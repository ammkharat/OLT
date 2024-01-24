using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
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
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class ReadingPagePresenter : AbstractRespondableDomainPagePresenter<ActionItemDTO, ActionItem, IActionItemDetails, IActionItemPage>
    {
        protected readonly IActionItemService service;
        private readonly ILogService logService;
        private readonly IFormEdmontonService formService;
        private readonly IReportPrintManager<ActionItem> reportPrintManager;
        private readonly IReportPrintManager<FormGN75B> reportPrintManagerForGn75B;


        public ReadingPagePresenter()  : this(new ReadingPage())
        {
        }

        public ReadingPagePresenter(IActionItemPage page)  : this(
            page,
            ClientServiceRegistry.Instance.GetService<IActionItemService>(),
            new Authorized(),
            ClientServiceRegistry.Instance.RemoteEventRepeater,
            ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
            ClientServiceRegistry.Instance.GetService<ILogService>(),
            ClientServiceRegistry.Instance.GetService<ITimeService>(),
            ClientServiceRegistry.Instance.GetService<IUserService>(),   
            ClientServiceRegistry.Instance.GetService<IFormEdmontonService>())
        {
        }

        protected ReadingPagePresenter(
            IActionItemPage page, 
            IActionItemService service,
            IAuthorized authorized,
            IRemoteEventRepeater remoteEventRepeater,
            IObjectLockingService objectLockingService,
            ILogService logService,
            ITimeService timeService,
            IUserService userService,
            IFormEdmontonService formService)  
            : base(page, authorized, remoteEventRepeater, objectLockingService, timeService, userService)
        {
            this.service = service;
            this.logService = logService;
            this.formService = formService;

//            page.Details.GoToDefinitionVisible = authorized.ToViewReadingDefinitions(ClientSession.GetUserContext().UserRoleElements);

            SubscribeToEvents();

            reportPrintManager = new ReportPrintManager<ActionItem, ActionItemReport, ActionItemMainReportAdapter>(new ActionItemPrintActions());
          
            PrintActions<FormGN75B, FormGN75BReport, FormGN75BReportAdapter> printActions = new EdmontonGN75BFormPrintActions(formService);
            reportPrintManagerForGn75B = new ReportPrintManager<FormGN75B, FormGN75BReport, FormGN75BReportAdapter>(printActions);

        }

        private void SubscribeToEvents()
        {
            page.Details.CustomFieldEntryClicked += CustomFieldEntryClicked;
            page.Details.ViewAssociatedLogs += ViewAssociatedLogs;
            page.Details.PrintPreview += PrintPreview;
            page.Details.Print += Print;
            if (userContext.IsEdmontonSite)
            {
                page.Details.ViewAssociatedGN75B += ViewAssociatedGn75B;
                //mangesh- DMND0005327 Request 15
                page.Details.ViewAssociatedGN75B1 += ViewAssociatedGn75B1;
                page.Details.ViewAssociatedGN75B2 += ViewAssociatedGn75B2;
                page.Details.EditAssociatedGN75B += EditAssociatedGn75B;
                page.Details.EditAssociatedGN75B1 += EditAssociatedGn75B1;
                page.Details.EditAssociatedGN75B2 += EditAssociatedGn75B2;
            }

        }

        protected override void UnSubscribeFromEvents()
        {
            page.Details.CustomFieldEntryClicked -= CustomFieldEntryClicked;
            base.UnSubscribeFromEvents();
            page.Details.ViewAssociatedLogs -= ViewAssociatedLogs;
            page.Details.PrintPreview -= PrintPreview;
            page.Details.Print -= Print;

            if (userContext.IsEdmontonSite)
            {
                page.Details.ViewAssociatedGN75B -= ViewAssociatedGn75B;

                //mangesh- DMND0005327 Request 15
                page.Details.ViewAssociatedGN75B1 -= ViewAssociatedGn75B1;
                page.Details.ViewAssociatedGN75B2 -= ViewAssociatedGn75B2;
                page.Details.EditAssociatedGN75B -= EditAssociatedGn75B;
                page.Details.EditAssociatedGN75B1 -= EditAssociatedGn75B1;
                page.Details.EditAssociatedGN75B2 -= EditAssociatedGn75B2;
            }
        }

        //ayman custom fields DMND0010030
        private void CustomFieldEntryClicked(CustomFieldEntry customFieldEntry)
        {
            ActionItem actionItem = QueryForFirstSelectedItem();
            if (actionItem.Assignment != null)
            {
                IRunnablePresenter presenter = CustomFieldPresenterMaker.Create(logService, customFieldEntry, actionItem.Assignment);
                presenter.Run(page.MainParentForm);
            }
        }

        private void ViewAssociatedGn75B()
        {
            long? associatedGn75BFormNumber = page.Details.AssociatedGn75BFormNumber;
            if (!associatedGn75BFormNumber.HasValue)
                return;

            FormGN75B formGn75B = formService.QueryFormGN75BById(associatedGn75BFormNumber.Value);
            reportPrintManagerForGn75B.PreviewReport(formGn75B);
        }

        //mangesh- DMND0005327 Request 15
        private void ViewAssociatedGn75B1()
        {
            long? associatedGn75BFormNumber1 = page.Details.AssociatedGn75BFormNumber1;
            if (!associatedGn75BFormNumber1.HasValue)
                return;

            FormGN75B formGn75B1 = formService.QueryFormGN75BById(associatedGn75BFormNumber1.Value);
            reportPrintManagerForGn75B.PreviewReport(formGn75B1);
        }
        //mangesh- DMND0005327 Request 15
        private void ViewAssociatedGn75B2()
        {
            long? associatedGn75BFormNumber2 = page.Details.AssociatedGn75BFormNumber2;
            if (!associatedGn75BFormNumber2.HasValue)
                return;

            FormGN75B formGn75B2 = formService.QueryFormGN75BById(associatedGn75BFormNumber2.Value);
            reportPrintManagerForGn75B.PreviewReport(formGn75B2);
        }

        //mangesh- DMND0005327- Requet 15
        private void EditAssociatedGn75B()
        {
            long? associatedGn75BFormNumber = page.Details.AssociatedGn75BFormNumber;
            if (!associatedGn75BFormNumber.HasValue)
                return;

            FormGN75B formGn75B = formService.QueryFormGN75BById(associatedGn75BFormNumber.Value);
            FormGN75BFormPresenter presenter = new FormGN75BFormPresenter(formGn75B);
            presenter.Run(null);
        }
        //mangesh- DMND0005327- Requet 15
        private void EditAssociatedGn75B1()
        {
            long? associatedGn75BFormNumber1 = page.Details.AssociatedGn75BFormNumber1;
            if (!associatedGn75BFormNumber1.HasValue)
                return;

            FormGN75B formGn75B1 = formService.QueryFormGN75BById(associatedGn75BFormNumber1.Value);
            FormGN75BFormPresenter presenter = new FormGN75BFormPresenter(formGn75B1);
            presenter.Run(null);
        }
        //mangesh- DMND0005327- Requet 15
        private void EditAssociatedGn75B2()
        {
            long? associatedGn75BFormNumber2 = page.Details.AssociatedGn75BFormNumber2;
            if (!associatedGn75BFormNumber2.HasValue)
                return;

            FormGN75B formGn75B2 = formService.QueryFormGN75BById(associatedGn75BFormNumber2.Value);
            FormGN75BFormPresenter presenter = new FormGN75BFormPresenter(formGn75B2);
            presenter.Run(null);
        }

        //DMND0010124 mangesh
        protected override IForm CreateCopyLastResponseForm(ActionItem item)
        {
            throw new NotImplementedException();
        }

        protected override IForm CreateResponseForm(ActionItem item)
        {
                return new ActionItemResponseForm(item, ActionItemStatus.AvailableForCurrentView, ActionItemStatus.Complete);
        }

        protected override PageKey GetDefinitionPageKey()
        {
            return null; // PageKey.READING_DEFINITION_PAGE;
        }

        protected override void ControlDetailButtons()
        {
            UserRoleElements userRoleElements = userContext.UserRoleElements;

            List<ActionItemDTO> selectedItems = page.SelectedItems;
            
            bool hasSingleItemSelected = selectedItems.Count == 1;
            bool hasItemsSelected = selectedItems.Count > 0;

            //COMMENT: trg - if this changes .. it means that the OldPriorityPagePresenter AuthorizeActionItemContextMenu needs to reflect change as well.
            IActionItemDetails details = page.Details;
            details.RespondEnabled = 
                hasSingleItemSelected && authorized.ToRespondActionItem(userRoleElements, page.FirstSelectedItem);
            details.GoToDefinitionEnabled = hasSingleItemSelected;
            EnableViewAssociatedLogsButtonIfNecessary();
            details.PrintEnabled = hasItemsSelected;
            details.PrintPreviewEnabled = hasSingleItemSelected;
        

        }


        private void EnableViewAssociatedLogsButtonIfNecessary()
        {
            bool hasSingleItemSelected = page.SelectedItems.Count == 1;
            page.Details.ViewAssociatedLogsEnabled = hasSingleItemSelected && (logService.CountOfLogsAssociatedToActionItem(page.FirstSelectedItem.IdValue) > 0);
        }

        protected override bool IsItemInDateRange(ActionItem actionItem, Range<Date> dateRange)
        {
            DateTime startDateTime = dateRange.LowerBound.CreateDateTime(Time.START_OF_DAY);
            DateTime? endDateTime = null;
            if (dateRange.UpperBound != null)
            {
                endDateTime = dateRange.UpperBound.CreateDateTime(Time.END_OF_DAY);
            }

            return (actionItem.StartDateTime >= startDateTime && (endDateTime == null || actionItem.StartDateTime <= endDateTime));
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerActionItemUpdated += repeater_Updated;
            remoteEventRepeater.ServerActionItemCreated += repeater_Created;
            remoteEventRepeater.ServerActionItemRemoved += repeater_Removed;
            remoteEventRepeater.ServerActionItemRefresh += repeater_Refresh;
            remoteEventRepeater.ServerLogRemoved += repeater_Log_Removed;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerActionItemUpdated -= repeater_Updated;
            remoteEventRepeater.ServerActionItemCreated -= repeater_Created;
            remoteEventRepeater.ServerActionItemRemoved -= repeater_Removed;
            remoteEventRepeater.ServerActionItemRefresh -= repeater_Refresh;
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
                    potentiallyReferencedLog );
            }
        }

        private void RefreshDetailButtonsIfLogMightBeAssociated(Log potentiallyReferencedLog)
        {
            if (potentiallyReferencedLog.LogType == LogType.Standard)
            {
                EnableViewAssociatedLogsButtonIfNecessary();
            }
        }

        protected override ActionItem QueryByDto(ActionItemDTO dto)
        {
            return service.QueryById(dto.IdValue);
        }

        protected override void SetDetailData(IActionItemDetails details, ActionItem actionItem)
        {
            details.SetDetails(actionItem, userContext.IsEdmontonSite,false);
        }
        protected override ActionItemDTO CreateDTOFromDomainObject(ActionItem item)

        {
            return new ActionItemDTO(item);
        }

        protected override bool ShouldBeDisplayed(ActionItem item)
        {
            return item.IsNot(ActionItemStatus.Cleared);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_ActionItem; }
        }

        public void ViewAssociatedLogs(object sender, EventArgs e)
        {
            List<LogDTO> associatedLogDtos = logService.QueryDTOsByActionItem(page.FirstSelectedItem.IdValue);
            page.ShowAssociatedLogForm(associatedLogDtos);
        }

        protected override IList<ActionItemDTO> GetDtos(Range<Date> range)
        {
            List<ActionItemDTO> RemovalList = new List<ActionItemDTO>();
            var readings = service.QueryDTOsByFunctionalLocationsAndDateRange(userContext.RootFlocSet, ActionItemStatus.AvailableForCurrentView, range, userContext.ReadableVisibilityGroupIds);
            if (readings != null && readings.Count > 0)
            {
                List<ActionItemDTO> ListToRemove = new List<ActionItemDTO>();
                foreach (ActionItemDTO aidto in readings)
                {
                    var aidef = service.QueryActionItemDefinitionByActionItemCreatedByActionItemDefId(aidto.DefinitionId());
                    if (!aidef.Reading)
                        ListToRemove.Add(aidto);
                }
                if (ListToRemove != null && ListToRemove.Count > 0)
                {
                    foreach (ActionItemDTO aidremove in ListToRemove)
                    {
                        readings.Remove(aidremove);
                    }
                }
            }
            return readings;
        }

        private void PrintPreview(object sender, EventArgs args)
        {
            reportPrintManager.PreviewReport(QueryForFirstSelectedItem());
        }

        private void Print(object sender, EventArgs args)
        {
            PrintWithDialogFocus(Print);
        }

        private void Print()
        {
            reportPrintManager.PrintReport(ConvertAllTo(page.SelectedItems));
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            return DateRangeUtilities.GetDefaultDateRangeForActionItems(userContext.Site, userContext.SiteConfiguration, timeService);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.Readings; }            //ayman action item reading
        }
    }
}
