using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class CraftOrTradeFixture
    {
        public static List<CraftOrTrade> GetListOfCraftOrTrades()
        {
            List<CraftOrTrade> craftOrTrades = new List<CraftOrTrade>
                                                   {CreateCraftOrTradeWelder(), CreateCraftOrTradePipeFitter()};

            return craftOrTrades;
        }

        public static CraftOrTrade CreateCraftOrTradeWelder()
        {
            return new CraftOrTrade(1, "PFW-Pipefitter Welder", "111335", 1);
        }

        /// <summary>
        /// (1, 'PFW-Pipefitter Welder','11111');
        /// </summary>
        /// <returns></returns>
        public static CraftOrTrade CreateCraftOrTradeThatMapsToDB()
        {
            return new CraftOrTrade(1, "PFW-Pipefitter Welder", "11111", 1);
        }

        public static CraftOrTrade CreateCraftOrTradePipeFitter()
        {
            return new CraftOrTrade(2, "Pipefitter", "111333", 1);
        }

        public static CraftOrTrade CreateNewCraftOrTradeHoleCutter()
        {
            return CreateNewCraftOrTrade(1);
        }

        public static CraftOrTrade CreateNewCraftOrTrade(Site site)
        {
            return CreateNewCraftOrTrade(site.IdValue);
        }

        private static CraftOrTrade CreateNewCraftOrTrade(long siteId)
        {
            return new CraftOrTrade(null, "Hole Cutter", "111336", siteId);
        }
        
        public static CraftOrTrade CreateNewCraftOrTrade(string name, Site site)
        {
            return new CraftOrTrade(name, string.Empty, site.IdValue);
        }

        public static CraftOrTrade CreateNewCraftOrTrade(string name, string workCentre, Site site)
        {
            return new CraftOrTrade(name, workCentre, site.IdValue);
        }

        public static CraftOrTrade CreateNewCraftOrTradeHoleCutter(Site site)
        {
            return CreateNewCraftOrTrade(site.IdValue);
        }
    }
}