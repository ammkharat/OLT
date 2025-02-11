using System;
using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitMontrealCloseFormPresenter : BaseFormPresenter<IWorkPermitCloseWithStatusFormView>
    {
        private readonly List<WorkPermitMontreal> permits;
        private readonly IWorkPermitMontrealService workPermitMontrealService;
        private readonly ISiteConfigurationService siteConfigurationService;

        public WorkPermitMontrealCloseFormPresenter(List<WorkPermitMontreal> permits) : base(new WorkPermitCloseWithStatusForm())
        {
            this.permits = permits;
            workPermitMontrealService = ClientServiceRegistry.Instance.GetService<IWorkPermitMontrealService>();
            siteConfigurationService = ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>();

            SubscribeToViewEvents();
        }

        private void SubscribeToViewEvents()
        {
            view.Load += HandleFormLoad;
            view.CancelButtonClick += CancelButton_Click;
            view.SubmitButtonClick += HandleSubmit;
        }

        private void HandleFormLoad(object sender, EventArgs e)
        {
            view.CommentsSectionTitle = StringResources.WorkPermitMontreal_CloseForm_CommentsTitle;
            view.Author = ClientSession.GetUserContext().User;
            view.CreateDateTime = Clock.Now;
            view.Shift = ClientSession.GetUserContext().UserShift.ShiftPatternName;

            view.FormTitle = StringResources.WorkPermitCloseFormTitle;

            if (permits.Count == 1)
            {
                view.Description = permits[0].DescriptionForLog();
            }
            else
            {
                StringBuilder builder = new StringBuilder(StringResources.WorkPermitCommentOnMultiplePermits);
                builder.AppendLine();
                builder.AppendLine();

                permits.Sort();
                foreach (WorkPermitMontreal permit in permits)
                {
                    builder.AppendLine("-------------------------------------");
                    builder.Append(permit.DescriptionForLog());
                    builder.AppendLine();
                    builder.AppendLine();
                }
                view.Description = builder.ToString();
            }

            List<WorkPermitLoggableStatus> statuses = siteConfigurationService.QueryWorkPermitStatusesForClosingBySite(ClientSession.GetUserContext().SiteId);
            statuses.Insert(0, WorkPermitLoggableStatus.EMPTY);
            view.Statuses = statuses;
        }

        private void HandleSubmit(object sender, EventArgs e)
        {
            try
            {
                if (!Valid())
                {
                    return;
                }

                DateTime now = Clock.Now;
                User user = ClientSession.GetUserContext().User;
                Role role = ClientSession.GetUserContext().Role;
                WorkAssignment workAssignment = ClientSession.GetUserContext().Assignment;
                ShiftPattern shift = ClientSession.GetUserContext().UserShift.ShiftPattern;

                Dictionary<long, Log> permitIdToAssociatedLogMap = new Dictionary<long, Log>();
                foreach (WorkPermitMontreal permit in permits)
                {
                    permit.WorkPermitStatus = view.SelectedStatus.Status;
                    permit.LastModifiedBy = user;
                    permit.LastModifiedDateTime = now;

                    if (!view.Comment.IsNullOrEmptyOrWhitespace())
                    {
                        permitIdToAssociatedLogMap.Add(permit.IdValue, CreateLog(now, user, role, workAssignment, shift, permit));
                    }
                }

                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitMontrealService.UpdateAndInsertLogs, permits, permitIdToAssociatedLogMap);                    

                view.SaveSucceededMessage();
                view.Close();
            }
            catch (Exception)
            {
                view.SaveFailedMessage();
            }
        }

        private Log CreateLog(
            DateTime now, User user, Role role, WorkAssignment workAssignment, ShiftPattern shift, 
            WorkPermitMontreal permit)
        {
            string logComments = view.Comment;   // this will be altered on the server side to add in permit-related info

            Log log = new Log(null, null, null, 
                              DataSource.PERMIT,
                              permit.FunctionalLocations,
                              false, false, false, false, false, false,
                              logComments, logComments,
                              now, shift, user, user, now, now,
                              false, 
                              false,
                              role,
                              LogType.Standard,
                              workAssignment);
            return log;
        }

        private bool Valid()
        {
            bool isValid = true;
            view.ClearErrors();
            
            if (view.SelectedStatus == null || view.SelectedStatus == WorkPermitLoggableStatus.EMPTY)
            {
                view.SetErrorForNoStatusSelected();
                isValid = false;
            }

            if (view.SelectedStatus != null && view.SelectedStatus.RequiresLog && view.Comment.IsNullOrEmptyOrWhitespace())
            {
                view.SetErrorForNoComments();
                isValid = false;
            }

            return isValid;
        }
    }
}