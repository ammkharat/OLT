using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture] [Category("Database")]
    public class LogDefinitionDTODaoTest : AbstractDaoTest
    {
        private ILogDefinitionDTODao dao;
        private ILogDefinitionDao logDefinitionDao;
        private Role roleInDB;
        private IRoleDao roleDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ILogDefinitionDTODao>();
            logDefinitionDao = DaoRegistry.GetDao<ILogDefinitionDao>();
            // Get a Role already in the Database
            roleDao = DaoRegistry.GetDao<IRoleDao>();
            roleInDB = roleDao.QueryByActiveDirectoryKey(SiteFixture.Oilsands(), "RestrictionReportingAdmin");
        }

        protected override void Cleanup() {}

        [Ignore] [Test]
        public void TestGetLogDefinitionDTOListShouldReturnAListOfLogs()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF()};
            List<LogDefinitionDTO> list = dao.QueryByFunctionalLocationsAndLogType(new RootFlocSet(flocs), LogType.Standard, null);
            Assert.IsTrue(list.Count > 0);
        }

        [Ignore] [Test]
        public void TestGetLogDefinitionDTOListShouldReturnAListofNone()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_PLT1_AFTU_SIC() };
            List<LogDefinitionDTO> list = dao.QueryByFunctionalLocationsAndLogType(new RootFlocSet(flocs), LogType.Standard, null);
            Assert.IsTrue(list.Count == 0);
        }

        [Ignore] [Test]
        public void ShouldReturnOperatingEngineerLogCreatedByOperatorWhenQuery()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            User createdUser = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            LogDefinition definition = BuildInsertableLogDefinition(true);
            definition.Schedule =
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            definition.Schedule.Id = 1;
            InsertLogDefinition(definition);

            definition.FunctionalLocations = new List<FunctionalLocation> { floc };
            definition.CreatedBy = createdUser;
            definition = InsertLogDefinition(definition);
            try
            {
                // Execute:
                var flocs = new List<FunctionalLocation>{floc};
                List<LogDefinitionDTO> definitions = dao.QueryByFunctionalLocationsAndLogType(new RootFlocSet(flocs), LogType.Standard, null);
                LogDefinitionDTO retrievedDTO =
                        definitions.Find(dto => dto.Id.Equals(definition.Id));
                Assert.AreEqual(definition.PlainTextComments, retrievedDTO.Comments);
                Assert.AreEqual(definition.Schedule.ToString(false), retrievedDTO.ScheduleInformation);
                Assert.That(definition.CreatedDateTime, Is.EqualTo(retrievedDTO.LogDateTime).Within(TimeSpan.FromSeconds(10)));
                Assert.AreEqual(definition.CreatedByRole.IdValue, retrievedDTO.CreatedByRoleId);
                Assert.AreEqual(definition.CreatedBy.IdValue, retrievedDTO.CreatedByUserId);
            }
            finally
            {
                RemoveLogDefinition(definition);
            }
        }

        [Ignore] [Test]
        public void ShouldOnlyReturnLogDefinitionsWithGivenLogType()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            User createdUser = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            
            LogDefinition standardLogDefinition = LogDefinitionFixture.CreateLogDefinition(null, LogType.Standard);
            standardLogDefinition.FunctionalLocations = new List<FunctionalLocation> { floc };
            standardLogDefinition.CreatedBy = createdUser;
            standardLogDefinition = InsertLogDefinition(standardLogDefinition);

            LogDefinition directiveLogDefinition = LogDefinitionFixture.CreateLogDefinition(null, LogType.DailyDirective);
            directiveLogDefinition.FunctionalLocations = new List<FunctionalLocation> { floc };
            directiveLogDefinition.CreatedBy = createdUser;
            directiveLogDefinition = InsertLogDefinition(directiveLogDefinition);

            List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc };
            List<LogDefinitionDTO> standardList = dao.QueryByFunctionalLocationsAndLogType(new RootFlocSet(flocs), LogType.Standard, null);
            List<LogDefinitionDTO> directiveList = dao.QueryByFunctionalLocationsAndLogType(new RootFlocSet(flocs), LogType.DailyDirective, null);
            
            Assert.IsTrue(standardList.Exists(logDefnDto => logDefnDto.Id == standardLogDefinition.Id));
            Assert.IsTrue(standardList.TrueForAll(logDefnDto => logDefnDto.LogType == LogType.Standard));

            Assert.IsTrue(directiveList.Exists(logDefnDto => logDefnDto.Id == directiveLogDefinition.Id));
            Assert.IsTrue(directiveList.TrueForAll(logDefnDto => logDefnDto.LogType == LogType.DailyDirective));
        }

        [Ignore] [Test]
        public void ShouldReturnLogDefinitionsThatHaveASecondLevelFloc()  // note: only daily directive log defs can be created at 2nd level
        {
            FunctionalLocation level2Floc = FunctionalLocationFixture.GetReal_SR1_OFFS();
            FunctionalLocation level3Floc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            User createdUser = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();

            LogDefinition secondLevelLogDefinition = LogDefinitionFixture.CreateLogDefinition(null, LogType.DailyDirective);
            secondLevelLogDefinition.FunctionalLocations = new List<FunctionalLocation> { level2Floc };
            secondLevelLogDefinition.CreatedBy = createdUser;
            secondLevelLogDefinition = InsertLogDefinition(secondLevelLogDefinition);

            LogDefinition thirdLevelLogDefinition = LogDefinitionFixture.CreateLogDefinition(null, LogType.DailyDirective);
            thirdLevelLogDefinition.FunctionalLocations = new List<FunctionalLocation> { level2Floc };
            thirdLevelLogDefinition.CreatedBy = createdUser;
            thirdLevelLogDefinition = InsertLogDefinition(thirdLevelLogDefinition);

            List<FunctionalLocation> flocs = new List<FunctionalLocation> { level2Floc, level3Floc };
            List<LogDefinitionDTO> directiveList = dao.QueryByFunctionalLocationsAndLogType(new RootFlocSet(flocs), LogType.DailyDirective, null);
            Assert.IsTrue(directiveList.Exists(logDefnDto => logDefnDto.Id == secondLevelLogDefinition.Id));
            Assert.IsTrue(directiveList.Exists(logDefnDto => logDefnDto.Id == thirdLevelLogDefinition.Id));
        }

        [Ignore] [Test]
        public void ShouldReturnLogDefinitionsHavingAFlocThatIsEqualToOrIsAChildOfOrIsAnAncestorOfOneOfTheGivenFlocs()
        {
            User createdUser = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();

            FunctionalLocation sr1Offs = FunctionalLocationFixture.GetReal_SR1_OFFS();
            FunctionalLocation sr1OffsBdof = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            FunctionalLocation sr1OffsTkfm = FunctionalLocationFixture.GetReal_SR1_OFFS_TKFM();

            FunctionalLocation sr1Plt3 = FunctionalLocationFixture.GetReal_SR1_PLT3();
            FunctionalLocation sr1Plt3Hydu = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            FunctionalLocation sr1Plt3HyduSch33Cr001 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU_SCH_33CR001();


            LogDefinition logDefinitionA = LogDefinitionFixture.CreateLogDefinition(null, LogType.DailyDirective);
            logDefinitionA.PlainTextComments = "A";
            logDefinitionA.FunctionalLocations = new List<FunctionalLocation> { sr1OffsTkfm, sr1Plt3HyduSch33Cr001 };
            logDefinitionA.CreatedBy = createdUser;
            logDefinitionA = InsertLogDefinition(logDefinitionA);

            LogDefinition logDefinitionB = LogDefinitionFixture.CreateLogDefinition(null, LogType.DailyDirective);
            logDefinitionB.PlainTextComments = "B";
            logDefinitionB.FunctionalLocations = new List<FunctionalLocation> { sr1Offs, sr1Plt3 };
            logDefinitionB.CreatedBy = createdUser;
            logDefinitionB = InsertLogDefinition(logDefinitionB);

            {
                List<FunctionalLocation> queryFlocs = new List<FunctionalLocation> { sr1Plt3Hydu };
                List<LogDefinitionDTO> results = dao.QueryByFunctionalLocationsAndLogType(new RootFlocSet(queryFlocs), LogType.DailyDirective, null);
                Assert.AreEqual(2, results.Count);
                Assert.AreEqual(logDefinitionA.Id, results[0].Id);
            }

            {
                List<FunctionalLocation> queryFlocs = new List<FunctionalLocation> { sr1Offs, sr1OffsTkfm, sr1OffsBdof };
                List<LogDefinitionDTO> results = dao.QueryByFunctionalLocationsAndLogType(new RootFlocSet(queryFlocs), LogType.DailyDirective, null);
                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Exists(dto => dto.Id == logDefinitionA.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == logDefinitionB.Id));
            }

            LogDefinition logDefinitionC = LogDefinitionFixture.CreateLogDefinition(null, LogType.DailyDirective);
            logDefinitionC.PlainTextComments = "C";
            logDefinitionC.FunctionalLocations = new List<FunctionalLocation> { sr1Offs };
            logDefinitionC.CreatedBy = createdUser;
            logDefinitionC = InsertLogDefinition(logDefinitionB);

            {
                List<FunctionalLocation> queryFlocs = new List<FunctionalLocation> { sr1OffsBdof };
                List<LogDefinitionDTO> results = dao.QueryByFunctionalLocationsAndLogType(new RootFlocSet(queryFlocs), LogType.DailyDirective, null);
                Assert.AreEqual(2, results.Count);
                Assert.That(results, Has.Some.Property("Id").EqualTo(logDefinitionB.Id));
                Assert.That(results, Has.Some.Property("Id").EqualTo(logDefinitionC.Id));
                Assert.That(results, Has.All.Property("Id").Not.EqualTo(logDefinitionA.Id));
            }
        }

        [Ignore] [Test]
        public void VariousQueries_VaryVisibilityGroups()
        {
            IWorkAssignmentDao workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
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

            RootFlocSet queryFlocSet = new RootFlocSet(FunctionalLocationFixture.GetReal_ED1_A001_U007());

            LogDefinition logDefinition1 = LogDefinitionFixture.CreateLogDefinition(null, LogType.Standard, horseAssignment);
            logDefinition1.FunctionalLocations = queryFlocSet.FunctionalLocations;
            InsertLogDefinition(logDefinition1);

            LogDefinition logDefinition2 = LogDefinitionFixture.CreateLogDefinition(null, LogType.Standard, clothingAssignment);
            logDefinition2.FunctionalLocations = queryFlocSet.FunctionalLocations;
            InsertLogDefinition(logDefinition2);

            LogDefinition logDefinition3 = LogDefinitionFixture.CreateLogDefinition(null, LogType.Standard, null);
            logDefinition3.FunctionalLocations = queryFlocSet.FunctionalLocations;
            InsertLogDefinition(logDefinition3);

            // case: I can read about chaps so I want to see all logs that were made with an assignment that has a chaps write group (and ones with no assignment)
            {
                List<long> visibilityGroupIds = new List<long> { chapsVisibilityGroup.IdValue };

                List<LogDefinitionDTO> results1 = dao.QueryByFunctionalLocationsAndLogType(queryFlocSet, LogType.Standard, visibilityGroupIds);
                Assert.AreEqual(2, results1.Count);
                Assert.IsTrue(results1.Exists(dto => dto.Id == logDefinition2.Id));
                Assert.IsTrue(results1.Exists(dto => dto.Id == logDefinition3.Id));

                List<LogDefinitionDTO> results2 = dao.QueryByUserRootFlocsAndLogType(queryFlocSet, LogType.Standard, visibilityGroupIds);
                Assert.AreEqual(2, results2.Count);
                Assert.IsTrue(results2.Exists(dto => dto.Id == logDefinition2.Id));
                Assert.IsTrue(results2.Exists(dto => dto.Id == logDefinition3.Id));
            }

            // case: I can read about horseshoes so I want to see all logs that were made with an assignment that has a horseshoe write group (and ones with no assignment)
            {
                List<long> visibilityGroupIds = new List<long> { horseshoeVisibilityGroup.IdValue };

                List<LogDefinitionDTO> results1 = dao.QueryByFunctionalLocationsAndLogType(queryFlocSet, LogType.Standard, visibilityGroupIds);
                Assert.AreEqual(2, results1.Count);
                Assert.IsTrue(results1.Exists(dto => dto.Id == logDefinition1.Id));
                Assert.IsTrue(results1.Exists(dto => dto.Id == logDefinition3.Id));

                List<LogDefinitionDTO> results2 = dao.QueryByUserRootFlocsAndLogType(queryFlocSet, LogType.Standard, visibilityGroupIds);
                Assert.AreEqual(2, results2.Count);
                Assert.IsTrue(results2.Exists(dto => dto.Id == logDefinition1.Id));
                Assert.IsTrue(results2.Exists(dto => dto.Id == logDefinition3.Id));
            }

            // case: I can read about both horseshoes and chaps so I want to see all logs that were made with an assignment that has at least one of those write groups (and ones with no assignment)
            {
                List<long> visibilityGroupIds = new List<long> { horseshoeVisibilityGroup.IdValue, chapsVisibilityGroup.IdValue };

                List<LogDefinitionDTO> results1 = dao.QueryByFunctionalLocationsAndLogType(queryFlocSet, LogType.Standard, visibilityGroupIds);
                Assert.AreEqual(3, results1.Count);
                Assert.IsTrue(results1.Exists(dto => dto.Id == logDefinition1.Id));
                Assert.IsTrue(results1.Exists(dto => dto.Id == logDefinition2.Id));
                Assert.IsTrue(results1.Exists(dto => dto.Id == logDefinition3.Id));

                List<LogDefinitionDTO> results2 = dao.QueryByUserRootFlocsAndLogType(queryFlocSet, LogType.Standard, visibilityGroupIds);
                Assert.AreEqual(3, results2.Count);
                Assert.IsTrue(results2.Exists(dto => dto.Id == logDefinition1.Id));
                Assert.IsTrue(results2.Exists(dto => dto.Id == logDefinition2.Id));
                Assert.IsTrue(results2.Exists(dto => dto.Id == logDefinition3.Id));
            }
        }

        private LogDefinition InsertLogDefinition(LogDefinition logDefinition)
        {
            return LogDefinitionDao().Insert(logDefinition);
        }

        private void RemoveLogDefinition(LogDefinition logDefinition)
        {
            LogDefinitionDao().Remove(logDefinition);
        }

        private ILogDefinitionDao LogDefinitionDao()
        {
            return logDefinitionDao;
        }

        private LogDefinition BuildInsertableLogDefinition(bool isOperatingEngineerLog)
        {
            LogDefinition logDefinition =
                new LogDefinition(RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11FromJan10Onward(),
                                  new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3() },
                                  false, false, false, false, false, false, isOperatingEngineerLog, roleInDB,
                                  DateTimeFixture.DateTimeNow, UserFixture.CreateUserWithGivenId(1), UserFixture.CreateUserWithGivenId(1),
                                  DateTimeFixture.DateTimeNow, new List<DocumentLink>(),                                  
                                  "comments", "comments",                                  
                                  LogType.Standard, null, false, null, null, true);

            return logDefinition;
        }
    }
}