using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using iTextSharp.text.pdf;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitMudsCloseFormPresenter : BaseFormPresenter<IWorkPermitCloseWithStatusFormView>
    {
        private readonly List<WorkPermitMuds> permits;
        private readonly IWorkPermitMudsService workPermitMudsService;
        private readonly ISiteConfigurationService siteConfigurationService;

        public WorkPermitMudsCloseFormPresenter(List<WorkPermitMuds> permits) : base(new WorkPermitCloseWithStatusForm())
        {
            this.permits = permits;
            workPermitMudsService = ClientServiceRegistry.Instance.GetService<IWorkPermitMudsService>();
            siteConfigurationService = ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>();

            SubscribeToViewEvents();
        }

        private void SubscribeToViewEvents()
        {
            view.Load += HandleFormLoad;
            view.CancelButtonClick += CancelButton_Click;
            view.SubmitButtonClick += HandleSubmit;
            view.ActionItemCheckboxCheck += HandleActionItemCheckboxCheck;
        }

        private void HandleFormLoad(object sender, EventArgs e)
        {
            view.CommentsSectionTitle = StringResources.WorkPermitMontreal_CloseForm_CommentsTitle;
            view.Author = ClientSession.GetUserContext().User;
            view.CreateDateTime = Clock.Now;
            view.Shift = ClientSession.GetUserContext().UserShift.ShiftPatternName;
            view.ActionItemCheckBoxVisible = true;
            view.dateTimeControlVisible = true;
            view.commentBoxVisible = true;
           // view.txtSuggestionVisible = true;
         //   view.hotpanelVisible = true;
            

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
                foreach (WorkPermitMuds permit in permits)
                {
                    builder.AppendLine("-------------------------------------");
                    builder.Append(permit.DescriptionForLog());
                    builder.AppendLine();
                    builder.AppendLine();
                }
                view.Description = builder.ToString();
            }
            if (permits.Count==1)
            {
                if (permits[0].WorkPermitType.IdValue == 1)
                {
                    view.ActionItemCheckBoxVisible = true;
                    view.commentBoxVisible = true;
                   // view.txtSuggestionVisible = true;
                   view.dateTimeControlVisible = true;
                   //view.hotpanelVisible = true;
                    
                }
                else
                {
                   view.ActionItemCheckBoxVisible = false;
                  view.commentBoxVisible = false;
                   // view.txtSuggestionVisible = false;
                  view.dateTimeControlVisible = false;
                   // view.hotpanelVisible = false;
                  
                  //view.SetSize = new Size(593, 40);
                 // view.mainPanelSize = new Size(593, 411);
                  view.setFormSize = new Size(609, 472);
                }

            }

            if (view.ActionItemCheckBoxchecked)
            {
                view.commentBoxEnable = false;
                view.dateTimeControlEnable = false;
            }
            else
            {
                view.commentBoxVisible = true;
                view.dateTimeControlEnable = true;
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
                foreach (WorkPermitMuds permit in permits)
                {
                    permit.WorkPermitStatus = view.SelectedStatus.Status;
                    permit.LastModifiedBy = user;
                    permit.LastModifiedDateTime = now;
                   // if (Convert.ToString(permit.WorkPermitStatus)== Convert.ToString(WorkPermitStatus.Complete))
                    if (permit.WorkPermitStatus.IdValue == 4 || permit.WorkPermitStatus.IdValue == 6 || permit.WorkPermitStatus.IdValue == 7 || permit.WorkPermitStatus.IdValue == 9)
                    { 
                        if (permit.WorkPermitType.IdValue == 1)
                        {
                            if (view.ActionItemCheckBoxchecked)
                            {
                                permit.ActionItemCheckBoxclick = view.ActionItemCheckBoxchecked;
                                permit.ActionItemCheckboxchecked = view.ActionItemCheckBoxchecked;  
                                // permit.ActionItemCloseById = ClientSession.GetUserContext().User.IdValue;
                                //permit.ActionItemCloseDateTime=view.
                                // permit.ActionItemCheckboxchecked=view

                            }
                            else
                            {

                                if (permit.WorkPermitType.IdValue == 1)
                                { 
                                    // view.commentBoxEnable = true;
                                    permit.WorkPermitCloseComments = view.WorkPermitCloseComment;
                                    permit.PermitCloseDateTime = view.ClosingDateTime;
                                    permit.WorkpermitClosedById = ClientSession.GetUserContext().User.IdValue;
                                }
                            }
                        }
                    }
                    else
                    {
                        view.ActionItemCheckBoxEnable = false;
                        view.commentBoxEnable = false;
                        view.dateTimeControlEnable = false;
                        permit.PermitCloseDateTime = null;
                        permit.WorkpermitClosedById = 0;
                        permit.WorkPermitCloseComments = null;

                    }


                    if (!view.Comment.IsNullOrEmptyOrWhitespace())
                    {
                        permitIdToAssociatedLogMap.Add(permit.IdValue, CreateLog(now, user, role, workAssignment, shift, permit));
                    }
                }
               
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitMudsService.UpdateAndInsertLogs, permits, permitIdToAssociatedLogMap);                    

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
            WorkPermitMuds permit)
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

        private void HandleActionItemCheckboxCheck(Object sender, EventArgs e)
        {
            if (view.ActionItemCheckBoxchecked)
            {
                view.commentBoxEnable = false;
                view.dateTimeControlEnable = false;
            }
            else
            {
                view.commentBoxEnable = true;
                view.dateTimeControlEnable = true;
            }
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
            if (!view.WorkPermitCloseComment.HasValue() && !view.ActionItemCheckBoxchecked)
            {
                view.SetErrorForNoActionItemComments();
                isValid = false;
            }

            return isValid;
        }
    }
}