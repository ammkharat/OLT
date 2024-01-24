using System;
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
    public class PermitRequestEdmontonValidatorForViewTest
    {
        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2011, 01, 01, 8, 0, 0);

            UserContext userContext = ClientSession.GetUserContext();
            DateTime startOfShift = new DateTime(2011, 01, 01, 6, 0, 0);
            userContext.UserShift = new UserShift(ShiftPatternFixture.CreateDayShift(startOfShift), startOfShift);
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldValidateFormValues_RequiredCausesWarning()
        {
            IPermitRequestEdmontonFormView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);

            view.GN11 = WorkPermitSafetyFormState.Required;
            AssertWarningForFormValueOfRequired(view, x => x.SetErrorForInvalidGN11Value(Arg<string>.Is.Anything));

            view.GN27 = WorkPermitSafetyFormState.Required;
            AssertWarningForFormValueOfRequired(view, x => x.SetErrorForInvalidGN27Value(Arg<string>.Is.Anything));
        }

        [Test]
        public void ShouldValidateFormValues_UnapprovedFormsCauseWarning()
        {
            IPermitRequestEdmontonFormView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
            view.FormGN59 = FormGN59Fixture.CreateFormWithExistingId();
            view.FormGN6 = FormGN6Fixture.CreateFormWithExistingId();
            view.FormGN7 = FormGN7Fixture.CreateFormWithExistingId();
            view.FormGN24 = FormGN24Fixture.CreateFormWithExistingId();
            //view.FormGN75A = FormGN75AFixture.CreateFormWithExistingId();
            view.GN24 = true;
            view.GN75A = true;
//            AssertWarningForFormValueOfRequired(view, x => x.SetErrorForNoApprovedGN59Form(Arg<string>.Is.Anything));
//            AssertWarningForFormValueOfRequired(view, x => x.SetErrorForNoApprovedGN7Form(Arg<string>.Is.Anything));
            AssertWarningForFormValueOfRequired(view, x => x.SetErrorForNoApprovedGN24Form(Arg<string>.Is.Anything));
            AssertWarningForFormValueOfRequired(view, x => x.SetErrorForNoApprovedGN75AForm(Arg<string>.Is.Anything));
        }

        [Test]
        public void ShouldValidateFormValues_NoFormCausesWarningIfFormBoxIsChecked()
        {
            IPermitRequestEdmontonFormView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
            view.GN59 = true;
            view.GN24 = true;
            view.GN6 = true;
            view.GN7 = true;
            view.GN75A = true;
//            view.FormGN59 = null;
//            view.FormGN24 = null;
//            view.FormGN6 = null;

            AssertWarningForFormValueOfRequired(view, x => x.SetErrorForNoApprovedGN59Form(Arg<string>.Is.Anything));
            AssertWarningForFormValueOfRequired(view, x => x.SetErrorForNoApprovedGN6Form(Arg<string>.Is.Anything));
            AssertWarningForFormValueOfRequired(view, x => x.SetErrorForNoApprovedGN7Form(Arg<string>.Is.Anything));
            AssertWarningForFormValueOfRequired(view, x => x.SetErrorForNoApprovedGN24Form(Arg<string>.Is.Anything));
            AssertWarningForFormValueOfRequired(view, x => x.SetErrorForNoApprovedGN75AForm(Arg<string>.Is.Anything));
        }

        [Test]
        public void ShouldValidateFormValues_FormNotApproved()
        {
            IPermitRequestEdmontonFormView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
            view.GN59 = true;
            view.GN24 = false;
            view.GN75A = false;
            view.GN6 = false;
            view.GN7 = false;

            FormGN59 formGn59 = FormGN59Fixture.CreateFormWithExistingId();
            formGn59.FormStatus = FormStatus.Draft;

            view.FormGN59 = formGn59;

            AssertWarningForFormValueOfRequired(view, x => x.SetErrorForNoApprovedGN59Form(Arg<string>.Is.Anything));
        }

        [Test]
        public void ShouldValidateFormValue_FormIsApproved()
        {
            IPermitRequestEdmontonFormView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
            view.GN59 = true;
            view.GN24 = false;
            view.GN75A = false;
            view.GN6 = false;
            view.GN7 = false;

            FormGN59 formGn59 = FormGN59Fixture.CreateFormWithExistingId();
            formGn59.FormStatus = FormStatus.Approved;

            view.FormGN59 = formGn59;

            PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationViewAdapter(view), DataSource.SAP);
            validator.Validate();
            view.AssertWasNotCalled(x => x.SetErrorForNoApprovedGN59Form(Arg<string>.Is.Anything));
            Assert.IsFalse(validator.HasWarnings);
        }

        private void AssertWarningForFormValueOfRequired(IPermitRequestEdmontonFormView view, Action<IPermitRequestEdmontonFormView> action)
        {
            PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationViewAdapter(view), DataSource.SAP);
            validator.Validate();
            view.AssertWasCalled(action);
            Assert.IsTrue(validator.HasWarnings);            
        }

        [Test]
        public void TestConfinedSpaceValidation()
        {
            // Confined Space Selected, fields null
            {
                IPermitRequestEdmontonFormView view = GetMockFormView(Clock.Now, Clock.Now,
                                                                      WorkPermitEdmontonType.COLD_WORK);
                view.ConfinedSpace = true;
                view.ConfinedSpaceCardNumber = null;
                view.ConfinedSpaceClass = null;

                PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationViewAdapter(view), DataSource.SAP);
                validator.Validate();

                view.AssertWasCalled(x => x.SetErrorForNoConfinedSpaceClass(Arg<string>.Is.Anything));
                Assert.IsTrue(validator.HasWarnings);
            }
            // Level "3" Selected, so card number not needed, no error.
            {
                IPermitRequestEdmontonFormView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.ConfinedSpace = true;
                view.ConfinedSpaceCardNumber = null;
                view.ConfinedSpaceClass = "3";

                PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationViewAdapter(view), DataSource.SAP);
                validator.Validate();

                view.AssertWasNotCalled(x => x.SetErrorForNoConfinedSpaceClass(Arg<string>.Is.Anything));
                Assert.IsFalse(validator.HasWarnings);
            }
        }

        [Test]
        public void ShouldValidateThatAreaLabelIsChosenWhenDataSourceIsManual()
        {
            // case: data source is MANUAL and area label is the special empty value
            {
                IPermitRequestEdmontonFormView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.AreaLabel = AreaLabel.EMPTY;

                PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationViewAdapter(view), DataSource.MANUAL);
                validator.Validate();

                view.AssertWasCalled(x => x.SetErrorForNoAreaLabel());
            }

            // case: data source is MANUAL and area label is null
            {
                IPermitRequestEdmontonFormView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.AreaLabel = null;

                PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationViewAdapter(view), DataSource.MANUAL);
                validator.Validate();

                view.AssertWasCalled(x => x.SetErrorForNoAreaLabel());
            }

            // case: data source is CLONE so show the error
            {
                IPermitRequestEdmontonFormView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.AreaLabel = null;

                PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationViewAdapter(view), DataSource.CLONE);
                validator.Validate();

                view.AssertWasCalled(x => x.SetErrorForNoAreaLabel());
            }

            // case: data source is SAP so do not show the error
            {
                IPermitRequestEdmontonFormView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.AreaLabel = null;

                PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationViewAdapter(view), DataSource.SAP);
                validator.Validate();

                view.AssertWasNotCalled(x => x.SetErrorForNoAreaLabel());
            }

            // case: data source is MERGE so do not show the error
            {
                IPermitRequestEdmontonFormView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
                view.AreaLabel = null;

                PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationViewAdapter(view), DataSource.MERGE);
                validator.Validate();

                view.AssertWasNotCalled(x => x.SetErrorForNoAreaLabel());
            }
        }


        private static IPermitRequestEdmontonFormView GetMockFormView(DateTime startDateTime, DateTime endDateTime, WorkPermitEdmontonType permitType)
        {
            IPermitRequestEdmontonFormView view = MockRepository.GenerateStub<IPermitRequestEdmontonFormView>();
            view.WorkPermitType = permitType;

            view.Description = "description";
            view.FunctionalLocation = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            view.RequestedStartDate = new Date(startDateTime);
            view.RequestedEndDate = new Date(endDateTime);

            view.IssuedToSuncor = true;

            return view;
        }

    }
}
