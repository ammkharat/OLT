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

namespace Com.Suncor.Olt.Client.MultiGrid
{
    public class EdmontonGN1FormContext : AbstractEdmontonFormContext<FormEdmontonGN1DTO, FormGN1, FormEdmontonGN1Details>
    {
        private readonly IWorkPermitEdmontonService workPermitEdmontonService;

        private readonly IReportPrintManager<FormGN1> reportPrintManager;                

        public EdmontonGN1FormContext(IFormEdmontonService formService, IWorkPermitEdmontonService workPermitEdmontonService, AbstractMultiGridPage page) 
            : base(formService, page, EdmontonFormType.GN1, new FormEdmontonGN1Details(), new FormEdmontonGN1GridRenderer())
        {            
            EdmontonGN1FormPrintActions printActions = new EdmontonGN1FormPrintActions(false, formService);
            reportPrintManager = new ReportPrintManager<FormGN1, FormGN1Report, Olt.Reports.Adapters.FormGN1ReportAdapter>(printActions);
            
            this.workPermitEdmontonService = workPermitEdmontonService;
        }

        protected override FormEdmontonGN1DTO CreateDtoFromDomainObject(FormGN1 item)
        {
            return (FormEdmontonGN1DTO) item.CreateDTO();
        }

        public override void SubscribeToEvents()
        {
            base.SubscribeToEvents();
            details.ViewTradeChecklist += HandleViewTradeChecklist;
        }

        public override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            details.ViewTradeChecklist -= HandleViewTradeChecklist;
        }

        private void HandleViewTradeChecklist(TradeChecklist selectedTradeChecklist)
        {
            EdmontonGN1FormSingleTradeChecklistPrintActions checklistPrintActions = new EdmontonGN1FormSingleTradeChecklistPrintActions(selectedTradeChecklist);
            IReportPrintManager<FormGN1> tradeChecklistReportPrintManager =
                new ReportPrintManager<FormGN1, FormGN1SingleTradeChecklistReport, Olt.Reports.Adapters.FormGN1TradeChecklistReportAdapter>(checklistPrintActions);
            tradeChecklistReportPrintManager.PreviewReport(QueryForFirstSelectedItem());
        }

