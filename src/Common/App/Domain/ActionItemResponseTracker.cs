using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;



namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class ActionItemResponseTracker : DomainObject, IHasDisplayOrder
    {
        private decimal? numericFieldEntry;

        public ActionItemResponseTracker(long actionitemdefinitionid, long actionitemid, long customfieldid,string customfieldname, int displayOrder,byte typeid, decimal? currentvalue, decimal? newvalue, string comment,byte phdlinktypeid,long batchnumber,string fieldentry, List<string> dropDownValues,string displayfield)
        {
            ActionItemDefinitionId = actionitemdefinitionid;            //ayman action item reading
            ActionItemId = actionitemid;
            CustomFieldId = customfieldid;
            CustomFieldName = customfieldname;
            DisplayOrder = displayOrder;
            TypeId = typeid;
            CurrentValue =  currentvalue;
            NewValue = newvalue;
            Comment = comment;
            PhdLinkTypeId = phdlinktypeid;
            BatchNumber = batchnumber;
            FieldEntry = fieldentry;
            DropDownValues = dropDownValues;
            DisplayField = displayfield;
        }

        public byte TypeId { get; set; }
        public string FieldEntry { get; set; }
        public string DisplayField { get; set; }
        public List<string> DropDownValues { get; set; }                 //ayman action item reading
        public byte PhdLinkTypeId { get; set; }
        public string Comment { get; set; }
        public long BatchNumber { get; set; }
        public long ActionItemId { get; set; }
        public long ActionItemDefinitionId { get; set; }                            //ayman action item reading

        public long CustomFieldId { get; set; }

        public string CustomFieldName { get; set; }

        public int DisplayOrder { get; set; }

        public string Color { get; private set; }

        public decimal? CurrentValue { get; set; }

        public decimal? NewValue { get; set; }



        public TagInfo TagInfo { get; set; }

        public CustomFieldType Type { get; set; }

        public CustomFieldPhdLinkType PhdLinkType { get; set; }


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

        public decimal? NumericFieldEntry
        {
            get { return numericFieldEntry; }
            set
            {
                if (!Type.Equals(CustomFieldType.NumericValue))
                {
                    throw new InvalidOperationException(
                        "The type of the custom field is not numeric. This setter cannot be used.");
                }

                numericFieldEntry = value;
            }
        }

        public void SetValue(string value)
        {
            if (Type.Equals(CustomFieldType.NumericValue))
            {
                decimal result;
                var parseWasSuccessful = Decimal.TryParse(value, out result);
                if (parseWasSuccessful)
                {
                    NumericFieldEntry = result;
                }
                else
                {
                    NumericFieldEntry = null;
                }
            }
            else
            {
                FieldEntry = value;
            }
        }


        public static void SortAndResetDisplayOrder(List<ActionItemResponseTracker> customFields)
        {
            customFields.Sort();
            var currentDisplayOrder = 0;
            customFields.ForEach(field => field.DisplayOrder = currentDisplayOrder++);
        }

        public static bool HasAtLeastOneReadFromPhdCustomField(List<ActionItemResponseTracker> customFields)
        {
            return
                customFields.Exists(field => field.PhdLinkType == CustomFieldPhdLinkType.Read && field.TagInfo != null);
        }

        public static bool HasAtLeastOneWriteToPhdCustomField(List<ActionItemResponseTracker> customFields)
        {
            return
                customFields.Exists(field => field.PhdLinkType == CustomFieldPhdLinkType.Write && field.TagInfo != null);
        }
    }
}