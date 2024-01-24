using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class CustomFieldEntry : DomainObject, IComparable<CustomFieldEntry>
    {
        private string fieldEntry;
        private decimal? numericFieldEntry;
        private decimal? newnumericFieldEntry;      //ayman action item reading
        private List<CustomFieldDropDownValue> dropDownValues;

        public CustomFieldEntry(long? id, long? customFieldId, string customFieldName, string fieldEntry,
            decimal? numericFieldEntry,decimal? newnumericFieldEntry, int displayOrder, CustomFieldType type, CustomFieldPhdLinkType phdLinkType,List<CustomFieldDropDownValue> dropdownvalues)   //ayman action item reading
        {
            this.id = id;
            Type = type;
            PhdLinkType = phdLinkType;
            CustomFieldName = customFieldName;
            CustomFieldId = customFieldId;
            if (type != null)
            {
                if (type.Equals(CustomFieldType.NumericValue) && fieldEntry != null)
                {
                    throw new InvalidOperationException(
                        "Numeric custom field entries cannot specify text field entry values.");
                }
                if (!type.Equals(CustomFieldType.NumericValue) && numericFieldEntry != null)
                {
                    throw new InvalidOperationException(
                        "Non-numeric custom field entries cannot specify numeric field entry values.");
                }
            }

            this.fieldEntry = fieldEntry;
            this.numericFieldEntry = numericFieldEntry;
            this.newnumericFieldEntry = newnumericFieldEntry;                //ayman action item reading
            this.dropDownValues = dropdownvalues;
            DisplayOrder = displayOrder;
        }
        //Start Custom Field Changes By : Swapnil Patki
        public CustomFieldEntry(long? id, long? customFieldId, string customFieldName, string fieldEntry,
            decimal? numericFieldEntry,decimal? newnumericFieldEntry, int displayOrder, CustomFieldType type, CustomFieldPhdLinkType phdLinkType,       //ayman action item reading
            decimal? minvalueofrange, decimal? maxvalueofrange, decimal? greaterthanvalue, decimal? lessthanvalue, string color,List<CustomFieldDropDownValue> dropdownvalues)
        {
            this.id = id;
            this.dropDownValues = dropdownvalues;
            Type = type;
            PhdLinkType = phdLinkType;
            CustomFieldName = customFieldName;
            CustomFieldId = customFieldId;

            if (type.Equals(CustomFieldType.NumericValue) && fieldEntry != null)
            {
                throw new InvalidOperationException(
                    "Numeric custom field entries cannot specify text field entry values.");
            }
            if (!type.Equals(CustomFieldType.NumericValue) && numericFieldEntry != null)
            {
                throw new InvalidOperationException(
                    "Non-numeric custom field entries cannot specify numeric field entry values.");
            }

            this.fieldEntry = fieldEntry;
            this.numericFieldEntry = numericFieldEntry;
            this.newnumericFieldEntry = newnumericFieldEntry;            //ayman action item reading
            this.dropDownValues = dropDownValues;
            DisplayOrder = displayOrder;
            MinValueofRange = minvalueofrange; // Custom Field Changes By : Swapnil Patki
            MaxValueofRange = maxvalueofrange; // Custom Field Changes By : Swapnil Patki
            GreaterThanValue = greaterthanvalue; // Custom Field Changes By : Swapnil Patki
            LessThanValue = lessthanvalue; // Custom Field Changes By : Swapnil Patki
            Color = color; // Custom Field Changes By : Swapnil Patki
        }
        //End Custom Field Changes By : Swapnil Patki

        //public CustomFieldEntry(CustomField field)
        //    : this(null, field.Id, field.Name, null, null, field.DisplayOrder, field.Type, field.PhdLinkType) // Custom Field Changes By : Swapnil Patki
        //{
        //}

        public CustomFieldEntry(CustomField field) // Custom Field Changes By : Swapnil Patki
            : this(null, field.Id, field.Name, null, null,null, field.DisplayOrder, field.Type, field.PhdLinkType, field.MinValueofRange, field.MaxValueofRange, field.GreaterThanValue, field.LessThanValue, field.Color,field.DropDownValues)
        {
        }

        //public CustomFieldEntry(CustomFieldEntry entry) // Custom Field Changes By : Swapnil Patki
        //    : this(
        //        entry.Id, entry.CustomFieldId, entry.CustomFieldName, entry.FieldEntry, entry.NumericFieldEntry,
        //        entry.DisplayOrder, entry.Type, entry.PhdLinkType)
        //{
        //}

        public CustomFieldEntry(CustomFieldEntry entry) // Custom Field Changes By : Swapnil Patki
            : this(
                entry.Id, entry.CustomFieldId, entry.CustomFieldName, entry.FieldEntry, entry.NumericFieldEntry,entry.newnumericFieldEntry,
                entry.DisplayOrder, entry.Type, entry.PhdLinkType, entry.MinValueofRange,entry.MaxValueofRange,entry.GreaterThanValue,entry.LessThanValue,entry.Color,entry.dropDownValues)
        {
        }

//        public bool HasPhTagAssociated { get; private set; }

        public decimal? MinValueofRange { get; private set; } // Custom Field Changes By : Swapnil Patki

        public decimal? MaxValueofRange { get; private set; } // Custom Field Changes By : Swapnil Patki

        public decimal? GreaterThanValue { get; private set; } // Custom Field Changes By : Swapnil Patki

        public decimal? LessThanValue { get; private set; } // Custom Field Changes By : Swapnil Patki

        public string Color { get;  set; } // Custom Field Changes By : Swapnil Patki

        public string CustomFieldName { get; private set; }

        public long? CustomFieldId { get; private set; }

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

        public decimal? NewNumericFieldEntry
        {
            get { return newnumericFieldEntry; }
            set
            {
                if (!Type.Equals(CustomFieldType.NumericValue))
                {
                    throw new InvalidOperationException(
                        "The type of the custom field is not numeric. This setter cannot be used.");
                }

                newnumericFieldEntry = value;
            }
        }

        public string FieldEntryForDisplay
        {
            get
            {
                if (Type == null)
                    return null;
                if (Type.Equals(CustomFieldType.NumericValue))
                {
                    if (numericFieldEntry == null)
                    {
                        return null;
                    }

                    return NumericFieldEntry.Value.ToString("G29");
                }
                return FieldEntry;
            }
        }

        public string FieldEntry
        {
            get { return fieldEntry; }
            set
            {
                if (Type.Equals(CustomFieldType.NumericValue))
                {
                    throw new InvalidOperationException(
                        "The type of the custom field is numeric. Please use NumericFieldEntry.");
                }

                fieldEntry = value;
            }
        }

        public List<CustomFieldDropDownValue> DropDownValues { get { return dropDownValues; } set { dropDownValues = value; } }        //ayman action item reading

        public int DisplayOrder { get; set; }

        public CustomFieldType Type { get; private set; }

        public CustomFieldPhdLinkType PhdLinkType { get; private set; }

        public bool IsJustForDisplay
        {
            get { return Type == CustomFieldType.BlankSpace || Type == CustomFieldType.Heading; }
        }

        public int CompareTo(CustomFieldEntry other)
        {
            return DisplayOrder.CompareTo(other.DisplayOrder);
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

        public CustomFieldEntryHistory TakeSnapshot()
        {
            return new CustomFieldEntryHistory(null, Id, CustomFieldName, FieldEntryForDisplay);
        }

        public static List<CustomFieldEntryHistory> TakeSnapshots(List<CustomFieldEntry> entries,
            List<CustomField> customFields)
        {
            var snapshots = new List<CustomFieldEntryHistory>();

            foreach (var customField in customFields)
            {
                var customFieldEntry = entries.Find(entry => entry.CustomFieldId == customField.IdValue) ??
                                       new CustomFieldEntry(customField);

                snapshots.Add(customFieldEntry.TakeSnapshot());
            }

            return snapshots;
        }

        public static bool HasAtLeastOneNonEmptyEntry(List<CustomFieldEntry> customFieldEntries)
        {
            if (customFieldEntries == null) return false;
            foreach (var entry in customFieldEntries)
            {
                if (!entry.FieldEntryForDisplay.IsNullOrEmptyOrWhitespace())
                {
                    return true;
                }
            }
            return false;
        }

        // given a complete list of custom fields and a subset of entries, returns a complete list of entries
        public static List<CustomFieldEntry> PadEntriesWithBlanks(List<CustomField> customFields,
            List<CustomFieldEntry> entries)
        {
            var orderedFields = new List<CustomField>(customFields);
            orderedFields.Sort();

            var customFieldEntries = new List<CustomFieldEntry>();

            foreach (var field in orderedFields)
            {
                var customFieldEntry = entries.Find(entry => entry.CustomFieldId == field.IdValue) ??
                                       new CustomFieldEntry(field);

                customFieldEntries.Add(customFieldEntry);
            }

            for (var i = 0; i < customFieldEntries.Count; i++)
            {
                customFieldEntries[i].DisplayOrder = i;
            }

            return customFieldEntries;
        }
    }
}