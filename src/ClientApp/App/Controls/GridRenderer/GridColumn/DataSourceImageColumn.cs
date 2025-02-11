﻿using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class DataSourceImageColumn<TRow> : SortableSimpleDomainObjectImageColumn<TRow, DataSource> 
        where TRow : IHasDataSource
    {
        private const string COLUMN_KEY = "SourceImage";
        private const int WIDTH = 50;
        
        public DataSourceImageColumn(DataSource[] applicableDataSources) : base(obj => obj.DataSource, GetImageMapItems(applicableDataSources))
        {
            foreach (DataSource dataSource in applicableDataSources)
            {
                nameToEntityMap.Add(dataSource.Name, dataSource);
            }
        }
              
        private static List<IImageMapItem<DataSource>> GetImageMapItems(DataSource[] applicableDataSources)
        {
            List<IImageMapItem<DataSource>> items = new List<IImageMapItem<DataSource>>();

            foreach (DataSource dataSource in applicableDataSources)
            {
                items.Add(new SortableSimpleDomainObjectImageMapItem<DataSource>(dataSource, GetImage(dataSource)));                
            }

            return items;
        }

        private static Bitmap GetImage(DataSource source)
        {
            Bitmap image;

            if (DataSource.MANUAL == source)
            {
                image = ResourceUtils.MANUAL;
            }
            else if (DataSource.SAP == source)
            {
                image = ResourceUtils.SAP;
            }
            else if (DataSource.TARGET == source)
            {
                image = ResourceUtils.TARGET;
            }
            else if (DataSource.ACTION_ITEM == source)
            {
                image = ResourceUtils.ACTION_ITEM;
            }
            else if (DataSource.PERMIT == source)
            {
                image = ResourceUtils.PERMIT;
            }
            else if (DataSource.DWS == source)
            {
                image = ResourceUtils.SCHEDULING;
            }
            else if (DataSource.LAB_ALERT == source)
            {
                image = ResourceUtils.LAB_ALERT;
            }
            else if (DataSource.EXCURSION == source)
            {
                image = ResourceUtils.EVENT;
            }
            else if (DataSource.PERMIT_REQUEST == source)
            {
                image = ResourceUtils.PERMIT_REQUEST;
            }
            else if (DataSource.MERGE == source)
            {
                image = ResourceUtils.MERGE;
            }
            else if (DataSource.CLONE == source)
            {
                image = ResourceUtils.CLONE;
            }
            else if (DataSource.HANDOVER == source)
            {
                image = ResourceUtils.HANDOVER_SMALL;
            }

           //Opertor Round Tool Image column for Log

            else if (DataSource.OPERATOR_ROUND == source)
            {
                image = ResourceUtils.COLD_PERMIT;
            }  
            //Active Csd Tool Image column for Log
            else if (DataSource.ACTIVE_CSD == source)
            {
                image = ResourceUtils.ACTIVE_CSD;
            }
            else if (DataSource.TEMPLATE == source) // Added By Vibhor : RITM0625399 - OLT - Include the "templates" as a source
            {
                image = ResourceUtils.Template;
            }
            else
            {
                image = ResourceUtils.BLANK;
            }

            return image;
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
    }
}
