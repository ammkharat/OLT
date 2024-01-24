using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using log4net;

namespace Com.Suncor.Olt.Client.MultiGrid
{
    public abstract class MultiGridContext<TDto, TDomainObject, TDetails> : IMultiGridContext
        where TDto : DomainObject
        where TDomainObject : DomainObject
        where TDetails : class, IDetails
    {
        protected readonly IAuthorized authorized;
        protected readonly TDetails details;
        protected readonly IMultiGridContextFilter filter;

        private long SiteId;   //ayman generic forms

        protected readonly DomainSummaryGrid<TDto> grid;
        private readonly IMultiGridContextSelection key;

        private readonly ILog logger = GenericLogManager.GetLogger<MultiGridContext<TDto, TDomainObject, TDetails>>();
        protected readonly IObjectLockingService objectLockingService;
        protected readonly AbstractMultiGridPage page;
        protected readonly UserContext userContext;
        private readonly IUserService userService;

        private bool isFirstTimeLoad = true;
        private List<TDto> itemsBeforeSearch;
        private string mostRecentSearchTerm;
        private static IFormGenericTemplateService service1;//Added by ppanigrahi
        private readonly IReportPrintManager<FormOP14> reportPrintManager;//Added by ppanigrahi
        private readonly IFormEdmontonService service;//Added by ppanigrahi

        protected MultiGridContext(DomainSummaryGrid<TDto> grid, IMultiGridContextSelection key,
            AbstractMultiGridPage page, TDetails details, IMultiGridContextFilter filter) :
                this(
                grid, key, page, details, ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
                ClientServiceRegistry.Instance.GetService<IUserService>(), filter)
        {
        }

        private MultiGridContext(DomainSummaryGrid<TDto> grid, IMultiGridContextSelection key,
            AbstractMultiGridPage page, TDetails details, IObjectLockingService objectLockingService,
            IUserService userService, IMultiGridContextFilter filter)
        {
            this.details = details;
            this.grid = grid;
            this.key = key;
            this.page = page;
            this.filter = filter;
            userContext = ClientSession.GetUserContext();
            this.objectLockingService = objectLockingService;
            this.userService = userService;
            authorized = new Authorized();
            SiteId = userContext.SiteId;       //ayman generic forms 
            service = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();
            service1 = ClientServiceRegistry.Instance.GetService<IFormGenericTemplateService>();
            PrintActions<FormOP14, FormOP14Report, FormOP14ReportAdapter> printActions = new FormOP14FormPrintActions();//Addedby ppanigrahi
            reportPrintManager = new ReportPrintManager<FormOP14, FormOP14Report, FormOP14ReportAdapter>(printActions);
        }

        private bool GridLayoutIsActive
        {
            get
            {
                return GridIdentifier != null &&
                       ClientSession.GetUserContext().GetGridLayoutXML(GridIdentifier.GridName) != null;
            }
        }





        private IList<TDto> Items
        {
            get { return new List<TDto>(grid.Items); }
            set { grid.Items = value.Count == 0 ? new List<TDto>() : new List<TDto>(value); }
        }

        protected TDto FirstSelectedItem
        {
            get { return grid.SelectedItems.Count > 0 ? grid.SelectedItems[0] : null; }
        }

        protected virtual UserGridLayoutIdentifier GridIdentifier
        {
            get { return null; }
        }

        public virtual void SubscribeToEvents()
        {
            grid.SelectedItemChanged += HandleSelectedItemChanged;
            grid.DoubleClickSelected += HandleDoubleClickSelected;
            details.ToggleShow += HandleToggleShow;
            details.SaveGridLayout += HandleSaveGridLayout;
            details.ExportAll += HandleExportAll;
        }

        public virtual void UnSubscribeFromEvents()
        {
            grid.SelectedItemChanged -= HandleSelectedItemChanged;
            grid.DoubleClickSelected -= HandleDoubleClickSelected;
            details.ToggleShow -= HandleToggleShow;
            details.SaveGridLayout -= HandleSaveGridLayout;
            details.ExportAll -= HandleExportAll;
        }

        public IMultiGridContextSelection Key
        {
            get { return key; }
        }

        public IDomainSummaryGrid Grid
        {
            get { return grid; }
        }

        public AbstractMultiGridPage Page
        {
            get { return page; }
        }

        public abstract bool IsItemSelected { get; }

        public void SetPageTitle()
        {
            filter.SetPageTitle(this);
        }

        IList<DomainObject> IMultiGridContext.Items
        {
            get { return Items.ConvertAll(x => (DomainObject) x); }
            set { Items = value.ConvertAll(x => (TDto) x); }
        }

        public IDetails Details
        {
            get { return details; }
        }

        List<DomainObject> IMultiGridContext.SelectedItems
        {
            get { return grid.SelectedItems.ConvertAll(i => (DomainObject) i); }
        }

        IList<DomainObject> IMultiGridContext.GetData(DtoFilters filters)
        {
            var domainObjects = GetData(filters);
            return domainObjects.ConvertAll(x => (DomainObject) x);
        }

        void IMultiGridContext.Edit(DomainObject item)
        {
            Edit(item as TDomainObject);
        }

        public bool DataNeedsRefresh { get; set; }

        public abstract void HookToServiceEvents(IRemoteEventRepeater repeater);

        public abstract void UnHookToServiceEvents(IRemoteEventRepeater repeater);


        //ayman generic forms
        DomainObject IMultiGridContext.QueryByIdAndSiteId(long id, long siteid)
        {
            var result = QueryByIdAndSiteId(id,siteid);
            return result;
        }
        
        DomainObject IMultiGridContext.QueryById(long id)
        {
            var result = QueryById(id);
            return result;
        }

        public void ControlShowingOfDetailsPane()
        {

            if (page.IsItemSelected())
            {
                SetDetailData(details, QueryForFirstSelectedItem());
                ShowDetails();
            }
            else
            {
                //ayman Sarnia eip - 3
                if (page.Items.Count > 0 && !page.IsItemSelected())
                {
                    grid.SelectFirstRow();
                    ShowDetails();
                }
                else
                {
                    HideDetails();
                }
            }
        }

        public long? SelectedDomainObjectId { get; set; }

        public string MostRecentSearchTerm
        {
            get { return mostRecentSearchTerm; }
        }

        public void ApplySearchTerm(string searchTerm, Action actionOnCancel)
        {
            if (searchTerm.IsNullOrEmptyOrWhitespace())
            {
                actionOnCancel();
                return;
            }

            mostRecentSearchTerm = searchTerm;

            if (itemsBeforeSearch == null)
            {
                itemsBeforeSearch = GetItems();
            }

            var foundItems = new List<TDto>();

            foreach (var item in itemsBeforeSearch)
            {
                if (item != null)
                {
                    if (item.ContainsSearchTerm(searchTerm))
                    {
                        foundItems.Add(item);
                    }
                }
            }

            Items = foundItems;
        }

        public abstract void ControlDetailButtons();

        public virtual Range<Date> GetDefaultDateRange()
        {
            return null;
        }

        public virtual FormStatus GetDefaultFormStatus()
        {
            return null;
        }

        public virtual void MakeAllDetailsButtonsInvisible()
        {
        }

        public void RefreshData(bool loadInForeground)
        {
            filter.RefreshData(this, loadInForeground);
        }

        public void RefreshData(IList<DomainObject> dtos)
        {
            SetPageTitle();

            var selectedIds = page.SelectedDTOs.AsIdList();

            page.Items = dtos;
            itemsBeforeSearch = dtos.ConvertAll(t => (TDto) t);
            ApplySearchTerm(mostRecentSearchTerm, ResetSearchBox);

            page.ClearSelectionsAndSelectItemsById(selectedIds);

            if (SelectedDomainObjectId.HasValue && !page.IsItemSelected() && page.Items.Count != 0)
            {
                page.SelectSingleItemById(SelectedDomainObjectId);
            }
            else if (!page.IsItemSelected() && page.Items.Count != 0)
            {
                page.SelectSingleItemByIndex(0);
            }

            if (isFirstTimeLoad)
            {
                LoadGridLayout();
                page.Grid.LoadCustomFilters();

                page.Grid.Renderer.SetupUnboundColumns(page.Grid.DisplayLayout.Bands[0]);
                isFirstTimeLoad = false;
            }

            // This is because the image column group by stuff gets lost after loading the grid layout and the captions don't display properly.
            page.Grid.Renderer.SetupBand(page.Grid.DisplayLayout.Bands[0]);

            ControlDetailButtonsInternally();

            IsDataLoaded = true;
            if (SiteId == Site.SARNIA_ID)
            {
                SentMailContext(dtos); //Added by ppanigrahi
            }
        }

        public bool IsDataLoaded { get; set; }

        public void ResetSearchBox()
        {
            page.ResetSearchTextBox();
            ResetGridItemsToPreSearchValues();
        }

        private void SetLayoutIsActiveIndicator()
        {
            Details.EnableLayoutIsActiveIndicator = GridLayoutIsActive;
        }

        private List<TDto> GetItems()
        {
            return new List<TDto>(grid.Items);
        }

        protected List<TDto> GetSelectedItems()
        {
            return new List<TDto>(grid.SelectedItems);
        }

        private void SetItems(IList<TDto> items)
        {
            Items = new List<TDto>(items);
        }

        protected abstract IList<TDto> GetData(DtoFilters filters);
        protected abstract void Edit(TDomainObject item);

        protected abstract TDto CreateDtoFromDomainObject(TDomainObject item);

        protected void ItemCreated(TDomainObject item)
        {
            if (!IsDataLoaded)
            {
                return;
            }

            if (IsItemInStateThatAlwaysRequiresShowing(item) || (IsItemInDateRange(item) && ShouldBeDisplayed(item)))
            {
                var dto = CreateDtoFromDomainObject(item);

                if (!page.IsDisposed)
                {
                    AddItem(dto);
                    if (itemsBeforeSearch != null) itemsBeforeSearch.Add(dto);
                }
            }
        }

        protected abstract bool IsItemInStateThatAlwaysRequiresShowing(TDomainObject item);

        protected void ItemUpdated(TDomainObject item)
        {
            if (!IsDataLoaded)
            {
                return;
            }

            var dto = CreateDtoFromDomainObject(item);

            var shouldBeDisplayed = ShouldBeDisplayed(item);
            var isItemInDateRange = IsItemInDateRange(item);

            if (page.IsDisposed)
                return;

            var itemIsInGrid = ItemIsInGrid(dto);
            var isItemInStateThatAlwaysRequiresShowing = IsItemInStateThatAlwaysRequiresShowing(item);

            if (itemIsInGrid && isItemInStateThatAlwaysRequiresShowing)
            {
                if (!page.IsDisposed)
                {
                    UpdateItem(dto);
                }
            }
            else if (itemIsInGrid && (!shouldBeDisplayed || !isItemInDateRange))
            {
                if (!page.IsDisposed)
                {
                    RemoveItem(dto);
                }
            }
            else if (itemIsInGrid)
            {
                if (!page.IsDisposed)
                {
                    UpdateItem(dto);
                }
            }
            else if (isItemInStateThatAlwaysRequiresShowing || (shouldBeDisplayed && isItemInDateRange))
            {
                if (!page.IsDisposed)
                {
                    AddItem(dto);
                }
            }

            if (itemsBeforeSearch != null && itemsBeforeSearch.Exists(dto1 => dto1.Id == dto.Id))
            {
                itemsBeforeSearch.RemoveAll(dto1 => dto1.Id == item.Id);
                itemsBeforeSearch.Add(dto);
            }
        }

        protected void ItemRemoved(TDomainObject item)
        {
            if (!IsDataLoaded)
            {
                return;
            }

            if (!page.IsDisposed)
            {
                var dto = CreateDtoFromDomainObject(item);
                RemoveItem(dto);
                if (itemsBeforeSearch != null && itemsBeforeSearch.Exists(dto1 => dto1.Id == item.Id))
                {
                    itemsBeforeSearch.RemoveAll(dto1 => dto1.Id == item.Id);
                }
            }
        }

        private void UpdateItem(TDto dto)
        {
            var updatedVersion = dto;
            var oldVersion = grid.FindItem(dto.Id);
            var updateIndex = grid.Items.IndexOf(oldVersion);

            // Got an Update Event for an item not in our list. So, ignore it.
            if (updateIndex == -1)
                return;

            grid.UpdateItem(updateIndex, updatedVersion);

            // The item that was updated is the item showing in the details pane, so reselect it
            if (FirstSelectedItem != null && updatedVersion.Id == FirstSelectedItem.Id)
            {
                SelectSingleItemById(updatedVersion.IdValue);
                page.RegisterDetailsChanged();
            }

            if (IsUpdatedByCurrentUser(dto))
            {
                grid.ScrollToItemById(dto.Id);
            }

            page.RegisterButtonsChanged();
        }

        protected abstract bool IsUpdatedByCurrentUser(TDto item);

        private void RemoveItem(TDto dto)
        {
            var toBeRemoved = grid.FindItem(dto.Id);

            // Somehow we got notified of an event for an item that we don't care about cause it's not in our visible list.
            if (toBeRemoved == null)
                return;


            grid.RemoveItem(toBeRemoved);

            if (Items.Count == 0)
            {
                // Nothing in the grid now, so make sure Buttons and Details are updated
                page.RegisterDetailsChanged();
                page.RegisterButtonsChanged();
            }
            else if (FirstSelectedItem != null && FirstSelectedItem.Id == dto.Id)
            {
                // Removing the First Item selected, so Details and Buttons should be notified.
                page.RegisterDetailsChanged();
                page.RegisterButtonsChanged();
            }
            else if (SelectedItemsContains(dto))
            {
                // Removing one of the other selected items, so update the buttons.
                page.RegisterButtonsChanged();
            }
        }

        private bool SelectedItemsContains(TDto item)
        {
            return grid.SelectedItems.Count > 0 && grid.SelectedItems.ExistsById(item);
        }

        protected abstract bool ItemIsInGrid(TDto item);

        protected virtual bool ShouldBeDisplayed(TDomainObject item)
        {
            var type = item.ObjectIdentifier.GetType();
            if (page.PageKey.Equals(PageKey.MULTIGRID_CSD_FORM_PAGE) && (item as FormOP14).FormStatus == FormStatus.Closed)
            { return false;}
            return true;
        }

        private bool IsItemInDateRange(TDomainObject item)
        {
            return IsItemInDateRange(item, filter.GetDateRange(this));
        }

        protected abstract bool IsItemInDateRange(TDomainObject item, Range<Date> dateRange);

        private void AddItem(TDto dto)
        {
            if (!grid.ItemIsInGrid(dto.IdValue))
            {
                grid.AddItem(dto);

                if (IsCreatedByCurrentUser(dto, ClientSession.GetUserContext().User))
                {
                    // only need to select the item that the user created because
                    // it's not possible to have other items selected when you just created one.
                    SelectSingleItemById(dto.IdValue);
                    grid.ScrollToItemById(dto.Id);
                }
            }
            else
            {
                logger.InfoFormat("{0} with id: {1} was already found in the grid. Skipping AddItem.",
                    dto.GetType().Name, dto.Id);
            }
        }

        private void SelectSingleItemById(long id)
        {
            grid.ClearSelections();
            grid.SelectItemById(id);
        }

        protected abstract bool IsCreatedByCurrentUser(TDto dto, User currentUser);

        private void ShowDetails()
        {
            Details.Show();
        }

        private void HideDetails()
        {
            Details.Hide();
        }

        public abstract void SetDetailData(TDetails details, TDomainObject item);


      
        protected TDomainObject QueryForFirstSelectedItem()
        {
            if (FirstSelectedItem == null)
            {
                return null;
            }
            return QueryByIdAndSiteId(FirstSelectedItem.IdValue,userContext.SiteId);    //ayman generic forms
        }

      
      public abstract TDomainObject QueryById(long id);

      public abstract TDomainObject QueryByIdAndSiteId(long id,long siteid);     //ayman generic forms

        private void HandleDoubleClickSelected(object sender, DomainEventArgs<TDto> e)
        {
            if(Page.PageKey.Equals(PageKey.MULTIGRID_FORM_PAGE))
            details.CallDefaultButton();
        }

        private void HandleSelectedItemChanged(object sender, DomainEventArgs<TDto> e)
        {
            ControlShowingOfDetailsPane();
            ControlDetailButtonsInternally();
        }

        protected abstract void Delete(TDomainObject item);

        protected void LaunchEditHistoryForm()
        {
            var item = QueryForFirstSelectedItem();
            if (item != null)
            {
                var presenter = CreateHistoryPresenter(item);
                presenter.Run(page.ParentForm);
            }
        }

        protected abstract EditHistoryFormPresenter CreateHistoryPresenter(TDomainObject item);

        protected virtual void DeleteWithOkCancelDialog(string entityName)
        {
            var confirmed = ShowOKCancelDialogForDelete(entityName);

            if (confirmed)
            {
                LockAndDeleteSelectedItems();
            }
        }

        protected void LockAndDeleteSelectedItems()
        {
            LockMultipleDomainObjects(Delete, QueryDomainObjectListFromDtos(grid.SelectedItems),
                () => page.DeleteSuccessfulMessage());
        }

        //TASK0637252  -  yalla harika
        protected bool ShowOKCancelDialogForDelete(string entityName)
        {
            if (ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
            {
                entityName = "Critical System Defeat";
            }
            return page.ShowOKCancelDialog(string.Format(StringResources.DeleteItemDialogText, entityName),
                string.Format(StringResources.DeleteItemDialogTitle, entityName));
        }


        // This could probably use PagePresenterHelper method that locks all objects first before attempting the action. 
        // Maybe we want to do the action until it fails to get a lock on one of the items?
        protected void LockMultipleDomainObjects(Action<TDomainObject> action, IEnumerable<TDomainObject> domainObjects,
            Action successDelegate)
        {
            var allActionsSucceeded = true;

            foreach (var domainObject in domainObjects)
            {
                try
                {
                    allActionsSucceeded &= PagePresenterHelper.LockDatabaseObjectWhileInUse(action, domainObject,
                        domainObject.ObjectIdentifier, LockType.Edit, userContext.User, objectLockingService);
                }
                catch (UserActionException)
                {
                    allActionsSucceeded = false;
                }
            }
            if (allActionsSucceeded && successDelegate != null)
            {
                successDelegate();
            }
        }

        protected List<TDomainObject> QueryDomainObjectListFromDtos(List<TDto> dtos)
        {
            return dtos.ConvertAll(dto => QueryByIdAndSiteId(dto.IdValue,userContext.SiteId));    //ayman generic forms
        }

        private void ResetGridItemsToPreSearchValues()
        {
            mostRecentSearchTerm = null;
            if (itemsBeforeSearch != null)
            {
                SetItems(itemsBeforeSearch); // wrap with a new list because itemsBeforeSearch is a ReadOnlyCollection
                itemsBeforeSearch = null;
            }
        }

        private void ControlDetailButtonsInternally()
        {
            SetLayoutIsActiveIndicator();
            ControlDetailButtons();
        }

        private void HandleToggleShow()
        {
            filter.HandleFilterToggle(this);
        }

        protected void PrintWithDialogFocus(Action performPrint)
        {
            new PrintWithDialogFocus().Print(performPrint);
        }

        private void HandleSaveGridLayout()
        {
            var action = page.ShowGridLayoutConfirmationDialog();

            if (GridLayoutAction.Cancel.Equals(action))
            {
                return;
            }

            var gridIdentifier = GridIdentifier;

            if (gridIdentifier == null)
            {
                throw new NotImplementedException("Implement the GridIdentifier property to use this event handler.");
            }

            if (GridLayoutAction.Save.Equals(action))
            {
                var xml = page.GetGridLayoutXml();

                userContext.SetGridLayoutXML(gridIdentifier.GridName, xml);
                userService.SaveGridLayout(userContext.User.IdValue, gridIdentifier, xml);
            }
            else if (GridLayoutAction.RestoreDefault.Equals(action))
            {
                userService.DeleteGridLayout(userContext.User.IdValue, gridIdentifier);
                userContext.RemoveGridLayoutXml(gridIdentifier.Name);

                page.Grid.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                page.Grid.DisplayLayout.Bands[0].SortedColumns.Clear();

                page.Grid.SetDefaultGridLayout();
            }
            else if (GridLayoutAction.RevertToPreviouslySaved.Equals(action))
            {
                LoadGridLayout();
                // This is because the image column group by stuff gets lost after loading the grid layout and the captions don't display properly.
                page.Grid.Renderer.SetupBand(page.Grid.DisplayLayout.Bands[0]);
                page.Grid.LoadCustomFilters();
                page.Grid.Renderer.SetupUnboundColumns(page.Grid.DisplayLayout.Bands[0]);
            }

            ControlDetailButtonsInternally();
        }

        private void LoadGridLayout()
        {
            try
            {
                var xmlFromCache = userContext.GetGridLayoutXML(GridIdentifier.Name);

                var xml = xmlFromCache.IsNullOrEmptyOrWhitespace()
                    ? userService.GetGridLayout(ClientSession.GetUserContext().User.IdValue, GridIdentifier)
                    : xmlFromCache;

                if (!xml.IsNullOrEmptyOrWhitespace())
                {
                    userContext.SetGridLayoutXML(GridIdentifier.Name, xml);
                    page.LoadGridLayout(xml);
                }
            }
            catch (Exception e)
            {
                logger.Info(
                    "There was a problem loading the grid layout. This may be because the grid has changed since the layout was saved and no longer matches the saved XML.",
                    e);
            }
        }

        private void HandleExportAll(object sender, EventArgs e)
        {
            new OltExcelExporter().Export(grid);
        }

        protected abstract IForm CreateEditForm(TDomainObject form);

        private void SentMailContext(IList<DomainObject> dtos)
        {
           // if(DomainObject == FormEdmontonOP14DTO)
            foreach (DomainObject formdtoobject  in dtos)
            {
                if (formdtoobject is FormEdmontonOP14DTO)
                {
                    FormEdmontonOP14DTO formdto = (FormEdmontonOP14DTO) formdtoobject;
                    if (formdto.Status == FormStatus.WaitingForApproval)
                    {

                        List<FormApproval> formapprovals = service1.QueryByFormSarniaCsdApproverByIdAndSiteId(SiteId, 3,
                            0);
                        List<FormApproval> op14Approvals = service1.QueryByFormOP14Id(formdto.FormNumber);
                        FormOP14 domainObject = service.QueryFormOP14ByIdAndSiteId(formdto.FormNumber, SiteId);
                        if (Clock.Now <= formdto.ValidFrom.AddDays(9) && Clock.Now <= formdto.ValidTo)
                        {
                            foreach (FormApproval formapproval in op14Approvals)
                            {

                                if (formapproval.Enabled)
                                {
                                    var Approver = formapprovals.FirstOrDefault(x => x.Approver == formapproval.Approver);

                                    //  FormApproval aproval = service1.QueryByFormOP14Id(editObject.FormNumber, Approver.Approver);

                                    if (Approver != null &&
                                        ((Approver.Approver.ToString().ToLower().Contains("shift supervisor")) ||
                                         (Approver.Approver.ToString().ToLower().Contains("operations manager"))))
                                    {
                                        if (!formapproval.isMailSent)
                                        {
                                            string emailList = Approver.EmailList;
                                            long approveroleId = service.QueryByFormOp14ApprovalId(domainObject.Id,
                                                Approver.Approver);
                                            bool isMailSent = true;
                                            // long id = formapproval.Id;

                                            SentMail(formapproval, emailList, approveroleId, Approver.Approver,
                                                domainObject);

                                            int success = service1.Updatemailsentflag(formapproval.Id, isMailSent);
                                        }
                                    }

                                }
                            }

                        }
                        else if ((Clock.Now >= formdto.ValidFrom.AddDays(10) && Clock.Now < formdto.ValidFrom.AddDays(29)) &&
                                 Clock.Now <= formdto.ValidTo)
                        {
                            foreach (FormApproval formapproval in op14Approvals)
                            {

                                if (formapproval.Enabled)
                                {
                                    var Approver =
                                        formapprovals.FirstOrDefault(x => x.Approver == formapproval.Approver);
                                    if (Approver != null &&
                                        ((Approver.Approver.ToString()
                                            .ToLower()
                                            .Contains("operations manager ( >= 10 days)"))))
                                    {
                                        if (!formapproval.isMailSent)
                                        {
                                            string emailList = Approver.EmailList;
                                            long approveroleId = service.QueryByFormOp14ApprovalId(domainObject.Id,
                                                Approver.Approver);
                                            bool isMailSent = true;
                                            // long id = formapproval.Id;

                                            // int success = service1.Updatemailsentflag(formapproval.Id, isMailSent);
                                            SentMail(formapproval, emailList, approveroleId, Approver.Approver,
                                                domainObject);

                                            int success = service1.Updatemailsentflag(formapproval.Id, isMailSent);
                                        }
                                    }


                                }
                            }

                        }
                        else if ((Clock.Now >= formdto.ValidFrom.AddDays(30)) && Clock.Now <= formdto.ValidTo)
                        {
                            foreach (FormApproval formapproval in op14Approvals)
                            {

                                if (formapproval.Enabled)
                                {
                                    var Approver =
                                        formapprovals.FirstOrDefault(x => x.Approver == formapproval.Approver);
                                    if (Approver != null &&
                                        ((Approver.Approver.ToString()
                                            .ToLower()
                                            .Contains("operations director (> 30 days)")) ||
                                         (Approver.Approver.ToString()
                                             .ToLower()
                                             .Contains("engineering director (> 30 days)"))))
                                    {
                                        if (!formapproval.isMailSent)
                                        {
                                            string emailList = Approver.EmailList;
                                            long approveroleId = service.QueryByFormOp14ApprovalId(domainObject.Id,
                                                Approver.Approver);
                                            bool isMailSent = true;
                                            // long id = formapproval.Id;



                                            SentMail(formapproval, emailList, approveroleId, Approver.Approver,
                                                domainObject);

                                            int success = service1.Updatemailsentflag(formapproval.Id, isMailSent);

                                        }
                                    }

                                }
                            }

                        }

                    }



                }
            }

        }
        private void SentMail(FormApproval approval, string emailList, long approveroleId, string approver, FormOP14 domainObject)
        {
            if (emailList != null)
            {
                List<EmailAddress> emailAdd =
                    EmailAddress.ConvertDelimitedListToEmailAddresses(emailList);
                foreach (EmailAddress em in emailAdd)
                {
                    int enabled;
                    string usernamestring = em.ToString();
                    string[] usernameList = usernamestring.Split('@');
                    var username = usernameList[0];
                    long userID = service.QueryUserId(username);
                    long? Id = approveroleId;
                    long ShouldBeEnabledBehaviourId = approval.ShouldBeEnabledBehaviourId;
                    bool Enabled = approval.Enabled;
                    if (Enabled)
                    {
                        enabled = 1;

                    }
                    else
                    {
                        enabled = 0;
                    }
                    long? FormOP14Id = domainObject.Id;
                    // long FunctionalLocationId = editObject.FunctionalLocations.;
                    long? FormStatusId = 2; //editObject.FormStatus.Id;
                    string CriticalSystemDefeated = domainObject.CriticalSystemDefeated;
                    long LastModifiedByUserId = userID;
                    long sitid = domainObject.SiteId;
                    //var subjectText = EdmontonFormType.OP14.Name + " Form" + "#" +
                    //                  editObject.FormNumber +
                    //                  " is waiting for approval for Role " + Approver.Approver;
                    var subjectText = "Critical System Defeat  Form" + "#" +
                                      domainObject.FormNumber +
                                      " is waiting for approval for Role " + approver;
                    var messageBodyText = BuildBodyText(Id, userID, ShouldBeEnabledBehaviourId,
                        enabled,
                        FormOP14Id, FormStatusId, CriticalSystemDefeated, sitid, approver);
                    var attachmentFilename = BuildAttachmentFilename(EdmontonFormType.OP14.Name,
                        domainObject.FormNumber);

                    //var emails = emailAddresses.ToCommaSeparatedString();



                    reportPrintManager.Email(domainObject, em, messageBodyText, subjectText,
                        attachmentFilename, true);
                }
            }

        }

        private string BuildBodyText(long? id, long userid, long shouldBeEnabledBehaviourId, int enabled, long? formOp14Id, long? formStatusId, string criticalSystemDefeated, long sitid, string approver)
        {
            // var introText = "OP-14 Critical System Defeat Form#" + editObject.FormNumber + " is waiting for approval. Please log into OLT to review and approve.\n\n" + "Review the change prior to approving.";

            //string introText = "<body>"+
            //        " OP-14 Critical System Defeat Form#"+editObject.FormNumber+"is waiting for approval."+"<br/><br/> Please check the document prior to approving.<br/><br/><br/>"+
            //        "<button id=\"btnAccept\" type=\"button\" value=\"button\">Accept</button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"+
            //        "<button id=\"btnReject\" type=\"button\" value=\"button\">Reject</button>"+
            //       "</body>";


            string remoteServicesURL = ConfigurationManager.AppSettings["RemoteServicesURL"].ToString();
            string introText = "<!DOCTYPE html>" +
                               "<html xmlns=\"http://www.w3.org/1999/xhtml\">" +
                               "<head>" +
                              "<div>" +
                                "Critical System Defeat Form#" + formOp14Id + " is waiting for approval." + "<br/><br/> Please check the document prior to approving.<br/><br/><br/>" +
                               "<a href=\"" + remoteServicesURL + "/EmailApprove.aspx?ID=" + formOp14Id + "&reqid=" + id + "&approvedByUserId=" + userid + "&shouldBeEnabledBehaviourId=" + shouldBeEnabledBehaviourId + "&enabled=" + enabled + "&approver=" + approver + "\"" + " target=\"_blank\"" + ">" + "Click here to Approve or Reject CSD#" + formOp14Id + "</a>" + "<br/><br/>" +
                               "</div>" +

                               "</body>" +

                               "</html>";
            //var workAssignments = configuration.WorkAsosignments;

            var builder = new StringBuilder();

            builder.AppendLine(introText);
            builder.AppendLine();



            return builder.ToString();
        }
        private string BuildAttachmentFilename(string Name, long number)
        {
            return String.Format("{0}_{1}.pdf", Name, number);

        }

 

    }
}