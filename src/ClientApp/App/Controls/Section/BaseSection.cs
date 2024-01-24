using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.Services;
using Infragistics.Win.UltraWinTabControl;
using log4net;

namespace Com.Suncor.Olt.Client.Controls.Section
{
    public partial class BaseSection : UserControl, ISection
    {
        public event Action<IItemSelectablePage> SelectedTabChanged;
        public event Action Selected;

        private const int DISPOSE_LOCK_TIMEOUT_MS = 60000;
        private const int ADD_LOCK_TIMEOUT_MS = 10000;
        private const int UI_LOCK_TIMEOUT_MS = 5000;

        //ayman action item definition 
        private  object aidService;

        private static readonly ILog logger = LogManager.GetLogger(typeof(BaseSection));
        private readonly object lockObject = new object();
        private readonly List<PageInformation> pageInformationListSortedBySelectionOrderThenByVisibleIndex = new List<PageInformation>();
        private readonly Dictionary<PageKey, IDomainPagePresenter> pagePresenterMap = new Dictionary<PageKey, IDomainPagePresenter>();

        public BaseSection()
        {
            InitializeComponent();
            tabControl.SelectedTabChanged += TabControl_SelectedTabChanged;
        }

        private void TabControl_SelectedTabChanged(object sender, SelectedTabChangedEventArgs e)
        {
            if (SelectedTabChanged != null)
            {
                foreach (PageInformation pageInformation in pageInformationListSortedBySelectionOrderThenByVisibleIndex)
                {
                    if (pageInformation.Page.Visible)
                    {
                        SelectedTabChanged(pageInformation.Page);
                        break;
                    }
                }
            }
        }

        public void DisposePages()
        {
            if (Monitor.TryEnter(lockObject, DISPOSE_LOCK_TIMEOUT_MS))
            {
                try
                {
                    if (pageInformationListSortedBySelectionOrderThenByVisibleIndex != null)
                    {
                        foreach (PageInformation pageInformation in pageInformationListSortedBySelectionOrderThenByVisibleIndex)
                        {
                            pageInformation.Page.Dispose();
                        }
                        pageInformationListSortedBySelectionOrderThenByVisibleIndex.Clear();
                    }
                }
                finally
                {
                    Monitor.Exit(lockObject);
                }
            }
            else
            {
                logger.Error("Timed out waiting for lock to dispose pages.");
            }
        }

        public bool GetSelectSingleItem(PageKey pageKey, long domainObjectId, bool suppressItemNotFoundMesage)
        {
            return GetSelectSingleItem(
                pageInformation => pageInformation.Page.PageKey.Equals(pageKey),
                pageKey.TabText,
                domainObjectId,
                suppressItemNotFoundMesage);
        }

        private bool GetSelectSingleItem(
            Func<PageInformation, bool> PageMatches,
            string searchDescription,
            long? id,
            bool suppressItemNotFoundMesage)
        {
            bool itemSelected = false;

            List<IItemSelectablePage> pages = GetPagesThatDisplaysDomainObjectSortedBySelectionOrderThenByVisibleIndex(
                PageMatches,
                searchDescription);
            foreach (IItemSelectablePage page in pages)
            {
                IDomainPagePresenter domainPagePresenter = pagePresenterMap[page.PageKey];
                domainPagePresenter.LoadDataInForegroundIfNotAlreadyLoaded();

                //SelectTabThatContainsControl((Control)page);

                if (page.ContainsItemById(id))
                {
                    //page.SelectSingleItemById(id);

                    itemSelected = true;
                    break;
                }
            }
            return itemSelected;
        }

        public void SelectSingleItem(PageKey pageKey, long domainObjectId, bool suppressItemNotFoundMesage)
        {
            SelectSingleItem(
                pageInformation => pageInformation.Page.PageKey.Equals(pageKey),
                pageKey.TabText,
                domainObjectId,
                suppressItemNotFoundMesage);
        }

        public void SelectSingleItem(DomainObject domainObject, bool suppressItemNotFoundMesage)
        {
            SelectSingleItem(
                pageInformation => pageInformation.PageDomainObjectType == domainObject.GetType(),
                domainObject.GetType().Name,
                domainObject.Id, 
                suppressItemNotFoundMesage);
        }

