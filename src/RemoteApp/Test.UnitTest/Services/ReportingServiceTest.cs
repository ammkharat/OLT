using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using NMock2.Matchers;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class ReportingServiceTest
    {
        private IReportingService reportingService;

        private ILogDTODao mockLogDTODao;
        private ITargetAlertDao mockTargetAlertDao;
        private ITargetAlertDTODao mockTargetAlertDTODao;
        private ITargetAlertResponseDao mockTargetAlertResponseDao;
        private ISafeWorkPermitAssessmentReportDTODao mockSafeWorkPermitAssessmentReportDTODao;
        private IDeviationAlertReportDTODao mockDeviationAlertReportDTODao;
        private ISummaryLogDTODao mockSummaryLogDTODao;
        private ActionItemDao mockActionItemDao;
        private IDetailedLogReportDTODao mockDetailedLogReportDTODao;
        private ICustomFieldTrendReportDTODao mockCustomFieldTrendReportDTODao;
        private IFormOilsandsTrainingReportDTODao mockFormOilsandsTrainingReportDTODao;
        private IEventDao mockEventDao;
        private IDirectiveDTODao mockDirectiveDtoDao;
        private IFormOP14Dao mockformop14dao;
        

        private IShiftHandoverQuestionnaireDTODao mockQuestionnaireDTODao;
        private IShiftHandoverQuestionnaireDao mockQuestionnaireDao;
        
        private IPlantHistorianService mockPlantHistorianService;
        

        private Mockery mockery;

        [SetUp]
        public void SetUp()
        {
            mockery = new Mockery();
            mockLogDTODao = mockery.NewMock<ILogDTODao>();
            mockTargetAlertDao = mockery.NewMock<ITargetAlertDao>();
            mockTargetAlertDTODao = mockery.NewMock<ITargetAlertDTODao>();
            mockTargetAlertResponseDao = mockery.NewMock<ITargetAlertResponseDao>();
            mockSafeWorkPermitAssessmentReportDTODao = mockery.NewMock<ISafeWorkPermitAssessmentReportDTODao>();
            mockDeviationAlertReportDTODao = mockery.NewMock<IDeviationAlertReportDTODao>();
            mockSummaryLogDTODao = mockery.NewMock<ISummaryLogDTODao>();
            mockActionItemDao = mockery.NewMock<ActionItemDao>();
            mockDetailedLogReportDTODao = mockery.NewMock<IDetailedLogReportDTODao>();

            mockQuestionnaireDTODao = mockery.NewMock<IShiftHandoverQuestionnaireDTODao>();
            mockQuestionnaireDao = mockery.NewMock<IShiftHandoverQuestionnaireDao>();
            
            mockPlantHistorianService = mockery.NewMock<IPlantHistorianService>();
            mockCustomFieldTrendReportDTODao = mockery.NewMock<ICustomFieldTrendReportDTODao>();
            mockFormOilsandsTrainingReportDTODao = mockery.NewMock<IFormOilsandsTrainingReportDTODao>();
            mockEventDao = mockery.NewMock<IEventDao>();
            mockDirectiveDtoDao = mockery.NewMock<IDirectiveDTODao>();
            mockformop14dao = mockery.NewMock<IFormOP14Dao>();
            

            reportingService = new ReportingService(
                mockPlantHistorianService,
                mockLogDTODao,
                mockSummaryLogDTODao,
                mockActionItemDao,
                mockDetailedLogReportDTODao,                 
                mockQuestionnaireDTODao, 
                mockTargetAlertDao,
                mockTargetAlertDTODao, 
                mockSafeWorkPermitAssessmentReportDTODao, 
                mockTargetAlertResponseDao,
                mockDeviationAlertReportDTODao,
                mockQuestionnaireDao,
                mockCustomFieldTrendReportDTODao,
                mockFormOilsandsTrainingReportDTODao,
                mockEventDao,
                mockDirectiveDtoDao, mockformop14dao);
        }
        
        [TearDown]
        public void TearDown()
        {
            DaoRegistry.Clear();          
        }

        [Ignore] [Test]
        public void ShouldGetDailyShiftLogsForMultipleUserShifts()
        {
            List<LogReportDTO> logReportDtosToReturn = LogDTOFixture.CreateLogReportDTOListWithTwoLogs();

            FunctionalLocation floc = FunctionalLocationFixture.GetAny_Unit1();
            List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc };
            RootFlocSet flocSet = new RootFlocSet(functionalLocations);

            List<UserShift> userShifts = new List<UserShift>();
            DateTime now = DateTimeFixture.DateTimeNow;
            UserShift twelveZShift =
                UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateShiftPattern("12z", new Time(10),
                                                                                        new Time(22), now,
                                                                                        SiteFixture.Sarnia()));
            userShifts.Add(twelveZShift);
            UserShift twelveXShift =
                UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateShiftPattern("12x", new Time(22),
                                                                                        new Time(10), now,
                                                                                        SiteFixture.Sarnia()));
            userShifts.Add(twelveXShift);

            TagInfoGroup tagInfoGroup = TagInfoGroupFixture.GetExistingSarniaTagInfoGroup();

            Expect.Once.On(mockLogDTODao).Method("QueryForLogReportDTO").With(
                flocSet, twelveZShift, false).Will(Return.Value(logReportDtosToReturn));

            Expect.Once.On(mockLogDTODao).Method("QueryForLogReportDTO").With(
                flocSet, twelveXShift, false).Will(Return.Value(new List<LogReportDTO>()));

            List<TagInfoReportDetail> expectedTagInfoReportDetails = SetTagInfoGroupReportDetailExpectation(tagInfoGroup);

            DailyShiftLogReportDTO reportDTO = reportingService.GetDailyShiftLogReportData(flocSet, userShifts, tagInfoGroup);

            //
            //  LogReport Assertions
            //
            List<LogReportDTO> list = reportDTO.Logs;
            Assert.AreEqual(2, list.Count);

            //
            //  TagInfoReportDetails
            //
            List<TagInfoReportDetail> actualTagInfoReportDetails = reportDTO.TagInfoReportDetailList;
            Assert.AreEqual(expectedTagInfoReportDetails, actualTagInfoReportDetails);

            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        [ExpectedException(typeof(NoDataFoundException))]
        public void GetOperatingEngineerShiftLogReportDataShouldGuardAgainstNoFunctionalLocations()
        {
            Site site = SiteFixture.Denver();
            List<FunctionalLocation> flocs = new List<FunctionalLocation>();
            List<UserShift> userShifts = new List<UserShift> { UserShiftFixture.CreateUserShift() };
            const TagInfoGroup tagInfoGroup = null;
            reportingService.GetOperatingEngineerShiftLogReportData(site, new RootFlocSet(flocs), userShifts, tagInfoGroup);
        }

        [Ignore] [Test]
        [ExpectedException(typeof(NoDataFoundException))]
        public void GetOperatingEngineerShiftLogReportDataShouldGuardAgainstNoUserShifts()
        {
            Site site = SiteFixture.Denver();
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetAny_Unit1() };
            List<UserShift> userShifts = new List<UserShift>();
            const TagInfoGroup tagInfoGroup = null;
            reportingService.GetOperatingEngineerShiftLogReportData(site, new RootFlocSet(flocs), userShifts, tagInfoGroup);
        }

        [Ignore] [Test]
        [ExpectedException(typeof(NoDataFoundException))]
        public void GetOperatingEngineerShiftLogReportDataShouldGuardAgainstNoSite()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetAny_Unit1() };
            List<UserShift> userShifts = new List<UserShift> { UserShiftFixture.CreateUserShift() };
            const TagInfoGroup tagInfoGroup = null;
            reportingService.GetOperatingEngineerShiftLogReportData(null, new RootFlocSet(flocs), userShifts, tagInfoGroup);
        }

        [Ignore] [Test]
        public void GetOperatingEngineerShiftLogReportDataShouldRetrieveLogsForEachShiftAndWorkAssignmentReport()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetAny_Unit1() };
            RootFlocSet flocSet = new RootFlocSet(flocs);

            //
            //  User Shift Set Up
            //
            UserShift userShift1 = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateDayShift());
            List<LogReportDTO> shift1Logs = new List<LogReportDTO> { CreateLogReportDto() };
            Expect.Once.On(mockLogDTODao).Method("QueryForLogReportDTO").
                With(Is.Same(flocSet), Is.Same(userShift1), Is.EqualTo(true)).
                Will(Return.Value(shift1Logs));

            UserShift userShift2 = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateNightShift());
            List<LogReportDTO> shift2Logs = new List<LogReportDTO> { CreateLogReportDto() };
            Expect.Once.On(mockLogDTODao).Method("QueryForLogReportDTO").
                With(Is.Same(flocSet), Is.Same(userShift2), Is.EqualTo(true)).
                Will(Return.Value(shift2Logs));

            Site site = SiteFixture.Denver();

            //
            //  WorkAssignment Report Details Set Up
            //
            List<UserShift> userShifts = new List<UserShift>(new[] { userShift1, userShift2 });
            List<WorkAssignmentReportDetail> workAssignmentReportDetails = new List<WorkAssignmentReportDetail>();

            //
            //  TagInfoGroup SetUp
            //
            TagInfoGroup tagInfoGroup = TagInfoGroupFixture.CreateSampleExistingTagInfoGroup(site,2);
            List<TagInfoReportDetail> expectedTagInfoReportDetails = SetTagInfoGroupReportDetailExpectation(tagInfoGroup);

            // Execute:
            OperatingEngineerLogReportDTO report = reportingService.GetOperatingEngineerShiftLogReportData(site, flocSet, userShifts, tagInfoGroup);

            //
            //  LogReport Assertions
            //
            List<LogReportDTO> logs = report.Logs;
            Assert.AreEqual(2, logs.Count, "Should have combination of logs from user shift 1 and 2.");
            Assert.AreSame(shift1Logs[0], logs[0]);
            Assert.AreSame(shift2Logs[0], logs[1]);

            //
            //  TagInfoReport Assertions
            //
            List<TagInfoReportDetail> actualTagInfoReportDetails = report.TagInfoReportDetailList;
            Assert.AreEqual(expectedTagInfoReportDetails, actualTagInfoReportDetails);

            Assert.AreEqual(workAssignmentReportDetails, report.WorkAssignmentReportDetails);
            
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        private List<TagInfoReportDetail> SetTagInfoGroupReportDetailExpectation(TagInfoGroup tagInfoGroup)
        {
            List<TagInfoReportDetail> expectedTagInfoReportDetails = new List<TagInfoReportDetail>();

            foreach (TagInfo tagInfo in tagInfoGroup.TagInfoList)
            {
                decimal? someValue = 21.456m;
                
                TagInfoReportDetail detail = new TagInfoReportDetail(tagInfo.Name, tagInfo.Description, tagInfo.Units, someValue);
                expectedTagInfoReportDetails.Add(detail);
                Expect.Once.On(mockPlantHistorianService).Method("CanReadTagValue").With(tagInfo).Will(Return.Value(true));
                Expect.Once
                    .On(mockPlantHistorianService)
                    .Method("ReadTagValues")
                    .With(new AlwaysMatcher(true, "Whatever"),
                          new EqualMatcher(tagInfo),
                          new AlwaysTrueMatcher())
                    .Will(Return.Value(new decimal?[] {someValue.Value}));
            }
            return expectedTagInfoReportDetails;
        }

        [Ignore] [Test]
        public void GetDailyShiftAlertReportDataShouldReturnDailyShiftAlert()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation>();
            RootFlocSet flocSet = new RootFlocSet(flocs);

            UserShift userShift = UserShiftFixture.CreateUserShift();
            List<UserShift> userShifts = new List<UserShift> { userShift };

            TargetAlert alert = TargetAlertFixture.CreateSarniaTargetAlertWith3();
            List<TargetAlert> targetAlertList = new List<TargetAlert> { alert };

            TargetAlertResponse response = TargetAlertResponseFixture.CreateNewResponse();
            List<TargetAlertResponse> targetAlertResponseList = new List<TargetAlertResponse> { response };

            TargetAlertResponseReportDetailDTO responseReportDetailDTO =
                new TargetAlertResponseReportDetailDTO(
                    response.ResponseComment.CreatedBy, response.ResponseComment.CreatedDate, "Some Comment", response.GapReason);

            TargetAlertReportDetailDTO expectedDTO = new TargetAlertReportDetailDTO(alert.IdValue,
                                                                                    alert.TargetName,
                                                                                    alert.FunctionalLocation,
                                                                                    alert.Status,
                                                                                    alert.CreatedDateTime,
                                                                                    alert.LastModifiedDateTime,
                                                                                    userShift,
                                                                                    alert.Tag,
                                                                                    alert.GetTargetThresholdEvaluationForOriginalExceedingValue(),
                                                                                    alert.ActualValue.GetValueOrDefault(),
                                                                                    alert.AcknowledgedUser,
                                                                                    alert.AcknowledgedDateTime,
                                                                                    new List<TargetAlertResponseReportDetailDTO> { responseReportDetailDTO }
                                                                                    );
            List<TargetAlertReportDetailDTO> expectedDtoList = new List<TargetAlertReportDetailDTO> { expectedDTO };

            
            Expect.Once.On(mockTargetAlertDao).Method("QueryByFunctionalLocationsAndUserShift")
                .With(flocSet, userShift).Will(Return.Value(targetAlertList));
            Expect.Once.On(mockTargetAlertResponseDao).Method("QueryByTargetAlert")
                .With(alert).Will(Return.Value(targetAlertResponseList));

            List<TargetAlertReportDetailDTO> dtoList =
                reportingService.GetDailyShiftAlertReportData(flocSet, userShifts);
            
            Assert.AreEqual(expectedDtoList, dtoList);
            
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void GetShiftGapReasonReportDataShouldGetDataWithStartDateTimeOfShiftOnStartDate()
        {
            ShiftPattern shiftPattern =
                ShiftPatternFixture.CreateShiftPattern(new Time(18, 00), new Time(06, 00));

            Expect.Once.On(mockTargetAlertResponseDao).Method("QueryGapReasonsByShiftAndDateRange").
                With(Is.Anything, Is.EqualTo(shiftPattern), 
                     Is.EqualTo(new DateTime(2006, 8, 3, 18, 00, 00)), Is.Anything).
                Will(Return.Value(new List<ShiftGapReasonReportDTO>()));

            reportingService.GetShiftGapReasonReportData(new List<ShiftPattern> { shiftPattern },
                                                         new RootFlocSet(new List<FunctionalLocation>()),
                                                         new Date(2006, 8, 3),
                                                         new Date(2006, 8, 4));
            
            mockery.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Ignore] [Test]
        public void GetShiftGapReasonReportDataShouldGetDataWithEndDateTimeOfShiftStartingOnEndDate()
        {
            ShiftPattern shiftPattern =
                ShiftPatternFixture.CreateShiftPattern(new Time(18, 00), new Time(06, 00));

            Expect.Once.On(mockTargetAlertResponseDao).Method("QueryGapReasonsByShiftAndDateRange").
                With(Is.Anything, Is.EqualTo(shiftPattern), 
                     Is.Anything, Is.EqualTo(new DateTime(2006, 8, 5, 06, 00, 00))).
                Will(Return.Value(new List<ShiftGapReasonReportDTO>()));

            reportingService.GetShiftGapReasonReportData(new List<ShiftPattern> { shiftPattern },
                                                         new RootFlocSet(new List<FunctionalLocation>()),
                                                         new Date(2006, 8, 3),
                                                         new Date(2006, 8, 4));
            
            mockery.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Ignore] [Test]
        public void GetShiftGapReasonReportDataShouldGetDataWithUnitFlocs()
        {
            List<FunctionalLocation> unitFlocs =
                new List<FunctionalLocation> { FunctionalLocationFixture.GetAny_Unit1() };
            RootFlocSet rootFlocSet = new RootFlocSet(unitFlocs);

            Expect.Once.On(mockTargetAlertResponseDao).Method("QueryGapReasonsByShiftAndDateRange").
                With(Is.EqualTo(rootFlocSet), Is.Anything, Is.Anything, Is.Anything).
                Will(Return.Value(new List<ShiftGapReasonReportDTO>()));

            reportingService.GetShiftGapReasonReportData(new List<ShiftPattern> { ShiftPatternFixture.CreateNewShiftPattern() },
                                                         rootFlocSet,
                                                         new Date(2006, 8, 3),
                                                         new Date(2006, 8, 4));
            
            mockery.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Ignore] [Test]
        public void GetShiftGapReasonReportDataShouldGetDataOnceForEachShiftPattern()
        {
            ShiftPattern shiftPattern1 = 
                ShiftPatternFixture.CreateShiftPattern(new Time(06, 00), new Time(18, 00));
            ShiftPattern shiftPattern2 = 
                ShiftPatternFixture.CreateShiftPattern(new Time(18, 00), new Time(06, 00));

            Expect.Once.On(mockTargetAlertResponseDao).Method("QueryGapReasonsByShiftAndDateRange").
                With(Is.Anything, Is.EqualTo(shiftPattern1), Is.Anything, Is.Anything).
                Will(Return.Value(new List<ShiftGapReasonReportDTO>()));
            Expect.Once.On(mockTargetAlertResponseDao).Method("QueryGapReasonsByShiftAndDateRange").
                With(Is.Anything, Is.EqualTo(shiftPattern2), Is.Anything, Is.Anything).
                Will(Return.Value(new List<ShiftGapReasonReportDTO>()));

            List<ShiftPattern> shiftPatterns = new List<ShiftPattern>
                                                             {
                                                                 shiftPattern1,
                                                                 shiftPattern2
                                                             };

            reportingService.GetShiftGapReasonReportData(shiftPatterns,
                                                         new RootFlocSet(new List<FunctionalLocation>()),
                                                         new Date(2006, 8, 3),
                                                         new Date(2006, 8, 4));
            
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        private static LogReportDTO CreateLogReportDto()
        {
            return new LogReportDTO(-1, -99, string.Empty, new DateTime(), string.Empty, string.Empty, 
                string.Empty, string.Empty, string.Empty, new DateTime(), 
                "",
                "");
        }

        [Ignore] [Test]
        public void ShouldGenerateMarkedAsReadReport_StandardLog()
        {
            {
                const string logType = MarkedAsReadReportLogDTO.STANDARD_LOG_TYPE_TEXT;

                List<MarkedAsReadReportLogDTO> logDtos = new List<MarkedAsReadReportLogDTO>
                                                             {
                                                                 CreateMarkedAsReadLogDTO(logType, "floc1", "readuserA",
                                                                                          "readuserB"),
                                                                 CreateMarkedAsReadLogDTO(logType, "floc2"),
                                                                 CreateMarkedAsReadLogDTO(logType, "floc3"),
                                                                 CreateMarkedAsReadLogDTO(logType, "floc4", "readuserA",
                                                                                          "readuserC"),
                                                                 CreateMarkedAsReadLogDTO(
                                                                     MarkedAsReadReportLogDTO.
                                                                         DAILY_DIRECTIVE_LOG_TYPE_TEXT, "floc5",
                                                                     "readuserA", "readuserB")
                                                             };

                Stub.On(mockLogDTODao).Method("QueryDTOByParentFlocListAndMarkedAsRead").Will(Return.Value(logDtos));
            }
            {
                List<MarkedAsReadReportLogDTO> summaryLogDtos = new List<MarkedAsReadReportLogDTO>
                                                                    {
                                                                        CreateMarkedAsReadLogDTO(
                                                                            MarkedAsReadReportLogDTO.
                                                                                SUMMARY_LOG_TYPE_TEXT, "floc6",
                                                                            "readuserA", "readuserD"),
                                                                        CreateMarkedAsReadLogDTO(
                                                                            MarkedAsReadReportLogDTO.
                                                                                SUMMARY_LOG_TYPE_TEXT, "floc7"),
                                                                        CreateMarkedAsReadLogDTO(
                                                                            MarkedAsReadReportLogDTO.
                                                                                SUMMARY_LOG_TYPE_TEXT, "floc8",
                                                                            "readuserD")
                                                                    };


                Stub.On(mockSummaryLogDTODao).Method("QueryDTOByParentFlocListAndMarkedAsRead").Will(Return.Value(summaryLogDtos));
            }
            {
                List<MarkedAsReadReportShiftHandoverQuestionnaireDTO> dtoList = 
                    new List<MarkedAsReadReportShiftHandoverQuestionnaireDTO>
                                                                                    {
                                                                                        CreateShiftHandoverQuestionnaireDTO
                                                                                            ("floc9", "readuserA",
                                                                                             "readuserD"),
                                                                                        CreateShiftHandoverQuestionnaireDTO
                                                                                            ("floc10"),
                                                                                        CreateShiftHandoverQuestionnaireDTO
                                                                                            ("floc11", "readuserD")
                                                                                    };
                Stub.On(mockQuestionnaireDTODao).Method("QueryByParentFlocListAndMarkedAsRead").Will(Return.Value(dtoList));
            }
            {
                List<MarkedAsReadReportDirectiveDTO> dtoList = new List<MarkedAsReadReportDirectiveDTO> { CreateDirectiveDTO("floc12", "readuserA") };
                Stub.On(mockDirectiveDtoDao).Method("QueryByParentFlocListAndMarkedAsRead").Will(Return.Value(dtoList));
            }

            MarkedAsReadReportDTO reportDto = reportingService.GetMarkedAsReadReportData(
                SiteFixture.Sarnia(), new Date(2010, 1, 1), new Date(2010, 1, 2), new RootFlocSet(new List<FunctionalLocation>()),
                true, true, true, true, true,true);
            Assert.AreEqual(4, reportDto.Logs.Count);
            Assert.AreEqual(1, reportDto.DirectiveLogs.Count);
            Assert.AreEqual(3, reportDto.SummaryLogs.Count);
            Assert.AreEqual(3, reportDto.ShiftHandoverQuestionnaires.Count);
            Assert.AreEqual(1, reportDto.Directives.Count);
        }

        [Ignore] [Test]
        public void ShouldRemoveShiftHandoversCreatedOutsideOfTheStartAndEndShifts()
        {
            UserShift startUserShift = UserShiftFixture.CreateUserShift(new Time(9), new Time(12), new DateTime(2010, 12, 2));
            UserShift overlappingShiftA = UserShiftFixture.CreateUserShift(new Time(8), new Time(14), new DateTime(2010, 12, 2));
            UserShift overlappingShiftB = UserShiftFixture.CreateUserShift(new Time(12), new Time(14), new DateTime(2010, 12, 2));                                                                                 
            UserShift endUserShift = UserShiftFixture.CreateUserShift(new Time(11), new Time(13), new DateTime(2010, 12, 2));

            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS() };

            ShiftHandoverQuestionnaire q1 = CreateQuestionnaire(1, new DateTime(2010, 12, 2, 9, 10, 0), startUserShift.ShiftPattern);
            ShiftHandoverQuestionnaire q2 = CreateQuestionnaire(2, new DateTime(2010, 12, 2, 9, 10, 0), overlappingShiftA.ShiftPattern);
            ShiftHandoverQuestionnaire q3 = CreateQuestionnaire(3, new DateTime(2010, 12, 2, 12, 40, 0), overlappingShiftB.ShiftPattern);
            ShiftHandoverQuestionnaire q4 = CreateQuestionnaire(4, new DateTime(2010, 12, 2, 12, 40, 0), endUserShift.ShiftPattern);
            List<ShiftHandoverQuestionnaire> questionnaires = new List<ShiftHandoverQuestionnaire> { q1, q2, q3, q4 };

            Expect.Once.On(mockQuestionnaireDao).Method("QueryByFunctionalLocationAndDateRangeAndAssignment").Will(Return.Value(questionnaires));
            List<ShiftHandoverQuestionnaire> filteredQuestionnaires = reportingService.GetDailyShiftHandoverReportData(
                startUserShift, endUserShift, new RootFlocSet(flocs), new List<WorkAssignment>(), false,false);
            mockery.VerifyAllExpectationsHaveBeenMet();

            Assert.AreEqual(2, filteredQuestionnaires.Count);
            Assert.IsTrue(filteredQuestionnaires.ExistsById(q1));
            Assert.IsTrue(filteredQuestionnaires.ExistsById(q4));
        }

        private CustomFieldTrendReportDTO CreateCustomFieldTrendReportDTO(long id, DateTime logDateTime)
        {
            CustomField customField = CustomFieldFixture.CustomFieldExistingInDatabase1();
            CustomFieldEntry entry = new CustomFieldEntry(customField);
            entry.SetValue("val");

            return new CustomFieldTrendReportDTO(id, CustomFieldTrendReportDTO.LogType.Standard, "a", logDateTime, "D", new Date(2013, 5, 28), string.Empty, new List<CustomFieldEntry> { entry }, "wa", new List<CustomField>());
        }

        [Ignore] [Test]
        public void ShouldSortCustomFieldTrendReportDataByLogDateTimeWithinTheLogTypeGroups()
        {
            UserShift startUserShift = UserShiftFixture.CreateUserShift(new Time(9), new Time(12), new DateTime(2010, 12, 2));
            UserShift endUserShift = UserShiftFixture.CreateUserShift(new Time(11), new Time(13), new DateTime(2010, 12, 2));

            List<CustomFieldTrendReportDTO> logDtos = new List<CustomFieldTrendReportDTO>
                {
                    CreateCustomFieldTrendReportDTO(1, new DateTime(2013, 9, 25, 17, 0, 0)),
                    CreateCustomFieldTrendReportDTO(2, new DateTime(2013, 9, 25, 15, 0, 0))
                };
            List<CustomFieldTrendReportDTO> summaryLogDtos = new List<CustomFieldTrendReportDTO>
                {
                    CreateCustomFieldTrendReportDTO(3, new DateTime(2013, 9, 25, 18, 0, 0)),
                    CreateCustomFieldTrendReportDTO(4, new DateTime(2013, 9, 25, 16, 0, 0))
                };

            Expect.Once.On(mockCustomFieldTrendReportDTODao).Method("QueryCustomFieldTrendReportDataForLogs").WithAnyArguments().Will(Return.Value(logDtos));
            Expect.Once.On(mockCustomFieldTrendReportDTODao).Method("QueryCustomFieldTrendReportDataForSummaryLogs").WithAnyArguments().Will(Return.Value(summaryLogDtos));

            List<CustomFieldTrendReportDTO> results = reportingService.GetCustomFieldTrendReportData(null, startUserShift, endUserShift, null, false, true, false, true);
            mockery.VerifyAllExpectationsHaveBeenMet();

            Assert.AreEqual(4, results.Count);
            Assert.AreEqual(2, results[0].IdValue);
            Assert.AreEqual(1, results[1].IdValue);
            Assert.AreEqual(4, results[2].IdValue);
            Assert.AreEqual(3, results[3].IdValue);
        }

        private static MarkedAsReadReportLogDTO CreateMarkedAsReadLogDTO(string logType, string floc, params string[] readusers)
        {
            List<ItemReadBy> items = readusers.ConvertAll(u => new ItemReadBy(u, Clock.Now));
            return new MarkedAsReadReportLogDTO(
                logType, new DateTime(), null, floc, null, "", items);
        }

        private static MarkedAsReadReportShiftHandoverQuestionnaireDTO CreateShiftHandoverQuestionnaireDTO(string floc, params string[] readusers)
        {
            List<ItemReadBy> reads = readusers.ConvertAll(u => new ItemReadBy(u, Clock.Now));
            return new MarkedAsReadReportShiftHandoverQuestionnaireDTO(
                "daily handover", new DateTime(), null, null, null, floc, reads);
        }

        private static MarkedAsReadReportDirectiveDTO CreateDirectiveDTO(string floc, params string[] readusers)
        {
            List<ItemReadBy> reads = readusers.ConvertAll(u => new ItemReadBy(u, Clock.Now));
            return new MarkedAsReadReportDirectiveDTO(new DateTime(), new DateTime(), new List<string> { floc }, new List<string> { "wa1" }, "lastmodby", "content", reads);
        }

        private ShiftHandoverQuestionnaire CreateQuestionnaire(long id, DateTime createdDateTime, ShiftPattern shiftPattern)
        {
            return new ShiftHandoverQuestionnaire(
                id,
                "no way",
                shiftPattern,
                WorkAssignmentFixture.CreateUnitLeader(),
                UserFixture.CreateUserWithGivenId(1),
                createdDateTime,
                new List<FunctionalLocation>(),
                new List<ShiftHandoverAnswer>(),
                new List<long>(), DateTime.MinValue, DateTime.MinValue, true);    
        }
    }
}
