using System;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls.Section
{
    public interface ISection
    {
        event Action<IItemSelectablePage> SelectedTabChanged;
        event Action Selected;

        void Dispose();
        void DisposePages();

        void AddPage(IItemSelectablePage page, IDomainPagePresenter pagePresenter, int defaultSelectOrder);

        void SelectSingleItem(PageKey pageKey, long domainObjectId, bool suppressItemNotFoundMesage);
        void SelectSingleItem(DomainObject domainObject, bool suppressItemNotFoundMesage);
        void OnSelect();

        bool GetSelectSingleItem(PageKey pageKey, long domainObjectId, bool suppressItemNotFoundMesage);

        bool IsPageVisible(PageKey pageKey);
        IItemSelectablePage SelectedPage { get; }
        IDomainPagePresenter SelectedPagePresenter { get; }
    }
}