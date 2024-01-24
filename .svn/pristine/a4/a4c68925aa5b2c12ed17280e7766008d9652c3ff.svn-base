using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class LogReplyFormPresenter : AbstractFormPresenter<ILogReplyFormView, Log>, ILogReplyFormPresenter
    {
        private readonly ILogService logService;
        private readonly Log replyToLog;        

        private readonly DateTime logDateTime;

        public LogReplyFormPresenter(ILogReplyFormView view, long replyToLogId) : this(view, replyToLogId, null)
        {
        }

        public LogReplyFormPresenter(ILogReplyFormView view, long replyToLogId, Log editObject)
            : base(view, editObject)
        {
            logService = ClientServiceRegistry.Instance.GetService<ILogService>();
            replyToLog = logService.QueryById(replyToLogId);
                        
            logDateTime = Clock.Now;
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {                        
            UpdateViewWithDefaults();                       

            if (IsEdit)
            {
                UpdateViewFromEditObject();
            }

            string title = null;

            if (replyToLog.LogType == LogType.DailyDirective)
            {
                view.HideOptions();
                view.ParentEntryLineLabel = StringResources.DirectiveParentEntryLineLabel;
                title = StringResources.DirectiveReplyTitle;
                view.EntryReplyDetailsLabelLine = StringResources.DirectiveEntryReplyDetailsLabelLine;
                view.CommentLabelLine = StringResources.DirectiveCommentsLabelLine;
                view.ParentLogTimeGroupBoxText = StringResources.DirectiveParentLogTimeGroupBoxText;
                view.LogTimeGroupBoxText = StringResources.DirectiveParentLogTimeGroupBoxText;
            }
            else
            {
                view.ParentEntryLineLabel = StringResources.LogParentEntryLineLabel;
                title = StringResources.LogReplyTitle;
                view.EntryReplyDetailsLabelLine = StringResources.LogEntryReplyDetailsLabelLine;
                view.CommentLabelLine = StringResources.LogCommentsLabelLine;
                view.ParentLogTimeGroupBoxText = StringResources.LogParentLogTimeGroupBoxText;
                view.LogTimeGroupBoxText = StringResources.LogParentLogTimeGroupBoxText;
            }

            view.UpdateTitleAsCreateOrEdit(IsEdit, title);

            if (replyToLog.LogType == LogType.Standard && !ClientSession.GetUserContext().SiteConfiguration.ShowFollowupOnLogForm)
            {
                view.HideFollowupFlags();
            }

            if(!ClientSession.GetUserContext().SiteConfiguration.CreateOperatingEngineerLogs)
            {
                view.HideOperatingEngineerCheckBox();
            }
        }

        private void UpdateViewFromEditObject()
        {
            view.RecommendForShiftSummary = editObject.RecommendForShiftSummary;
            view.OperationsFollowUp = editObject.OperationsFollowUp;
            view.ProcessControlFollowUp = editObject.ProcessControlFollowUp;
            view.SupervisionFollowUp = editObject.SupervisionFollowUp;
            view.InspectionFollowUp = editObject.InspectionFollowUp;
            view.EHSFollowUp = editObject.EnvironmentalHealthSafetyFollowUp;
            view.OtherFollowUp = editObject.OtherFollowUp;
            view.Author = editObject.CreationUser != null ? editObject.CreationUser.FullNameWithUserName : "";
            view.LogDateTime = editObject.LogDateTime;
            view.Shift = editObject.CreatedShiftPattern.Name;
            view.IsOperatingEngineer = editObject.IsOperatingEngineerLog;
            view.Comments = editObject.RtfComments;
            view.DocumentLinks = editObject.DocumentLinks;
        }

        protected void UpdateViewWithDefaults()
        {
            view.Author = userContext.User.FullNameWithUserName;
            view.FunctionalLocations = replyToLog.FunctionalLocations;
            view.LogDateTime = logDateTime;
            view.Shift = userContext.UserShift.ShiftPattern.Name;
            view.ParentAuthor = replyToLog.LastModifiedBy.FullNameWithUserName;
            view.ParentComments = replyToLog.RtfComments;
            view.ParentLogDateTime = replyToLog.LogDateTime;
            view.ParentShift = replyToLog.CreatedShiftPattern.Name;
            SetupOperatingEngineerDefaultInfo();
            view.Comments = string.Empty;
            view.DocumentLinks = new List<DocumentLink>();
        }

        private void SetupOperatingEngineerDefaultInfo()
        {
            view.IsOperatingEngineer = replyToLog.IsOperatingEngineerLog;

            SiteConfiguration siteConfiguration = userContext.SiteConfiguration;

            if (!siteConfiguration.CreateOperatingEngineerLogs)
            {
                view.DisableOperatingEngineerLogs();
            }
            view.OperatingEngineerDisplayText = siteConfiguration.OperatingEngineerLogDisplayName;
        }
        
        public override bool ValidateViewHasError()
        {
            view.ClearErrorProviders();

            bool hasError = false;

            if (view.IsCommentEmpty)
            {
                view.SetCommentsBlankError();
                hasError = true;
            }

            return hasError;
        }

        public override void Insert(SaveUpdateDomainObjectContainer<Log> container)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(logService.Insert, container.Item);
        }

        public override void Update(SaveUpdateDomainObjectContainer<Log> container)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(logService.Update, editObject);
        }

        protected override SaveUpdateDomainObjectContainer<Log> GetNewObjectToInsert()
        {
            DateTime now = Clock.Now;
            Log log = new Log(null,
                              null,
                              null,
                              DataSource.MANUAL,
                              replyToLog.FunctionalLocations,
                              view.InspectionFollowUp,
                              view.ProcessControlFollowUp,
                              view.OperationsFollowUp,
                              view.SupervisionFollowUp,
                              view.EHSFollowUp,
                              view.OtherFollowUp,
                              view.Comments,
                              view.CommentsAsPlainText,
                              logDateTime,
                              userContext.UserShift.ShiftPattern,
                              userContext.User,
                              userContext.User,
                              now,
                              now,
                              false,
                              view.IsOperatingEngineer,
                              userContext.Role,
                              view.DocumentLinks,
                              replyToLog.LogType,
                              view.RecommendForShiftSummary,
                              replyToLog.WorkAssignment,
                              null,
                              null);

            log.SetReplyTo(replyToLog);

            return new SaveUpdateDomainObjectContainer<Log>(log);
        }

        protected override SaveUpdateDomainObjectContainer<Log> GetPopulatedEditObjectToUpdate()
        {
            UpdateEditLogFromView();
            return new SaveUpdateDomainObjectContainer<Log>(editObject);
        }
     
        private void UpdateEditLogFromView()
        {
            editObject.InspectionFollowUp = view.InspectionFollowUp;
            editObject.OperationsFollowUp = view.OperationsFollowUp;
            editObject.ProcessControlFollowUp = view.ProcessControlFollowUp;
            editObject.SupervisionFollowUp = view.SupervisionFollowUp;
            editObject.EnvironmentalHealthSafetyFollowUp = view.EHSFollowUp;
            editObject.OtherFollowUp = view.OtherFollowUp;
            editObject.RecommendForShiftSummary = view.RecommendForShiftSummary;
            editObject.LastModifiedBy = userContext.User;
            editObject.LastModifiedDate = Clock.Now;
            editObject.IsOperatingEngineerLog = view.IsOperatingEngineer;
            editObject.RtfComments = view.Comments;
            editObject.PlainTextComments = view.CommentsAsPlainText;
            editObject.DocumentLinks = view.DocumentLinks;
        }

        public void HandleLogCommentGuidelineLinkClick(object sender, EventArgs e)
        {
            List<LogGuideline> logGuidelines = GuidelineUtilities.GetGuidelines(
                ClientSession.GetUserContext().DivisionsForSelectedFunctionalLocations, logService);
            view.ShowGuidelines(logGuidelines);
        }
    }
}