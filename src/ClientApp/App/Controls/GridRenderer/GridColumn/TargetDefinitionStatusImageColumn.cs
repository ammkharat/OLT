using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class TargetDefinitionStatusImageColumn : StatusImageColumn<TargetDefinitionDTO, TargetDefinitionStatus>
    {
        public TargetDefinitionStatusImageColumn() : base(RendererStringResources.Status, GetImageMapItems())
        {
            nameToEntityMap.Add(TargetDefinitionStatus.Pending.Name, TargetDefinitionStatus.Pending);
            nameToEntityMap.Add(TargetDefinitionStatus.Approved.Name, TargetDefinitionStatus.Approved);
            nameToEntityMap.Add(TargetDefinitionStatus.Rejected.Name, TargetDefinitionStatus.Rejected);
            nameToEntityMap.Add(TargetDefinitionStatus.InvalidTag.Name, TargetDefinitionStatus.InvalidTag);
        }

        private static List<IImageMapItem<TargetDefinitionStatus>> GetImageMapItems()
        {
            List<IImageMapItem<TargetDefinitionStatus>> items = new List<IImageMapItem<TargetDefinitionStatus>>();

            items.Add(new SortableSimpleDomainObjectImageMapItem<TargetDefinitionStatus>(TargetDefinitionStatus.Pending, ResourceUtils.PENDING));
            items.Add(new SortableSimpleDomainObjectImageMapItem<TargetDefinitionStatus>(TargetDefinitionStatus.Approved, ResourceUtils.APPROVED));
            items.Add(new SortableSimpleDomainObjectImageMapItem<TargetDefinitionStatus>(TargetDefinitionStatus.Rejected, ResourceUtils.REJECTED));
            items.Add(new SortableSimpleDomainObjectImageMapItem<TargetDefinitionStatus>(TargetDefinitionStatus.InvalidTag, ResourceUtils.INVALID_TAG));

            return items;
        }
    }
}
