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
    public class EdmontonGN6FormContext : AbstractEdmontonFormContext<FormEdmontonGN6DTO, FormGN6, FormEdmontonGN6Details>
    {
        private readonly IWorkPermitEdmontonService workPermitService;
        private readonly IReportPrintManager<FormGN6> reportPrintManager;

        public EdmontonGN6FormContext(IFormEdmontonService formService, IWorkPermitEdmontonService workPermitService, AbstractMultiGridPage page) 
            : base(formService, page, EdmontonFormType.GN6, new FormEdmontonGN6Details(), new FormEdmontonGN6GridRenderer())
        {
            this.workPermitService = workPermitService;
            EdmontonGN6FormPrintActions printActions = new EdmontonGN6FormPrintActions(false);
            reportPrintManager = new ReportPrintManager<FormGN6, FormGN6Report, FormGN6ReportAdapter>(printActions);

        }

        protected override FormEdmontonGN6DTO CreateDtoFromDomainObject(FormGN6 item)
        {
            return (FormEdmontonGN6DTO) item.CreateDTO();
        }

        public override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerGN6FormCreated += HandleRepeaterCreated;
            remoteEventRepeater.ServerGN6FormUpdated += HandleRepeaterUpdated;
            remoteEventRepeater.ServerGN6FormRemoved += HandleRepeaterRemoved;
        }

        public override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerGN6FormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerGN6FormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerGN6FormRemoved -= HandleRepeaterRemoved;
        }

        public override void SetDetailData(FormEdmontonGN6Details details, FormGN6 form)
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
                details.Section1NotApplicableToJob = false;
                details.Section1Content = null;
                details.PreJobMeetingSignatures = null;
                details.FormNumber = null;
                details.ClosedDateTime = null;
                details.ApprovedDateTime = null;
                details.WorkPermitEdmontonDTOs = null;
                details.DocumentLinks = new List<DocumentLink>();
                details.JobDescription = null;
                details.ReasonForCriticalLift = null;

                return;
            }

            details.CreatedByUser = form.CreatedBy;
            details.CreatedDateTime = form.CreatedDateTime;

            details.LastModifiedByUser = form.LastModifiedBy;
            details.LastModifiedDateTime = form.LastModifiedDateTime;

            details.Section1NotApplicableToJob = form.Section1NotApplicableToJob;
            details.Section1Content = form.Section1Content;
            details.Section2NotApplicableToJob = form.Section2NotApplicableToJob;
            details.Section2Content = form.Section2Content;
            details.Section3NotApplicableToJob = form.Section3NotApplicableToJob;
            details.Section3Content = form.Section3Content;
            details.Section4NotApplicableToJob = form.Section4NotApplicableToJob;
            details.Section4Content = form.Section4Content;
            details.Section5NotApplicableToJob = form.Section5NotApplicableToJob;
            details.Section5Content = form.Section5Content;
            details.Section6NotApplicableToJob = form.Section6NotApplicableToJob;
            details.Section6Content = form.Section6Content;

            details.PreJobMeetingSignatures = form.PreJobMeetingSignatures;
            details.JobDescription = form.JobDescription;
            details.ReasonForCriticalLift = form.ReasonForCriticalLift;

            details.ValidFromDateTime = form.FromDateTime;
            details.ValidToDateTime = form.ToDateTime;
            details.FunctionalLocations = form.FunctionalLocations;
            details.Approvals = form.Approvals;

            details.FormNumber = form.FormNumber;
            details.ClosedDateTime = form.ClosedDateTime;
            details.ApprovedDateTime = form.ApprovedDateTime;

            List<WorkPermitEdmontonDTO> associatedPermits = workPermitService.QueryDtosByFormGN6Id(form.IdValue);
            currentFormAssociatedToIssuedPermit = associatedPermits.Exists(wp => wp.Status == PermitRequestBasedWorkPermitStatus.Issued);
            details.WorkPermitEdmontonDTOs = associatedPermits;
            
            details.DocumentLinks = form.DocumentLinks;

            details.AdjustTextBoxHeights();
        }

        public override bool IsItemSelected
        {
            get { return grid.SelectedItem != null; }
        }

        public override void ControlDetailButtons()
        {            
            base.ControlDetailButtons();

            UserRoleElements userRoleElements = userContext.UserRoleElements;
            List<FormEdmontonGN6DTO> selectedItems = GetSelectedItems();
            bool hasSingleItemSelected = selectedItems.Count == 1;

            details.EditEnabled = hasSingleItemSelected && authorized.ToEditFormGN6(userRoleElements, selectedItems[0].Status);
        }

        public override IList<FormEdmontonGN6DTO> GetData(RootFlocSet flocSet, DateRange dateRange, List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange)
        {
            return formService.QueryFormGN6DTOsByCriteria(flocSet, dateRange, formStatuses, includeAllDraftFormsRegardlessOfDateRange);
        }

        protected override EdmontonFormType FormTypeToQuery()
        {
            return EdmontonFormType.GN6;
        }

        //ayman generic forms
        public override FormGN6 QueryByIdAndSiteId(long id,long siteid)
        {
            return formService.QueryFormGN6ByIdAndSiteId(id,siteid);
        }
        
        public override FormGN6 QueryById(long id)
        {
            return formService.QueryFormGN6ById(id);
        }

        protected override void Update(FormGN6 form)
        {
            //ayman generic forms include siteid 
            form.SiteId = ClientSession.GetUserContext().SiteId;

            LabelAttributes attributesForHazardsLabel = WorkPermitEdmontonReport.GetAttributesForHazardsLabel();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.UpdateGN6, form, attributesForHazardsLabel);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_FormGN6; }
        }

        protected override IForm CreateEditForm(FormGN6 item)
        {
            FormGN6FormPresenter presenter = new FormGN6FormPresenter(item);
            return presenter.View;            
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(FormGN6 item)
        {
            return new EditFormGN6HistoryFormPresenter(item);
        }

        private bool currentFormAssociatedToIssuedPermit;

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

        protected override void Delete(FormGN6 item)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.RemoveGN6, item, ClientSession.GetUserContext().User);
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
            get { return UserGridLayoutIdentifier.FormGN6; }
        }

        protected override IReportPrintManager<FormGN6> ReportPrintManager
        {
            get { return reportPrintManager; }
        }

        public override DialogResultAndOutput<FormGN6> Edit(FormGN6 domainObject, IBaseForm view)
        {
            FormGN6FormPresenter presenter = new FormGN6FormPresenter(domainObject);
            return presenter.RunAndReturnTheEditObject(view);
        }

        public override DialogResultAndOutput<FormGN6> CreateNew(IBaseForm view)
        {
            FormGN6FormPresenter presenter = new FormGN6FormPresenter();
            return presenter.RunAndReturnTheEditObject(view);
        }
    }
}