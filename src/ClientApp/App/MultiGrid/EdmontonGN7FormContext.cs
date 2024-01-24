using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.MultiGrid
{
    public class EdmontonGN7FormContext : AbstractEdmontonFormContext<FormEdmontonDTO, FormGN7, FormEdmontonDetails>
    {
        private readonly IWorkPermitEdmontonService workPermitEdmontonService;
        private readonly IReportPrintManager<FormGN7> reportPrintManager;

        public EdmontonGN7FormContext(IFormEdmontonService formService,
            IWorkPermitEdmontonService workPermitEdmontonService, AbstractMultiGridPage page)
            : base(formService, page, EdmontonFormType.GN7, new FormEdmontonDetails(), new FormEdmontonGridRenderer())
        {
            this.workPermitEdmontonService = workPermitEdmontonService;
            PrintActions<FormGN7, FormReport, FormReportAdapter> printActions = new EdmontonGN7FormPrintActions();
            reportPrintManager = new ReportPrintManager<FormGN7, FormReport, FormReportAdapter>(printActions);
        }

        protected override IReportPrintManager<FormGN7> ReportPrintManager
        {
            get { return reportPrintManager; }
        }


        protected override FormEdmontonDTO CreateDtoFromDomainObject(FormGN7 item)
        {
            return (FormEdmontonDTO) item.CreateDTO();
        }

        public override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerGN7FormCreated += HandleRepeaterCreated;
            remoteEventRepeater.ServerGN7FormUpdated += HandleRepeaterUpdated;
            remoteEventRepeater.ServerGN7FormRemoved += HandleRepeaterRemoved;
        }

        public override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerGN7FormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerGN7FormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerGN7FormRemoved -= HandleRepeaterRemoved;
        }

        public override void SetDetailData(FormEdmontonDetails details, FormGN7 form)
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

            details.WorkPermitEdmontonDTOs = workPermitEdmontonService.QueryDtosByFormGN7Id(form.IdValue);
        }

        public override bool IsItemSelected
        {
            get { return grid.SelectedItem != null; }
        }

        public override void ControlDetailButtons()
        {
            base.ControlDetailButtons();

            UserRoleElements userRoleElements = userContext.UserRoleElements;
            List<FormEdmontonDTO> selectedItems = GetSelectedItems();
            bool hasSingleItemSelected = selectedItems.Count == 1;

            details.EditEnabled = hasSingleItemSelected &&
                                  authorized.ToEditFormGN7(userRoleElements, selectedItems[0].Status);
        }

        public override IList<FormEdmontonDTO> GetData(RootFlocSet flocSet, DateRange dateRange,
            List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange)
        {
            return formService.QueryFormGN7DTOs(flocSet, dateRange, formStatuses,
                includeAllDraftFormsRegardlessOfDateRange);
        }

        protected override EdmontonFormType FormTypeToQuery()
        {
            return EdmontonFormType.GN7;
        }

        //ayman generic forms
        public override FormGN7 QueryByIdAndSiteId(long id,long siteid)
        {
            return formService.QueryFormGN7ByIdAndSiteId(id,siteid);
        }

        public override FormGN7 QueryById(long id)
        {
            return formService.QueryFormGN7ById(id);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_FormGN7; }
        }

        protected override IForm CreateEditForm(FormGN7 item)
        {
            FormGN7FormPresenter presenter = new FormGN7FormPresenter(item);
            return presenter.View;
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(FormGN7 item)
        {
            return new EditFormGN7HistoryFormPresenter(item);
        }

        protected override void Delete(FormGN7 item)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.RemoveGN7, item);
        }

        protected override void Update(FormGN7 form)
        {
            //ayman generic forms include siteid
            form.SiteId = ClientSession.GetUserContext().SiteId;

            LabelAttributes attributesForHazardsLabel = WorkPermitEdmontonReport.GetAttributesForHazardsLabel();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.UpdateGN7, form,
                attributesForHazardsLabel);
        }

        public override Range<Date> GetDefaultDateRange()
        {
            Date now = Clock.DateNow;
            Date from = now.AddDays(-1*userContext.SiteConfiguration.DaysToDisplayFormsBackwards);
            Date to = userContext.SiteConfiguration.DaysToDisplayFormsForwards == null
                ? null
                : now.AddDays(userContext.SiteConfiguration.DaysToDisplayFormsForwards.Value);

            return new Range<Date>(from, to);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.FormGN7; }
        }

        public override DialogResultAndOutput<FormGN7> Edit(FormGN7 domainObject, IBaseForm view)
        {
            FormGN7FormPresenter presenter = new FormGN7FormPresenter(domainObject);
            return presenter.RunAndReturnTheEditObject(view);
        }

        public override DialogResultAndOutput<FormGN7> CreateNew(IBaseForm view)
        {
            FormGN7FormPresenter presenter = new FormGN7FormPresenter();
            return presenter.RunAndReturnTheEditObject(view);
        }
    }
}