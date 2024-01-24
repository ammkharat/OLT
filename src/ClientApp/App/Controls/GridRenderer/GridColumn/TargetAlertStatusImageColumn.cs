using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class TargetAlertStatusImageColumn : StatusImageColumn<TargetAlertDTO, TargetAlertStatus>
    {
        public TargetAlertStatusImageColumn() : base(RendererStringResources.State, GetImageMapItems())
        {
            nameToEntityMap.Add(TargetAlertStatus.NeverToExceedAlert.Name, TargetAlertStatus.NeverToExceedAlert);
            nameToEntityMap.Add(TargetAlertStatus.StandardAlert.Name, TargetAlertStatus.StandardAlert);
            nameToEntityMap.Add(TargetAlertStatus.Acknowledged.Name, TargetAlertStatus.Acknowledged);
        }

        public static List<IImageMapItem<TargetAlertStatus>> GetImageMapItems()
        {
            List<IImageMapItem<TargetAlertStatus>> items = new List<IImageMapItem<TargetAlertStatus>>();

            items.Add(new SortableSimpleDomainObjectImageMapItem<TargetAlertStatus>(TargetAlertStatus.NeverToExceedAlert, ResourceUtils.NTE_ALERT));
            items.Add(new SortableSimpleDomainObjectImageMapItem<TargetAlertStatus>(TargetAlertStatus.StandardAlert, ResourceUtils.ALERT));
            items.Add(new SortableSimpleDomainObjectImageMapItem<TargetAlertStatus>(TargetAlertStatus.Acknowledged, ResourceUtils.ACKNOWLEDGED));

            return items;
        }
    }
}
