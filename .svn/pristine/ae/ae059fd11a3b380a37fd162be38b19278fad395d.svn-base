using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.PlantHistorian;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.PlantHistorian;

namespace Com.Suncor.Olt.Integration.PlantDataHistorian
{
    public class PlantHistorianConnectionFixture
    {
        public static ScadaConnectionInfo GetSarniaPhd300Info()
        {
            return new ScadaConnectionInfo(1, 1, @"NETWORK\sarhwacc", "S@rni@01Hny", "PHDPRD201.network.lan", "RAPI200",
                true,
                HoneywellPhdDatabaseType.Oracle, "PHD_READONLY", "PHD_READONLY", "PDBPRDSAR.NETWORK.LAN", "SARPDPRD", 5,
                1, "Average", 5, "Last", 3600, "Before", 0, false, DateTime.Now, null, null, null,
                ScadaConnectionType.PhdConnection, "PHD");
        }

        public static ScadaConnectionInfo GetMontrealInfo()
        {
            return new ScadaConnectionInfo(9, 9, @"PHD_READONLY", "PHD_READONLY", "PHDPRDMTL001.network.lan", "Default",
                false,
                HoneywellPhdDatabaseType.Oracle, "PHD_READONLY", "PHD_READONLY", "BFLXPRDMTL001.NETWORK.LAN", "UNF", 0,
                0, "Raw", 5, null, null, null, 100, false, DateTime.Now, null, null, null,
                ScadaConnectionType.PhdConnection, "PHD");
        }

        public static ScadaConnectionInfo GetLubesInfo()
        {
            return new ScadaConnectionInfo(10, 10, string.Empty, string.Empty, "MPNPHD.pcacorp.net", "RAPI200", false,
                HoneywellPhdDatabaseType.Oracle, "PHD_READONLY", "PHD_READONLY", "MPNBFU.pcacorp.net", "PRD", 5, 1,
                "Average", 5, "Last", 3600, "Before", 0, false, DateTime.Now, null, null, null,
                ScadaConnectionType.PhdConnection, "PHD");
        }

        public static OSIPiConnectionInfo GetDenverInfo()
        {
            var scadaConnectionInfo = new ScadaConnectionInfo(2, 2, null, null, null, null, false,
                HoneywellPhdDatabaseType.Oracle, null, null, null, null, 0, 0, null, null, null, null, null, 0,
                true, Clock.Now, "DEAPPI1.network.lan", "OLTClient", "DvPI4OLT", ScadaConnectionType.PiConnection,
                "PI");
            return
                new OSIPiConnectionInfo(scadaConnectionInfo);
        }

        public static ScadaConnectionInfo GetOilSandsPhd310InfoUsingOracle()
        {
            return new ScadaConnectionInfo(3, 3, @"NETWORK\OLTPHD", "Uyd2R171KaNqyOR", "PHDPRDFMM003V1.network.lan",
                "RAPI200", true,
                HoneywellPhdDatabaseType.Oracle, "TOTALPLANT", "DFTPOTP", "BFLXPRDFMM001.network.lan", "OPHDBPRD", 5, 1,
                "Average", 5, "Last", 3600, "Before", 0, false, DateTime.Now, null, null, null,
                ScadaConnectionType.PhdConnection, "PHD");
        }

        public static ScadaConnectionInfo GetOilSandsPhd310InfoUsingSqlServer()
        {
            return new ScadaConnectionInfo(3, 3, @"NETWORK\OLTPHD", "Uyd2R171KaNqyOR", "PHDPRDFMM003V1.network.lan",
                "RAPI200", true,
                HoneywellPhdDatabaseType.SqlServer, "Phdoilsandsread", "oilphds8nds", "PHD310SQL.network.lan", "PHDCFG",
                5, 1, "Average", 5, "Last", 3600, "Before", 0, false, DateTime.Now, null, null, null,
                ScadaConnectionType.PhdConnection, "PHD");
        }
    }
}