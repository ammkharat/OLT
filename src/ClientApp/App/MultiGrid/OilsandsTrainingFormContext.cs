using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.MultiGrid
{
    public class OilsandsTrainingFormContext : MultiGridContext<FormOilsandsTrainingDTO, FormOilsandsTraining, FormOilsandsTrainingDetails>
    {
        private readonly IFormOilsandsService formService;
        private readonly IReportPrintManager<FormOilsandsTraining> reportPrintManager;

        public OilsandsTrainingFormContext(IFormOilsandsService formService, AbstractMultiGridPage page) :
            base(
                new DomainSummaryGrid<FormOilsandsTrainingDTO>(new FormOilsandsTrainingGridRenderer(), OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT, "formOilsandsTrainingGrid"), OilsandsFormType.Training, page, new FormOilsandsTrainingDetails(),
                new MultiGridContextDateFilter()
            )
        {          
            this.formService = formService;
            reportPrintManager = new ReportPrintManager<FormOilsandsTraining, FormOilsandsTrainingReport, FormOilsandsTrainingReportAdapter>(new FormOilsandsTrainingPrintActions());
        }
        
        public override bool IsItemSelected
        {
            get { return grid.SelectedItem != null; }
        }

        public override void ControlDetailButtons()
        {
            UserRoleElements userRoleElements = userContext.UserRoleElements;
            List<FormOilsandsTrainingDTO> selectedItems = grid.SelectedItems;
            bool hasSingleItemSelected = selectedItems.Count == 1;
            bool hasItemsSelected = selectedItems.Count >= 1;
            
            details.DeleteEnabled = hasSingleItemSelected && authorized.ToDeleteOilsandsTrainingForm(userContext, selectedItems[0]) && FormStatus.Draft.Equals(selectedItems[0].Status);
            details.EditEnabled = hasSingleItemSelected && authorized.ToEditForm(userContext, selectedItems[0]);
            details.ViewEditHistoryEnabled = hasSingleItemSelected;
            details.CloneEnabled = hasSingleItemSelected && authorized.ToCreateForms(userRoleElements,ClientSession.GetUserContext().Site);
            details.EmailEnabled = hasSingleItemSelected && FormStatus.Draft.Equals(selectedItems[0].Status);
            details.PrintEnabled = hasItemsSelected;
            details.PrintPreviewEnabled = hasSingleItemSelected;
        }

        protected override IList<FormOilsandsTrainingDTO> GetData(DtoFilters filters)
        {
            List<FormOilsandsTrainingDTO> dtos = formService.QueryFormOilsandsTrainingsByFunctionalLocationsAndDateRange(userContext.RootFlocSet, new DateRange(filters.Range));
            return dtos;
        }

        protected override FormOilsandsTrainingDTO CreateDtoFromDomainObject(FormOilsandsTraining item)
        {
            return new FormOilsandsTrainingDTO(item);
        }

        public override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerFormOilsandsTrainingCreated += HandleRepeaterCreated;
            remoteEventRepeater.ServerFormOilsandsTrainingUpdated += HandleRepeaterUpdated;
            remoteEventRepeater.ServerFormOilsandsTrainingRemoved += HandleRepeaterRemoved;
        }

        public override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerFormOilsandsTrainingCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerFormOilsandsTrainingUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerFormOilsandsTrainingRemoved -= HandleRepeaterRemoved;
        }

        private void HandleRepeaterCreated(object sender, DomainEventArgs<FormOilsandsTraining> e)
        {
            if (page != null && !page.IsDisposed)
            {
                page.Invoke(new Action<FormOilsandsTraining>(ItemCreated), new object[] { e.SelectedItem });
            }                        
        }

        private void HandleRepeaterUpdated(object sender, DomainEventArgs<FormOilsandsTraining> e)
        {
            if (page != null && !page.IsDisposed)
            {
                page.Invoke(new Action<FormOilsandsTraining>(ItemUpdated), new object[] { e.SelectedItem });
            }
        }

        private void HandleRepeaterRemoved(object sender, DomainEventArgs<FormOilsandsTraining> e)
        {
            if (page != null && !page.IsDisposed)
            {
                page.Invoke(new Action<FormOilsandsTraining>(ItemRemoved), new object[] { e.SelectedItem });
            }
        }

        protected override bool IsCreatedByCurrentUser(FormOilsandsTrainingDTO dto, User currentUser)
        {
            return dto.CreatedByUserId == currentUser.IdValue;
        }

        public override void SetDetailData(FormOilsandsTrainingDetails details, FormOilsandsTraining item)
        {
            details.SetDetails(item);
        }

        public override FormOilsandsTraining QueryById(long id)
        {
            return formService.QueryFormOilsandsTrainingById(id);
        }

        //ayman generic forms
        public override FormOilsandsTraining QueryByIdAndSiteId(long id,long siteid)
        {
            return formService.QueryFormOilsandsTrainingByIdAndSiteId(id,siteid);
        }

        public override void SubscribeToEvents()
        {
            base.SubscribeToEvents();

            details.Delete += HandleDelete;
            details.Edit += HandleEdit;
            details.ViewEditHistory += HandleViewEditHistory;
            details.Clone += HandleClone;
            details.Print += HandlePrint;
            details.Preview += HandlePreview;
            details.Email += HandleEmail;
        }

        public override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();

            details.Delete -= HandleDelete;
            details.Edit -= HandleEdit;
            details.ViewEditHistory -= HandleViewEditHistory;
            details.Clone -= HandleClone;
            details.Print -= HandlePrint;
            details.Preview -= HandlePreview;
            details.Email -= HandleEmail;
        }

        private void HandleEdit(object sender, EventArgs e)
        {
            FormOilsandsTraining itemToEdit = QueryById(FirstSelectedItem.IdValue);
            PagePresenterHelper.LockDatabaseObjectWhileInUse(Edit, itemToEdit, itemToEdit.ObjectIdentifier, LockType.Edit, userContext.User, objectLockingService);
        }

        private void HandleClone(object sender, EventArgs e)
        {
            FormOilsandsTraining form = QueryForFirstSelectedItem();
            form.ConvertToClone(ClientSession.GetUserContext().User, Clock.Now);

            IForm editForm = CreateEditForm(form);

            if (editForm != null)
            {
                editForm.ShowDialog(page.ParentForm);
                editForm.Dispose();
            }
        }

        private void HandleEmail(object sender, EventArgs e)
        {
            FormOilsandsTrainingFormPresenter.ShowEmail(FirstSelectedItem.IdValue);
        }

        private void HandlePrint(object sender, EventArgs e)
        {
            PrintWithDialogFocus(Print);
        }

        private void Print()
        {
            reportPrintManager.PrintReport(QueryDomainObjectListFromDtos(GetSelectedItems()).ConvertAll(i => i));
        }

        private void HandlePreview(object sender, EventArgs e)
        {
            reportPrintManager.PreviewReport(QueryForFirstSelectedItem());
        }

        private void HandleViewEditHistory(object sender, EventArgs e)
        {
           LaunchEditHistoryForm();            
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(FormOilsandsTraining item)
        {
            return new EditFormOilsandsTrainingHistoryFormPresenter(item);
        }

        protected override void Edit(FormOilsandsTraining item)
        {
            IForm form = CreateEditForm(item);
            if (form != null)
            {
                form.ShowDialog(page.ParentForm);
                form.Dispose();
            }            
        }

        protected override IForm CreateEditForm(FormOilsandsTraining item)
        {
            return new FormOilsandsTrainingFormPresenter(item).View;
        }

        private void HandleDelete(object sender, EventArgs e)
        {
            DeleteWithOkCancelDialog(StringResources.DomainObjectName_OilsandsTrainingForm);   
        }

        protected override void Delete(FormOilsandsTraining item)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.RemoveFormOilsandsTraining, item);            
        }

        protected override bool ItemIsInGrid(FormOilsandsTrainingDTO item)
        {
            return grid.FindItem(item.Id) != null;
        }

        protected override bool IsUpdatedByCurrentUser(FormOilsandsTrainingDTO item)
        {
            if (item == null)
            {
                return false;
            }

            return item.LastModifiedByUserId == ClientSession.GetUserContext().User.Id;
        }

        public override void MakeAllDetailsButtonsInvisible()
        {
            details.MakeAllButtonsInvisible();
        }

        public override Range<Date> GetDefaultDateRange()
        {
            Date now = Clock.DateNow;
            Date from = now.AddDays(-1 * userContext.SiteConfiguration.DaysToDisplayFormsBackwards);
            Date to = userContext.SiteConfiguration.DaysToDisplayFormsForwards == null ? null : now.AddDays(userContext.SiteConfiguration.DaysToDisplayFormsForwards.Value);

            return new Range<Date>(from, to);
        }

        protected override bool IsItemInDateRange(FormOilsandsTraining item, Range<Date> range)
        {
            DateRange theRange = new DateRange(range);
            return theRange.Overlaps(item.FromDate, item.ToDate);
        }

        protected override bool IsItemInStateThatAlwaysRequiresShowing(FormOilsandsTraining item)
        {
            return item.CreatedBy.Id == userContext.User.Id;
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.OilsandsTrainingForms; }
        }
    }
}