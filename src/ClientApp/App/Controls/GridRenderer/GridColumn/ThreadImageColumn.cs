using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class ThreadImageColumn<TDto> : AbstractImageBooleanColumn<TDto> where TDto : IThreadableDTO
    {
        private const string COLUMN_KEY = "ThreadedImage";
        private const int COLUMN_WIDTH = 45;

        public ThreadImageColumn()
            : base(
            obj => obj.IsPartOfThread,
            obj => obj.IsPartOfThread,
            GetGroupByValue, 
            GetImageMapItems())
        {
            nameToEntityMap.Add(GetDisplayValue(true), true);
            nameToEntityMap.Add(GetDisplayValue(false), false);
        }

        private static string GetGroupByValue(TDto obj)
        {
            return GetDisplayValue(obj.IsPartOfThread);
        }
        
        private static List<IImageMapItem<bool>> GetImageMapItems()
        {
            List<IImageMapItem<bool>> items = new List<IImageMapItem<bool>>();

            items.Add(new ImageMapItem<bool>(true, ResourceUtils.THREAD, GetDisplayValue(true), GetDisplayValue(true)));
            items.Add(new ImageMapItem<bool>(false, ResourceUtils.NOT_IN_THREAD, GetDisplayValue(false), GetDisplayValue(false)));

            return items;
        }

        private static string GetDisplayValue(bool isPartOfThread)
        {
            if (isPartOfThread)
            {
                return RendererStringResources.InThread;
            }
            else
            {
                return RendererStringResources.NotInThread;
            }
        }

        public override string ColumnKey
        {
            get { return COLUMN_KEY; }
        }

        public override string ColumnCaption
        {
            get { return string.Empty; }
        }

        protected override int ColumnWidth
        {
            get { return COLUMN_WIDTH; }
        }

        protected override int SortFilterValues(bool x, bool y)
        {
            return y.CompareTo(x);
        }
    }
}
