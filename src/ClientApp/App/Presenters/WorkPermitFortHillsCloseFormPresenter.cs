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
using log4net;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitFortHillsCloseFormPresenter : BaseFormPresenter<IWorkPermitCloseWithStatusFormView>
    {
        private readonly List<WorkPermitFortHills> permits;
        private readonly IWorkPermitFortHillsService workPermitEdmontonService;
        private readonly ISiteConfigurationService siteConfigurationService;

        private static readonly ILog logger = LogManager.GetLogger(typeof(WorkPermitFortHillsCloseFormPresenter));

        public WorkPermitFortHillsCloseFormPresenter(List<WorkPermitFortHills> permits)
            : base(new WorkPermitCloseWithStatusForm())
        {
            this.permits = permits;
            workPermitEdmontonService = ClientServiceRegistry.Instance.GetService<IWorkPermitFortHillsService>();
            siteConfigurationService = ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>();
            
            SubscribeToViewEvents();
        }

        private void SubscribeToViewEvents()
        {
            view.Load += Form_Load;
            view.CancelButtonClick += CancelButton_Click;
            view.SubmitButtonClick += Submit;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            view.Author = ClientSession.GetUserContext().User;
            view.CreateDateTime = Clock.Now;
            view.Shift = ClientSession.GetUserContext().UserShift.ShiftPatternName;

            view.FormTitle = StringResources.WorkPermitCloseFormTitle;
            
            if (permits.Count == 1)
            {
                view.Description = permits[0].DescriptionForLog;
            }
            else
            {
                StringBuilder builder = new StringBuilder(StringResources.WorkPermitCommentOnMultiplePermits);
                builder.AppendLine();
                builder.AppendLine();

                permits.Sort();
                foreach(WorkPermitFortHills permit in permits)
                {
                    builder.AppendLine("-------------------------------------");
                    builder.Append(permit.DescriptionForLog);
                    builder.AppendLine();
                    builder.AppendLine();
                }
                view.Description = builder.ToString();
            }

            List<WorkPermitLoggableStatus> statuses = siteConfigurationService.QueryWorkPermitStatusesForClosingBySite(ClientSession.GetUserContext().SiteId);
            statuses.Insert(0, WorkPermitLoggableStatus.EMPTY);
            view.Statuses = statuses;
        }

        private void Submit(object sender, EventArgs e)
        {
            try
            {
                if (Valid())
                {
                    DateTime now = Clock.Now;
                    User user = ClientSession.GetUserContext().User;
                    Role role = ClientSession.GetUserContext().Role;
                    WorkAssignment workAssignment = ClientSession.GetUserContext().Assignment;
                    ShiftPattern shift = ClientSession.GetUserContext().UserShift.ShiftPattern;

                    Dictionary<long, Log> permitIdToAssociatedLogMap = new Dictionary<long, Log>();

                    foreach (WorkPermitFortHills permit in permits)
                    {
                        permit.WorkPermitStatus = view.SelectedStatus.Status;
                        permit.LastModifiedBy = user;
                        permit.LastModifiedDateTime = now;

                        Log log = CreateLog(now, user, role, workAssignment, shift, permit); // ||Create action item here.... ****** AI ******

                        if (view.Comment.HasValue())                                         // ||Create action item here.... ****** AI ******    
                        {                                                                    // ||Create action item here.... ****** AI ******
                            permitIdToAssociatedLogMap.Add(permit.IdValue, log);             // ||Create action item here.... ****** AI ******
                        }
                    }
                   //Create action item here.... ****** AI ******
                   ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitEdmontonService.UpdateAndInsertLogs, permits, permitIdToAssociatedLogMap); //|| add Action item association here                           

                    view.SaveSucceededMessage();
                    view.Close();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                view.SaveFailedMessage();
            }
        }

        private bool Valid()
        {
            bool isValid = true;
            view.ClearErrors();
            if (!view.StatusHidden && (view.SelectedStatus == null || view.SelectedStatus == WorkPermitLoggableStatus.EMPTY))
            {
                view.SetErrorForNoStatusSelected();
                isValid = false;
            }
            if (!view.StatusHidden && view.SelectedStatus != null &&
                view.SelectedStatus != WorkPermitLoggableStatus.EMPTY && view.SelectedStatus.RequiresLog &&
                view.Comment.IsNullOrEmptyOrWhitespace())
            {
                view.SetErrorForNoComments();
                isValid = false;
            }
            return isValid;
        }

        private Log CreateLog(
            DateTime now, User user, Role role, WorkAssignment workAssignment, ShiftPattern shift,
            WorkPermitFortHills permit)
        {
            string logComments = view.Comment;   // this will be altered on the server side to add in permit-related info

            bool recommendForShiftSummary = !view.StatusHidden &&
                                            view.SelectedStatus.Status == PermitRequestBasedWorkPermitStatus.Incomplete;

            Log log = new Log(null, null, null, 
                              DataSource.PERMIT,
                              new List<FunctionalLocation> { permit.FunctionalLocation },
                              false, false, false, false, false, false,
                              logComments, logComments,
                              now, shift, user, user, now, now,
                              false, 
                              false,
                              role, new List<DocumentLink>(0), 
                              LogType.Standard,
                              recommendForShiftSummary,
                              workAssignment, new List<CustomFieldEntry>(0), new List<CustomField>(0));
            return log;
        }
        
    }
}