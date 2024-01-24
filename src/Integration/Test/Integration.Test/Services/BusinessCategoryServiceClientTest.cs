using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class BusinessCategoryServiceClientTest
    {
        private IBusinessCategoryService businessCategoryService;
        private IFunctionalLocationService flocService;

        [SetUp]
        public void SetUp()
        {
            businessCategoryService = GenericServiceRegistry.Instance.GetService<IBusinessCategoryService>();
            flocService = GenericServiceRegistry.Instance.GetService<IFunctionalLocationService>();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test][Ignore]
        public void ShouldGetDefaults()
        {
            var siteId = SiteFixture.Sarnia().IdValue;

            var category = businessCategoryService.GetDefaultSAPWorkOrderCategory(siteId);
            Assert.IsNotNull(category);
            Assert.AreEqual("Equipment / Mechanical", category.Name); // default in June, 2010.

            category = businessCategoryService.GetDefaultSAPNotificationCategory(siteId);
            Assert.IsNotNull(category);
            Assert.AreEqual("Environmental / Safety", category.Name); // default in June, 2010.
        }

        [Test][Ignore]
        public void ShouldGetUniqueCategoriesForFlocList()
        {
            var division = flocService.QueryByFullHierarchy("SR1", Site.SARNIA_ID);
            var divisions = new List<FunctionalLocation>
            {
                division,
                division
            };

            var categories = businessCategoryService.QueryUniqueCategoriesByFunctionalLocationList(divisions);

            Assert.IsNotEmpty(categories);

            foreach (var businessCategory in categories)
            {
                if (
                    categories.Exists(
                        category => category.Id == businessCategory.Id && !ReferenceEquals(category, businessCategory)))
                {
                    Assert.Fail("Duplicate found");
                }
            }
        }

        [Test][Ignore]
        public void ShouldInsert()
        {
            var siteId = SiteFixture.Sarnia().IdValue;

            var name = "cat" + DateTime.Now.Ticks;

            {
                var all = businessCategoryService.QueryAllBySite(siteId);
                Assert.IsFalse(all.Exists(obj => obj.Name == name));
            }

            var user = UserFixture.CreateUserWithGivenId(1);
            var businessCategory = new BusinessCategory(name, "Short Name", user, DateTimeFixture.DateTimeNow,
                DateTimeFixture.DateTimeNow, siteId);

            businessCategoryService.Save(new List<BusinessCategory> {businessCategory}, new List<BusinessCategory>(0),
                new List<BusinessCategory>(0), user, DateTimeFixture.DateTimeNow);
            {
                var all = businessCategoryService.QueryAllBySite(siteId);
                Assert.IsTrue(all.Exists(obj => obj.Name == name));
            }
        }
    }
}