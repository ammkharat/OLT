using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    public enum FieldType
    {
        Numeric,
        Text,
        DateTime
    }

    /// <summary>
    /// </summary>
    [Serializable]
    public class SearchField : DomainObject
    {
        private bool visible = true;

        public SearchField(string friendlyname, string name, FieldType fieldtype, bool visible)
        {
            FriendlyName = friendlyname;
            Name = name;
            Fieldtype = fieldtype;
            this.visible = visible;
        }

        public SearchField(string friendlyname, string name, FieldType fieldtype)
        {
            FriendlyName = friendlyname;
            Name = name;
            Fieldtype = fieldtype;
        }

        public string FriendlyName { get; set; }

        public string Name { get; set; }

        public FieldType Fieldtype { get; set; }

        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }


        public static List<SearchField> GetAllTagFields()
        {
            var list = new List<SearchField>
            {
                new SearchField(StringResources.TagSearchField_ID, "ID", FieldType.Numeric, false),
                new SearchField(StringResources.TagSearchField_TagName, "Name", FieldType.Text),
                new SearchField(StringResources.TagSearchField_Description, "Description", FieldType.Text),
                new SearchField(StringResources.TagSearchField_Units, "Units", FieldType.Text)
            };

            return list;
        }
    }
}