using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture] [Category("Database")]
    public class SummaryLogDTODaoTest : AbstractDaoTest
    {
        private ISummaryLogDTODao summaryLogDTODao;
        private ISummaryLogDao summaryLogDao;
        private IShiftPatternDao shiftPatternDao;
        private IFunctionalLocationDao functionalLocationDao;
        private ISummaryLogReadDao logReadDao;
        private IUserDao userDao;
        private IWorkAssignmentDao workAssignmentDao;

        protected override void TestInitialize()
        {
            summaryLogDTODao = DaoRegistry.GetDao<ISummaryLogDTODao>();
            summaryLogDao = DaoRegistry.GetDao<ISummaryLogDao>();
            shiftPatternDao = DaoRegistry.GetDao<IShiftPatternDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            logReadDao = DaoRegistry.GetDao<ISummaryLogReadDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void QueryByFirstLevelFLOCListShouldReturnDTOs()
        {
            SummaryLog summaryLog = InsertTestSummaryLog();

            DateTime? startOfRange = summaryLog.LogDateTime.AddDays(-1);
            DateTime? endOfRange = summaryLog.LogDateTime.AddDays(1);
            List<FunctionalLocation> flocList = new List<FunctionalLocation> { summaryLog.FunctionalLocations[0] };

            List<SummaryLogDTO> dtos = summaryLogDTODao.QueryDTOsByParentFlocList(startOfRange, endOfRange, new RootFlocSet(flocList), null); 
            Assert.IsTrue(dtos.Count > 0);

            SummaryLogDTO dto = dtos.Find(obj => obj.Id == summaryLog.Id);
            Assert.AreEqual(summaryLog.Id, dto.IdValue);
            Assert.AreEqual(summaryLog.FunctionalLocations[0].FullHierarchy, dto.FunctionalLocations);
            Assert.AreEqual(summaryLog.EnvironmentalHealthSafetyFollowUp, dto.EnvironmentalHealthSafetyFollowUp);
            Assert.AreEqual(summaryLog.InspectionFollowUp, dto.InspectionFollowUp);
            Assert.AreEqual(summaryLog.ProcessControlFollowUp, dto.ProcessControlFollowUp);
            Assert.AreEqual(summaryLog.OperationsFollowUp, dto.OperationsFollowUp);
            Assert.AreEqual(summaryLog.SupervisionFollowUp, dto.SupervisionFollowUp);
            Assert.AreEqual(summaryLog.OtherFollowUp, dto.OtherFollowUp);
            Assert.AreEqual(summaryLog.CreatedByRole.Id, dto.CreatedByRoleId);
            Assert.AreEqual(summaryLog.CreationUser.Id, dto.CreatedByUserId);
            Assert.AreEqual(summaryLog.CreatedShiftPattern.Id, dto.CreatedShiftPatternId);
            Assert.IsNotNull(dto.CreatedShiftStartDate);
            Assert.IsNotNull(dto.CreatedShiftStartTime);
            Assert.IsNotNull(dto.CreatedShiftEndDate);
            Assert.IsNotNull(dto.CreatedShiftEndTime);
            Assert.IsNotNull(dto.WorkAssignmentName);
        }

        [Ignore] [Test]
        public void ShouldPopulateThreadFields()
        {
            SummaryLog parentLog = null;
            SummaryLog childLog = null;
            SummaryLog unrelatedLog = null;

            {
                parentLog = SummaryLogFixture.CreateSummaryLog(ShiftPatternFixture.CreateDayShift(), FunctionalLocationFixture.GetReal_DN1_3003_0000(),
                                      new DateTime(2011, 3, 5, 10, 0, 0), "Parent Log");

                parentLog = summaryLogDao.Insert(parentLog);
                Assert.IsFalse(parentLog.IsPartOfThread);
            }

            {
                childLog = SummaryLogFixture.CreateSummaryLog(ShiftPatternFixture.CreateDayShift(), FunctionalLocationFixture.GetReal_DN1_3003_0000(),
                                     new DateTime(2011, 3, 5, 10, 0, 0), "Child Log");

                childLog.SetReplyTo(parentLog);

                Assert.IsTrue(childLog.IsPartOfThread);
               
                childLog = summaryLogDao.Insert(childLog);                                
            }

            {
                unrelatedLog = SummaryLogFixture.CreateSummaryLog(ShiftPatternFixture.CreateDayShift(), FunctionalLocationFixture.GetReal_DN1_3003_0000(),
                                     new DateTime(2011, 3, 5, 10, 0, 0), "Unrelated Log");
               
                Assert.IsFalse(unrelatedLog.IsPartOfThread);
               
                unrelatedLog = summaryLogDao.Insert(unrelatedLog);                                
            }

            // manually set the parent Log to have children since this is usually set in the service layer.
            parentLog.HasChildren = true;
            summaryLogDao.Update(parentLog);

            {
                DateTime? startOfRange = parentLog.LogDateTime.AddDays(-1);
                DateTime? endOfRange = parentLog.LogDateTime.AddDays(1);
                List<FunctionalLocation> flocList = new List<FunctionalLocation> { parentLog.FunctionalLocations[0] };

                List<SummaryLogDTO> dtos = summaryLogDTODao.QueryDTOsByParentFlocList(startOfRange, endOfRange, new RootFlocSet(flocList), null);

                SummaryLogDTO parentLogFromQuery = dtos.Find(sl => sl.IdValue == parentLog.IdValue);
                SummaryLogDTO childLogFromQuery = dtos.Find(sl => sl.IdValue == childLog.IdValue);
                SummaryLogDTO unrelatedLogFromQuery = dtos.Find(sl => sl.IdValue == unrelatedLog.IdValue);

                Assert.IsNotNull(parentLogFromQuery);
                Assert.IsNotNull(childLogFromQuery);
                Assert.IsNotNull(unrelatedLogFromQuery);

                Assert.IsTrue(parentLogFromQuery.HasChildren);
                Assert.IsFalse(childLogFromQuery.HasChildren);
                Assert.IsFalse(unrelatedLogFromQuery.HasChildren);

                Assert.IsTrue(childLogFromQuery.IsPartOfThread);
                Assert.IsTrue(parentLogFromQuery.IsPartOfThread);                            
                Assert.IsFalse(unrelatedLogFromQuery.IsPartOfThread);                            
            }
        }

        private SummaryLog InsertTestSummaryLog()
        {
            SummaryLog log = SummaryLogFixture.CreateSummaryLog(
                    ShiftPatternFixture.CreateDayShift(),
                    FunctionalLocationFixture.GetReal_DN1_3003_0000(),
                    new DateTime(2011, 3, 5, 10, 0, 0), "test comments");
            return summaryLogDao.Insert(log);
        }

        [Ignore] [Test]
        public void ShouldNotGetDeletedLogsWhenGettingLogsByFLOC()
        {
            SummaryLog summaryLog = InsertTestSummaryLog();

            var flocs = new List<FunctionalLocation>(1) { summaryLog.FunctionalLocations[0] };
            List<SummaryLogDTO> dtos = summaryLogDTODao.QueryDTOsByParentFlocList(null, null, new RootFlocSet(flocs), null);

            Assert.IsNotNull(dtos.Find(obj => obj.Id == summaryLog.Id));

            summaryLogDao.Remove(summaryLog);

            dtos = summaryLogDTODao.QueryDTOsByParentFlocList(null, null, new RootFlocSet(flocs), null);
            Assert.IsNull(dtos.Find(obj => obj.Id == summaryLog.Id));
        }             

        [Ignore] [Test] 
        public void QueryByFunctionalLocationsShouldTreatANullEndRangeLikeAWildCard()
        {
            SummaryLog summaryLog = InsertTestSummaryLog();

            DateTime startRange = summaryLog.LogDateTime.AddDays(-1);
            var flocs = new List<FunctionalLocation>(1) { summaryLog.FunctionalLocations[0] };

            List<SummaryLogDTO> dtos = summaryLogDTODao.QueryDTOsByParentFlocList(startRange, null, new RootFlocSet(flocs), null);
            Assert.IsNotNull(dtos.Find(obj => obj.Id == summaryLog.Id));
        }

        [Ignore] [Test]
        public void QueryByFunctionalLocationsShouldTreatANullStartRangeLikeAWildCard()
        {
            SummaryLog summaryLog = InsertTestSummaryLog();

            DateTime endRange = summaryLog.LogDateTime.AddDays(1);
            var flocs = new List<FunctionalLocation>(1) { summaryLog.FunctionalLocations[0] };

            List<SummaryLogDTO> dtos = summaryLogDTODao.QueryDTOsByParentFlocList(null, endRange, new RootFlocSet(flocs), null);
            Assert.IsNotNull(dtos.Find(obj => obj.Id == summaryLog.Id));
        }
              
        [Ignore] [Test]        
        public void ShouldQueryShiftSummaryLogByDateRange()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_DN1_3003_0000();

            ShiftPattern shiftPattern = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            DateTime now = shiftPattern.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            long id1;
            {
                SummaryLog log = SummaryLogFixture.CreateSummaryLog(
                    shiftPattern,
                    floc,
                    now,
                    "comments 1");
                log.FunctionalLocations = new List<FunctionalLocation> { floc };
                log = summaryLogDao.Insert(log);
                id1 = log.IdValue;
            }

            long id2;
            {
                SummaryLog log = SummaryLogFixture.CreateSummaryLog(
                    shiftPattern,
                    floc,
                    now.AddHours(-3),
                    "comments 2");
                log.FunctionalLocations = new List<FunctionalLocation> { floc };
                log = summaryLogDao.Insert(log);
                id2 = log.IdValue;
            }

            List<FunctionalLocation> flocQueryList = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_DN1() };
            RootFlocSet flocSet = new RootFlocSet(flocQueryList);
            {
                List<SummaryLogDTO> results = summaryLogDTODao.QueryDTOsByParentFlocList(
                    now.AddHours(-10), now.AddHours(10), flocSet, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1), results.ToNewLineDelimitedString());
                Assert.IsTrue(results.Exists(obj => obj.Id == id2), results.ToNewLineDelimitedString());
            }
            {
                List<SummaryLogDTO> results = summaryLogDTODao.QueryDTOsByParentFlocList(
                    now, now.AddHours(1), flocSet, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1), results.ToNewLineDelimitedString());
                Assert.IsFalse(results.Exists(obj => obj.Id == id2), results.ToNewLineDelimitedString());
            }
            {
                List<SummaryLogDTO> results = summaryLogDTODao.QueryDTOsByParentFlocList(
                    now, now, flocSet, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1), results.ToNewLineDelimitedString());
                Assert.IsFalse(results.Exists(obj => obj.Id == id2), results.ToNewLineDelimitedString());
            }
            {
                List<SummaryLogDTO> results = summaryLogDTODao.QueryDTOsByParentFlocList(
                    now.AddHours(-1), now, flocSet, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1), results.ToNewLineDelimitedString());
                Assert.IsFalse(results.Exists(obj => obj.Id == id2), results.ToNewLineDelimitedString());
            }
            {
                List<SummaryLogDTO> results = summaryLogDTODao.QueryDTOsByParentFlocList(
                    now, null, flocSet, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1), results.ToNewLineDelimitedString());
                Assert.IsFalse(results.Exists(obj => obj.Id == id2), results.ToNewLineDelimitedString());
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByParentFloc()
        {
            FunctionalLocation floc1 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A"));
            FunctionalLocation floc2 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B"));
            FunctionalLocation floc3 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B-C"));
            FunctionalLocation floc4 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B-C-D"));
            FunctionalLocation floc5 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B-C-D-E"));
            FunctionalLocation floc6 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("Z"));

            ShiftPattern shiftPattern = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            DateTime now = shiftPattern.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            long id1;
            {
                SummaryLog log = SummaryLogFixture.CreateSummaryLog(shiftPattern, floc1, now, "comments 1");
                log.FunctionalLocations = new List<FunctionalLocation> { floc1 };
                log = summaryLogDao.Insert(log);
                id1 = log.IdValue;
            }
            long id2;
            {
                SummaryLog log = SummaryLogFixture.CreateSummaryLog(shiftPattern, floc2, now, "comments 2");
                log.FunctionalLocations = new List<FunctionalLocation> { floc2 };
                log = summaryLogDao.Insert(log);
                id2 = log.IdValue;
            }
            long id3;
            {
                SummaryLog log = SummaryLogFixture.CreateSummaryLog(shiftPattern, floc3, now, "comments 3");
                log.FunctionalLocations = new List<FunctionalLocation> { floc3 };
                log = summaryLogDao.Insert(log);
                id3 = log.IdValue;
            }
            long id4;
            {
                SummaryLog log = SummaryLogFixture.CreateSummaryLog(shiftPattern, floc4, now, "comments 4");
                log.FunctionalLocations = new List<FunctionalLocation> { floc4 };
                log = summaryLogDao.Insert(log);
                id4 = log.IdValue;
            }
            long id5;
            {
                SummaryLog log = SummaryLogFixture.CreateSummaryLog(shiftPattern, floc5, now, "comments 5");
                log.FunctionalLocations = new List<FunctionalLocation> { floc5 };
                log = summaryLogDao.Insert(log);
                id5 = log.IdValue;
            }
            long id6;
            {
                SummaryLog log = SummaryLogFixture.CreateSummaryLog(shiftPattern, floc6, now, "comments 6");
                log.FunctionalLocations = new List<FunctionalLocation> { floc6 };
                log = summaryLogDao.Insert(log);
                id6 = log.IdValue;
            }

            {
                List<SummaryLogDTO> results = summaryLogDTODao.QueryDTOsByParentFlocList(
                    now.SubtractDays(1), now.AddDays(1), new RootFlocSet(new List<FunctionalLocation> { floc1, floc6 }), null);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1), results.ToNewLineDelimitedString());
                Assert.IsTrue(results.Exists(obj => obj.Id == id2), results.ToNewLineDelimitedString());
                Assert.IsTrue(results.Exists(obj => obj.Id == id3), results.ToNewLineDelimitedString());
                Assert.IsTrue(results.Exists(obj => obj.Id == id4), results.ToNewLineDelimitedString());
                Assert.IsTrue(results.Exists(obj => obj.Id == id5), results.ToNewLineDelimitedString());
                Assert.IsTrue(results.Exists(obj => obj.Id == id6), results.ToNewLineDelimitedString());
            }
            {
                List<SummaryLogDTO> results = summaryLogDTODao.QueryDTOsByParentFlocList(
                    now.SubtractDays(1), now.AddDays(1), new RootFlocSet(new List<FunctionalLocation> { floc1, floc1 }), null);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1), results.ToNewLineDelimitedString());
                Assert.IsTrue(results.Exists(obj => obj.Id == id2), results.ToNewLineDelimitedString());
                Assert.IsTrue(results.Exists(obj => obj.Id == id3), results.ToNewLineDelimitedString());
                Assert.IsTrue(results.Exists(obj => obj.Id == id4), results.ToNewLineDelimitedString());
                Assert.IsTrue(results.Exists(obj => obj.Id == id5), results.ToNewLineDelimitedString());
                Assert.IsFalse(results.Exists(obj => obj.Id == id6), results.ToNewLineDelimitedString());
            }
            {
                List<SummaryLogDTO> results = summaryLogDTODao.QueryDTOsByParentFlocList(
                    now.SubtractDays(1), now.AddDays(1), new RootFlocSet(new List<FunctionalLocation> { floc2 }), null);
                Assert.IsFalse(results.Exists(obj => obj.Id == id1), results.ToNewLineDelimitedString());
                Assert.IsTrue(results.Exists(obj => obj.Id == id2), results.ToNewLineDelimitedString());
                Assert.IsTrue(results.Exists(obj => obj.Id == id3), results.ToNewLineDelimitedString());
                Assert.IsTrue(results.Exists(obj => obj.Id == id4), results.ToNewLineDelimitedString());
                Assert.IsTrue(results.Exists(obj => obj.Id == id5), results.ToNewLineDelimitedString());
                Assert.IsFalse(results.Exists(obj => obj.Id == id6), results.ToNewLineDelimitedString());
            }
            {
                List<SummaryLogDTO> results = summaryLogDTODao.QueryDTOsByParentFlocList(
                    now.SubtractDays(1), now.AddDays(1), new RootFlocSet(new List<FunctionalLocation> { floc3 }), null);
                Assert.IsFalse(results.Exists(obj => obj.Id == id1), results.ToNewLineDelimitedString());
                Assert.IsFalse(results.Exists(obj => obj.Id == id2), results.ToNewLineDelimitedString());
                Assert.IsTrue(results.Exists(obj => obj.Id == id3), results.ToNewLineDelimitedString());
                Assert.IsTrue(results.Exists(obj => obj.Id == id4), results.ToNewLineDelimitedString());
                Assert.IsTrue(results.Exists(obj => obj.Id == id5), results.ToNewLineDelimitedString());
                Assert.IsFalse(results.Exists(obj => obj.Id == id6), results.ToNewLineDelimitedString());
            }
            {
                List<SummaryLogDTO> results = summaryLogDTODao.QueryDTOsByParentFlocList(
                    now.SubtractDays(1), now.AddDays(1), new RootFlocSet(new List<FunctionalLocation> { floc4 }), null);
                Assert.IsFalse(results.Exists(obj => obj.Id == id1), results.ToNewLineDelimitedString());
                Assert.IsFalse(results.Exists(obj => obj.Id == id2), results.ToNewLineDelimitedString());
                Assert.IsFalse(results.Exists(obj => obj.Id == id3), results.ToNewLineDelimitedString());
                Assert.IsTrue(results.Exists(obj => obj.Id == id4), results.ToNewLineDelimitedString());
                Assert.IsTrue(results.Exists(obj => obj.Id == id5), results.ToNewLineDelimitedString());
                Assert.IsFalse(results.Exists(obj => obj.Id == id6), results.ToNewLineDelimitedString());
            }
            {
                List<SummaryLogDTO> results = summaryLogDTODao.QueryDTOsByParentFlocList(
                    now.SubtractDays(1), now.AddDays(1), new RootFlocSet(new List<FunctionalLocation> { floc5 }), null);
                Assert.IsFalse(results.Exists(obj => obj.Id == id1), results.ToNewLineDelimitedString());
                Assert.IsFalse(results.Exists(obj => obj.Id == id2), results.ToNewLineDelimitedString());
                Assert.IsFalse(results.Exists(obj => obj.Id == id3), results.ToNewLineDelimitedString());
                Assert.IsFalse(results.Exists(obj => obj.Id == id4), results.ToNewLineDelimitedString());
                Assert.IsTrue(results.Exists(obj => obj.Id == id5), results.ToNewLineDelimitedString());
                Assert.IsFalse(results.Exists(obj => obj.Id == id6), results.ToNewLineDelimitedString());
            }
        }

        [Ignore] [Test]
        public void ShouldLoadFlocs()
        {
            ShiftPattern shiftPattern = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            DateTime now = shiftPattern.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            FunctionalLocation floc1 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("1"));
            FunctionalLocation floc2 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("2-A"));
            FunctionalLocation floc3 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("3-B-C"));

            long id1 = summaryLogDao.Insert(SummaryLogFixture.CreateSummaryLog(now, shiftPattern, "comments", floc1)).IdValue;
            long id2 = summaryLogDao.Insert(SummaryLogFixture.CreateSummaryLog(now, shiftPattern, "comments", floc2, floc1)).IdValue;
            long id3 = summaryLogDao.Insert(SummaryLogFixture.CreateSummaryLog(now, shiftPattern, "comments", floc3, floc2, floc1)).IdValue;

            {
                List<SummaryLogDTO> results = summaryLogDTODao.QueryDTOsByParentFlocList(
                    now.SubtractDays(1), now.AddDays(1), new RootFlocSet(floc1), null);
                Assert.AreEqual(3, results.Count);
                Assert.AreEqual("1", results.Find(obj => obj.Id == id1).FunctionalLocations);
                Assert.AreEqual("1, 2-A", results.Find(obj => obj.Id == id2).FunctionalLocations);
                Assert.AreEqual("1, 2-A, 3-B-C", results.Find(obj => obj.Id == id3).FunctionalLocations);
            }
            {
                List<SummaryLogDTO> results = summaryLogDTODao.QueryDTOsByParentFlocList(
                    now.SubtractDays(1), now.AddDays(1), new RootFlocSet(floc2), null);
                Assert.AreEqual(2, results.Count);
                Assert.AreEqual("1, 2-A", results.Find(obj => obj.Id == id2).FunctionalLocations);
                Assert.AreEqual("1, 2-A, 3-B-C", results.Find(obj => obj.Id == id3).FunctionalLocations);
            }
            {
                List<SummaryLogDTO> results = summaryLogDTODao.QueryDTOsByParentFlocList(
                    now.SubtractDays(1), now.AddDays(1), new RootFlocSet(floc3), null);
                Assert.AreEqual(1, results.Count);
                Assert.AreEqual("1, 2-A, 3-B-C", results.Find(obj => obj.Id == id3).FunctionalLocations);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByMarkedAsRead()
        {
            ShiftPattern shiftPattern = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            DateTime now = shiftPattern.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            FunctionalLocation floc1 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("1"));
            FunctionalLocation floc2 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("2-A"));
            FunctionalLocation floc3 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("3-B-C"));

            long id1 = summaryLogDao.Insert(SummaryLogFixture.CreateSummaryLog(now, shiftPattern, "c1", floc1)).IdValue;
            long id2 = summaryLogDao.Insert(SummaryLogFixture.CreateSummaryLog(now, shiftPattern, "c3", floc2, floc1)).IdValue;
            long id3 = summaryLogDao.Insert(SummaryLogFixture.CreateSummaryLog(now, shiftPattern, "c5", floc3, floc2, floc1)).IdValue;
            long id4 = summaryLogDao.Insert(SummaryLogFixture.CreateSummaryLog(now, shiftPattern, "c7", floc1)).IdValue;

            User user1 = userDao.Insert(UserFixture.CreateUser("user1", "first1", "last1"));
            User user2 = userDao.Insert(UserFixture.CreateUser("user2", "first2", "last2"));
            User user3 = userDao.Insert(UserFixture.CreateUser("user3", "first3", "last3"));

            logReadDao.Insert(new SummaryLogRead(id1, user1.IdValue, DateTimeFixture.DateTimeNow));
            logReadDao.Insert(new SummaryLogRead(id3, user2.IdValue, DateTimeFixture.DateTimeNow));
            logReadDao.Insert(new SummaryLogRead(id3, user3.IdValue, DateTimeFixture.DateTimeNow));

            {
                List<MarkedAsReadReportLogDTO> results = summaryLogDTODao.QueryDTOByParentFlocListAndMarkedAsRead(
                    now.SubtractDays(1), now.AddDays(1), new RootFlocSet(floc1));

                Assert.AreEqual(2, results.Count);
                {
                    MarkedAsReadReportLogDTO dto = results.Find(obj => obj.FunctionalLocation == "1");
                    Assert.IsNotNull(dto);
                    Assert.AreEqual(1, dto.ReadByUsers.Count);
                    Assert.IsTrue(dto.ReadByUsers.Exists(obj => obj.UserFullNameWithUserName == "last1, first1 [user1]"));
                    Assert.AreEqual("c1", dto.Comments);                    
                }
                {
                    MarkedAsReadReportLogDTO dto = results.Find(obj => obj.FunctionalLocation == "1, 2-A, 3-B-C");
                    Assert.IsNotNull(dto);
                    Assert.AreEqual(2, dto.ReadByUsers.Count);
                    Assert.IsTrue(dto.ReadByUsers.Exists(obj => obj.UserFullNameWithUserName == "last2, first2 [user2]"));
                    Assert.IsTrue(dto.ReadByUsers.Exists(obj => obj.UserFullNameWithUserName == "last3, first3 [user3]"));
                    Assert.AreEqual("c5", dto.Comments);                    
                }
            }
            {
                List<MarkedAsReadReportLogDTO> results = summaryLogDTODao.QueryDTOByParentFlocListAndMarkedAsRead(
                    now.SubtractDays(1), now.AddDays(1), new RootFlocSet(floc2));
                Assert.AreEqual(1, results.Count);
                {
                    MarkedAsReadReportLogDTO dto = results.Find(obj => obj.FunctionalLocation == "1, 2-A, 3-B-C");
                    Assert.IsNotNull(dto);
                    Assert.AreEqual(2, dto.ReadByUsers.Count);
                    Assert.IsTrue(dto.ReadByUsers.Exists(obj => obj.UserFullNameWithUserName == "last2, first2 [user2]"));
                    Assert.IsTrue(dto.ReadByUsers.Exists(obj => obj.UserFullNameWithUserName == "last3, first3 [user3]"));
                    
                    Assert.IsTrue(dto.Comments.Equals("c5"));                    
                }
            }
            {
                List<MarkedAsReadReportLogDTO> results = summaryLogDTODao.QueryDTOByParentFlocListAndMarkedAsRead(
                    now.SubtractDays(1), now.AddDays(1), new RootFlocSet(floc3));
                Assert.AreEqual(1, results.Count);
                {
                    MarkedAsReadReportLogDTO dto = results.Find(obj => obj.FunctionalLocation == "1, 2-A, 3-B-C");
                    Assert.IsNotNull(dto);
                    Assert.AreEqual(2, dto.ReadByUsers.Count);
                    Assert.IsTrue(dto.ReadByUsers.Exists(obj => obj.UserFullNameWithUserName == "last2, first2 [user2]"));
                    Assert.IsTrue(dto.ReadByUsers.Exists(obj => obj.UserFullNameWithUserName == "last3, first3 [user3]"));
                    
                    Assert.IsTrue(dto.Comments.Equals("c5"));
                   
                }
            }
        }

        [Ignore] [Test]
        public void QueryByFunctionalLocations_VaryVisibilityGroups()
        {
            IVisibilityGroupDao visibilityGroupDao = DaoRegistry.GetDao<IVisibilityGroupDao>();
            IWorkAssignmentVisibilityGroupDao workAssignmentVisibilityGroupDao = DaoRegistry.GetDao<IWorkAssignmentVisibilityGroupDao>();

            VisibilityGroup chapsVisibilityGroup = new VisibilityGroup(-1, "Chaps Department", Site.SARNIA_ID, true);
            VisibilityGroup horseshoeVisibilityGroup = new VisibilityGroup(-1, "Horseshoe Department", Site.SARNIA_ID, false);

            visibilityGroupDao.Insert(chapsVisibilityGroup);
            visibilityGroupDao.Insert(horseshoeVisibilityGroup);

            WorkAssignment horseAssignment = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("Horse Supervisor"));
            WorkAssignment clothingAssignment = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("Cowboy Clothing Supervisor"));

            // horse supervisor can read info about chaps and horseshoes, but can only write about horseshoes
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup1 = new WorkAssignmentVisibilityGroup(null, horseAssignment.IdValue, chapsVisibilityGroup.IdValue, "Chaps", VisibilityType.Read);
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup2 = new WorkAssignmentVisibilityGroup(null, horseAssignment.IdValue, horseshoeVisibilityGroup.IdValue, "Horseshoe", VisibilityType.Write);
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup3 = new WorkAssignmentVisibilityGroup(null, horseAssignment.IdValue, horseshoeVisibilityGroup.IdValue, "Horseshoe", VisibilityType.Read);

            // cowboy clothing supervisor can read info about chaps and horseshoes, but can only write about chaps
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup4 = new WorkAssignmentVisibilityGroup(null, clothingAssignment.IdValue, chapsVisibilityGroup.IdValue, "Chaps", VisibilityType.Read);
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup5 = new WorkAssignmentVisibilityGroup(null, clothingAssignment.IdValue, chapsVisibilityGroup.IdValue, "Chaps", VisibilityType.Write);
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup6 = new WorkAssignmentVisibilityGroup(null, clothingAssignment.IdValue, horseshoeVisibilityGroup.IdValue, "Horseshoe", VisibilityType.Read);

            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup1);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup2);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup3);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup4);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup5);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup6);

            SummaryLog log1 = SummaryLogFixture.CreateSummaryLogNotInDatabase();
            log1.WorkAssignment = horseAssignment;
            log1.FunctionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF(), FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3() };
            summaryLogDao.Insert(log1);

            SummaryLog log2 = SummaryLogFixture.CreateSummaryLogNotInDatabase();
            log2.WorkAssignment = clothingAssignment;
            log2.FunctionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3() };
            summaryLogDao.Insert(log2);

            SummaryLog log3 = SummaryLogFixture.CreateSummaryLogNotInDatabase();
            log3.WorkAssignment = null;
            log3.FunctionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3() };
            summaryLogDao.Insert(log3);

            RootFlocSet queryFlocSet = new RootFlocSet(FunctionalLocationFixture.GetReal_SR1());

            // case: I can read about chaps so I want to see all logs that were made with an assignment that has a chaps write group (or has no work assignment)
            {
                List<long> visibilityGroupIds = new List<long> { chapsVisibilityGroup.IdValue };
                List<SummaryLogDTO> results = summaryLogDTODao.QueryDTOsByParentFlocList(null, null, queryFlocSet, visibilityGroupIds);
                Assert.AreEqual(5, results.Count);
                Assert.IsTrue(results.Exists(dto => dto.Id == log2.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == log3.Id));
            }

            // case: I can read about horseshoes so I want to see all logs that were made with an assignment that has a horseshoe write group (or has no work assignment)
            {
                List<long> visibilityGroupIds = new List<long> { horseshoeVisibilityGroup.IdValue };
                List<SummaryLogDTO> results = summaryLogDTODao.QueryDTOsByParentFlocList(null, null, queryFlocSet, visibilityGroupIds);

                Assert.AreEqual(5, results.Count);
                Assert.IsTrue(results.Exists(dto => dto.Id == log1.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == log3.Id));
            }

            // case: I can read about both horseshoes and chaps so I want to see all logs that were made with an assignment that has at least one of those write groups (or has no work assignment)
            {
                List<long> visibilityGroupIds = new List<long> { horseshoeVisibilityGroup.IdValue, chapsVisibilityGroup.IdValue };
                List<SummaryLogDTO> results = summaryLogDTODao.QueryDTOsByParentFlocList(null, null, queryFlocSet, visibilityGroupIds);

                Assert.AreEqual(6, results.Count);
                Assert.IsTrue(results.Exists(dto => dto.Id == log1.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == log2.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == log3.Id));
            }

            // case: I logged in with no assignment so my visibility groups list is null, so I get to see everything
            {
                List<long> visibilityGroupIds = null;
                List<SummaryLogDTO> results = summaryLogDTODao.QueryDTOsByParentFlocList(null, null, queryFlocSet, visibilityGroupIds);

                Assert.AreEqual(6, results.Count);
                Assert.IsTrue(results.Exists(dto => dto.Id == log1.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == log2.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == log3.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldInsertUpdateAndRetrieveFunctionalLocationList()
        {
            FunctionalLocation parentFloc = FunctionalLocationFixture.GetReal_SR1();

            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3();

            SummaryLog log1 = SummaryLogFixture.CreateSummaryLogNotInDatabase();
            log1.FunctionalLocations = new List<FunctionalLocation> { floc1, floc2 };
            summaryLogDao.Insert(log1);

            {
                List<SummaryLogDTO> results = summaryLogDTODao.QueryDTOsByParentFlocList(null, null, new RootFlocSet(parentFloc), null);
                SummaryLogDTO dto = results.Find(obj => obj.Id == log1.Id);
                Assert.AreEqual("SR1-OFFS-BDOF, SR1-PLT3-GEN3", dto.FunctionalLocations);
            }

            log1.FunctionalLocations.Clear();
            log1.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF_SAB_02AC009());
            summaryLogDao.Update(log1);

            {
                List<SummaryLogDTO> results = summaryLogDTODao.QueryDTOsByParentFlocList(null, null, new RootFlocSet(parentFloc), null);
                SummaryLogDTO dto = results.Find(obj => obj.Id == log1.Id);
                Assert.AreEqual("SR1-OFFS-BDOF-SAB-02AC009", dto.FunctionalLocations);
            }
        }
       
    }
}