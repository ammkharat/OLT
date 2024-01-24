using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class RestrictionDefinitionStatusImageColumn : StatusImageColumn<RestrictionDefinitionDTO, RestrictionDefinitionStatus>
    {
        public RestrictionDefinitionStatusImageColumn() : base(RendererStringResources.Status, GetImageMapItems())
        {
            nameToEntityMap.Add(RestrictionDefinitionStatus.Valid.Name, RestrictionDefinitionStatus.Valid);
            nameToEntityMap.Add(RestrictionDefinitionStatus.InvalidTag.Name, RestrictionDefinitionStatus.InvalidTag);
        }

        private static List<IImageMapItem<RestrictionDefinitionStatus>> GetImageMapItems()
        {
            List<IImageMapItem<RestrictionDefinitionStatus>> items = new List<IImageMapItem<RestrictionDefinitionStatus>>();

            items.Add(new SortableSimpleDomainObjectImageMapItem<RestrictionDefinitionStatus>(RestrictionDefinitionStatus.Valid, ResourceUtils.APPROVED));
            items.Add(new SortableSimpleDomainObjectImageMapItem<RestrictionDefinitionStatus>(RestrictionDefinitionStatus.InvalidTag, ResourceUtils.INVALID_TAG));

            return items;
        }
    }
}
