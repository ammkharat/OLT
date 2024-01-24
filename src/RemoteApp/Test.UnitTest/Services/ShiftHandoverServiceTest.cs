using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class ShiftHandoverServiceTest
    {
        private IShiftHandoverService shiftHandoverService;
        private IShiftHandoverQuestionnaireAssociationDao mockShiftHandoverQuestionnaireAssociationDao;
        private IShiftHandoverQuestionnaireDTODao mockShiftHandoverQuestionnaireDtoDao;
        private ITimeService mockTimeService;
        private Mockery mocks;
        private IShiftHandoverQuestionnaireDao mockShiftHandoverQuestionnaireDao;
        private IQuestionnaireReadDao mockQuestionnaireReadDao;
        private IShiftHandoverEmailConfigurationDao mockEmailConfigurationDao;
        private ILogDTODao mockLogDtoDao;
        private ISummaryLogDao mockSummaryLogDao;
        private ICokerCardDao mockCokerCards;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockShiftHandoverQuestionnaireDtoDao = mocks.NewMock<IShiftHandoverQuestionnaireDTODao>();
            mockShiftHandoverQuestionnaireAssociationDao = mocks.NewMock<IShiftHandoverQuestionnaireAssociationDao>();
            mockShiftHandoverQuestionnaireDao = mocks.NewMock<IShiftHandoverQuestionnaireDao>();
            mockQuestionnaireReadDao = mocks.NewMock<IQuestionnaireReadDao>();
            mockEmailConfigurationDao = mocks.NewMock<IShiftHandoverEmailConfigurationDao>();
            mockTimeService = mocks.NewMock<ITimeService>();
            mockLogDtoDao = mocks.NewMock<ILogDTODao>();
            mockSummaryLogDao = mocks.NewMock<ISummaryLogDao>();
            mockCokerCards = mocks.NewMock<ICokerCardDao>();
            
            shiftHandoverService = new ShiftHandoverService(
                mockShiftHandoverQuestionnaireDao,
                mockShiftHandoverQuestionnaireAssociationDao,
                mockShiftHandoverQuestionnaireDtoDao,
                mocks.NewMock<IShiftHandoverConfigurationDao>(),
                mocks.NewMock<IShiftHandoverConfigurationDTODao>(),
                mocks.NewMock<IShiftHandoverQuestionDao>(),
                mockTimeService,
                mocks.NewMock<IEditHistoryService>(),
                mockQuestionnaireReadDao,
                mocks.NewMock<ISiteConfigurationDao>(),
                mockEmailConfigurationDao,
                mockLogDtoDao, mockSummaryLogDao, mockCokerCards);
        }

        [TearDown]
        public void TearDown()
        {
            mocks.VerifyAllExpectationsHaveBeenMet();
            DaoRegistry.Clear();          
        }

        [Ignore] [Test]
        public void QueryByPriorityShouldNotIncludeDTOsCreatedByGivenUser()
        {
            Site site = SiteFixture.Oilsands();
            DateTime now = new DateTime(2010, 1, 3, 21, 0, 0);
            DateTime questionnaireCreatedDateTime = now;
            DateTime dayAndTimeAfterQuestionnaireCreated = now.AddDays(1);
            Date dayAfterQuestionnaireCreated = now.AddDays(1).ToDate();
            
            Stub.On(mockTimeService).Method("GetDate").WithAnyArguments().Will(Return.Value(dayAfterQuestionnaireCreated));
            UserShift userShift = new UserShift(ShiftPatternFixture.CreateNightShift(), dayAndTimeAfterQuestionnaireCreated);

            User questionnaireUserA = UserFixture.CreateOperator(1, "Sweet B.A.by Jay");
            User questionnaireUserB = UserFixture.CreateOperator(2, "Jimmy B.A.");
            ShiftHandoverQuestionnaire shiftHandoverQuestionnaireA = ShiftHandoverQuestionnaireFixture.Create(1, null, questionnaireUserA, ShiftPatternFixture.CreateNightShift(), questionnaireCreatedDateTime, new List<FunctionalLocation>());
            ShiftHandoverQuestionnaire shiftHandoverQuestionnaireB = ShiftHandoverQuestionnaireFixture.Create(2, null, questionnaireUserA, ShiftPatternFixture.CreateNightShift(), questionnaireCreatedDateTime, new List<FunctionalLocation>());
            ShiftHandoverQuestionnaire shiftHandoverQuestionnaireC = ShiftHandoverQuestionnaireFixture.Create(3, null, questionnaireUserB, ShiftPatternFixture.CreateNightShift(), questionnaireCreatedDateTime, new List<FunctionalLocation>());
            List<ShiftHandoverQuestionnaire> questionnaires = new List<ShiftHandoverQuestionnaire> { shiftHandoverQuestionnaireA, shiftHandoverQuestionnaireB, shiftHandoverQuestionnaireC };

            // case 1: querying with user B should only return user A's questionnaires
            List<ShiftHandoverQuestionnaireDTO> dtos = questionnaires.ConvertAll(questionnaire => new ShiftHandoverQuestionnaireDTO(questionnaire));
            Expect.Once.On(mockShiftHandoverQuestionnaireDtoDao).Method("QueryByFunctionalLocationAndAssignment").WithAnyArguments().Will(Return.Value(dtos));

            List<ShiftHandoverQuestionnaireDTO> resultingDTOs = shiftHandoverService.QueryPriorityDTOs(null, null, questionnaireUserB.Id, userShift, null);
            Assert.AreEqual(2, resultingDTOs.Count);
            Assert.IsTrue(resultingDTOs.TrueForAll(dto => dto.CreateUserId.Equals(questionnaireUserA.Id)));
            
            // case 2: querying with user A should only return user B's questionnaires
            dtos = questionnaires.ConvertAll(questionnaire => new ShiftHandoverQuestionnaireDTO(questionnaire));
            Expect.Once.On(mockShiftHandoverQuestionnaireDtoDao).Method("QueryByFunctionalLocationAndAssignment").WithAnyArguments().Will(Return.Value(dtos));

            resultingDTOs = shiftHandoverService.QueryPriorityDTOs(null, null, questionnaireUserA.Id, userShift, null);
            Assert.AreEqual(1, resultingDTOs.Count);
            Assert.IsTrue(resultingDTOs.TrueForAll(dto => dto.CreateUserId.Equals(questionnaireUserB.Id)));
        }

        [Ignore] [Test]
        public void QueryByPriorityShouldNotIncludeDTOsCreatedInGivenUserShift()
        {
            Site site = SiteFixture.Oilsands();
            ShiftPattern nightShiftPattern = ShiftPatternFixture.CreateNightShift();
            User questionnaireUser = UserFixture.CreateOperator(1, "Sweet B.A.by Jay");
            User nonQuestionnaireUser = UserFixture.CreateOperator(2, "Jimmy B.A.");

            Date createdAtDateForFirstTwoQuestionnaires = new Date(2009, 12, 2);
            Date createdAtDateForLastQuestionnaire = createdAtDateForFirstTwoQuestionnaires.AddDays(1);
            Stub.On(mockTimeService).Method("GetDate").WithAnyArguments().Will(Return.Value(createdAtDateForLastQuestionnaire));

            DateTime createdAtDateTimeForFirstTwoQuestionnaires = new DateTime(2009, 12, 2, 21, 0, 0);
            DateTime createdAtDateTimeForLastQuestionnaire = createdAtDateTimeForFirstTwoQuestionnaires.AddDays(1);

            ShiftHandoverQuestionnaire shiftHandoverQuestionnaireA = ShiftHandoverQuestionnaireFixture.Create(1, null, questionnaireUser, nightShiftPattern, createdAtDateTimeForFirstTwoQuestionnaires, new List<FunctionalLocation>());
            ShiftHandoverQuestionnaire shiftHandoverQuestionnaireB = ShiftHandoverQuestionnaireFixture.Create(2, null, questionnaireUser, nightShiftPattern, createdAtDateTimeForFirstTwoQuestionnaires, new List<FunctionalLocation>());
            ShiftHandoverQuestionnaire shiftHandoverQuestionnaireC = ShiftHandoverQuestionnaireFixture.Create(3, null, questionnaireUser, nightShiftPattern, createdAtDateTimeForLastQuestionnaire, new List<FunctionalLocation>());
            List<ShiftHandoverQuestionnaire> questionnaires = new List<ShiftHandoverQuestionnaire> { shiftHandoverQuestionnaireA, shiftHandoverQuestionnaireB, shiftHandoverQuestionnaireC };

            // case 1: current user shift is when shiftHandoverQuestionnaireC was created, so the other two questionnaires should be returned
            List<ShiftHandoverQuestionnaireDTO> dtos = questionnaires.ConvertAll(questionnaire => new ShiftHandoverQuestionnaireDTO(questionnaire));
            Expect.Once.On(mockShiftHandoverQuestionnaireDtoDao).Method("QueryByFunctionalLocationAndAssignment").WithAnyArguments().Will(Return.Value(dtos));

            UserShift currentUserShift = new UserShift(nightShiftPattern, createdAtDateTimeForLastQuestionnaire);
            List<ShiftHandoverQuestionnaireDTO> resultingDTOs = shiftHandoverService.QueryPriorityDTOs(null, null, nonQuestionnaireUser.Id, currentUserShift, null);
            Assert.AreEqual(2, resultingDTOs.Count);
            Assert.IsTrue(resultingDTOs.TrueForAll(dto => dto.Id == shiftHandoverQuestionnaireA.Id || dto.Id == shiftHandoverQuestionnaireB.Id));

            // case 2: current user shift is when questionnaires A and B were created, so only shiftHandoverQuestionnaireC should be returned
            dtos = questionnaires.ConvertAll(questionnaire => new ShiftHandoverQuestionnaireDTO(questionnaire));
            Expect.Once.On(mockShiftHandoverQuestionnaireDtoDao).Method("QueryByFunctionalLocationAndAssignment").WithAnyArguments().Will(Return.Value(dtos));

            currentUserShift = new UserShift(nightShiftPattern, createdAtDateTimeForFirstTwoQuestionnaires);
            resultingDTOs = shiftHandoverService.QueryPriorityDTOs(null, null, nonQuestionnaireUser.Id, currentUserShift, null);
            Assert.AreEqual(1, resultingDTOs.Count);
            Assert.IsTrue(resultingDTOs.TrueForAll(dto => dto.Id == shiftHandoverQuestionnaireC.Id));
        }

        [Ignore] [Test]
        public void MarkAsReadShouldNotMarkAsReadIfTheHandoverDoesNotExist()
        {
            User user = UserFixture.CreateOperator(1, "Jimmy Dev");
            ShiftHandoverQuestionnaire handover = ShiftHandoverQuestionnaireFixture.Create();
            handover.Id = 5;

            Expect.Once.On(mockShiftHandoverQuestionnaireDao).Method("QueryById").WithAnyArguments().Will(Return.Value(null));
            Expect.Never.On(mockQuestionnaireReadDao).Method("Insert");
            bool markAsReadWasSuccessful = shiftHandoverService.MarkAsRead(handover.IdValue, user.IdValue, DateTime.Now);

            Assert.IsFalse(markAsReadWasSuccessful);
        }

        [Ignore] [Test]
        public void MarkAsReadShouldMarkAsReadIfTheHandoverExists()
        {
            User user = UserFixture.CreateOperator(1, "Jimmy Dev");
            ShiftHandoverQuestionnaire handover = ShiftHandoverQuestionnaireFixture.Create();
            handover.Id = 5;

            Expect.Once.On(mockShiftHandoverQuestionnaireDao).Method("QueryById").WithAnyArguments().Will(Return.Value(handover));
            Expect.Once.On(mockQuestionnaireReadDao).Method("UserMarkedAsRead").Will(Return.Value(null));
            Expect.Once.On(mockQuestionnaireReadDao).Method("Insert");
            bool markAsReadWasSuccessful = shiftHandoverService.MarkAsRead(handover.IdValue, user.IdValue, DateTime.Now);

            Assert.IsTrue(markAsReadWasSuccessful);
        }
    }
}
