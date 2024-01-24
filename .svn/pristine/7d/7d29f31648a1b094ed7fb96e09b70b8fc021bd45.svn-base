using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class ShiftSummaryItemSourceImageColumn : SortableSimpleDomainObjectImageColumn<IShiftSummaryItemGridDisplayAdapter, ShiftSummaryItemSource>
    {
        private const int WIDTH = 50;

        private readonly string columnCaption;        

        public ShiftSummaryItemSourceImageColumn(string columnCaption)
            : base(obj => obj.Source, GetImageMapItems())
        {
            this.columnCaption = columnCaption;

            foreach (IImageMapItem<ShiftSummaryItemSource> item in GetImageMapItems())
            {
                nameToEntityMap.Add(item.Key.Name, item.Key);
            }
        }

        public static List<IImageMapItem<ShiftSummaryItemSource>> GetImageMapItems()
        {
            return new List<IImageMapItem<ShiftSummaryItemSource>>
                       {
                           new SortableSimpleDomainObjectImageMapItem<ShiftSummaryItemSource>(ShiftSummaryItemSource.HandoverLog, ResourceUtils.HANDOVER_SMALL),
                           new SortableSimpleDomainObjectImageMapItem<ShiftSummaryItemSource>(ShiftSummaryItemSource.HandoverQuestions, ResourceUtils.HANDOVER_QUESTIONS),
                           new SortableSimpleDomainObjectImageMapItem<ShiftSummaryItemSource>(ShiftSummaryItemSource.ShiftLog, ResourceUtils.MANUAL),
                           //add new shift log summary to filter ayman 
                          // new SortableSimpleDomainObjectImageMapItem<ShiftSummaryItemSource>(ShiftSummaryItemSource.ShiftLogSummary, ResourceUtils.MANUAL),
                           new SortableSimpleDomainObjectImageMapItem<ShiftSummaryItemSource>(ShiftSummaryItemSource.TargetAlertResponse, ResourceUtils.TARGET),
                           new SortableSimpleDomainObjectImageMapItem<ShiftSummaryItemSource>(ShiftSummaryItemSource.ActionItemResponse, ResourceUtils.ACTION_ITEM),
                           new SortableSimpleDomainObjectImageMapItem<ShiftSummaryItemSource>(ShiftSummaryItemSource.SafeWorkPermit, ResourceUtils.PERMIT),
                           new SortableSimpleDomainObjectImageMapItem<ShiftSummaryItemSource>(ShiftSummaryItemSource.LabAlertResponse, ResourceUtils.LAB_ALERT),
                           new SortableSimpleDomainObjectImageMapItem<ShiftSummaryItemSource>(ShiftSummaryItemSource.SapNotificationLog, ResourceUtils.SAP)
                       };
        }
        
        public override string ColumnKey
        {
            get { return "SourceImage"; }
        }

        public override string ColumnCaption
        {
            get { return columnCaption; }
        }

        protected override int ColumnWidth
        {
            get { return WIDTH; }
        }
    }
}
