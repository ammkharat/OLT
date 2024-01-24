using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class WorkPermitStatusImageColumn : StatusImageColumn<WorkPermitDTO, WorkPermitStatus> 
    {
        public WorkPermitStatusImageColumn() : base(RendererStringResources.Status, GetImageMapItems())
        {
            nameToEntityMap.Add(WorkPermitStatus.Approved.Name, WorkPermitStatus.Approved);
            nameToEntityMap.Add(WorkPermitStatus.Complete.Name, WorkPermitStatus.Complete);
            nameToEntityMap.Add(WorkPermitStatus.Pending.Name, WorkPermitStatus.Pending);
            nameToEntityMap.Add(WorkPermitStatus.Rejected.Name, WorkPermitStatus.Rejected);
            nameToEntityMap.Add(WorkPermitStatus.Issued.Name, WorkPermitStatus.Issued);
            nameToEntityMap.Add(WorkPermitStatus.Archived.Name, WorkPermitStatus.Archived);
        }

        public static List<IImageMapItem<WorkPermitStatus>> GetImageMapItems()
        {
            List<IImageMapItem<WorkPermitStatus>> items = new List<IImageMapItem<WorkPermitStatus>>();

            items.Add(new SortableSimpleDomainObjectImageMapItem<WorkPermitStatus>(WorkPermitStatus.Approved, ResourceUtils.APPROVED));
            items.Add(new SortableSimpleDomainObjectImageMapItem<WorkPermitStatus>(WorkPermitStatus.Complete, ResourceUtils.COMPLETED_PERMIT));
            items.Add(new SortableSimpleDomainObjectImageMapItem<WorkPermitStatus>(WorkPermitStatus.Pending, ResourceUtils.PENDING));
            items.Add(new SortableSimpleDomainObjectImageMapItem<WorkPermitStatus>(WorkPermitStatus.Rejected, ResourceUtils.REJECTED));
            items.Add(new SortableSimpleDomainObjectImageMapItem<WorkPermitStatus>(WorkPermitStatus.Issued, ResourceUtils.ISSUED));
            items.Add(new SortableSimpleDomainObjectImageMapItem<WorkPermitStatus>(WorkPermitStatus.Archived, ResourceUtils.ARCHIVED));

            return items;
        }
    }
}
