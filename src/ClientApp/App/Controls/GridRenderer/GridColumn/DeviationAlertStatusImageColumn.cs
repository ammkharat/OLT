using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class DeviationAlertStatusImageColumn : AbstractImageGridColumn<DeviationAlertDTO, DeviationAlertStatus, DeviationAlertStatus, string> 
    {
        private const string COLUMN_KEY = "StatusImage";
        private const int WIDTH = 50;

        protected readonly Dictionary<string, DeviationAlertStatus> nameToEntityMap = new Dictionary<string, DeviationAlertStatus>(); 

        public DeviationAlertStatusImageColumn() : base(
            obj => obj.GetStatus(ClientSession.GetUserContext().UserShift),
            ConvertRowToSortValue,
            ConvertRowToGroupByValue,
            GetImageMapItems())
        {
            nameToEntityMap.Add(DeviationAlertStatus.RequiresResponseIsLate.Name, DeviationAlertStatus.RequiresResponseIsLate);
            nameToEntityMap.Add(DeviationAlertStatus.RequiresResponse.Name, DeviationAlertStatus.RequiresResponse);
            nameToEntityMap.Add(DeviationAlertStatus.Responded.Name, DeviationAlertStatus.Responded);
            nameToEntityMap.Add(DeviationAlertStatus.AutomaticallyRespondedForPositiveDeviation.Name, DeviationAlertStatus.AutomaticallyRespondedForPositiveDeviation);
        }

        public static List<IImageMapItem<DeviationAlertStatus>> GetImageMapItems()
        {
            List<IImageMapItem<DeviationAlertStatus>> items = new List<IImageMapItem<DeviationAlertStatus>>();

            items.Add(new SortableSimpleDomainObjectImageMapItem<DeviationAlertStatus>(DeviationAlertStatus.RequiresResponseIsLate, ResourceUtils.LATE_ALERT));
            items.Add(new SortableSimpleDomainObjectImageMapItem<DeviationAlertStatus>(DeviationAlertStatus.RequiresResponse, ResourceUtils.ALERT));
            items.Add(new SortableSimpleDomainObjectImageMapItem<DeviationAlertStatus>(DeviationAlertStatus.Responded, ResourceUtils.RESPONDED));
            items.Add(new SortableSimpleDomainObjectImageMapItem<DeviationAlertStatus>(DeviationAlertStatus.AutomaticallyRespondedForPositiveDeviation, ResourceUtils.POSITIVE_DEVIATION));

            return items;
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

        protected override void AddFilterItemValueInformationToList(ValueListItemsCollection valueListItems, DeviationAlertStatus key)
        {
            ValueListItem valueListItem = valueListItems.Add(imageMap[key].FilterItemDisplayName, imageMap[key].FilterItemDisplayName);
            valueListItem.DataValue = imageMap[key].FilterItemDisplayName;
        }

        public override void AddFilterComparer(UltraGridColumn column)
        {
            column.RowFilterComparer = new ImageColumnComparer<DeviationAlertStatus>(nameToEntityMap, imageMap);
        }

        private static DeviationAlertStatus ConvertRowToSortValue(DeviationAlertDTO dto)
        {
            DeviationAlertStatus status = dto.GetStatus(ClientSession.GetUserContext().UserShift);
            if (status == DeviationAlertStatus.AutomaticallyRespondedForPositiveDeviation)
            {
                return DeviationAlertStatus.Responded;
            }
            else
            {
                return status;
            }
        }

        private static string ConvertRowToGroupByValue(DeviationAlertDTO dto)
        {
            DeviationAlertStatus status = dto.GetStatus(ClientSession.GetUserContext().UserShift);
            if (status == DeviationAlertStatus.Responded ||
                status == DeviationAlertStatus.AutomaticallyRespondedForPositiveDeviation)
            {
                return
                    DeviationAlertStatus.Responded.Name + " / " +
                    DeviationAlertStatus.AutomaticallyRespondedForPositiveDeviation.Name;
            }
            else
            {
                return status.Name;
            }
        }
    }
}
