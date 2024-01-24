using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class PermitAssessmentYesAnswerImageColumn : AbstractImageBooleanColumn<PermitAssessmentDTO>
    {
        private const string COLUMN_KEY = "HasYesAnswer";
        private const int WIDTH = 65;

        public PermitAssessmentYesAnswerImageColumn()
            : base(obj => obj.HasYesAnswer, obj => obj.HasYesAnswer, GetGroupByValue, GetImageMapItems())
        {
            nameToEntityMap.Add(GetDisplayValue(true), true);
            nameToEntityMap.Add(GetDisplayValue(false), false);
        }

        private static string GetGroupByValue<T>(T obj) where T : PermitAssessmentDTO
        {
            return GetDisplayValue(obj.HasYesAnswer);
        }

        private static List<IImageMapItem<bool>> GetImageMapItems()
        {
            List<IImageMapItem<bool>> items = new List<IImageMapItem<bool>>
            {
                new ImageMapItem<bool>(true, ResourceUtils.FLAG, GetDisplayValue(true), GetDisplayValue(true)),
                new ImageMapItem<bool>(false, ResourceUtils.NO_FLAG, GetDisplayValue(false), GetDisplayValue(false))
            };

            return items;
        }

        private static string GetDisplayValue(bool hasYesAnswer)
        {
            return hasYesAnswer ? RendererStringResources.IlpIsRecommended : RendererStringResources.IlpIsNotRecommended;
        }

        public override string ColumnKey
        {
            get { return COLUMN_KEY; }
        }

        public override string ColumnCaption
        {
            get { return "Has Yes Answer"; }
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
