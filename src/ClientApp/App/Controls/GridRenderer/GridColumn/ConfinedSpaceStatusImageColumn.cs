using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class ConfinedSpaceStatusImageColumn : StatusImageColumn<ConfinedSpaceDTO, ConfinedSpaceStatus>
    {
        public ConfinedSpaceStatusImageColumn() : base(RendererStringResources.Status, GetImageMapItems())
        {
            nameToEntityMap.Add(ConfinedSpaceStatus.Pending.Name, ConfinedSpaceStatus.Pending);
            nameToEntityMap.Add(ConfinedSpaceStatus.Issued.Name, ConfinedSpaceStatus.Issued);
        }

        public static List<IImageMapItem<ConfinedSpaceStatus>> GetImageMapItems()
        {
            List<IImageMapItem<ConfinedSpaceStatus>> items = new List<IImageMapItem<ConfinedSpaceStatus>>();

            items.Add(new SortableSimpleDomainObjectImageMapItem<ConfinedSpaceStatus>(ConfinedSpaceStatus.Pending, ResourceUtils.PENDING));
            items.Add(new SortableSimpleDomainObjectImageMapItem<ConfinedSpaceStatus>(ConfinedSpaceStatus.Issued, ResourceUtils.ISSUED));

            return items;
        }
    }
}