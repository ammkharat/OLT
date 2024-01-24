using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class BusinessCategoryFLOCAssociationDaoTest : AbstractDaoTest
    {
        private IBusinessCategoryFLOCAssociationDao associationDao;
        private IBusinessCategoryDao businessCategoryDao;

        protected override void TestInitialize()
        {
            businessCategoryDao = DaoRegistry.GetDao<IBusinessCategoryDao>();
            associationDao = DaoRegistry.GetDao<IBusinessCategoryFLOCAssociationDao>();            
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsertAndQueryById()
        {
            BusinessCategoryFLOCAssociation associationReturnedFromInsert = InsertAssociationIntoDatabase();

            Assert.IsNotNull(associationReturnedFromInsert);

            List<BusinessCategoryFLOCAssociation> results = associationDao.QueryByFLOCId(associationReturnedFromInsert.FunctionalLocation.Id);

            BusinessCategoryFLOCAssociation associationToCheck = results.Find(obj => obj.Id == associationReturnedFromInsert.Id);
            Assert.IsNotNull(associationToCheck);
            Assert.AreEqual("Test abc123", associationToCheck.BusinessCategory.Name);
            Assert.AreEqual("test", associationToCheck.BusinessCategory.ShortName);            

            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1();
            Assert.AreEqual(floc.Id, associationToCheck.FunctionalLocation.Id);
        }

        [Ignore] [Test]
        public void ShouldQueryByFLOCId()
        {
            User user = UserFixture.CreateUserWithGivenId(1);
            BusinessCategory savedCategory1 = SaveBusinessCategoryToDatabase("Test abc123 1", "test 1", user);
            BusinessCategory savedCategory2 = SaveBusinessCategoryToDatabase("Test abc123 2", "test 2", user);

            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1();

            BusinessCategoryFLOCAssociation association1 =
                new BusinessCategoryFLOCAssociation(floc, savedCategory1, user, DateTimeFixture.DateTimeNow);
            BusinessCategoryFLOCAssociation association2 =
                new BusinessCategoryFLOCAssociation(floc, savedCategory2, user, DateTimeFixture.DateTimeNow);

            associationDao.Insert(association1);
            associationDao.Insert(association2);

            List<BusinessCategoryFLOCAssociation> associations = associationDao.QueryByFLOCId(floc.IdValue);

            Assert.IsNotNull(associations);
            Assert.IsTrue(associations.Count >= 2);

            BusinessCategoryFLOCAssociation queriedAssociation1 = associations.FindById(association1);
            Assert.AreEqual("test 1", queriedAssociation1.BusinessCategory.ShortName);

            BusinessCategoryFLOCAssociation queriedAssociation2 = associations.FindById(association2);
            Assert.AreEqual("test 2", queriedAssociation2.BusinessCategory.ShortName);
        }

        [Ignore] [Test]
        [ExpectedException("Com.Suncor.Olt.Common.Exceptions.SqlWrapperException")]
        public void ShouldNotAllowDuplicateAssociationsToBeInserted()
        {
            User user = UserFixture.CreateUserWithGivenId(1);
            BusinessCategory savedCategory = SaveBusinessCategoryToDatabase("Test abc123 1", "test 1", user);

            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1();

            BusinessCategoryFLOCAssociation association1 =
                new BusinessCategoryFLOCAssociation(floc, savedCategory, user, DateTimeFixture.DateTimeNow);

            associationDao.Insert(association1);
            associationDao.Insert(association1);
        }

        [Ignore] [Test]
        public void ShouldDeleteAllByFlocId()
        {
            User user = UserFixture.CreateUserWithGivenId(1);
            BusinessCategory savedReasonCode1 = SaveBusinessCategoryToDatabase("Test abc123 1", "test 1", user);
            BusinessCategory savedReasonCode2 = SaveBusinessCategoryToDatabase("Test abc123 2", "test 2", user);

            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3();

            BusinessCategoryFLOCAssociation association1 =
                new BusinessCategoryFLOCAssociation(floc, savedReasonCode1, user, DateTimeFixture.DateTimeNow);
            BusinessCategoryFLOCAssociation association2 =
                new BusinessCategoryFLOCAssociation(floc, savedReasonCode2, user, DateTimeFixture.DateTimeNow);

            associationDao.Insert(association1);
            associationDao.Insert(association2);

            List<BusinessCategoryFLOCAssociation> associations = associationDao.QueryByFLOCId(floc.IdValue);

            Assert.IsNotNull(associations);
            Assert.IsTrue(associations.Count >= 2);

            associationDao.DeleteAllByFLOCId(floc.IdValue);

            associations = associationDao.QueryByFLOCId(floc.IdValue);

            Assert.IsNotNull(associations);
            Assert.IsTrue(associations.Count == 0);
        }

        private BusinessCategoryFLOCAssociation InsertAssociationIntoDatabase()
        {
            // Insert Restriction Reason Code
            User user = UserFixture.CreateUserWithGivenId(1);
            BusinessCategory savedBusinessCategory = SaveBusinessCategoryToDatabase("Test abc123", "test", user);

            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1();

            // Insert association
            DateTime expectedDate = DateTimeFixture.DateTimeNow;
            BusinessCategoryFLOCAssociation association =
                new BusinessCategoryFLOCAssociation(floc, savedBusinessCategory, user, expectedDate);

            BusinessCategoryFLOCAssociation associationReturnedFromInsert = associationDao.Insert(association);

            return associationReturnedFromInsert;
        }

        private BusinessCategory SaveBusinessCategoryToDatabase(string name, string shortName, User user)
        {
            BusinessCategory bc = new BusinessCategory(name, shortName, user, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow, SiteFixture.Sarnia().IdValue);
            return businessCategoryDao.Insert(bc);
        }
    }
}