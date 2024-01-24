using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class RoadAccessOnPermitFormPresenter : AbstractFormPresenter<ICraftOrTradeView, CraftOrTrade>
    {
        private readonly ICraftOrTradeService craftOrTradeService;

        public RoadAccessOnPermitFormPresenter(ICraftOrTradeView view)
            : this(view, null)
        {
        }

        public RoadAccessOnPermitFormPresenter(ICraftOrTradeView view, CraftOrTrade craftOrTradeToEdit)
            : this(view, craftOrTradeToEdit, ClientServiceRegistry.Instance.GetService<ICraftOrTradeService>())
        {
        }

        public RoadAccessOnPermitFormPresenter(
            ICraftOrTradeView view, 
            CraftOrTrade craftOrTradeToEdit,
            ICraftOrTradeService craftOrTradeService)
            : base(view, craftOrTradeToEdit)
        {
            this.craftOrTradeService = craftOrTradeService;
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            Site site = userContext.Site;
            view.CraftOrTradeSite = site.Name;
            
            if (IsEdit)
            {
                UpdateViewFromEditObject();
            }
            else
            {
                UpdateViewWithDefaults();
            }
        }

        private void UpdateViewFromEditObject()
        {
            view.CraftOrTradeName = editObject.Name;
            view.WorkCentre = editObject.WorkCenterCode;
            view.ViewTitle = StringResources.RoadAccessOnPermitFormEditTitle;
        }

        protected void UpdateViewWithDefaults()
        {
            view.ViewTitle = StringResources.RoadAccessOnPermitFormCreateTitle;
        }

        public override void HandleSaveAndCloseButtonClick(object sender, EventArgs eventArgs)
        {
            SaveOrUpdate(true);            
        }

        protected override void SaveOrUpdateComplete(bool saveOrUpdateSucceeded)
        {
            if (saveOrUpdateSucceeded)
            {
                view.SetDialogResultOK();
            }
        }

        public override void Insert(SaveUpdateDomainObjectContainer<CraftOrTrade> craftOrTrade)
        {            
            craftOrTradeService.InsertRoadAccesOnPermit(craftOrTrade.Item);
        }

        public override void Update(SaveUpdateDomainObjectContainer<CraftOrTrade> craftOrTrade)
        {
            craftOrTradeService.UpdateRoadAccesOnPermit(craftOrTrade.Item);
        }

        protected override SaveUpdateDomainObjectContainer<CraftOrTrade> GetPopulatedEditObjectToUpdate()
        {
            editObject.Name = view.CraftOrTradeName;
            editObject.WorkCenterCode = view.WorkCentre;
            return new SaveUpdateDomainObjectContainer<CraftOrTrade>(editObject);
        }

        protected override SaveUpdateDomainObjectContainer<CraftOrTrade> GetNewObjectToInsert()
        {
            CraftOrTrade craftOrTrade = new CraftOrTrade(view.CraftOrTradeName, view.WorkCentre, userContext.SiteId);
            return new SaveUpdateDomainObjectContainer<CraftOrTrade>(craftOrTrade);
        }

        public override bool ValidateViewHasError()
        {
            view.ClearErrorProviders();

            bool hasError = false;

            string name = view.CraftOrTradeName;
           
            if (name.IsNullOrEmptyOrWhitespace())
            {
                view.ShowNameIsEmptyError();
                hasError = true;
            }            
            else 
            {
                CraftOrTrade duplicateCraftOrTrade =
                    craftOrTradeService.QueryRoadAccessOnPermitByWorkCentreAndNameAndSiteId(view.WorkCentre, name, userContext.SiteId);
                                
                if (duplicateCraftOrTrade != null)
                {
                    if (!IsEdit || (IsEdit && editObject.Id != duplicateCraftOrTrade.Id))
                    {
                        view.ShowDuplicateCraftOrTradeError();
                        hasError = true;
                    }
                }
            }
            
            return hasError;
        }
    }
}