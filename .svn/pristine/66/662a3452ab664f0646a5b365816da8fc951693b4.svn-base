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
    public class SummaryLogReplyFormPresenter : AbstractFormPresenter<ILogReplyFormView, SummaryLog>, ILogReplyFormPresenter
    {
        private readonly ISummaryLogService summaryLogService;
        private readonly ILogService logService;
        private readonly SummaryLog replyToLog;        

        private readonly DateTime logDateTime;

        public SummaryLogReplyFormPresenter(ILogReplyFormView view, long replyToLogId) : this(view, replyToLogId, null)
        {
        }

        public SummaryLogReplyFormPresenter(ILogReplyFormView view, long replyToLogId, SummaryLog editObject) : base(view, editObject)
        {
            summaryLogService = ClientServiceRegistry.Instance.GetService<ISummaryLogService>();
            logService = ClientServiceRegistry.Instance.GetService<ILogService>();
            replyToLog = summaryLogService.QueryById(replyToLogId);
                        
            logDateTime = Clock.Now;
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {              
            view.HideOptions();

            UpdateViewWithDefaults();                       

            if (IsEdit)
            {
                UpdateViewFromEditObject();
            }

            view.ParentEntryLineLabel = StringResources.LogParentEntryLineLabel;
            string title = StringResources.SummaryLogReplyTitle; 
            view.EntryReplyDetailsLabelLine = StringResources.LogEntryReplyDetailsLabelLine;
            view.CommentLabelLine = StringResources.LogCommentsLabelLine;
            view.ParentLogTimeGroupBoxText = StringResources.LogParentLogTimeGroupBoxText;
            view.LogTimeGroupBoxText = StringResources.LogParentLogTimeGroupBoxText;      

            view.UpdateTitleAsCreateOrEdit(IsEdit, title);                     
        }

        private void UpdateViewFromEditObject()
        {            
            view.OperationsFollowUp = editObject.OperationsFollowUp;
            view.ProcessControlFollowUp = editObject.ProcessControlFollowUp;
            view.SupervisionFollowUp = editObject.SupervisionFollowUp;
            view.InspectionFollowUp = editObject.InspectionFollowUp;
            view.EHSFollowUp = editObject.EnvironmentalHealthSafetyFollowUp;
            view.OtherFollowUp = editObject.OtherFollowUp;
            view.Author = editObject.CreationUser != null ? editObject.CreationUser.FullNameWithUserName : "";
            view.LogDateTime = editObject.LogDateTime;
            view.Shift = editObject.CreatedShiftPattern.Name;            
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
            view.Comments = string.Empty;
            view.DocumentLinks = new List<DocumentLink>();
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

        public override void Insert(SaveUpdateDomainObjectContainer<SummaryLog> container)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(summaryLogService.Insert, container.Item);
        }

        public override void Update(SaveUpdateDomainObjectContainer<SummaryLog> container)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(summaryLogService.Update, container.Item);
        }

        protected override SaveUpdateDomainObjectContainer<SummaryLog> GetNewObjectToInsert()
        {
            DateTime now = Clock.Now;

            SummaryLog log = new SummaryLog(
                replyToLog.FunctionalLocations,
                view.Comments,
                view.CommentsAsPlainText,
                null,
                DataSource.MANUAL,
                view.InspectionFollowUp,
                view.ProcessControlFollowUp,
                view.OperationsFollowUp,
                view.SupervisionFollowUp,
                view.EHSFollowUp,
                view.OtherFollowUp,
                logDateTime,
                now,
                userContext.UserShift.ShiftPattern,
                userContext.User,
                userContext.Role,
                userContext.User,
                now,
                view.DocumentLinks,
                replyToLog.WorkAssignment,
                null, null,
                null, null, false);

            log.SetReplyTo(replyToLog);

            return new SaveUpdateDomainObjectContainer<SummaryLog>(log);
        }

        protected override SaveUpdateDomainObjectContainer<SummaryLog> GetPopulatedEditObjectToUpdate()
        {
            UpdateEditLogFromView();
            return new SaveUpdateDomainObjectContainer<SummaryLog>(editObject);
        }
    
        private void UpdateEditLogFromView()
        {
            editObject.InspectionFollowUp = view.InspectionFollowUp;
            editObject.OperationsFollowUp = view.OperationsFollowUp;
            editObject.ProcessControlFollowUp = view.ProcessControlFollowUp;
            editObject.SupervisionFollowUp = view.SupervisionFollowUp;
            editObject.EnvironmentalHealthSafetyFollowUp = view.EHSFollowUp;
            editObject.OtherFollowUp = view.OtherFollowUp;            
            editObject.LastModifiedBy = userContext.User;
            editObject.LastModifiedDate = Clock.Now;            
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