using System.Collections.Generic;
using System.Windows.Forms;
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
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using log4net;

namespace Com.Suncor.Olt.Client.MultiGrid
{
    public class PermitAssessmentFormContext :
        AbstractEdmontonFormContext<PermitAssessmentDTO, PermitAssessment, FormPermitAssessmentDetails>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (PermitAssessmentFormContext));
        private readonly IReportPrintManager<PermitAssessment> reportPrintManager;
        private readonly WindowsFormsSynchronizationContext synchronizationContext;

        public PermitAssessmentFormContext(IFormEdmontonService formService, AbstractMultiGridPage page)
            : base(
                formService, page, EdmontonFormType.OilsandsPermitAssessment, new FormPermitAssessmentDetails(),
                new PermitAssessmentGridRenderer())
        {
            PrintActions
                <PermitAssessment, SafeWorkPermitAuditQuestionnaireReport, SafeWorkPermitAuditQuestionnaireReportAdapter
                    >
                printActions =
                    new SafeWorkPermitAuditQuestionnaireReportPrintActions();
            reportPrintManager =
                new ReportPrintManager
                    <PermitAssessment, SafeWorkPermitAuditQuestionnaireReport,
                        SafeWorkPermitAuditQuestionnaireReportAdapter>(
                    printActions);
        }

        public override bool IsItemSelected
        {
            get { return grid.SelectedItem != null; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_OilsandsPermitAssessmentForm; }
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.PermitAssessment; }
        }

        protected override IReportPrintManager<PermitAssessment> ReportPrintManager
        {
            get { return reportPrintManager; }
        }


        protected override PermitAssessmentDTO CreateDtoFromDomainObject(PermitAssessment item)
        {
            return (PermitAssessmentDTO) item.CreateDTO();
        }

        public override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerOilsandsPermitAssessmentFormCreated += HandleRepeaterCreated;
            remoteEventRepeater.ServerOilsandsPermitAssessmentFormUpdated += HandleRepeaterUpdated;
            remoteEventRepeater.ServerOilsandsPermitAssessmentFormRemoved += HandleRepeaterRemoved;
        }


        public override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerOilsandsPermitAssessmentFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerOilsandsPermitAssessmentFormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerOilsandsPermitAssessmentFormRemoved -= HandleRepeaterRemoved;
        }


        public override void SetDetailData(FormPermitAssessmentDetails details, PermitAssessment form)
        {
            details.CreatedByUser = form.CreatedBy;
            details.CreatedDateTime = form.CreatedDateTime;

            details.LastModifiedByUser = form.LastModifiedBy;
            details.LastModifiedDateTime = form.LastModifiedDateTime;

            details.FormNumber = form.FormNumber;

            details.FunctionalLocations = form.FunctionalLocations;
            details.ValidFromDateTime = form.FromDateTime;
            details.ValidToDateTime = form.ToDateTime;

            details.DocumentLinks = form.DocumentLinks;

            details.LocationEquipmentNumber = form.LocationEquipmentNumber;
            details.IsIlpRecommended = form.IsIlpRecommended;

            details.PermitNumber = form.PermitNumber;
            details.PermitType = form.OilsandsWorkPermitType.Name;
            details.CrewSize = form.CrewSize;
            details.JobDescription = form.JobDescription;
            details.IssuedToSuncor = form.IssuedToSuncor;
            details.IssuedToContractor = form.IssuedToContractor;
            details.ContractorName = form.Contractor;
            details.TradeName = form.Trade;
            details.JobCoordinator = form.JobCoordinator;

            details.QuestionnaireName = form.QuestionnaireName;
            details.QuestionnaireVersion = form.QuestionnaireVersion;

            details.PermitAssessment = form;
        }

        public override void ControlDetailButtons()
        {
            base.ControlDetailButtons();
            var selectedItems = GetSelectedItems();
            var hasSingleItemSelected = selectedItems.Count == 1;
            var userRoleElements = userContext.UserRoleElements;

            details.DeleteVisible = false;
            details.EmailButtonVisible = false;

            // re-using the close button for cancel
            details.CloseButtonVisible = true;

            details.EditEnabled = hasSingleItemSelected &&
                                  authorized.ToEditPermitAssessment(userRoleElements, selectedItems[0], userContext.User,
                                      userContext.UserShift);

            details.CancelEnabled = hasSingleItemSelected &&
                                    authorized.ToCancelPermitAssessment(userRoleElements, userContext.User,
                                        userContext.UserShift, selectedItems[0]);
        }

        public override IList<PermitAssessmentDTO> GetData(RootFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStatuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            return formService.QueryOilsandsPermitAssessmentDtos(flocSet, dateRange);
        }


        protected override EdmontonFormType FormTypeToQuery()
        {
            return EdmontonFormType.OilsandsPermitAssessment;
        }

        //ayman generic forms
        public override PermitAssessment QueryByIdAndSiteId(long id,long siteid)
        {
            return formService.QueryPermitAssessmentFormByIdAndSiteId(id,siteid);
        }
        
        public override PermitAssessment QueryById(long id)
        {
            return formService.QueryPermitAssessmentFormById(id);
        }

        protected override void Update(PermitAssessment form)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                formService.UpdateOilsandsPermitAssessmentForm, form);
        }

        protected override IForm CreateEditForm(PermitAssessment item)
        {
            var presenter = new PermitAssessmentFormPresenter(item);
            return presenter.View;
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(PermitAssessment item)
        {
            return new PermitAssessmentHistoryFormPresenter(item);
        }

        protected override void Delete(PermitAssessment item)
        {
//            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
//                formService.RemoveLubesAlarmDisable, item);
        }

        public override Range<Date> GetDefaultDateRange()
        {
            // todo, probably needs tweaking for permit assessment
            var now = Clock.DateNow;
            var from = now.AddDays(-1*userContext.SiteConfiguration.DaysToDisplayFormsBackwards);
            var to = userContext.SiteConfiguration.DaysToDisplayFormsForwards == null
                ? null
                : now.AddDays(userContext.SiteConfiguration.DaysToDisplayFormsForwards.Value);

            return new Range<Date>(from, to);
        }

        public override DialogResultAndOutput<PermitAssessment> Edit(PermitAssessment domainObject,
            IBaseForm view)
        {
            var presenter = new PermitAssessmentFormPresenter(domainObject);
            return presenter.RunAndReturnTheEditObject(view);
        }

        public override DialogResultAndOutput<PermitAssessment> CreateNew(IBaseForm view)
        {
            var presenter = new PermitAssessmentFormPresenter();
            return presenter.RunAndReturnTheEditObject(view);
        }
    }
}