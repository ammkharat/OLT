using System.Drawing;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public interface IImageMapItem<T>
    {
        T Key { get; }
        Bitmap Image { get; }
        string ToolTip { get; }
        string FilterItemDisplayName { get; }
    }
}