        private void SelectSingleItem(
            Func<PageInformation, bool> PageMatches,
            string searchDescription,
            long? id, 
            bool suppressItemNotFoundMesage)
        {
            bool itemSelected = false;

            List<IItemSelectablePage> pages = GetPagesThatDisplaysDomainObjectSortedBySelectionOrderThenByVisibleIndex(
                PageMatches,
                searchDescription); 
            foreach (IItemSelectablePage page in pages)
            {
                IDomainPagePresenter domainPagePresenter = pagePresenterMap[page.PageKey];
                domainPagePresenter.LoadDataInForegroundIfNotAlreadyLoaded();

                SelectTabThatContainsControl((Control)page);

                if (page.ContainsItemById(id))
                {
                    page.SelectSingleItemById(id);

                    itemSelected = true;
                    break;
                }
            }


            // ayman action item definition not exist
            if (!itemSelected)
            {
                long actionitemDefid = id ?? 0;
                if (actionitemDefid != 0)
                {
                    //ayman action item definition 
                    var actionItemDefinitionService = ClientServiceRegistry.Instance.GetService<IActionItemDefinitionService>();
                    var schedule = ClientServiceRegistry.Instance.GetService<IScheduleService>();

                    ActionItemDefinition aiDef = actionItemDefinitionService.QueryById(actionitemDefid);
                    if (!aiDef.Deleted)
                    {
                        foreach (IItemSelectablePage page in pages)
                        {
                            if (page is ActionItemDefinitionPage)
                            {
                                ((Com.Suncor.Olt.Client.Controls.Page.ActionItemDefinitionPage)(page)).AddItem(new ActionItemDefinitionDTO(aiDef));

                                if (page.ContainsItemById(actionitemDefid))
                                {
                                    page.SelectSingleItemById(actionitemDefid);
                                }

                                itemSelected = true;
                            }

                        }   
                    }

                }
            }


            if (!itemSelected && !suppressItemNotFoundMesage)
            {
                OltMessageBox.Show(ParentForm, StringResources.ActionItemDefinitionDeleted);   //ItemNotAvailableError,  ayman change action item def is deleted
            }
        }

        private List<IItemSelectablePage> GetPagesThatDisplaysDomainObjectSortedBySelectionOrderThenByVisibleIndex(
            Func<PageInformation, bool> PageMatches,
            string searchDescription)
        {
            List<PageInformation> pagesForDomainObectType = new List<PageInformation>();

            if (Monitor.TryEnter(lockObject, UI_LOCK_TIMEOUT_MS))
            {
                try
                {
                    foreach (PageInformation pageInformation in pageInformationListSortedBySelectionOrderThenByVisibleIndex)
                    {
                        if (PageMatches(pageInformation))
                        {
                            if (pageInformation.Page.CanSelectItemFromAnotherPage)
                            {
                                pagesForDomainObectType.Add(pageInformation);
                            }
                        }
                    }
                }
                finally
                {
                    Monitor.Exit(lockObject);
                }
            }
            else
            {
                logger.Error("Timed out waiting for lock to get page that displays: " + searchDescription);
            }

            return pagesForDomainObectType.ConvertAll(obj => obj.Page);
        }

        private void SelectTabThatContainsControl(Control controlInTab)
        {
            UltraTab tabToSelect = GetTabThatContainsControl(controlInTab);
            if (tabToSelect != null &&
                (tabControl.SelectedTab == null || !ReferenceEquals(tabControl.SelectedTab, tabToSelect)))
            {
                tabControl.SelectedTab = tabToSelect;
            }
        }

        private UltraTab GetTabThatContainsControl(Control controlInTab)
        {
            foreach (UltraTab tab in tabControl.Tabs)
            {
                foreach (Control control in tab.TabPage.Controls)
                {
                    if (control == controlInTab)
                    {
                        return tab;
                    }
                }
            }
            return null;
        }

        public void OnSelect()
        {
            if (Selected != null)
            {
                Selected();
            }
        }

        public bool IsPageVisible(PageKey pageKey)
        {
            bool isVisible = false;

            if (Monitor.TryEnter(lockObject, UI_LOCK_TIMEOUT_MS))
            {
                try
                {
                    foreach (PageInformation pageInformation in pageInformationListSortedBySelectionOrderThenByVisibleIndex)
                    {
                        if (pageInformation.Page.PageKey.Id == pageKey.Id)
                        {
                            isVisible = pageInformation.Page.Visible;
                            break;
                        }
                    }
                }
                finally
                {
                    Monitor.Exit(lockObject);
                }
            }
            else
            {
                logger.Error("Timed out waiting for lock to check if page is visible.  PageKey = " + pageKey.Id);
            }

            return isVisible;
        }

