using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls
{
    public interface IDomainSummaryGrid
    {
        IGridRenderer Renderer { get; }

        void LoadCustomFilters();

        UltraGridLayout DisplayLayout { get; }
        void SelectSingleItemByIndex(int index);
        void SetDefaultGridLayout();
        void SelectItemById(long? id);
    }
}
