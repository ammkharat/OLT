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
    public class EdmontonGN75AFormContext : AbstractEdmontonFormContext<FormEdmontonGN75ADTO, FormGN75A, FormEdmontonGN75ADetails>
    {
        private readonly IWorkPermitEdmontonService workPermitEdmontonService;

        private readonly IReportPrintManager<FormGN75A> reportPrintManager;        
        private readonly IReportPrintManager<FormGN75B> gn75BReportPrintManager;        

        public EdmontonGN75AFormContext(IFormEdmontonService formService, IWorkPermitEdmontonService workPermitEdmontonService, AbstractMultiGridPage page) 
            : base(formService, page, EdmontonFormType.GN75A, new FormEdmontonGN75ADetails(), new FormEdmontonGN75AGridRenderer())
        {
            EdmontonGN75AFormPrintActions printActions = new EdmontonGN75AFormPrintActions(false, workPermitEdmontonService);
            reportPrintManager = new ReportPrintManager<FormGN75A, FormGN75AReport, FormGN75AReportAdapter>(printActions);

            EdmontonGN75BFormPrintActions printGn75BActions = new EdmontonGN75BFormPrintActions(formService, page);
            gn75BReportPrintManager = new ReportPrintManager<FormGN75B, FormGN75BReport, FormGN75BReportAdapter>(printGn75BActions);

            this.workPermitEdmontonService = workPermitEdmontonService;
        }

        protected override FormEdmontonGN75ADTO CreateDtoFromDomainObject(FormGN75A item)
        {
            return (FormEdmontonGN75ADTO) item.CreateDTO();
        }

        public override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerGN75AFormCreated += HandleRepeaterCreated;
            remoteEventRepeater.ServerGN75AFormUpdated += HandleRepeaterUpdated;
            remoteEventRepeater.ServerGN75AFormRemoved += HandleRepeaterRemoved;
        }

        public override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerGN75AFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerGN75AFormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerGN75AFormRemoved -= HandleRepeaterRemoved;
        }

        public override void ControlDetailButtons()
        {
            base.ControlDetailButtons();

            UserRoleElements userRoleElements = userContext.UserRoleElements;
            List<FormEdmontonGN75ADTO> selectedItems = GetSelectedItems();
            bool hasSingleItemSelected = selectedItems.Count == 1;

            details.DeleteEnabled = hasSingleItemSelected && authorized.ToDeleteForm(userRoleElements) && FormStatus.Draft.Equals(selectedItems[0].Status);
            details.EditEnabled = hasSingleItemSelected && authorized.ToEditFormGN75B(userRoleElements, selectedItems[0].Status);
        }

        public override void SubscribeToEvents()
        {
            base.SubscribeToEvents();
            details.ViewGN75B += HandleViewGN75BForm;
        }

        public override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            details.ViewGN75B -= HandleViewGN75BForm;
        }

        private void HandleViewGN75BForm()
        {
            FormGN75A selectedGN75A = QueryForFirstSelectedItem();

            if (selectedGN75A != null && selectedGN75A.AssociatedFormGN75BNumber.HasValue)
            {
                FormGN75B formGn75B = formService.QueryFormGN75BById(selectedGN75A.AssociatedFormGN75BNumber.Value);
                gn75BReportPrintManager.PreviewReport(formGn75B);
            }            
        }

        public override void SetDetailData(FormEdmontonGN75ADetails details, FormGN75A form)
        {
            if (form == null)
            {
                details.CreatedByUser = null;
                details.CreatedDateTime = null;
                details.LastModifiedByUser = null;
                details.LastModifiedDateTime = null;

                details.Content = null;
                details.FormNumber = null;
                details.ApprovedDateTime = null;
                details.ClosedDateTime = null;
                details.FunctionalLocation = null;
                details.ValidFromDateTime = null;
                details.ValidToDateTime = null;
                details.AssociatedGN75BFormNumber = null;
                details.Approvals = new List<FormApproval>();
                details.DocumentLinks = new List<DocumentLink>();                
                
                return;
            }

            details.CreatedByUser = form.CreatedBy;
            details.CreatedDateTime = form.CreatedDateTime;
            details.LastModifiedByUser = form.LastModifiedBy;
            details.LastModifiedDateTime = form.LastModifiedDateTime;

            details.Content = form.Content;
            details.FormNumber = form.FormNumber;
            details.ApprovedDateTime = form.ApprovedDateTime;
            details.ClosedDateTime = form.ClosedDateTime;
            details.FunctionalLocation = form.FunctionalLocation;
            details.ValidFromDateTime = form.FromDateTime;
            details.ValidToDateTime = form.ToDateTime;
            details.AssociatedGN75BFormNumber = form.AssociatedFormGN75BNumber;
            
            List<FormApproval> enabledApprovals = form.Approvals.FindAll(a => a.ShouldBeEnabled(form, Clock.Now));
            details.Approvals = enabledApprovals;

            details.DocumentLinks = form.DocumentLinks;

            details.WorkPermitEdmontonDTOs = workPermitEdmontonService.QueryDtosByFormGN75AId(form.IdValue);
        }

        protected override void Delete(FormGN75A item)
        {            
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formGn75A => formService.RemoveGN75A(formGn75A, userContext.User), item);
        }

        protected override void DeleteWithOkCancelDialog(string entityName)
        {
            List<FormEdmontonGN75ADTO> selectedDTOs = grid.SelectedItems;

            List<long> idsForSelectedItems = selectedDTOs.ConvertAll(dto => dto.IdValue);
            
            bool confirmed;

            // Going back to the DB is intentional here because the user might not have refreshed the current GN75A and the associated permits won't be marked as issued.
            if (formService.GN75AIsAssociatedToAnIssuedWorkPermit(idsForSelectedItems))
            {
                confirmed = page.ShowOKCancelDialog(string.Format(StringResources.DeleteFormWithAssociatedWorkPermitsWarning, entityName), string.Format(StringResources.DeleteItemDialogTitle, entityName));
            }
            else
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
            FormGN75A form = QueryForFirstSelectedItem();

            FormEdmontonGN75BDTO gn75BDto = null;

            if (form.AssociatedFormGN75BNumber != null)
            {
                gn75BDto = formService.QueryFormGN75BDTOById(form.AssociatedFormGN75BNumber.Value); 
            }
            
            form.ConvertToClone(ClientSession.GetUserContext().User, gn75BDto);

            FormGN75AFormPresenter presenter = new FormGN75AFormPresenter(form, true);
            IForm editForm = presenter.View;   
            
            if (editForm != null)
            {
                editForm.ShowDialog(page.ParentForm);
                editForm.Dispose();
            }
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(FormGN75A item)
        {
            return new EditFormGN75AHistoryFormPresenter(item);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.FormGN75A; }
        }

        protected override IReportPrintManager<FormGN75A> ReportPrintManager
        {
            get { return reportPrintManager; }
        }

        public override DialogResultAndOutput<FormGN75A> Edit(FormGN75A domainObject, IBaseForm view)
        {
            FormGN75AFormPresenter presenter = new FormGN75AFormPresenter(domainObject);
            return presenter.RunAndReturnTheEditObject(view);                        
        }

        public override DialogResultAndOutput<FormGN75A> CreateNew(IBaseForm view)
        {
            FormGN75AFormPresenter presenter = new FormGN75AFormPresenter();
            return presenter.RunAndReturnTheEditObject(view);            
        }

        //ayman generic forms
        public override FormGN75A QueryByIdAndSiteId(long id,long siteid)
        {
            return formService.QueryFormGN75AByIdAndSiteId(id,siteid);
        }

        public override FormGN75A QueryById(long id)
        {
            return formService.QueryFormGN75AById(id);
        }

        public override IList<FormEdmontonGN75ADTO> GetData(RootFlocSet flocSet, DateRange dateRange, List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange)
        {
            return formService.QueryFormGN75ADTOsByCriteria(flocSet, dateRange, formStatuses, includeAllDraftFormsRegardlessOfDateRange);
        }

        protected override EdmontonFormType FormTypeToQuery()
        {
            return EdmontonFormType.GN75A;
        }

        protected override string DomainObjectName
        {
           get { return StringResources.DomainObjectName_FormGN75A; }            
        }

        protected override void Update(FormGN75A form)
        {            
            //ayman generic forms include siteid 
            form.SiteId = ClientSession.GetUserContext().SiteId;

            LabelAttributes attributesForHazardsLabel = WorkPermitEdmontonReport.GetAttributesForHazardsLabel();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.UpdateGN75A, form, attributesForHazardsLabel);
        }

        protected override IForm CreateEditForm(FormGN75A theForm)
        {
            FormGN75AFormPresenter presenter = new FormGN75AFormPresenter(theForm);
            return presenter.View;            
        }
    }
}