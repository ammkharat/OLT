using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class ScheduleTypeImageColumn<TRow> : AbstractImageBooleanColumn<TRow> where TRow : IHasSchedule
    {
        private const string COLUMN_KEY = "ScheduleTypeImage";

        public ScheduleTypeImageColumn() : base(
            obj => obj.IsRecurring, 
            obj => obj.IsRecurring,
            GetGroupByValue, 
            GetImageMapItems())
        {
            nameToEntityMap.Add(GetDisplayValue(true), true);
            nameToEntityMap.Add(GetDisplayValue(false), false);
        }

        private static string GetGroupByValue<T>(T obj) where T : IHasSchedule
        {
            return GetDisplayValue(obj.IsRecurring);
        }
        
        private static List<IImageMapItem<bool>> GetImageMapItems()
        {
            List<IImageMapItem<bool>> items = new List<IImageMapItem<bool>>();

            items.Add(new ImageMapItem<bool>(true, ResourceUtils.RECURRING, GetDisplayValue(true), GetDisplayValue(true)));
            items.Add(new ImageMapItem<bool>(false, ResourceUtils.SINGLE, GetDisplayValue(false), GetDisplayValue(false)));

            return items;
        }

        private static string GetDisplayValue(bool isRecurring)
        {
            if (isRecurring)
            {
                return RendererStringResources.Recurring;
            }
            else
            {
                return RendererStringResources.Single;
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
            get { return ResourceUtils.RECURRING.Width + 5; }  // add 5 because otherwise on Windows 7 the image would render in a messed up manner
        }

        protected override int SortFilterValues(bool x, bool y)
        {
            return y.CompareTo(x);
        }
    }
}
