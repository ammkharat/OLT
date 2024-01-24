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
    public class EdmontonGN24FormContext : AbstractEdmontonFormContext<FormEdmontonGN24DTO, FormGN24, FormEdmontonGN24Details>
    {
        private readonly IWorkPermitEdmontonService workPermitService;
        private readonly IReportPrintManager<FormGN24> reportPrintManager;

        public EdmontonGN24FormContext(IFormEdmontonService formService, IWorkPermitEdmontonService workPermitService, AbstractMultiGridPage page) 
            : base(formService, page, EdmontonFormType.GN24, new FormEdmontonGN24Details(), new FormEdmontonGN24GridRenderer())
        {
            this.workPermitService = workPermitService;

            EdmontonGN24FormPrintActions printActions = new EdmontonGN24FormPrintActions(false);
            reportPrintManager = new ReportPrintManager<FormGN24, FormGN24Report, FormGN24ReportAdapter>(printActions);
        }

        protected override FormEdmontonGN24DTO CreateDtoFromDomainObject(FormGN24 item)
        {
            return (FormEdmontonGN24DTO) item.CreateDTO();
        }

        public override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerGN24FormCreated += HandleRepeaterCreated;
            remoteEventRepeater.ServerGN24FormUpdated += HandleRepeaterUpdated;
            remoteEventRepeater.ServerGN24FormRemoved += HandleRepeaterRemoved;
        }

        public override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerGN24FormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerGN24FormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerGN24FormRemoved -= HandleRepeaterRemoved;
        }

        public override void SetDetailData(FormEdmontonGN24Details details, FormGN24 form)
        {
            details.WorkPermitEdmontonSectionVisible = true;

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
                details.PreJobMeetingSignatures = null;
                details.FormNumber = null;
                details.ClosedDateTime = null;
                details.ApprovedDateTime = null;
                details.WorkPermitEdmontonDTOs = null;
                details.AlkylationClass = null;
                details.DocumentLinks = new List<DocumentLink>();

                return;
            }

            details.IsForPSVRemovalOrInstallation = form.IsTheSafeWorkPlanForPSVRemovalOrInstallation;
            details.IsForWorkInTheAlkylationUnit = form.IsTheSafeWorkPlanForWorkInTheAlkylationUnit;
            details.AlkylationClass = form.AlkylationClass;

            details.CreatedByUser = form.CreatedBy;
            details.CreatedDateTime = form.CreatedDateTime;

            details.LastModifiedByUser = form.LastModifiedBy;
            details.LastModifiedDateTime = form.LastModifiedDateTime;

            details.Content = form.Content;
            details.PreJobMeetingSignatures = form.PreJobMeetingSignatures;

            details.ValidFromDateTime = form.FromDateTime;
            details.ValidToDateTime = form.ToDateTime;
            details.FunctionalLocations = form.FunctionalLocations;
            List<FormApproval> enabledApprovals = form.Approvals.FindAll(a => a.ShouldBeEnabled(form, Clock.Now));
            details.Approvals = enabledApprovals;

            details.FormNumber = form.FormNumber;
            details.ClosedDateTime = form.ClosedDateTime;
            details.ApprovedDateTime = form.ApprovedDateTime;

            List<WorkPermitEdmontonDTO> workPermitsAssociatedToForm = workPermitService.QueryDtosByFormGN24Id(form.IdValue);
            currentFormAssociatedToIssuedPermit = workPermitsAssociatedToForm.Exists(wp => wp.Status == PermitRequestBasedWorkPermitStatus.Issued);
            details.WorkPermitEdmontonDTOs = workPermitsAssociatedToForm;
            
            details.DocumentLinks = form.DocumentLinks;
        }

        private bool currentFormAssociatedToIssuedPermit;

        public override bool IsItemSelected
        {
            get { return grid.SelectedItem != null; }
        }

        public override void ControlDetailButtons()
        {            
            base.ControlDetailButtons();

            UserRoleElements userRoleElements = userContext.UserRoleElements;
            List<FormEdmontonGN24DTO> selectedItems = GetSelectedItems();
            bool hasSingleItemSelected = selectedItems.Count == 1;

            details.EditEnabled = hasSingleItemSelected && authorized.ToEditFormGN24(userRoleElements, selectedItems[0].Status);
        }

        public override IList<FormEdmontonGN24DTO> GetData(RootFlocSet flocSet, DateRange dateRange, List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange)
        {
            return formService.QueryFormGN24DTOsByCriteria(flocSet, dateRange, formStatuses, includeAllDraftFormsRegardlessOfDateRange);
        }

        protected override EdmontonFormType FormTypeToQuery()
        {
            return EdmontonFormType.GN24;
        }

        //ayman generic forms
        public override FormGN24 QueryByIdAndSiteId(long id,long siteid)
        {
            return formService.QueryFormGN24ByIdAndSiteId(id,siteid);
        }
        
        
        public override FormGN24 QueryById(long id)
        {
            return formService.QueryFormGN24ById(id);
        }

        protected override void Update(FormGN24 form)
        {
            //ayman generic forms include siteid
            form.SiteId = ClientSession.GetUserContext().SiteId; 

            LabelAttributes attributesForHazardsLabel = WorkPermitEdmontonReport.GetAttributesForHazardsLabel();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.UpdateGN24, form, attributesForHazardsLabel);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_FormGN24; }
        }

        protected override IForm CreateEditForm(FormGN24 item)
        {
            FormGN24FormPresenter presenter = new FormGN24FormPresenter(item);
            return presenter.View;            
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(FormGN24 item)
        {
            return new EditFormGN24HistoryFormPresenter(item);
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

        protected override void Delete(FormGN24 item)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.RemoveGN24, item, ClientSession.GetUserContext().User);
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
            get { return UserGridLayoutIdentifier.FormGN24; }
        }

        protected override IReportPrintManager<FormGN24> ReportPrintManager
        {
            get { return reportPrintManager; }
        }

        public override DialogResultAndOutput<FormGN24> Edit(FormGN24 domainObject, IBaseForm view)
        {
            FormGN24FormPresenter presenter = new FormGN24FormPresenter(domainObject);
            return presenter.RunAndReturnTheEditObject(view);
        }

        public override DialogResultAndOutput<FormGN24> CreateNew(IBaseForm view)
        {
            FormGN24FormPresenter presenter = new FormGN24FormPresenter();
            return presenter.RunAndReturnTheEditObject(view);
        }
    }
}