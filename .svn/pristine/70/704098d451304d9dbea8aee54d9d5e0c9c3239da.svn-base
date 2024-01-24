using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class WorkPermitAttributeTest
    {
        [Test]
        public void ClassificationShouldDetectPropertyClassification()
        {
            var propertyAttribute = new SarniaWorkPermitAttribute(WorkPermitAttribute.Classification.Property);
            Assert.IsFalse(propertyAttribute.IsGroup);
        }

        [Test]
        public void ClassificationShouldDetectGroupClassification()
        {
            var groupAttribute = new SarniaWorkPermitAttribute(WorkPermitAttribute.Classification.Group);
            Assert.IsTrue(groupAttribute.IsGroup);
        }

        [Test]
        public void ClassificationShouldDefaultToPropertyClassification()
        {
            var propertyAttribute = new SarniaWorkPermitAttribute();
            Assert.IsFalse(propertyAttribute.IsGroup);
        }

        [Test]
        public void PreSetterPropertyShouldReturnPropertyName()
        {
            var attribute = new SarniaWorkPermitAttribute("FraggleRock");
            Assert.AreEqual("FraggleRock", attribute.PreSetterProperty);
            Assert.IsTrue(attribute.HasPreSetterProperty);
        }

        [Test]
        public void HasPreSetterPropertyShouldReturnFalseIfNotProvided()
        {
            var attribute = new SarniaWorkPermitAttribute();
            Assert.IsFalse(attribute.HasPreSetterProperty);           
        }

        [Test]
        public void IsForSite()
        {
            var denverAttribute = new DenverWorkPermitAttribute();
            Assert.IsTrue(denverAttribute.IsForSite(SiteFixture.Denver().IdValue));
            Assert.IsFalse(denverAttribute.IsForSite(SiteFixture.Sarnia().IdValue));

            var sarniaAttribute = new SarniaWorkPermitAttribute();
            Assert.IsTrue(sarniaAttribute.IsForSite(SiteFixture.Sarnia().IdValue));
            Assert.IsFalse(sarniaAttribute.IsForSite(SiteFixture.Denver().IdValue));
        }

        [Test]
        public void ShouldSortPropertiesByOrderingDesignation()
        {            
            var firstAttribute = new SarniaWorkPermitAttribute(WorkPermitAttribute.Ordering.FirstSet, "First");
            var secondAttribute = new SarniaWorkPermitAttribute(WorkPermitAttribute.Ordering.SecondSet, "Second");
            var thirdAttribute = new SarniaWorkPermitAttribute(WorkPermitAttribute.Ordering.ThirdSet, "Third");
            var fourthAttribute = new SarniaWorkPermitAttribute(WorkPermitAttribute.Ordering.FourthSet, "Fourth");
            var dontCareAboutOrderingAttribute = new SarniaWorkPermitAttribute("DontCareAboutOrdering");

            var attributeList = new List<WorkPermitAttribute> { dontCareAboutOrderingAttribute, secondAttribute, firstAttribute, thirdAttribute, fourthAttribute };
            var expectedList = new List<WorkPermitAttribute> { firstAttribute, secondAttribute, thirdAttribute, fourthAttribute, dontCareAboutOrderingAttribute };
            attributeList.Sort();
            Assert.AreEqual(expectedList, attributeList);
        }
    }
}
