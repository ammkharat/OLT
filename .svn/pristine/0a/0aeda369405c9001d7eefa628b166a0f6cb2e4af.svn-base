using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    /// <summary>
    /// Abstract presenter to present a form for commenting on a particular 'commentable' entity.
    /// </summary>
    public abstract class CommentsFormPresenter
    {
        private readonly ICommentsFormView view;
        private readonly ICommentable commentable;
        protected readonly ILogService logService;        

        private bool shouldSkipConfirm;

        protected CommentsFormPresenter(
            ICommentsFormView view, 
            ICommentable commentable,
            ILogService logService)
        {
            this.view = view;
            this.commentable = commentable;
            this.logService = logService;            

            SubscribeToViewEvents();
        }

        /// <summary>
        /// Create a control to present a summary of the object we're commenting on.
        /// </summary>        
        protected abstract Control CreateSummaryView();

        protected abstract string FormTitle { get; }
        
        protected abstract List<FunctionalLocation> FindFunctionalLocations();

        protected abstract DataSource DataSource { get; }
        
        protected abstract void Update();

        private void SubscribeToViewEvents()
        {
            view.FormClosing += OnFormClosing;
            view.Load += HandleFormLoad;
            view.SubmitButtonClick += HandleSubmitButtonClick;
            view.CancelButtonClick += HandleCancelButtonClick;
            view.CreateLogCheckedChanged += HandleLogCreatedCheckChanged;          
        }

        private void HandleLogCreatedCheckChanged(object sender, EventArgs e)
        {
            SiteConfiguration siteConfiguration = ClientSession.GetUserContext().SiteConfiguration;

            bool enableLogAsOperatiingEngineeringLog = siteConfiguration.CreateOperatingEngineerLogs && view.IsLogRequired;
            view.EnableLogAsOperatingEngineeringLog(enableLogAsOperatiingEngineeringLog, siteConfiguration.OperatingEngineerLogDisplayName);
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            view.Title = FormTitle;
            UserContext userContext = ClientSession.GetUserContext();
            view.Author = userContext.User;
            view.CreateDateTime = Clock.Now;
            view.ShiftName = userContext.UserShift.ShiftPatternName;
            view.SummaryView = CreateSummaryView();
            SetupLogAsOperatingEngineer();
        }

        private void SetupLogAsOperatingEngineer()
        {
            SiteConfiguration siteConfiguration = ClientSession.GetUserContext().SiteConfiguration;

            if (!siteConfiguration.CreateOperatingEngineerLogs)
            {
                view.HideOperatingEngineerLogCheckbox();
            }
          
            view.IsLogAnOperatingEngineeringLog = false;            
        }
        
        public void HandleSubmitButtonClick(object sender, EventArgs e)
        {
            commentable.AddComment(MapViewToComment(ClientSession.GetUserContext().User));

            Update();

            if (view.IsLogRequired)
            {
                DateTime now = Clock.Now;
                List<FunctionalLocation> flocs = FindFunctionalLocations();
                InsertLog(CreateLog(now, flocs));
            }

            view.SaveSucceededMessage();
            shouldSkipConfirm = true;
        }

        protected virtual void InsertLog(Log log)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(logService.Insert, log);
        }

        private Comment MapViewToComment(User user)
        {
            commentable.LastModifiedBy = user;
            commentable.LastModifiedDate = Clock.Now;
            return new Comment(commentable.LastModifiedBy, commentable.LastModifiedDate, view.UserComments);
        }

        protected abstract string SummaryDescription(string newComments);

        private Log CreateLog(DateTime dateTime, List<FunctionalLocation> flocs)
        {
            UserContext context = ClientSession.GetUserContext();
            string comments = GetComments();

            return new Log(null, null, null,
                           DataSource,
                           flocs,
                           false, false, false, false, false, false,                           
                           comments,
                           comments,
                           dateTime,
                           context.UserShift.ShiftPattern,
                           context.User,
                           context.User,
                           dateTime,
                           dateTime,
                           false,
                           view.IsLogAnOperatingEngineeringLog,
                           context.Role,
                           LogType.Standard,
                           context.Assignment);
        }
       
        private string GetComments()
        {
            return SummaryDescription(view.UserComments);
        }

        private void HandleCancelButtonClick(object sender, EventArgs e)
        {            
            view.Close();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs eventArgs)
        {
            if (!ClientSession.GetInstance().ForceLogoff && !shouldSkipConfirm && !view.ConfirmCancelDialog())
            {
                eventArgs.Cancel = true;
            }
        }
    }
}
