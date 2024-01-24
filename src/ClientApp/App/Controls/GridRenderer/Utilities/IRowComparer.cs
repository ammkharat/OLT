using System.Collections;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities
{
    public interface IRowComparer : IComparer
    {
        int Compare(UltraGridRow compareRow, UltraGridRow compareToRow);
    }
}
