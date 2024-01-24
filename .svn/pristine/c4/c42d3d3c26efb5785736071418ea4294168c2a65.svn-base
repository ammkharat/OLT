using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class IsOnlyVisibleOnReportsImageColumn<TRow> : AbstractImageBooleanColumn<TRow> where TRow : IIsVisible
    {
        private const string COLUMN_KEY = "VisibleImage";
        private const int WIDTH = 50;

        public IsOnlyVisibleOnReportsImageColumn()
            : base(
                obj => obj.IsVisible,
                obj => obj.IsVisible,
                GetGroupByValue,
                GetImageMapItems())
        {
            nameToEntityMap.Add(GetDisplayValue(true), true);
            nameToEntityMap.Add(GetDisplayValue(false), false);
        }

        private static string GetGroupByValue<T>(T obj) where T : IIsVisible
        {
            return GetDisplayValue(obj.IsVisible);
        }

        private static List<IImageMapItem<bool>> GetImageMapItems()
        {
            List<IImageMapItem<bool>> items = new List<IImageMapItem<bool>>
            {
                new ImageMapItem<bool>(true, ResourceUtils.EYE_CLOSED, GetDisplayValue(true), GetDisplayValue(true)),
                new ImageMapItem<bool>(false, ResourceUtils.EYE_OPENED, GetDisplayValue(false), GetDisplayValue(false))
            };

            return items;
        }

        private static string GetDisplayValue(bool isVisibleOnlyOnReports)
        {
            return isVisibleOnlyOnReports ? RendererStringResources.VisibleOnlyOnReports: RendererStringResources.VisibleAlways;
        }

        public override string ColumnKey
        {
            get { return COLUMN_KEY; }
        }

        public override string ColumnCaption
        {
            get { return RendererStringResources.Visible; }
        }

        protected override int ColumnWidth
        {
            get { return WIDTH; }
        }

        protected override int SortFilterValues(bool x, bool y)
        {
            return y.CompareTo(x);
        }
    }
}