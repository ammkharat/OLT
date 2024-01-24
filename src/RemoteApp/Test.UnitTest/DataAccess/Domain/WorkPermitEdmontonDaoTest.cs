using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]    
    public class WorkPermitEdmontonDaoTest : AbstractDaoTest
    {
        private IWorkPermitEdmontonDao workPermitDao;
        private IPermitRequestEdmontonDao permitRequestDao;
        private IWorkPermitEdmontonDTODao workPermitDTODao;
        private IWorkPermitEdmontonGroupDao groupDao;
        private IFormGN1Dao formGN1Dao;

        protected override void TestInitialize()
        {
            workPermitDao = DaoRegistry.GetDao<IWorkPermitEdmontonDao>();
            workPermitDTODao = DaoRegistry.GetDao<IWorkPermitEdmontonDTODao>();
            permitRequestDao = DaoRegistry.GetDao<IPermitRequestEdmontonDao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitEdmontonGroupDao>();
            formGN1Dao = DaoRegistry.GetDao<IFormGN1Dao>();
        }

        protected override void Cleanup()
        {
            DaoRegistry.Clear();
        }
              
        [Ignore] [Test]
        public void ShouldInsert()
        {
            long? permitRequestId;

            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            {
                WorkPermitEdmontonGroup group = groupDao.Insert(WorkPermitEdmontonGroupFixture.CreateForInsert());

                PermitRequestEdmonton someRequest = PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, floc, group);
                PermitRequestEdmonton permitRequestEdmonton = permitRequestDao.Insert(someRequest);
                permitRequestId = permitRequestEdmonton.IdValue;
            }
                                    
            WorkPermitEdmonton workPermit = WorkPermitEdmontonFixture.CreateForInsert(floc);

            {
                FormGN1 formGN1 = FormGN1Fixture.CreateForInsert(workPermit.FunctionalLocation, workPermit.RequestedStartDateTime, workPermit.ExpiredDateTime, FormStatus.Approved);
                formGN1Dao.Insert(formGN1);
                workPermit.FormGN1 = formGN1;
                workPermit.GN1 = true;
                workPermit.FormGN1TradeChecklistId = formGN1.TradeChecklists[0].Id;
                workPermit.FormGN1TradeChecklistDisplayNumber = "ABC123";
            }

            workPermit = workPermitDao.Insert(workPermit, permitRequestId);
            Assert.That(workPermit.Id, Is.GreaterThan(0));

            RequeryPermitAndAssertFieldsAreEqual(workPermit, false);
        }
       
        [Ignore] [Test]
        public void ShouldUpdate()
        {            
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal("ED1-A001-IFST");

            WorkPermitEdmonton workPermit = WorkPermitEdmontonFixture.CreateForInsert(floc1);
            workPermit.IssuedToSuncor = !workPermit.IssuedToSuncor;

            {
                FormGN1 formGN1 = FormGN1Fixture.CreateForInsert(workPermit.FunctionalLocation, workPermit.RequestedStartDateTime, workPermit.ExpiredDateTime, FormStatus.Approved);
                formGN1Dao.Insert(formGN1);
                workPermit.FormGN1 = formGN1;
                workPermit.GN1 = true;
                workPermit.FormGN1TradeChecklistId = formGN1.TradeChecklists[0].Id;
                workPermit.FormGN1TradeChecklistDisplayNumber = "ABC123";                
            }

            
            workPermit = workPermitDao.Insert(workPermit, null);

            workPermit = workPermitDao.QueryById(workPermit.IdValue);

            Assert.IsNull(workPermit.IssuedByUser);

            WorkPermitEdmontonFixture.ModifyValues(workPermit, floc2);

            {
                FormGN1 formGN1 = FormGN1Fixture.CreateForInsert(workPermit.FunctionalLocation, workPermit.RequestedStartDateTime, workPermit.ExpiredDateTime, FormStatus.Approved);
                formGN1Dao.Insert(formGN1);
                workPermit.FormGN1 = formGN1;
                workPermit.GN1 = true;
                workPermit.FormGN1TradeChecklistId = formGN1.TradeChecklists[0].Id;
                workPermit.FormGN1TradeChecklistDisplayNumber = "ABC123-2";
            }

            workPermitDao.Update(workPermit);

            workPermit = workPermitDao.QueryById(workPermit.IdValue);

            RequeryPermitAndAssertFieldsAreEqual(workPermit, true);
        }
       
        [Ignore] [Test]
        public void ShouldRemove()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            WorkPermitEdmonton workPermit = WorkPermitEdmontonFixture.CreateForInsert(floc);
            workPermit = workPermitDao.Insert(workPermit, null);

            Range<Date> dateRange = new Range<Date>(Clock.DateNow.AddDays(-5), Clock.DateNow.AddDays(1));
            RootFlocSet rootFlocSet = new RootFlocSet(floc);

            List<WorkPermitEdmontonDTO> dtos = workPermitDTODao.QueryByDateRangeAndFlocs(dateRange, rootFlocSet);
            Assert.AreEqual(1, dtos.Count);
            Assert.AreEqual(workPermit.IdValue, dtos[0].IdValue);

            workPermitDao.Remove(workPermit);

            dtos = workPermitDTODao.QueryByDateRangeAndFlocs(dateRange, rootFlocSet);
            Assert.AreEqual(0, dtos.Count);
        }
       
        [Ignore] [Test]
        public void ShouldInsertPermitNumber_And_UpdatePermitAndNotCreateAnotherPermitNumber()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            WorkPermitEdmonton workPermit = WorkPermitEdmontonFixture.CreateForInsert(floc, PermitRequestBasedWorkPermitStatus.Pending);

            workPermit = workPermitDao.Insert(workPermit, null);
            Assert.IsNotNull(workPermit.PermitNumber);
            long returnedPermitNumber = workPermit.PermitNumber.Value;

            {
                WorkPermitEdmonton requeried = workPermitDao.QueryById(workPermit.IdValue);
                Assert.IsNotNull(requeried);
                Assert.IsNotNull(requeried.PermitNumber);
                Assert.AreEqual(returnedPermitNumber, requeried.PermitNumber);
            }

            workPermit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Issued;

            workPermitDao.Update(workPermit);
            Assert.IsNotNull(workPermit.PermitNumber);
            Assert.AreEqual(returnedPermitNumber, workPermit.PermitNumber);

            {
                WorkPermitEdmonton requeried = workPermitDao.QueryById(workPermit.IdValue);
                Assert.IsNotNull(requeried);
                Assert.AreEqual(returnedPermitNumber, requeried.PermitNumber);
            }
        }
      
        [Ignore] [Test]
        public void ShouldInsertNoPermitNumber_And_UpdatePermitAndCreatePermitNumber()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            WorkPermitEdmonton workPermit = WorkPermitEdmontonFixture.CreateForInsert(floc, PermitRequestBasedWorkPermitStatus.Requested);

            workPermit = workPermitDao.Insert(workPermit, null);
            Assert.IsNull(workPermit.PermitNumber);

            {
                WorkPermitEdmonton requeried = workPermitDao.QueryById(workPermit.IdValue);
                Assert.IsNotNull(requeried);
                Assert.IsNull(requeried.PermitNumber);
            }

            workPermit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Pending;

            workPermitDao.Update(workPermit);
            Assert.IsNotNull(workPermit.PermitNumber);
            long returnedPermitNumber = workPermit.PermitNumber.Value;

            {
                WorkPermitEdmonton requeried = workPermitDao.QueryById(workPermit.IdValue);
                Assert.IsNotNull(requeried);
                Assert.IsNotNull(requeried.PermitNumber);
                Assert.AreEqual(returnedPermitNumber, requeried.PermitNumber);
            }
        }
     
        [Ignore] [Test]
        public void UpdatingShouldNotCreateAPermitNumberIfThePermitIsGoingToRemainInRequestedState()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            WorkPermitEdmonton workPermit = WorkPermitEdmontonFixture.CreateForInsert(floc, PermitRequestBasedWorkPermitStatus.Requested);

            workPermit = workPermitDao.Insert(workPermit, null);
            Assert.IsNull(workPermit.PermitNumber);

            {
                WorkPermitEdmonton requeried = workPermitDao.QueryById(workPermit.IdValue);
                Assert.IsNotNull(requeried);
                Assert.IsNull(requeried.PermitNumber);
            }

            workPermitDao.Update(workPermit);
            Assert.IsNull(workPermit.PermitNumber);
        }
      
        [Ignore] [Test]
        public void ShouldInsertPermitNumberInSequence()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            WorkPermitEdmonton workPermit1 = workPermitDao.Insert(WorkPermitEdmontonFixture.CreateForInsert(floc, PermitRequestBasedWorkPermitStatus.Requested), null);
            WorkPermitEdmonton workPermit2 = workPermitDao.Insert(WorkPermitEdmontonFixture.CreateForInsert(floc, PermitRequestBasedWorkPermitStatus.Pending), null);
            WorkPermitEdmonton workPermit3 = workPermitDao.Insert(WorkPermitEdmontonFixture.CreateForInsert(floc, PermitRequestBasedWorkPermitStatus.Pending), null);
            workPermit1.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Pending;
            workPermitDao.Update(workPermit1);

            Assert.AreEqual(workPermit2.PermitNumber + 1, workPermit3.PermitNumber);
            Assert.AreEqual(workPermit3.PermitNumber + 1, workPermit1.PermitNumber);
        }
        
        [Ignore] [Test]
        public void AnInsertionThatCreatesAPermitNumberShouldAlsoSetTheZeroEnergyFormNumberIfTheUserWantsThatToHappen()
        {
            {
                FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();
                WorkPermitEdmonton workPermit = WorkPermitEdmontonFixture.CreateForInsert(floc, PermitRequestBasedWorkPermitStatus.Pending);
                workPermit.UseCurrentPermitNumberForZeroEnergyFormNumber = true;
                workPermit.ZeroEnergyFormNumber = null;

                workPermit = workPermitDao.Insert(workPermit, null);
                Assert.IsNotNull(workPermit.PermitNumber);
                Assert.AreEqual(workPermit.PermitNumber.ToString(), workPermit.ZeroEnergyFormNumber);

                {
                    WorkPermitEdmonton requeried = workPermitDao.QueryById(workPermit.IdValue);
                    Assert.IsNotNull(requeried);
                    Assert.IsNotNull(requeried.PermitNumber);
                    Assert.AreEqual(requeried.PermitNumber.ToString(), requeried.ZeroEnergyFormNumber);
                }
            }

            {
                FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();
                WorkPermitEdmonton workPermit = WorkPermitEdmontonFixture.CreateForInsert(floc, PermitRequestBasedWorkPermitStatus.Pending);
                workPermit.UseCurrentPermitNumberForZeroEnergyFormNumber = false;
                workPermit.ZeroEnergyFormNumber = null;

                workPermit = workPermitDao.Insert(workPermit, null);
                Assert.IsNotNull(workPermit.PermitNumber);
                Assert.IsNull(workPermit.ZeroEnergyFormNumber);

                {
                    WorkPermitEdmonton requeried = workPermitDao.QueryById(workPermit.IdValue);
                    Assert.IsNotNull(requeried);
                    Assert.IsNotNull(requeried.PermitNumber);
                    Assert.IsNull(requeried.ZeroEnergyFormNumber);
                }
            }
        }
       
        [Ignore] [Test]
        public void AnUpdateThatCreatesAPermitNumberShouldAlsoSetTheZeroEnergyFormNumberIfTheUserWantsThatToHappen()
        {
            {
                FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();
                WorkPermitEdmonton workPermit = WorkPermitEdmontonFixture.CreateForInsert(floc, PermitRequestBasedWorkPermitStatus.Requested);
                workPermit.UseCurrentPermitNumberForZeroEnergyFormNumber = true;
                workPermit.ZeroEnergyFormNumber = null;
                workPermit = workPermitDao.Insert(workPermit, null);

                {
                    WorkPermitEdmonton requeried = workPermitDao.QueryById(workPermit.IdValue);
                    Assert.IsNotNull(requeried);
                    Assert.IsNull(requeried.PermitNumber);
                    Assert.IsNull(requeried.ZeroEnergyFormNumber);
                }

                workPermit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Pending;
                workPermitDao.Update(workPermit);
                Assert.IsNotNull(workPermit.PermitNumber);
                Assert.AreEqual(workPermit.PermitNumber.ToString(), workPermit.ZeroEnergyFormNumber);

                {
                    WorkPermitEdmonton requeried = workPermitDao.QueryById(workPermit.IdValue);
                    Assert.IsNotNull(requeried);
                    Assert.IsNotNull(requeried.PermitNumber);
                    Assert.AreEqual(requeried.PermitNumber.ToString(), requeried.ZeroEnergyFormNumber);
                }
            }

            {
                FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();
                WorkPermitEdmonton workPermit = WorkPermitEdmontonFixture.CreateForInsert(floc, PermitRequestBasedWorkPermitStatus.Requested);
                workPermit.UseCurrentPermitNumberForZeroEnergyFormNumber = false;
                workPermit.ZeroEnergyFormNumber = null;
                workPermit = workPermitDao.Insert(workPermit, null);

                {
                    WorkPermitEdmonton requeried = workPermitDao.QueryById(workPermit.IdValue);
                    Assert.IsNotNull(requeried);
                    Assert.IsNull(requeried.PermitNumber);
                    Assert.IsNull(requeried.ZeroEnergyFormNumber);
                }

                workPermit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Pending;
                workPermitDao.Update(workPermit);

                {
                    WorkPermitEdmonton requeried = workPermitDao.QueryById(workPermit.IdValue);
                    Assert.IsNotNull(requeried);
                    Assert.IsNotNull(requeried.PermitNumber);
                    Assert.IsNull(requeried.ZeroEnergyFormNumber);
                }
            }
        }
       
        [Ignore] [Test]
        public void ShouldFindPermitFromPreviousDateAssociatedToSamePermitRequest()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            PermitRequestEdmonton validCompletePermitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            PermitRequestEdmonton insertedPermitRequest = permitRequestDao.Insert(validCompletePermitRequest);

            WorkPermitEdmonton previousPermit = WorkPermitEdmontonFixture.CreateForInsert(floc, PermitRequestBasedWorkPermitStatus.Issued);
            previousPermit.IssuedByUser = previousPermit.CreatedBy;
            WorkPermitEdmonton insertedPreviousPermit = workPermitDao.Insert(previousPermit, insertedPermitRequest.Id);
            workPermitDao.Update(insertedPreviousPermit);

            WorkPermitEdmonton currentPermit = WorkPermitEdmontonFixture.CreateForInsert(floc, PermitRequestBasedWorkPermitStatus.Pending);
            currentPermit.IssuedDateTime = previousPermit.IssuedDateTime.Value.AddHours(1); // make sure the second permit's issued date/time is after the first one.
            
            WorkPermitEdmonton insertedCurrentPermit = workPermitDao.Insert(currentPermit, insertedPermitRequest.Id);

            WorkPermitEdmonton previousDayIssuedPermitForSamePermitRequest = workPermitDao.QueryPreviousDayIssuedPermitForSamePermitRequest(insertedCurrentPermit);

            Assert.That(previousDayIssuedPermitForSamePermitRequest, Is.Not.Null);
            Assert.That(previousDayIssuedPermitForSamePermitRequest.IdValue, Is.EqualTo(insertedPreviousPermit.IdValue));
        }
      
        [Ignore] [Test]
        public void ShouldFindPermitFromPreviousDateAssociatedToSamePermitRequest_ButOnlyIfThePreviousPermitHasBeenIssued()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            PermitRequestEdmonton validCompletePermitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();            
            PermitRequestEdmonton insertedPermitRequest = permitRequestDao.Insert(validCompletePermitRequest);

            // no show that was never issued.
            WorkPermitEdmonton previousPermit = WorkPermitEdmontonFixture.CreateForInsert(floc, PermitRequestBasedWorkPermitStatus.NoShow);
            previousPermit.IssuedDateTime = null;
            previousPermit.IssuedByUser = null;

            WorkPermitEdmonton insertedPreviousPermit = workPermitDao.Insert(previousPermit, insertedPermitRequest.Id);
            Assert.IsFalse(insertedPreviousPermit.HasBeenIssued);

            WorkPermitEdmonton currentPermit = WorkPermitEdmontonFixture.CreateForInsert(floc, PermitRequestBasedWorkPermitStatus.Pending);