        public override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerGN1FormCreated += HandleRepeaterCreated;
            remoteEventRepeater.ServerGN1FormUpdated += HandleRepeaterUpdated;
            remoteEventRepeater.ServerGN1FormRemoved += HandleRepeaterRemoved;
        }

        public override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerGN1FormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerGN1FormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerGN1FormRemoved -= HandleRepeaterRemoved;
        }

        public override void ControlDetailButtons()
        {
            base.ControlDetailButtons();

            UserRoleElements userRoleElements = userContext.UserRoleElements;
            List<FormEdmontonGN1DTO> selectedItems = GetSelectedItems();
            bool hasSingleItemSelected = selectedItems.Count == 1;

            details.DeleteEnabled = hasSingleItemSelected && authorized.ToDeleteForm(userRoleElements) && FormStatus.Draft.Equals(selectedItems[0].Status);
            details.EditEnabled = hasSingleItemSelected && authorized.ToEditFormGN1(userRoleElements, selectedItems[0].Status);
        }

        public override void SetDetailData(FormEdmontonGN1Details details, FormGN1 form)
        {
            if (form == null)
            {
                details.ClearDetails();                
                return;
            }
            
            details.CreatedByUser = form.CreatedBy;
            details.CreatedDateTime = form.CreatedDateTime;

            details.LastModifiedByUser = form.LastModifiedBy;
            details.LastModifiedDateTime = form.LastModifiedDateTime;

            details.FormNumber = form.FormNumber;
            details.ApprovedDateTime = form.ApprovedDateTime;
            details.ClosedDateTime = form.ClosedDateTime;
            details.FunctionalLocation = form.FunctionalLocation;
            details.FormLocation = form.Location;
            details.ValidFromDateTime = form.FromDateTime;
            details.ValidToDateTime = form.ToDateTime;
            details.CSELevel = form.CSELevel;
            details.JobDescription = form.JobDescription;
            details.PlanningWorksheetContent = form.PlanningWorksheetContent;
            details.PlanningWorksheetApprovals = form.EnabledPlanningWorksheetApprovals;
            details.SetTradeChecklists(form.TradeChecklists, form.CSELevel);
            details.RescuePlanContent = form.RescuePlanContent;
            details.RescuePlanApprovals = form.RescuePlanApprovals;
            details.DocumentLinks = form.DocumentLinks;

            details.WorkPermitEdmontonDTOs = workPermitEdmontonService.QueryDtosByFormGN1Id(form.IdValue);            
        }

        protected override void Delete(FormGN1 item)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formGN1 => formService.RemoveGN1(formGN1, userContext.User), item);
        }

        protected override void DeleteWithOkCancelDialog(string entityName)
        {
            List<FormEdmontonGN1DTO> selectedDTOs = grid.SelectedItems;

            List<long> idsForSelectedItems = selectedDTOs.ConvertAll(dto => dto.IdValue);
            
            bool confirmed;

            // Going back to the DB is intentional here because the user might not have refreshed the current GN75A and the associated permits won't be marked as issued.
            // TODO
            //if (formService.GN75AIsAssociatedToAnIssuedWorkPermit(idsForSelectedItems))
            //{
            //    confirmed = page.ShowOKCancelDialog(string.Format(StringResources.DeleteFormWithAssociatedWorkPermitsWarning, entityName), string.Format(StringResources.DeleteItemDialogTitle, entityName));
            //}
            //else
            {
                confirmed = ShowOKCancelDialogForDelete(entityName);
            }

            if (confirmed)
            {
                LockAndDeleteSelectedItems();
            }
        }

        protected override void HandleClone()
        {
            FormGN1 form = QueryForFirstSelectedItem();
            
            form.ConvertToClone(ClientSession.GetUserContext().User);

            FormGN1FormPresenter presenter = new FormGN1FormPresenter(form, true);
            IForm editForm = presenter.View;   
            
            if (editForm != null)
            {
                editForm.ShowDialog(page.ParentForm);
                editForm.Dispose();
            }
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(FormGN1 item)
        {          
            return new EditFormGN1HistoryFormPresenter(item);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.FormGN1; }
        }

        protected override IReportPrintManager<FormGN1> ReportPrintManager
        {
            get { return reportPrintManager; }
        }

        public override DialogResultAndOutput<FormGN1> Edit(FormGN1 domainObject, IBaseForm view)
        {
            FormGN1FormPresenter presenter = new FormGN1FormPresenter(domainObject);
            return presenter.RunAndReturnTheEditObject(view);                        
        }

        public override DialogResultAndOutput<FormGN1> CreateNew(IBaseForm view)
        {
            FormGN1FormPresenter presenter = new FormGN1FormPresenter();
            return presenter.RunAndReturnTheEditObject(view);            
        }

        
        //ayman generic forms
        public override FormGN1 QueryByIdAndSiteId(long id,long siteid)
        {
            return formService.QueryFormGN1ByIdAndSiteId(id,siteid);
        }
        
        public override FormGN1 QueryById(long id)
        {
            return formService.QueryFormGN1ById(id);
        }

        public override IList<FormEdmontonGN1DTO> GetData(RootFlocSet flocSet, DateRange dateRange, List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange)
        {
            return formService.QueryFormGN1DTOsByCriteria(flocSet, dateRange, formStatuses, includeAllDraftFormsRegardlessOfDateRange);
        }

        protected override EdmontonFormType FormTypeToQuery()
        {
            return EdmontonFormType.GN1;
        }

        protected override string DomainObjectName
        {
           get { return StringResources.DomainObjectName_FormGN1; }            
        }

        protected override void Update(FormGN1 form)
        {            
            //ayman generic forms include siteid 
            form.SiteId = ClientSession.GetUserContext().SiteId;  

            LabelAttributes attributesForHazardsLabel = WorkPermitEdmontonReport.GetAttributesForHazardsLabel();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification((formGn1, tradeChecklistRemovalList, labelAttributes) => formService.UpdateGN1(formGn1, labelAttributes), form, new List<TradeChecklist>(), attributesForHazardsLabel);
        }

        protected override IForm CreateEditForm(FormGN1 theForm)
        {
            FormGN1FormPresenter presenter = new FormGN1FormPresenter(theForm);
            return presenter.View;            
        }
    }
}