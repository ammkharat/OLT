using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.Bootstrap;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class BusinessCategoryDaoTest : AbstractDaoTest
    {
        private IBusinessCategoryDao businessCategoryDao;        

        protected override void TestInitialize()
        {
            Bootstrapper.BootstrapDaos();
            businessCategoryDao = DaoRegistry.GetDao<IBusinessCategoryDao>();            
        }

        protected override void Cleanup()
        {
            
        }

        [Ignore] [Test]
        public void ShouldInsertAndFindById()
        {            
            const string categoryName = "Some Fake Category";
            const string categoryShortName = "Short Name";
            User user = UserFixture.CreateUserWithGivenId(1);
            DateTime lastModified = new DateTime(2010, 1, 1);
            DateTime createDate = new DateTime(2010, 2, 15);

            BusinessCategory businessCategory = 
                new BusinessCategory(categoryName, categoryShortName, true, true, user, lastModified, createDate, SiteFixture.Sarnia().IdValue);

            BusinessCategory insertedCategory = businessCategoryDao.Insert(businessCategory);

            BusinessCategory queriedCategory = businessCategoryDao.QueryById(insertedCategory.IdValue);
            Assert.IsNotNull(queriedCategory);
                        
            Assert.AreEqual(categoryName, queriedCategory.Name);
            Assert.AreEqual(categoryShortName, queriedCategory.ShortName);
            Assert.AreEqual(user.Id, queriedCategory.LastModifiedBy.Id);
            Assert.AreEqual(1, queriedCategory.LastModifiedDateTime.Month);
            Assert.AreEqual(2, queriedCategory.CreatedDateTime.Month);
            Assert.IsTrue(queriedCategory.IsDefaultSAPNotificationCategory);
            Assert.IsTrue(queriedCategory.IsDefaultSAPWorkOrderCategory);
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {            
            const string categoryName = "Some Fake Category";
            const string shortName = "shrtnm";
            User user = UserFixture.CreateUserWithGivenId(1);
            DateTime lastModified = new DateTime(2010, 1, 1);
            DateTime createDate = new DateTime(2010, 2, 15);

            BusinessCategory businessCategory = new BusinessCategory(categoryName, shortName, user, lastModified, createDate, SiteFixture.Sarnia().IdValue);

            BusinessCategory insertedCategory = businessCategoryDao.Insert(businessCategory);

            BusinessCategory queriedCategory = businessCategoryDao.QueryById(insertedCategory.IdValue);

            const string updatedName = "Some fake Category (edited)";
            const string updatedShortName = "sn(edited)";
            User updatedUser = UserFixture.CreateUserWithGivenId(2);
            DateTime updatedLastModified = new DateTime(2010, 5, 12);

            queriedCategory.Name = updatedName;
            queriedCategory.ShortName = updatedShortName;
            queriedCategory.IsDefaultSAPNotificationCategory = true;
            queriedCategory.IsDefaultSAPWorkOrderCategory = true;
            queriedCategory.LastModifiedBy = updatedUser;            
            queriedCategory.LastModifiedDateTime = updatedLastModified;

            businessCategoryDao.Update(queriedCategory);

            BusinessCategory updatedResult = businessCategoryDao.QueryById(queriedCategory.IdValue);

            Assert.IsNotNull(updatedResult);

            Assert.AreEqual(updatedName, updatedResult.Name);
            Assert.AreEqual(updatedShortName, updatedResult.ShortName);

            Assert.IsTrue(updatedResult.IsDefaultSAPNotificationCategory);
            Assert.IsTrue(updatedResult.IsDefaultSAPWorkOrderCategory);

            Assert.AreEqual(updatedUser.Id, updatedResult.LastModifiedBy.Id);
            Assert.AreEqual(updatedLastModified.Month, updatedResult.LastModifiedDateTime.Month);
        }

        [Ignore] [Test]
        public void ShouldQueryAll()
        {
            List<BusinessCategory> all = businessCategoryDao.QueryAllBySite(SiteFixture.Sarnia().IdValue);
            Assert.IsNotEmpty(all);
        }
       
        [Ignore] [Test]
        public void ShouldGetCategoryDefaults()
        {
            // NOTE: these are hard-coded for the test, but if these tests ever run off real production data, and it has changed, then 
            // these won't run properly

            Assert.AreEqual("Equipment / Mechanical", businessCategoryDao.GetDefaultSAPWorkOrderCategory(SiteFixture.Sarnia().IdValue).Name);
            Assert.AreEqual("Environmental / Safety", businessCategoryDao.GetDefaultSAPNotificationCategory(SiteFixture.Sarnia().IdValue).Name);
        }

    }
}
