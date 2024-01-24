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
    public class BusinessCategoryFLOCAssociationServiceClientTest
    {
        private const long ID_OF_UNIT_LEVEL_FLOC = 27560;

        private IBusinessCategoryFLOCAssociationService associationService;
        private IBusinessCategoryService businessCategoryService;
        private IFunctionalLocationService flocService;

        [SetUp]
        public void SetUp()
        {
            associationService = GenericServiceRegistry.Instance.GetService<IBusinessCategoryFLOCAssociationService>();
            businessCategoryService = GenericServiceRegistry.Instance.GetService<IBusinessCategoryService>();
            flocService = GenericServiceRegistry.Instance.GetService<IFunctionalLocationService>();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test][Ignore]
        public void ShouldRecreateBusinessCategoryFLOCAssociations()
        {
            var user = UserFixture.CreateUserWithGivenId(1);

            var code1 = new BusinessCategory("$$$ 555 Fake Category 1", "cat 1", user, DateTimeFixture.DateTimeNow,
                DateTimeFixture.DateTimeNow, SiteFixture.Sarnia().IdValue);
            var code2 = new BusinessCategory("$$$ 555 Fake Category 2", "cat 2", user, DateTimeFixture.DateTimeNow,
                DateTimeFixture.DateTimeNow, SiteFixture.Sarnia().IdValue);
            var code3 = new BusinessCategory("$$$ 555 Fake Category 3", "cat 3", user, DateTimeFixture.DateTimeNow,
                DateTimeFixture.DateTimeNow, SiteFixture.Sarnia().IdValue);

            var insertedBusinessCategoriesWithIds =
                businessCategoryService.Save(new List<BusinessCategory> {code1, code2, code3},
                    new List<BusinessCategory>(0), new List<BusinessCategory>(0),
                    UserFixture.CreateSAPUser(), DateTimeFixture.DateTimeNow);

            var testFloc = flocService.QueryById(ID_OF_UNIT_LEVEL_FLOC);
            Assert.IsNotNull(testFloc);

            var associationList = new List<BusinessCategoryFLOCAssociation>();

            foreach (var businessCategory in insertedBusinessCategoriesWithIds)
            {
                var newFlocAssociation
                    = new BusinessCategoryFLOCAssociation(testFloc, businessCategory, user, DateTimeFixture.DateTimeNow);
                associationList.Add(newFlocAssociation);
            }

            associationService.RecreateFLOCAssociations(associationList, testFloc, user, DateTimeFixture.DateTimeNow);

            var assocications =
                associationService.QueryByFLOCId(ID_OF_UNIT_LEVEL_FLOC);

            Assert.AreEqual(3, assocications.Count);

            // Now recreate with just one reason code. There should only be the one after.

            var listWithOneReasonCode =
                new List<BusinessCategoryFLOCAssociation> {associationList[0]};
            associationService.RecreateFLOCAssociations(listWithOneReasonCode, testFloc, user,
                DateTimeFixture.DateTimeNow);

            var onlyOneFlocAssociation =
                associationService.QueryByFLOCId(ID_OF_UNIT_LEVEL_FLOC);

            Assert.AreEqual(1, onlyOneFlocAssociation.Count);
        }
    }
}