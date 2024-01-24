using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;


namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class FormStatusImageColumn : StatusImageColumn<IHasStatus<FormStatus>, FormStatus>
    {        
        public FormStatusImageColumn() : base(RendererStringResources.Status, GetImageMapItems())
        {
            nameToEntityMap.Add(FormStatus.Approved.Name, FormStatus.Approved);
            nameToEntityMap.Add(FormStatus.Closed.Name, FormStatus.Closed);
            nameToEntityMap.Add(FormStatus.Draft.Name, FormStatus.Draft);
            nameToEntityMap.Add(FormStatus.Expired.Name, FormStatus.Expired);
            nameToEntityMap.Add(FormStatus.WaitingForApproval.Name, FormStatus.WaitingForApproval);
        }

        public static List<IImageMapItem<FormStatus>> GetImageMapItems()
        {
            return new List<IImageMapItem<FormStatus>>
                       {
                           new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.Approved, ResourceUtils.APPROVED),
                           new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.Closed, ResourceUtils.COMPLETED_PERMIT),
                           new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.Draft, ResourceUtils.PENDING),
                           new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.Expired, ResourceUtils.REJECTED),
                           new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.WaitingForApproval, ResourceUtils.WAITINGFORAPPROVAL),
                       };
        }
    }
}