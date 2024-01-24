using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class EditHistoryServiceTest
    {
        private IEditHistoryService editHistoryService;
        private ILabAlertDefinitionHistoryDao labAlertDefinitionHistoryDao;
        private IActionItemDefinitionHistoryDao mockActionItemDefinitionHistoryDao;
        private ICokerCardConfigurationDao mockCokerCardConfigurationDao;
        private ICokerCardHistoryDao mockCokerCardHistoryDao;
        private IConfinedSpaceHistoryDao mockConfinedSpaceHistoryDao;
        private ICustomFieldDao mockCustomFieldDao;
        private IDeviationAlertResponseHistoryDao mockDeviationAlertResponseHistoryDao;
        private IDirectiveHistoryDao mockDirectiveHistoryDao;
        private IExcursionResponseHistoryDao mockExcursionResponseHistoryDao;
        private IFunctionalLocationOperationalModeHistoryDao mockFLOCOpModeHistoryDao;
        private IFormGN1HistoryDao mockFormGN1HistoryDao;
        private IFormGN24HistoryDao mockFormGN24HistoryDao;
        private IFormGN59HistoryDao mockFormGN59HistoryDao;
        private IFormGN6HistoryDao mockFormGN6HistoryDao;
        private IFormGN75AHistoryDao mockFormGN75AHistoryDao;
        private IFormGN75BHistoryDao mockFormGN75BHistoryDao;
        private IFormGN7HistoryDao mockFormGN7HistoryDao;
        private IFormOP14HistoryDao mockFormOP14HistoryDao;
        private IFormGenericTemplateHistoryDao mockFormGenericTemplateHistoryDao; //generic template - mangesh
        private IFormOilsandsTrainingHistoryDao mockFormOilsandsTrainingHistoryDao;
        private IFormOvertimeFormHistoryDao mockFormOvertimeFormHistoryDao;
        private IGasTestElementInfoConfigurationHistoryDao mockGasTestElementInfoConfigurationHistoryDao;
        private ILogDefinitionHistoryDao mockLogDefinitionHistoryDao;
        private ILogHistoryDao mockLogHistoryDao;
        private ILubesAlarmDisableHistoryDao mockLubesAlarmDisableHistoryDao;
        private IFormLubesCsdHistoryDao mockLubesCsdFormHistoryDao;
        private IMontrealCsdHistoryDao mockMontrealCsdHistoryDao;
        private IOpmToeDefinitionCommentHistoryDao mockOpmToeDefinitionCommentHistoryDao;
        private IPermitAssessmentHistoryDao mockPermitAssessmentHistoryDao;
        private IPermitRequestEdmontonHistoryDao mockPermitRequestEdmontonHistoryDao;
        private IPermitRequestMontrealHistoryDao mockPermitRequestHistoryDao;
        private IPermitRequestLubesHistoryDao mockPermitRequestLubesHistoryDao;
        private IRestrictionDefinitionHistoryDao mockRestrictionDefinitionHistoryDao;
        private ISummaryLogHistoryDao mockSummaryLogHistoryDao;
        private ITargetDefinitionHistoryDao mockTargetDefinitionHistoryDao;
        private ITradeChecklistHistoryDao mockTradeChecklistHistoryDao;
        private IWorkPermitEdmontonHistoryDao mockWorkPermitEdmontonHistoryDao;
        private IWorkPermitHistoryDao mockWorkPermitHistoryDao;
        private IWorkPermitLubesHistoryDao mockWorkPermitLubesHistoryDao;
        private IWorkPermitMontrealHistoryDao mockWorkPermitMontrealHistoryDao;
        private IShiftHandoverQuestionnaireHistoryDao questionnaireHistoryDao;
        private IDocumentSuggestionHistoryDao documentSuggestionHistoryDao;
        private IProcedureDeviationHistoryDao procedureDeviationHistoryDao;
        private ITemporaryInstallationsMudsHistoryDao mocktemporaryInstallationsHistoryDao; //RITM0268131 - mangesh
        private IWorkPermitMudsHistoryDao mockWorkPermitMudsHistoryDao; //RITM0301321 mangesh
        private IConfinedSpaceMudsHistoryDao mockConfinedSpaceMudsHistoryDao; //RITM0301321 mangesh
        private IPermitRequestMudsHistoryDao mockPermitRequestMudsHistoryDao; //RITM0301321 mangesh
        private IPermitRequestFortHillsHistoryDao mockPermitRequestFortHillsHistoryDao;
        private IWorkPermitFortHillsHistoryDao mockWorkPermitFortHillsHistoryDao;
 
 private Mockery mocks;
        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockActionItemDefinitionHistoryDao = mocks.NewMock<IActionItemDefinitionHistoryDao>();
            mockLogHistoryDao = mocks.NewMock<ILogHistoryDao>();
            mockSummaryLogHistoryDao = mocks.NewMock<ISummaryLogHistoryDao>();
            mockWorkPermitHistoryDao = mocks.NewMock<IWorkPermitHistoryDao>();
            mockWorkPermitMontrealHistoryDao = mocks.NewMock<IWorkPermitMontrealHistoryDao>();
            mockTargetDefinitionHistoryDao = mocks.NewMock<ITargetDefinitionHistoryDao>();
            mockRestrictionDefinitionHistoryDao = mocks.NewMock<IRestrictionDefinitionHistoryDao>();
            mockDeviationAlertResponseHistoryDao = mocks.NewMock<IDeviationAlertResponseHistoryDao>();
            mockLogDefinitionHistoryDao = mocks.NewMock<ILogDefinitionHistoryDao>();
            mockGasTestElementInfoConfigurationHistoryDao = mocks.NewMock<IGasTestElementInfoConfigurationHistoryDao>();
            mockFLOCOpModeHistoryDao = mocks.NewMock<IFunctionalLocationOperationalModeHistoryDao>();
            questionnaireHistoryDao = mocks.NewMock<IShiftHandoverQuestionnaireHistoryDao>();
            labAlertDefinitionHistoryDao = mocks.NewMock<ILabAlertDefinitionHistoryDao>();
            mockCokerCardHistoryDao = mocks.NewMock<ICokerCardHistoryDao>();
            mockCokerCardConfigurationDao = mocks.NewMock<ICokerCardConfigurationDao>();
            mockPermitRequestHistoryDao = mocks.NewMock<IPermitRequestMontrealHistoryDao>();
            mockConfinedSpaceHistoryDao = mocks.NewMock<IConfinedSpaceHistoryDao>();
            mockWorkPermitEdmontonHistoryDao = mocks.NewMock<IWorkPermitEdmontonHistoryDao>();
            mockPermitRequestEdmontonHistoryDao = mocks.NewMock<IPermitRequestEdmontonHistoryDao>();
            mockFormOvertimeFormHistoryDao = mocks.NewMock<IFormOvertimeFormHistoryDao>();
            mockFormGN7HistoryDao = mocks.NewMock<IFormGN7HistoryDao>();
            mockFormGN59HistoryDao = mocks.NewMock<IFormGN59HistoryDao>();
            mockFormOP14HistoryDao = mocks.NewMock<IFormOP14HistoryDao>();
            mockFormGenericTemplateHistoryDao = mocks.NewMock<IFormGenericTemplateHistoryDao>(); // generic template - mangesh
            mockFormGN24HistoryDao = mocks.NewMock<IFormGN24HistoryDao>();
            mockFormGN6HistoryDao = mocks.NewMock<IFormGN6HistoryDao>();
            mockFormGN75AHistoryDao = mocks.NewMock<IFormGN75AHistoryDao>();
            mockFormGN75BHistoryDao = mocks.NewMock<IFormGN75BHistoryDao>();
            mockFormGN1HistoryDao = mocks.NewMock<IFormGN1HistoryDao>();
            mockTradeChecklistHistoryDao = mocks.NewMock<ITradeChecklistHistoryDao>();
            mockFormOilsandsTrainingHistoryDao = mocks.NewMock<IFormOilsandsTrainingHistoryDao>();
            mockCustomFieldDao = mocks.NewMock<ICustomFieldDao>();
            mockWorkPermitLubesHistoryDao = mocks.NewMock<IWorkPermitLubesHistoryDao>();
            mockPermitRequestLubesHistoryDao = mocks.NewMock<IPermitRequestLubesHistoryDao>();
            mockDirectiveHistoryDao = mocks.NewMock<IDirectiveHistoryDao>();
            mockLubesCsdFormHistoryDao = mocks.NewMock<IFormLubesCsdHistoryDao>();
            mockLubesAlarmDisableHistoryDao = mocks.NewMock<ILubesAlarmDisableHistoryDao>();
            mockMontrealCsdHistoryDao = mocks.NewMock<IMontrealCsdHistoryDao>();
            mockExcursionResponseHistoryDao = mocks.NewMock<IExcursionResponseHistoryDao>();
            mockOpmToeDefinitionCommentHistoryDao = mocks.NewMock<IOpmToeDefinitionCommentHistoryDao>();
            mockPermitAssessmentHistoryDao = mocks.NewMock<IPermitAssessmentHistoryDao>();
            documentSuggestionHistoryDao = mocks.NewMock<IDocumentSuggestionHistoryDao>();
            procedureDeviationHistoryDao = mocks.NewMock<IProcedureDeviationHistoryDao>();
            mocktemporaryInstallationsHistoryDao = mocks.NewMock<ITemporaryInstallationsMudsHistoryDao>(); //RITM0268131 - mangesh
            mockWorkPermitMudsHistoryDao = mocks.NewMock<IWorkPermitMudsHistoryDao>(); //RITM0301321 mangesh
            mockConfinedSpaceMudsHistoryDao = mocks.NewMock<IConfinedSpaceMudsHistoryDao>();  //RITM0301321 mangesh
            mockPermitRequestMudsHistoryDao = mocks.NewMock<IPermitRequestMudsHistoryDao>();
            mockPermitRequestFortHillsHistoryDao = mocks.NewMock<IPermitRequestFortHillsHistoryDao>();
            mockWorkPermitFortHillsHistoryDao = mocks.NewMock<IWorkPermitFortHillsHistoryDao>();

            editHistoryService = new EditHistoryService(mockActionItemDefinitionHistoryDao,
                mockLogHistoryDao,
                mockSummaryLogHistoryDao,
                mockWorkPermitHistoryDao,
                mockWorkPermitMontrealHistoryDao,
                mockTargetDefinitionHistoryDao,
                mockRestrictionDefinitionHistoryDao,
                mockDeviationAlertResponseHistoryDao,
                mockLogDefinitionHistoryDao,
                mockGasTestElementInfoConfigurationHistoryDao,
                mockFLOCOpModeHistoryDao,
                questionnaireHistoryDao,
                labAlertDefinitionHistoryDao,
                mockCokerCardHistoryDao,
                mockCokerCardConfigurationDao,
                mockPermitRequestHistoryDao,
                mockConfinedSpaceHistoryDao,
                mockWorkPermitEdmontonHistoryDao,
                mockPermitRequestEdmontonHistoryDao,
                mockFormOvertimeFormHistoryDao,
                mockFormGN7HistoryDao,
                mockFormGN59HistoryDao,
                mockFormOP14HistoryDao,
                mockFormGenericTemplateHistoryDao, // generic template - mangesh
                mockFormGN24HistoryDao,
                mockFormGN6HistoryDao,
                mockFormGN75AHistoryDao,
                mockFormGN75BHistoryDao,
                mockFormGN1HistoryDao,
                mockTradeChecklistHistoryDao,
                mockFormOilsandsTrainingHistoryDao,
                mockCustomFieldDao,
                mockWorkPermitLubesHistoryDao,
                mockPermitRequestLubesHistoryDao,
                mockDirectiveHistoryDao,
                mockLubesCsdFormHistoryDao,
                mockLubesAlarmDisableHistoryDao,
                mockMontrealCsdHistoryDao, 
                mockExcursionResponseHistoryDao, 
                mockOpmToeDefinitionCommentHistoryDao,
                mockPermitAssessmentHistoryDao,
                documentSuggestionHistoryDao,
                procedureDeviationHistoryDao,
                mocktemporaryInstallationsHistoryDao,mockPermitRequestFortHillsHistoryDao,
                mockWorkPermitMudsHistoryDao, mockConfinedSpaceMudsHistoryDao, mockPermitRequestMudsHistoryDao, mockWorkPermitFortHillsHistoryDao); //RITM0301321 mangesh
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Ignore] [Test]
        public void ShouldLoadMostRecentGasTestElementInfoConfigurationHistoryChangeSets()
        {
            var dto = GasTestElementInfoFixture.SarniaStandardDTOs;

            var user1 = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            var dateTime1 = new DateTime(2006, 02, 02);
            var snapshots =
                new List<GasTestElementInfoConfigurationHistory>();
            CreateGasTestElementInfoConfigurationHistoryList(dateTime1, dto, snapshots, user1);

            var user2 = UserFixture.CreateOperatorMickeyInFortMcMurrySite();
            var dateTime2 = new DateTime(2005, 01, 01);
            CreateGasTestElementInfoConfigurationHistoryList(dateTime2, dto, snapshots, user2);

            var site = SiteFixture.Sarnia();

            Expect.Once.On(mockGasTestElementInfoConfigurationHistoryDao).Method("QueryAllBySiteId").With(site.IdValue)
                .Will(Return.Value(snapshots));
            var changeSets = editHistoryService.GetEditHistory(site);
            Assert.AreEqual(2, changeSets.Count);
            Assert.AreEqual(0, changeSets[0].PropertyChanges.Count);
            Assert.AreEqual(0, changeSets[1].PropertyChanges.Count);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldLoadMostRecentLogChangeSetsWhenNumberOfChangeSetsAvailableAreGreaterThanMax()
        {
            ShouldLoadMostRecentLogChangeSets(6, 5);
        }

        [Ignore] [Test]
        public void ShouldLoadMostRecentLogChangeSetsWhenNumberOfChangeSetsAvailableAreLessThanMax()
        {
            ShouldLoadMostRecentLogChangeSets(3, 3);
        }

        [Ignore] [Test]
        public void TakeFLOCOpModeSnapShotShouldInsertASnapShotOfProvidedFLOCOpMode()
        {
            var lastModifiedUser = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            var lastModifiedDate = new DateTime(2001, 1, 2);
            var flocOpModeDTO =
                FunctionalLocationOperationalModeDTOFixture.MakeConstrainedOpModeDto();
            var flocOpMode =
                new FunctionalLocationOperationalMode(flocOpModeDTO.IdValue, flocOpModeDTO.OperationalMode,
                    flocOpModeDTO.AvailabilityReason, lastModifiedDate);

            var expected =
                new FunctionalLocationOperationalModeHistory(flocOpModeDTO.FunctionalLocationId,
                    flocOpModeDTO.OperationalMode,
                    flocOpModeDTO.AvailabilityReason,
                    lastModifiedDate,
                    lastModifiedUser);
            Expect.Once.On(mockFLOCOpModeHistoryDao).Method("Insert").With(expected);
            editHistoryService.TakeSnapshot(flocOpMode, lastModifiedUser);
        }

        [Ignore] [Test]
        public void TakeGasTestElementInfoSnapshotShouldInsertASnapshotOfTheProvidedGasTestElementInfo()
        {
            var now = DateTimeFixture.DateTimeNow;
            var user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            var site = SiteFixture.Sarnia();

            var gasTestElementInfoDTOList =
                SetExpectationsForTakeSnapshot(now, user, site.IdValue);

            editHistoryService.TakeSnapshot(gasTestElementInfoDTOList, now, user, site.IdValue);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void TakeLogDefinitionSnapshotShouldInsertASnapshotOfTheProvidedLogDefinition()
        {
            var logDefinition = LogDefinitionFixture.CreateLogDefinition();
            logDefinition.Id = 1234;
            var logDefinitionSnapshot = logDefinition.TakeSnapshot(new List<CustomField>());
            Stub.On(mockCustomFieldDao)
                .Method("QueryByCustomFieldGroupsForLogDefinitions")
                .Will(Return.Value(new List<CustomField>()));
            Expect.Once.On(mockLogDefinitionHistoryDao).Method("Insert").With(logDefinitionSnapshot);
            editHistoryService.TakeSnapshot(logDefinition);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void TakeLogSnapshotShouldInsertASnapshotOfTheProvidedLog()
        {
            var log = LogFixture.CreateLogItemGoofySarnia();
            log.Id = 1234;
            var logSnapshot = log.TakeSnapshot(new List<CustomField>());
            Expect.Once.On(mockLogHistoryDao).Method("Insert").With(logSnapshot);
            Stub.On(mockCustomFieldDao)
                .Method("QueryByCustomFieldGroupsForLogs")
                .Will(Return.Value(new List<CustomField>()));
            editHistoryService.TakeSnapshot(log);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void TakeTargetDefinitionSnapshotShouldInsertASnapshotOfTheProvidedTargetDefinition()
        {
            var targetDefinition =
                TargetDefinitionFixture.CreateATargetWithRecurringDailyScheduleAndActiveTargetFixture();
            var targetDefinitionSnapshot = targetDefinition.TakeSnapshot();
            Expect.Once.On(mockTargetDefinitionHistoryDao).Method("Insert").With(targetDefinitionSnapshot);
            editHistoryService.TakeSnapshot(targetDefinition);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void TheChangeSetsShouldBeReturnedInReverseChronologicalOrder()
        {
            var actionItemDefinition = ActionItemDefinitionFixture.CreateActionItemDefinition(1);
            var histories =
                ActionItemDefinitionHistoryFixture.CreateActionItemDefinitionHistories();
            Expect.Once.On(mockActionItemDefinitionHistoryDao)
                .Method("GetById")
                .With(actionItemDefinition.IdValue)
                .Will(
                    Return.Value(histories));
            var changeSets = editHistoryService.GetEditHistoryForActionItemDefinition(actionItemDefinition.IdValue);
            Assert.IsTrue(changeSets[0].ChangeDateTime > changeSets[1].ChangeDateTime);
            Assert.IsTrue(changeSets[1].ChangeDateTime > changeSets[2].ChangeDateTime);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private static void CreateGasTestElementInfoConfigurationHistoryList(DateTime dateTime,
            IEnumerable<GasTestElementInfoDTO> dto,
            ICollection<GasTestElementInfoConfigurationHistory> historyList, User user)
        {
            foreach (var infoDTO in dto)
            {
                historyList.Add(new GasTestElementInfoConfigurationHistory(infoDTO, dateTime, user));
            }
        }

        private List<GasTestElementInfoDTO> SetExpectationsForTakeSnapshot(DateTime now, User user, long siteId)
        {
            var gasTestElementInfoDTOList = GasTestElementInfoFixture.SarniaStandardDTOs;
            for (var i = 0; i < gasTestElementInfoDTOList.Count; i++)
            {
                Expect.Once.On(mockGasTestElementInfoConfigurationHistoryDao).Method("Insert").With(
                    gasTestElementInfoDTOList[i].TakeSnapshot(now, user), siteId);
            }
            return gasTestElementInfoDTOList;
        }

        private void ShouldLoadMostRecentLogChangeSets(int totalHistoryCount, int expectedRecentHistoryCount)
        {
            var now = DateTimeFixture.DateTimeNow;
            var log = LogFixture.CreateLogItem(now, now);
            var histories = CreateLogHistories(totalHistoryCount);
            Expect.Once.On(mockLogHistoryDao).Method("GetById").With(log.Id).Will(Return.Value(histories));
            var changeSets = editHistoryService.GetRecentEditHistoryForLog(log.IdValue);
            Assert.AreEqual(expectedRecentHistoryCount, changeSets.Count);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private static List<LogHistory> CreateLogHistories(int count)
        {
            return CreateHistoryObjects(count, LogHistoryFixture.CreateLogHistory);
        }

        private static List<T> CreateHistoryObjects<T>(int count, CreateHistoryObject<T> createHistoryObject)
        {
            var histories = new List<T>(count);

            for (var i = 0; i < count; i++)
            {
                histories.Add(createHistoryObject());
            }

            return histories;
        }

        private delegate T CreateHistoryObject<T>();
    }
}