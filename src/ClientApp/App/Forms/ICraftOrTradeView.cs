namespace Com.Suncor.Olt.Client.Forms
{
    public interface ICraftOrTradeView : IBaseForm
    {
        string CraftOrTradeName { get; set; }
        string WorkCentre { get; set; }
        string CraftOrTradeSite { set; }
        string ViewTitle { set; }

        void ShowNameIsEmptyError();
        void ShowDuplicateCraftOrTradeError();
        void ClearErrorProviders();
        
        void SetDialogResultOK();
    }
}