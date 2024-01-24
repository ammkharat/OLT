using System.Drawing;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class ImageMapItem<T> : IImageMapItem<T>
    {
        private readonly T key;
        private readonly Bitmap image;
        private readonly string toolTip;
        private readonly string filterItemDisplayName;

        public ImageMapItem(T key, Bitmap image, string toolTip, string filterItemDisplayName)
        {
            this.key = key;
            this.image = image;
            this.toolTip = toolTip;
            this.filterItemDisplayName = filterItemDisplayName;
        }

        public T Key
        {
            get { return key; }
        }

        public Bitmap Image
        {
            get { return image; }
        }

        public string ToolTip
        {
            get { return toolTip; }
        }

        public string FilterItemDisplayName
        {
            get { return filterItemDisplayName; }
        }
    }
}
