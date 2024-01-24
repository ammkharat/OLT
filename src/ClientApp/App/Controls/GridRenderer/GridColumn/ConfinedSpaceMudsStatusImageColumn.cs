using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class ConfinedSpaceMudsStatusImageColumn : StatusImageColumn<ConfinedSpaceMudsDTO, ConfinedSpaceStatusMuds>
    {
        public ConfinedSpaceMudsStatusImageColumn() : base(RendererStringResources.Status, GetImageMapItems())
        {
            nameToEntityMap.Add(ConfinedSpaceStatusMuds.Pending.Name, ConfinedSpaceStatusMuds.Pending);
            nameToEntityMap.Add(ConfinedSpaceStatusMuds.Issued.Name, ConfinedSpaceStatusMuds.Issued);
        }

        public static List<IImageMapItem<ConfinedSpaceStatusMuds>> GetImageMapItems()
        {
            List<IImageMapItem<ConfinedSpaceStatusMuds>> items = new List<IImageMapItem<ConfinedSpaceStatusMuds>>();

            items.Add(new SortableSimpleDomainObjectImageMapItem<ConfinedSpaceStatusMuds>(ConfinedSpaceStatusMuds.Pending, ResourceUtils.PENDING));
            items.Add(new SortableSimpleDomainObjectImageMapItem<ConfinedSpaceStatusMuds>(ConfinedSpaceStatusMuds.Issued, ResourceUtils.ISSUED));

            return items;
        }
    }
}