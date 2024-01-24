using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.DTO;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class ConfigGasTestElementInfoFormPresenterTest
    {
        private const string SET_COLD_LIMIT_ERROR_MESSAGE = "SetColdLimitErrorMessage";
        private const string SET_HOT_LIMIT_ERROR_MESSAGE = "SetHotLimitErrorMessage";
        private const string SET_CSE_LIMIT_ERROR_MESSAGE = "SetCSELimitErrorMessage";
        private const string SET_INSERT_CSE_LIMIT_ERROR_MESSAGE = "SetInertCSELimitErrorMessage";
        private const string SET_UNIT_LIMIT_ERROR_MESSAGE = "SetUnitErrorMessage";

        private Mockery mocks;
        private IConfigGasTestElementInfoFormView mockView;
        private IGasTestElementInfoService mockGasTestElementInfoService;
        private IEditHistoryService mockEditHistoryService;
        private ConfigGasTestElementInfoFormPresenter presenter;
        private Site site;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
            mocks = new Mockery();
            mockView = mocks.NewMock<IConfigGasTestElementInfoFormView>();
            mockGasTestElementInfoService = mocks.NewMock<IGasTestElementInfoService>();
            mockEditHistoryService = mocks.NewMock<IEditHistoryService>();

            site = SiteFixture.Sarnia();
            presenter = new ConfigGasTestElementInfoFormPresenter(mockView, site, mockGasTestElementInfoService, mockEditHistoryService);
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldSetViewWithStandardInfosForSiteOnLoad()
        {

            Expect.Once.On(mockGasTestElementInfoService).Method("QueryStandardElementInfoDTOsBySiteId")
                .With(site.IdValue).Will(Return.Value(GasTestElementInfoFixture.SarniaStandardDTOs));
            Expect.Once.On(mockView).SetProperty("StandardGasTestElementInfoDTOList")
                .To(IsList.Equal(GasTestElementInfoFixture.SarniaStandardDTOs));
            Expect.Once.On(mockView).SetProperty("Site").To(SiteFixture.Sarnia());

            presenter.HandleFormLoad(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldGetStandardInfosFromViewAndUpdateToDatabaseOnSave()
        {
            ClientSession.GetUserContext().User = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            
            List<GasTestElementInfoDTO> dtos = GasTestElementInfoFixture.SarniaStandardDTOs;
            Expect.Once.On(mockView).GetProperty("StandardGasTestElementInfoDTOList").Will(Return.Value(dtos));
            Expect.Once.On(mockView).Method("ClearErrorMessage");
            Expect.Once.On(mockGasTestElementInfoService).Method("UpdateGasTestElementInfoDTOList").With(dtos);
            Expect.Once.On(mockEditHistoryService).Method("TakeSnapshot").With(dtos, Clock.Now, ClientSession.GetUserContext().User, site.IdValue);
            Expect.Once.On(mockView).Method("SaveSucceededMessage");
            Expect.Once.On(mockView).Method("Close");
            presenter.HandleSaveButtonClick(null, EventArgs.Empty);
            
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        #region DataValidation And OnSave

        private void ShouldValidateGasLimit(GasTestElementInfoDTO dtoToBeValidated, ICollection<string> expectedErrorMethodCallNameList)
        {
            List<GasTestElementInfoDTO> userDTO = GasTestElementInfoDTO.CreateDTOList(GasTestElementInfoFixture.SarniaStandardGasTestElementInfos);
            userDTO.Add(dtoToBeValidated);

            Expect.Once.On(mockView).Method("ClearErrorMessage");
            Expect.Once.On(mockView).GetProperty("StandardGasTestElementInfoDTOList").Will(Return.Value(userDTO));

            if (expectedErrorMethodCallNameList == null ||
                expectedErrorMethodCallNameList.Count == 0)
            {
                Expect.Once.On(mockGasTestElementInfoService).Method("UpdateGasTestElementInfoDTOList");
                Expect.Once.On(mockEditHistoryService).Method("TakeSnapshot");
                Expect.Once.On(mockView).Method("SaveSucceededMessage");
                Expect.Once.On(mockView).Method("Close");
            }
            else
            {
                Expect.Never.On(mockGasTestElementInfoService).Method("UpdateGasTestElementInfoDTOList");
                Expect.Never.On(mockView).Method("Close");
                foreach(string errorMethodName in expectedErrorMethodCallNameList)
                    Expect.Once.On(mockView).Method(errorMethodName);
            }

            presenter.HandleSaveButtonClick(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        #region Ranged Limit Validation
 
        [Test]
        public void ShouldShowInvalidLimitErrorMessageForRangedLimitStandardDTO()
        {
            const string invalidRangedLimit = "abc-def";

            GasTestElementInfoDTO rangedLimitDTO = GasTestElementInfoFixture.CreateRangedLimitStandardDTO();
            rangedLimitDTO.ColdLimit = invalidRangedLimit;
            rangedLimitDTO.HotLimit = invalidRangedLimit;
            rangedLimitDTO.CSELimit = invalidRangedLimit;
            rangedLimitDTO.InertCSELimit = invalidRangedLimit;

            var expectedMethodCalls = new []
                                            {
                                                SET_COLD_LIMIT_ERROR_MESSAGE,
                                                SET_HOT_LIMIT_ERROR_MESSAGE,
                                                SET_CSE_LIMIT_ERROR_MESSAGE,
                                                SET_INSERT_CSE_LIMIT_ERROR_MESSAGE
                                            };
            ShouldValidateGasLimit(rangedLimitDTO, expectedMethodCalls);
        }


        [Test]
        public void ShouldNotShowLimitErrorMessageForRangedLimitStandardDTO()
        {
            const string validRangedLimit = "0-100";

            GasTestElementInfoDTO rangedLimitDTO = GasTestElementInfoFixture.CreateRangedLimitStandardDTO();
            rangedLimitDTO.ColdLimit = validRangedLimit;
            rangedLimitDTO.HotLimit = validRangedLimit;
            rangedLimitDTO.CSELimit = validRangedLimit;
            rangedLimitDTO.InertCSELimit = validRangedLimit;

            var expectedMethodCalls = new string[0];
            ShouldValidateGasLimit(rangedLimitDTO, expectedMethodCalls);
        }

        [Test]
        public void ShouldShowUnitErrorMessageForRangedLimitStandardDTOWithLimitValuesAndUnknownUnit()
        {
            const string validRangedLimit = "0-100";
            GasLimitUnit invalidUnit = GasLimitUnit.UNKNOWN;

            GasTestElementInfoDTO rangedLimitDTO = GasTestElementInfoFixture.CreateRangedLimitStandardDTO();
            rangedLimitDTO.ColdLimit = validRangedLimit;
            rangedLimitDTO.HotLimit = validRangedLimit;
            rangedLimitDTO.CSELimit = validRangedLimit;
            rangedLimitDTO.InertCSELimit = validRangedLimit;
            rangedLimitDTO.UnitName = invalidUnit.UnitName;

            var expectedMethodCalls = new[]
                                            {
                                                SET_UNIT_LIMIT_ERROR_MESSAGE
                                            };
            ShouldValidateGasLimit(rangedLimitDTO, expectedMethodCalls);
        }

        [Test]
        public void ShouldShowErrorOnInvalidPercentageForRangedStandardDTOLimit()
        {
            const string invalidPercentage = "0-101";
            GasTestElementInfoDTO rangedLimitDTO = GasTestElementInfoFixture.CreateRangedLimitStandardDTO();
            rangedLimitDTO.UnitName = GasLimitUnit.PERCENTAGE.UnitName;
            rangedLimitDTO.ColdLimit = invalidPercentage;
            rangedLimitDTO.HotLimit = invalidPercentage;
            rangedLimitDTO.CSELimit = invalidPercentage;
            rangedLimitDTO.InertCSELimit = invalidPercentage;

            var expectedMethodCalls = new[]
                                            {
                                                SET_COLD_LIMIT_ERROR_MESSAGE,
                                                SET_HOT_LIMIT_ERROR_MESSAGE,
                                                SET_CSE_LIMIT_ERROR_MESSAGE,
                                                SET_INSERT_CSE_LIMIT_ERROR_MESSAGE
                                            };
            ShouldValidateGasLimit(rangedLimitDTO, expectedMethodCalls);
        }

        #endregion

        #region Non-Ranged Limit Validataion

        [Test]
        public void ShouldShowInvalidLimitErrorMessageForNonRangedLimitStandardDTO()
        {
            const string invalidRangedLimit = "10-20";

            GasTestElementInfoDTO nonRangedLimitDTO= GasTestElementInfoFixture.CreateNonRangedLimitStandardDTO();
            nonRangedLimitDTO.ColdLimit = invalidRangedLimit;
            nonRangedLimitDTO.HotLimit = invalidRangedLimit;
            nonRangedLimitDTO.CSELimit = invalidRangedLimit;
            nonRangedLimitDTO.InertCSELimit = invalidRangedLimit;

            var expectedMethodCalls = new[]
                                            {
                                                SET_COLD_LIMIT_ERROR_MESSAGE,
                                                SET_HOT_LIMIT_ERROR_MESSAGE,
                                                SET_CSE_LIMIT_ERROR_MESSAGE,
                                                SET_INSERT_CSE_LIMIT_ERROR_MESSAGE
                                            };
            ShouldValidateGasLimit(nonRangedLimitDTO, expectedMethodCalls);
        }

        [Test]
        public void ShouldNotShowLimitErrorMessageForNonRangedLimitStandardDTO()
        {
            const string validRangedLimit = "100";

            GasTestElementInfoDTO nonRangedLimitDTO = GasTestElementInfoFixture.CreateNonRangedLimitStandardDTO();
            nonRangedLimitDTO.ColdLimit = validRangedLimit;
            nonRangedLimitDTO.HotLimit = validRangedLimit;
            nonRangedLimitDTO.CSELimit = validRangedLimit;
            nonRangedLimitDTO.InertCSELimit = validRangedLimit;

            var expectedMethodCalls = new string[0];
            ShouldValidateGasLimit(nonRangedLimitDTO, expectedMethodCalls);
        }

        [Test]
        public void ShouldShowErrorOnInvalidPercentageForNonRangedStandardDTOLimit()
        {
            const string invalidPercentage = "101";
            GasTestElementInfoDTO nonRangedLimitDTO = GasTestElementInfoFixture.CreateNonRangedLimitStandardDTO();
            nonRangedLimitDTO.UnitName = GasLimitUnit.PERCENTAGE.UnitName;
            nonRangedLimitDTO.ColdLimit = invalidPercentage;
            nonRangedLimitDTO.HotLimit = invalidPercentage;
            nonRangedLimitDTO.CSELimit = invalidPercentage;
            nonRangedLimitDTO.InertCSELimit = invalidPercentage;

            var expectedMethodCalls = new[]
                                            {
                                                SET_COLD_LIMIT_ERROR_MESSAGE,
                                                SET_HOT_LIMIT_ERROR_MESSAGE,
                                                SET_CSE_LIMIT_ERROR_MESSAGE,
                                                SET_INSERT_CSE_LIMIT_ERROR_MESSAGE
                                            };
            ShouldValidateGasLimit(nonRangedLimitDTO, expectedMethodCalls);
        }

        #endregion

        #endregion


    }
}
