using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;

namespace Com.Suncor.Olt.Client.MultiGrid
{
    public class EdmontonOvertimeFormContext :
        AbstractEdmontonFormContext<EdmontonOvertimeFormDTO, OvertimeForm, EdmontonOvertimeFormDetails>
    {
        private IReportPrintManager<OvertimeForm> reportPrintManager;

        public EdmontonOvertimeFormContext(IFormEdmontonService service, AbstractMultiGridPage multiGridPage)
            : base(
                service, multiGridPage, EdmontonFormType.Overtime, new EdmontonOvertimeFormDetails(),
                new EdmontonOvertimeFormGridRenderer())
        {
            reportPrintManager =
                new ReportPrintManager
                    <OvertimeForm, FormOvertimeFormReport, Olt.Reports.Adapters.FormOvertimeFormReportAdapter>(
                    new FormOvertimeFormPrintActions());
        }

        protected override EdmontonOvertimeFormDTO CreateDtoFromDomainObject(OvertimeForm item)
        {
            return item.CreateDTO() as EdmontonOvertimeFormDTO;
        }

        public override void HookToServiceEvents(IRemoteEventRepeater repeater)
        {
            repeater.ServerOvertimeFormCreated += HandleRepeaterCreated;
            repeater.ServerOvertimeFormUpdated += HandleRepeaterUpdated;
            repeater.ServerOvertimeFormRemoved += HandleRepeaterRemoved;
        }

        public override void UnHookToServiceEvents(IRemoteEventRepeater repeater)
        {
            repeater.ServerOvertimeFormCreated -= HandleRepeaterCreated;
            repeater.ServerOvertimeFormUpdated -= HandleRepeaterUpdated;
            repeater.ServerOvertimeFormRemoved -= HandleRepeaterRemoved;
        }

        public override void SetDetailData(EdmontonOvertimeFormDetails details, OvertimeForm item)
        {
            if (item == null)
            {
                details.ClearDetails();
                return;
            }
            details.CreatedByUser = item.CreatedBy;
            details.CreatedDateTime = item.CreatedDateTime;
            details.LastModifiedByUser = item.LastModifiedBy;
            details.LastModifiedDateTime = item.LastModifiedDateTime;
            details.ApprovedDateTime = item.ApprovedDateTime;
            details.CancelledDateTime = item.CancelledDateTime;
            details.Trade = item.Trade;
            details.FormNumber = item.FormNumber;
            details.ValidFromDateTime = item.FromDateTime;
            details.ValidToDateTime = item.ToDateTime;

            details.Contractors = item.OnPremiseContractors;
            details.Approvals = item.Approvals;
            details.DocumentLinks = item.DocumentLinks;
        }

        protected override void Delete(OvertimeForm item)
        {
            throw new NotImplementedException();
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(OvertimeForm item)
        {
            return new EditFormEdmontonOvertimeFormHistoryPresenter(item);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.OvertimeForm; }
        }

        protected override IReportPrintManager<OvertimeForm> ReportPrintManager
        {
            get { return reportPrintManager; }
        }

        public override DialogResultAndOutput<OvertimeForm> Edit(OvertimeForm domainObject, IBaseForm view)
        {
            throw new NotImplementedException("Don't edit this Form from the Select Form. So, do nothing");
        }

        public override DialogResultAndOutput<OvertimeForm> CreateNew(IBaseForm view)
        {
            // Don't create this Form from the Select Form. So, do nothing
            throw new NotImplementedException("Don't create this Form from the Select Form. So, do nothing");
        }

        //ayman generic forms   override
        public override OvertimeForm QueryByIdAndSiteId(long id,long siteid)
        {
            return formService.QueryOvertimeFormById(id);
        }
        
        
        public override OvertimeForm QueryById(long id)
        {
            return formService.QueryOvertimeFormById(id);
        }

        public override IList<EdmontonOvertimeFormDTO> GetData(RootFlocSet flocSet, DateRange dateRange,
            List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange)
        {
            return formService.QueryOvertimeFormsByCriteria(dateRange);
        }

        public override void ControlDetailButtons()
        {
            base.ControlDetailButtons();
            List<EdmontonOvertimeFormDTO> selectedItems = GetSelectedItems();
            bool hasSingleItemSelected = selectedItems.Count == 1;
            bool hasMultipleSelected = selectedItems.Count > 1;
            details.EditEnabled = hasSingleItemSelected && selectedItems.First().Status != FormStatus.Cancelled;
            details.EmailEnabled = hasSingleItemSelected && (selectedItems[0].Status != FormStatus.Cancelled);
            details.DeleteVisible = false;
            // re-using the close button for cancel
            details.CloseButtonVisible = true;
            details.CancelEnabled = selectedItems.Count > 0 &&
                                    !selectedItems.Exists(dto => dto.Status == FormStatus.Cancelled);
        }

        protected override EdmontonFormType FormTypeToQuery()
        {
            return EdmontonFormType.Overtime;
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_OvertimeForm; }
        }

        protected override void Update(OvertimeForm form)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.UpdateOvertimeForm, form);
        }

        protected override IForm CreateEditForm(OvertimeForm form)
        {
            FormOvertimeFormPresenter presenter = new FormOvertimeFormPresenter(form);
            return presenter.View;
        }
    }
}