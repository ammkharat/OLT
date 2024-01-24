using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class FormOilsandsTrainingIrregularHoursImageColumn : AbstractImageBooleanColumn<FormOilsandsTrainingDTO> 
    {
        private const string COLUMN_KEY = "IrregularHoursImage";
        private const int WIDTH = 65;

        public FormOilsandsTrainingIrregularHoursImageColumn()
            : base(obj => obj.IsOutsideIdealNumberOfHours, obj => obj.IsOutsideIdealNumberOfHours, GetGroupByValue, GetImageMapItems())
        {
            nameToEntityMap.Add(GetDisplayValue(true), true);
            nameToEntityMap.Add(GetDisplayValue(false), false);
        }

        private static string GetGroupByValue<T>(T obj) where T : FormOilsandsTrainingDTO
        {
            return GetDisplayValue(obj.IsOutsideIdealNumberOfHours);
        }

        private static List<IImageMapItem<bool>> GetImageMapItems()
        {
            List<IImageMapItem<bool>> items = new List<IImageMapItem<bool>>();

            items.Add(new ImageMapItem<bool>(true, ResourceUtils.FLAG, GetDisplayValue(true), GetDisplayValue(true)));
            items.Add(new ImageMapItem<bool>(false, ResourceUtils.NO_FLAG, GetDisplayValue(false), GetDisplayValue(false)));

            return items;
        }

        private static string GetDisplayValue(bool isOutsideIdealHours)
        {
            return isOutsideIdealHours ? RendererStringResources.HasIrregularHours : string.Empty;
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
            get { return WIDTH; }
        }

        protected override int SortFilterValues(bool x, bool y)
        {
            return y.CompareTo(x);
        }
    }
}
