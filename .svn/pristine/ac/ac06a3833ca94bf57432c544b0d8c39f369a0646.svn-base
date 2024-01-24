using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class CustomField : DomainObject, IHasDisplayOrder
    {
        public CustomField(long? id, string name, int displayOrder, long? customFieldGroupId,
            long? originCustomFieldGroupId, long? originCustomFieldId, TagInfo tagInfo,
            CustomFieldType type, CustomFieldPhdLinkType phdLinkType, List<CustomFieldDropDownValue> dropDownValues)
        {
            this.id = id;
            OriginCustomFieldId = originCustomFieldId;
            Name = name;
            DisplayOrder = displayOrder;
            TagInfo = tagInfo;
            Type = type;
            PhdLinkType = phdLinkType;
            DropDownValues = dropDownValues;
            GroupId = customFieldGroupId;
            OriginCustomFieldGroupId = originCustomFieldGroupId;

        }

        public CustomField(long? id, string name, int displayOrder, long? customFieldGroupId,
            long? originCustomFieldGroupId, long? originCustomFieldId, TagInfo tagInfo,
            CustomFieldType type, CustomFieldPhdLinkType phdLinkType, List<CustomFieldDropDownValue> dropDownValues,
            decimal? minvalueofrange, decimal? maxvalueofrange, decimal? greaterthanvalue, decimal? lessthanvalue, string color, bool? isactive, DateTime? date)
        {
            this.id = id;
            OriginCustomFieldId = originCustomFieldId;
            Name = name;
            DisplayOrder = displayOrder;
            TagInfo = tagInfo;
            Type = type;
            PhdLinkType = phdLinkType;
            DropDownValues = dropDownValues;
            GroupId = customFieldGroupId;
            OriginCustomFieldGroupId = originCustomFieldGroupId;
            MinValueofRange = minvalueofrange;
            MaxValueofRange = maxvalueofrange;
            GreaterThanValue = greaterthanvalue;
            LessThanValue = lessthanvalue;
            Color = color;
            IsActive = isactive;
            Date = date;
        }

        public CustomField(long? id, string name, int displayOrder, TagInfo tagInfo, CustomFieldType type,
            CustomFieldPhdLinkType phdLinkType, List<CustomFieldDropDownValue> dropDownValues)
            : this(id, name, displayOrder, null, null, null, tagInfo, type, phdLinkType, dropDownValues)
        {
        }

        public CustomField(long? id, string name, int displayOrder, TagInfo tagInfo, CustomFieldType type,
            CustomFieldPhdLinkType phdLinkType, List<CustomFieldDropDownValue> dropDownValues, decimal? minvalueofrange, decimal? maxvalueofrange, decimal? greaterthanvalue, decimal? lessthanvalue, string color, bool? isactive, DateTime? date)
            : this(id, name, displayOrder, null, null, null, tagInfo, type, phdLinkType, dropDownValues, minvalueofrange, maxvalueofrange, greaterthanvalue, lessthanvalue,color,isactive,date)
        {
        }

        public decimal? MinValueofRange { get; set; }

        public decimal? MaxValueofRange { get; set; }

        public decimal? GreaterThanValue { get; set; }

        public decimal? LessThanValue { get; set; }

        public string Color { get; private set; }

        public bool? IsActive { get;  set; }

        public DateTime? Date { get; set; }

        public long? OriginCustomFieldId { get; set; }

        public long? GroupId { get; set; }

        public string Name { get; set; }

        public TagInfo TagInfo { get; set; }

        public CustomFieldType Type { get; set; }

        public CustomFieldPhdLinkType PhdLinkType { get; set; }

        public List<CustomFieldDropDownValue> DropDownValues { get; set; }

        public long? OriginCustomFieldGroupId { get; set; }
        public int DisplayOrder { get; set; }

        public CustomField Clone()
        {
            var clone = this.DeepClone();
            clone.Id = null;
            return clone;
        }

        public override int CompareTo(DomainObject other)
        {
            if (other == null)
            {
                return base.CompareTo(null);
            }

            var otherCustomField = (CustomField) other;
            return CompareByOriginGroupAndThenDisplayOrder(this, otherCustomField);
        }

        private static int CompareByOriginGroupAndThenDisplayOrder(CustomField x, CustomField y)
        {
            if (x.OriginCustomFieldGroupId == y.OriginCustomFieldGroupId)
            {
                return x.DisplayOrder.CompareTo(y.DisplayOrder);
            }

            if (x.OriginCustomFieldGroupId == null)
            {
                return -1;
            }
            if (y.OriginCustomFieldGroupId == null)
            {
                return 1;
            }
            return x.OriginCustomFieldGroupId.Value.CompareTo(y.OriginCustomFieldGroupId.Value);
        }

        public static void SortAndResetDisplayOrder(List<CustomField> customFields)
        {
            customFields.Sort();
            var currentDisplayOrder = 0;
            customFields.ForEach(field => field.DisplayOrder = currentDisplayOrder++);
        }

        public static bool HasAtLeastOneReadFromPhdCustomField(List<CustomField> customFields)
        {
            return
                customFields.Exists(field => field.PhdLinkType == CustomFieldPhdLinkType.Read && field.TagInfo != null);
        }

        public static bool HasAtLeastOneWriteToPhdCustomField(List<CustomField> customFields)
        {
            return
                customFields.Exists(field => field.PhdLinkType == CustomFieldPhdLinkType.Write && field.TagInfo != null);
        }
    }
}