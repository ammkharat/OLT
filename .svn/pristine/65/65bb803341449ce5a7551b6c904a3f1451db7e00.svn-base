using System.Collections.Generic;
using Com.Suncor.Olt.Client.Localization;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class LabAlertStatusImageColumn : AbstractImageGridColumn<LabAlertDTO, LabAlertStatus, LabAlertStatus, string>
    {
        private const string COLUMN_KEY = "StatusImage";
        private const int WIDTH = 50;

        protected readonly Dictionary<string, LabAlertStatus> nameToEntityMap = new Dictionary<string, LabAlertStatus>(); 

        public LabAlertStatusImageColumn() : base(
            obj => obj.GetStatus(ClientSession.GetUserContext().UserShift),
            obj => obj.GetStatus(ClientSession.GetUserContext().UserShift),
            obj => obj.GetStatus(ClientSession.GetUserContext().UserShift).Name,
            GetImageMapItems())
        {
            nameToEntityMap.Add(LabAlertStatus.DataUnavailableLate.Name, LabAlertStatus.DataUnavailableLate);
            nameToEntityMap.Add(LabAlertStatus.NotRespondedLate.Name, LabAlertStatus.NotRespondedLate);
            nameToEntityMap.Add(LabAlertStatus.DataUnavailable.Name, LabAlertStatus.DataUnavailable);
            nameToEntityMap.Add(LabAlertStatus.NotResponded.Name, LabAlertStatus.NotResponded);
            nameToEntityMap.Add(LabAlertStatus.Responded.Name, LabAlertStatus.Responded);
        }

        public static List<IImageMapItem<LabAlertStatus>> GetImageMapItems()
        {
            List<IImageMapItem<LabAlertStatus>> items = new List<IImageMapItem<LabAlertStatus>>();

            items.Add(new SortableSimpleDomainObjectImageMapItem<LabAlertStatus>(LabAlertStatus.DataUnavailableLate, ResourceUtils.ALERT_DATA_UNAVAILABLE_LATE));
            items.Add(new SortableSimpleDomainObjectImageMapItem<LabAlertStatus>(LabAlertStatus.NotRespondedLate, ResourceUtils.LATE_ALERT));
            items.Add(new SortableSimpleDomainObjectImageMapItem<LabAlertStatus>(LabAlertStatus.DataUnavailable, ResourceUtils.ALERT_DATA_UNAVAILABLE));
            items.Add(new SortableSimpleDomainObjectImageMapItem<LabAlertStatus>(LabAlertStatus.NotResponded, ResourceUtils.ALERT));
            items.Add(new SortableSimpleDomainObjectImageMapItem<LabAlertStatus>(LabAlertStatus.Responded, ResourceUtils.RESPONDED));

            return items;
        }

        protected override void AddFilterItemValueInformationToList(ValueListItemsCollection valueListItems, LabAlertStatus key)
        {
            ValueListItem valueListItem = valueListItems.Add(imageMap[key].FilterItemDisplayName, imageMap[key].FilterItemDisplayName);
            valueListItem.DataValue = imageMap[key].FilterItemDisplayName;
        }
        
        public override void AddFilterComparer(UltraGridColumn column)
        {
            column.RowFilterComparer = new ImageColumnComparer<LabAlertStatus>(nameToEntityMap, imageMap);
        }

        public override string ColumnKey
        {
            get { return COLUMN_KEY; }
        }

        public override string ColumnCaption
        {
            get { return RendererStringResources.State; }
        }

        protected override int ColumnWidth
        {
            get { return WIDTH; }
        }

    }
}
