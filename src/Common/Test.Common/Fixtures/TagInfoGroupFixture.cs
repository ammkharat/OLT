using System;
using System.Collections.Generic;
using System.Globalization;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class TagInfoGroupFixture
    {
        public static TagInfoGroup GetExistingSarniaTagInfoGroup()
        {
            Site site = SiteFixture.Sarnia();
            TagInfoGroup ret = new TagInfoGroup(1, "Tag Info Group 1", site);
            ret.TagInfoList = TagInfoFixture.GetExistingSarniaTagInfoList();
            return ret;
        }

        public static TagInfoGroup CreateInvalidTagInfoGroup()
        {
            TagInfoGroup group = GetExistingSarniaTagInfoGroup();
            Site tagInfoSite = SiteFixture.Denver();
            group.TagInfoList = TagInfoFixture.CreateTagInfoList(tagInfoSite,2);
            return group;
        }

        public static TagInfoGroup CreateNewSarniaTagInfoGroup()
        {
            String name = DateTimeFixture.DateTimeNow.Ticks.ToString(CultureInfo.InvariantCulture);
            Site site = SiteFixture.Sarnia();
            TagInfoGroup ret = new TagInfoGroup(null, name, site) {TagInfoList = TagInfoFixture.GetExistingSarniaTagInfoList()};
            return ret;
        }

        public static List<TagInfoGroup> CreateSampleExistingTagInfoGroupList(Site site,long scadaConnectionInfoId)
        {
            List<TagInfoGroup> ret = new List<TagInfoGroup>();
            int groupCount = 10;
            for(int i = 0; i < groupCount; i++)
            {
                string name = "TagInfo Group - " + i;
                TagInfoGroup group = new TagInfoGroup(i, name, site);
                group.TagInfoList = TagInfoFixture.CreateTagInfoList(site,scadaConnectionInfoId);
                ret.Add(group);
            }
            return ret;
        }

        public static TagInfoGroup CreateSampleExistingTagInfoGroup(Site site,long scadaConnectionInfoId)
        {
            TagInfoGroup ret = new TagInfoGroup(1, "Sampe TagInfo Group", site) {TagInfoList = TagInfoFixture.CreateTagInfoList(site,scadaConnectionInfoId)};
            return ret;
        }
    }
}