        public IItemSelectablePage SelectedPage
        {
            get
            {
                UltraTab selectedTab = tabControl.SelectedTab;
                if (selectedTab != null)
                {
                    return (IItemSelectablePage) selectedTab.TabPage.Controls[0];
                }
                else
                {
                    return null;
                }
            }
        }

        public IDomainPagePresenter SelectedPagePresenter
        {
            get
            {
                IItemSelectablePage selectedPage = SelectedPage;
                return pagePresenterMap[selectedPage.PageKey];
            }
        }

        public void AddPage(IItemSelectablePage page, IDomainPagePresenter pagePresenter, int defaultSelectOrder)
        {
            if (Monitor.TryEnter(lockObject, ADD_LOCK_TIMEOUT_MS))
            {
                try
                {
                    pageInformationListSortedBySelectionOrderThenByVisibleIndex.Add(
                        new PageInformation(page, tabControl.Tabs.Count, defaultSelectOrder));
                    pageInformationListSortedBySelectionOrderThenByVisibleIndex.Sort(
                        PageInformation.SortBySelectionOrderThenByVisibleIndex);

                    pagePresenterMap.Add(page.PageKey, pagePresenter);
                }
                finally
                {
                    Monitor.Exit(lockObject);
                }
            }
            else
            {
                string message = String.Format("Timed out waiting for lock to add page.  PageKey={0} tabText={1}", page.PageKey.Id, page.TabText);
                logger.Error(message);
                throw new Exception(message);
            }
            AddTabAndPutControlInTab((Control) page, page.TabText);
        }

        private void AddTabAndPutControlInTab(Control control, string tabText)
        {
            ((System.ComponentModel.ISupportInitialize)(tabControl)).BeginInit();
            tabControl.SuspendLayout();

            control.Name = "Page" + tabControl.Tabs.Count;

            control.Dock = DockStyle.Fill;
            control.Padding = new Padding(3);

            string uniqueTabName = "Tab" + tabControl.Tabs.Count;
            UltraTab ultraTab = tabControl.CreateTab(uniqueTabName, tabText);
            ultraTab.TabPage.Controls.Add(control);
            ultraTab.VisibleIndex = tabControl.Tabs.Count - 1;

            UpdateDefaultSelectedTab();

            ((System.ComponentModel.ISupportInitialize)(tabControl)).EndInit();
            tabControl.ResumeLayout(false);
        }

        private void UpdateDefaultSelectedTab()
        {
            IItemSelectablePage defaultSelectedPage = GetDefaultSelectedPage();
            if (defaultSelectedPage != null)
            {
                SelectTabThatContainsControl((Control)defaultSelectedPage);
            }
        }

        private IItemSelectablePage GetDefaultSelectedPage()
        {
            if (pageInformationListSortedBySelectionOrderThenByVisibleIndex.Count == 0)
            {
                return null;
            }
            else
            {
                return pageInformationListSortedBySelectionOrderThenByVisibleIndex[0].Page;
            }
        }

        private class PageInformation
        {
            private readonly IItemSelectablePage page;
            private readonly int visibleIndex;
            private readonly int defaultSelectionOrder;

            public PageInformation(
                IItemSelectablePage page, 
                int visibleIndex, 
                int defaultSelectionOrder)
            {
                this.page = page;
                this.visibleIndex = visibleIndex;
                this.defaultSelectionOrder = defaultSelectionOrder;
            }

            public IItemSelectablePage Page
            {
                get { return page; }
            }


            public Type PageDomainObjectType
            {
                get { return page.PageDtoType; }
            }

            public static int SortBySelectionOrderThenByVisibleIndex(PageInformation x, PageInformation y)
            {
                {
                    int compareResult = x.defaultSelectionOrder.CompareTo(y.defaultSelectionOrder);
                    if (compareResult != 0)
                    {
                        return compareResult;
                    }
                }
                return x.visibleIndex.CompareTo(y.visibleIndex);
            }
        }

    }
}
