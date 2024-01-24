using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Utility.Cache;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class DropdownValue : DomainObject, IHasDisplayOrder, ICacheBySiteId
    {
        private readonly string key;
        private readonly long siteId;
        private int displayOrder;
        private string value;

        public DropdownValue(long siteId, string key, string value, int displayOrder)
            : this(null, siteId, key, value, displayOrder)
        {
        }

        public DropdownValue(long? id, long siteId, string key, string value, int displayOrder)
        {
            this.id = id;
            this.siteId = siteId;
            this.key = key;
            this.value = value;
            this.displayOrder = displayOrder;
        }

        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public string Name
        {
            get { return Value; }
        }

        public string Key
        {
            get { return key; }
        }

        public long SiteId
        {
            get { return siteId; }
        }

        public int DisplayOrder
        {
            get { return displayOrder; }
            set { displayOrder = value; }
        }

        public static List<String> DropdownValuesForKey(String queryKey, List<DropdownValue> dropdownValues)
        {
            var relevantDropdownValues = dropdownValues.FindAll(obj => obj.Key.ToLower() == queryKey.ToLower());
            relevantDropdownValues.Sort((x, y) => x.DisplayOrder.CompareTo(y.DisplayOrder));
            var values = relevantDropdownValues.ConvertAll(dropdownValue => dropdownValue.Value);
            values.Insert(0, String.Empty);
            return values;
        }
    }
}