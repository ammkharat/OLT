using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client
{
    public class ShiftHandoverCommentTextRenderer
    {
        private readonly ICommentsBuilder commentsBuilder;

        public ShiftHandoverCommentTextRenderer(ICommentsBuilder commentsBuilder)
        {
            this.commentsBuilder = commentsBuilder;
        }

        public void RenderCommentText(ShiftHandoverQuestionnaire handover, List<HasCommentsDTO> summaryLogs, List<HasCommentsDTO> logs)
        {
            commentsBuilder.Clear();

            bool thereAreBothSummaryLogAndRegularLogComments = summaryLogs.Count > 0 && logs.Count > 0;

            string summaryLogsTitle =
                thereAreBothSummaryLogAndRegularLogComments ? StringResources.ShiftHandoverCommentRenderer_SummaryLogs : null;
            string shiftLogsTitle = 
                thereAreBothSummaryLogAndRegularLogComments ? StringResources.ShiftHandoverCommentRenderer_ShiftLogs : null;

            bool sameUserForEverything = handover.IsSameUser(summaryLogs) && handover.IsSameUser(logs);

            BuildMainCommentsSection(handover, summaryLogs, summaryLogsTitle, sameUserForEverything);            
            BuildMainCommentsSection(handover, logs, shiftLogsTitle, sameUserForEverything);
        }

        private void BuildMainCommentsSection(ShiftHandoverQuestionnaire handover, List<HasCommentsDTO> items, string sectionTitle, bool isSameUserForeverything)
        {
            if (items == null)
            {
                items = new List<HasCommentsDTO>();
            }

            bool hasRows = items.Count > 0;

            if (hasRows)
            {
                if (sectionTitle != null)
                {
                    commentsBuilder.SetTitle(sectionTitle);
                }

                IOrderedEnumerable<IGrouping<string, DatedComment>> orderedGroups = items
                    .GroupBy(item => item.CreationUserFullName,
                             item => new DatedComment(item.RtfComments, item.LogDateTime, item.FunctionalLocationsAsCommaSeparatedFullHierarchyList))
                    .OrderBy(group => group.Key);

                bool shouldShowFlocHeader = DetermineWhetherToShowFLOCHeader(handover, items);

                foreach (IGrouping<string, DatedComment> grouping in orderedGroups)
                {
                    string userName = grouping.Key;

                    if (!isSameUserForeverything)
                    {
                        commentsBuilder.AddUserHeader(userName);
                    }

                    IOrderedEnumerable<DatedComment> orderedCommentsForGroup = grouping.FindAll(item => !string.IsNullOrEmpty(item.Comment)).OrderBy(item => item.Date);                    
                    
                    DatedComment[] datedComments = orderedCommentsForGroup.ToArray();
                    for (int i = 0; i < datedComments.Length; i++)
                    {
                        DatedComment comment = datedComments[i];

                        WorkAssignment workAssignment = handover.Assignment;
                        // TODO: Remove the check for Site Edmonton in the future.
                        bool hasSameFunctionalLocations = workAssignment.SiteId == Site.EDMONTON_ID && workAssignment.HasSameFunctionalLocations(comment.LogFlocListString);

                        string locationText = hasSameFunctionalLocations
                                                            ? string.Empty
                                                            : comment.LogFlocListString;


                        string logHeader = locationText; //comment.LogFlocListString;

                        if (shouldShowFlocHeader)
                        {
                            commentsBuilder.AddLogHeader(logHeader, comment.Date.ToTimeString());
                        }
                        else
                        {
                            commentsBuilder.AddLogTime(comment.Date.ToTimeString());
                        }

                        commentsBuilder.AddComment(
                            comment.Comment, i == 0, i == datedComments.Length - 1);
                    }
                }
            }                        
        }

        private static bool DetermineWhetherToShowFLOCHeader(ShiftHandoverQuestionnaire handover, List<HasCommentsDTO> commentItem)
        {
            string handoverFlocs = handover.FunctionalLocations.FullHierarchyListToString(true, false);
            string assignmentFlocs = handover.Assignment != null
                                         ? handover.Assignment.FunctionalLocations.FullHierarchyListToString(true, false)
                                         : string.Empty;


            foreach (HasCommentsDTO item in commentItem)
            {
                string itemFlocNames = item.FunctionalLocationNames;
                bool allAreSame = string.Equals(itemFlocNames, handoverFlocs, StringComparison.Ordinal) && 
                    string.Equals(itemFlocNames, assignmentFlocs, StringComparison.Ordinal);

                if (!allAreSame)
                {
                    return true;
                }
            }

            return false;
        }

        private class DatedComment
        {
            private readonly string comment;
            private readonly DateTime date;
            private readonly string flocsAsCommaSeparatedString;

            public DatedComment(string comment, DateTime date, string flocsAsCommaSeparatedString)
            {
                this.comment = comment;
                this.date = date.GetNetworkPortable();
                this.flocsAsCommaSeparatedString = flocsAsCommaSeparatedString;
            }

            public string Comment
            {
                get { return comment; }
            }

            public DateTime Date
            {
                get { return date; }
            }

            public string LogFlocListString
            {
                get { return flocsAsCommaSeparatedString; }
            }
        }

        public interface ICommentsBuilder
        {            
            void SetTitle(string title);
            void AddLogHeader(string text, string logTimeString);
            void AddLogTime(string logTime);
            void AddUserHeader(string userHeader);
            void AddComment(string text, bool isFirstComment, bool isLastComment);                        
            void Clear();
        }

        public class RichTextCommentsBuilder : ICommentsBuilder
        {
            private readonly RichTextDisplay richTextDisplay;

            public RichTextCommentsBuilder(RichTextDisplay richTextDisplay)
            {
                this.richTextDisplay = richTextDisplay;
            }

            public void Clear()
            {
                richTextDisplay.Clear();
            }

            public void SetTitle(string title)
            {
                title = title + Environment.NewLine;
                string rtfTitle = RichTextUtilities.ConvertTextToRTF(title, 14.0f, true, true, false);
                richTextDisplay.AppendText(rtfTitle);
            }

            public void AddUserHeader(string userHeader)
            {
                userHeader = userHeader + Environment.NewLine;
                string rtfText = RichTextUtilities.ConvertTextToRTF(userHeader, UIConstants.RichTextDefaultFontSize + 2, true, false, true);
                richTextDisplay.AppendText(rtfText);
            }

            public void AddLogTime(string logTime)
            {                
                string label = StringResources.HandoverLogTimePrefix;

                //string logTimeString = string.Format("{0}: {1}{2}", label, logTime, Environment.NewLine);
                string logTimeString = string.Format("{0}{1}", logTime, Environment.NewLine);

                string rtfLogTimeString = RichTextUtilities.ConvertTextToRTF(logTimeString);
                rtfLogTimeString = RichTextUtilities.FormatDocumentSelection(
                        rtfLogTimeString, 0, label.Length + 1, UIConstants.RichTextDefaultFontSize, true, false, false);
               
                richTextDisplay.AppendText(rtfLogTimeString);
            }

            public void AddLogHeader(string text, string logTimeString)
            {
                string logHeader;
                if (text.IsNullOrEmptyOrWhitespace())
                {
                    logHeader = string.Format("{0}{1}", logTimeString, Environment.NewLine);
                }
                else
                {
                    logHeader = string.Format("{0} - {1}{2}", logTimeString, text, Environment.NewLine);    
                }
                
                string rtfText = RichTextUtilities.ConvertTextToRTF(
                    logHeader, UIConstants.RichTextDefaultFontSize, true, false, false);
                richTextDisplay.AppendText(rtfText);
            }

            public void AddComment(string text, bool isFirstComment, bool isLastComment)
            {
                string suffix = string.Empty;

                if (isFirstComment && isLastComment)
                {
                    suffix = "\n";
                }
                else if (!isLastComment)
                {
                    suffix = "_____________________________________________\n";
                }
                else
                {
                    suffix = "\n";
                }
                
                string rtfSuffix = RichTextUtilities.ConvertTextToRTF(suffix, 11.0f, false, false, false);

                richTextDisplay.AppendText(text);
                richTextDisplay.AppendText(rtfSuffix);
            } 
        }
    }
}