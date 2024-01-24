using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.MultiGrid
{
    public abstract class AbstractEdmontonFormContext<TDto, TBaseEdmontonForm, TDetails> :
        MultiGridContext<TDto, TBaseEdmontonForm, TDetails>
        where TDto : DomainObject, IFormEdmontonDTO
        where TBaseEdmontonForm : DomainObject, IEdmontonForm
        where TDetails : class, IFormEdmontonDetails
    {
        protected readonly IFormEdmontonService formService;

        protected AbstractEdmontonFormContext(IFormEdmontonService service, AbstractMultiGridPage page,
            EdmontonFormType formType,
            TDetails details, IGridRenderer gridRenderer, IMultiGridContextFilter filter) :
                base(
                new DomainSummaryGrid<TDto>(gridRenderer, OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT,
                    "edmontonForm" + formType.Name), formType, page, details, filter)
        {
            formService = service;
        }

        protected AbstractEdmontonFormContext(IFormEdmontonService service, AbstractMultiGridPage page,
            EdmontonFormType formType,
            TDetails details, IGridRenderer gridRenderer) :
                this(service, page, formType, details, gridRenderer, new MultiGridContextDateFilter())
        {
        }
        
        protected abstract override UserGridLayoutIdentifier GridIdentifier { get; }
        protected abstract IReportPrintManager<TBaseEdmontonForm> ReportPrintManager { get; }

        public abstract DialogResultAndOutput<TBaseEdmontonForm> Edit(TBaseEdmontonForm domainObject, IBaseForm view);
        public abstract DialogResultAndOutput<TBaseEdmontonForm> CreateNew(IBaseForm view);

        //ayman generic forms  override
        public abstract override  TBaseEdmontonForm QueryByIdAndSiteId(long id,long siteid);

        public abstract override TBaseEdmontonForm QueryById(long id);

        public abstract IList<TDto> GetData(RootFlocSet flocSet, DateRange dateRange, List<FormStatus> formStatuses,
            bool includeAllDraftFormsRegardlessOfDateRange);

        protected abstract EdmontonFormType FormTypeToQuery();

        protected abstract string DomainObjectName { get; }
        protected abstract void Update(TBaseEdmontonForm form);

        public override bool IsItemSelected
        {
            get { return grid.SelectedItem != null; }
        }

        protected override bool IsItemInStateThatAlwaysRequiresShowing(TBaseEdmontonForm item)
        {
            return item.FormStatus == FormStatus.Draft || item.LastModifiedBy.Id == userContext.User.Id;
        }

        protected override bool IsItemInDateRange(TBaseEdmontonForm item, Range<Date> dateRange)
        {
            DateRange theRange = new DateRange(dateRange);
            return theRange.Overlaps(item.FromDateTime, item.ToDateTime);
        }

        public override void ControlDetailButtons()
        {
            UserRoleElements userRoleElements = userContext.UserRoleElements;
            List<TDto> selectedItems = GetSelectedItems();
            bool hasSingleItemSelected = selectedItems.Count == 1;
            bool hasItemsSelected = selectedItems.Count > 0;

            details.DeleteEnabled = hasSingleItemSelected && authorized.ToDeleteForm(userRoleElements) &&
                                    (FormStatus.Draft.Equals(selectedItems[0].Status) ||
                                    FormStatus.WaitingForApproval.Equals(selectedItems[0].Status)) //DMND0010815 : Added By Vibhor - Sarnia Issues for CSD, EIP forms
                                    ;

            details.ViewEditHistoryEnabled = hasSingleItemSelected;
            details.CloneEnabled = hasSingleItemSelected && authorized.ToCreateForms(userRoleElements, ClientSession.GetUserContext().Site);
            details.CloseEnabled = hasItemsSelected && authorized.ToEditForm(userRoleElements) &&
                                   selectedItems.TrueForAll(
                                       item =>
                                           FormStatus.Draft.Equals(item.Status) ||
                                           FormStatus.Approved.Equals(item.Status) ||
                                           FormStatus.Expired.Equals(item.Status)  || 
                                           FormStatus.WaitingForApproval.Equals(item.Status));  //ayman close button enable/disable
            details.PrintEnabled = hasItemsSelected;
            details.PrintPreviewEnabled = hasSingleItemSelected;
            details.EmailEnabled = hasSingleItemSelected &&
                                   !selectedItems[0].Status.IsOneOf(FormStatus.Approved, FormStatus.Closed);
        }

        protected virtual void HandleRepeaterCreated(object sender, DomainEventArgs<TBaseEdmontonForm> e)
        {
            if (page != null && !page.IsDisposed)
            {
                page.Invoke(new Action<TBaseEdmontonForm>(ItemCreated), new object[] {e.SelectedItem});
            }
        }

        //ayman Sarnia eip DMND0008992
        protected virtual void HandleEipIssueRepeaterUpdated(object sender, DomainEventArgs<TBaseEdmontonForm> e)
        {
            if (page != null && !page.IsDisposed)
            {
                page.Invoke(new Action<TBaseEdmontonForm>(ItemUpdated), new object[] { e.SelectedItem });
            }
        }

        protected virtual void HandleRepeaterUpdated(object sender, DomainEventArgs<TBaseEdmontonForm> e)
        {
            if (page != null && !page.IsDisposed)
            {
                page.Invoke(new Action<TBaseEdmontonForm>(ItemUpdated), new object[] {e.SelectedItem});
            }
        }

        protected virtual void HandleRepeaterRemoved(object sender, DomainEventArgs<TBaseEdmontonForm> e)
        {
            if (page != null && !page.IsDisposed)
            {
                page.Invoke(new Action<TBaseEdmontonForm>(ItemRemoved), new object[] {e.SelectedItem});
            }
        }

        protected override IList<TDto> GetData(DtoFilters filters)
        {
            RootFlocSet rootFlocSet;

            if (userContext.SiteConfiguration.FormsFlocSetType.Equals(FunctionalLocationSetType.WorkPermit) &&
                userContext.HasFlocsForWorkPermits)
            {
                rootFlocSet = userContext.RootFlocSetForWorkPermits;
            }
            else
            {
                rootFlocSet = userContext.RootFlocSet;
            }

            IList<TDto> queryResult = GetData(rootFlocSet, new DateRange(filters.Range), filters.FormStatus, true);

            return queryResult;
        }


        protected override bool IsCreatedByCurrentUser(TDto dto, User currentUser)
        {
            TDto formDto = dto;
            return formDto.CreatedByUserId == currentUser.IdValue;
        }

        public override void SubscribeToEvents()
        {
            base.SubscribeToEvents();

            details.Delete += HandleDelete;
            details.Edit += HandleEdit;
            details.ViewEditHistory += HandleViewEditHistory;
            details.Clone += HandleClone;
            details.Print += HandlePrint;
            details.PrintPreview += HandlePreview;
            details.Email += HandleEmail;
            details.Close += HandleClose;
            details.Cancel += HandleCancel;
            /*RITM0265746 - Sarnia CSD marked as read start*/
            details.MarkAsRead += HandleMarkAsRead;
            details.MarkedAsReadByToggled += HandleMarkedAsReadByToggled;
            /*RITM0265746 - Sarnia CSD marked as read end*/
        }

        public override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();

            details.Delete -= HandleDelete;
            details.Edit -= HandleEdit;
            details.ViewEditHistory -= HandleViewEditHistory;
            details.Clone -= HandleClone;
            details.Print -= HandlePrint;
            details.PrintPreview -= HandlePreview;
            details.Email -= HandleEmail;
            details.Cancel -= HandleCancel;
            details.Close -= HandleClose;
            /*RITM0265746 - Sarnia CSD marked as read start*/
            details.MarkAsRead -= HandleMarkAsRead;
            details.MarkedAsReadByToggled -= HandleMarkedAsReadByToggled;
            /*RITM0265746 - Sarnia CSD marked as read end*/
        }
        
        private void HandleEdit(object sender, EventArgs e)
        {
            //ayman generic forms testing to change queryById to QueryByIdAndSiteId

            TBaseEdmontonForm itemToEdit = QueryByIdAndSiteId(FirstSelectedItem.IdValue, ClientSession.GetUserContext().SiteId);
            if (itemToEdit != null)           //ayman Sarnia eip - 3
            {
                PagePresenterHelper.LockDatabaseObjectWhileInUse(Edit, itemToEdit, itemToEdit.ObjectIdentifier,
                    LockType.Edit, userContext.User, objectLockingService);
            }
        }

   
        protected virtual void HandleClone()
        {
            TBaseEdmontonForm form = QueryForFirstSelectedItem();
            form.ConvertToClone(ClientSession.GetUserContext().User);

            IForm editForm = CreateEditForm(form);

            if (editForm != null)
            {
                editForm.ShowDialog(page.ParentForm);
                editForm.Dispose();
            }
        }

        private void HandleEmail()
        {
            string formTypeName = FormTypeToQuery().Name;

            IFormEdmontonDTO formDto = FirstSelectedItem;
            long formNumber = formDto.FormNumber;

            FormEdmontonPagePresenterHelper.ShowEmail(formTypeName, formNumber);
        }

        private void HandlePrint(object sender, EventArgs e)
        {
            PrintWithDialogFocus(Print);
        }

        private void Print()
        {
            List<TBaseEdmontonForm> domainObjectList = QueryDomainObjectListFromDtos(GetSelectedItems());
            PagePresenterHelper.LockMultipleDomainObjects(ReportPrintManager.PrintReport, domainObjectList,
                LockType.Print, userContext.User, objectLockingService);
        }

        private void HandlePreview()
        {
            TBaseEdmontonForm itemToPreview = QueryForFirstSelectedItem();
            PagePresenterHelper.LockDatabaseObjectWhileInUse(ReportPrintManager.PreviewReport, itemToPreview,
                itemToPreview.ObjectIdentifier, LockType.Preview, userContext.User, objectLockingService);
        }

        private void HandleViewEditHistory(object sender, EventArgs e)
        {
            LaunchEditHistoryForm();
        }

        protected virtual bool HandleCancel()
        {
            DialogResult dialogResult = OltMessageBox.Show(StringResources.CancelFormDialogText, MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                List<TBaseEdmontonForm> domainObjectList = QueryDomainObjectListFromDtos(GetSelectedItems());
                LockMultipleDomainObjects(Close, domainObjectList, CancelSuccessfulMessage);
                return true;
            }

            return false;
        }

        protected virtual bool HandleClose()
        {
            DialogResult dialogResult = OltMessageBox.Show(StringResources.CloseFormDialogText, MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                List<TBaseEdmontonForm> domainObjectList = QueryDomainObjectListFromDtos(GetSelectedItems());
                LockMultipleDomainObjects(Close, domainObjectList, CloseSuccessfulMessage);
                return true;
            }

            return false;
        }

        private void Close(TBaseEdmontonForm form)
        {
            DateTime now = Clock.Now;
            form.MarkAsClosed(now, ClientSession.GetUserContext().User);
            Update(form);
        }

        private void CloseSuccessfulMessage()
        {
            OltMessageBox.Show(Form.ActiveForm, StringResources.CloseSuccessfulMessage,
                StringResources.CloseSuccessfulTitle, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        private void CancelSuccessfulMessage()
        {
            OltMessageBox.Show(Form.ActiveForm, StringResources.CancelSuccessfulMessage,
                StringResources.CancelSuccessfulTitle, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        protected override void Edit(TBaseEdmontonForm item)
        {
            IForm form = CreateEditForm(item);
            if (form != null)
            {
                form.ShowDialog(page.ParentForm);
                form.Dispose();
            }
        }

    

        private void HandleDelete(object sender, EventArgs e)
        {
            DeleteWithOkCancelDialog(DomainObjectName);
        }

        protected override bool ItemIsInGrid(TDto item)
        {
            return grid.FindItem(item.Id) != null;
        }

        protected override bool IsUpdatedByCurrentUser(TDto item)
        {
            if (item == null)
            {
                return false;
            }

            return (item.LastModifiedByUserId == ClientSession.GetUserContext().User.Id);
        }

        public override void MakeAllDetailsButtonsInvisible()
        {
            details.MakeAllButtonsInvisible();
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

        /*RITM0265746 - Sarnia CSD marked as read start*/

        protected virtual void InsertMarkAsReadFormOp14(long id, long userid, DateTime sitetimeDateTime, long shiftId)
        {
        }

        protected virtual void HandleMarkedAsReadByToggled(long id)
        {

        }

        /*RITM0265746 - Sarnia CSD marked as read start*/
        private void HandleMarkedAsReadByToggled()
        {
            HandleMarkedAsReadByToggled(FirstSelectedItem.IdValue);
            //PagePresenterHelper.LockDatabaseObjectWhileInUse(Edit, itemToEdit, itemToEdit.ObjectIdentifier,
            //    LockType.Edit, userContext.User, objectLockingService);
        }
        private void HandleMarkAsRead()
        {
            long ShiftId = Convert.ToInt64(ClientSession.GetUserContext().UserShift.ShiftPatternId);
            InsertMarkAsReadFormOp14(FirstSelectedItem.IdValue, Convert.ToInt64(ClientSession.GetUserContext().User.Id.Value), Clock.Now, ShiftId);
            details.MarkAsReadEnabled = false;
            //PagePresenterHelper.LockDatabaseObjectWhileInUse(Edit, itemToEdit, itemToEdit.ObjectIdentifier,
            //    LockType.Edit, userContext.User, objectLockingService);
        }
        /*RITM0265746 - Sarnia CSD marked as read end*/
       
    }
}