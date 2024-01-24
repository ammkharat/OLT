using Com.Suncor.Olt.Client.Controls.Page;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public interface IDomainPagePresenter
    {
        IItemSelectablePage Page { get; }
        void DoInitialDataLoad();
        void LoadDataInForegroundIfNotAlreadyLoaded();
        bool IsDataLoaded { get; }
        void PreviouslyLoadedPageSelected();
    }
}