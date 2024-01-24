using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class EdmontonOvertimeFormStatusImageColumn : StatusImageColumn<IHasStatus<FormStatus>, FormStatus>
    {
        public EdmontonOvertimeFormStatusImageColumn()
            : base(RendererStringResources.Status, GetImageMapItems())
        {
            nameToEntityMap.Add(FormStatus.Approved.Name, FormStatus.Approved);
            nameToEntityMap.Add(FormStatus.Draft.Name, FormStatus.Draft);
            nameToEntityMap.Add(FormStatus.Cancelled.Name, FormStatus.Cancelled);
        }

        public static List<IImageMapItem<FormStatus>> GetImageMapItems()
        {
            return new List<IImageMapItem<FormStatus>>
            {
                new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.Approved, ResourceUtils.APPROVED),
                new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.Draft, ResourceUtils.PENDING),
                new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.Cancelled, ResourceUtils.REJECTED)
            };
        }
    }
}