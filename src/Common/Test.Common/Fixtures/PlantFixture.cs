using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public static class PlantFixture
    {
        public static readonly Plant SarniaPlant = new Plant(4000, "Sarnia", Site.SARNIA_ID);
        private static readonly Plant DenverRefineryPlant = new Plant(4000, "Refinery", Site.DENVER_ID);
        private static readonly Plant DenverPipelineAndTerminalsPlant = new Plant(4000, "Pipeline and Terminals", Site.DENVER_ID);
        private static readonly Plant DenverRetailPlant = new Plant(4000, "Retail", Site.DENVER_ID);

        //ayman USPipeline workpermit
        public static readonly Plant USPipelineRefineryPlant = new Plant(9991, "Refinery", Site.USPipeline_ID);
        private static readonly Plant USPipelinePipelineAndTerminalsPlant = new Plant(9991, "Pipeline and Terminals", Site.USPipeline_ID);
        private static readonly Plant USPipelineRetailPlant = new Plant(9991, "Retail", Site.USPipeline_ID);
        
        private static readonly Plant OilsandsExtractionPlant = new Plant(1200, "Oilsands Extraction", Site.OILSAND_ID);
        public static readonly Plant OilsandsUpgradingPlant = new Plant(1300, "Oilsands Upgrading", Site.OILSAND_ID);
        private static readonly Plant FirebagPlant = new Plant(1400, "Firebag", Site.FIREBAG_ID);
        private static readonly Plant MacKayRiverPlant = new Plant(754, "MacKay River", Site.MACKAY_ID);
        private static readonly Plant EdmontonPlant = new Plant(702, "Edmonton", Site.EDMONTON_ID);
        private static readonly Plant MontrealPlant = new Plant(302, "Montreal", Site.MONTREAL_ID);
        private static readonly Plant LubesPlant = new Plant(402, "Lubes", Site.LUBES_ID);
        private static readonly Plant EnergyAndUtilties = new Plant(1060, "EUS", Site.SITE_WIDE_SERVICES_ID);
        private static readonly Plant TransmissionAndDistribution = new Plant(1000, "TDS", Site.SITE_WIDE_SERVICES_ID);
        public static readonly Plant WoodBuffaloLab = new Plant(8888, "Oilsands Labs", Site.WOODBUFFALO_ID);


        public static List<Plant> SarniaPlants()
        {
           return new List<Plant>(new[] { SarniaPlant });
        }

        public static List<Plant> DenverPlants()
        {
           return new List<Plant>(new[] { DenverRefineryPlant, DenverPipelineAndTerminalsPlant, DenverRetailPlant });   
        }

        //ayman USPipeline workpermit
        public static List<Plant> USPipelinePlants()
        {
            return new List<Plant>(new[] { USPipelineRefineryPlant, USPipelinePipelineAndTerminalsPlant, USPipelineRetailPlant });
        }


        public static List<Plant> OilsandsPlants()
        {
            return  new List<Plant>(new[] { OilsandsExtractionPlant, OilsandsUpgradingPlant });  
        } 

        public static List<Plant> FirebagPlants()
        {
            return new List<Plant>(new[] { FirebagPlant });  
        } 

        public static List<Plant> MacKayRiverPlants()
        {
            return new List<Plant>(new[] { MacKayRiverPlant });  
        }

        public static List<Plant> EdmontonPlants()
        {
            return new List<Plant>(new[] { EdmontonPlant });
        }

        public static List<Plant> MontrealPlants()
        {
            return new List<Plant>(new[] { MontrealPlant });
        }

        public static List<Plant> LubesPlants()
        {
            return new List<Plant>(new[] { LubesPlant });
        }

        public static List<Plant> SiteWideServicesPlants()
        {
            return new List<Plant> {EnergyAndUtilties, TransmissionAndDistribution};
        }
    }
}
