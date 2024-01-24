using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigureCraftOrTradePresenter
    {
        private readonly IConfigureCraftOrTradeView view;
        private readonly ICraftOrTradeService craftOrTradeService;
        private readonly Site site;

        public ConfigureCraftOrTradePresenter(IConfigureCraftOrTradeView view, ICraftOrTradeService craftOrTradeService)
        {
            this.view = view;
            this.craftOrTradeService = craftOrTradeService;
            site = ClientSession.GetUserContext().Site;
        }

        public ConfigureCraftOrTradePresenter(IConfigureCraftOrTradeView view) : 
            this (view, ClientServiceRegistry.Instance.GetService<ICraftOrTradeService>())
        {
        }

        public void RegisterToViewEvents()
        {
            view.Load += HandleLoad;
            view.New += HandleNew;
            view.Edit += HandleEdit;
            view.Delete += HandleDelete;
            view.EditDoubleClick += HandleEditDoubleClick;
        }

        public void HandleLoad(object sender, EventArgs e)
        {
            view.CraftOrTradeSite = site.Name;
            view.CraftOrTrades = craftOrTradeService.QueryBySiteNoCache(site);
        }
        
        public void HandleNew(object sender, EventArgs e)
        {
            New();
        }
        
        public void New()
        {
            DialogResult result = view.CreateNewCraftOrTrade();
            if (DialogResult.OK == result)
            {
                List<CraftOrTrade> loadedCraftOrTrades = craftOrTradeService.QueryBySiteNoCache(site);
                view.CraftOrTrades = loadedCraftOrTrades;
                SelectLastCreatedCraftOrTrade(loadedCraftOrTrades);
            }                      
        }

        public void HandleEdit(object sender, EventArgs e)
        {
            Edit(view.SelectedCraftOrTrade);
        }

        public void HandleEditDoubleClick(object sender, DomainEventArgs<CraftOrTrade> e)
        {
            Edit(e.SelectedItem);    
        }
        
        public void Edit(CraftOrTrade selectedCraftOrTrade)
        {            
            if (selectedCraftOrTrade == null) return;
            
            DialogResult result = view.EditCraftOrTrade(selectedCraftOrTrade);
            if (DialogResult.OK == result)
            {
                view.CraftOrTrades = craftOrTradeService.QueryBySiteNoCache(site);
                view.SelectedCraftOrTrade = selectedCraftOrTrade;
            }
        }

        public void HandleDelete(object sender, EventArgs e)
        {
            Delete();
        }
        
        public void Delete()
        {
            CraftOrTrade selectedCraftOrTrade = view.SelectedCraftOrTrade;
            if (selectedCraftOrTrade != null)
            {
                craftOrTradeService.Remove(selectedCraftOrTrade);
                view.CraftOrTrades = craftOrTradeService.QueryBySiteNoCache(site);                
            }
        }

        private void SelectLastCreatedCraftOrTrade(List<CraftOrTrade> craftOrTrades)
        {
            craftOrTrades.Sort(SortById);
            if (craftOrTrades.Count != 0)
            {
                view.SelectedCraftOrTrade = craftOrTrades.Last();
            }
        }

        private static int SortById(CraftOrTrade x, CraftOrTrade y)
        {
            return Nullable.Compare(x.Id, y.Id);
        }
        
        public static string CreateLockIdentifier(Site site)
        {
            return "Configure Craft/Trades: " + site.Id;
        }

    }
}
