using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class ActionItemStatusImageColumn : StatusImageColumn<ActionItemDTO, ActionItemStatus>
    {
        public ActionItemStatusImageColumn() : base(RendererStringResources.Status, GetImageMapItems())
        {
            var userContext = ClientSession.GetUserContext();
            
                nameToEntityMap.Add(ActionItemStatus.Complete.Name, ActionItemStatus.Complete);
                nameToEntityMap.Add(ActionItemStatus.Current.Name, ActionItemStatus.Current);
                nameToEntityMap.Add(ActionItemStatus.Incomplete.Name, ActionItemStatus.Incomplete);
                nameToEntityMap.Add(ActionItemStatus.CannotComplete.Name, ActionItemStatus.CannotComplete);

                //IEF Submitted status changes Start
                if (userContext.SiteId == 3 && userContext.PlantIds.Contains(1100))
                {
                    nameToEntityMap.Add(ActionItemStatus.IefSubmitted.Name, ActionItemStatus.IefSubmitted);
                    //IEFSubmitted changes
                }
                //IEF Submitted status changes End
        }
            

        public static
            List<IImageMapItem<ActionItemStatus>> GetImageMapItems()
        {
            List<IImageMapItem<ActionItemStatus>> items = new List<IImageMapItem<ActionItemStatus>>();
            var userContext = ClientSession.GetUserContext();

            items.Add(new SortableSimpleDomainObjectImageMapItem<ActionItemStatus>(ActionItemStatus.Complete, ResourceUtils.APPROVED));
            items.Add(new SortableSimpleDomainObjectImageMapItem<ActionItemStatus>(ActionItemStatus.Current, ResourceUtils.CURRENT));
            items.Add(new SortableSimpleDomainObjectImageMapItem<ActionItemStatus>(ActionItemStatus.Incomplete, ResourceUtils.REJECTED));
            items.Add(new SortableSimpleDomainObjectImageMapItem<ActionItemStatus>(ActionItemStatus.CannotComplete, ResourceUtils.CANT_COMPLETE));
            
            //IEF Submitted status changes Start
            if (userContext.SiteId == 3 && userContext.PlantIds.Contains(1100))
            {
                items.Add(new SortableSimpleDomainObjectImageMapItem<ActionItemStatus>(ActionItemStatus.IefSubmitted, ResourceUtils.IEFSUBMITTED));//IEFSubmitted changes 
            }
            //IEF Submitted status changes End

            return items;
        }
    }
}
