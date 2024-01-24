using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class Site : DomainObject
    {
        public const long SARNIA_ID = 1;
        public const long DENVER_ID = 2;
        public const long OILSAND_ID = 3;
        public const long FIREBAG_ID = 5;
        public const long SITE_WIDE_SERVICES_ID = 6;
        public const long MACKAY_ID = 7;
        public const long EDMONTON_ID = 8;
        public const long MONTREAL_ID = 9;
        public const long LUBES_ID = 10;
        public const long VOYAGEUR_ID = 11;
        public const long WOODBUFFALO_ID = 12;
        public const long SELC_ID = 13;
        public const long MAJOR_PROJECTS_ID = 14;
        public const long FORT_HILLS_ID = 15;
        //ayman
        public const long MontrealSulphur_ID = 16;
        public const long Turnaround_ID = 17;
        public const long USPipeline_ID = 18;
        public const long TerraNova_ID = 19;
        //ayman
        public const long Contruction_Mgnt_ID = 21; //RITM0443261 : Added by Vibhor {Change the name for Shift log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}
        private readonly string activeDirectoryKey;
        private readonly string name;
        private readonly List<Plant> plants;
        private readonly OltTimeZoneInfo timeZone;

        private static readonly long[] WoodBuffaloRegionSiteIds =
        {
            OILSAND_ID, FIREBAG_ID, SITE_WIDE_SERVICES_ID, MACKAY_ID, VOYAGEUR_ID,
            WOODBUFFALO_ID, SELC_ID
        };

        public Site(long? id, string name, OltTimeZoneInfo timeZone, List<Plant> plants, string activeDirectoryKey)
        {
            this.id = id;
            this.name = name;
            this.timeZone = timeZone;
            this.plants = plants;
            this.activeDirectoryKey = activeDirectoryKey;
        }

        public string Name
        {
            get { return name; }
        }

        public OltTimeZoneInfo TimeZone
        {
            get { return timeZone; }
        }

        public List<Plant> Plants
        {
            get { return plants; }
        }

        public string ActiveDirectoryKey
        {
            get { return activeDirectoryKey; }
        }

        public bool IsFrenchSite
        {
            get { return Id == MONTREAL_ID; }
        }

        public static bool IsWoodBuffaloRegionSite(long siteId)
        {
            return WoodBuffaloRegionSiteIds.Contains(siteId);
        }

    }
}