using System.Collections.Generic;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class CustomFieldTest
    {
        [Test]
        public void ShouldSortByOriginGroupIdAndThenDisplayOrder()
        {
            const int originCustomFieldGroupId = 1;
            const int anotherOriginCustomFieldGroupId = 2;

            CustomField cf1 = new CustomField(1, "a", 1, null, originCustomFieldGroupId, null, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            CustomField cf2 = new CustomField(2, "a", 2, null, originCustomFieldGroupId, null, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            CustomField cf3 = new CustomField(3, "a", 1, null, anotherOriginCustomFieldGroupId, null, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            CustomField cf4 = new CustomField(4, "a", 2, null, anotherOriginCustomFieldGroupId, null, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);

            List<CustomField> customFields = new List<CustomField> { cf3, cf1, cf2, cf4 };

            customFields.Sort();

            Assert.AreEqual(1, customFields[0].IdValue);
            Assert.AreEqual(2, customFields[1].IdValue);
            Assert.AreEqual(3, customFields[2].IdValue);
            Assert.AreEqual(4, customFields[3].IdValue);
        }

    }
}
