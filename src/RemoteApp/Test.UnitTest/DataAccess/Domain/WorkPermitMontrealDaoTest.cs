using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]    
    public class WorkPermitMontrealDaoTest : AbstractDaoTest
    {
        private IWorkPermitMontrealDao workPermitDao;
        private IWorkPermitMontrealTemplateDao templateDao;
        private WorkPermitMontrealTemplate template;
        private IPermitRequestMontrealDao permitRequestDao;
        private IWorkPermitMontrealGroupDao groupDao;

 
        protected override void TestInitialize()
        {
            workPermitDao = DaoRegistry.GetDao<IWorkPermitMontrealDao>();
            templateDao = DaoRegistry.GetDao<IWorkPermitMontrealTemplateDao>();
            template = templateDao.QueryAllNotDeleted()[0];
            groupDao = DaoRegistry.GetDao<IWorkPermitMontrealGroupDao>();
            permitRequestDao = DaoRegistry.GetDao<IPermitRequestMontrealDao>();
        }

        protected override void Cleanup()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldInsertMontrealWorkPermit()
        {
            WorkPermitMontreal workPermit = WorkPermitMontrealFixture.CreateForInsert();
            workPermit.Template = template;
            workPermit.IssuedDateTime = new DateTime(2013, 1, 1, 8, 30, 0);

            workPermit.FunctionalLocations.Clear();
            workPermit.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_MT1_A001_U010());
            workPermit.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_MT1_A002_U430());

            workPermit = workPermitDao.Insert(workPermit, null);
            Assert.That(workPermit.Id, Is.GreaterThan(0));

            {
                WorkPermitMontreal requeried = workPermitDao.QueryById(workPermit.IdValue);
                Assert.IsNotNull(requeried);
                Assert.AreEqual(workPermit.DataSource, requeried.DataSource);
                Assert.AreEqual(workPermit.WorkPermitStatus, requeried.WorkPermitStatus);
                Assert.AreEqual(workPermit.WorkPermitType, requeried.WorkPermitType);
                Assert.That(requeried.StartDateTime, Is.EqualTo(workPermit.StartDateTime).Within(TimeSpan.FromSeconds(10)));
                Assert.That(requeried.EndDateTime, Is.EqualTo(workPermit.EndDateTime).Within(TimeSpan.FromSeconds(10)));
                Assert.That(requeried.IssuedDateTime, Is.EqualTo(workPermit.IssuedDateTime).Within(TimeSpan.FromSeconds(10)));                
                Assert.AreEqual(workPermit.WorkOrderNumber, requeried.WorkOrderNumber);
                Assert.AreEqual(workPermit.Trade, requeried.Trade);
                Assert.AreEqual(workPermit.Description, requeried.Description);
                Assert.AreEqual(template.Id, requeried.Template.Id);
                Assert.AreEqual(workPermit.RequestedByGroup.Id, requeried.RequestedByGroup.Id);

                Assert.AreEqual(workPermit.FunctionalLocations.Count, requeried.FunctionalLocations.Count);
                foreach (FunctionalLocation functionalLocation in workPermit.FunctionalLocations)
                {
                    Assert.IsTrue(requeried.FunctionalLocations.Exists(floc => floc.Id == functionalLocation.Id));
                }
            }
        }

        [Ignore] [Test]
        public void ShouldUpdateMontrealWorkPermit()
        {
            WorkPermitMontreal workPermit = WorkPermitMontrealFixture.CreateForInsert();
            workPermit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Issued;            
            workPermit.Template = null;
            workPermit.FunctionalLocations.Clear();
            workPermit.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_MT1_A001_U010());
            workPermit.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_MT1_A002_U430());
            workPermit.IssuedDateTime = new DateTime(2013, 1, 1, 8, 30, 0);

            workPermit = workPermitDao.Insert(workPermit, null);
            workPermit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Complete;
            workPermit.RequestedByGroup = null;
            workPermit.Template = template;
            workPermit.FunctionalLocations.Clear();
            workPermit.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_MT1_A001_U010());
            workPermit.WorkPermitType = WorkPermitMontrealType.FRESH_AIR_MASK;
            workPermit.IssuedDateTime = new DateTime(2013, 2, 2, 7, 45, 0);
            workPermit.UsePreviousPermitAnswered = true;
            workPermitDao.Update(workPermit);

            WorkPermitMontreal updatedPermit = workPermitDao.QueryById(workPermit.IdValue);
            Assert.That(updatedPermit, Is.Not.Null);
            Assert.That(updatedPermit.WorkPermitStatus, Is.EqualTo(PermitRequestBasedWorkPermitStatus.Complete));
            Assert.AreEqual(template.Id, updatedPermit.Template.Id);
            Assert.AreEqual(1, updatedPermit.FunctionalLocations.Count);
            Assert.AreEqual(FunctionalLocationFixture.GetReal_MT1_A001_U010().Id, updatedPermit.FunctionalLocations[0].Id);
            Assert.AreEqual(WorkPermitMontrealType.FRESH_AIR_MASK, updatedPermit.WorkPermitType);
            Assert.AreEqual(null, updatedPermit.RequestedByGroup);
            Assert.That(new DateTime(2013, 2, 2, 7, 45, 0), Is.EqualTo(workPermit.IssuedDateTime).Within(TimeSpan.FromSeconds(10)));
            Assert.IsTrue(updatedPermit.UsePreviousPermitAnswered);
            
        }
       
        [Ignore] [Test]
        public void ShouldInsertPermitNumber_And_UpdatePermitAndNotCreateAnotherPermitNumber()
        {
            WorkPermitMontreal workPermit = CreateForInsert(PermitRequestBasedWorkPermitStatus.Pending);

            workPermit = workPermitDao.Insert(workPermit, null);
            Assert.IsNotNull(workPermit.PermitNumber);
            long returnedPermitNumber = workPermit.PermitNumber.Value;

            {
                WorkPermitMontreal requeried = workPermitDao.QueryById(workPermit.IdValue);
                Assert.IsNotNull(requeried);
                Assert.IsNotNull(requeried.PermitNumber);
                Assert.AreEqual(returnedPermitNumber, requeried.PermitNumber);
            }

            workPermit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Issued;
            
            workPermitDao.Update(workPermit);
            Assert.IsNotNull(workPermit.PermitNumber);
            Assert.AreEqual(returnedPermitNumber, workPermit.PermitNumber);

            {
                WorkPermitMontreal requeried = workPermitDao.QueryById(workPermit.IdValue);
                Assert.IsNotNull(requeried);
                Assert.AreEqual(returnedPermitNumber, requeried.PermitNumber);
            }
        }

        [Ignore] [Test]
        public void ShouldInsertNoPermitNumber_And_UpdatePermitAndCreatePermitNumber()
        {
            WorkPermitMontreal workPermit = CreateForInsert(PermitRequestBasedWorkPermitStatus.Requested);

            workPermit = workPermitDao.Insert(workPermit, null);
            Assert.IsNull(workPermit.PermitNumber);

            {
                WorkPermitMontreal requeried = workPermitDao.QueryById(workPermit.IdValue);
                Assert.IsNotNull(requeried);
                Assert.IsNull(requeried.PermitNumber);
            }

            workPermit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Pending;

            workPermitDao.Update(workPermit);
            Assert.IsNotNull(workPermit.PermitNumber);
            long returnedPermitNumber = workPermit.PermitNumber.Value;

            {
                WorkPermitMontreal requeried = workPermitDao.QueryById(workPermit.IdValue);
                Assert.IsNotNull(requeried);
                Assert.IsNotNull(requeried.PermitNumber);
                Assert.AreEqual(returnedPermitNumber, requeried.PermitNumber);
            }
        }

        [Ignore] [Test]
        public void ShouldInsertPermitNumberInSequence()
        {
            WorkPermitMontreal workPermit1 = workPermitDao.Insert(CreateForInsert(PermitRequestBasedWorkPermitStatus.Requested), null);
            WorkPermitMontreal workPermit2 = workPermitDao.Insert(CreateForInsert(PermitRequestBasedWorkPermitStatus.Pending), null);
            WorkPermitMontreal workPermit3 = workPermitDao.Insert(CreateForInsert(PermitRequestBasedWorkPermitStatus.Pending), null);
            workPermitDao.Update(workPermit1);

            Assert.AreEqual(workPermit2.PermitNumber + 1, workPermit3.PermitNumber);
            Assert.AreEqual(workPermit3.PermitNumber + 1, workPermit1.PermitNumber);
        }

        [Ignore] [Test]
        public void ShouldDelete()
        {
            WorkPermitMontreal workPermit = CreateForInsert(PermitRequestBasedWorkPermitStatus.Pending);
            workPermit.LastModifiedBy = UserFixture.CreateEngineeringSupport();
            workPermit.LastModifiedDateTime = new DateTime(2001, 1, 20);
            workPermit = workPermitDao.Insert(workPermit, null);
            long id = workPermit.IdValue;

            {
                WorkPermitMontreal requeried = workPermitDao.QueryById(id);
                Assert.IsNotNull(requeried);

                requeried.LastModifiedBy = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
                requeried.LastModifiedDateTime = new DateTime(2001, 5, 12);

                workPermitDao.Remove(requeried);
            }
            {
                WorkPermitMontreal requeried = workPermitDao.QueryById(id);
                Assert.IsNotNull(requeried);

                Assert.AreEqual(UserFixture.CreateOperatorGoofyInFortMcMurrySite().Id, requeried.LastModifiedBy.Id);
                Assert.AreEqual(new DateTime(2001, 5, 12), requeried.LastModifiedDateTime);
            }
        }

        [Ignore] [Test]
        public void ShouldInsertRequestDetails_NonNullValues()
        {
            PermitAttribute attribute1 = PermitAttributeFixture.GetReal(Site.MONTREAL_ID)[0];
            PermitAttribute attribute2 = PermitAttributeFixture.GetReal(Site.MONTREAL_ID)[1];

            long id;
            {
                WorkPermitMontreal workPermit = WorkPermitMontrealFixture.CreateForInsert();
                workPermit.RequestedByUser = UserFixture.CreateAdmin();
                workPermit.RequestedDateTime = new DateTime(2011, 3, 5);
                workPermit.Company = "Company1";
                workPermit.Supervisor = "Supervisor1";
                workPermit.ExcavationNumber = "ExcavationNumber1";
                workPermit.Attributes.Add(attribute1);
                workPermit.Attributes.Add(attribute2);
                workPermit = workPermitDao.Insert(workPermit, null);
                id = workPermit.IdValue;
            }

            {
                WorkPermitMontreal requeried = workPermitDao.QueryById(id);
                Assert.AreEqual(UserFixture.CreateAdmin().Id, requeried.RequestedByUser.Id);
                Assert.AreEqual(new DateTime(2011, 3, 5), requeried.RequestedDateTime);
                Assert.AreEqual("Company1", requeried.Company);
                Assert.AreEqual("Supervisor1", requeried.Supervisor);
                Assert.AreEqual("ExcavationNumber1", requeried.ExcavationNumber);
                Assert.AreEqual(2, requeried.Attributes.Count);
                Assert.IsTrue(requeried.Attributes.Exists(obj => obj.Id == attribute1.Id));
                Assert.IsTrue(requeried.Attributes.Exists(obj => obj.Id == attribute2.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldInsertRequestDetails_NullValues()
        {
            long id;
            {
                WorkPermitMontreal workPermit = WorkPermitMontrealFixture.CreateForInsert();
                workPermit.RequestedByUser = null;
                workPermit.RequestedDateTime = null;
                workPermit.Company = null;
                workPermit.Supervisor = null;
                workPermit.ExcavationNumber = null;
                workPermit.Attributes.Clear();
                workPermit = workPermitDao.Insert(workPermit, null);
                id = workPermit.IdValue;
            }

            {
                WorkPermitMontreal requeried = workPermitDao.QueryById(id);
                Assert.IsNull(requeried.RequestedByUser);
                Assert.IsNull(requeried.RequestedDateTime);
                Assert.IsNull(requeried.Company);
                Assert.IsNull(requeried.Supervisor);
                Assert.IsNull(requeried.ExcavationNumber);
                Assert.AreEqual(0, requeried.Attributes.Count);
            }
        }

        [Ignore] [Test]
        public void ShouldInsertPermitRequestMontrealWorkPermitMontrealAssociationRecord()
        {
            PermitRequestMontreal permitRequest = PermitRequestMontrealFixture.CreateForInsert(DataSource.MANUAL);
            PermitRequestMontreal permitRequestFromDB = permitRequestDao.Insert(permitRequest);

            WorkPermitMontreal workPermit = WorkPermitMontrealFixture.CreateForInsert();
            workPermitDao.Insert(workPermit, permitRequestFromDB.Id);

            bool exists = workPermitDao.DoesPermitRequestMontrealAssociationExist(new List<PermitRequestMontrealDTO> { new PermitRequestMontrealDTO(permitRequestFromDB) }, new Date(workPermit.StartDateTime));
            Assert.True(exists);
        }

        [Ignore] [Test]
        public void InsertShouldInsertDocumentLinks()
        {
            WorkPermitMontreal permit = WorkPermitMontrealFixture.CreateForInsert();
            permit.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            permit.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink());
            permit = workPermitDao.Insert(permit, null);

            WorkPermitMontreal requeried = workPermitDao.QueryById(permit.IdValue);

            Assert.AreEqual(permit.DocumentLinks.Count, requeried.DocumentLinks.Count);
            Assert.That(requeried.DocumentLinks, Has.Some.EqualTo(permit.DocumentLinks[0]));
            Assert.That(requeried.DocumentLinks, Has.Some.EqualTo(permit.DocumentLinks[1]));
        }

        [Ignore] [Test]
        public void UpdateShouldRemoveDeletedDocumentLinks()
        {
            WorkPermitMontreal permit = WorkPermitMontrealFixture.CreateForInsert();
            permit.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            permit.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink());
            permit = workPermitDao.Insert(permit, null);

            long removedLinkId = permit.DocumentLinks[0].IdValue;
            long retainedLinkId = permit.DocumentLinks[1].IdValue;

            permit.DocumentLinks.Remove(permit.DocumentLinks[0]);
            workPermitDao.Update(permit);

            WorkPermitMontreal requeried = workPermitDao.QueryById(permit.IdValue);
            Assert.AreEqual(permit.DocumentLinks.Count, requeried.DocumentLinks.Count);
            Assert.That(requeried.DocumentLinks, Has.None.Property("Id").EqualTo(removedLinkId));
            Assert.That(requeried.DocumentLinks, Has.Some.Property("Id").EqualTo(retainedLinkId));
        }

        [Ignore] [Test]
        public void UpdateShouldAddNewDocumentLink()
        {
            WorkPermitMontreal permit = WorkPermitMontrealFixture.CreateForInsert();
            permit.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            permit = workPermitDao.Insert(permit, null);

            permit.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink());
            workPermitDao.Update(permit);

            WorkPermitMontreal requeried = workPermitDao.QueryById(permit.IdValue);
            Assert.AreEqual(permit.DocumentLinks.Count, requeried.DocumentLinks.Count);
            Assert.That(requeried.DocumentLinks, Has.Some.Property("Id").EqualTo(permit.DocumentLinks[0].Id));
            Assert.That(requeried.DocumentLinks, Has.Some.Property("Id").EqualTo(permit.DocumentLinks[1].Id));
        }

        [Ignore] [Test]
        public void ShouldInsertWorkPermitMontrealUserReadDocumentLinkAssociation()
        {
            User user = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();

            WorkPermitMontreal workPermit = WorkPermitMontrealFixture.CreateForInsert();
            workPermitDao.Insert(workPermit, null);
            Assert.IsFalse(workPermitDao.HasUserReadAtLeastOneDocumentLink(user.IdValue, workPermit.IdValue));

            workPermitDao.InsertWorkPermitMontrealUserReadDocumentLinkAssociation(user.IdValue, workPermit.IdValue);
            Assert.IsTrue(workPermitDao.HasUserReadAtLeastOneDocumentLink(user.IdValue, workPermit.IdValue));
        }

    

        private static WorkPermitMontreal CreateForInsert(PermitRequestBasedWorkPermitStatus status)
        {
            WorkPermitMontreal workPermit = WorkPermitMontrealFixture.CreateForInsert();
            workPermit.PermitNumber = null;
            workPermit.WorkPermitStatus = status;

            return workPermit;
        }
    }
}