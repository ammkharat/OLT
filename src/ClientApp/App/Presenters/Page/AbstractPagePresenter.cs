using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using System.Diagnostics;
using log4net;

namespace Com.Suncor.Olt.Client.Presenters.Page
{     

    public abstract class AbstractPagePresenter<TDto, TDomainObject, TDetails, TPage> : IDomainPagePresenter
        where TDto : DomainObject
        where TDomainObject : DomainObject
        where TDetails : IDetails
        where TPage : class, IDomainPage<TDto, TDetails>
    {
        private readonly ILog logger = GenericLogManager.GetLogger<AbstractPagePresenter<TDto, TDomainObject, TDetails, TPage>>();

        private IBackgroundHelper<Range<Date>> backgroundHelper;

        protected readonly UserContext userContext;
        protected TPage page;
        protected IRemoteEventRepeater remoteEventRepeater;
        private readonly IObjectLockingService objectLockingService;
        protected readonly IAuthorized authorized;
        protected readonly ITimeService timeService;
        private readonly IUserService userService;
        protected Range<Date> userSelectedDateRange;
        private int soundcount;
        Stopwatch stopwatch = new Stopwatch();
        protected abstract TDomainObject QueryByDto(TDto dto);
        protected abstract IList<TDto> GetDtos(Range<Date> dateRange);                                              //ayman temp merge
        //protected abstract IList<TDto> GetDtos(Range<Date> dateRangeLog, Range<Date> dateRange);                    //ayman temp merge
        protected abstract TDto CreateDTOFromDomainObject(TDomainObject item);
        protected abstract string DomainObjectName { get; }

        protected abstract void HookToServiceEvents(IRemoteEventRepeater repeater);
        protected abstract void UnHookToServiceEvents(IRemoteEventRepeater repeater);

        protected abstract void ControlDetailButtons();
        protected abstract void SetDetailData(TDetails details, TDomainObject item);
        protected readonly IPage invokeControl;
        protected AbstractPagePresenter(
            TPage page,
            IAuthorized authorized, 
            IRemoteEventRepeater remoteEventRepeater, 
            IObjectLockingService objectLockingService,
            ITimeService timeService,
            IUserService userService)
        {
            userContext = ClientSession.GetUserContext();
            this.page = page;
            this.authorized = authorized;
            this.remoteEventRepeater = remoteEventRepeater;
            this.objectLockingService = objectLockingService;
            this.timeService = timeService;
            this.userService = userService;

            SetPageTitle();
            page.Items = new List<TDto>();                        
        }

        public bool IsDataLoaded { get; private set; }
        
        public virtual void PreviouslyLoadedPageSelected()
        {
            
        }

        public IItemSelectablePage Page
        {
             get { return page; }
        }

        public void DoInitialDataLoad()
        {
            page.HideDetails();
            
            try
            {
                RefreshData(true);
            }
            catch (Exception e)
            {
                logger.Error("There was an exception refreshing data. Removing page layouts and trying again", e);
                RemovePageLayouts();
                RefreshData(true);
            }
            
            // call this manually once to make sure that the details and buttons are in the correct state
            ControlShowingOfDetailsPane();
            ControlDetailButtonsInternally();

            // subscribe to events after loading the data so that we don't get selected item change events 
            // more than once
            SubscribeToEvents();

            // now that everything is set up, we are ready to accept events
            if (remoteEventRepeater != null)
            {
                HookToServiceEvents(remoteEventRepeater);
            }            
        }

        private void RemovePageLayouts()
        {
            logger.Warn("Removing grid layouts for user: " + userContext.User.FullNameWithUserName);
            userService.DeleteGridLayoutsForUser(userContext.User.IdValue);
            userContext.ClearGridLayoutCache();
        }

        private void ControlDetailButtonsInternally()
        {
            ControlDetailButtons();
            page.EnableLayoutIsActiveIndicator = GridIdentifier != null && ClientSession.GetUserContext().GetGridLayoutXML(GridIdentifier.GridName) != null;                                       
        }

        public void LoadDataInForegroundIfNotAlreadyLoaded()
        {
            if (!IsDataLoaded)
            {
                DoInitialDataLoad();
            }
        }

        private void SubscribeToEvents()
        {
            if (page != null)
            {
                page.DetailsChanged += Details_Changed;
                page.ButtonsChanged += Buttons_Changed;

                page.Grid.SelectedItemChanged += Grid_SelectedItemChanged;
                page.Grid.DoubleClickSelected += Grid_DoubleClicked;

                page.Details.ToggleShow += Details_ToggleShow;
                page.Details.ExportAll += Details_ExportAllClicked;
                page.Details.SaveGridLayout += HandleSaveGridLayout;

                page.SearchButtonClicked += HandleSearchButtonClicked;
                page.CancelSearchButtonClicked += HandleCancelSearchButtonClicked;

                page.Disposed += Page_Disposed;
            }
        }

        protected virtual void UnSubscribeFromEvents()
        {
            if (page != null)
            {
                page.DetailsChanged -= Details_Changed;
                page.ButtonsChanged -= Buttons_Changed;

                page.Grid.SelectedItemChanged -= Grid_SelectedItemChanged;
                page.Grid.DoubleClickSelected -= Grid_DoubleClicked;            

                page.Details.ToggleShow -= Details_ToggleShow;
                page.Details.ExportAll -= Details_ExportAllClicked;
                page.Details.SaveGridLayout -= HandleSaveGridLayout;

                page.SearchButtonClicked -= HandleSearchButtonClicked;
                page.CancelSearchButtonClicked -= HandleCancelSearchButtonClicked;

                page.Disposed -= Page_Disposed;
            }
        }

        private List<TDto> itemsBeforeSearch;
        private string mostRecentSearchTerm = null;

        private void HandleSearchButtonClicked(string searchTerm)
        {
            ApplySearchTerm(searchTerm);
        }

        private void ApplySearchTerm(string searchTerm)
        {
            if (searchTerm.IsNullOrEmptyOrWhitespace())
            {
                HandleCancelSearchButtonClicked();
                return;
            }

            mostRecentSearchTerm = searchTerm;

            if (itemsBeforeSearch == null)
            {
                itemsBeforeSearch = new List<TDto>(page.Items);
            }

            List<TDto> foundItems = new List<TDto>();

            foreach (TDto item in itemsBeforeSearch)
            {
                if (item != null)
                {
                    if (item.ContainsSearchTerm(searchTerm))
                    {
                        foundItems.Add(item);
                    }
                }
            }

            page.Items = foundItems;            
        }

        private void HandleCancelSearchButtonClicked()
        {
            page.ResetSearchTextBox();
            mostRecentSearchTerm = null;

            if (itemsBeforeSearch != null)
            {
                page.Items = new List<TDto>(itemsBeforeSearch);   // wrap with a new list because itemsBeforeSearch is a ReadOnlyCollection
                itemsBeforeSearch = null;            
            }
        }

        private void Page_Disposed(object sender, EventArgs e)
        {
            UnSubscribeFromEvents();

            if (remoteEventRepeater != null)
            {
                UnHookToServiceEvents(remoteEventRepeater);
            }
            remoteEventRepeater = null;

            page = null;
        }

        protected void DisableSelectedItemChangedEvent()
        {
            page.Grid.SelectedItemChanged -= Grid_SelectedItemChanged;
        }

        protected void EnableSelectedItemChangedEvent()
        {
            page.Grid.SelectedItemChanged += Grid_SelectedItemChanged;
        }

        protected virtual void Grid_DoubleClicked(object sender, DomainEventArgs<TDto> args)
        {
            page.Details.CallDefaultButton();
        }

        protected virtual void Grid_SelectedItemChanged(object sender, DomainEventArgs<TDto> args)
        {
            ControlShowingOfDetailsPane();
            ControlDetailButtonsInternally();
        }     

        private void Details_Changed(object sender, EventArgs e)
        {
            ControlShowingOfDetailsPane();
        }

        private void Buttons_Changed(object sender, EventArgs e)
        {
            ControlDetailButtonsInternally();
        }

        protected void ControlShowingOfDetailsPane()
        {
            if (page.IsItemSelected() && !page.IsDisposed)
            {
                if (page.InvokeRequired)
                {
                    page.Invoke(new MethodInvoker(delegate
                    {
                        SetDetailData(page.Details, QueryForFirstSelectedItem());
                        page.ShowDetails();
                    }));
                }
                else
                {
                    SetDetailData(page.Details, QueryForFirstSelectedItem());
                    page.ShowDetails();
                }
            }
            else
            {
                if (page.InvokeRequired)
                {
                    page.Invoke(new MethodInvoker(() => page.HideDetails()));
                }
                else
                {
                    page.HideDetails();
                }
            }
        }

        private void Details_ExportAllClicked(object sender, EventArgs e)
        {
            page.ExportAll();
        }

        protected TDomainObject QueryForFirstSelectedItem()
        {
            if (page.FirstSelectedItem == null)
            {
                return null;
            }
              
            return QueryByDto(page.FirstSelectedItem);
        }

        protected virtual void repeater_Created(object sender, DomainEventArgs<TDomainObject> e)
        {
            if (page != null && !page.IsDisposed)
            {
                page.Invoke(new Action<TDomainObject>(ItemCreated), e.SelectedItem);
            }
        }

        protected virtual void repeater_Updated(object sender, DomainEventArgs<TDomainObject> e)
        {
            if (page != null && !page.IsDisposed)
            {
                page.Invoke(new Action<TDomainObject>(ItemUpdated), e.SelectedItem );
            }
        }

        protected virtual void repeater_Removed(object sender, DomainEventArgs<TDomainObject> e)
        {
            if (page != null && !page.IsDisposed)
            {
                page.Invoke(new Action<TDomainObject>(ItemRemoved), e.SelectedItem );
            }
        }

        protected void repeater_Refresh(object sender, DomainEventArgs<Site> e)
        {
            if (page != null && !page.IsDisposed)
            {
                page.Invoke(new MethodInvoker(RefreshData));
                // DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
                if (soundcount == 1)
                {
                    stopwatch.Start();
                    
                }
                if (stopwatch.Elapsed.Milliseconds > 5000)
                {
                    stopwatch.Stop();
                    soundcount = 0;
                }

                bool sound = ClientSession.GetUserContext().User.WorkPermitPrintPreference.SoundAlertEnable;
                if (sound && (stopwatch.Elapsed.Milliseconds > 5000 || soundcount == 0))
                {
                    if ((ClientSession.GetUserContext().SiteConfiguration.SoundAlertforActionItemDirectiveEventsTargets) &&
                        (page.PageKey == PageKey.ACTION_ITEM_PAGE || page.PageKey == PageKey.DIRECTIVE_PAGE || page.PageKey == PageKey.TARGET_ALERT_PAGE)) //events need to be added
                    {
                        if (invokeControl.IsOnNonUiThread())
                        {
                            soundcount += 1;
                            using (var soundPlayer = new System.Media.SoundPlayer(Properties.Resources.SoundAlert))
                            {
                                soundPlayer.PlaySync();  // DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
                            }
                        }
                    }
                }
            }
        }

        
        protected virtual bool ShouldBeDisplayed(TDomainObject item)
        {
            return true;
        }

        protected virtual void RefreshThreadedView(bool recalculateRelationships)
        {
        }

        protected void AddOrUpdateItemsBeforeSearch(List<TDomainObject> items)
        {
            if (page != null && !page.IsDisposed)
            {
                page.Invoke(new Action<List<TDomainObject>>(ItemsUpdated), items);
            }
        }

        private void ItemsUpdated(List<TDomainObject> items)
        {
            foreach (var item in items)
            {
                ItemsBeforeSearchUpdated(item);
            }

            RefreshThreadedView(true);           
        }

        private void ItemsBeforeSearchUpdated(TDomainObject item)
        {
            if (itemsBeforeSearch == null) return;

            TDto dto = CreateDTOFromDomainObject(item);

            bool shouldBeDisplayed = ShouldBeDisplayed(item);
            bool isItemInDateRange = IsItemInDateRange(item);

            if (itemsBeforeSearch.ExistsById(dto))
            {
                itemsBeforeSearch.RemoveById(dto);
            }

            if (shouldBeDisplayed && isItemInDateRange)
            {
                itemsBeforeSearch.Add(dto);
            }
        }

        protected void ItemCreated(TDomainObject item)
        {
            if (IsItemInDateRange(item) && ShouldBeDisplayed(item))
            {
                TDto dto = CreateDTOFromDomainObject(item);
                if (!page.IsDisposed)
                {
                    page.AddItem(dto);

                    if (itemsBeforeSearch != null && !itemsBeforeSearch.ExistsById(dto))
                    {
                        itemsBeforeSearch.Add(dto);
                    }

                    RefreshThreadedView(true);
                }
            }
        }

        protected virtual bool IsItemInDateRange(TDomainObject item)
        {
            if (userSelectedDateRange == null)
            {
                return true;
            }
            return IsItemInDateRange(item, userSelectedDateRange);
        }

        protected virtual bool IsItemInDateRange(TDomainObject item, Range<Date> range)
        {
            // For pages that don't have Date Range filters, always display the item.
            return true;
        }

        protected void ItemUpdated(TDomainObject item)
        {
            TDto dto = CreateDTOFromDomainObject(item);

            bool shouldBeDisplayed = ShouldBeDisplayed(item);
            bool isItemInDateRange = IsItemInDateRange(item);

            if (page.IsDisposed) return;

            bool itemIsInGrid = page.ItemIsInGrid(dto);

            if (itemIsInGrid && (!shouldBeDisplayed || !isItemInDateRange))
            {
                if (!page.IsDisposed)
                {
                    page.RemoveItem(dto);

                    if (itemsBeforeSearch != null && itemsBeforeSearch.ExistsById(dto))
                    {
                        itemsBeforeSearch.Remove(dto);
                    }

                    RefreshThreadedView(true);
                }
            }
            else if (itemIsInGrid)
            {
                if (!page.IsDisposed)
                {
                    page.UpdateItem(dto);

                    if (itemsBeforeSearch != null && itemsBeforeSearch.ExistsById(dto))
                    {
                        itemsBeforeSearch.RemoveById(dto);
                        itemsBeforeSearch.Add(dto);
                    }

                    RefreshThreadedView(true);
                }
            }
            else if (shouldBeDisplayed && isItemInDateRange)
            {
                if (!page.IsDisposed)
                {
                    page.AddItem(dto);

                    if (itemsBeforeSearch != null)
                    {
                        itemsBeforeSearch.RemoveById(dto);
                        itemsBeforeSearch.Add(dto);
                    }

                    RefreshThreadedView(true);
                }
            }
        }

        protected void ItemRemoved(TDomainObject item)
        {
            if (!page.IsDisposed)
            {
                var dto = CreateDTOFromDomainObject(item);

                page.RemoveItem(dto);

                if (itemsBeforeSearch != null && itemsBeforeSearch.ExistsById(dto))
                {
                    itemsBeforeSearch.RemoveById(dto);
                }

                RefreshThreadedView(true);
            }
        }

        protected void LockDatabaseObjectWhileInUse(Action<TDomainObject> action, LockType lockType)
        {
            TDomainObject domainObject = QueryForFirstSelectedItem();
            LockDatabaseObjectWhileInUse(action, domainObject, lockType);
        }

        protected virtual bool LockDatabaseObjectWhileInUse(Action<TDomainObject> action, TDomainObject domainObject, LockType lockType)
        {
            return LockDatabaseObjectWhileInUse(action, domainObject, domainObject.ObjectIdentifier, lockType);
        }

        protected bool LockDatabaseObjectWhileInUse(Action<TDomainObject> action, TDomainObject domainObject, string lockIdentifier, LockType lockType)
        {
            return PagePresenterHelper.LockDatabaseObjectWhileInUse(action, domainObject, lockIdentifier, lockType, userContext.User, objectLockingService);        
        }

        protected void LockMultipleDomainObjects(Action<List<TDomainObject>> action, LockType lockType)
        {
            List<TDomainObject> domainObjects = ConvertAllTo(page.SelectedItems);
            PagePresenterHelper.LockMultipleDomainObjects(action, domainObjects, lockType, userContext.User, objectLockingService);
        }

        protected void LockMultipleDomainObjects(Action<TDomainObject> action, Action successDelegate)
        {
            List<TDomainObject> domainObjects = ConvertAllTo(page.SelectedItems);
            LockMultipleDomainObjects(action, domainObjects, successDelegate);
        }

        protected List<TDomainObject> ConvertAllTo(List<TDto> dtos)
        {
            return dtos.ConvertAll(dto => QueryByDto(dto));
        }

        protected void LockMultipleDomainObjects(Action<TDomainObject> action, IEnumerable<TDomainObject> domainObjects, Action successDelegate)
        {
            bool allActionsSucceeded = true;

            foreach (TDomainObject domainObject in domainObjects)
            {
                try
                {
                    allActionsSucceeded &= LockDatabaseObjectWhileInUse(action, domainObject, LockType.Edit);
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

        private void Details_ToggleShow()
        {
            if (page.Details.ShowButtonAppearance == Constants.SHOW_CURRENT_WIDGET_APPEARANCE)
            {
                RefreshData(GetDefaultDateRange(), true, false);
            }
            else
            {
                DialogResultAndOutput<Range<Date>> dialogResultAndOutput = page.DisplayDateRangeDialog();
                if (dialogResultAndOutput.Result == DialogResult.OK)
                {
                    RefreshData(dialogResultAndOutput.Output, false, false);
                }
            }
        }

        protected virtual Range<Date> GetDefaultDateRange()
        {
            return null;
        }

        protected void RefreshData()
        {
            RefreshData(false);
        }

        private void RefreshData(bool fetchDataInForeground)
        {
            Range<Date> range = GetDefaultDateRange();
            RefreshData(range, true, fetchDataInForeground);
        }
        
        protected void RefreshData(Range<Date> newDateRange, bool isCurrentlyDefault, bool fetchDataInForeground)
        {
            page.Details.ShowButtonAppearance = !isCurrentlyDefault ? Constants.SHOW_CURRENT_WIDGET_APPEARANCE : Constants.SHOW_DATE_RANGE_WIDGET_APPEARANCE;

            if (backgroundHelper == null)
            {
                backgroundHelper = CreateBackgroundHelper(fetchDataInForeground);
                backgroundHelper.Run(newDateRange);
            }
        }

        protected virtual IBackgroundHelper<Range<Date>> CreateBackgroundHelper(bool synchronous)
        {
            if (synchronous)
            {
                return new FakeBackgroundHelper<Range<Date>, DtosAndDateRange<TDto>>(new DtoFetcher(this));
            }
            return new BackgroundHelper<Range<Date>, DtosAndDateRange<TDto>>(new ClientBackgroundWorker(), new DtoFetcher(this));
        }

        protected bool firstTimeLoad = true;

        protected void RefreshData(IList<TDto> dtos, Range<Date> newDateRange)
        {            
            userSelectedDateRange = newDateRange;

            SetPageTitle();

            List<long> selectedIds = page.SelectedItems.AsIdList();
            
            

            page.Items = dtos;
            itemsBeforeSearch = new List<TDto>(dtos);
            ApplySearchTerm(mostRecentSearchTerm);

            page.ClearSelectionsAndSelectItemsById(selectedIds);
            
            if (firstTimeLoad)
            {
                LoadGridLayout();
                page.Grid.LoadCustomFilters();

                page.Grid.Renderer.SetupUnboundColumns(page.Grid.DisplayLayout.Bands[0]);
                firstTimeLoad = false;
            }

            // This is because the image column group by stuff gets lost after loading the grid layout and the captions don't display properly.
            page.Grid.Renderer.SetupBand(page.Grid.DisplayLayout.Bands[0]);

            if (!page.IsItemSelected() && page.Items.Count != 0)
            {
                page.SelectSingleItemByIndex(0);
            }

            IsDataLoaded = true;
        }

        protected void SetPageTitle()
        {
            if (userSelectedDateRange != null)
            {
                SetPageTitle(userSelectedDateRange);
            }
            else if (GetDefaultDateRange() != null)
            {
                SetPageTitle(GetDefaultDateRange());
            }
            else if (!string.IsNullOrEmpty(GetPageTitleOverride()))
            {
                string pageTitleOverride = GetPageTitleOverride();
                
                string secondLineOfPageTitle = SetSecondLineOfPageTitle();
                if (!secondLineOfPageTitle.IsNullOrEmptyOrWhitespace())
                {
                    pageTitleOverride += Environment.NewLine + secondLineOfPageTitle;
                }

                page.PageTitle = pageTitleOverride;
            }
            else
            {
                // this doesn't include second line stuff, because nobody should use it. They should override the GetPageTitleOverride()
                page.PageTitle = PageTitleName + " : ";
            }
        }

        protected virtual string SetSecondLineOfPageTitle()
        {
            return null;
        }

        // Override this if you want full control of the page title to set to your heart's desire.
        protected virtual string GetPageTitleOverride()
        {
            return null;
        }

        private void SetPageTitle(Range<Date> range)
        {
            string secondLineOfPageTitle = SetSecondLineOfPageTitle();

            Date lowerBound = range.LowerBound;
            Date upperBound = range.UpperBound;
            if (lowerBound == upperBound)
            {
                string pageTitle = string.Format(
                    StringResources.DateRangeIncludesTextForOneDay,
                    PageTitleName + " : ",
                    lowerBound);
                if (!secondLineOfPageTitle.IsNullOrEmptyOrWhitespace())
                {
                    pageTitle += Environment.NewLine + secondLineOfPageTitle;
                }
                page.PageTitle = pageTitle;
            }
            else
            {
                if (PageTitleName == StringResources.WorkPermitTemplates || PageTitleName == StringResources.PermitRequestTemplates)
                {
                //    string pageTitle = string.Format(
                //    StringResources.DateRangeIncludesText,
                //    PageTitleName + " : ",
                //    lowerBound,
                //    upperBound != null ? upperBound.ToString() : StringResources.NoEnd_LowerCase);
                //if (!secondLineOfPageTitle.IsNullOrEmptyOrWhitespace())
                //{
                //    pageTitle += Environment.NewLine + secondLineOfPageTitle;
                //}

                    page.PageTitle = "";
                }
                else
                {
                    string pageTitle = string.Format(
                    StringResources.DateRangeIncludesText,
                    PageTitleName + " : ",
                    lowerBound,
                    upperBound != null ? upperBound.ToString() : StringResources.NoEnd_LowerCase);
                    if (!secondLineOfPageTitle.IsNullOrEmptyOrWhitespace())
                    {
                        pageTitle += Environment.NewLine + secondLineOfPageTitle;
                    }

                    page.PageTitle = pageTitle;
                }
            }
        }

        protected virtual string PageTitleName
        {
            get { return page.PageKey.TitleText; }
        }

        protected void PrintWithDialogFocus(Action performPrint)
        {
            new PrintWithDialogFocus().Print(performPrint);
        }

        private void HandleSaveGridLayout()
        {
            GridLayoutAction action = page.ShowGridLayoutConfirmationDialog();

            if (GridLayoutAction.Cancel.Equals(action))
            {
                return;
            }

            UserGridLayoutIdentifier gridIdentifier = GridIdentifier;

            if (gridIdentifier == null)
            {
                throw new NotImplementedException("Implement the GridIdentifier property to use this event handler.");
            }

            if (GridLayoutAction.Save.Equals(action))
            {
                string xml = page.GetGridLayoutXml();
                
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
                string xmlFromCache = userContext.GetGridLayoutXML(GridIdentifier.Name);

                string xml = xmlFromCache.IsNullOrEmptyOrWhitespace() ? userService.GetGridLayout(ClientSession.GetUserContext().User.IdValue, GridIdentifier) : xmlFromCache;
                
                if (!xml.IsNullOrEmptyOrWhitespace())
                {
                    userContext.SetGridLayoutXML(GridIdentifier.Name, xml);
                    page.LoadGridLayout(xml);                    
                }
            }
            catch (Exception e)
            {
                logger.Info("There was a problem loading the grid layout. This may be because the grid has changed since the layout was saved and no longer matches the saved XML.", e);
            }
        }

        protected virtual UserGridLayoutIdentifier GridIdentifier { get { return null; } }

        protected class DtosAndDateRange<TTDto>
        {
            private readonly IList<TTDto> dtos;
            private readonly Range<Date> dateRange;

            public DtosAndDateRange(IList<TTDto> dtos, Range<Date> dateRange)
            {
                this.dtos = dtos;
                this.dateRange = dateRange;
            }

            public Range<Date> DateRange
            {
                get { return dateRange; }
            }

            public IList<TTDto> Dtos
            {
                get { return dtos; }
            }
        }

        protected class DtoFetcher : ClientBackgroundingFriendly<Range<Date>, DtosAndDateRange<TDto>>
        {
            private readonly AbstractPagePresenter<TDto, TDomainObject, TDetails, TPage> presenter;

            public DtoFetcher(AbstractPagePresenter<TDto, TDomainObject, TDetails, TPage> presenter)
            {
                this.presenter = presenter;
            }


            /////ayman action item definition - leave those block of codes for future use in case it needed to save coding time
            //public List<string> GetActionItemDefinitionIDsRelatedtoActionItems(List<ActionItemDTO> AidIDs)
            //{
            //    var aidIds = AidIDs.ConvertAll(dd => dd.DefinitionId().ToString());
            //    aidIds = aidIds.Distinct().ToList();
            //    return aidIds;
            //}

            public override DtosAndDateRange<TDto> DoWork(Range<Date> range)
            {
                //if (presenter is Page.ActionItemDefinitionPagePresenter)
                //{
                //    ActionItemDefinitionPagePresenter mypage = new ActionItemDefinitionPagePresenter();
                //    mypage.NewDateRange = range;
                //}

                IList<TDto> dtos = presenter.GetDtos(range);

                ////ayman action item definition
                //if (presenter is Page.ActionItemPagePresenter)
                //{
                //    if (dtos != null && dtos.Count > 0)
                //    {
                //        List<ActionItemDTO> aidDtos = dtos as List<ActionItemDTO>;
                //        GetActionItemDefinitionIDsRelatedtoActionItems(aidDtos);
                //    }
                //}
                return new DtosAndDateRange<TDto>(dtos, range);
            }


            public override bool ViewEnabled
            {
                set { presenter.page.ButtonsEnabled = value; }
            }

            public override void WorkSuccessfullyCompleted(DtosAndDateRange<TDto> result)
            {
                presenter.RefreshData(result.Dtos, result.DateRange);
            }

            public override void WorkCompletedOrCancelled()
            {
                presenter.backgroundHelper = null;
            }

            public override void OnError(Exception e)
            {
                if (e.Message.Contains("Timeout expired") || e.Message.Contains("Transaction Timeout"))
                {
                    presenter.page.ShowUnableToReturnTheAmountOfDataRequestedError(StringResources.UnableToReturnAmountOfDataError);
                    presenter.page.Details.ShowButtonAppearance = Constants.SHOW_DATE_RANGE_WIDGET_APPEARANCE;
                    presenter.RefreshData();
                }
                else
                {
                    throw new Exception("Error fetching DTOs", e);
                }
            }
        }
    }
}