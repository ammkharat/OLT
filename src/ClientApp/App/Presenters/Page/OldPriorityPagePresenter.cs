using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Validation;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public delegate void ActionItemAction(ActionItemDTO actionItem);
    public delegate void TargetAlertAction(TargetAlertDTO targetAlert);
    public delegate void WorkPermitAction(WorkPermitDTO workPermit);
    public delegate void DeviationAlertAction(DeviationAlertDTO alert);
    public delegate void ShiftHandoverQuestionnaireAction(ShiftHandoverQuestionnaireDTO shiftHandoverQuestionnaireDto);
    
    public class OldPriorityPagePresenter
    {
        private readonly IOldPriorityPage page;
        private readonly IActionItemService actionItemService;
        private readonly ITargetAlertService targetAlertService;
        private readonly IWorkPermitService workPermitService;
        private readonly IGasTestElementInfoService gasTestElementInfoService;
        private readonly IDeviationAlertService deviationAlertService;
        private readonly ILabAlertService labAlertService;
        private readonly IShiftHandoverService shiftHandoverService;
        private readonly IAuthorized authorized;
        private readonly IRemoteEventRepeater remoteEventRepeater;

        public OldPriorityPagePresenter(
            IOldPriorityPage page, 
            IRemoteEventRepeater remoteEventRepeater, 
            IAuthorized authorized,
            IActionItemService actionItemService,
            ITargetAlertService targetAlertService,
            IWorkPermitService workPermitService,
            IGasTestElementInfoService gasTestElementInfoService,
            IDeviationAlertService deviationAlertService,
            ILabAlertService labAlertService,
            IShiftHandoverService shiftHandoverService)
        {
            this.page = page;
            this.actionItemService = actionItemService;
            this.targetAlertService = targetAlertService;
            this.workPermitService = workPermitService;
            this.gasTestElementInfoService = gasTestElementInfoService;
            this.deviationAlertService = deviationAlertService;
            this.labAlertService = labAlertService;
            this.shiftHandoverService = shiftHandoverService;
            this.authorized = authorized;
            this.remoteEventRepeater = remoteEventRepeater;
        }

        public OldPriorityPagePresenter(IOldPriorityPage page)
            : this(
            page,
            ClientServiceRegistry.Instance.RemoteEventRepeater,
            new Authorized(),
            ClientServiceRegistry.Instance.GetService<IActionItemService>(),
            ClientServiceRegistry.Instance.GetService<ITargetAlertService>(),
            ClientServiceRegistry.Instance.GetService<IWorkPermitService>(),
            ClientServiceRegistry.Instance.GetService<IGasTestElementInfoService>(),
            ClientServiceRegistry.Instance.GetService<IDeviationAlertService>(),
            ClientServiceRegistry.Instance.GetService<ILabAlertService>(),
            ClientServiceRegistry.Instance.GetService<IShiftHandoverService>())
        {
        }

        public void PriorityPage_Load(object sender, EventArgs e)
        {
            remoteEventRepeater.ServerActionItemCreated += Repeater_ServerActionItemCreated;
            remoteEventRepeater.ServerActionItemUpdated += Repeater_ServerActionItemUpdated;
            remoteEventRepeater.ServerActionItemRemoved += Repeater_ServerActionItemRemoved;
            remoteEventRepeater.ServerActionItemRefresh += Repeater_ServerActionItemRefresh;

            remoteEventRepeater.ServerTargetAlertCreated += Repeater_ServerTargetAlertCreated;
            remoteEventRepeater.ServerTargetAlertUpdated += Repeater_ServerTargetAlertUpdated;

            remoteEventRepeater.ServerWorkPermitCreated += Repeater_ServerWorkPermitCreated;
            remoteEventRepeater.ServerWorkPermitUpdated += Repeater_ServerWorkPermitUpdated;
            remoteEventRepeater.ServerWorkPermitRemoved += Repeater_ServerWorkPermitRemoved;

            remoteEventRepeater.ServerDeviationAlertCreated += Repeater_ServerDeviationAlertCreated;
            remoteEventRepeater.ServerDeviationAlertUpdated += Repeater_ServerDeviationAlertUpdated;

            remoteEventRepeater.ServerLabAlertCreated += Repeater_ServerLabAlertCreated;
            remoteEventRepeater.ServerLabAlertUpdated += Repeater_ServerLabAlertUpdated;

            remoteEventRepeater.ServerShiftHandoverQuestionnaireCreated += Repeater_ServerShiftHandoverQuestionnaireCreated;
            remoteEventRepeater.ServerShiftHandoverQuestionnaireRemoved += Repeater_ServerShiftHandoverQuestionnaireRemoved;
            remoteEventRepeater.ServerShiftHandoverQuestionnaireUpdated += Repeater_ServerShiftHandoverQuestionnaireUpdated;

            // Whoever is going to revamp the Priority Page, don't forget to plug into the WorkPermitMontreal events.
            CheckSecurityAndLoadData();
            page.SetPanelVisibility();
        }

        private void Repeater_ServerShiftHandoverQuestionnaireCreated(object sender, DomainEventArgs<ShiftHandoverQuestionnaire> eventArgs)
        {
            if (page.IsDisposed)
            {
                return;
            }

            UserContext userContext = ClientSession.GetUserContext();
            ShiftHandoverQuestionnaire handoverQuestionnaire = eventArgs.SelectedItem;
            if (handoverQuestionnaire.IsAPriority(userContext.User, userContext.Assignment, userContext.UserShift, Clock.Now))
            {
                ShiftHandoverQuestionnaireDTO dto = new ShiftHandoverQuestionnaireDTO(handoverQuestionnaire);
                page.Invoke(new ShiftHandoverQuestionnaireAction(page.AddShiftHandoverQuestionnaire), new object[] { dto });
            }
        }

        private void Repeater_ServerShiftHandoverQuestionnaireRemoved(object sender, DomainEventArgs<ShiftHandoverQuestionnaire> eventArgs)
        {
            if (page.IsDisposed)
            {
                return;
            }

            ShiftHandoverQuestionnaireDTO dto = new ShiftHandoverQuestionnaireDTO(eventArgs.SelectedItem);
            page.Invoke(new ShiftHandoverQuestionnaireAction(page.RemoveShiftHandoverQuestionnaire), new object[] { dto });
        }

        private void Repeater_ServerShiftHandoverQuestionnaireUpdated(object sender, DomainEventArgs<ShiftHandoverQuestionnaire> eventArgs)
        {
            if (page.IsDisposed)
            {
                return;
            }

            ShiftHandoverQuestionnaire handoverQuestionnaire = eventArgs.SelectedItem;
            UserContext userContext = ClientSession.GetUserContext();
            if (handoverQuestionnaire.IsAPriority(userContext.User, userContext.Assignment, userContext.UserShift, Clock.Now))
            {
                ShiftHandoverQuestionnaireDTO dto = new ShiftHandoverQuestionnaireDTO(handoverQuestionnaire);
                page.Invoke(new ShiftHandoverQuestionnaireAction(page.UpdateShiftHandoverQuestionnaire), new object[] { dto });
            }
        }

        private void Repeater_ServerActionItemCreated(object sender, DomainEventArgs<ActionItem> eventArgs)
        {
            if (page.IsDisposed)
            {
                return;
            }

            ActionItem ai = eventArgs.SelectedItem;
            UserContext userContext = ClientSession.GetUserContext();
            if(ai.Status.Id == ActionItemStatus.Current.Id && 
               (!userContext.SiteConfiguration.ShowActionItemsByWorkAssignmentOnPriorityPage || 
                ClientSession.GetUserContext().HasSameAssignment(ai.Assignment)))
            {
                var dto = new ActionItemDTO(ai);
                page.Invoke(new ActionItemAction(page.AddActionItem), new object[] { dto });
            }
        }

        

        private void Repeater_ServerActionItemUpdated(object sender, DomainEventArgs<ActionItem> eventArgs)
        {
            if (page.IsDisposed)
            {
                return;
            }

            ActionItem ai = eventArgs.SelectedItem;
            
            var displayStatuses = ActionItemStatus.AllForPriorityDisplay;
            var dto = new ActionItemDTO(ai);

            page.Invoke(ai.Status.IsOneOf(displayStatuses)
                    ? new ActionItemAction(page.UpdateActionItem)
                    : new ActionItemAction(page.RemoveActionItem), new object[] {dto});
            AuthorizeActionItemContextMenu();
        }

        private void Repeater_ServerActionItemRemoved(object sender, DomainEventArgs<ActionItem> eventArgs)
        {
            if (page.IsDisposed)
            {
                return;
            }

            ActionItemDTO dto = new ActionItemDTO(eventArgs.SelectedItem);
            page.Invoke(new ActionItemAction(page.RemoveActionItem), new object[] { dto });
        }

        private void Repeater_ServerActionItemRefresh(object sender, DomainEventArgs<Site> e)
        {
            UIRefreshActionItemList();
        }

        private void UIRefreshActionItemList()
        {
            if (page.IsDisposed)
            {
                return;
            }

            if (page.InvokeRequired)
            {
                page.BeginInvoke(new MethodInvoker(UIRefreshActionItemList));
            }
            else
            {
                CheckSecurityAndLoadActionItemData();
            }
        }

        private void Repeater_ServerTargetAlertCreated(object sender, DomainEventArgs<TargetAlert> eventArgs)
        {
            if (page.IsDisposed || !AuthorizedToViewTarget())
            {
                return;
            }

            TargetAlert ta = eventArgs.SelectedItem;
            if(ta.Status.Id != TargetAlertStatus.Closed.Id)
            {
                var dto = new TargetAlertDTO(ta);
                if(page.InvokeRequired)
                {
                    page.Invoke(new TargetAlertAction(page.AddTargetAlert), new object[] {dto});
                }
                else
                {
                    page.AddTargetAlert(dto);
                }
            }
          }

        private void Repeater_ServerTargetAlertUpdated(object sender, DomainEventArgs<TargetAlert> eventArgs)
        {
            if (page.IsDisposed || !AuthorizedToViewTarget())
            {
                return;
            }

            TargetAlert ta = eventArgs.SelectedItem;

            var dto = new TargetAlertDTO(ta);

            page.Invoke(
                TargetAlertStatus.AllForPriorityDisplay.Contains(dto.Status)
                    ? new TargetAlertAction(page.UpdateTargetAlert)
                    : new TargetAlertAction(page.RemoveTargetAlert), new object[] {dto});

            AuthorizeTargetAlertContextMenu();
        }

        private void Repeater_ServerDeviationAlertCreated(object sender, DomainEventArgs<DeviationAlert> eventArgs)
        {
            if (page.IsDisposed)
            {
                return;
            }

            DeviationAlert alert = eventArgs.SelectedItem;
            DeviationAlertDTO dto = new DeviationAlertDTO(alert);
            if (page.InvokeRequired)
            {
                page.Invoke(new DeviationAlertAction(page.AddDeviationAlert), new object[] { dto });
            }
            else
            {
                page.AddDeviationAlert(dto);
            }
        }

        private void Repeater_ServerDeviationAlertUpdated(object sender, DomainEventArgs<DeviationAlert> eventArgs)
        {
            if (page.IsDisposed)
            {
                return;
            }

            DeviationAlert alert = eventArgs.SelectedItem;

            DeviationAlertDTO dto = new DeviationAlertDTO(alert);
            page.Invoke(new DeviationAlertAction(page.UpdateDeviationAlert), new object[] { dto });

            AuthorizeDeviationAlertContextMenu();
        }

        private void Repeater_ServerLabAlertCreated(object sender, DomainEventArgs<LabAlert> eventArgs)
        {
            if (page.IsDisposed)
            {
                return;
            }

            LabAlert alert = eventArgs.SelectedItem;
            if (LabAlertPagePresenter.ShouldShowOnPrioritiesPage(alert))
            {
                LabAlertDTO dto = new LabAlertDTO(alert);
                if (page.InvokeRequired)
                {
                    page.Invoke(new Action<LabAlertDTO>(page.AddLabAlert), new object[] {dto});
                }
                else
                {
                    page.AddLabAlert(dto);
                }
            }
        }

        private void Repeater_ServerLabAlertUpdated(object sender, DomainEventArgs<LabAlert> eventArgs)
        {
            if (page.IsDisposed)
            {
                return;
            }

            LabAlert alert = eventArgs.SelectedItem;

            LabAlertDTO dto = new LabAlertDTO(alert);
            if (LabAlertPagePresenter.ShouldShowOnPrioritiesPage(alert))
            {
                if (LabAlertStatus.AllForPriorityDisplay.ExistsById(alert.Status))
                {
                    if (page.InvokeRequired)
                    {
                        page.Invoke(new Action<LabAlertDTO>(page.UpdateLabAlert), new object[] {dto});
                    }
                    else
                    {
                        page.UpdateLabAlert(dto);
                    }
                }
                else
                {
                    if (page.InvokeRequired)
                    {
                        page.Invoke(new Action<LabAlertDTO>(page.RemoveLabAlert), new object[] {dto});
                    }
                    else
                    {
                        page.RemoveLabAlert(dto);
                    }
                }
            }

            AuthorizeLabAlertContextMenu();
        }

        private void Repeater_ServerWorkPermitCreated(object sender, DomainEventArgs<WorkPermit> eventArgs)
        {
            if (page.IsDisposed)
            {
                return;
            }

            WorkPermit workPermit = eventArgs.SelectedItem;
            if(IsValidForDisplayOnPrioritiesPage(workPermit))
            {
                var dto = new WorkPermitDTO(workPermit);
                page.Invoke(new WorkPermitAction(page.AddWorkPermit), new object[] {dto});
            }
        }

        private void Repeater_ServerWorkPermitUpdated(object sender, DomainEventArgs<WorkPermit> eventArgs)
        {
            if (page.IsDisposed)
            {
                return;
            }

            WorkPermit wp = eventArgs.SelectedItem;
            if(IsValidForDisplayOnPrioritiesPage(wp))
            {
                if(page.ContainsWorkPermit(wp))
                {
                    var dto = new WorkPermitDTO(wp);
                    page.Invoke(new WorkPermitAction(page.UpdateWorkPermit), new object[] {dto});
                }
                else
                {
                    // If a previously rejected permit is now approved, we need to add it:
                    Repeater_ServerWorkPermitCreated(sender, eventArgs);
                }
                AuthorizeWorkPermitContextMenu();
            }
            else
            {
                Repeater_ServerWorkPermitRemoved(sender, eventArgs);
            }
        }

        private static bool IsValidForDisplayOnPrioritiesPage(WorkPermit workPermit)
        {
            return workPermit.IsNot(WorkPermitStatus.Complete) &&
                   workPermit.IsNot(WorkPermitStatus.Rejected) &&
                   workPermit.IsNot(WorkPermitStatus.Archived) &&
                   workPermit.IsEffectiveInUserShift(ClientSession.GetUserContext().UserShift);
        }

        private void Repeater_ServerWorkPermitRemoved(object sender, DomainEventArgs<WorkPermit> eventArgs)
        {
            if (page.IsDisposed)
            {
                return;
            }

            var dto = new WorkPermitDTO(eventArgs.SelectedItem);
            page.Invoke(new WorkPermitAction(page.RemoveWorkPermit), new object[] { dto });
            AuthorizeWorkPermitContextMenu();
        }

        public void CheckSecurityAndLoadData()
        {
            CheckSecurityAndLoadActionItemData();
            CheckSecurityAndLoadTargetAlertData();
            CheckSecurityAndLoadDeviationAlertData();
            CheckSecurityAndLoadLabAlertData();
            CheckSecurityAndLoadWorkPermit();
            CheckSecurityAndLoadShiftHandoverQuestionnaireData();
        }

        private void CheckSecurityAndLoadShiftHandoverQuestionnaireData()
        {
            UserContext userContext = ClientSession.GetUserContext();
            UserRoleElements user = userContext.UserRoleElements;
            if (authorized.ToViewShiftHandoverOnPrioritiesPage(user))
            {
                List<ShiftHandoverQuestionnaireDTO> shiftHandoverQuestionnaireList =
                    shiftHandoverService.QueryPriorityDTOs(userContext.RootFlocSet, userContext.WorkAssignmentId, userContext.User.Id, userContext.UserShift, userContext.ReadableVisibilityGroupIds);
                page.ShiftHandoverQuestionnaireList = shiftHandoverQuestionnaireList;
            }
            else
            {
                page.DisableShiftHandoverQuestionnaireListView();
            }
        }

        private void CheckSecurityAndLoadActionItemData()
        {            
            UserContext userContext = ClientSession.GetUserContext();
            UserRoleElements roleElements = userContext.UserRoleElements;
            if(authorized.ToViewActionItemsOnPrioritiesPage(roleElements))
            {
                List<ActionItemDTO> actionItemList;

                if (userContext.SiteConfiguration.ShowActionItemsByWorkAssignmentOnPriorityPage)
                {
                    actionItemList =
                            actionItemService.QueryDTOByFunctionalLocationsAndWorkAssignmentForCurrentShiftOrIfResponseRequiredWithDisplayLimits
                                (userContext.RootFlocSet, userContext.UserShift.ShiftPattern,
                                        userContext.Assignment, userContext.ReadableVisibilityGroupIds);
                }
                else
                {
                    actionItemList =
                            actionItemService.QueryDTOByFunctionalLocationsForCurrentShiftOrIfResponseRequiredWithDisplayLimits
                                (userContext.RootFlocSet, userContext.UserShift.ShiftPattern, userContext.ReadableVisibilityGroupIds);
                     
                }
                               
                page.ActionItemList = actionItemList;
                AuthorizeActionItemContextMenu();    
            }
            else
            {
                page.DisableActionItemContextMenu();
                page.DisableActionItemListView();
            }
        }

        private void CheckSecurityAndLoadTargetAlertData()
        {
            if (AuthorizedToViewTarget())
            {
                UserContext userContext = ClientSession.GetUserContext();
                page.TargetList =
                        targetAlertService.QueryByFunctionalLocationsAndStatuses(userContext.RootFlocSet,
                                                                                 TargetAlertStatus.AllForPriorityDisplay);
                AuthorizeTargetAlertContextMenu();
            }
            else
            {
                page.DisableTargetContextMenu();
                page.DisableTargetListView();
            }
        }

        private bool AuthorizedToViewTarget()
        {
            UserContext userContext = ClientSession.GetUserContext();
            UserRoleElements userRoleElements = userContext.UserRoleElements;
            return authorized.ToViewTargetsOnPrioritiesPage(userRoleElements);
        }

        private void CheckSecurityAndLoadDeviationAlertData()
        {
            UserContext userContext = ClientSession.GetUserContext();
            UserRoleElements userRoleElements = userContext.UserRoleElements;
            if (authorized.ToViewRestrictionReporting(userRoleElements))
            {
                page.DeviationAlertList = deviationAlertService.QueryDTOsByFLOCAndShift(
                    userContext.RootFlocSet, userContext.UserShift);
                AuthorizeDeviationAlertContextMenu();
            }
            else
            {
                page.DisableDeviationAlertContextMenu();
                page.DisableDeviationAlertListView();
            }
        }

        private void CheckSecurityAndLoadLabAlertData()
        {
            UserContext userContext = ClientSession.GetUserContext();
            UserRoleElements userRoleElements = userContext.UserRoleElements;
            if (authorized.ToViewLabAlertDefinitionsAndLabAlerts(userRoleElements))
            {
                DateTime lowerBound = DateTime.Now.AddDays(userContext.SiteConfiguration.DaysToDisplayLabAlerts * -1).GetNetworkPortable();
                Range<Date> range = new Range<Date>(new Date(lowerBound), new Date(DateTime.Now.GetNetworkPortable()));
                page.LabAlertList = labAlertService.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(
                    userContext.RootFlocSet, range, new List<LabAlertStatus>(LabAlertStatus.AllForPriorityDisplay));
                AuthorizeLabAlertContextMenu();
            }
            else
            {
                page.DisableLabAlertContextMenu();
                page.DisableLabAlertListView();
            }
        }

        private void CheckSecurityAndLoadWorkPermit()
        {
            UserContext userContext = ClientSession.GetUserContext();
            UserRoleElements userRoleElements = userContext.UserRoleElements;
            if (authorized.ToViewWorkPermitsOnThePrioritiesPage(userRoleElements))
            {
                page.WorkPermitList = workPermitService.QueryOldPriorityPageWorkPermits(userContext.RootFlocSet, userContext.UserShift.ShiftPattern);
                AuthorizeWorkPermitContextMenu();
            }
            else
            {
                page.DisablePermitContextMenu();
                page.DisablePermitListView();
            }
        }

        public void ActionItemListView_DoubleClickSelected(object sender, DomainEventArgs<ActionItemDTO> e)
        {
            page.MainParentForm.SelectSectionAndItem(SectionKey.ActionItemSection, e.SelectedItem);
        }

        public void TargetListView_DoubleClickSelected(object sender, DomainEventArgs<TargetAlertDTO> e)
        {
            page.MainParentForm.SelectSectionAndItem(SectionKey.TargetSection, e.SelectedItem);
        }

        public void WorkPermitListView_DoubleClickSelected(object sender, DomainEventArgs<WorkPermitDTO> e)
        {
            page.MainParentForm.SelectSectionAndItem(SectionKey.WorkPermitSection, e.SelectedItem);
        }

        public void ShiftHandoverQuestionnaireGridView_DoubleClickSelected(object sender, DomainEventArgs<ShiftHandoverQuestionnaireDTO> e)
        {
            page.MainParentForm.SelectSectionAndItem(SectionKey.ShiftHandoverSection, e.SelectedItem);
        }        

        public void ActionItemGridView_SelectedItemChanged(object sender, DomainEventArgs<ActionItemDTO> e)
        {
            AuthorizeActionItemContextMenu();
        }

        public void TargetAlertGridView_SelectedItemChanged(object sender, DomainEventArgs<TargetAlertDTO> e)
        {
            AuthorizeTargetAlertContextMenu();
        }

        public void WorkPermitGridView_SelectedItemChanged(object sender, DomainEventArgs<WorkPermitDTO> e)
        {
            AuthorizeWorkPermitContextMenu();
        }

        private void AuthorizeActionItemContextMenu()
        {
            List<ActionItemDTO> selectedItems = page.SelectedActionItemDTOs;
            bool hasItemSelected = selectedItems.Count > 0;

            //COMMENT: trg - if this changes .. it means that the ActionItemPagePresenter ControlDetailButtons needs to reflect change as well.
            IActionItemActions actions = page.ActionItemActions;
            actions.RespondEnabled = hasItemSelected && authorized.ToRespondActionItem(ClientSession.GetUserContext().UserRoleElements, selectedItems[0]);
        }
        
        private void AuthorizeTargetAlertContextMenu()
        {
            UserRoleElements userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            List<TargetAlertDTO> selectedItems = page.SelectedTargetAlertDTOs;
            bool hasItemsSelected = selectedItems.Count > 0;
            bool hasSingleItemSelected = selectedItems.Count == 1;
            
            //COMMENT: trg - if this changes .. it means that the TargetAlertPagePresenter ControlDetailButtons needs to reflect change as well.
            ITargetAlertActions actions = page.TargetAlertActions;
            actions.RespondEnabled = hasSingleItemSelected && authorized.ToRespondToTargetAlerts(userRoleElements);
            actions.AcknowledgeEnabled = hasItemsSelected && authorized.ToAcknowledgeTargetAlerts(userRoleElements, selectedItems);
        }

        private void AuthorizeWorkPermitContextMenu()
        {
            UserContext userContext = ClientSession.GetUserContext();

            UserRoleElements userRoleElements = userContext.UserRoleElements;
            UserShift userShift = userContext.UserShift;
            
            List<WorkPermit> selectedItems = ConvertAllTo(page.SelectedWorkPermitDTOs);
            bool hasSelectedItems = selectedItems.Count != 0;
            bool hasSingleItemSelected = selectedItems.Count == 1;

            //COMMENT: trg - if this changes .. it means that the WorkPermitPagePresenter ControlDetailButtons needs to reflect change as well.
            IWorkPermitActions actions = page.WorkPermitActions;
            List<GasTestElementInfo> standardGasTestElementInfoList = gasTestElementInfoService.QueryStandardElementInfosBySiteId(userContext.Site.IdValue);

            var validator = new WorkPermitApprovableValidator(selectedItems, authorized, standardGasTestElementInfoList);
            actions.ApproveEnabled = hasSelectedItems
                                     && authorized.ToApproveWorkPermits(userRoleElements, userShift, selectedItems)
                                     && validator.PermitsAreValidEnoughToBeApproved();

            actions.RejectEnabled = hasSelectedItems && authorized.ToRejectWorkPermits(userRoleElements, selectedItems);
            bool closeEnabled = authorized.ToCloseWorkPermits(userRoleElements, selectedItems);
            actions.CloseEnabled = hasSelectedItems && closeEnabled;
            actions.CommentEnabled = hasSingleItemSelected && authorized.ToCommentWorkPermit(userRoleElements);

            actions.DeleteEnabled = hasSelectedItems && authorized.ToDeleteWorkPermits(userRoleElements, selectedItems);
            actions.EditEnabled = hasSingleItemSelected && authorized.ToEditWorkPermit(userRoleElements, selectedItems[0]);
            actions.CopyEnabled = hasSingleItemSelected && (authorized.ToCopyWorkPermitWithNoRestriction(userRoleElements) || authorized.ToCopyWorkPermitWithSomeRestrictions(userRoleElements));
            actions.CloneEnabled = hasSingleItemSelected && (authorized.ToCloneWorkPermitWithNoRestriction(userRoleElements) || authorized.ToCloneWorkPermitWithSomeRestrictions(userRoleElements));
            bool printAuthorization = hasSelectedItems && authorized.ToPrintWorkPermits(userRoleElements, userShift, selectedItems);
            actions.PrintEnabled = printAuthorization;
            actions.PrintPreviewEnabled = hasSingleItemSelected && authorized.ToPrintPreviewWorkPermit(userRoleElements, userShift, selectedItems[0]);
        }

        protected List<WorkPermit> ConvertAllTo(List<WorkPermitDTO> dtos)
        {
            return dtos.ConvertAll(dto => workPermitService.QueryById(dto.IdValue));
        }

        public void ActionItemContextMenuStrip_Respond(object sender, EventArgs e)
        {
            CreateActionItemPagePresenter().RespondButton_Clicked();
        }

        private ActionItemPagePresenter CreateActionItemPagePresenter()
        {
            return new ActionItemPagePresenter(new PriorityPageActionItemContextMenuPage(page.SelectedActionItemDTOs));
        }
        
        public void TargetContextMenuStrip_Acknowledge(object sender, EventArgs e)
        {
            CreateTargetAlertPresenter().Acknowledge();
        }

        public void TargetContextMenuStrip_Respond(object sender, EventArgs e)
        {
            CreateTargetAlertPresenter().RespondButton_Clicked();
        }

        private TargetAlertPagePresenter CreateTargetAlertPresenter()
        {
            return new TargetAlertPagePresenter(new PriorityPageTargetAlertContextMenuPage(page.SelectedTargetAlertDTOs));
        }

        public void PermitContextMenuStrip_Approve(object sender, EventArgs e)
        {
            CreateWorkPermitPagePresenter().ApproveButton_Clicked();
        }

        public void PermitContextMenuStrip_Reject(object sender, EventArgs e)
        {
            CreateWorkPermitPagePresenter().RejectButton_Clicked();
        }

        public void PermitContextMenuStrip_CloseWorkPermit(object sender, EventArgs e)
        {
            CreateWorkPermitPagePresenter().CloseWorkPermit( sender, e);
        }
        public void PermitContextMenuStrip_Comment(object sender, EventArgs e)
        {
            CreateWorkPermitPagePresenter().CommentButton_Clicked();
        }

        public void PermitContextMenuStrip_Delete(object sender, EventArgs e)
        {
            CreateWorkPermitPagePresenter().DeleteButton_Clicked();
        }

        public void PermitContextMenuStrip_Edit(object sender, EventArgs e)
        {
            CreateWorkPermitPagePresenter().EditButton_Clicked();
        }

        public void PermitContextMenuStrip_Copy(object sender, EventArgs e)
        {
            CreateWorkPermitPagePresenter().Copy(sender, e);
        }

        public void PermitContextMenuStrip_Print(object sender, EventArgs e)
        {
            CreateWorkPermitPagePresenter().Print(sender, e);
        }

        public void PermitContextMenuStrip_PrintPreview(object sender, EventArgs e)
        {
            CreateWorkPermitPagePresenter().PrintPreview(sender, e);
        }

        public void PermitContextMenuStrip_Clone(object sender, EventArgs e)
        {
            CreateWorkPermitPagePresenter().Clone(sender, e);
        }
        
        private WorkPermitPagePresenter CreateWorkPermitPagePresenter()
        {
            return new WorkPermitPagePresenter(new PriorityPageWorkPermitContextMenuPage(page.SelectedWorkPermitDTOs));
        }

        public void DeviationAlertContextMenuStrip_Respond(object sender, EventArgs e)
        {
            DeviationAlertPagePresenter presenter = new DeviationAlertPagePresenter(new PriorityPageDeviationAlertContextMenuPage(page.SelectedDeviationAlertDTOs));
            presenter.RespondButton_Clicked();
        }

        public void DeviationAlertGridView_SelectedItemChanged(object sender, DomainEventArgs<DeviationAlertDTO> e)
        {
            AuthorizeDeviationAlertContextMenu();
        }

        private void AuthorizeDeviationAlertContextMenu()
        {
            UserContext userContext = ClientSession.GetUserContext();
            UserRoleElements roleElements = userContext.UserRoleElements;
            List<DeviationAlertDTO> selectedItems = page.SelectedDeviationAlertDTOs;
            bool hasSingleItemSelected = selectedItems.Count == 1;

            //COMMENT: trg - if this changes .. it means that the TargetAlertPagePresenter ControlDetailButtons needs to reflect change as well.
            IDeviationAlertActions actions = page.DeviationAlertActions;
            actions.RespondEnabled = hasSingleItemSelected &&
                (authorized.ToEditDeviationAlertComments(roleElements) ||
                authorized.ToRespondToDeviationAlerts(roleElements, userContext.UserShift, selectedItems[0])) && 
                deviationAlertService.IsWithinDaysToEditResponse(userContext.Site, selectedItems);
        }

        public void DeviationAlertGridView_DoubleClickSelected(object sender, DomainEventArgs<DeviationAlertDTO> e)
        {
            page.MainParentForm.SelectSectionAndItem(SectionKey.RestrictionSection, e.SelectedItem);
        }

        public void LabAlertContextMenuStrip_Respond(object sender, EventArgs e)
        {
            LabAlertPagePresenter presenter = new LabAlertPagePresenter(new PriorityPageLabAlertContextMenuPage(page.SelectedLabAlertDTOs));
            presenter.RespondButton_Clicked();
        }

        public void LabAlertGridView_SelectedItemChanged(object sender, DomainEventArgs<LabAlertDTO> e)
        {
            AuthorizeLabAlertContextMenu();
        }

        private void AuthorizeLabAlertContextMenu()
        {
            UserContext userContext = ClientSession.GetUserContext();
            UserRoleElements roleElements = userContext.UserRoleElements;
            List<LabAlertDTO> selectedItems = page.SelectedLabAlertDTOs;
            bool hasSingleItemSelected = selectedItems.Count == 1;

            //COMMENT: trg - if this changes .. it means that the LabAlertPagePresenter ControlDetailButtons needs to reflect change as well.
            ILabAlertActions actions = page.LabAlertActions;
            actions.RespondEnabled = hasSingleItemSelected &&
                authorized.ToRespondToLabAlerts(roleElements);
        }

        public void LabAlertGridView_DoubleClickSelected(object sender, DomainEventArgs<LabAlertDTO> e)
        {
            page.MainParentForm.SelectSectionAndItem(SectionKey.LabAlertSection, e.SelectedItem);
        }
    }
}
