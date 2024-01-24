using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class WorkPermitTypeImageColumn : SortableSimpleDomainObjectImageColumn<WorkPermitDTO, WorkPermitType>
    {
        private const string COLUMN_KEY = "WorkPermitTypeImage";
        private const int COLUMN_WIDTH = 50;
        
        public WorkPermitTypeImageColumn() : base(obj => obj.WorkPermitType, GetImageMapItems())
        {
            nameToEntityMap.Add(WorkPermitType.HOT.Name, WorkPermitType.HOT);
            nameToEntityMap.Add(WorkPermitType.COLD.Name, WorkPermitType.COLD);
        }

        private static List<IImageMapItem<WorkPermitType>> GetImageMapItems()
        {
            List<IImageMapItem<WorkPermitType>> items = new List<IImageMapItem<WorkPermitType>>();

            items.Add(new SortableSimpleDomainObjectImageMapItem<WorkPermitType>(WorkPermitType.HOT, ResourceUtils.HOT_PERMIT));
            items.Add(new SortableSimpleDomainObjectImageMapItem<WorkPermitType>(WorkPermitType.COLD, ResourceUtils.COLD_PERMIT));

            return items;
        }

        public override string ColumnKey
        {
            get { return COLUMN_KEY; }
        }

        public override string ColumnCaption
        {
            get { return RendererStringResources.Type; }
        }

        protected override int ColumnWidth
        {
            get { return COLUMN_WIDTH; }
        }
    }
}
