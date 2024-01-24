using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class WorkPermitDataSourceImageColumn : SortableSimpleDomainObjectImageColumn<WorkPermitDTO, WorkPermitDataSourceImageColumn.WorkPermitDataSource>
    {
        private const string COLUMN_KEY = "SourceImage";
        private const int WIDTH = 50;
        
        public WorkPermitDataSourceImageColumn() : base(WorkPermitDataSource.Get, GetImageMapItems())
        {
            nameToEntityMap.Add(WorkPermitDataSource.SAP.Name, WorkPermitDataSource.SAP);
            nameToEntityMap.Add(WorkPermitDataSource.ManualOperations.Name, WorkPermitDataSource.ManualOperations);
            nameToEntityMap.Add(WorkPermitDataSource.ManualNonOperations.Name, WorkPermitDataSource.ManualNonOperations);
        }

        private static List<IImageMapItem<WorkPermitDataSource>> GetImageMapItems()
        {
            List<IImageMapItem<WorkPermitDataSource>> items = new List<IImageMapItem<WorkPermitDataSource>>();

            items.Add(new SortableSimpleDomainObjectImageMapItem<WorkPermitDataSource>(WorkPermitDataSource.SAP, ResourceUtils.SAP));
            items.Add(new SortableSimpleDomainObjectImageMapItem<WorkPermitDataSource>(WorkPermitDataSource.ManualOperations, ResourceUtils.MANUAL));
            items.Add(new SortableSimpleDomainObjectImageMapItem<WorkPermitDataSource>(WorkPermitDataSource.ManualNonOperations, ResourceUtils.NON_OPERATIONS));

            return items;
        }

        public override string ColumnKey
        {
            get { return COLUMN_KEY; }
        }

        public override string ColumnCaption
        {
            get { return RendererStringResources.Source; }
        }

        protected override int ColumnWidth
        {
            get { return WIDTH; }
        }

        public class WorkPermitDataSource : SortableSimpleDomainObject
        {
            public static readonly WorkPermitDataSource ManualOperations = new WorkPermitDataSource(0, 1);
            public static readonly WorkPermitDataSource ManualNonOperations = new WorkPermitDataSource(1, 2);
            public static readonly WorkPermitDataSource SAP = new WorkPermitDataSource(2, 3);

            public WorkPermitDataSource(long id, int sortOrder) : base(id, sortOrder)
            {
            }

            public override string GetName()
            {
                if (IdValue == 0) { return RendererStringResources.ManualOperations; }
                if (IdValue == 1) { return RendererStringResources.ManualNonOperations; }
                if (IdValue == 2) { return RendererStringResources.SAP; }
                return null;
            }

            public static WorkPermitDataSource Get(WorkPermitDTO permit)
            {
                DataSource permitSource = DataSource.GetById(permit.SourceId);

                if (permitSource.Equals(DataSource.SAP))
                {
                    return SAP;
                }
                if (permit.Operations)
                {
                    return ManualOperations;
                }
                return ManualNonOperations;
            }
        }
    }
}
