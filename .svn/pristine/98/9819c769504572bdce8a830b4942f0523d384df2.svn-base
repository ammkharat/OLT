using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using log4net;

namespace Com.Suncor.Olt.Client.MultiGrid
{
    public class GenericTemplateFormContext :
        AbstractEdmontonFormContext<FormGenericTemplateDTO, FormGenericTemplate, FormGenericTemplateDetails>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (EdmontonOP14FormContext));
        private readonly IReportPrintManager<FormGenericTemplate> reportPrintManager;
        private readonly WindowsFormsSynchronizationContext synchronizationContext;
        private readonly GenericTemplateFormTimerManager timerManager;
        private long formtypeid;
        private long plantid = ClientSession.GetUserContext().Site.Plants[0].IdValue; //INC0251500 - mangesh

        public GenericTemplateFormContext(IFormEdmontonService formService, AbstractMultiGridPage page, long formTypeID)
            : base(formService, page, getEdmontonFormType(formTypeID), new FormGenericTemplateDetails(), new GenericTemplateFormGridRenderer())
        {
            PrintActions<FormGenericTemplate, FormGenericTemplateReport, FormGenericTemplateReportAdapter> printActions =
                new FormGenericTemplateFormPrintActions();
            reportPrintManager = new ReportPrintManager<FormGenericTemplate, FormGenericTemplateReport, FormGenericTemplateReportAdapter>(printActions);
            synchronizationContext = (WindowsFormsSynchronizationContext) SynchronizationContext.Current;
            timerManager = new GenericTemplateFormTimerManager();
            page.Disposed += HandlePageDisposed;
            this.formtypeid =  formTypeID;
        }

        public override bool IsItemSelected { get { return grid.SelectedItem != null; } }
        protected override string DomainObjectName { get { return Convert.ToString(FormGenericTemplate.getEdmontonFormType(formtypeid)); } }
        protected override UserGridLayoutIdentifier GridIdentifier { get { return FormGenericTemplate.getUserGridLayoutIdentifier(formtypeid); } } 

        protected override IReportPrintManager<FormGenericTemplate> ReportPrintManager { get { return reportPrintManager; } }
        
        static EdmontonFormType getEdmontonFormType(long formTypeID)
        {
            return FormGenericTemplate.getEdmontonFormType(formTypeID);
        }

        private void HandlePageDisposed(object sender, EventArgs eventArgs)
        {
            if (timerManager != null)
            {
                timerManager.Clear();
            }
        }

        public override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            page.Disposed -= HandlePageDisposed;
        }

        protected override FormGenericTemplateDTO CreateDtoFromDomainObject(FormGenericTemplate item)
        {
            return (FormGenericTemplateDTO) item.CreateDTO();
        }

        public override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerGenericTemplateFormCreated += HandleRepeaterCreated;
            remoteEventRepeater.ServerGenericTemplateFormUpdated += HandleRepeaterUpdated;
            remoteEventRepeater.ServerGenericTemplateFormRemoved += HandleRepeaterRemoved;
        }

        protected override void HandleRepeaterCreated(object sender, DomainEventArgs<FormGenericTemplate> e)
        {
            if (page != null && !page.IsDisposed)
            {
                if (e.SelectedItem != null)
                {
                    RegisterRenderTimer(CreateDtoFromDomainObject(e.SelectedItem));
                }
            }
            base.HandleRepeaterCreated(sender, e);
        }

        protected override void HandleRepeaterUpdated(object sender, DomainEventArgs<FormGenericTemplate> e)
        {
            if (page != null && !page.IsDisposed)
            {
                if (e.SelectedItem != null)
                {
                    RegisterRenderTimer(CreateDtoFromDomainObject(e.SelectedItem));
                }
            }
            base.HandleRepeaterUpdated(sender, e);
        }

        public override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerGenericTemplateFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerGenericTemplateFormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerGenericTemplateFormRemoved -= HandleRepeaterRemoved;
        }

        public override void SetDetailData(FormGenericTemplateDetails details, FormGenericTemplate form)
        {

            details.WorkPermitEdmontonSectionVisible = false;

            details.ValidFromDateTimeLabel = StringResources.FormGenericTemplate_SystemDefeated + ":";
            details.ValidToDateTimeLabel = StringResources.FormGenericTemplate_EstimatedBackInService + ":";

            if (form == null)
            {
                details.ValidFromDateTime = null;
                details.ValidToDateTime = null;
                details.CreatedByUser = null;
                details.CreatedDateTime = null;
                details.LastModifiedByUser = null;
                details.LastModifiedDateTime = null;
                details.FunctionalLocations = null;
                details.Approvals = null;
                details.Content = null;
                details.FormNumber = null;
                details.ClosedDateTime = null;
                details.ApprovedDateTime = null;
                details.WorkPermitEdmontonDTOs = null;
                //details.Department = null;
                details.DocumentLinks = null;
                //details.IsTheCSDForAPressureSafetyValve = null;
                //details.CriticalSystemDefeated = null;
                return;
            }

            details.CreatedByUser = form.CreatedBy;
            details.CreatedDateTime = form.CreatedDateTime;

            details.LastModifiedByUser = form.LastModifiedBy;
            details.LastModifiedDateTime = form.LastModifiedDateTime;

            details.Content = form.Content;

            details.ValidFromDateTime = form.FromDateTime;
            details.ValidToDateTime = form.ToDateTime;
            details.FunctionalLocations = form.FunctionalLocations;
            details.Approvals = form.EnabledApprovals;

            details.FormNumber = form.FormNumber;
            details.ClosedDateTime = form.ClosedDateTime;
            details.ApprovedDateTime = form.ApprovedDateTime;
            details.DocumentLinks = form.DocumentLinks;
            //details.Department = form.Department;
            //details.IsTheCSDForAPressureSafetyValve = form.IsTheCSDForAPressureSafetyValve;
            //details.CriticalSystemDefeated = form.CriticalSystemDefeated;
            
            details.AdjustTextBoxHeights();
        }

        public override void ControlDetailButtons()
        { 
            //base.ControlDetailButtons();
            var userRoleElements = userContext.UserRoleElements;
            var selectedItems = GetSelectedItems(); //List<FormGenericTemplateDTO> selectedItems1 = grid.SelectedItems;
            //if(selectedItems.Count <= 0) return;
            var hasSingleItemSelected = selectedItems.Count == 1;
            bool hasItemsSelected = selectedItems.Count > 0;
            var site = userContext.Site;
            EdmontonFormType formType = FormGenericTemplate.getEdmontonFormType(formtypeid);
            FormStatus formStatus = hasItemsSelected ? selectedItems[0].Status : null;

            bool hasEdit = authorized.ToEditFormGenericTemplate(userRoleElements, formStatus, formType, site);
            bool hasCreate = authorized.ToCreateFormGenericTemplate(userRoleElements, formStatus, formType, site);
            bool hasApproveOrClose = authorized.ToApproveOrCloseFormGenericTemplate(userRoleElements, formStatus, formType, site);
            bool hasDelete = authorized.ToDeleteFormGenericTemplate(userRoleElements, formStatus, formType, site) && FormStatus.Draft.Equals(formStatus); 

            details.ViewEditHistoryEnabled = hasSingleItemSelected;
            details.EditEnabled = hasSingleItemSelected && hasEdit;
            details.DeleteEnabled = hasSingleItemSelected && hasDelete;
            details.CloneEnabled = hasSingleItemSelected && hasCreate;
            details.CloseEnabled = hasItemsSelected && hasApproveOrClose &&
                                   selectedItems.TrueForAll(
                                       item =>
                                           FormStatus.Draft.Equals(item.Status) ||
                                           FormStatus.Approved.Equals(item.Status) ||
                                           FormStatus.Expired.Equals(item.Status) ||
                                           FormStatus.WaitingForApproval.Equals(item.Status));
            details.PrintEnabled = hasItemsSelected;
            details.PrintPreviewEnabled = hasSingleItemSelected;
            details.EmailEnabled = hasSingleItemSelected && !formStatus.Equals(FormStatus.Approved) && !formStatus.Equals(FormStatus.Closed);

            //INC0251500 - mangesh
            bool isSameUser = false;
            if (hasItemsSelected)
            {
                isSameUser = userContext.User.IdValue == selectedItems[0].CreatedByUserId;
            }
            if (!hasEdit && hasSingleItemSelected && hasCreate && isSameUser //userContext.User.IdValue == selectedItems[0].CreatedByUserId
                && selectedItems[0].Status != FormStatus.Closed) //RITM0341710 : Bug fix Vibhor added the condition if form is closed user not able to edit
            {
                details.EditEnabled = true;
            }
            else if (details.CloseEnabled)// && userContext.User.IdValue == selectedItems[0].CreatedByUserId
            {
                details.EditEnabled = true;
            }
        }

        public override IList<FormGenericTemplateDTO> GetData(RootFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStatuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            var op14Dtos = formService.QueryFormGenericTemplateDTOs(flocSet,
                dateRange,
                formStatuses,
                includeAllDraftFormsRegardlessOfDateRange,
                formtypeid, plantid);
            timerManager.Clear();
            op14Dtos.ForEach(RegisterRenderTimer);
            return op14Dtos;
        }

        private void RegisterRenderTimer(FormGenericTemplateDTO dto)
        {
            timerManager.Unregister(dto);
            var now = Clock.Now;

            // this will never auto change its grouping
            if (dto.ValidTo < now) return;

            if (dto.ValidFrom > now)
            {
                var timeUntilActive = dto.ValidFrom.Subtract(now);
                SetupTimerCallback(timeUntilActive, dto);
            }
            else
            {
                var timeUntilRequiresApprovalOrExpires = dto.ValidTo.Subtract(now);
                SetupTimerCallback(timeUntilRequiresApprovalOrExpires, dto);
            }
        }

        private void SetupTimerCallback(TimeSpan differenceInTime, FormGenericTemplateDTO dto)
        {
            var timeRemainingInShift = ClientSession.GetInstance().GetTimeRemainingInShiftWithPostShiftPadding();
            if (differenceInTime < timeRemainingInShift)
            {
                SetupTimerForCallback(dto, differenceInTime);
            }
        }

        private void SetupTimerForCallback(FormGenericTemplateDTO dto, TimeSpan differenceInTime)
        {
            try
            {
                timerManager.RegisterTimer(dto, differenceInTime, HandleTimerFire);
            }
            catch (TimerDueTimeNegativeException e)
            {
                logger.Error("Encountered negative timer due time for directive:<" + dto.Id + ">", e);
            }
        }

        private void HandleTimerFire(object dto)
        {
            // we are often in a background thread at this point but we need to manipulate the UI, so we make sure to do
            // the real work on the UI thread
            synchronizationContext.Post(RefreshItem, dto);
        }

        private void RefreshItem(object dto)
        {
            if (!(dto is FormGenericTemplateDTO)) return;

            if (!(page.Grid is DomainSummaryGrid<FormGenericTemplateDTO>))
            {
                DataNeedsRefresh = true;

                return;
            }

            var edmontonOp14DTO = (FormGenericTemplateDTO)dto;
            RegisterRenderTimer(edmontonOp14DTO);

            var domainSummaryGrid = ((DomainSummaryGrid<FormGenericTemplateDTO>)page.Grid);
            var oldVersion =
                domainSummaryGrid.FindItem(edmontonOp14DTO.Id);

            if (oldVersion == null) return;

            var updateIndex = domainSummaryGrid.Items.IndexOf(oldVersion);

            if (updateIndex == -1)
            {
                domainSummaryGrid.AddItem(edmontonOp14DTO);
            }
            else
            {
                domainSummaryGrid.UpdateItem(updateIndex, edmontonOp14DTO);
            }
        }

        protected override EdmontonFormType FormTypeToQuery()
        {
            return (FormGenericTemplate.getEdmontonFormType(formtypeid));
        }

        public override FormGenericTemplate QueryById(long id) 
        {
            return formService.QueryFormGenericTemplateById(id);
        }

        public override FormGenericTemplate QueryByIdAndSiteId(long id, long siteid)
        {
            return formService.QueryFormGenericTemplateByIdAndSiteId(id, siteid, formtypeid, plantid);  
        }

        protected override void Update(FormGenericTemplate form)
        {
            form.SiteId = ClientSession.GetUserContext().SiteId;            //ayman generic forms set siteid to the form
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.UpdateGenericTemplate, form);
        }

        protected override IForm CreateEditForm(FormGenericTemplate item)
        {
            var presenter = new FormGenericTemplateFormPresenter(item);
            return presenter.View;
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(FormGenericTemplate item)
        {
            return new EditFormGenericTemplateFormPresenter(item);
        }

        protected override void Delete(FormGenericTemplate item)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.RemoveGenericTemplate, item);
        }

        public override Range<Date> GetDefaultDateRange()
        {
            var now = Clock.DateNow;
            var from = now.AddDays(-1*userContext.SiteConfiguration.DaysToDisplayFormsBackwards);
            var to = userContext.SiteConfiguration.DaysToDisplayFormsForwards == null
                ? null
                : now.AddDays(userContext.SiteConfiguration.DaysToDisplayFormsForwards.Value);

            return new Range<Date>(from, to);
        }

        public override DialogResultAndOutput<FormGenericTemplate> Edit(FormGenericTemplate domainObject, IBaseForm view)
        {
            var presenter = new FormGenericTemplateFormPresenter(domainObject);
            return presenter.RunAndReturnTheEditObject(view);
        }

        public override DialogResultAndOutput<FormGenericTemplate> CreateNew(IBaseForm view)
        {
            var presenter = new FormGenericTemplateFormPresenter();
            return presenter.RunAndReturnTheEditObject(view);
        }
    }
}