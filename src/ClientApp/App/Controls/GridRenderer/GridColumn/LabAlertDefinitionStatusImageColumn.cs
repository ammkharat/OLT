using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class LabAlertDefinitionStatusImageColumn : StatusImageColumn<LabAlertDefinitionDTO, LabAlertDefinitionStatus>
    {
        public LabAlertDefinitionStatusImageColumn() : base(RendererStringResources.Status, GetImageMapItems())
        {
            nameToEntityMap.Add(LabAlertDefinitionStatus.Valid.Name, LabAlertDefinitionStatus.Valid);
            nameToEntityMap.Add(LabAlertDefinitionStatus.InvalidTag.Name, LabAlertDefinitionStatus.InvalidTag);
        }

        private static List<IImageMapItem<LabAlertDefinitionStatus>> GetImageMapItems()
        {
            List<IImageMapItem<LabAlertDefinitionStatus>> items = new List<IImageMapItem<LabAlertDefinitionStatus>>();

            items.Add(new SortableSimpleDomainObjectImageMapItem<LabAlertDefinitionStatus>(LabAlertDefinitionStatus.Valid, ResourceUtils.APPROVED));
            items.Add(new SortableSimpleDomainObjectImageMapItem<LabAlertDefinitionStatus>(LabAlertDefinitionStatus.InvalidTag, ResourceUtils.INVALID_TAG));

            return items;
        }
    }
}
