using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class CustomFieldFixture
    {
        public static CustomField CustomFieldExistingInDatabase1()
        {
            return new CustomField(15571, "OPP A", 0, 100, 100, 15571, null, CustomFieldType.DropDownList, CustomFieldPhdLinkType.Off, new List<CustomFieldDropDownValue>());
        }

        public static CustomField CustomFieldExistingInDatabase2()
        {
            return new CustomField(15572, "OPP B", 1, 100, 101, 15572, null, CustomFieldType.DropDownList, CustomFieldPhdLinkType.Off, new List<CustomFieldDropDownValue>());
        }

        public static CustomField CustomFieldExistingInDatabase3()
        {
            return new CustomField(15573, "OPP C", 2, 100, 102, 15573, null, CustomFieldType.DropDownList, CustomFieldPhdLinkType.Off, new List<CustomFieldDropDownValue>());
        }

        public static CustomField CreateCustomField(string name, int displayOrder)
        {
            return new CustomField(null, name, displayOrder, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
        }
    }
}