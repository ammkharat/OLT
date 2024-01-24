
using System.Collections;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public interface IImageGridColumn
    {
        string ColumnKey { get; }
        string ColumnCaption { get; }

        IComparer SortComparer { get; }
        IGroupByEvaluator GroupByEvaluator { get; }

        void AddToBand(UltraGridBand band);
        void SetCellValue(UltraGridRow row);
        void AddFilterItems(ValueList valueList);
        void AddFilterComparer(UltraGridColumn column);
    }
}
