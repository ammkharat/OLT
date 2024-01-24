using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture] [Category("Database")]
    public class WorkPermitDTODaoTest : AbstractDaoTest
    {
        private IWorkPermitDTODao dao;
        private IWorkPermitDao workPermitDao;
        private IWorkAssignmentDao workAssignmentDao;

        private static readonly List<WorkPermitStatus> allButArchived = WorkPermitStatus.All.FindAll(s => s != WorkPermitStatus.Archived);

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IWorkPermitDTODao>();
            workPermitDao = DaoRegistry.GetDao<IWorkPermitDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
        }


        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldGetListOfDTOS()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("SR1-PLT3-HYDU");
            var list = new List<FunctionalLocation> { floc };
            List<WorkPermitDTO> dtoList = dao.QueryByDateRangeAndStatuses(new RootFlocSet(list), WorkPermitStatus.All, new DateTime(2004, 01, 01), DateTimeFixture.DateTimeNow, null);
            Assert.IsTrue(dtoList.Count > 0);
        }

        [Ignore] [Test]
        public void ShouldSetApprovedByUserName()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("SR1-OFFS-BDOF");
            var list = new List<FunctionalLocation> { floc };
            const long APPROVED_WORK_PERMIT_ID = 8;

            List<WorkPermitDTO> statuses = dao.QueryByDateRangeAndStatuses(new RootFlocSet(list), new List<WorkPermitStatus> {WorkPermitStatus.Approved}, new DateTime(2000, 01, 01),
                                                                           DateTimeFixture.DateTimeNow, null);

            WorkPermitDTO approvedDTO = statuses.FindById(APPROVED_WORK_PERMIT_ID);
            string expectedApprovedByName = User.ToFullNameWithUserName("Gumble", "Barney", "oltuser7");
            Assert.IsNotNull(approvedDTO);
            Assert.AreEqual(WorkPermitStatus.Approved.IdValue, approvedDTO.StatusId);
            Assert.AreEqual(expectedApprovedByName, approvedDTO.ApprovedByFullNameWithUserName);
            Assert.IsTrue(approvedDTO.CreatedByFullNameWithUserName.Contains("oltuser1"));
        }

        [Ignore] [Test]
        public void ShouldReturnWorkPermitsThatStartInTheShift()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("SR1-OFFS-BDOF");
            List<FunctionalLocation> flocList = new List<FunctionalLocation> { floc };
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateShiftPattern(new Time(6, 0), new Time(18, 0));

            List<WorkPermitDTO> workPermitDTOS = dao.QueryByFLOCsAndShiftForThisDate(new RootFlocSet(flocList), allButArchived, shiftPattern, new DateTime(2005, 11, 25, 7, 30, 0));
            // For the purposes of this test, the work permit with ID 1 should definitely show up (among others) 
            // because it starts during the shift.
            Assert.That(workPermitDTOS, Has.Some.Property("Id").EqualTo(1));
        }

        [Ignore] [Test]
        public void ShouldReturnWorkPermitsThatSpanTheShift()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("SR1-OFFS-BDOF");
            List<FunctionalLocation> flocList = new List<FunctionalLocation> { floc };
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateShiftPattern(new Time(6, 0), new Time(18, 0));
            List<WorkPermitDTO> workPermitDTOS = dao.QueryByFLOCsAndShiftForThisDate(new RootFlocSet(flocList), allButArchived, shiftPattern, new DateTime(2006, 3, 25, 7, 0, 0));
            // For the purposes of this test, the work permit with ID 1 should definitely show up (among others) 
            // because it spans the given shift
            Assert.That(workPermitDTOS, Has.Some.Property("Id").EqualTo(1));
        }

        [Ignore] [Test]
        public void QueryByFLOCsAndShiftForThisDateShouldReturnNonArchivedWorkPermits()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("SR1-PLT3-GEN3");
            var flocList = new List<FunctionalLocation> { floc };
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift();
            WorkPermit permit = CreatePermit(floc, shiftPattern, new Date(2005, 11, 25));
            WorkPermit archivedPermit = CreatePermit(floc, shiftPattern, new Date(2005, 11, 25));
            permit = workPermitDao.Insert(permit);
            archivedPermit = InsertArchivedPermit(archivedPermit);
            List<WorkPermitDTO> workPermitDTOs = dao.QueryByFLOCsAndShiftForThisDate(new RootFlocSet(flocList), allButArchived, shiftPattern, shiftPattern.StartTime.ToDateTime(new Date(2005, 11, 25)));

            Assert.That(workPermitDTOs, Has.Some.Property("Id").EqualTo(permit.Id));
            Assert.That(workPermitDTOs, Has.None.Property("Id").EqualTo(archivedPermit.Id));
        }

        private static WorkPermit CreatePermit(FunctionalLocation floc, ShiftPattern shiftPattern, Date startDate)
        {
            WorkPermit permit = WorkPermitFixture.CreateWorkPermit();
            permit.Specifics.FunctionalLocation = floc;
            permit.Specifics.StartDateTime = shiftPattern.StartTime.ToDateTime(startDate);
            return permit;
        }

        [Ignore] [Test]
        public void ShouldPopulateDtoWithOperationsProperty()
        {
            WorkPermit operationsPermit = CreateWorkPermit(true);
            WorkPermit nonOperationsPermit = CreateWorkPermit(false);
            WorkPermit insertedOperationsPermit = workPermitDao.Insert(operationsPermit);
            WorkPermit insertNonOperationsPermit = workPermitDao.Insert(nonOperationsPermit);
            try
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { operationsPermit.FunctionalLocation };
                var statuses = new[]
                                                  {
                                                      insertedOperationsPermit.WorkPermitStatus,
                                                      insertNonOperationsPermit.WorkPermitStatus
                                                  };

                DateTime subtract = insertedOperationsPermit.StartDateTime.Subtract(new TimeSpan(1, 0, 0));
                DateTime add = insertedOperationsPermit.StartDateTime.Add(new TimeSpan(1, 0, 0));
                List<WorkPermitDTO> retrievedPermits = dao.QueryByDateRangeAndStatuses(new RootFlocSet(flocs), statuses, subtract, add, null);

                Assert.That(retrievedPermits,
                            Has.Some.Property("Id").EqualTo(operationsPermit.Id).And.Some.Property("Operations").EqualTo
                                (true));

                Assert.That(retrievedPermits, 
                    Has.Some.Property("Id").EqualTo(operationsPermit.Id).And
                        .Some.Property("Operations").EqualTo(false));

            }
            finally
            {
                Array.ForEach(new []{ insertedOperationsPermit}, WorkPermitTestDao.DeleteWorkPermit);
            }
        }

        [Ignore] [Test]
        public void ShouldInsertAndQueryWithWorkAssignment()
        {
            WorkAssignment assignment = workAssignmentDao.QueryById(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData().IdValue);

            WorkPermit permitWithAssignment = WorkPermitFixture.CreateWorkPermit(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF());                                        
            permitWithAssignment.Specifics.WorkAssignment = assignment;
            WorkPermit permitReturnedFromInsert = workPermitDao.Insert(permitWithAssignment);                            

            WorkPermit permitWithoutAssignment = WorkPermitFixture.CreateWorkPermit(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF());                                        
            permitWithoutAssignment.Specifics.WorkAssignment = assignment;
            WorkPermit permitReturnedFromInsertNoAssignment = workPermitDao.Insert(permitWithoutAssignment);                            

            WorkPermit sanityCheckPermit = workPermitDao.QueryById(permitReturnedFromInsert.IdValue);
            Assert.AreEqual(assignment, sanityCheckPermit.WorkAssignment);

            List<FunctionalLocation> flocList = new List<FunctionalLocation> {permitWithAssignment.FunctionalLocation};


            {
                List<WorkPermitDTO> result = dao.QueryByDateRangeAndStatuses(
                    new RootFlocSet(flocList),
                    WorkPermitStatus.All,
                    permitWithAssignment.StartDateTime.AddDays(-7),
                    permitWithAssignment.StartDateTime.AddDays(7),
                    assignment);

                Assert.IsTrue(result.Exists(dto => dto.IdValue == permitReturnedFromInsert.IdValue));

                foreach (WorkPermitDTO workPermitDto in result)
                {
                    Assert.AreEqual(assignment.Name, workPermitDto.WorkAssignment);
                }                
            }

            {
                List<WorkPermitDTO> result = dao.QueryByDateRangeAndStatuses(
                    new RootFlocSet(flocList),
                    WorkPermitStatus.All,
                    permitWithAssignment.StartDateTime.AddDays(-7),
                    permitWithAssignment.StartDateTime.AddDays(7),
                    null);

                Assert.IsTrue(result.Exists(dto => dto.IdValue == permitReturnedFromInsert.IdValue));
                Assert.IsTrue(result.Exists(dto => dto.IdValue == permitReturnedFromInsertNoAssignment.IdValue));
            }
        }

        [Ignore] [Test]
        public void ShouldPopulateDtoWithFullNamesWithUsernames()
        {
            User user = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            WorkPermit permit = WorkPermitFixture.CreateWorkPermit(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF());
            permit.SetCreatedBy(user, true);
            permit.LastModifiedBy = user;
            permit.SetWorkPermitStatusAndApprover(WorkPermitStatus.Approved, user);
            WorkPermit insertedPermit = workPermitDao.Insert(permit);
            try
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { permit.FunctionalLocation };

                DateTime add = permit.StartDateTime.Add(new TimeSpan(1, 0, 0));
                DateTime subtract = permit.StartDateTime.Subtract(new TimeSpan(1, 0, 0));
                List<WorkPermitDTO> retrievedPermits = dao.QueryByDateRangeAndStatuses(new RootFlocSet(flocs),
                                                                                                 WorkPermitStatus.All,
                                                                                                 subtract, add, null);
                
                WorkPermitDTO retrievedOperationsPermit = retrievedPermits.FindById(permit.Id);
                Assert.IsTrue(retrievedOperationsPermit.CreatedByFullNameWithUserName.Contains(user.Username));
                Assert.IsTrue(retrievedOperationsPermit.LastModifiedByFullNameWithUserName.Contains(user.Username));
                Assert.IsTrue(retrievedOperationsPermit.ApprovedByFullNameWithUserName.Contains(user.Username));
            }
            finally
            {
                WorkPermitTestDao.DeleteWorkPermit(insertedPermit);
            }
        }

        [Ignore] [Test]
        public void ShouldPopulateDtoWithEmptyFullNamesWithUsernamesIfNull()
        {
            WorkPermit permit = WorkPermitFixture.CreateWorkPermit(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF());
            permit.SetWorkPermitStatusAndApprover(WorkPermitStatus.Pending, null);
            WorkPermit insertedPermit = workPermitDao.Insert(permit);
            try
            {
                List<FunctionalLocation> flocs = new List<FunctionalLocation> { permit.FunctionalLocation };
                DateTime add = permit.StartDateTime.Add(new TimeSpan(1, 0, 0));
                DateTime subtract = permit.StartDateTime.Subtract(new TimeSpan(1, 0, 0));
                List<WorkPermitDTO> retrievedPermits = dao.QueryByDateRangeAndStatuses(new RootFlocSet(flocs),
                                                                                                 WorkPermitStatus.All,
                                                                                                 subtract, add, null);

                Assert.That(retrievedPermits, Has.Some.Property("Id").EqualTo(permit.Id));
                Assert.That(retrievedPermits, Has.Some.Property("ApprovedByFullNameWithUserName").Empty);
                    
            }
            finally
            {
                WorkPermitTestDao.DeleteWorkPermit(insertedPermit);
            }
        }

        [Ignore] [Test]
        public void QueryWithoutArchivedPermitStatusShouldNotReturnIt()
        {
            WorkPermit nonArchivedPermit = workPermitDao.Insert(WorkPermitFixture.CreateWorkPermit(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF()));
            WorkPermit archivedPermit = InsertArchivedPermit(WorkPermitFixture.CreateWorkPermit(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF()));
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { archivedPermit.FunctionalLocation };

            DateTime add = nonArchivedPermit.StartDateTime.Add(new TimeSpan(1, 0, 0));
            DateTime subtract = nonArchivedPermit.StartDateTime.Subtract(new TimeSpan(1, 0, 0));
            List<WorkPermitDTO> retrievedPermits = dao.QueryByDateRangeAndStatuses(new RootFlocSet(flocs),
                                                                                             allButArchived,
                                                                                             subtract, add, null);
            
            Assert.That(retrievedPermits, Has.Some.Property("Id").EqualTo(nonArchivedPermit.Id));
            Assert.That(retrievedPermits, Has.None.Property("Id").EqualTo(archivedPermit.Id));

        }

        [Ignore] [Test]
        public void QueryByDateRangeShouldReturnAllStatusesWhenInRange()
        {
            DateTime now = DateTimeFixture.DateTimeNow;

            FunctionalLocation floc = FunctionalLocationFixture.GetReal("SR1-PLT3-GEN3");
            var flocList = new List<FunctionalLocation> { floc };
            WorkPermitStatus[] statuses = WorkPermitStatus.All;
            var range = new Range<Date>(now.ToDate().SubtractDays(3), now.ToDate().AddDays(3));
            InsertWorkPermits(floc, now, statuses);
            List<WorkPermitDTO> dtos = dao.QueryByDateRangeAndStatuses(new RootFlocSet(flocList),
                                                            statuses,
                                                            range.LowerBound.CreateDateTime(Time.START_OF_DAY),
                                                            range.UpperBound.CreateDateTime(Time.END_OF_DAY),
                                                            null);
            foreach (WorkPermitStatus status in statuses)
            {
                Assert.IsTrue(dtos.Exists(obj => obj.Status == status), status.Name);
            }
        }

        [Ignore] [Test]
        public void QueryByDateRangeShouldReturnNoRecordsWhenNothingInRange()
        {
            DateTime now = DateTimeFixture.DateTimeNow;

            FunctionalLocation floc = FunctionalLocationFixture.GetReal("SR1-PLT3-GEN3");
            var flocList = new List<FunctionalLocation> { floc };
            WorkPermitStatus[] statuses = WorkPermitStatus.All;
            var range = new Range<Date>(now.ToDate().AddDays(1), now.ToDate().AddDays(3));
            InsertWorkPermits(floc, now, statuses);
            List<WorkPermitDTO> dtos = dao.QueryByDateRangeAndStatuses(new RootFlocSet(flocList),
                                                            statuses,
                                                            range.LowerBound.CreateDateTime(Time.START_OF_DAY),
                                                            range.UpperBound.CreateDateTime(Time.END_OF_DAY), 
                                                            null);
            Assert.IsTrue(dtos.Count == 0);
        }

        [Ignore] [Test]
        public void QueryByDateRangeShouldReturnOnlyThoseInRange()
        {
            DateTime now = DateTimeFixture.DateTimeNow;

            FunctionalLocation floc = FunctionalLocationFixture.GetReal("SR1-PLT3-GEN3");
            var flocList = new List<FunctionalLocation> { floc };
            WorkPermitStatus[] statuses = WorkPermitStatus.All;
            Range<Date> range = new Range<Date>(now.ToDate(), now.ToDate().AddDays(2));
            Range<DateTime> queryRange = new Range<DateTime>(range.LowerBound.CreateDateTime(Time.START_OF_DAY), range.UpperBound.CreateDateTime(Time.END_OF_DAY));
            List<WorkPermitDTO> dtosBeforeInsert = dao.QueryByDateRangeAndStatuses(new RootFlocSet(flocList),
                                                            statuses,
                                                            queryRange.LowerBound,
                                                            queryRange.UpperBound,
                                                            null);

            List<WorkPermit> inserted = InsertWorkPermitsWithRange(floc, now, statuses);
            List<WorkPermitDTO> dtosAfterInsert = dao.QueryByDateRangeAndStatuses(new RootFlocSet(flocList),
                                                            statuses,
                                                            queryRange.LowerBound,
                                                            queryRange.UpperBound,
                                                            null);
            
            int permitsAfterInsert = dtosAfterInsert.Count;
            int permitsBeforeInsert = dtosBeforeInsert.Count;
            int permitsJustInsertedWithInRange = inserted.FindAll(p => queryRange.IsRangeNotOverLapped(new Range<DateTime>(p.StartDateTime, p.EndDateTime.Value))).Count;
            Assert.AreEqual(permitsAfterInsert, permitsBeforeInsert + permitsJustInsertedWithInRange);
        }

        private void InsertWorkPermits(FunctionalLocation floc, DateTime dateTime, IEnumerable<WorkPermitStatus> statuses)
        {
            foreach(WorkPermitStatus status in statuses)
            {
                WorkPermit permit = WorkPermitFixture.CreateWorkPermit();
                permit.Specifics.FunctionalLocation = floc;
                permit.Specifics.StartDateTime = dateTime;
                permit.Specifics.EndDateTime = dateTime.AddMinutes(1);
                permit.SetWorkPermitStatus(status);
                workPermitDao.Insert(permit);
            }
        }

        private List<WorkPermit> InsertWorkPermitsWithRange(FunctionalLocation floc, DateTime dateTime, IEnumerable<WorkPermitStatus> statuses)
        {
            List<WorkPermit> result = new List<WorkPermit>();
            int i = 0;
            foreach(WorkPermitStatus status in statuses)
            {
                WorkPermit permit = WorkPermitFixture.CreateWorkPermit();
                permit.Specifics.FunctionalLocation = floc;
                permit.Specifics.StartDateTime = dateTime.AddDays(i);
                permit.Specifics.EndDateTime = permit.Specifics.StartDateTime.AddHours(2);
                permit.SetWorkPermitStatus(status);
                WorkPermit workPermit = workPermitDao.Insert(permit);
                i++;
                result.Add(workPermit);
            }
            return result;
        }

        private WorkPermit InsertArchivedPermit(WorkPermit permit)
        {
            WorkPermit insertedPermit = workPermitDao.Insert(permit);
            insertedPermit.SetWorkPermitStatus(WorkPermitStatus.Archived);
            workPermitDao.Update(insertedPermit);
            return insertedPermit;
        }

        private static WorkPermit CreateWorkPermit(bool isOperations)
        {
            WorkPermit permit = WorkPermitFixture.CreateWorkPermit(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF());
            permit.SetCreatedBy(permit.CreatedBy, isOperations);
            return permit;
        }
    }
}