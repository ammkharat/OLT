using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class TagInfoFixture
    {
        private static int tagNameCount;

        private static string CreateUniqueTagInfoName()
        {
            var name = "Tag-" + DateTimeFixture.DateTimeNow.Ticks + tagNameCount;
            tagNameCount = tagNameCount + 1;
            return name;
        }

        public static TagInfo CreateTagInfoWithoutId()
        {
            var name = CreateUniqueTagInfoName();
            var ret =
                new TagInfo(SiteFixture.Sarnia().Id, name, "Created by TagInfoFixture.CreateTagInfoWithoutId()", "Units",
                    false, 1)
                {Id = null};
            return ret;
        }

        public static TagInfo CreateTagInfoWithId2FromDB()
        {
            var ret = new TagInfo(SiteFixture.Sarnia().Id, "B2", "Tag B from DB", "KPH", true, 1) {Id = 2};
            return ret;
        }

        public static TagInfo CreateTagEquipmentAWithUnitsMPHAndFortMcMurrayFLOC()
        {
            var tag = new TagInfo(SiteFixture.Sarnia().Id, "EquipmentA", "Equipment Piece A", "MPH", true, 1)
            {
                Id = 1
            };
            return tag;
        }

        public static TagInfo CreateMockTagForSarnia(long tagId, string tagName)
        {
            var tag = new TagInfo(SiteFixture.Sarnia().Id, tagName, "Mock Tag " + tagName, "CM", false,1) {Id = tagId};
            return tag;
        }

        public static TagInfo CreateMockTagForDenver(long tagId, string tagName)
        {
            var tag = new TagInfo(SiteFixture.Denver().Id, tagName, "Mock Tag " + tagName, "CM", false,2) {Id = tagId};
            return tag;
        }

        public static List<TagInfo> CreateTagListForSarnia()
        {
            var testSite = SiteFixture.Sarnia();
            var tags = new List<TagInfo>
            {
                new TagInfo(testSite.Id, "Test1", "This is Test1 Tag", "km", false,1),
                new TagInfo(testSite.Id, "Test2", "This is Test2 Tag", "m", false,1),
                new TagInfo(testSite.Id, "Test3", "This is Test3 Tag", "mm", false,1)
            };

            return tags;
        }

        public static List<TagInfo> CreateTagInfoList(Site site, long scadaConnectionInfoId)
        {
            var ret = new List<TagInfo>();

            var tagInfoCount = 5;
            for (var i = 0; i < tagInfoCount; i++)
            {
                var name = "Test Tag Info Id = " + i;
                var description = "Description for TagInfo " + i;
                var unit = "KM";
                var tagInfo = new TagInfo(i, site.Id, name, description, unit, false, scadaConnectionInfoId);
                ret.Add(tagInfo);
            }
            return ret;
        }

        public static List<TagInfo> CreatePHDTagInfoList(Site site, int count, long scadaConnectionInfoId)
        {
            var tags = new List<TagInfo>();
            for (var i = 0; i < count; i++)
            {
                var description = "TagInfoFixture.CreatePHDTagInfoList() Id = " + i;
                var tagInfo = new TagInfo(site.Id, CreateUniqueTagInfoName(), description, "KHP", false,scadaConnectionInfoId) {Id = i};
                tags.Add(tagInfo);
            }
            return tags;
        }

        public static TagInfo GetWorkingRestrictionDefinitionTargetTagInfoForOilsands()
        {
            return new TagInfo(66, 3, "P86_REST_MASS_TARGET", "Plant 86 target tonnages", "TONNE/HR", false, 3);
        }

        public static List<TagInfo> GetExistingSarniaTagInfoList()
        {
            var site = SiteFixture.Sarnia();


            var tagInfo1 = new TagInfo(site.Id, "31TI111.PV", "FRESH FEED FROM STORAGE TO 31-V-001", "DEGC", false,1)
            {Id = 1640};


            var tagInfo2 = new TagInfo(site.Id, "04CF002.CV", "PLANT 3 UTILITIES TOTAL STM 'DTWY 04FC02' <CALC - 1>",
                "TONNE/D", false,1)
            {Id = 9354};


            var tagInfo3 = new TagInfo(site.Id, "12TI732A.PV", "PLANT 1 -GDS- HDT REACTOR R02 BED #1", "DEGC", false,1)
            {Id = 84493};


            var ret = new List<TagInfo> {tagInfo1, tagInfo2, tagInfo3};
            return ret;
        }
    }
}