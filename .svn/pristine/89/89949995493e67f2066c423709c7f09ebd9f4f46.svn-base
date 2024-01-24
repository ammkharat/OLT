using System;
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
    public class PermitRequestEdmontonValidatorTest
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

            //view.GN6 = WorkPermitSafetyFormState.Required;
            //PermitRequestEdmontonValidator validator = new PermitRequestEdmontonValidator(view);
            //validator.ValidateAndSetErrors();
            //view.AssertWasCalled(x => x.SetErrorForNoGN6Value());    
            //Assert.IsTrue(validator.HasWarnings);
            
            // gn-6, gn-11, gn-24, gn27, gn75, bt-1

            view.GN6 = WorkPermitSafetyFormState.Required;
            AssertWarningForFormValueOfRequired(view, x => x.SetErrorForInvalidGN6Value());

            view.GN11 = WorkPermitSafetyFormState.Required;
            AssertWarningForFormValueOfRequired(view, x => x.SetErrorForInvalidGN11Value());

            view.GN24 = WorkPermitSafetyFormState.Required;
            AssertWarningForFormValueOfRequired(view, x => x.SetErrorForInvalidGN24Value());

            view.GN27 = WorkPermitSafetyFormState.Required;
            AssertWarningForFormValueOfRequired(view, x => x.SetErrorForInvalidGN27Value());

            view.GN75 = WorkPermitSafetyFormState.Required;
            AssertWarningForFormValueOfRequired(view, x => x.SetErrorForInvalidGN75Value());

            view.BT1 = WorkPermitSafetyFormState.Required;
            AssertWarningForFormValueOfRequired(view, x => x.SetErrorForInvalidBT1Value());
        }

        private void AssertWarningForFormValueOfRequired(IPermitRequestEdmontonFormView view, Action<IPermitRequestEdmontonFormView> action)
        {
            PermitRequestEdmontonValidator validator = new PermitRequestEdmontonValidator(view);
            validator.ValidateAndSetErrors();
            view.AssertWasCalled(action);
            Assert.IsTrue(validator.HasWarnings);
            
        }

        [Test]
        public void TestConfinedSpaceValidation()
        {
            //// story #1903 states this: "If Class A/B selected, then “Card#” mustbe provided and “Rescue Plan” selected and Rescue Plan “Form#” provided"

            //// Confined Space Selected, fields null
            //{
            //    IPermitRequestEdmontonFormView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
            //    view.ConfinedSpace = true;
            //    view.ConfinedSpaceCardNumber = null;
            //    view.ConfinedSpaceClass = null;

            //    PermitRequestEdmontonValidator validator = new PermitRequestEdmontonValidator(view);
            //    validator.ValidateAndSetErrors();

            //    view.AssertWasCalled(x => x.SetErrorForNoConfinedSpaceCardClass());    
            //} 
            
            //// Class "C" Selected, so card number not needed, no error.
            //{
            //    IPermitRequestEdmontonFormView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
            //    view.ConfinedSpace = true;
            //    view.ConfinedSpaceCardNumber = null;
            //    view.ConfinedSpaceClass = "C";

            //    PermitRequestEdmontonValidator validator = new PermitRequestEdmontonValidator(view);
            //    validator.ValidateAndSetErrors();

            //    view.AssertWasNotCalled(x => x.SetErrorForNoConfinedSpaceCardClass());    
            //}

            //// Class "A" selected, need a card number, need Rescue Plan selected, and need a Rescue plan form number.
            //// Test what happens when they are not selected.
            //{
            //    IPermitRequestEdmontonFormView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.COLD_WORK);
            //    view.ConfinedSpace = true;
            //    view.ConfinedSpaceClass = "A";
            //    view.ConfinedSpaceCardNumber = null;

            //    view.RescuePlan = false;
            //    view.RescuePlanFormNumber = null;
                
            //    PermitRequestEdmontonValidator validator = new PermitRequestEdmontonValidator(view);
            //    validator.ValidateAndSetErrors();

            //    view.AssertWasCalled(x => x.SetErrorForNoConfinedSpaceCardNumber());
            //    view.AssertWasCalled(x => x.SetErrorForNoRescuePlanDueToConfinedSpaceClassValue());
            //}
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
