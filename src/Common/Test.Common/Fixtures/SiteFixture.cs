using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public static class SiteFixture
    {
        private static readonly Site SarniaSite = new Site(1, "Sarnia", TimeZoneFixture.GetSarniaTimeZone(), PlantFixture.SarniaPlants(), "Sarnia");
        private static readonly Site DenverSite = new Site(2, "Denver", TimeZoneFixture.GetMountainTimeZone(), PlantFixture.DenverPlants(), "Denver");
        private static readonly Site OilsandsSite = new Site(3, "Oilsands", TimeZoneFixture.GetMountainTimeZone(), PlantFixture.OilsandsPlants(), "OilSands");
        private static readonly Site FirebagSite = new Site(5, "Firebag", TimeZoneFixture.GetMountainTimeZone(), PlantFixture.FirebagPlants(), "Firebag");
        private static readonly Site SiteWideServicesSite = new Site(6, "Site Wide Services", TimeZoneFixture.GetMountainTimeZone(), PlantFixture.SiteWideServicesPlants(), "SiteWideServices");
        private static readonly Site MacKayRiverSite = new Site(7, "MacKay River", TimeZoneFixture.GetMountainTimeZone(), PlantFixture.MacKayRiverPlants(), "MacKayRiver");
        private static readonly Site EdmontonSite = new Site(8, "Edmonton", TimeZoneFixture.GetMountainTimeZone(), PlantFixture.EdmontonPlants(), "Edmonton");
        private static readonly Site MontrealSite = new Site(9, "Montreal", TimeZoneFixture.GetMountainTimeZone(), PlantFixture.MontrealPlants(), "Montreal");
        private static readonly Site LubesSite = new Site(10, "Lubes", TimeZoneFixture.GetSarniaTimeZone(), PlantFixture.LubesPlants(), "Lubes");
        //ayman USPipeline workpermit
        private static readonly Site USPipelineSite = new Site(18, "USPipeline", TimeZoneFixture.GetMountainTimeZone(), PlantFixture.USPipelinePlants(), "USPipeline");
        private static readonly Site WoodBuffalo_Lab = new Site(12, "Wood Buffalo Laboratories", TimeZoneFixture.GetMountainTimeZone(),
            new List<Plant> {PlantFixture.WoodBuffaloLab}, "WoodBuffaloLaboratories");
        
        public static List<Site> GetSites()
        {
            var sites = new List<Site> { SarniaSite, DenverSite, OilsandsSite };
            return sites;
        }

        public static Site Sarnia()
        {
            return SarniaSite;
        }

        public static Site Denver()
        {
            return DenverSite;
        }

        //ayman USpipeline workpermit
        public static Site USPipeline()
        {
            return USPipelineSite;
        }

        public static Site Oilsands()
        {
            return OilsandsSite;
        }

        public static Site Firebag()
        {
            return FirebagSite;
        }
        
        public static Site SiteWideServices()
        {
            return SiteWideServicesSite;
        }

        public static Site MacKayRiver()
        {
            return MacKayRiverSite;
        }

        public static Site Edmonton()
        {
            return EdmontonSite;
        }
        
        public static Site Montreal()
        {
            return MontrealSite;
        }

        public static Site Lubes()
        {
            return LubesSite;
        }

        public static Site Lab()
        {
            return WoodBuffalo_Lab;
        }

        public static Site Unknown = new Site(99, "unknown site", TimeZoneFixture.GetMountainTimeZone(), new List<Plant>(), "Unknown");
    }
}
