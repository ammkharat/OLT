using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class CustomFieldDropDownValue : DomainObject, IHasDisplayOrder
    {
        public CustomFieldDropDownValue(long? customFieldId, string value, int displayOrder)
        {
            CustomFieldId = customFieldId;
            Value = value;
            DisplayOrder = displayOrder;
        }

        public long? CustomFieldId { get; set; }
        public string Value { get; set; }
        public int DisplayOrder { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}