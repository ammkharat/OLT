using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;

namespace Com.Suncor.Olt.Integration.HTTPHandlers.Fixtures
{
    public class FunctionalLocationSAPFixture : SAPFixture
    {
        private const string ADD = "Add";
        private const string CHANGE = "Change";
        private const string DELETE = "Delete";

        public static FunctionalLocationSAPData CreateFLOCSAPData()
        {
            const string plantID = "4000";
            var description = string.Empty;
            var action = string.Empty;
            const string flocId = "SR1-PLT1-GEN1-SAS";

            var flocSAPData = new FunctionalLocationSAPData(plantID,
                flocId,
                string.Empty,
                description,
                action);
            return flocSAPData;
        }

        public static string CreateNewFlocEquipment2()
        {
            var ticks = string.Format("{0}", DateTimeFixture.DateTimeNow.Ticks);
            return "TEST" + ticks.Substring(ticks.Length - 12);
        }

        public static string CreateNewUnitFloc()
        {
            var ticks = string.Format("{0}", DateTimeFixture.DateTimeNow.Ticks);
            return "UNIT" + ticks.Substring(ticks.Length - 10);
        }

        public static FunctionalLocationSAPData GetAddEquipment2Floc(string newEquipment2)
        {
            var flocSAPData = CreateFLOCSAPData();
            flocSAPData.Action = ADD;
            flocSAPData.ReplacePart(newEquipment2, 5);
            return flocSAPData;
        }


        public static FunctionalLocationSAPData GetAddUnitFloc(string unit)
        {
            var flocSAPData = CreateFLOCSAPData();
            flocSAPData.Action = ADD;

            var flocId = new FunctionalLocationHierarchy(flocSAPData.FlocId).GetAncestorOrSelf(3).ToString();
            flocSAPData.FlocId = flocId;

            flocSAPData.ReplacePart(unit, 3);

            return flocSAPData;
        }

        public static string GetChangeFlocDescription(string existingEquipment2Name)
        {
            var flocSAPData = CreateFLOCSAPData();
            flocSAPData.PlantID = "4000";
            flocSAPData.Description = "Created By GetChangeFlocDescription" + "New Description";
            flocSAPData.Action = CHANGE;
            flocSAPData.ReplacePart(existingEquipment2Name, 5);

            return flocSAPData.CreateMessage();
        }

        public static string GetDeleteFloc(string existingEquipment2Name)
        {
            var flocSAPData = CreateFLOCSAPData();
            flocSAPData.Action = DELETE;
            flocSAPData.ReplacePart(existingEquipment2Name, 5);
            return flocSAPData.CreateMessage();
        }
    }
}