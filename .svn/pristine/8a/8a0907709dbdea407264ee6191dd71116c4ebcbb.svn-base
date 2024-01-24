using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class TagInfoGroup : DomainObject
    {
        private readonly Site site;
        private string name;
        private List<TagInfo> tagInfoList;

        private TagInfoGroup(long? id, string name, Site site, IEnumerable<TagInfo> tagInfoList)
        {
            this.id = id;
            this.name = name;
            this.site = site;
            this.tagInfoList = new List<TagInfo>(tagInfoList);
        }

        public TagInfoGroup(long? id, string name, Site site)
            : this(id, name, site, new List<TagInfo>())
        {
        }

        public TagInfoGroup(TagInfoGroup originalTagInfoGroup)
            : this(
                originalTagInfoGroup.id, originalTagInfoGroup.name, originalTagInfoGroup.site,
                originalTagInfoGroup.tagInfoList)
        {
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Site Site
        {
            get { return site; }
        }

        public List<TagInfo> TagInfoList
        {
            get { return tagInfoList; }
            set { tagInfoList = value; }
        }
    }
}