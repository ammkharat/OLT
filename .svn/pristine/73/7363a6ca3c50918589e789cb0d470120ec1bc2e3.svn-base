using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class LogFlagImageColumn : AbstractImageBooleanColumn<LogDTO>
    {
        private readonly bool siteSupportsFollowUp;

        private const string COLUMN_KEY = "LogFlagImage";
        private const int COLUMN_WIDTH = 45;

        public LogFlagImageColumn(bool siteSupportsFollowUp)
            : base(
            IsFlagged,
            IsFlagged,
            GetGroupByValue, 
            GetImageMapItems())
        {
            this.siteSupportsFollowUp = siteSupportsFollowUp;
            nameToEntityMap.Add(GetDisplayValue(true), true);
            nameToEntityMap.Add(GetDisplayValue(false), false);
        }

        private static bool IsFlagged(LogDTO item)
        {
            return IsFlaggedForFollowup(item) || IsRecommendedForShiftSummary(item);
        }

        private static bool IsRecommendedForShiftSummary(LogDTO item)
        {
            return item.RecommendForShiftSummary;
        }

        private static bool IsFlaggedForFollowup(LogDTO item)
        {
            return item.InspectionFollowUp
                   || item.ProcessControlFollowUp
                   || item.OperationsFollowUp
                   || item.SupervisionFollowUp
                   || item.EnvironmentalHealthSafetyFollowUp
                   || item.OtherFollowUp;
        }

        private static string GetGroupByValue(LogDTO item)
        {
            return GetDisplayValue(IsFlagged(item));
        }
        
        private static List<IImageMapItem<bool>> GetImageMapItems()
        {
            List<IImageMapItem<bool>> items = new List<IImageMapItem<bool>>();

            items.Add(new ImageMapItem<bool>(true, ResourceUtils.FLAG, GetDisplayValue(true), GetDisplayValue(true)));
            items.Add(new ImageMapItem<bool>(false, ResourceUtils.NO_FLAG, GetDisplayValue(false), GetDisplayValue(false)));

            return items;
        }

        private static string GetDisplayValue(bool isFlagged)
        {
            if (isFlagged)
            {
                return RendererStringResources.FollowUp;
            }
            else
            {
                return RendererStringResources.NoFollowUp;
            }
        }

        public override string ColumnKey
        {
            get { return COLUMN_KEY; }
        }

        public override string ColumnCaption
        {
            get
            {
                if (siteSupportsFollowUp)
                {
                    return RendererStringResources.Flag;    
                }
                else
                {
                    return RendererStringResources.RecommendedForSummaryHeading;
                }                
            }
        }

        protected override int ColumnWidth
        {
            get { return COLUMN_WIDTH; }
        }

        protected override int SortFilterValues(bool x, bool y)
        {
            return y.CompareTo(x);
        }

        protected override string GetToolTipText(LogDTO rowObject)
        {
            if (!IsFlagged(rowObject))
            {
                return GetDisplayValue(false);
            }
            else
            {
                StringBuilder ret = new StringBuilder();

                bool isFlaggedForFollowup = IsFlaggedForFollowup(rowObject);

                if (IsRecommendedForShiftSummary(rowObject))
                {
                    ret.AppendLine(RendererStringResources.RecommendedForSummary_NoNewLines);

                    if (isFlaggedForFollowup)
                    {
                        ret.AppendLine();
                    }
                }
                
                if (isFlaggedForFollowup)
                {
                    ret.AppendLine(RendererStringResources.RequiresFollowUp);
                    ret.AppendLine();

                    if (rowObject.InspectionFollowUp)
                        ret.AppendLine(RendererStringResources.Inspection);

                    if (rowObject.ProcessControlFollowUp)
                        ret.AppendLine(RendererStringResources.ProcessControl);

                    if (rowObject.OperationsFollowUp)
                        ret.AppendLine(RendererStringResources.Operations);

                    if (rowObject.SupervisionFollowUp)
                        ret.AppendLine(RendererStringResources.Supervision);

                    if (rowObject.EnvironmentalHealthSafetyFollowUp)
                        ret.AppendLine(RendererStringResources.EHS);

                    if (rowObject.OtherFollowUp)
                        ret.AppendLine(RendererStringResources.Other);                    
                }


                //
                // Hack: Infragistics UltraGrdCell.ToolTip does not draw the tool tip 
                // properly without the line below.
                //
                ret.AppendLine(" ");

                return ret.ToString();
            }
        }

    }
}
