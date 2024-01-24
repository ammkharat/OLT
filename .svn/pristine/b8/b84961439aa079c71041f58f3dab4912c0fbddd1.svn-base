using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class ImageColumnComparer<T> : IComparer
    {
        readonly Dictionary<string, T> nameToEntityMap;
        readonly Dictionary<T, IImageMapItem<T>> imageMap;

        public ImageColumnComparer(Dictionary<string, T> nameToEntityMap, Dictionary<T, IImageMapItem<T>> imageMap)
        {
            this.nameToEntityMap = nameToEntityMap;
            this.imageMap = imageMap;
        }

        public int Compare(object x, object y)
        {
            Bitmap theBitmap;
            string theFilterString;

            if (x is string && y is string)
            {
                return string.CompareOrdinal((string)x, (string)y);
            }
            if (x is Bitmap)
            {
                theBitmap = (Bitmap)x;
                theFilterString = (string)y;
            }
            else
            {
                theBitmap = (Bitmap)y;
                theFilterString = (string)x;
            }

            T dataSource = nameToEntityMap[theFilterString];
            IImageMapItem<T> imageMapItem = imageMap[dataSource];

            return theBitmap == imageMapItem.Image ? 0 : 1;
        }
    }

}
