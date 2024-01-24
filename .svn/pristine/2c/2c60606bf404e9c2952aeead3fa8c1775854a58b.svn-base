using System.Collections.Generic;
using System.Threading;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Controls.Section;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Common.Domain;
using log4net;

namespace Com.Suncor.Olt.Client.Presenters.Section
{
    public abstract class AbstractSectionPresenter : ISectionPresenter
    {
        private const int DISPOSE_LOCK_TIMEOUT_MS = 40000;
        private const int LOAD_LOCK_TIMEOUT_MS = 20000;

        private static readonly ILog logger = LogManager.GetLogger(typeof(AbstractSectionPresenter));

        private readonly ISection section;

        private readonly object lockObject = new object();
        private readonly Dictionary<PageKey, IDomainPagePresenter> tabPresenter = new Dictionary<PageKey, IDomainPagePresenter>();

        protected AbstractSectionPresenter(ISection section, IEnumerable<IDomainPagePresenter> pagePresenters)
        {
            this.section = section;

            AddPageAndInitializeLoadStateMap(pagePresenters);

            section.Selected += Section_Selected;
            section.SelectedTabChanged += Section_SelectedTabChanged;
        }

        public ISection Section
        {
            get { return section; }
        }

        public void Dispose()
        {
            section.Selected -= Section_Selected;
            section.SelectedTabChanged -= Section_SelectedTabChanged;

            if (Monitor.TryEnter(lockObject, DISPOSE_LOCK_TIMEOUT_MS))
            {
                try
                {
                    tabPresenter.Clear();
                }
                finally
                {
                    Monitor.Exit(lockObject);
                }
            }
            else
            {
                logger.Error("Timed out waiting for lock to clear load state map.");
            }

            section.DisposePages();
            section.Dispose();
        }

        

        private void AddPageAndInitializeLoadStateMap(IEnumerable<IDomainPagePresenter> presenters)
        {
            lock (lockObject)
            {
                foreach (IDomainPagePresenter pagePresenter in presenters)
                {
                    section.AddPage(pagePresenter.Page, pagePresenter, GetDefaultSelectionOrder(pagePresenter.Page));
                    tabPresenter.Add(pagePresenter.Page.PageKey, pagePresenter);
                }
            }
        }

        private static int GetDefaultSelectionOrder(IItemSelectablePage page)
        {
            if (IsPrimaryPage(page))
            {
                return 0;
            }
            if (IsSecondaryPage(page))
            {
                return 1;
            }
            return 2;
        }

        private static bool IsPrimaryPage(IItemSelectablePage page)
        {
            foreach (RoleDisplayConfiguration configuration in ClientSession.GetUserContext().RoleDisplayConfigurations)
            {
                if (configuration.PrimaryPageKey != null && 
                    configuration.PrimaryPageKey.Id == page.PageKey.Id)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsSecondaryPage(IItemSelectablePage page)
        {
            foreach (RoleDisplayConfiguration configuration in ClientSession.GetUserContext().RoleDisplayConfigurations)
            {
                if (configuration.SecondaryPageKey != null &&
                    configuration.SecondaryPageKey.Id == page.PageKey.Id)
                {
                    return true;
                }
            }
            return false;
        }

        // this is here just in case the selected tab changed event did not fire properly for the very first load
        private void Section_Selected()
        {
            IItemSelectablePage selectedPage = section.SelectedPage;
            if (selectedPage != null)
            {
                LoadTabPage(selectedPage);
            }
        }

        private void Section_SelectedTabChanged(IItemSelectablePage page)
        {
            LoadTabPage(page);
        }

        private void LoadTabPage(IItemSelectablePage page)
        {
            if (Monitor.TryEnter(lockObject, LOAD_LOCK_TIMEOUT_MS))
            {
                try
                {
                    bool containsKey = tabPresenter.ContainsKey(page.PageKey);
                    bool isDataLoaded = tabPresenter[page.PageKey].IsDataLoaded;

                    if (containsKey && !isDataLoaded)
                    {
                        tabPresenter[page.PageKey].DoInitialDataLoad();
                    }
                    
                    if (containsKey && isDataLoaded)
                    {
                        IDomainPagePresenter domainPagePresenter = tabPresenter[page.PageKey];
                        domainPagePresenter.PreviouslyLoadedPageSelected();
                    }
                }
                finally
                {
                    Monitor.Exit(lockObject);
                }
            }
            else
            {
                logger.Error("Timed out waiting for lock to load page: " + page.PageKey.TabText);
            }
        }

    }
}