using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class ActionItemDefinitionPagePresenter
        :
            AbstractApprovableDomainPagePresenter
                <ActionItemDefinitionDTO, ActionItemDefinition, IActionItemDefinitionDetails, IActionItemDefinitionPage>
    {
        private ActionItemDefinition definition_img;
        //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

        private readonly IActionItemDefinitionService actionItemDefinitionService;
        private readonly ILogService logService;
        private readonly IActionItemService actionItemService;
        private readonly IFormEdmontonService formService;
        private readonly IReportPrintManager<FormGN75B> reportPrintManager;

        //ayman action item definition
        private Range<Date> newrange;

        public ActionItemDefinition definition; // Added By Vibhor : RITM0574870 - OLT - Clone feature created for AI definitions

        

        public ActionItemDefinitionPagePresenter() : base(
            new ActionItemDefinitionPage(),
            new Authorized(),
            ClientServiceRegistry.Instance.RemoteEventRepeater,
            ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
            ClientServiceRegistry.Instance.GetService<ITimeService>(),
            ClientServiceRegistry.Instance.GetService<IUserService>())
        {
            actionItemDefinitionService = ClientServiceRegistry.Instance.GetService<IActionItemDefinitionService>();
            logService = ClientServiceRegistry.Instance.GetService<ILogService>();
            actionItemService = ClientServiceRegistry.Instance.GetService<IActionItemService>();
            formService = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();
            newrange = new Range<Date>(null, null); //ayman action item definition
            PrintActions<FormGN75B, FormGN75BReport, FormGN75BReportAdapter> printActions =
                new EdmontonGN75BFormPrintActions(formService);
            reportPrintManager = new ReportPrintManager<FormGN75B, FormGN75BReport, FormGN75BReportAdapter>(printActions);

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            page.Details.ViewAssociatedLogs += ViewAssociatedLogs;
            if (userContext.IsEdmontonSite)
            {
                page.Details.ViewAssociatedGN75B += ViewAssociatedGn75B;

                //mangesh - DMND0005327 - Request 15
                page.Details.ViewAssociatedGN75B1 += ViewAssociatedGn75B1;
                page.Details.ViewAssociatedGN75B2 += ViewAssociatedGn75B2;
            }

            page.Details.Clone += Clone; // Added By Vibhor : RITM0574870 - OLT - Clone feature created for AI definitions

        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            page.Details.ViewAssociatedLogs -= ViewAssociatedLogs;
            if (userContext.IsEdmontonSite)
            {
                page.Details.ViewAssociatedGN75B -= ViewAssociatedGn75B;

                //mangesh - DMND0005327 - Request 15
                page.Details.ViewAssociatedGN75B1 -= ViewAssociatedGn75B1;
                page.Details.ViewAssociatedGN75B2 -= ViewAssociatedGn75B2;
            }

            page.Details.Clone -= Clone; // Added By Vibhor : RITM0574870 - OLT - Clone feature created for AI definitions

        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(ActionItemDefinition item)
        {
            return new EditActionItemDefinitionHistoryFormPresenter(item);
        }

        protected override IForm CreateEditForm(ActionItemDefinition item)
        {
            return new ActionItemDefinitionForm(item);
        }

        protected override void ControlDetailButtons()
        {
            UserRoleElements userRoleElements = userContext.UserRoleElements;

            IActionItemDefinitionDetails details = page.Details;

            List<ActionItemDefinitionDTO> selectedItemDtos = page.SelectedItems;
            bool hasItemsSelected = selectedItemDtos.Count > 0;
            bool hasSingleItemSelected = selectedItemDtos.Count == 1;

            ActionItemDefinitionDTO firstSelectedItem = page.FirstSelectedItem;

            details.ApproveEnabled = hasItemsSelected &&
                                     authorized.ToApproveActionItemDefinitions(userRoleElements, selectedItemDtos);
            details.RejectEnabled = hasItemsSelected &&
                                    authorized.ToRejectActionItemDefinitions(userRoleElements, selectedItemDtos);
            details.DeleteEnabled = hasItemsSelected &&
                                    authorized.ToDeleteActionItemDefinitions(userRoleElements, selectedItemDtos);
            details.EditEnabled = hasSingleItemSelected &&
                                  authorized.ToEditActionItemDefinition(userRoleElements, firstSelectedItem);
            details.CommentEnabled = hasSingleItemSelected &&
                                     authorized.ToCommentActionItemDefinition(userRoleElements, firstSelectedItem);
            details.ViewEditHistoryEnabled = hasSingleItemSelected;

            details.CloneEnabled = hasSingleItemSelected && authorized.ToCloneActionItem(userRoleElements); // Added By Vibhor : RITM0574870 - OLT - Clone feature created for AI definitions

            EnableViewAssociatedLogsButtonIfNecessary();
        }

        protected override void Delete(ActionItemDefinition actionItemDefinition)
        {
            actionItemDefinition.LastModifiedBy = ClientSession.GetUserContext().User;
            actionItemDefinition.LastModifiedDate = Clock.Now;
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(actionItemDefinitionService.Remove,
                actionItemDefinition);
        }

        protected override void Approve(ActionItemDefinition actionItemDefinition)
        {
            Debug.Assert(actionItemDefinition.Is(ActionItemDefinitionStatus.Pending));
            Debug.Assert(actionItemDefinition.RequiresApproval);
            Debug.Assert(actionItemDefinition.Active == false);

            actionItemDefinition.Approve(ClientSession.GetUserContext().User, Clock.Now);

            bool shouldClearCurrentActionItems = false;
            if (actionItemService.CurrentActionItemsExistForActionItemDefinition(actionItemDefinition, Clock.Now))
            {
                shouldClearCurrentActionItems = page.ShouldClearCurrentActionItemsForDefinitionUpdate;
            }

            if (shouldClearCurrentActionItems)
            {
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                    actionItemDefinitionService.UpdateAndClearCurrentActionItems, actionItemDefinition);
            }
            else
            {
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                    actionItemDefinitionService.Update, actionItemDefinition);
            }
        }


        protected override void Comment(ActionItemDefinition actionItemDefinition)
        {
            var commentsView = new CommentsForm();
            new ActionItemDefinitionCommentsFormPresenter(commentsView, actionItemDefinition);
            commentsView.ShowDialog(page.ParentForm);
        }

        protected override void Reject(ActionItemDefinition actionItemDefinition)
        {
            Debug.Assert(actionItemDefinition.Is(ActionItemDefinitionStatus.Pending));
            Debug.Assert(actionItemDefinition.Active == false);
            Debug.Assert(actionItemDefinition.RequiresApproval);

            actionItemDefinition.Reject(ClientSession.GetUserContext().User, Clock.Now);
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(actionItemDefinitionService.Update,
                actionItemDefinition);
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerActionItemDefinitionCreated += repeater_Created;
            remoteEventRepeater.ServerActionItemDefinitionUpdated += repeater_Updated;
            remoteEventRepeater.ServerActionItemDefinitionRemoved += repeater_Removed;
            remoteEventRepeater.ServerLogRemoved += repeater_Log_Removed;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerActionItemDefinitionCreated -= repeater_Created;
            remoteEventRepeater.ServerActionItemDefinitionUpdated -= repeater_Updated;
            remoteEventRepeater.ServerActionItemDefinitionRemoved -= repeater_Removed;
            remoteEventRepeater.ServerLogRemoved -= repeater_Log_Removed;
        }

        private void repeater_Log_Removed(object sender, DomainEventArgs<Log> e)
        {
            RefreshDetailButtonsIfLogMightBeAssociatedUsingUIThread(e.SelectedItem);
        }

        private void RefreshDetailButtonsIfLogMightBeAssociatedUsingUIThread(Log potentiallyReferencedLog)
        {
            if (!page.IsDisposed)
            {
                page.Invoke(
                    new Action<Log>(RefreshDetailButtonsIfLogMightBeAssociated),
                    potentiallyReferencedLog);
            }
        }

        private void RefreshDetailButtonsIfLogMightBeAssociated(Log potentiallyReferencedLog)
        {
            if (potentiallyReferencedLog.LogType == LogType.Standard)
            {
                EnableViewAssociatedLogsButtonIfNecessary();
            }
        }

        private void EnableViewAssociatedLogsButtonIfNecessary()
        {
            bool hasSingleItemSelected = page.SelectedItems.Count == 1;
            page.Details.ViewAssociatedLogsEnabled = hasSingleItemSelected &&
                                                     (logService.CountOfLogsAssociatedToActionItemDefinition(
                                                         page.FirstSelectedItem.IdValue) > 0);
        }

        protected override void SetDetailData(IActionItemDefinitionDetails details, ActionItemDefinition definition)
        {
            this.definition_img = definition;
            //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
            details.EditedBy = definition.LastModifiedBy.FullNameWithUserName;
            details.Description = definition.Description;
            details.Schedule = definition.Schedule;
            details.ActionItemDefinitionName = definition.Name;
            details.ActionCategory = definition.Category != null ? definition.Category.Name : null;
            details.WorkAssignment = definition.Assignment != null ? definition.Assignment.DisplayName : null;
            details.Priority = definition.Priority.Name;
            details.Comments = definition.Comments;
            details.FunctionalLocations = definition.FunctionalLocations;
            details.RequiresApproval = definition.RequiresApproval;
            details.Active = definition.Active;
            details.CopyResponseToLog = definition.CopyResponseToLog;
            //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
            details.ResponseRequired = definition.ResponseRequired;
            details.TargetDefinitionDTOs = definition.TargetDefinitionDTOs;
            details.OperationalMode = definition.OperationalMode.Name;
            details.DocumentLinks = definition.DocumentLinks;
            details.CreateAnActionItemForEachFunctionalLocation = definition.CreateAnActionItemForEachFunctionalLocation;
            details.EveryShift = definition.EveryShift; //RITM0265710 mangesh    ayman commented to fix the code relap

            if (userContext.IsEdmontonSite)
            {
                details.AssociatedGn75BFormNumber = definition.AssociatedFormGN75BId.HasValue
                    ? definition.AssociatedFormGN75BId.Value
                    : (long?) null;

                //mangesh - DMND0005327 - Request 15
                details.AssociatedGn75BFormNumber1 = definition.AssociatedFormGN75BId1.HasValue
                    ? definition.AssociatedFormGN75BId1.Value
                    : (long?) null;
                details.AssociatedGn75BFormNumber2 = definition.AssociatedFormGN75BId2.HasValue
                    ? definition.AssociatedFormGN75BId2.Value
                    : (long?) null;
            }
            else
            {
                details.HideGn75BAssocation();
            }
//RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives


            //if (definition.Imagelist_detail != null && definition.Imagelist_detail.Count > 0)
            if (definition.Imagelist != null && definition.Imagelist.Count > 0)
            {
                details.actionItemImage = definition.Imagelist;
                //details.actionItemImage = definition.Imagelist_detail;
                details.DefinitionDetailImage = definition_img;
                //definition.Imagelist = null;
                details.ImageGridVisible = true;
                details.ImageGridLabelVisible = true;
            }
            else
            {
                details.actionItemImage = null;
                details.ImageGridVisible = false;
                details.ImageGridLabelVisible = false;

            }

        }

        protected override ActionItemDefinitionDTO CreateDTOFromDomainObject(ActionItemDefinition actionItemDefinition)
        {
            return new ActionItemDefinitionDTO(actionItemDefinition);
        }

        protected override ActionItemDefinition QueryByDto(ActionItemDefinitionDTO dto)
        {
            ActionItemDefinition aid = actionItemDefinitionService.QueryById(dto.IdValue);

            definition = aid; // Added By Vibhor : RITM0574870 - OLT - Clone feature created for AI definitions

            var autopopulateResult =
                actionItemDefinitionService.QueryActionItemDefAutoPopulateByActionItemDefinitionId(dto.IdValue);
            //ayman action item reading
            var readingResult =
                actionItemDefinitionService.QueryActionItemDefReadingByActionItemDefinitionId(dto.IdValue);
            //ayman action item reading
            if (autopopulateResult != null)
                aid.AutoPopulate = (bool) autopopulateResult;
            if (readingResult != null)
                aid.Reading = (bool) readingResult;
            return aid;
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_ActionItemDefinition; }
        }

        private void ViewAssociatedGn75B()
        {
            long? formGn75BId = page.Details.AssociatedGn75BFormNumber;
            if (!formGn75BId.HasValue)
                return;

            FormGN75B formGn75B = formService.QueryFormGN75BById(formGn75BId.Value);
            reportPrintManager.PreviewReport(formGn75B);
        }

        //mangesh- DMND0005327 Request 15
        private void ViewAssociatedGn75B1()
        {
            long? formGn75BId1 = page.Details.AssociatedGn75BFormNumber1;
            if (!formGn75BId1.HasValue)
                return;

            FormGN75B formGn75B1 = formService.QueryFormGN75BById(formGn75BId1.Value);
            reportPrintManager.PreviewReport(formGn75B1);
        }

        //mangesh- DMND0005327 Request 15
        private void ViewAssociatedGn75B2()
        {
            long? formGn75BId2 = page.Details.AssociatedGn75BFormNumber2;
            if (!formGn75BId2.HasValue)
                return;

            FormGN75B formGn75B2 = formService.QueryFormGN75BById(formGn75BId2.Value);
            reportPrintManager.PreviewReport(formGn75B2);
        }

        private void ViewAssociatedLogs(object sender, EventArgs e)
        {
            List<LogDTO> associatedLogDtos = logService.QueryDTOsByActionItemDefinition(page.FirstSelectedItem.IdValue);
            page.ShowAssociatedLogForm(associatedLogDtos);
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            return DateRangeUtilities.GetDefaultDateRangeForActionItemDefinitions(userContext.Site,
                userContext.SiteConfiguration, timeService);
        }


        //ayman action item definition
        //public List<long> GetActionItemDefinitionIDsRelatedtoActionItems(List<ActionItemDTO> AidIDs)
        //{
        //    var aidIds = AidIDs.ConvertAll(dd => dd.DefinitionId());
        //    aidIds = aidIds.Distinct().ToList();
        //    return aidIds;
        //}


        protected override IList<ActionItemDefinitionDTO> GetDtos(Range<Date> dateRange)
        {

            var noreadingdefdtos =
                actionItemDefinitionService.QueryDTOByFunctionalLocationsAndDateRange(userContext.Site,
                    userContext.RootFlocSet, dateRange, userContext.ReadableVisibilityGroupIds);
            List<ActionItemDefinitionDTO> RemovalList = new List<ActionItemDefinitionDTO>();
            foreach (var dto in noreadingdefdtos)
            {
                var isreading =
                    actionItemDefinitionService.QueryActionItemDefReadingByActionItemDefinitionId(dto.IdValue);
                if ((bool) isreading)
                {
                    RemovalList.Add(dto);
                }
            }
            foreach (ActionItemDefinitionDTO dt in RemovalList)
            {
                noreadingdefdtos.Remove(dt);
            }
            return noreadingdefdtos;

        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.ActionItemDefinitions; }
        }

		// Added By Vibhor : RITM0574870 - OLT - Clone feature created for AI definitions

        public void Clone(object sender, EventArgs args)
        {
            ActionItemDefinition def = definition;
            def.Isclone = true;

            def.CreatedBy = ClientSession.GetUserContext().User;
            def.CreatedDateTime = Clock.Now;
            def.Source.Id = 0;
            def.id = null;

            IForm newForm = CreateEditForm(def);
            newForm.ShowDialog(page.ParentForm);
        }

        
    }
}

