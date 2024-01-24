using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class TagInfo : DomainObject
    {
        private const int DESCRIPTION_MAX_LENGTH = 100;
        private string description;
        private string scadaProviderDescription;

        public TagInfo(long? siteId, string name, string description, string units, bool deleted,
            long? scadaConnectionInfoId)
            : this(new long?(), siteId, name, description, units, deleted, scadaConnectionInfoId)
        {
        }

        public TagInfo(long? id, long? siteId, string name, string description, string units, bool deleted,
            long? scadaConnectionInfoId)
        {
            this.id = id;
            Name = name;
            Description = description;
            Units = units;
            SiteId = siteId;
            Deleted = deleted;
            ScadaConnectionInfoId = scadaConnectionInfoId;
        }

        public string Name { get; private set; }

        public string Description
        {
            get { return description; }
            set { description = value.NullToEmpty().LeftSubstring(DESCRIPTION_MAX_LENGTH); }
        }

        public string ScadaProviderDescription
        {
            get { return scadaProviderDescription; }
            set { scadaProviderDescription = value; }
        }

        public string Units { get; set; }

        public long? SiteId { get; private set; }

        public bool Deleted { get; private set; }
        public long? ScadaConnectionInfoId { get; set; }

        public string NameAndDescription
        {
            get { return string.Format("{0} ({1})", Name, Description); }
        }

        public static TagInfo CreateEmpty()
        {
            return new NullTagInfo();
        }

        [Serializable]
        private class NullTagInfo : TagInfo
        {
            public NullTagInfo() : base(null, string.Empty, string.Empty, string.Empty, false, null)
            {
            }
        }
    }
}