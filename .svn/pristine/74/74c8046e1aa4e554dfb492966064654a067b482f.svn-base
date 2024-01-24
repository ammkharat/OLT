using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.MultiGrid
{
    public class EdmontonGN59FormContext : AbstractEdmontonFormContext<FormEdmontonDTO, FormGN59, FormEdmontonDetails>
    {
        private readonly IWorkPermitEdmontonService workPermitEdmontonService;
        private readonly IReportPrintManager<FormGN59> reportPrintManager;
        private bool currentFormAssociatedToIssuedPermit;

        public EdmontonGN59FormContext(IFormEdmontonService formService, IWorkPermitEdmontonService workPermitEdmontonService, AbstractMultiGridPage page) 
            : base(formService, page, EdmontonFormType.GN59, new FormEdmontonDetails(), new FormEdmontonGridRenderer())
        {
            this.workPermitEdmontonService = workPermitEdmontonService;

            EdmontonGN59FormPrintActions edmontonGn59FormPrintActions = new EdmontonGN59FormPrintActions(false);
            reportPrintManager = new ReportPrintManager<FormGN59, FormReport, FormReportAdapter>(edmontonGn59FormPrintActions);
        }

        protected override IReportPrintManager<FormGN59> ReportPrintManager
        {
             get { return reportPrintManager; }
        }

        protected override FormEdmontonDTO CreateDtoFromDomainObject(FormGN59 item)
        {
            return (FormEdmontonDTO) item.CreateDTO();
        }

        public override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerGN59FormCreated += HandleRepeaterCreated;
            remoteEventRepeater.ServerGN59FormUpdated += HandleRepeaterUpdated;
            remoteEventRepeater.ServerGN59FormRemoved += HandleRepeaterRemoved;
        }

        public override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerGN59FormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerGN59FormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerGN59FormRemoved -= HandleRepeaterRemoved;
        }

        public override void SetDetailData(FormEdmontonDetails details, FormGN59 form)
        {            
            details.WorkPermitEdmontonSectionVisible = true;
            details.ValidFromDateTimeLabel = StringResources.From + ":";
            details.ValidToDateTimeLabel = StringResources.To + ":";

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
                details.DocumentLinks = null;
                details.WorkPermitEdmontonDTOs = null;
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
            details.Approvals = form.Approvals;
            details.DocumentLinks = form.DocumentLinks;

            details.FormNumber = form.FormNumber;
            details.ClosedDateTime = form.ClosedDateTime;
            details.ApprovedDateTime = form.ApprovedDateTime;

            List<WorkPermitEdmontonDTO> associatedPermits = workPermitEdmontonService.QueryDtosByFormGN59Id(form.IdValue);
            currentFormAssociatedToIssuedPermit = associatedPermits.Exists(wp => wp.Status == PermitRequestBasedWorkPermitStatus.Issued);
            details.WorkPermitEdmontonDTOs = associatedPermits;
        
        }

        public override void ControlDetailButtons()
        {
            base.ControlDetailButtons();

            List<FormEdmontonDTO> selectedItems = GetSelectedItems();
            bool hasSingleItemSelected = selectedItems.Count == 1;

            details.EditEnabled = hasSingleItemSelected && authorized.ToEditFormGN59(userContext.UserRoleElements, selectedItems[0].Status);            
        }

        public override IList<FormEdmontonDTO> GetData(RootFlocSet flocSet, DateRange dateRange, List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange)
        {
            return formService.QueryFormGN59DTOs(flocSet, dateRange, formStatuses, includeAllDraftFormsRegardlessOfDateRange);
        }

        public override bool IsItemSelected
        {
            get { return grid.SelectedItem != null; }
        }

        protected override EdmontonFormType FormTypeToQuery()
        {
            return EdmontonFormType.GN59;
        }

        
        //ayman generic forms
        public override FormGN59 QueryByIdAndSiteId(long id,long siteid)
        {
            return formService.QueryFormGN59ByIdAndSiteId(id,siteid);
        }
        
        
        public override FormGN59 QueryById(long id)
        {
            return formService.QueryFormGN59ById(id);
        }

        protected override void Update(FormGN59 form)
        {
            //ayman generic forms include siteid
            form.SiteId = ClientSession.GetUserContext().SiteId;

            LabelAttributes attributesForHazardsLabel = WorkPermitEdmontonReport.GetAttributesForHazardsLabel();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.UpdateGN59, form, attributesForHazardsLabel);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_FormGN59; }
        }

        protected override IForm CreateEditForm(FormGN59 item)
        {
            bool noReapprovalRequiredForEndDateChange = authorized.ToChangeEndDateOfGN59WithNoReapprovalRequired(userContext.UserRoleElements);

            FormGN59FormPresenter presenter = new FormGN59FormPresenter(item, noReapprovalRequiredForEndDateChange);
            return presenter.View;            
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(FormGN59 item)
        {
            return new EditFormGN59HistoryFormPresenter(item);
        }

        protected override void DeleteWithOkCancelDialog(string entityName)
        {
            if (currentFormAssociatedToIssuedPermit)
            {
                DialogResult result = OltMessageBox.ShowCustomYesNo(StringResources.FormAssociatedToIssuedPermit);
                if (DialogResult.Yes == result)
                {
                    LockMultipleDomainObjects(Delete, QueryDomainObjectListFromDtos(grid.SelectedItems), () => page.DeleteSuccessfulMessage());
                }
            }
            else
            {
                base.DeleteWithOkCancelDialog(entityName);
            }
        }

        protected override void Delete(FormGN59 item)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.RemoveGN59, item);
        }

        public override Range<Date> GetDefaultDateRange()
        {
            Date now = Clock.DateNow;
            Date from = now.AddDays(-1 * userContext.SiteConfiguration.DaysToDisplayFormsBackwards);
            Date to = userContext.SiteConfiguration.DaysToDisplayFormsForwards == null ? null : now.AddDays(userContext.SiteConfiguration.DaysToDisplayFormsForwards.Value);

            return new Range<Date>(from, to);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.FormGN59; }
        }

        public override DialogResultAndOutput<FormGN59> Edit(FormGN59 domainObject, IBaseForm view)
        {
            bool noReapprovalRequiredForEndDateChange = authorized.ToChangeEndDateOfGN59WithNoReapprovalRequired(userContext.UserRoleElements);

            FormGN59FormPresenter presenter = new FormGN59FormPresenter(domainObject, noReapprovalRequiredForEndDateChange);
            return presenter.RunAndReturnTheEditObject(view);
        }

        public override DialogResultAndOutput<FormGN59> CreateNew(IBaseForm view)
        {
            FormGN59FormPresenter presenter = new FormGN59FormPresenter();
            return presenter.RunAndReturnTheEditObject(view);
        }
    }
}