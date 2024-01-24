using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public static class TargetDefinitionReadWriteTagConfigurationFixture
    {
        public static TargetDefinitionReadWriteTagConfiguration CreateTargetDefinitionTagValueConfigurationFoundInDatabase()
        {
            Site site = SiteFixture.Sarnia();
            TargetDefinitionReadWriteTagConfiguration readWriteTagConfig
                    = new TargetDefinitionReadWriteTagConfiguration(-2,
                                                                    new ReadWriteTagConfiguration(TagDirection.Write, new TagInfo(1, site.Id, "A1", "Tag A from DB", "MPH", false,1)),
                                                                    new ReadWriteTagConfiguration(TagDirection.None, new TagInfo(2, site.Id, "B2", "Tag B from DB", "KPH", false,1)),
                                                                    new ReadWriteTagConfiguration(TagDirection.None, new TagInfo(3, site.Id, "C3", "Tag C from DB", "Litres", false,1)),
                                                                    new ReadWriteTagConfiguration(TagDirection.None, new TagInfo(4, site.Id, "D4", "Tag D from DB", "CM", false,1)));
            return readWriteTagConfig;
        }

        public static TargetDefinitionReadWriteTagConfiguration CreateConfigurationWithOnlyReadTypesForTagA1Values()
        {
            Site site = SiteFixture.Sarnia();
            TargetDefinitionReadWriteTagConfiguration readWriteTagConfig
                    = new TargetDefinitionReadWriteTagConfiguration(-1,
                                                                    new ReadWriteTagConfiguration(TagDirection.Read, new TagInfo(1, site.Id, "A1", "Tag A from DB", "MPH", false,1)),
                                                                    new ReadWriteTagConfiguration(TagDirection.Read, new TagInfo(1, site.Id, "A1", "Tag A from DB", "MPH", false,1)),
                                                                    new ReadWriteTagConfiguration(TagDirection.Read, new TagInfo(1, site.Id, "A1", "Tag A from DB", "MPH", false,1)),
                                                                    new ReadWriteTagConfiguration(TagDirection.Read, new TagInfo(1, site.Id, "A1", "Tag A from DB", "MPH", false,1)));
            return readWriteTagConfig;
        }
    }
}