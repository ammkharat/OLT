using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    [TestFixture]
    public class WorkPermitMontrealValidatorTest
    {
        private DateTime startOfShift;
        private DateTime endOfShift;
        
        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2011, 01, 01, 8, 0, 0);
            UserContext userContext = ClientSession.GetUserContext();
            startOfShift = new DateTime(2011, 01, 01, 6, 0, 0);
            endOfShift = new DateTime(2011, 01, 01, 18, 0, 0);

            userContext.UserShift = new UserShift(ShiftPatternFixture.CreateDayShift(startOfShift), startOfShift);
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test][Ignore]
        public void ShouldSetErrorWhenStartDateAfterEndDate()
        {
            IWorkPermitMontrealFormView view = GetValidMockFormView(startOfShift, new DateTime(2010, 01, 01),
                                                        WorkPermitMontrealType.ELEVATED_HOT);

            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);

            validator.ValidateUserFormAndSetErrors(view);
            
            view.AssertWasCalled(x => x.SetErrorForStartDateTimeAfterEndDateTime());
        }

        [Test][Ignore]
        public void ShouldSetErrorWhenStartTimeAfterEndTimeOnSameDate()
        {
            DateTime startDateTime = new DateTime(2011, 01, 01, 14, 0, 0);
            DateTime endDateTime = new DateTime(2011, 01, 01, 13, 0, 0);

            IWorkPermitMontrealFormView view = GetValidMockFormView(startDateTime, endDateTime, WorkPermitMontrealType.ELEVATED_HOT);
            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);
            validator.ValidateUserFormAndSetErrors(view);
            view.AssertWasCalled(x => x.SetErrorForStartDateTimeAfterEndDateTime());
        }

        [Test][Ignore]
        public void ShouldSetErrorWhenEndDateTimeIsBeforeNow()
        {
            DateTime startDateTime = Clock.Now.AddMinutes(-30);
            DateTime endDateTime = Clock.Now.AddMinutes(-5);
            
            IWorkPermitMontrealFormView view = GetValidMockFormView(startDateTime, endDateTime, WorkPermitMontrealType.ELEVATED_HOT);
            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);
            validator.ValidateUserFormAndSetErrors(view);
            view.AssertWasCalled(x => x.SetErrorForEndDateMustBeonOrAfterTodayError());
        }
        
        [Test][Ignore]
        public void ShouldSetErrorWhenTypeIsNull()
        {
            IWorkPermitMontrealFormView view = GetValidMockFormView(startOfShift, endOfShift,
                                                        null);

            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);
            validator.ValidateUserFormAndSetErrors(view);

            view.AssertWasCalled(x => x.SetErrorForNoPermitType());
        }

        [Test][Ignore]
        public void ShouldSetErrorWhenTypeIsNullType()
        {
            IWorkPermitMontrealFormView view = GetValidMockFormView(startOfShift, endOfShift,
                                                        WorkPermitMontrealType.NULL);

            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);
            validator.ValidateUserFormAndSetErrors(view);

            view.AssertWasCalled(x => x.SetErrorForNoPermitType());
        }

        [Test][Ignore]
        public void ShouldSetErrorWhenDescriptionIsNull()
        {
            IWorkPermitMontrealFormView view = GetValidMockFormView(startOfShift, endOfShift,
                                                        WorkPermitMontrealType.MODERATE_HOT);

            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);
            view.Description = null;

            validator.ValidateUserFormAndSetErrors(view);

            view.AssertWasCalled(x => x.SetErrorForNoDescription());
        }

        [Test][Ignore]
        public void ShouldSetErrorWhenDescriptionIsEmpty()
        {
            IWorkPermitMontrealFormView view = GetValidMockFormView(startOfShift, endOfShift,
                                                                    WorkPermitMontrealType.MODERATE_HOT);

            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);
            view.Description = string.Empty;

            validator.ValidateUserFormAndSetErrors(view);

            view.AssertWasCalled(x => x.SetErrorForNoDescription());
        }

        [Test][Ignore]
        public void ShouldSetErrorWhenDescriptionIsWhitespace()
        {
            IWorkPermitMontrealFormView view = GetValidMockFormView(startOfShift, endOfShift,
                                            WorkPermitMontrealType.MODERATE_HOT);

            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);
            view.Description = "     ";

            validator.ValidateUserFormAndSetErrors(view);

            view.AssertWasCalled(x => x.SetErrorForNoDescription());
        }

        [Test][Ignore]
        public void ShouldSetErrorWhenTradeIsWhitespace()
        {

            IWorkPermitMontrealFormView view = GetValidMockFormView(startOfShift, endOfShift,
                                                        WorkPermitMontrealType.MODERATE_HOT);
            view.SelectedTrade = "    ";
            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);

            validator.ValidateUserFormAndSetErrors(view);

            view.AssertWasCalled(x => x.SetErrorForNoTrade());
        }

        [Test][Ignore]
        public void ShouldSetErrorWhenTradeIsNull()
        {
            IWorkPermitMontrealFormView view = GetValidMockFormView(startOfShift, endOfShift,
                                                        WorkPermitMontrealType.ELEVATED_HOT);
            view.SelectedTrade = null;


            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);


            validator.ValidateUserFormAndSetErrors(view);

            view.AssertWasCalled(x => x.SetErrorForNoTrade());
        }

        [Test][Ignore]
        public void ShouldSetErrorWhenTradeIsEmpty()
        {
            IWorkPermitMontrealFormView view = GetValidMockFormView(startOfShift, endOfShift,
                                                        WorkPermitMontrealType.MODERATE_HOT);
            view.SelectedTrade = string.Empty;

            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);

            validator.ValidateUserFormAndSetErrors(view);

            view.AssertWasCalled(x => x.SetErrorForNoTrade());
        }

        [Test][Ignore]
        public void ShouldNotSetErrorWhenAllIsGood()
        {
            IWorkPermitMontrealFormView view = MockRepository.GenerateMock<IWorkPermitMontrealFormView>();
            view.Expect(v => v.SelectedPermitType).Return(WorkPermitMontrealType.MODERATE_HOT);
            view.Expect(v=> v.SelectedTrade).Return("trade");
            view.Expect(v=> v.Description).Return("description");
            view.Expect(v=> v.FunctionalLocations).Return(new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_MT1_A003_U120() });
            view.Expect(v=> v.StartDateTime).Return(startOfShift);
            view.Expect(v=> v.EndDateTime).Return(endOfShift);
            view.Expect(v=> v.Corrosif).Return(new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value")));
            view.Expect(v=> v.Aromatique).Return(new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value")));
            view.Expect(v=> v.AutresSubstances).Return(new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value")));
            view.Expect(v=> v.DessinsRequis).Return(new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value")));
            view.Expect(v=> v.BoiteEnergieZero).Return(new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value")));
            view.Expect(v=> v.FormulaireDespaceClosAffiche).Return(new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value")));
            view.Expect(v=> v.AutreConditions).Return(new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value")));
            view.Expect(v=> v.ProtectionRespiratoire).Return(new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value")));
            view.Expect(v=> v.Habits).Return(new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value")));
            view.Expect(v=> v.AutreProtection).Return(new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value")));
            view.Expect(v=> v.AutresEquipementDincendie).Return(new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value")));
            view.Expect(v=> v.Surveillant).Return(new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value")));
            view.Expect(v=> v.DetectionContinueDesGaz).Return(new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value")));
            view.Expect(v => v.AutreEquipementsSecurite).Return(new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value")));

            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);
            validator.ValidateUserFormAndSetErrors(view);
            
            view.VerifyAllExpectations();
        }

        [Test][Ignore]
        public void ShouldSetErrorWhenTimeSpanIsTooLong_OneHourForVehicleEntry()
        {
            // 3pm to 3:59 
            IWorkPermitMontrealFormView view = GetValidMockFormView(
                new DateTime(2011, 01, 01, 15, 0, 0), new DateTime(2011, 01, 01, 15, 59, 0),
                WorkPermitMontrealType.VEHICLE_ENTRY);


            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);
            Assert.IsFalse(validator.HasErrors);

            validator.ValidateUserFormAndSetErrors(view);

            Assert.IsFalse(validator.HasErrors);
            view.AssertWasNotCalled(x => x.SetErrorForTimeSpanTooLongForVehicleEntryType());
        }

        [Test][Ignore]
        public void ShouldNotSetErrorWhenTimeSpanIsNotTooLongForVehicleEntry()
        {
            // 3pm to 4:01
            IWorkPermitMontrealFormView view = GetValidMockFormView(
                new DateTime(2011, 01, 01, 15, 0, 0), new DateTime(2011, 01, 01, 16, 1, 0),
                WorkPermitMontrealType.VEHICLE_ENTRY);

            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);
            Assert.IsFalse(validator.HasErrors);

            validator.ValidateUserFormAndSetErrors(view);

            view.AssertWasCalled(x => x.SetErrorForTimeSpanTooLongForVehicleEntryType());
            Assert.IsTrue(validator.HasErrors);
        }

        [Test][Ignore]
        public void ShouldNotSetErrorWhenTimeSpanIsNotTooLong()
        {
            // 3pm to 2:59am
            IWorkPermitMontrealFormView view = GetValidMockFormView(
                new DateTime(2011, 01, 01, 15, 0, 0), new DateTime(2011, 01, 02, 2, 59, 0),
                WorkPermitMontrealType.ELEVATED_HOT);

            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);
            Assert.IsFalse(validator.HasErrors);

            validator.ValidateUserFormAndSetErrors(view);

            Assert.IsFalse(validator.HasErrors);
            view.AssertWasNotCalled(x => x.SetErrorForTimeSpanTooLongForVehicleEntryType());
            view.AssertWasNotCalled(x => x.SetErrorForTimeSpanTooLong());
        }

        [Test][Ignore]
        public void ShouldSetErrorWhenTimeSpanIsTooLong()
        {
            // 3pm to 3:01am
            IWorkPermitMontrealFormView view = GetValidMockFormView(
                new DateTime(2011, 01, 01, 15, 0, 0), new DateTime(2011, 01, 02, 3, 1, 0),
                WorkPermitMontrealType.ELEVATED_HOT);

            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);
            Assert.IsFalse(validator.HasErrors);

            validator.ValidateUserFormAndSetErrors(view);

            view.AssertWasCalled(x => x.SetErrorForTimeSpanTooLong());
            Assert.IsTrue(validator.HasErrors);
        }

        [Test][Ignore]
        public void ShouldHaveValidationErrorIfCorrosifCheckboxIsCheckedButNullValue()
        {
            IWorkPermitMontrealFormView view = GetValidMockFormView(startOfShift, endOfShift,
                                                                    WorkPermitMontrealType.MODERATE_HOT);
            view.Corrosif = new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, null));

            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);

            validator.ValidateUserFormAndSetErrors(view);

            view.AssertWasCalled(x => x.SetErrorForCorrosif());                
            Assert.IsTrue(validator.HasErrors);
        }

        [Test][Ignore]
        public void ShouldHaveValidationErrorIfCorrosifCheckboxIsCheckedButNoValue()
        {
            IWorkPermitMontrealFormView view = GetValidMockFormView(startOfShift, endOfShift,
                                                                    WorkPermitMontrealType.MODERATE_HOT);
            view.Corrosif = new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, string.Empty));


            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);
            validator.ValidateUserFormAndSetErrors(view);

            view.AssertWasCalled(x => x.SetErrorForCorrosif());
            Assert.IsTrue(validator.HasErrors);
        }

        [Test][Ignore]
        public void ShouldHaveValidationErrorIfCorrosifCheckboxIsCheckedButWhitespaceValue()
        {
            IWorkPermitMontrealFormView view = GetValidMockFormView(startOfShift, endOfShift,
                                                                    WorkPermitMontrealType.MODERATE_HOT);
            view.Corrosif = new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "    "));

            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);

            validator.ValidateUserFormAndSetErrors(view);
            view.AssertWasCalled(x => x.SetErrorForCorrosif());
            Assert.IsTrue(validator.HasErrors);
        }

        [Test][Ignore]
        public void ShouldNotHaveValidationErrorIfCorrosifCheckboxIsNotChecked()
        {
            IWorkPermitMontrealFormView view = GetValidMockFormView(startOfShift, endOfShift,
                                                                    WorkPermitMontrealType.MODERATE_HOT);
            view.Corrosif = new Visible<TernaryString>(VisibleState.Visible, new TernaryString(false, string.Empty));

            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);
            validator.ValidateUserFormAndSetErrors(view);

            view.AssertWasNotCalled(x => x.SetErrorForCorrosif());
            Assert.IsFalse(validator.HasErrors);
        }

        [Test][Ignore]
        public void ShouldNotHaveValidationErrorIfCorrosifCheckboxIsNotVisibleAndNotChecked()
        {
            IWorkPermitMontrealFormView view = GetValidMockFormView(startOfShift, endOfShift,
                                                                    WorkPermitMontrealType.MODERATE_HOT);
            view.Corrosif = new Visible<TernaryString>(VisibleState.Invisible, new TernaryString(false, string.Empty));


            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);
            validator.ValidateUserFormAndSetErrors(view);

            view.AssertWasNotCalled(x => x.SetErrorForCorrosif());
            Assert.IsFalse(validator.HasErrors);
        }

        private static IWorkPermitMontrealFormView GetValidMockFormView(DateTime startDateTime, DateTime endDateTime, WorkPermitMontrealType permitType)
        {
            IWorkPermitMontrealFormView view = MockRepository.GenerateStub<IWorkPermitMontrealFormView>();
            view.SelectedPermitType = permitType;
            
            WorkPermitMontrealTemplate workPermitMontrealTemplate = new WorkPermitMontrealTemplate("some selected template", permitType, true, false, 44);
            workPermitMontrealTemplate.Id = 10;

            view.SelectedPermitTemplate = workPermitMontrealTemplate;
            view.SelectedTrade = "trade";
            view.Description = "description";
            view.FunctionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_MT1_A003_U120() };
            view.StartDateTime = startDateTime;
            view.EndDateTime = endDateTime;
            view.SelectedRequestedByGroup = WorkPermitMontrealGroupFixture.CreateWithExistingId();
            view.Corrosif = new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value"));
            view.Aromatique = new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value"));
            view.AutresSubstances = new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value"));
            view.DessinsRequis = new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value"));
            view.BoiteEnergieZero = new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value"));
            view.FormulaireDespaceClosAffiche = new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value"));
            view.AutreConditions = new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value"));
            view.ProtectionRespiratoire = new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value"));
            view.Habits = new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value"));
            view.AutreProtection = new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value"));
            view.AutresEquipementDincendie = new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value"));
            view.Surveillant = new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value"));
            view.DetectionContinueDesGaz = new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value"));
            view.AutreEquipementsSecurite = new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "a value"));

            return view;
        }
    }
}