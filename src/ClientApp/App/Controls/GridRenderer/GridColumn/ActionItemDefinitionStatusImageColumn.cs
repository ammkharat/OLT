using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class ActionItemDefinitionStatusImageColumn : StatusImageColumn<ActionItemDefinitionDTO, ActionItemDefinitionStatus>
    {
        public ActionItemDefinitionStatusImageColumn() : base(RendererStringResources.Status, GetImageMapItems())
        {
            nameToEntityMap.Add(ActionItemDefinitionStatus.Approved.Name, ActionItemDefinitionStatus.Approved);
            nameToEntityMap.Add(ActionItemDefinitionStatus.Pending.Name, ActionItemDefinitionStatus.Pending);
            nameToEntityMap.Add(ActionItemDefinitionStatus.Rejected.Name, ActionItemDefinitionStatus.Rejected);
        }

        private static List<IImageMapItem<ActionItemDefinitionStatus>> GetImageMapItems()
        {
            List<IImageMapItem<ActionItemDefinitionStatus>> items = new List<IImageMapItem<ActionItemDefinitionStatus>>();

            items.Add(new SortableSimpleDomainObjectImageMapItem<ActionItemDefinitionStatus>(ActionItemDefinitionStatus.Approved, ResourceUtils.APPROVED));
            items.Add(new SortableSimpleDomainObjectImageMapItem<ActionItemDefinitionStatus>(ActionItemDefinitionStatus.Pending, ResourceUtils.PENDING));
            items.Add(new SortableSimpleDomainObjectImageMapItem<ActionItemDefinitionStatus>(ActionItemDefinitionStatus.Rejected, ResourceUtils.REJECTED));

            return items;
        }
    }
}
