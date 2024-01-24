using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class DataSource : SortableSimpleDomainObject
    {
        public static readonly DataSource MANUAL = new DataSource(0, 1);
        public static readonly DataSource SAP = new DataSource(1, 3);
        public static readonly DataSource TARGET = new DataSource(2, 5);
        public static readonly DataSource ACTION_ITEM = new DataSource(3, 4);
        public static readonly DataSource PERMIT = new DataSource(4, 6);

        public static readonly DataSource DWS = new DataSource(5, 7);
            // We no longer have DWS but we need to keep this because there are records in the production db with this value.

        public static readonly DataSource LAB_ALERT = new DataSource(6, 8);
        public static readonly DataSource PERMIT_REQUEST = new DataSource(7, 9);
        public static readonly DataSource MERGE = new DataSource(8, 2);
        public static readonly DataSource CLONE = new DataSource(9, 10);
        public static readonly DataSource HANDOVER = new DataSource(10, 11);
        public static readonly DataSource EXCURSION = new DataSource(11, 12);
        public static readonly DataSource OPERATOR_ROUND = new DataSource(12, 12);
        public static readonly DataSource ACTIVE_CSD= new DataSource(13,13);

        public static readonly DataSource TEMPLATE = new DataSource(14, 14); // Added By Vibhor : RITM0625399 - OLT - Include the "templates" as a source

        private static readonly DataSource[] ALL =
        {
            MANUAL, SAP, TARGET, ACTION_ITEM, PERMIT, DWS, LAB_ALERT,
            PERMIT_REQUEST, MERGE, CLONE, HANDOVER, EXCURSION,OPERATOR_ROUND,ACTIVE_CSD, TEMPLATE
        };

        private DataSource(int id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            if (IdValue == 0)
            {
                return StringResources.DataSource_Manual;
            }
            if (IdValue == 1)
            {
                return StringResources.DataSource_SAP;
            }
            if (IdValue == 2)
            {
                return StringResources.DataSource_Target;
            }
            if (IdValue == 3)
            {
                return StringResources.DataSource_ActionItem;
            }
            if (IdValue == 4)
            {
                return StringResources.DataSource_Permit;
            }
            if (IdValue == 5)
            {
                return StringResources.DataSource_DWS;
            }
            if (IdValue == 6)
            {
                return StringResources.DataSource_LabAlert;
            }
            if (IdValue == 7)
            {
                return StringResources.DataSource_PermitRequest;
            }
            if (IdValue == 8)
            {
                return StringResources.DataSource_Merge;
            }
            if (IdValue == 9)
            {
                return StringResources.DataSource_Clone;
            }
            if (IdValue == 10)
            {
                return StringResources.DataSource_Handover;
            }
            if (IdValue == 11)
            {
                return StringResources.DataSource_Excursion;
            }
            if (IdValue == 12)
            {
                return "Operator Round";
            }
            if (IdValue == 13)
            {
               // return StringResources.DataSource_ActiveCsd;
                return "Active CSD";
            }
            if (IdValue == 14) // Added By Vibhor : RITM0625399 - OLT - Include the "templates" as a source
            {
                return "Template";
            }
            return null;
        }

        public static DataSource GetById(long id)
        {
            return GetById(id, ALL);
        }
    }
}