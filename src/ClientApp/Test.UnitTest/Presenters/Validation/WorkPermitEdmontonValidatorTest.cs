using System;
using System.Drawing;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Validation.Edmonton;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.Validation.Edmonton;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    [TestFixture]
    public class WorkPermitEdmontonValidatorTest
    {
        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2011, 01, 01, 8, 0, 0);

            UserContext userContext = ClientSession.GetUserContext();
            DateTime startOfShift = new DateTime(2011, 01, 01, 6, 0, 0);
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift(startOfShift);
            userContext.UserShift = new UserShift(shiftPattern, startOfShift);
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldSetErrorWhenDescriptionIsNull()
        {
            IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.HOT_WORK);
            view.Description = null;

            WorkPermitEdmontonValidator validator = CreateValidator(view);
            validator.ValidateAndSetErrors(Clock.Now);

            view.AssertWasCalled(x => x.SetErrorForNoDescription());
        }

        private WorkPermitEdmontonValidator CreateValidator(IWorkPermitEdmontonView view)
        {
            LabelAttributes labelAttributes = new LabelAttributes(new Font(FontFamily.GenericSansSerif, 10), 100, 100);
            return new WorkPermitEdmontonValidator(new WorkPermitEdmontonValidationViewAdapter(view), labelAttributes);
        }

        [Test]
        public void ShouldSetErrorWhenDescriptionIsWhiteSpace()
        {
            IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.HOT_WORK);
            view.Description = "    ";

            WorkPermitEdmontonValidator validator = CreateValidator(view);
            validator.ValidateAndSetErrors(Clock.Now);

            view.AssertWasCalled(x => x.SetErrorForNoDescription());
        }

        [Test][Ignore]
        public void ShouldSetErrorWhenDescriptionIsEmptyString()
        {
            IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.HOT_WORK);
            view.Description = "";

            WorkPermitEdmontonValidator validator = CreateValidator(view);
            validator.ValidateAndSetErrors(Clock.Now);

            view.AssertWasCalled(x => x.SetErrorForNoDescription());
        }

        [Test]
        public void ShouldSetErrorWhenHazardsIsNullOrEmpty()
        {
            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.HOT_WORK);
                view.HazardsAndOrRequirements = " ";

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasCalled(x => x.SetErrorForNoHazardsAndOrRequirements());
            }

            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.HOT_WORK);
                view.HazardsAndOrRequirements = null;

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasCalled(x => x.SetErrorForNoHazardsAndOrRequirements());
            }
        }

        [Test]
        public void ShouldSetErrorWhenVariousRequiredFieldsAreNotSet()
        {
            IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
            view.FunctionalLocation = null;
            view.WorkPermitType = null;

            WorkPermitEdmontonValidator validator = CreateValidator(view);
            validator.ValidateAndSetErrors(Clock.Now);

            view.AssertWasCalled(x => x.SetErrorForNoFunctionalLocation());
            view.AssertWasCalled(x => x.SetErrorForNoPermitType());
        }

        [Test]
        public void ShouldRequireAreaAndPersonNotifiedIfOtherAreasAffectedIsChecked()
        {
            IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);

            view.Stub(x => x.OtherAreasAndOrUnitsAffected).Return(true);

            view.SetOtherAreasAndOrUnitsAffected(true, null, null);

            WorkPermitEdmontonValidator validator = CreateValidator(view);
            validator.ValidateAndSetErrors(Clock.Now);

            view.AssertWasCalled(x => x.SetErrorForNoAreaAffected());
            view.AssertWasCalled(x => x.SetErrorForNoPersonNotified());
        }

        [Test]
        public void ShouldNotRequireAreaAndPersonNotifiedIfOtherAreaAffectedIsNotChecked()
        {
            IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);

            view.Stub(x => x.OtherAreasAndOrUnitsAffected).Return(false);
                     
            view.SetOtherAreasAndOrUnitsAffected(false, null, null);

            WorkPermitEdmontonValidator validator = CreateValidator(view);
            validator.ValidateAndSetErrors(Clock.Now);

            view.AssertWasNotCalled(x => x.SetErrorForNoAreaAffected());
            view.AssertWasNotCalled(x => x.SetErrorForNoPersonNotified());
        }

        [Test]
        public void ShouldSetErrorWhenIssuedDateTimeAfterExpiryDateTime()
        {
            IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now.AddMinutes(-5), WorkPermitEdmontonType.HOT_WORK);

            WorkPermitEdmontonValidator validator = CreateValidator(view);
            validator.ValidateAndSetErrors(Clock.Now);

            view.AssertWasCalled(x => x.SetErrorForStartDateTimeNotBeforeEndDateTime());
        }

        [Test]
        public void ShouldSetErrorWhenExpiryDateTimeIsInThePast()
        {
            IWorkPermitEdmontonView view = GetMockFormView(Clock.Now.AddHours(-2), Clock.Now.AddMinutes(-5), WorkPermitEdmontonType.HOT_WORK);

            WorkPermitEdmontonValidator validator = CreateValidator(view);
            validator.ValidateAndSetErrors(Clock.Now);

            view.AssertWasCalled(x => x.SetErrorForExpiryDateTimeInThePast());
        }

        [Test]
        public void ShouldSetErrorWhenLocationOrOccupationOrGroupAreNotProvided()
        {
            IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
            view.Location = null;
            view.Occupation = " ";
            view.Group = null;

            WorkPermitEdmontonValidator validator = CreateValidator(view);
            validator.ValidateAndSetErrors(Clock.Now);

            view.AssertWasCalled(x => x.SetErrorForNoOccupation());
            view.AssertWasCalled(x => x.SetErrorForNoLocation());
            view.AssertWasCalled(x => x.SetErrorForNoGroup());
        }

        [Test]
        public void ShouldSetErrorWhenNumberOfWorkersIsNotPositive()
        {
            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.NumberOfWorkers = 0;

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasCalled(x => x.SetErrorForNumberOfWorkersLessThanOrEqualToZero());
            }

            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.NumberOfWorkers = -3;

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasCalled(x => x.SetErrorForNumberOfWorkersLessThanOrEqualToZero());
            }
        }

        [Test]
        public void ShouldRequireCertainStatusOfPipingEquipmentFieldsWhenTheSectionIsApplicableToJob()
        {
            IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);

            view.ProductNormallyInPipingEquipment = null;
            view.ZeroEnergyFormNumber = null;
            view.LockBoxNumber = "  ";

            {
                view.StatusOfPipingEquipmentSectionNotApplicableToJob = true;

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasNotCalled(x => x.SetErrorForNoProductNormallyInPipingEquipment());
            }

            {
                view.StatusOfPipingEquipmentSectionNotApplicableToJob = false;

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasCalled(x => x.SetErrorForNoProductNormallyInPipingEquipment());
            }
        }

        [Test]
        public void AtLeastOneItemFromFireProtectiveEquipmentSectionShouldBeSelectedIfPermitTypeIsHighEnergyHotWork()
        {
            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK);

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasCalled(x => x.SetErrorForNoFireProtectiveMeasuresChosenButTypeIsHighEnergyHotWork());
            }

            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK);
                view.EquipmentGrounded = true;

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasNotCalled(x => x.SetErrorForNoFireProtectiveMeasuresChosenButTypeIsHighEnergyHotWork());
            }

            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasNotCalled(x => x.SetErrorForNoFireProtectiveMeasuresChosenButTypeIsHighEnergyHotWork());
            }
        }

        [Test]
        public void AtLeastOneSafetyRequirementShouldBeCheckedIfTheSectionIsApplicableToJob()
        {
            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = true;

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasNotCalled(x => x.SetErrorForNoSafetyRequirementChosen());
            }

            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = false;

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasCalled(x => x.SetErrorForNoSafetyRequirementChosen());
            }

            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = false;
                view.FireBlanket = true;

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasNotCalled(x => x.SetErrorForNoSafetyRequirementChosen());
            }
        }

        [Test]
        public void IfGasTestsSectionIsEnabledThenAtLeastOneGasLineInItMustBeFilledOut()
        {
            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.GasTestsSectionNotApplicableToJob = false;
                view.GasTestDataLine2Oxygen = "heyo";

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasCalled(x => x.SetErrorForNoOperatorGasDetectorNumber());
                view.AssertWasCalled(x => x.SetErrorForGasTestsTableLine2IsInvalid());
            }

            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.GasTestsSectionNotApplicableToJob = true;
                view.GasTestDataLine2Oxygen = "heyo";

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasNotCalled(x => x.SetErrorForNoOperatorGasDetectorNumber());
                view.AssertWasNotCalled(x => x.SetErrorForGasTestsTableLine2IsInvalid());
            }
        }

        [Test]
        public void IfWorkerToProvideGasTestDataIsCheckedThenShouldNotValidateGasTestLines()
        {
            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.WorkerToProvideGasTestData = true;
                view.GasTestsSectionNotApplicableToJob = false;
                view.GasTestDataLine2Oxygen = "heyo";

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasNotCalled(x => x.SetErrorForNoOperatorGasDetectorNumber());
                view.AssertWasNotCalled(x => x.SetErrorForGasTestsTableLine2IsInvalid());
            }

            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.WorkerToProvideGasTestData = false;
                view.GasTestsSectionNotApplicableToJob = false;
                view.GasTestDataLine2Oxygen = "heyo";

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasCalled(x => x.SetErrorForNoOperatorGasDetectorNumber());
                view.AssertWasCalled(x => x.SetErrorForGasTestsTableLine2IsInvalid());
            }
        }

        [Test]
        public void IfAnOtherSafetyRequirementIsCheckedButHasNoValueWeShouldKickUpAFuss()
        {
            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = false;

                view.Other3 = true;
                view.Other3Value = "  ";

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasCalled(x => x.SetErrorForOther3CheckedWithNoValue());
            }

            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = false;

                view.Other3 = true;
                view.Other3Value = "this is ok";

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasNotCalled(x => x.SetErrorForOther3CheckedWithNoValue());
            }

            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);                
                
                view.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = true;
                view.Other3 = true;
                view.Other3Value = " ";

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasNotCalled(x => x.SetErrorForOther3CheckedWithNoValue());                
            }
        }

        [Test]
        public void ShouldSetErrorIfNoIssuedToOptionIsChosen()
        {
            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.IssuedToContractor = false;
                view.IssuedToSuncor = false;

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasCalled(x => x.SetErrorForNoIssuedToOptionSelected());
            }

            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.IssuedToContractor = true;
                view.IssuedToSuncor = false;

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasNotCalled(x => x.SetErrorForNoIssuedToOptionSelected());
            }
        }

        [Test]
        public void ShouldSetErrorIfGn59IsSelectedButNoFormNumberIsProvided()
        {
            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.GN59 = true;
                view.FormGN59 = null;

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasCalled(x => x.SetErrorForNoApprovedGN59Form());
            }

            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.GN59 = false;
                view.FormGN59 = null;

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasNotCalled(x => x.SetErrorForNoApprovedGN59Form());
            }
        }

        [Test]
        public void ShouldSetErrorIfGn7IsSelectedButNoFormNumberIsProvided()
        {
            IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
            view.GN7 = true;
            view.FormGN7 = null;

            WorkPermitEdmontonValidator validator = CreateValidator(view);
            validator.ValidateAndSetErrors(Clock.Now);

            view.AssertWasCalled(x => x.SetErrorForNoApprovedGN7Form());
        }

        [Test]
        public void ShouldSetErrorIfGn6IsSelectedButNoFormNumberIsProvided()
        {
            IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
            view.GN6 = true;
            view.FormGN6 = null;

            WorkPermitEdmontonValidator validator = CreateValidator(view);
            validator.ValidateAndSetErrors(Clock.Now);

            view.AssertWasCalled(x => x.SetErrorForNoApprovedGN6Form());
        }

        [Test]
        public void ShouldSetErrorIfGn75AIsSelectedButNoFormNumberIsProvided()
        {
            IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
            view.GN75A = true;
            view.FormGN75A = null;

            WorkPermitEdmontonValidator validator = CreateValidator(view);
            validator.ValidateAndSetErrors(Clock.Now);

            view.AssertWasCalled(x => x.SetErrorForNoApprovedGN75AForm());
        }

        [Test]
        public void ShouldValidateFormValues_RequiredCausesWarning()
        {
            IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);

            view.GN11 = WorkPermitSafetyFormState.Required;
            AssertWarningForFormValueOfRequired(view, x => x.SetErrorForInvalidGN11Value());

            view.GN27 = WorkPermitSafetyFormState.Required;
            AssertWarningForFormValueOfRequired(view, x => x.SetErrorForInvalidGN27Value());
        }

        private void AssertWarningForFormValueOfRequired(IWorkPermitEdmontonView view, Action<IWorkPermitEdmontonView> action)
        {
            WorkPermitEdmontonValidator validator = CreateValidator(view);
            validator.ValidateAndSetErrors(Clock.Now);
            view.AssertWasCalled(action);
            Assert.IsTrue(validator.HasWarnings);
        }

        [Test]
        public void ShouldSetErrorIfWorkersMonitorNumberIsCheckedButNoNumberIsProvided()
        {
            IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
            view.WorkersMonitor = true;
            view.WorkersMonitorNumber = " ";

            WorkPermitEdmontonValidator validator = CreateValidator(view);
            validator.ValidateAndSetErrors(Clock.Now);

            view.AssertWasCalled(x => x.SetErrorForNoWorkersMonitorNumber());
        }

        [Test]
        public void ShouldSetErrorIfRadioChannelNumberIsCheckedButNoNumberIsProvided()
        {
            IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);

            view.RadioChannel = true;
            view.RadioChannelNumber = null;
            WorkPermitEdmontonValidator validator = CreateValidator(view);
            validator.ValidateAndSetErrors(Clock.Now);

            view.AssertWasCalled(x => x.SetErrorForNoRadioChannelNumber());
        }

        [Test]
        public void ShouldSetErrorIfAnswerToQuestionOneIsNotYesButTheSectionIsEnabled()
        {
            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.ConfinedSpaceWorkSectionNotApplicableToJob = false;
                view.QuestionOneResponse = YesNoNotApplicable.BLANK;

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasCalled(x => x.SetErrorForQuestionOneNotSetToYes());
            }

            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.ConfinedSpaceWorkSectionNotApplicableToJob = false;
                view.QuestionOneResponse = YesNoNotApplicable.YES;

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasNotCalled(x => x.SetErrorForQuestionOneNotSetToYes());
            }

            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.ConfinedSpaceWorkSectionNotApplicableToJob = true;
                view.QuestionOneResponse = YesNoNotApplicable.BLANK;

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasNotCalled(x => x.SetErrorForQuestionOneNotSetToYes());
            }

        }

        [Test]
        public void ShouldSetErrorWhenAssociatedFormsAreNotApproved()
        {
            FormGN6 formGn6 = FormGN6Fixture.CreateFormWithExistingId();
            FormGN7 formGn7 = FormGN7Fixture.CreateFormWithExistingId();
            FormGN59 formGn59 = FormGN59Fixture.CreateFormWithExistingId();
            FormGN24 formGn24 = FormGN24Fixture.CreateFormWithExistingId();

            {
                Assert.IsFalse(formGn6.IsApproved());
                Assert.IsFalse(formGn7.IsApproved());
                Assert.IsFalse(formGn59.IsApproved());
                Assert.IsFalse(formGn24.IsApproved());

                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.GN6 = true;
                view.FormGN6 = formGn6;

                view.GN7 = true;
                view.FormGN7 = formGn7;

                view.GN59 = true;
                view.FormGN59 = formGn59;
                
                view.GN24 = true;
                view.FormGN24 = formGn24;

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasCalled(x => x.SetErrorForNoApprovedGN59Form());
                view.AssertWasCalled(x => x.SetErrorForNoApprovedGN6Form());
                view.AssertWasCalled(x => x.SetErrorForNoApprovedGN7Form());
                view.AssertWasCalled(x => x.SetErrorForNoApprovedGN24Form());
            }

            {
                formGn6.FormStatus = FormStatus.Approved;
                formGn7.FormStatus = FormStatus.Approved;
                formGn59.FormStatus = FormStatus.Approved;
                formGn24.FormStatus = FormStatus.Approved;

                Assert.IsTrue(formGn6.IsApproved());
                Assert.IsTrue(formGn7.IsApproved());
                Assert.IsTrue(formGn59.IsApproved());
                Assert.IsTrue(formGn24.IsApproved());

                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.FormGN6 = formGn6;
                view.FormGN7 = formGn7;
                view.FormGN59 = formGn59;
                view.GN24 = true;
                view.FormGN24 = formGn24;

                WorkPermitEdmontonValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasNotCalled(x => x.SetErrorForNoApprovedGN59Form());
                view.AssertWasNotCalled(x => x.SetErrorForNoApprovedGN6Form());
                view.AssertWasNotCalled(x => x.SetErrorForNoApprovedGN7Form());
                view.AssertWasNotCalled(x => x.SetErrorForNoApprovedGN24Form());
            }
        }

        private static IWorkPermitEdmontonView GetMockFormView(DateTime startDateTime, DateTime endDateTime, WorkPermitEdmontonType permitType)
        {
            IWorkPermitEdmontonView view = MockRepository.GenerateStub<IWorkPermitEdmontonView>();
            view.WorkPermitType = permitType;

            view.Description = "description";
            view.FunctionalLocation = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            view.RequestedStartDateTime = startDateTime;
            view.ExpiryDateTime = endDateTime;

            view.IssuedToSuncor = true;
            
            return view;
        }

        [Test]
        public void ShouldValidateConfinedSpaceCardNumber()
        {
            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.HOT_WORK);
                WorkPermitEdmontonValidator validator = CreateValidator(view);

                view.ConfinedSpace = true;
                view.ConfinedSpaceClass = WorkPermitEdmonton.ConfinedSpaceLevel1;
                view.ConfinedSpaceCardNumber = null;
                
                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasCalled(x => x.SetErrorForNoConfinedSpaceCardNumber());
                view.AssertWasNotCalled(x => x.SetErrorForNoConfinedSpaceClass());
            }

            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.HOT_WORK);
                WorkPermitEdmontonValidator validator = CreateValidator(view);

                view.ConfinedSpace = true;
                view.ConfinedSpaceClass = WorkPermitEdmonton.ConfinedSpaceLevel2;
                view.ConfinedSpaceCardNumber = null;

                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasCalled(x => x.SetErrorForNoConfinedSpaceCardNumber());
                view.AssertWasNotCalled(x => x.SetErrorForNoConfinedSpaceClass());
            }

            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.HOT_WORK);
                WorkPermitEdmontonValidator validator = CreateValidator(view);

                view.ConfinedSpace = true;
                view.ConfinedSpaceClass = WorkPermitEdmonton.ConfinedSpaceLevel3;
                view.ConfinedSpaceCardNumber = null;

                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasNotCalled(x => x.SetErrorForNoConfinedSpaceCardNumber());
                view.AssertWasNotCalled(x => x.SetErrorForNoConfinedSpaceClass());
            }

            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.HOT_WORK);
                WorkPermitEdmontonValidator validator = CreateValidator(view);

                view.ConfinedSpace = true;
                view.ConfinedSpaceClass = WorkPermitEdmonton.ConfinedSpaceLevel2;
                view.ConfinedSpaceCardNumber = "12345";

                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasNotCalled(x => x.SetErrorForNoConfinedSpaceCardNumber());
                view.AssertWasNotCalled(x => x.SetErrorForNoConfinedSpaceClass());
            }

            {
                IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.HOT_WORK);
                WorkPermitEdmontonValidator validator = CreateValidator(view);

                view.ConfinedSpace = true;
                view.ConfinedSpaceClass = WorkPermitEdmonton.ConfinedSpaceLevel3;
                view.ConfinedSpaceCardNumber = "12345";

                validator.ValidateAndSetErrors(Clock.Now);

                view.AssertWasNotCalled(x => x.SetErrorForNoConfinedSpaceCardNumber());
                view.AssertWasNotCalled(x => x.SetErrorForNoConfinedSpaceClass());
            }
        }

    }
}
