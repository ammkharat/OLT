using System;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.MultiGrid;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Client.Presenters.Page
{     
    // NOTES:
    // A lot of what's here, like search stuff, should probably be moved to a new base class that is shared by this and the normal abstractpagepresenter.
    public abstract class AbstractMultiGridPagePresenter : IDomainPagePresenter
    {
        private readonly ILog logger = GenericLogManager.GetLogger<AbstractMultiGridPagePresenter>();

        private readonly UserContext userContext;
        protected AbstractMultiGridPage page;
        private IRemoteEventRepeater remoteEventRepeater;
        private readonly IUserService userService;
                        
        protected AbstractMultiGridPagePresenter(
            AbstractMultiGridPage page, 
            IRemoteEventRepeater remoteEventRepeater,
            IUserService userService)
        {
            userContext = ClientSession.GetUserContext();
            this.page = page;
            this.remoteEventRepeater = remoteEventRepeater;
            this.userService = userService;
        }

        public bool IsDataLoaded
        {
            get { return page.CurrentGridContext != null && page.CurrentGridContext.IsDataLoaded; }
        }

        public void PreviouslyLoadedPageSelected()
        {
        }

        public IItemSelectablePage Page
        {
             get { return page; }
        }

        public void DoInitialDataLoad()
        {
            bool firstTimeLoad = page.CurrentGridContext == null;
          
            if (firstTimeLoad)
            {
                page.CurrentGridContext = GetInitialGridContext();
            }
            
            page.SetGridAndDetails(page.CurrentGridContext.Grid, page.CurrentGridContext.Details);

            try
            {
                page.CurrentGridContext.RefreshData(true);
            }
            catch (Exception e)
            {
                logger.Error("There was an exception refreshing data. Removing page layouts and trying again", e);
                RemovePageLayouts();
                page.CurrentGridContext.RefreshData(true);
            }
            
            // call this manually once to make sure that the details and buttons are in the correct state
            ControlShowingOfDetailsPane();
            ControlDetailButtons();

            // subscribe to events after loading the data so that we don't get selected item change events 
            // more than once
            if (firstTimeLoad)
            {
                SubscribeToEvents();

                if (remoteEventRepeater != null)
                {
                    HookToServiceEvents(remoteEventRepeater);
                }
            }

            page.CurrentGridContext.IsDataLoaded = true;
        }

        private void RemovePageLayouts()
        {
            logger.Warn("Removing grid layouts for user: " + userContext.User.FullNameWithUserName);
            userService.DeleteGridLayoutsForUser(userContext.User.IdValue);
            userContext.ClearGridLayoutCache();
        }

        private void SubscribeContextsToEvents()
        {
            foreach (IMultiGridContext context in page.AllContexts)
            {
                context.SubscribeToEvents();
            }            
        }

        private void UnsubscribeContextsFromEvents()
        {
            foreach (IMultiGridContext context in page.AllContexts)
            {
                context.UnSubscribeFromEvents();
            }            

        }

        private void HookToServiceEvents(IRemoteEventRepeater repeater)
        {
            foreach (IMultiGridContext context in page.AllContexts)
            {
                context.HookToServiceEvents(repeater);
            }
        }

        private void UnHookToServiceEvents(IRemoteEventRepeater repeater)
        {
            foreach (IMultiGridContext context in page.AllContexts)
            {
                context.UnHookToServiceEvents(repeater);
            }
        }

        protected abstract IMultiGridContext GetInitialGridContext();

        public void LoadDataInForegroundIfNotAlreadyLoaded()
        {
            if (!IsDataLoaded)
            {
                DoInitialDataLoad();
            }
        }

        private void SubscribeToEvents()
        {
            SubscribeContextsToEvents();

            page.SelectedGridChanged += HandleSelectedGridChanged;

            page.DetailsChanged += Details_Changed;
            page.ButtonsChanged += Buttons_Changed;
            
            page.SearchButtonClicked += HandleSearchButtonClicked;
            page.CancelSearchButtonClicked += HandleCancelSearchButtonClicked;

            page.Disposed += Page_Disposed;
        }

        private void UnSubscribeFromEvents()
        {
            UnsubscribeContextsFromEvents();

            page.SelectedGridChanged -= HandleSelectedGridChanged;

            page.DetailsChanged -= Details_Changed;
            page.ButtonsChanged -= Buttons_Changed;

            page.SearchButtonClicked -= HandleSearchButtonClicked;
            page.CancelSearchButtonClicked -= HandleCancelSearchButtonClicked;

            page.Disposed -= Page_Disposed;
        }
       
        private void HandleSelectedGridChanged(IMultiGridContextSelection gridType)
        {   
            //TODO
            //generic template - mangesh - as the same record is showing in all the forms grid
            long fId = ((SimpleDomainObject)(gridType)).Value;
            var name = FormGenericTemplate.getEdmontonFormType(fId);
            if (name != null)
            {
                page.CurrentGridContext.DataNeedsRefresh = true;
                //page.MainParentForm.CreateNewItemVisible = false;
            }
           //----------------------------------------------
            page.CurrentGridContext = ChangeContext(gridType);
            
            if (page.CurrentGridContext.DataNeedsRefresh)
            {
                DoInitialDataLoad();
                page.CurrentGridContext.DataNeedsRefresh = false;
                return;
            }


            //ayman Sarnia eip - 2
            if (ClientSession.GetUserContext().IsSarniaSite)
            {
                DoInitialDataLoad();
            }

            if(!page.CurrentGridContext.IsDataLoaded)
            {
                DoInitialDataLoad();
            }
            else
            {
                page.SearchText = page.CurrentGridContext.MostRecentSearchTerm;               
                page.CurrentGridContext.SetPageTitle();
            }


        }

        protected abstract IMultiGridContext ChangeContext(IMultiGridContextSelection gridContextSelection);
       
        private void HandleSearchButtonClicked(string searchTerm)
        {
            page.CurrentGridContext.ApplySearchTerm(searchTerm, HandleCancelSearchButtonClicked);
        }

        private void HandleCancelSearchButtonClicked()
        {
            page.CurrentGridContext.ResetSearchBox();
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

        private void Details_Changed(object sender, EventArgs e)
        {
            ControlShowingOfDetailsPane();
        }

        private void Buttons_Changed(object sender, EventArgs e)
        {
            ControlDetailButtons();
        }

        private void ControlDetailButtons()
        {
            page.CurrentGridContext.ControlDetailButtons();
        }

        private void ControlShowingOfDetailsPane()
        {
            page.CurrentGridContext.ControlShowingOfDetailsPane();
        }
    }
}