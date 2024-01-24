using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Utility
{
    public class SAPWorkCentre
    {
        public static readonly SAPWorkCentre EXTRACTION = new SAPWorkCentre(1, WorkCentreName.OPRPR, "1200");
        public static readonly SAPWorkCentre UPGRADING = new SAPWorkCentre(2, WorkCentreName.OPRPR, "1300");
        public static readonly SAPWorkCentre SARNIA_REFINERY = new SAPWorkCentre(3, WorkCentreName.OPRPR, "4000");
        public static readonly SAPWorkCentre DENVER_REFINERY = new SAPWorkCentre(4, WorkCentreName.OPRPR, "7000");
        public static readonly SAPWorkCentre FIREBAG_1 = new SAPWorkCentre(5, WorkCentreName.PRTEC, "1400");
        public static readonly SAPWorkCentre FIREBAG_2 = new SAPWorkCentre(6, WorkCentreName.PRTEC1, "1400");
        public static readonly SAPWorkCentre FIREBAG_3 = new SAPWorkCentre(7, WorkCentreName.PRTEC1_C, "1400");
        public static readonly SAPWorkCentre FIREBAG_4 = new SAPWorkCentre(8, WorkCentreName.PRTEC2, "1400");
        public static readonly SAPWorkCentre FIREBAG_5 = new SAPWorkCentre(9, WorkCentreName.PRTEC2_C, "1400");
        public static readonly SAPWorkCentre DEV = new SAPWorkCentre(10, WorkCentreName.OPER, "DEVONLY");

        //mangesh - added for montreal: RITM0011613
        public static readonly SAPWorkCentre MONTREAL_REFINERY = new SAPWorkCentre(11, WorkCentreName.OPERATIO, "302");

        //ayman USPipeline workpermit
        public static readonly SAPWorkCentre USPipeline_REFINERY = new SAPWorkCentre(12, WorkCentreName.OPRPR, "9991");


        public static readonly SAPWorkCentre[] all =
        {
            EXTRACTION, UPGRADING, SARNIA_REFINERY, DENVER_REFINERY, FIREBAG_1,
            FIREBAG_2, FIREBAG_3, FIREBAG_4, FIREBAG_5, DEV
            ,MONTREAL_REFINERY, USPipeline_REFINERY //mangesh :added 'MONTREAL_REFINERY' for montreal-RITM0011613
        };

        private readonly long id;
        private readonly string name;
        //NOTE - this property is not required right now (Mar 15, 2006)
        //i just added it for visual reference.
        private readonly string plantId;

        private SAPWorkCentre(long id, string name, string plantId)
        {
            this.id = id;
            this.name = name;
            this.plantId = plantId;
        }

        public long Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }

        public string PlantId
        {
            get { return plantId; }
        }

        public static bool IsInWorkCentreList(string workCentreIdentifier)
        {
            if (string.IsNullOrEmpty(workCentreIdentifier))
                return false;

            return all.Exists(wc => wc.name.StartsWith(workCentreIdentifier));
        }
    }
}