//            currentPermit.IssuedDateTime = previousPermit.IssuedDateTime.Value.AddHours(1); // make sure the second permit's issued date/time is after the first one.
            
            WorkPermitEdmonton insertedCurrentPermit = workPermitDao.Insert(currentPermit, insertedPermitRequest.Id);

            WorkPermitEdmonton previousDayIssuedPermitForSamePermitRequest = workPermitDao.QueryPreviousDayIssuedPermitForSamePermitRequest(insertedCurrentPermit);

            Assert.That(previousDayIssuedPermitForSamePermitRequest, Is.Null);            
        }
        
        [Ignore] [Test]
        public void ShouldKnowIfPermitRequestEdmontonAssociationExists()
        {
            WorkPermitEdmontonGroup group = groupDao.Insert(WorkPermitEdmontonGroupFixture.CreateForInsert());

            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            PermitRequestEdmonton permitRequestAssociated = PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, floc, group);
            PermitRequestEdmonton permitRequestAssociatedFromDB = permitRequestDao.Insert(permitRequestAssociated);

            PermitRequestEdmonton permitRequestUnassociated = PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, floc, group);
            PermitRequestEdmonton permitRequestUnassociatedFromDB = permitRequestDao.Insert(permitRequestUnassociated);

            WorkPermitEdmonton workPermitWithAssociation = WorkPermitEdmontonFixture.CreateForInsert(floc, PermitRequestBasedWorkPermitStatus.Requested);
            workPermitDao.Insert(workPermitWithAssociation, permitRequestAssociatedFromDB.Id);

            DateTime issuedDateTimeForPermit = workPermitWithAssociation.IssuedDateTime.Value;
            
            Range<DateTime> workPermitIssuedRange = new Range<DateTime>(issuedDateTimeForPermit.AddHours(-1), issuedDateTimeForPermit.AddHours(1));
            Assert.True(workPermitDao.DoesPermitRequestEdmontonAssociationExist(new List<long> { new PermitRequestEdmontonDTO(permitRequestAssociatedFromDB).IdValue }, workPermitIssuedRange));
            Assert.False(workPermitDao.DoesPermitRequestEdmontonAssociationExist(new List<long> { new PermitRequestEdmontonDTO(permitRequestUnassociatedFromDB).IdValue }, workPermitIssuedRange));

            workPermitIssuedRange = new Range<DateTime>(issuedDateTimeForPermit.AddDays(1), issuedDateTimeForPermit.AddDays(2));
            Assert.False(workPermitDao.DoesPermitRequestEdmontonAssociationExist(new List<long> { new PermitRequestEdmontonDTO(permitRequestAssociatedFromDB).IdValue }, workPermitIssuedRange));
        }
        
        [Ignore] [Test]
        public void ShouldKnowIfPermitRequestEdmontonAssociationExistsWhenPermitIsIssuedBeforeStartDate()
        {
            WorkPermitEdmontonGroup group = groupDao.Insert(WorkPermitEdmontonGroupFixture.CreateForInsert());
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            PermitRequestEdmonton permitRequestAssociated = PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, floc, group);
            permitRequestAssociated.RequestedStartDate = new Date(2013, 9, 11);
            permitRequestAssociated.RequestedStartTimeDay = new Time(8, 0, 0);
            permitRequestDao.Insert(permitRequestAssociated);

            WorkPermitEdmonton workPermitWithAssociation = WorkPermitEdmontonFixture.CreateForInsert(floc, PermitRequestBasedWorkPermitStatus.Requested);
            workPermitWithAssociation.RequestedStartDateTime = new DateTime(2013, 9, 11, 8, 0, 0);
            workPermitWithAssociation.ExpiredDateTime = new DateTime(2013, 9, 11, 15, 0, 0);
            workPermitDao.Insert(workPermitWithAssociation, permitRequestAssociated.Id);

            // insert doesn't set issueddatetime so we have to update to set it
            workPermitWithAssociation.IssuedDateTime = new DateTime(2013, 9, 10, 8, 0, 0);   // issued a day before the start and expire date
            workPermitDao.Update(workPermitWithAssociation);

            UserShift userShift = WorkPermitEdmonton.UserShift(new DateTime(2013, 9, 11, 8, 0, 0));
            bool doesPermitRequestEdmontonAssociationExist = workPermitDao.DoesPermitRequestEdmontonAssociationExist(new List<long> { permitRequestAssociated.IdValue }, userShift.DateTimeRangeWithoutPadding);
            Assert.IsTrue(doesPermitRequestEdmontonAssociationExist);
        }
       
        [Ignore] [Test]
        public void ShouldBeAbleToSaveWhenAYesNoNotApplicablePropertyIsSetToNull()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal("ED1-A001-IFST");

            WorkPermitEdmonton workPermit = WorkPermitEdmontonFixture.CreateForInsert(floc1);
            workPermit.IssuedToSuncor = !workPermit.IssuedToSuncor;
            workPermit = workPermitDao.Insert(workPermit, null);

            workPermit = workPermitDao.QueryById(workPermit.IdValue);

            WorkPermitEdmontonFixture.ModifyValues(workPermit, floc2);
            workPermit.IsolationValvesLocked = null;
            workPermit.QuestionThreeResponse = null;
            workPermitDao.Update(workPermit);   // this was throwing a null reference exception when the test failed
        }
       
        [Ignore] [Test]
        public void ShouldQueryLatestExpiryDateTimeByPermitRequestId()
        {            
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            {
                WorkPermitEdmontonGroup group = groupDao.Insert(WorkPermitEdmontonGroupFixture.CreateForInsert());

                PermitRequestEdmonton someRequest = PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, floc, group);
                PermitRequestEdmonton permitRequestEdmonton = permitRequestDao.Insert(someRequest);
                long permitRequestId = permitRequestEdmonton.IdValue;

                WorkPermitEdmonton workPermit1 = WorkPermitEdmontonFixture.CreateForInsert(floc);
                workPermit1.ExpiredDateTime = new DateTime(2012, 3, 10);

                WorkPermitEdmonton workPermit2 = WorkPermitEdmontonFixture.CreateForInsert(floc);
                workPermit2.ExpiredDateTime = new DateTime(2012, 3, 11);
                
                workPermitDao.Insert(workPermit1, permitRequestId);
                WorkPermitEdmonton permit2 = workPermitDao.Insert(workPermit2, permitRequestId);

                DateTime? result = workPermitDao.QueryLatestExpiryDateByPermitRequestId(permitRequestId);
                Assert.That(permit2.ExpiredDateTime, Is.EqualTo(result).Within(TimeSpan.FromSeconds(1)));
            }
          
            // Make sure it works if there are no permits for that request id (even though it should never get called this way in practice, it's possible for a permit request to exist and not have any associated permits)
            {
                DateTime? result = workPermitDao.QueryLatestExpiryDateByPermitRequestId(0);
                Assert.IsNull(result);
            }
        }
        
        [Ignore] [Test]
        public void InsertShouldInsertDocumentLinks()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(floc);
            permit.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            permit.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink());
            permit = workPermitDao.Insert(permit, null);

            WorkPermitEdmonton requeried = workPermitDao.QueryById(permit.IdValue);

            Assert.AreEqual(permit.DocumentLinks.Count, requeried.DocumentLinks.Count);
            Assert.That(requeried.DocumentLinks, Has.Some.EqualTo(permit.DocumentLinks[0]));
            Assert.That(requeried.DocumentLinks, Has.Some.EqualTo(permit.DocumentLinks[1]));
        }
       
        [Ignore] [Test]
        public void UpdateShouldRemoveDeletedDocumentLinks()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(floc);
            permit.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            permit.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink());
            permit = workPermitDao.Insert(permit, null);

            long removedLinkId = permit.DocumentLinks[0].IdValue;
            long retainedLinkId = permit.DocumentLinks[1].IdValue;

            permit.DocumentLinks.Remove(permit.DocumentLinks[0]);
            workPermitDao.Update(permit);

            WorkPermitEdmonton requeried = workPermitDao.QueryById(permit.IdValue);
            Assert.AreEqual(permit.DocumentLinks.Count, requeried.DocumentLinks.Count);
            Assert.That(requeried.DocumentLinks, Has.None.Property("Id").EqualTo(removedLinkId));
            Assert.That(requeried.DocumentLinks, Has.Some.Property("Id").EqualTo(retainedLinkId));
        }
        
        [Ignore] [Test]
        public void UpdateShouldAddNewDocumentLink()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(floc);
            permit.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            permit = workPermitDao.Insert(permit, null);

            permit.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink());
            workPermitDao.Update(permit);

            WorkPermitEdmonton requeried = workPermitDao.QueryById(permit.IdValue);
            Assert.AreEqual(permit.DocumentLinks.Count, requeried.DocumentLinks.Count);
            Assert.That(requeried.DocumentLinks, Has.Some.Property("Id").EqualTo(permit.DocumentLinks[0].Id));
            Assert.That(requeried.DocumentLinks, Has.Some.Property("Id").EqualTo(permit.DocumentLinks[1].Id));
        }
       
        [Ignore] [Test]
        public void QueryingAPermitThatWasManuallyCreatedShouldNotHaveASubmittedByUser()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(floc);
            permit = workPermitDao.Insert(permit, null);

            WorkPermitEdmonton requeried = workPermitDao.QueryById(permit.IdValue);
            Assert.IsNull(requeried.SubmittedByUser);
        }
       
        [Ignore] [Test]
        public void ShouldQueryByFormGN59Id()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("ED1-A001-IFST");

            WorkPermitEdmonton permitOne = WorkPermitEdmontonFixture.CreateForInsert(floc);
            permitOne.FormGN59 = FormGN59Fixture.CreateFormWithExistingId();
            workPermitDao.Insert(permitOne, null);

            WorkPermitEdmonton permitTwo = WorkPermitEdmontonFixture.CreateForInsert(floc);
            permitTwo.FormGN59 = FormGN59Fixture.CreateFormWithExistingId();
            workPermitDao.Insert(permitTwo, null);

            WorkPermitEdmonton permitThree = WorkPermitEdmontonFixture.CreateForInsert(floc);
            permitThree.FormGN59 = FormGN59Fixture.CreateAnotherFormWithExistingId();
            workPermitDao.Insert(permitThree, null);

            {
                List<WorkPermitEdmonton> results = workPermitDao.QueryByFormGN59Id(permitOne.FormGN59.IdValue);
                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Exists(request => request.Id == permitOne.Id));
                Assert.IsTrue(results.Exists(request => request.Id == permitTwo.Id));
            }

            {
                List<WorkPermitEdmonton> results = workPermitDao.QueryByFormGN59Id(permitThree.FormGN59.IdValue);
                Assert.AreEqual(1, results.Count);
                Assert.IsTrue(results.Exists(request => request.Id == permitThree.Id));
            }
        }    
      
        [Ignore] [Test]
        public void ShouldQueryByFormGN24Id()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("ED1-A001-IFST");

            WorkPermitEdmonton permitOne = WorkPermitEdmontonFixture.CreateForInsert(floc);
            permitOne.FormGN24 = FormGN24Fixture.CreateFormWithExistingId();
            workPermitDao.Insert(permitOne, null);

            WorkPermitEdmonton permitTwo = WorkPermitEdmontonFixture.CreateForInsert(floc);
            permitTwo.FormGN24 = FormGN24Fixture.CreateFormWithExistingId();
            workPermitDao.Insert(permitTwo, null);

            WorkPermitEdmonton permitThree = WorkPermitEdmontonFixture.CreateForInsert(floc);
            permitThree.FormGN24 = FormGN24Fixture.CreateAnotherFormWithExistingId();
            workPermitDao.Insert(permitThree, null);

            {
                List<WorkPermitEdmonton> results = workPermitDao.QueryByFormGN24Id(permitOne.FormGN24.IdValue);
                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Exists(request => request.Id == permitOne.Id));
                Assert.IsTrue(results.Exists(request => request.Id == permitTwo.Id));
            }

            {
                List<WorkPermitEdmonton> results = workPermitDao.QueryByFormGN24Id(permitThree.FormGN24.IdValue);
                Assert.AreEqual(1, results.Count);
                Assert.IsTrue(results.Exists(request => request.Id == permitThree.Id));
            }
        }
        
        [Ignore] [Test]
        public void ShouldQueryByFormGN7Id()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("ED1-A001-IFST");

            WorkPermitEdmonton permitOne = WorkPermitEdmontonFixture.CreateForInsert(floc);
            permitOne.FormGN7 = FormGN7Fixture.CreateFormWithExistingId();
            workPermitDao.Insert(permitOne, null);

            WorkPermitEdmonton permitTwo = WorkPermitEdmontonFixture.CreateForInsert(floc);
            permitTwo.FormGN7 = FormGN7Fixture.CreateFormWithExistingId();
            workPermitDao.Insert(permitTwo, null);

            WorkPermitEdmonton permitThree = WorkPermitEdmontonFixture.CreateForInsert(floc);
            permitThree.FormGN7 = FormGN7Fixture.CreateAnotherFormWithExistingId();
            workPermitDao.Insert(permitThree, null);

            {
                List<WorkPermitEdmonton> results = workPermitDao.QueryByFormGN7Id(permitOne.FormGN7.IdValue);
                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Exists(request => request.Id == permitOne.Id));
                Assert.IsTrue(results.Exists(request => request.Id == permitTwo.Id));
            }

            {
                List<WorkPermitEdmonton> results = workPermitDao.QueryByFormGN7Id(permitThree.FormGN7.IdValue);
                Assert.AreEqual(1, results.Count);
                Assert.IsTrue(results.Exists(request => request.Id == permitThree.Id));
            }
        }

        private void RequeryPermitAndAssertFieldsAreEqual(WorkPermitEdmonton workPermit, bool isUpdate)
        {           
            WorkPermitEdmonton requeried = workPermitDao.QueryById(workPermit.IdValue);

            Assert.IsNotNull(requeried);

            Assert.AreEqual(workPermit.Priority.IdValue, requeried.Priority.IdValue);
            Assert.AreEqual(workPermit.Group.IdValue, requeried.Group.IdValue);
            Assert.AreEqual(workPermit.WorkPermitStatus, requeried.WorkPermitStatus);
            Assert.AreEqual(workPermit.DataSource, requeried.DataSource);
            Assert.AreEqual(workPermit.IssuedToSuncor, requeried.IssuedToSuncor);
            Assert.AreEqual(workPermit.Company, requeried.Company);
            Assert.AreEqual(workPermit.Occupation, requeried.Occupation);
            Assert.AreEqual(workPermit.NumberOfWorkers, requeried.NumberOfWorkers);
            Assert.AreEqual(workPermit.WorkPermitType, requeried.WorkPermitType);
            Assert.AreEqual(workPermit.DurationPermit, requeried.DurationPermit);
            Assert.AreEqual(workPermit.FunctionalLocation, requeried.FunctionalLocation);
            Assert.AreEqual(workPermit.Location, requeried.Location);            
            Assert.AreEqual(workPermit.AlkylationEntryClassOfClothing, requeried.AlkylationEntryClassOfClothing);
            Assert.AreEqual(workPermit.ConfinedSpace, requeried.ConfinedSpace);
            Assert.AreEqual(workPermit.ConfinedSpaceCardNumber, requeried.ConfinedSpaceCardNumber);
            Assert.AreEqual(workPermit.ConfinedSpaceClass, requeried.ConfinedSpaceClass);
            Assert.AreEqual(workPermit.SpecialWork, requeried.SpecialWork);
            Assert.AreEqual(workPermit.SpecialWorkFormNumber, requeried.SpecialWorkFormNumber);
            Assert.AreEqual(workPermit.SpecialWorkType, requeried.SpecialWorkType);

            Assert.AreEqual(workPermit.VehicleEntry, requeried.VehicleEntry);
            Assert.AreEqual(workPermit.VehicleEntryTotal, requeried.VehicleEntryTotal);
            Assert.AreEqual(workPermit.VehicleEntryType, requeried.VehicleEntryType);
            Assert.AreEqual(workPermit.RescuePlan, requeried.RescuePlan);
            Assert.AreEqual(workPermit.RescuePlanFormNumber, requeried.RescuePlanFormNumber);
            Assert.AreEqual(workPermit.GN59, requeried.GN59);
            Assert.AreEqual(workPermit.FormGN59.Id, requeried.FormGN59.Id);
            Assert.AreEqual(workPermit.GN7, requeried.GN7);
            Assert.AreEqual(workPermit.FormGN7.Id, requeried.FormGN7.Id);
            Assert.AreEqual(workPermit.GN24, requeried.GN24);
            Assert.AreEqual(workPermit.FormGN24.Id, requeried.FormGN24.Id);

            Assert.AreEqual(workPermit.GN1, requeried.GN1);
            Assert.AreEqual(workPermit.FormGN1.Id, requeried.FormGN1.Id);
            Assert.AreEqual(workPermit.FormGN1TradeChecklistId, requeried.FormGN1TradeChecklistId);
            Assert.AreEqual(workPermit.FormGN1TradeChecklistDisplayNumber, requeried.FormGN1TradeChecklistDisplayNumber);

            Assert.That(workPermit.RequestedStartDateTime, Is.EqualTo(requeried.RequestedStartDateTime).Within(TimeSpan.FromSeconds(1)));
            Assert.That(workPermit.IssuedDateTime, Is.EqualTo(requeried.IssuedDateTime).Within(TimeSpan.FromSeconds(1)));
            Assert.That(workPermit.ExpiredDateTime, Is.EqualTo(requeried.ExpiredDateTime).Within(TimeSpan.FromSeconds(1)));            
            Assert.AreEqual(workPermit.WorkOrderNumber, requeried.WorkOrderNumber);
            Assert.AreEqual(workPermit.OperationNumber, requeried.OperationNumber);
            Assert.AreEqual(workPermit.SubOperationNumber, requeried.SubOperationNumber);
            Assert.AreEqual(workPermit.TaskDescription, requeried.TaskDescription);
            Assert.AreEqual(workPermit.HazardsAndOrRequirements, requeried.HazardsAndOrRequirements);
            Assert.AreEqual(workPermit.StatusOfPipingEquipmentSectionNotApplicableToJob, requeried.StatusOfPipingEquipmentSectionNotApplicableToJob);
            Assert.AreEqual(workPermit.ProductNormallyInPipingEquipment, requeried.ProductNormallyInPipingEquipment);
            Assert.AreEqual(workPermit.IsolationValvesLocked, requeried.IsolationValvesLocked);
            Assert.AreEqual(workPermit.DepressuredDrained, requeried.DepressuredDrained);
            Assert.AreEqual(workPermit.Ventilated, requeried.Ventilated);
            Assert.AreEqual(workPermit.Purged, requeried.Purged);
            Assert.AreEqual(workPermit.BlindedAndTagged, requeried.BlindedAndTagged);
            Assert.AreEqual(workPermit.DoubleBlockAndBleed, requeried.DoubleBlockAndBleed);
            Assert.AreEqual(workPermit.ElectricalLockout, requeried.ElectricalLockout);
            Assert.AreEqual(workPermit.MechanicalLockout, requeried.MechanicalLockout);
            Assert.AreEqual(workPermit.BlindSchematicAvailable, requeried.BlindSchematicAvailable);
            Assert.AreEqual(workPermit.ZeroEnergyFormNumber, requeried.ZeroEnergyFormNumber);
            Assert.AreEqual(workPermit.LockBoxNumber, requeried.LockBoxNumber);
            Assert.AreEqual(workPermit.JobsiteEquipmentInspected, requeried.JobsiteEquipmentInspected);
            Assert.AreEqual(workPermit.OtherAreasAndOrUnitsAffected, requeried.OtherAreasAndOrUnitsAffected);
            Assert.AreEqual(workPermit.OtherAreasAndOrUnitsAffectedArea, requeried.OtherAreasAndOrUnitsAffectedArea);
            Assert.AreEqual(workPermit.OtherAreasAndOrUnitsAffectedPersonNotified, requeried.OtherAreasAndOrUnitsAffectedPersonNotified);
            Assert.AreEqual(workPermit.ConfinedSpaceWorkSectionNotApplicableToJob, requeried.ConfinedSpaceWorkSectionNotApplicableToJob);
            Assert.AreEqual(workPermit.QuestionOneResponse, requeried.QuestionOneResponse);
            Assert.AreEqual(workPermit.QuestionTwoResponse, requeried.QuestionTwoResponse);
            Assert.AreEqual(workPermit.QuestionTwoAResponse, requeried.QuestionTwoAResponse);
            Assert.AreEqual(workPermit.QuestionTwoBResponse, requeried.QuestionTwoBResponse);
            Assert.AreEqual(workPermit.QuestionThreeResponse, requeried.QuestionThreeResponse);
            Assert.AreEqual(workPermit.QuestionFourResponse, requeried.QuestionFourResponse);
            Assert.AreEqual(workPermit.GasTestsSectionNotApplicableToJob, requeried.GasTestsSectionNotApplicableToJob);
            Assert.AreEqual(workPermit.OperatorGasDetectorNumber, requeried.OperatorGasDetectorNumber);
            Assert.AreEqual(workPermit.GasTestDataLine1CombustibleGas, requeried.GasTestDataLine1CombustibleGas);
            Assert.AreEqual(workPermit.GasTestDataLine1Oxygen, requeried.GasTestDataLine1Oxygen);
            Assert.AreEqual(workPermit.GasTestDataLine1ToxicGas, requeried.GasTestDataLine1ToxicGas);
            Assert.AreEqual(workPermit.GasTestDataLine1Time, requeried.GasTestDataLine1Time);
            Assert.AreEqual(workPermit.GasTestDataLine2CombustibleGas, requeried.GasTestDataLine2CombustibleGas);
            Assert.AreEqual(workPermit.GasTestDataLine2Oxygen, requeried.GasTestDataLine2Oxygen);
            Assert.AreEqual(workPermit.GasTestDataLine2ToxicGas, requeried.GasTestDataLine2ToxicGas);
            Assert.AreEqual(workPermit.GasTestDataLine2Time, requeried.GasTestDataLine2Time);
            Assert.AreEqual(workPermit.GasTestDataLine3CombustibleGas, requeried.GasTestDataLine3CombustibleGas);
            Assert.AreEqual(workPermit.GasTestDataLine3Oxygen, requeried.GasTestDataLine3Oxygen);
            Assert.AreEqual(workPermit.GasTestDataLine3ToxicGas, requeried.GasTestDataLine3ToxicGas);
            Assert.AreEqual(workPermit.GasTestDataLine3Time, requeried.GasTestDataLine3Time);
            Assert.AreEqual(workPermit.GasTestDataLine4CombustibleGas, requeried.GasTestDataLine4CombustibleGas);
            Assert.AreEqual(workPermit.GasTestDataLine4Oxygen, requeried.GasTestDataLine4Oxygen);
            Assert.AreEqual(workPermit.GasTestDataLine4ToxicGas, requeried.GasTestDataLine4ToxicGas);
            Assert.AreEqual(workPermit.GasTestDataLine4Time, requeried.GasTestDataLine4Time);
            Assert.AreEqual(workPermit.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob, requeried.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);
            Assert.AreEqual(workPermit.FaceShield, requeried.FaceShield);
            Assert.AreEqual(workPermit.Goggles, requeried.Goggles);
            Assert.AreEqual(workPermit.RubberBoots, requeried.RubberBoots);
            Assert.AreEqual(workPermit.RubberGloves, requeried.RubberGloves);
            Assert.AreEqual(workPermit.RubberSuit, requeried.RubberSuit);
            Assert.AreEqual(workPermit.SafetyHarnessLifeline, requeried.SafetyHarnessLifeline);
            Assert.AreEqual(workPermit.HighVoltagePPE, requeried.HighVoltagePPE);
            Assert.AreEqual(workPermit.Other1Checked, requeried.Other1Checked);
            Assert.AreEqual(workPermit.Other1, requeried.Other1);
            Assert.AreEqual(workPermit.EquipmentGrounded, requeried.EquipmentGrounded);
            Assert.AreEqual(workPermit.FireBlanket, requeried.FireBlanket);
            Assert.AreEqual(workPermit.FireExtinguisher, requeried.FireExtinguisher);
            Assert.AreEqual(workPermit.FireMonitorManned, requeried.FireMonitorManned);
            Assert.AreEqual(workPermit.FireWatch, requeried.FireWatch);
            Assert.AreEqual(workPermit.SewersDrainsCovered, requeried.SewersDrainsCovered);
            Assert.AreEqual(workPermit.SteamHose, requeried.SteamHose);
            Assert.AreEqual(workPermit.Other2Checked, requeried.Other2Checked);
            Assert.AreEqual(workPermit.Other2, requeried.Other2);
            Assert.AreEqual(workPermit.AirPurifyingRespirator, requeried.AirPurifyingRespirator);
            Assert.AreEqual(workPermit.BreathingAirApparatus, requeried.BreathingAirApparatus);
            Assert.AreEqual(workPermit.DustMask, requeried.DustMask);
            Assert.AreEqual(workPermit.LifeSupportSystem, requeried.LifeSupportSystem);
            Assert.AreEqual(workPermit.SafetyWatch, requeried.SafetyWatch);
            Assert.AreEqual(workPermit.ContinuousGasMonitor, requeried.ContinuousGasMonitor);
            Assert.AreEqual(workPermit.WorkersMonitorNumber, requeried.WorkersMonitorNumber);
            Assert.AreEqual(workPermit.BumpTestMonitorPriorToUse, requeried.BumpTestMonitorPriorToUse);
            Assert.AreEqual(workPermit.Other3Checked, requeried.Other3Checked);
            Assert.AreEqual(workPermit.Other3, requeried.Other3);
            Assert.AreEqual(workPermit.AirMover, requeried.AirMover);
            Assert.AreEqual(workPermit.BarriersSigns, requeried.BarriersSigns);
            Assert.AreEqual(workPermit.RadioChannelNumber, requeried.RadioChannelNumber);
            Assert.AreEqual(workPermit.AirHorn, requeried.AirHorn);
            Assert.AreEqual(workPermit.MechVentilationComfortOnly, requeried.MechVentilationComfortOnly);
            Assert.AreEqual(workPermit.AsbestosMMCPrecautions, requeried.AsbestosMMCPrecautions);
            Assert.AreEqual(workPermit.Other4Checked, requeried.Other4Checked);
            Assert.AreEqual(workPermit.Other4, requeried.Other4);
            Assert.AreEqual(workPermit.CreatedDateTime, requeried.CreatedDateTime);
            Assert.AreEqual(workPermit.CreatedBy.IdValue, requeried.CreatedBy.IdValue);
            Assert.AreEqual(workPermit.UseCurrentPermitNumberForZeroEnergyFormNumber, requeried.UseCurrentPermitNumberForZeroEnergyFormNumber);

            if (!isUpdate)
            {
                Assert.AreEqual(workPermit.SubmittedByUser, requeried.SubmittedByUser);
            }
            else
            {
                Assert.AreEqual(1, workPermit.IssuedByUser.IdValue);    
            }
                        
            Assert.AreEqual(workPermit.LastModifiedBy.IdValue, requeried.LastModifiedBy.IdValue);
            Assert.AreEqual(workPermit.LastModifiedDateTime, requeried.LastModifiedDateTime);

            Assert.AreEqual(workPermit.PermitAcceptor, requeried.PermitAcceptor);
            Assert.AreEqual(workPermit.ShiftSupervisor, requeried.ShiftSupervisor);

            Assert.IsTrue((workPermit.AreaLabel == null && requeried.AreaLabel == null) || (workPermit.AreaLabel.Id == requeried.AreaLabel.Id));
        }
    }
}