using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class IsActiveImageColumn<TRow> : AbstractImageBooleanColumn<TRow> where TRow : IIsActive
    {
        private const string COLUMN_KEY = "ActiveImage";
        private const int WIDTH = 50;

        public IsActiveImageColumn() : base(
            obj => obj.IsActive, 
            obj => obj.IsActive, 
            GetGroupByValue,
            GetImageMapItems())
        {
            nameToEntityMap.Add(GetDisplayValue(true), true);
            nameToEntityMap.Add(GetDisplayValue(false), false);
        }

        private static string GetGroupByValue<T>(T obj) where T : IIsActive
        {
            return GetDisplayValue(obj.IsActive);
        }

        private static List<IImageMapItem<bool>> GetImageMapItems()
        {
            List<IImageMapItem<bool>> items = new List<IImageMapItem<bool>>
            {
                new ImageMapItem<bool>(true, ResourceUtils.ACTIVE, GetDisplayValue(true), GetDisplayValue(true)),
                new ImageMapItem<bool>(false, ResourceUtils.INACTIVE, GetDisplayValue(false), GetDisplayValue(false))
            };

            return items;
        }

        private static string GetDisplayValue(bool isActive)
        {
            return isActive ? RendererStringResources.Active : RendererStringResources.Inactive;
        }

        public override string ColumnKey
        {
            get { return COLUMN_KEY; }
        }

        public override string ColumnCaption
        {
            get { return RendererStringResources.Active; }
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