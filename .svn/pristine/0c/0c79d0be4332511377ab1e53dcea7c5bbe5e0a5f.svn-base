using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IBusinessCategoryView : IBaseForm
    {
        List<BusinessCategory> Items { set; }
        BusinessCategory SelectedBusinessCategory { get; }
        void SelectBusinessCategory(BusinessCategory reasonCodeToSelect);
        void RebindGrid();
        void ClearErrors();
        void SetGridDataError(string errorMessage);
    }
}