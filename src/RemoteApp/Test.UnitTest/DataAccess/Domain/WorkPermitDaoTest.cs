using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]    
    public class WorkPermitDaoTest : AbstractDaoTest
    {
        private const int TEST_WORK_PERMIT_COUNT = 3;

        private IWorkPermitDao dao;
        private IWorkAssignmentDao workAssignmentDao;
        private IGasTestElementInfoDao gasTestElementInfoDao;
        private long siteId;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IWorkPermitDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            gasTestElementInfoDao = DaoRegistry.GetDao<IGasTestElementInfoDao>();
            siteId = 1;
        }

        protected override void Cleanup()
        {
            DaoRegistry.Clear();
        }
        
        private List<WorkPermit> QueryAllActivePendingWorkPermits()
        {
            return dao.QueryAllWorkPermitsByStatus(WorkPermitStatus.Pending);
        }

        private List<WorkPermit> QueryAllRejectedWorkPermits()
        {
            return dao.QueryAllWorkPermitsByStatus(WorkPermitStatus.Rejected);
        }

        [Ignore] [Test]
        public void ShouldQueryAllCompleteWorkPermitsThatAreNotMarkedAsDeleted()
        {
            List<WorkPermit> insertedWorkPermits = InsertWorkPermits(WorkPermitStatus.Complete);
            dao.Remove(insertedWorkPermits[2]);
            List<WorkPermit> foundCompletedWorkPermits
                    = dao.QueryAllWorkPermitsLessThanOrEqualToRequestDateTimeBySiteAndWorkPermitStatus(DateTimeFixture.DateTimeNow, siteId, WorkPermitStatus.Complete);
            foreach(WorkPermit workpermit in foundCompletedWorkPermits)
            {
                Assert.AreEqual(workpermit.WorkPermitStatus, WorkPermitStatus.Complete);
                Assert.IsFalse(workpermit.Deleted);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryAllWorkPermitsThatAreRejected()
        {
            InsertWorkPermits(WorkPermitStatus.Rejected);
            List<WorkPermit> expectedRejectedWorkPermits = QueryAllRejectedWorkPermits();
            List<WorkPermit> foundRejectedWorkPermits = dao.QueryAllWorkPermitsByStatus(WorkPermitStatus.Rejected);
            Assert.IsTrue(foundRejectedWorkPermits.Count >= expectedRejectedWorkPermits.Count);
            foreach(WorkPermit workpermit in foundRejectedWorkPermits)
            {
                Assert.AreEqual(workpermit.WorkPermitStatus, WorkPermitStatus.Rejected);
                Assert.IsTrue(expectedRejectedWorkPermits.Contains(workpermit));
            }
        }

        private List<WorkPermit> InsertWorkPermits(WorkPermitStatus status)
        {
            return InsertWorkPermits(status, DateTimeFixture.DateTimeNow);
        }

        private List<WorkPermit> InsertWorkPermits(WorkPermitStatus status, DateTime now)
        {
            List<WorkPermit> workPermits = WorkPermitFixture.CreateWorkPermitListOfACertainStatus(TEST_WORK_PERMIT_COUNT, status, now);
            foreach(WorkPermit workPermit in workPermits)
            {
                dao.Insert(workPermit);
            }
            return workPermits;
        }

        [Ignore] [Test]
        public void ShouldQueryAllWorkPermitsThatAreIssuedForSarniaAndArePriorOrEqualToAug1_2003()
        {
            DateTime now = DateTimeFixture.DateTimeNow;

            //insert Some with current date
            InsertWorkPermits(WorkPermitStatus.Issued, now);

            //need site
            DateTime updatedToDate = new DateTime(2003, 08, 01);
            DateTime toCheckDateTime = updatedToDate.AddMinutes(1);
            List<WorkPermit> insertedPermits = InsertWorkPermits(WorkPermitStatus.Issued, updatedToDate);

            //Make sure there are some other than Issued permits in the database
            InsertWorkPermits(WorkPermitStatus.Rejected, updatedToDate);

            List<WorkPermit> foundWorkPermits =
                    dao.QueryAllWorkPermitsLessThanOrEqualToRequestDateTimeBySiteAndWorkPermitStatus(
                            toCheckDateTime, siteId, WorkPermitStatus.Issued);
            Assert.IsTrue(foundWorkPermits.Count >= insertedPermits.Count);
            foreach(WorkPermit permit in foundWorkPermits)
            {
                Assert.AreEqual(WorkPermitStatus.Issued, permit.WorkPermitStatus);
                Assert.AreEqual(siteId, permit.FunctionalLocation.Site.IdValue);
                Assert.IsTrue(permit.LastModifiedDate <= toCheckDateTime);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryAllWorkPermitsThatHaveNotBeenUpdatedByDate()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            var updatedToDate = new DateTime(2006, 08, 01);
            List<WorkPermit> workpermits = QueryAllActivePendingWorkPermits().FindAll(obj => obj.FunctionalLocation.Site.Id == siteId);
            Assert.IsTrue(workpermits.Count > 0);
            foreach(WorkPermit workpermit in workpermits)
            {
                workpermit.LastModifiedBy = workpermit.CreatedBy;
                workpermit.LastModifiedDate = updatedToDate;
                dao.Update(workpermit);
                Assert.AreEqual(updatedToDate, workpermit.LastModifiedDate);
            }
            List<WorkPermit> wpAllActiveAndPending = dao.QueryAllWorkPermitsLessThanOrEqualToRequestDateTimeBySiteAndWorkPermitStatus(
                updatedToDate.AddHours(1), siteId, WorkPermitStatus.Pending);
            Assert.AreEqual(workpermits.Count, wpAllActiveAndPending.Count);
            foreach (WorkPermit expected in workpermits)
            {
                WorkPermit actual = wpAllActiveAndPending.FindById(expected);
                Assert.IsNotNull(actual, expected.ToString());
                Assert.AreEqual(expected.ToString(), actual.ToString());
            }
        }

        [Ignore] [Test]
        public void ShouldQueryAllWorkPermitsThatHaveNotBeenUpdatedByDateWithRandomWorkpermitUpdates()
        {
            var updatedToDate = new DateTime(2006, 08, 01);
            List<WorkPermit> workpermits = QueryAllActivePendingWorkPermits();
            var sortedWorkPermit = new List<WorkPermit>();
            for(int index = 0; index < workpermits.Count; index++)
            {
                if(index % 2 == 0)
                {
                    workpermits[index].LastModifiedBy = workpermits[index].CreatedBy;
                    workpermits[index].LastModifiedDate = updatedToDate;
                    dao.Update(workpermits[index]);
                    Assert.AreEqual(updatedToDate, workpermits[index].LastModifiedDate);
                    Assert.IsTrue(workpermits[index].Id.HasValue);
                    sortedWorkPermit.Add(workpermits[index]);
                }
                else
                {
                    workpermits[index].LastModifiedBy = workpermits[index].CreatedBy;
                    workpermits[index].LastModifiedDate = updatedToDate.AddDays(1);
                    dao.Update(workpermits[index]);
                    Assert.IsTrue(workpermits[index].Id.HasValue);
                }
            }
            List<WorkPermit> wpAllActiveAndPending
                    = dao.QueryAllWorkPermitsLessThanOrEqualToRequestDateTimeBySiteAndWorkPermitStatus(updatedToDate.AddHours(1), siteId, WorkPermitStatus.Pending);
            sortedWorkPermit.Sort();
            Assert.AreEqual(sortedWorkPermit.ToString(), wpAllActiveAndPending.ToString());
        }

        private static void FixUpExpectedWorkPermitProperty(WorkPermit expected, WorkPermit actual)
        {
            //
            // Can't compare permit number since insert generates the number 
            // based on the number of items in there
            //
            expected.PermitNumber = actual.PermitNumber;
            //
            // We don't know how CreatedBy and LastModifiedBy will work.
            //
            expected.SetCreatedBy(actual.CreatedBy, actual.IsOperations);
            expected.LastModifiedBy = actual.LastModifiedBy;
        }

        [Ignore] [Test]
        public void QueryByFunctionalLocationsAndStatusesShouldReturnMatchingPermits()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();

            WorkPermit pendingPermit = dao.Insert(WorkPermitFixture.CreateWorkPermit(WorkPermitStatus.Pending, floc));
            WorkPermit approvedPermit = dao.Insert(WorkPermitFixture.CreateWorkPermit(WorkPermitStatus.Approved, floc));
            WorkPermit rejectedPermit = dao.Insert(WorkPermitFixture.CreateWorkPermit(WorkPermitStatus.Rejected, floc));
            List<FunctionalLocation> relevantFlocs = new List<FunctionalLocation> { pendingPermit.FunctionalLocation };
            WorkPermitStatus[] statuses = {WorkPermitStatus.Pending, WorkPermitStatus.Approved};
            List<WorkPermit> retrievedPermits =
                    dao.QueryByFunctionalLocationsAndStatuses(new RootFlocSet(relevantFlocs), statuses);

            Assert.That(retrievedPermits, Has.Some.Property("Id").EqualTo(pendingPermit.Id));
            Assert.That(retrievedPermits, Has.Some.Property("Id").EqualTo(approvedPermit.Id));
            Assert.That(retrievedPermits, Has.None.Property("Id").EqualTo(rejectedPermit.Id));
        }

        [Ignore] [Test]
        public void QueryByFunctionalLocationsAndStatusesShouldReturnPermitsBelowTheGivenFourthAndFifthLevelFlocs()
        {
            FunctionalLocation fourthLevelFloc = FunctionalLocationFixture.GetReal("SR1-OFFS-BDOF-SAB");
            FunctionalLocation fifthLevelFloc = FunctionalLocationFixture.GetReal("SR1-OFFS-BDOF-SAB-02AC009");
            
            WorkPermit permit1 = dao.Insert(WorkPermitFixture.CreateWorkPermit(WorkPermitStatus.Pending, fourthLevelFloc));
            WorkPermit permit2 = dao.Insert(WorkPermitFixture.CreateWorkPermit(WorkPermitStatus.Approved, fifthLevelFloc));

            List<FunctionalLocation> relevantFlocs = new List<FunctionalLocation> { fourthLevelFloc, fifthLevelFloc };
            WorkPermitStatus[] statuses = { WorkPermitStatus.Pending, WorkPermitStatus.Approved };
            List<WorkPermit> retrievedPermits = dao.QueryByFunctionalLocationsAndStatuses(new RootFlocSet(relevantFlocs), statuses);                    

            Assert.AreEqual(2, retrievedPermits.Count);
            Assert.IsTrue(retrievedPermits.Exists(permit => permit.Id == permit1.Id));
            Assert.IsTrue(retrievedPermits.Exists(permit => permit.Id == permit2.Id));
        }

        [Ignore] [Test]
        public void QueryWorkPermitsByFunctionalLocationsShouldReturnCorrectWorkPermitsFromTheDatabase()
        {
            var functionalLocations = new List<FunctionalLocation>
                                          {
                                              FunctionalLocationFixture.GetReal_SR1_OFFS(),
                                              FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF()
                                          };
            List<WorkPermit> results = dao.QueryByFunctionalLocationsAndStatuses(new RootFlocSet(functionalLocations), WorkPermitStatus.All);
            Assert.IsTrue(results.Count > 0);
            foreach(WorkPermit permit in results)
            {
                FunctionalLocationType flocType = permit.FunctionalLocation.Type;
                Assert.IsTrue
                        (
                        flocType == FunctionalLocationType.Level3 ||
                        flocType == FunctionalLocationType.Level4 ||
                        flocType == FunctionalLocationType.Level5
                        );
            }
        }

        [Ignore] [Test]
        public void QueryByFunctionalLocationsShouldReturnNonArchivedPermitsWhenArchivedNotIncludedInStatuses()
        {
            WorkPermit nonArchivedPermit = dao.Insert(WorkPermitFixture.CreateWorkPermit());
            WorkPermit archivedPermit = InsertArchivedPermit(WorkPermitFixture.CreateWorkPermit());
            WorkPermitStatus[] workPermitStatuses = WorkPermitStatus.All;
            List<WorkPermitStatus> allButArchived = workPermitStatuses.FindAll(s => s != WorkPermitStatus.Archived);

            List<WorkPermit> retrievedPermits =
                    dao.QueryByFunctionalLocationsAndStatuses(new RootFlocSet(nonArchivedPermit.FunctionalLocation),
                                                              allButArchived.ToArray());
            
            Assert.That(retrievedPermits, Has.Some.Property("Id").EqualTo(nonArchivedPermit.Id));
            Assert.That(retrievedPermits, Has.None.Property("Id").EqualTo(archivedPermit.Id));
        }

        [Ignore] [Test]
        public void QueryAWorkPermitByIdShouldReturnAWorkPermitFromTheDatabase()
        {
            const long expectedId = 1;
            WorkPermit workPermit = dao.QueryById(expectedId);
            Assert.IsNotNull(workPermit);
            Assert.AreEqual(expectedId, workPermit.Id);
        }

        [Ignore] [Test]
        public void ShouldNullWhenQueryNonExistantWorkPermitId()
        {
            const long NON_EXISTANT_ID = -1;
            WorkPermit workPermit = dao.QueryById(NON_EXISTANT_ID);
            Assert.IsNull(workPermit);
        }

        [Ignore] [Test]
        public void ShouldNullWhenQueryDeletedWorkPermit()
        {
            const long DELETED_ID = 4;
            WorkPermit workPermit = dao.QueryById(DELETED_ID);
            Assert.IsTrue(workPermit.Deleted);
        }

        #region Insert Tests

        [Ignore] [Test]
        public void ShouldBeAbleToInsertWorkPermitAndGetBackNewID()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateWorkPermitWithRadiationInformationSetWithNoID();
            Assert.IsNull(workPermit.Id);
            WorkPermit savedWorkPermit = dao.Insert(workPermit);
            Assert.IsNotNull(savedWorkPermit.Id);
        }

        [Ignore] [Test]
        public void ShouldBeAbleToInsertWorkPermitWithNullValuesForEquipmentAndJobSitePreparationFields()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateWorkPermitWithRadiationInformationSetWithNoID();            
            workPermit.EquipmentPreparationCondition.IsOutOfService = null;            
            workPermit.EquipmentPreparationCondition.IsTestBump = null;
            workPermit.EquipmentPreparationCondition.IsStillContainsResidual = null;
            workPermit.EquipmentPreparationCondition.IsLeakingValves = null;
            
            workPermit.JobWorksitePreparation.IsFlowRequiredForJob = null;
            workPermit.JobWorksitePreparation.IsBondingOrGroundingRequired = null;
            workPermit.JobWorksitePreparation.IsWeldingGroundWireInTestArea = null;
            workPermit.JobWorksitePreparation.IsSurroundingConditionsAffectOrContaminated = null;
            workPermit.JobWorksitePreparation.IsVestedBuddySystemInEffect = null;
            workPermit.JobWorksitePreparation.IsCriticalConditionRemainJobSite = null;
            workPermit.JobWorksitePreparation.IsPermitReceiverFieldOrEquipmentOrientation = null;
                                       
            dao.Insert(workPermit);            
            Assert.IsNotNull(workPermit.Id);
        }
        
        [Ignore] [Test]
        public void ShouldBeAbleToInsertAndQueryWorkPermitWithNullWorkPermitTypeClassificationType()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateWorkPermitWithRadiationInformationSetWithNoID();
            workPermit.WorkPermitTypeClassification = null;
            dao.Insert(workPermit);
            Assert.IsNotNull(workPermit.Id);
            Assert.AreEqual(null, dao.QueryById(workPermit.IdValue).WorkPermitTypeClassification);
        }

        [Ignore] [Test]
        public void ShouldInsertWorkPermitAndGetBackNewID()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateWorkPermitWithNoLastModifiedBy();
            Assert.IsNull(workPermit.Id);
            WorkPermit savedWorkPermit = dao.Insert(workPermit);
            Assert.IsNotNull(savedWorkPermit.Id);
            Assert.IsNull(savedWorkPermit.LastModifiedBy);
        }

        [Ignore] [Test]
        public void ShouldInsertWorkPermitWithSystemCraftOrTrade()
        {
            CraftOrTrade systemCraftOrTrade = CraftOrTradeFixture.CreateCraftOrTradeThatMapsToDB();
            WorkPermit workPermit = WorkPermitFixture.CreateWorkPermitWithNoLastModifiedBy();
            workPermit.Specifics.CraftOrTrade = systemCraftOrTrade;
            long? id = dao.Insert(workPermit).Id;
            WorkPermit retrievedPermit = dao.QueryById(id.Value);
            Assert.AreEqual(typeof(CraftOrTrade), retrievedPermit.Specifics.CraftOrTrade.GetType());
            Assert.AreEqual(systemCraftOrTrade.Id, ((CraftOrTrade) retrievedPermit.Specifics.CraftOrTrade).Id);
        }

        [Ignore] [Test]
        public void ShouldInsertWorkPermitWithWorkAssignment()
        {
            {
                WorkAssignment workAssignment = WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData();
                WorkPermit workPermit = WorkPermitFixture.CreateWorkPermitWithNoLastModifiedBy();
                workPermit.Specifics.WorkAssignment = workAssignment;
                long? id = dao.Insert(workPermit).Id;
                WorkPermit retrievedPermit = dao.QueryById(id.Value);
                Assert.AreEqual(workAssignment.Id, retrievedPermit.WorkAssignment.Id);     
            }
           
            {                
                WorkPermit workPermit = WorkPermitFixture.CreateWorkPermitWithNoLastModifiedBy();
                workPermit.Specifics.WorkAssignment = null;
                long? id = dao.Insert(workPermit).Id;
                WorkPermit retrievedPermit = dao.QueryById(id.Value);
                Assert.IsNull(retrievedPermit.WorkAssignment);     
            }           
        }

        [Ignore] [Test]
        public void ShouldInsertWorkPermitWithUserSpecifiedCraftOrTrade()
        {
            var userSpecifiedCraftOrTrade = new UserSpecifiedCraftOrTrade("Astronaut");
            WorkPermit workPermit = WorkPermitFixture.CreateWorkPermitWithNoLastModifiedBy();
            workPermit.Specifics.CraftOrTrade = userSpecifiedCraftOrTrade;
            long? id = dao.Insert(workPermit).Id;
            WorkPermit retrievedPermit = dao.QueryById(id.Value);
            Assert.AreEqual(userSpecifiedCraftOrTrade, retrievedPermit.Specifics.CraftOrTrade);
        }

        [Ignore] [Test]
        public void InsertWorkPermitShouldLeavePermitNotArchived()
        {
            WorkPermit permit = WorkPermitFixture.CreateWorkPermit();
            permit = dao.Insert(permit);
            WorkPermit retrievedPermit = dao.QueryById(permit.IdValue);
            Assert.IsFalse(retrievedPermit.Is(WorkPermitStatus.Archived));
        }

        [Ignore] [Test]
        public void InsertWorkPermitShouldPersistEndTimeFinalized()
        {
            WorkPermit permit = InsertWorkPermit(true);
            Assert.IsTrue(dao.QueryById(permit.IdValue).StartAndOrEndTimesFinalized);

            permit = InsertWorkPermit(false);
            Assert.IsFalse(dao.QueryById(permit.IdValue).StartAndOrEndTimesFinalized);
        }

        [Ignore] [Test]
        public void ShouldGenerateWorkPermitNumberOnInsert()
        {
            WorkPermit expected = WorkPermitFixture.CreateWorkPermit();
            dao.Insert(expected);
            WorkPermit actual = dao.QueryById(expected.Id.GetValueOrDefault());
            Assert.IsTrue(actual.PermitNumber.Contains(expected.FunctionalLocation.Division));
        }

        [Ignore] [Test]
        public void ShouldPersistIsOperationsTruePositionOnInsert()
        {
            AssertIsOperations(true);
        }

        [Ignore] [Test]
        public void ShouldPersistIsOperationsFalsePositionOnInsert()
        {
            AssertIsOperations(false);
        }

        private void AssertIsOperations(bool isOperations)
        {
            WorkPermit permit = WorkPermitFixture.CreateWorkPermit();
            permit.SetCreatedBy(UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(), isOperations);
            WorkPermit insertedPermit = dao.Insert(permit);
            try
            {
                WorkPermit retrievedPermit = dao.QueryById(insertedPermit.IdValue);
                Assert.AreEqual(isOperations, retrievedPermit.IsOperations);
            }
            finally
            {
                WorkPermitTestDao.DeleteWorkPermit(insertedPermit);
            }
        }

        [Ignore] [Test]
        public void ShouldBeAbleToInsertQueryAndUpdateSameRecord()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            WorkPermit originalWorkPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID(new DateTime(2011, 4, 9));
            originalWorkPermit.SapOperationId = 55555555;
            originalWorkPermit.FireConfinedSpaceRequirements.IsNotApplicable = true;
            AddGasTests(originalWorkPermit);

            WorkAssignment workAssignment1 = workAssignmentDao.QueryById(WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData().IdValue);
            WorkAssignment workAssignment2 = workAssignmentDao.QueryById(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData().IdValue);
            originalWorkPermit.Specifics.WorkAssignment = workAssignment1;

            WorkPermit insertedWorkPermit = dao.Insert(originalWorkPermit);
            Assert.IsNotNull(insertedWorkPermit.Id);
            WorkPermit newInsertedWorkPermit = dao.QueryById(insertedWorkPermit.IdValue);

            Assert.AreEqual(workAssignment1.Id, newInsertedWorkPermit.WorkAssignment.Id);

            //setting this up since stored proc autogenerates the permit number (and we want them to be equal for the test)
            insertedWorkPermit.PermitNumber = newInsertedWorkPermit.PermitNumber;
            insertedWorkPermit.LastModifiedBy = newInsertedWorkPermit.LastModifiedBy;
            // this is because the real user comes back from the DB correctly, but the initial user
            // came from a fixture. The userID is correct for both, but it's more reliable to set
            // it this way and get the tests to pass.
            insertedWorkPermit.SetCreatedBy(newInsertedWorkPermit.CreatedBy, true);
            Assert.AreEqual(insertedWorkPermit, newInsertedWorkPermit);
            newInsertedWorkPermit.EquipmentPreparationCondition.IsVentilationMethodNotApplicable = false;
            newInsertedWorkPermit.EquipmentPreparationCondition.IsVentilationMethodNaturalDraft = true;
            newInsertedWorkPermit.EquipmentPreparationCondition.IsVentilationMethodLocalExhaust = false;
            newInsertedWorkPermit.EquipmentPreparationCondition.IsVentilationMethodForced = false;
            newInsertedWorkPermit.SapOperationId = 66666666;
            newInsertedWorkPermit.SetWorkPermitStatusAndApprover(WorkPermitStatus.Approved,
                                                                 newInsertedWorkPermit.LastModifiedBy);
            newInsertedWorkPermit.FireConfinedSpaceRequirements.IsNotApplicable = false;
            newInsertedWorkPermit.Specifics.WorkAssignment = workAssignment2;

            dao.Update(newInsertedWorkPermit);

            WorkPermit updatedWorkPermit = dao.QueryById(newInsertedWorkPermit.IdValue);
            //everything should be the same except for created by / last modified / approved by differences so
            // set it here
            newInsertedWorkPermit.LastModifiedBy = updatedWorkPermit.LastModifiedBy;
                        
            Assert.AreEqual(newInsertedWorkPermit, updatedWorkPermit);
        }

        private void AddGasTests(WorkPermit workPermit)
        {
            workPermit.GasTests.Elements.Clear();
            List<GasTestElementInfo> gasTestElementInfos = gasTestElementInfoDao.QueryStandardInfosBySiteId(workPermit.FunctionalLocation.Site.IdValue);
            foreach (GasTestElementInfo gasTestElementInfo in gasTestElementInfos)
            {
                workPermit.GasTests.Elements.Add(GasTestElement.CreateGasTestElement(gasTestElementInfo));
            }
        }

        [Ignore] [Test]
        public void InsertUpdateWorkPermitShouldInsertNewLiveLinkDocumentsAndDeleteOldOnes()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID(new DateTime(2010, 6, 7, 9, 3, 5));
            workPermit.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            dao.Insert(workPermit);
            WorkPermit retrievedworkPermit = dao.QueryById(workPermit.IdValue);
            Assert.AreEqual(workPermit.DocumentLinks.Count, retrievedworkPermit.DocumentLinks.Count,
                            "Insert: Number of links are not the same");
            Assert.IsNotNull(retrievedworkPermit.DocumentLinks[0].Id, "Insert: Live Link Document Id is null");
            Assert.AreEqual(workPermit.DocumentLinks[0].Id, retrievedworkPermit.DocumentLinks[0].Id,
                            "Insert: First LiveLink document ID's dont match");
            retrievedworkPermit.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            retrievedworkPermit.LastModifiedBy = UserFixture.CreateOperatorOltUser1InFortMcMurrySite();
            dao.Update(retrievedworkPermit);
            WorkPermit updatedWorkPermit = dao.QueryById(workPermit.IdValue);
            Assert.AreEqual(retrievedworkPermit.DocumentLinks.Count,
                            updatedWorkPermit.DocumentLinks.Count, "UPdate: Number of links are not the same");
            Assert.IsNotNull(updatedWorkPermit.DocumentLinks[1].Id, "UPdate: Live Link Document Id is null");
            Assert.AreEqual(retrievedworkPermit.DocumentLinks[1].Id,
                            updatedWorkPermit.DocumentLinks[1].Id,
                            "UPdate: First LiveLink document ID's dont match");
            updatedWorkPermit.DocumentLinks.Remove(updatedWorkPermit.DocumentLinks[1]);
            dao.Update(updatedWorkPermit);
            WorkPermit updatedSecondTimeWorkPermit = dao.QueryById(workPermit.IdValue);
            Assert.AreEqual(updatedWorkPermit.DocumentLinks.Count,
                            updatedSecondTimeWorkPermit.DocumentLinks.Count,
                            "UPdate with remove: Number of links are not the same");
            Assert.IsNotNull(updatedWorkPermit.DocumentLinks[0].Id,
                             "UPdate with remove: Live Link Document Id is null");
            Assert.AreEqual(updatedWorkPermit.DocumentLinks[0].Id,
                            updatedSecondTimeWorkPermit.DocumentLinks[0].Id,
                            "UPdate with remove: First LiveLink document ID's dont match");
            dao.Remove(workPermit);
        }

        [Ignore] [Test]
        public void ShouldInsertAndRetrieveSapOperationIds()
        {
            long? someMadeUpSapOperationId = 87654321;
            WorkPermit originalWorkPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();
            originalWorkPermit.SapOperationId = someMadeUpSapOperationId;
            WorkPermit insertedWorkPermit = dao.Insert(originalWorkPermit);
            Assert.IsNotNull(insertedWorkPermit.Id);
            WorkPermit newInsertedWorkPermit = dao.QueryById(insertedWorkPermit.IdValue);
            Assert.IsNotNull(newInsertedWorkPermit.SapOperationId);
            Assert.AreEqual(someMadeUpSapOperationId, newInsertedWorkPermit.SapOperationId);
        }

        [Ignore] [Test]
        public void ShouldInsertAndRetrieveEnergyIsolationFields()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();
            workPermit.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequiredNotApplicable = true;
            workPermit.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequired = false;
            workPermit.EquipmentPreparationCondition.LockOutMethod = WorkPermitLockOutMethodType.INDIVIDUAL_BY_WORKER;
            workPermit.EquipmentPreparationCondition.LockOutMethodComments = "abc";
            workPermit.EquipmentPreparationCondition.EnergyIsolationPlanNumber = "123";
            workPermit.EquipmentPreparationCondition.ConditionsOfEIPSatisfied = true;
            workPermit.EquipmentPreparationCondition.ConditionsOfEIPNotSatisfiedComments = "mno";
            workPermit = dao.Insert(workPermit);

            {
                WorkPermit requeried = dao.QueryById(workPermit.IdValue);
                Assert.IsTrue(requeried.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequiredNotApplicable);
                Assert.IsFalse(requeried.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequired.Value);
                Assert.AreEqual(WorkPermitLockOutMethodType.INDIVIDUAL_BY_WORKER, requeried.EquipmentPreparationCondition.LockOutMethod);
                Assert.AreEqual("abc", requeried.EquipmentPreparationCondition.LockOutMethodComments);
                Assert.AreEqual("123", requeried.EquipmentPreparationCondition.EnergyIsolationPlanNumber);
                Assert.IsTrue(requeried.EquipmentPreparationCondition.ConditionsOfEIPSatisfied.Value);
                Assert.AreEqual("mno", requeried.EquipmentPreparationCondition.ConditionsOfEIPNotSatisfiedComments);
            }

            workPermit.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequiredNotApplicable = false;
            workPermit.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequired = true;
            workPermit.EquipmentPreparationCondition.LockOutMethod = WorkPermitLockOutMethodType.INDIVIDUAL_BY_OPERATIONS;
            workPermit.EquipmentPreparationCondition.LockOutMethodComments = "def";
            workPermit.EquipmentPreparationCondition.EnergyIsolationPlanNumber = "456";
            workPermit.EquipmentPreparationCondition.ConditionsOfEIPSatisfied = false;
            workPermit.EquipmentPreparationCondition.ConditionsOfEIPNotSatisfiedComments = "pqr";
            dao.Update(workPermit);

            {
                WorkPermit requeried = dao.QueryById(workPermit.IdValue);
                Assert.IsFalse(requeried.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequiredNotApplicable);
                Assert.IsTrue(requeried.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequired.Value);
                Assert.AreEqual(WorkPermitLockOutMethodType.INDIVIDUAL_BY_OPERATIONS, requeried.EquipmentPreparationCondition.LockOutMethod);
                Assert.AreEqual("def", requeried.EquipmentPreparationCondition.LockOutMethodComments);
                Assert.AreEqual("456", requeried.EquipmentPreparationCondition.EnergyIsolationPlanNumber);
                Assert.IsFalse(requeried.EquipmentPreparationCondition.ConditionsOfEIPSatisfied.Value);
                Assert.AreEqual("pqr", requeried.EquipmentPreparationCondition.ConditionsOfEIPNotSatisfiedComments);
            }

            workPermit.EquipmentPreparationCondition.LockOutMethod = WorkPermitLockOutMethodType.COMPLEX_GROUP;
            dao.Update(workPermit);

            {
                WorkPermit requeried = dao.QueryById(workPermit.IdValue);
                Assert.AreEqual(WorkPermitLockOutMethodType.COMPLEX_GROUP, requeried.EquipmentPreparationCondition.LockOutMethod);
            }

            workPermit.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequired = null;
            workPermit.EquipmentPreparationCondition.LockOutMethod = null;
            workPermit.EquipmentPreparationCondition.LockOutMethodComments = null;
            workPermit.EquipmentPreparationCondition.EnergyIsolationPlanNumber = null;
            workPermit.EquipmentPreparationCondition.ConditionsOfEIPSatisfied = null;
            workPermit.EquipmentPreparationCondition.ConditionsOfEIPNotSatisfiedComments = null;
            dao.Update(workPermit);

            {
                WorkPermit requeried = dao.QueryById(workPermit.IdValue);
                Assert.IsNull(requeried.EquipmentPreparationCondition.IsHazardousEnergyIsolationRequired);
                Assert.IsNull(requeried.EquipmentPreparationCondition.LockOutMethod);
                Assert.AreEqual(null, requeried.EquipmentPreparationCondition.LockOutMethodComments);
                Assert.AreEqual(null, requeried.EquipmentPreparationCondition.EnergyIsolationPlanNumber);
                Assert.IsNull(requeried.EquipmentPreparationCondition.ConditionsOfEIPSatisfied);
                Assert.IsNull(requeried.EquipmentPreparationCondition.ConditionsOfEIPNotSatisfiedComments);
            }
        }

        [Ignore] [Test]
        public void ShouldInsertAndRetrieveAsbestosFields()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();
            workPermit.Asbestos.HazardsConsideredNotApplicable = true;
            workPermit.Asbestos.HazardsConsidered = false;
            workPermit = dao.Insert(workPermit);

            {
                WorkPermit requeried = dao.QueryById(workPermit.IdValue);
                Assert.IsTrue(requeried.Asbestos.HazardsConsideredNotApplicable);
                Assert.IsFalse(requeried.Asbestos.HazardsConsidered.Value);
            }

            workPermit.Asbestos.HazardsConsideredNotApplicable = false;
            workPermit.Asbestos.HazardsConsidered = true;
            dao.Update(workPermit);

            {
                WorkPermit requeried = dao.QueryById(workPermit.IdValue);
                Assert.IsFalse(requeried.Asbestos.HazardsConsideredNotApplicable);
                Assert.IsTrue(requeried.Asbestos.HazardsConsidered.Value);
            }

            workPermit.Asbestos.HazardsConsidered = null;
            dao.Update(workPermit);

            {
                WorkPermit requeried = dao.QueryById(workPermit.IdValue);
                Assert.IsNull(requeried.Asbestos.HazardsConsidered);
            }
        }

        #endregion Insert Tests

        [Ignore] [Test]
        public void ShouldGetAllWorkPermitPropertiesInPopulateInstanceWhenQueryFromDatabase()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            WorkPermit expected = WorkPermitFixture.CreateWorkPermit();
            expected.LastModifiedDate = new DateTime(2011, 5, 14, 11, 0, 7);
            //new work permit must have a createdby set
            expected.SetCreatedBy(UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(), true);
            AddGasTests(expected);

            dao.Insert(expected);
            WorkPermit actual = dao.QueryById(expected.IdValue);
            FixUpExpectedWorkPermitProperty(expected, actual);
            Assert.AreEqual(expected.PermitNumber, actual.PermitNumber);
            Assert.AreEqual(expected.CreatedBy.Id, actual.CreatedBy.Id);
            Assert.AreEqual(expected.PermitValidDateTime, actual.PermitValidDateTime);
            Assert.AreEqual(expected.WorkPermitType, actual.WorkPermitType);
            Assert.AreEqual(expected.WorkPermitStatus, actual.WorkPermitStatus);
            Assert.AreEqual(expected.WorkPermitTypeClassification, actual.WorkPermitTypeClassification);
            AssertWorkPermitSpecifics(expected.Specifics, actual.Specifics);
            AssertWorkPermitAttributes(expected.Attributes, actual.Attributes);
            Assert.AreEqual(expected.AdditionItemsRequired, actual.AdditionItemsRequired);
            Assert.AreEqual(expected.Tools, actual.Tools);
            Assert.AreEqual(expected.EquipmentPreparationCondition, actual.EquipmentPreparationCondition);
            Assert.AreEqual(expected.JobWorksitePreparation, actual.JobWorksitePreparation);
            Assert.AreEqual(expected.RadiationInformation, actual.RadiationInformation);
            Assert.AreEqual(expected.GasTests, actual.GasTests);
            Assert.AreEqual(expected.FireConfinedSpaceRequirements, actual.FireConfinedSpaceRequirements);
            Assert.AreEqual(expected.RespiratoryProtectionRequirements, actual.RespiratoryProtectionRequirements);
            Assert.AreEqual(expected.SpecialProtectionRequirements, actual.SpecialProtectionRequirements);
            Assert.AreEqual(expected, actual);
        }

        [Ignore] [Test]
        public void ShouldMarkWorkPermitAsDeleted()
        {
            const string sqlTestStatement = "SELECT count(*) FROM WorkPermit Where Id = {0} and Deleted = 1";
            WorkPermit workPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();
            dao.Insert(workPermit);
            dao.Remove(workPermit);
            string checkForMarkedAsDeletedSql = string.Format(sqlTestStatement, workPermit.IdValue);
            var workPermitMarkedAsDeletedCount =
                    TestDataAccessUtil.ExecuteScalarExpression<int>(checkForMarkedAsDeletedSql);
            Assert.AreEqual(1, workPermitMarkedAsDeletedCount);
        }

        #region Update Tests

        [Ignore] [Test]
        public void UpdateWorkPermitShouldUpdateWorkPermit()
        {
            WorkPermit originalWorkPermit = dao.QueryById(1);
            Assert.AreEqual(originalWorkPermit.WorkPermitStatus, WorkPermitStatus.Pending);
            originalWorkPermit.SetWorkPermitStatus(WorkPermitStatus.Approved);
            originalWorkPermit.SpecialPrecautionsOrConsiderations = "New Text";
            originalWorkPermit.Specifics.WorkOrderDescription = "New Description";
            originalWorkPermit.SpecialProtectionRequirements.IsEyeOrFaceProtectionFaceshield = true;
            //explicitly change the last mod by.
            originalWorkPermit.LastModifiedBy = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            dao.Update(originalWorkPermit);
            WorkPermit actualWorkPermit = dao.QueryById(1);
            Assert.AreEqual(actualWorkPermit.Id, originalWorkPermit.Id);
            Assert.AreEqual(originalWorkPermit.WorkPermitStatus, WorkPermitStatus.Approved);
            Assert.AreNotEqual(actualWorkPermit.LastModifiedBy, originalWorkPermit.LastModifiedBy);
        }

        [Ignore] [Test]
        public void UpdateWorkPermitThatIsAlreadyApprovedShouldUpdateWorkPermitAndStayApproved()
        {
            WorkPermit originalWorkPermit = dao.QueryById(1);
            originalWorkPermit.SetWorkPermitStatus(WorkPermitStatus.Approved);
            Assert.AreEqual(originalWorkPermit.WorkPermitStatus, WorkPermitStatus.Approved);
            originalWorkPermit.SpecialPrecautionsOrConsiderations = "New Text";
            originalWorkPermit.Specifics.WorkOrderDescription = "New Description";
            originalWorkPermit.SpecialProtectionRequirements.IsEyeOrFaceProtectionFaceshield = true;
            //explicitly change the last mod by.
            originalWorkPermit.LastModifiedBy = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            dao.Update(originalWorkPermit);
            WorkPermit actualWorkPermit = dao.QueryById(1);
            Assert.AreEqual(actualWorkPermit.Id, originalWorkPermit.Id);
            Assert.AreEqual(originalWorkPermit.WorkPermitStatus, WorkPermitStatus.Approved);
            Assert.AreNotEqual(actualWorkPermit.LastModifiedBy, originalWorkPermit.LastModifiedBy);
        }

        [Ignore] [Test]
        public void UpdateWorkPermitShouldSwtichBetweenSystemAndUserSpecifiedCraftOrTrade()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateWorkPermit();
            workPermit.Specifics.CraftOrTrade = CraftOrTradeFixture.CreateCraftOrTradeThatMapsToDB();
            workPermit = dao.Insert(workPermit);
            // Execute:
            var craftOrTrade = new UserSpecifiedCraftOrTrade("Pilot");
            workPermit.Specifics.CraftOrTrade = craftOrTrade;
            dao.Update(workPermit);
            WorkPermit retrievedPermit = dao.QueryById(workPermit.IdValue);
            Assert.AreEqual(typeof(UserSpecifiedCraftOrTrade), retrievedPermit.Specifics.CraftOrTrade.GetType());
            Assert.AreEqual(craftOrTrade, retrievedPermit.Specifics.CraftOrTrade);
        }

        [Ignore] [Test]
        public void UpdateWorkPermitShouldNotHaveNullLastModifiedBy()
        {
            WorkPermit originalWorkPermit = dao.QueryById(1);
            originalWorkPermit.SpecialPrecautionsOrConsiderations = "New Text";
            originalWorkPermit.Specifics.WorkOrderDescription = "New Description";
            originalWorkPermit.SpecialProtectionRequirements.IsEyeOrFaceProtectionFaceshield = true;
            originalWorkPermit.LastModifiedBy = UserFixture.CreateOperatorMickeyInFortMcMurrySite();
            dao.Update(originalWorkPermit);
            WorkPermit actualWorkPermit = dao.QueryById(1);
            Assert.IsNotNull(actualWorkPermit.LastModifiedBy);
        }

        [Ignore] [Test]
        public void UpdateWorkPermitShouldPersistEndTimeFinalized()
        {
            WorkPermit permit = InsertWorkPermit(true);
            permit.StartAndOrEndTimesFinalized = false;
            dao.Update(permit);
            Assert.IsFalse(dao.QueryById(permit.IdValue).StartAndOrEndTimesFinalized);
        }

        [Ignore] [Test]
        public void ShouldUpdateWorkPermitsAssociatedWithADeletedCraftOrTradeAndCopyTheNameOfTheCraftOrTradeToOtherOtherField()
        {            
            WorkPermit workPermit = dao.QueryById(1);
            string originalCraftOrTradeName = workPermit.CraftOrTradeName;
            // Verify that the original craft or trade has an associated craft or trade object.
            Assert.IsTrue(workPermit.Specifics.CraftOrTrade is CraftOrTrade);
            
            dao.UpdateWorkPermitsAssociatedWithDeletedCraftOrTrade(1);
            
            WorkPermit updatedWorkPermit = dao.QueryById(1);
            Assert.AreEqual(originalCraftOrTradeName, updatedWorkPermit.CraftOrTradeName);
            // Verify that the updated craft or trade has an "other" craft or trade object.
            Assert.IsTrue(updatedWorkPermit.Specifics.CraftOrTrade is UserSpecifiedCraftOrTrade);
        }
        
        #endregion Update Tests

        [Ignore] [Test]
        public void ShouldRetrieveSapOperationIdsWhenQueryingByFloc()
        {
            var flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF ()};
            List<WorkPermit> workPermits = dao.QueryByFunctionalLocationsAndStatuses(new RootFlocSet(flocs), WorkPermitStatus.All);
            // at least one of these should have an SapOperationId because I hard coded one in the test data
            bool hasASapOperationId = false;
            foreach(WorkPermit currentPermit in workPermits)
            {
                if(currentPermit.SapOperationId != null)
                {
                    hasASapOperationId = true;
                    break;
                }
            }
            Assert.IsTrue(hasASapOperationId);
        }

        [Ignore] [Test]
        public void ShouldQueryWorkPermitBySapWorkOrderOperationKeys()
        {
            const string workOrderNumber = "00070003432";
            const string operationNumber = "010";
            const string subOperation = "sub";
            WorkPermit permit1 = InsertSapWorkOrderOperationAndPermit(workOrderNumber, operationNumber, subOperation);
            WorkPermit permit2 = InsertSapWorkOrderOperationAndPermit(workOrderNumber + "x", operationNumber, subOperation);
            WorkPermit permit3 = InsertSapWorkOrderOperationAndPermit(workOrderNumber, operationNumber + "x", subOperation);
            WorkPermit permit4 = InsertSapWorkOrderOperationAndPermit(workOrderNumber, operationNumber, subOperation + "x");
            try
            {
                WorkPermit matchingPermit = dao.QueryBySapWorkOrderOperationKeys(workOrderNumber, operationNumber, subOperation);
                Assert.AreEqual(permit1.Id, matchingPermit.Id);
            }
            finally
            {
                Array.ForEach(new[] {permit1}, WorkPermitTestDao.DeleteWorkPermit);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryWorkPermitBySapWorkOrderOperationKeysWithNullSubOperation()
        {
            const string workOrderNumber = "00070003432";
            const string operationNumber = "010";
            WorkPermit permit1 = InsertSapWorkOrderOperationAndPermit(workOrderNumber, operationNumber, "nn");
            WorkPermit permit2 = InsertSapWorkOrderOperationAndPermit(workOrderNumber, operationNumber, null);
            try
            {
                WorkPermit matchingPermit = dao.QueryBySapWorkOrderOperationKeys(workOrderNumber, operationNumber, null);
                Assert.AreEqual(permit2.Id, matchingPermit.Id);
            }
            finally
            {
                Array.ForEach(new[] {permit1}, WorkPermitTestDao.DeleteWorkPermit);
            }
        }

        [Test, Ignore("TODO: Joe - Test me! We don't want to be returned gas test element results with deleted gas test elements ")]
        public void ShouldNotReturnGasTestElementInfoResultsThatAreAssociatedWithDeletedGasTestElements()
        {
            
        }

        private WorkPermit InsertSapWorkOrderOperationAndPermit(string workOrderNumber, string operationNumber,
                                                                string subOperation)
        {
            SapWorkOrderOperation operation = InsertSapWorkOrderOperation(workOrderNumber, operationNumber, subOperation, SapOperationType.WorkPermit);
            return InsertWorkPermit(operation);
        }

        private static SapWorkOrderOperation InsertSapWorkOrderOperation(string workOrderNumber, string operationNumber,
                                                                  string subOperation,
                                                                  SapOperationType sapOperationType)
        {
            var operation = new SapWorkOrderOperation(null, workOrderNumber, operationNumber, subOperation, sapOperationType);
            return DaoRegistry.GetDao<ISapWorkOrderOperationDao>().Insert(operation);
        }

        private WorkPermit InsertWorkPermit(SapWorkOrderOperation operation)
        {
            WorkPermit permit = WorkPermitFixture.CreateWorkPermit();
            permit.SapOperationId = operation.Id;
            return dao.Insert(permit);
        }

        private static void AssertWorkPermitAttributes(WorkPermitAttributes expected, WorkPermitAttributes actual)
        {
            Assert.AreEqual(expected, actual);
        }

        private static void AssertWorkPermitSpecifics(WorkPermitSpecifics expected, WorkPermitSpecifics actual)
        {
            Assert.AreEqual(expected.WorkOrderNumber, actual.WorkOrderNumber);
            Assert.AreEqual(expected.StartDateTime, actual.StartDateTime);
            Assert.AreEqual(expected.EndDateTime, actual.EndDateTime);
            Assert.AreEqual(expected.WorkOrderDescription, actual.WorkOrderDescription);
            Assert.AreEqual(expected.FunctionalLocation.Id, actual.FunctionalLocation.Id);
            Assert.AreEqual(expected.JobStepDescription, actual.JobStepDescription);
            Assert.AreEqual(expected.Communication, actual.Communication);
            Assert.AreEqual(expected.CraftOrTrade, actual.CraftOrTrade);
            Assert.AreEqual(expected.ContractorCompanyName, actual.ContractorCompanyName);
            Assert.AreEqual(expected.ContactName, actual.ContactName);
        }

        private WorkPermit InsertArchivedPermit(WorkPermit permit)
        {
            WorkPermit insertedPermit = dao.Insert(permit);
            insertedPermit.SetWorkPermitStatus(WorkPermitStatus.Archived);
            dao.Update(insertedPermit);
            return insertedPermit;
        }

        private WorkPermit InsertWorkPermit(bool endTimeFinalized)
        {
            WorkPermit permit = WorkPermitFixture.CreateWorkPermit();
            permit.StartAndOrEndTimesFinalized = endTimeFinalized;
            return dao.Insert(permit);
        }
    }
}
