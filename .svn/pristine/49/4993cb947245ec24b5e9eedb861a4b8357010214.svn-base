using System;
using System.Drawing;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Validation.Lubes;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Validation.Lubes;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Client.Validator
{
    [TestFixture]
    public class WorkPermitLubesValidatorTest
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
        public void StartAndEndDateTimesShouldFallWithinASingleShiftThatIsNotInThePast()
        {
            Clock.Now = new DateTime(2011, 01, 01, 8, 0, 0);

            // case: falls across more than one shift in the future
            {
                IWorkPermitLubesView view = GetMockFormView(new DateTime(2011, 02, 01, 8, 0, 0), new DateTime(2011, 02, 01, 21, 0, 0), WorkPermitLubesType.HAZARDOUS_COLD_WORK);
                WorkPermitLubesValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now, 0, 0);
                view.AssertWasCalled(x => x.SetWarningForStartAndEndNotWithinCurrentShiftOrFutureShift());
            }

            // case: falls across more than one shift in the future, but both times are within the same shift pattern
            {
                IWorkPermitLubesView view = GetMockFormView(new DateTime(2011, 02, 01, 8, 0, 0), new DateTime(2011, 02, 03, 9, 0, 0), WorkPermitLubesType.HAZARDOUS_COLD_WORK);
                WorkPermitLubesValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now, 0, 0);
                view.AssertWasCalled(x => x.SetWarningForStartAndEndNotWithinCurrentShiftOrFutureShift());
            }

            // case: falls across more than one shift but starting in the current shift
            {
                IWorkPermitLubesView view = GetMockFormView(Clock.Now, new DateTime(2011, 01, 01, 19, 0, 0), WorkPermitLubesType.HAZARDOUS_COLD_WORK);
                WorkPermitLubesValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now, 0, 0);
                view.AssertWasCalled(x => x.SetWarningForStartAndEndNotWithinCurrentShiftOrFutureShift());            
            }

            // case: falls within shift in the past
            {
                IWorkPermitLubesView view = GetMockFormView(new DateTime(2010, 01, 01, 13, 0, 0), new DateTime(2010, 01, 01, 14, 0, 0), WorkPermitLubesType.HAZARDOUS_COLD_WORK);
                WorkPermitLubesValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now, 0, 0);
                view.AssertWasCalled(x => x.SetWarningForStartAndEndNotWithinCurrentShiftOrFutureShift());
            }

            // case: within current shift
            {
                IWorkPermitLubesView view = GetMockFormView(Clock.Now, new DateTime(2011, 01, 01, 13, 0, 0), WorkPermitLubesType.HAZARDOUS_COLD_WORK);
                WorkPermitLubesValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now, 0, 0);
                view.AssertWasNotCalled(x => x.SetWarningForStartAndEndNotWithinCurrentShiftOrFutureShift());
            }

            // case: within future shift
            {
                IWorkPermitLubesView view = GetMockFormView(new DateTime(2011, 02, 01, 22, 0, 0), new DateTime(2011, 02, 02, 3, 0, 0), WorkPermitLubesType.HAZARDOUS_COLD_WORK);
                WorkPermitLubesValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now, 0, 0);
                view.AssertWasNotCalled(x => x.SetWarningForStartAndEndNotWithinCurrentShiftOrFutureShift());
            }
        }

        [Test]
        public void StartAndEndDateTimesShouldFallWithinASingleShiftThatIsNotInThePast_IncludeShiftPadding()
        {
            Clock.Now = new DateTime(2011, 01, 01, 8, 0, 0);

            // case: falls across more than one shift in the future
            {
                IWorkPermitLubesView view = GetMockFormView(new DateTime(2011, 02, 01, 8, 0, 0), new DateTime(2011, 02, 01, 18, 31, 0), WorkPermitLubesType.HAZARDOUS_COLD_WORK);
                WorkPermitLubesValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now, 60, 60);
                view.AssertWasCalled(x => x.SetWarningForStartAndEndNotWithinCurrentShiftOrFutureShift());
            }

            // case: falls across more than one shift but starting in the current shift
            {
                IWorkPermitLubesView view = GetMockFormView(Clock.Now, new DateTime(2011, 01, 01, 18, 31, 0), WorkPermitLubesType.HAZARDOUS_COLD_WORK);
                WorkPermitLubesValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now, 60, 60);
                view.AssertWasCalled(x => x.SetWarningForStartAndEndNotWithinCurrentShiftOrFutureShift());
            }

            // case: within current shift, starting and ending in the padding zones
            {
                IWorkPermitLubesView view = GetMockFormView(new DateTime(2011, 01, 01, 4, 30, 0), new DateTime(2011, 01, 01, 18, 30, 0), WorkPermitLubesType.HAZARDOUS_COLD_WORK);
                WorkPermitLubesValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now, 60, 60);
                view.AssertWasNotCalled(x => x.SetWarningForStartAndEndNotWithinCurrentShiftOrFutureShift());
            }

            // case: within future shift, starting and ending in the padding zones
            {
                IWorkPermitLubesView view = GetMockFormView(new DateTime(2011, 02, 01, 16, 30, 0), new DateTime(2011, 02, 02, 6, 30, 0), WorkPermitLubesType.HAZARDOUS_COLD_WORK);
                WorkPermitLubesValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now, 60, 60);
                view.AssertWasNotCalled(x => x.SetWarningForStartAndEndNotWithinCurrentShiftOrFutureShift());
            }

            // case: times are in the current day and night shift (incl. padding) but the expiry time has not passed
            {
                IWorkPermitLubesView view = GetMockFormView(new DateTime(2011, 01, 01, 5, 30, 0), new DateTime(2011, 01, 01, 5, 45, 0), WorkPermitLubesType.HAZARDOUS_COLD_WORK);
                WorkPermitLubesValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(new DateTime(2011, 01, 01, 5, 44, 0), 60, 60);
                view.AssertWasNotCalled(x => x.SetWarningForStartAndEndNotWithinCurrentShiftOrFutureShift());
            }

            // case: times are in the current day and night shift (incl. padding) but the expiry time has passed
            {
                IWorkPermitLubesView view = GetMockFormView(new DateTime(2011, 01, 01, 5, 30, 0), new DateTime(2011, 01, 01, 5, 45, 0), WorkPermitLubesType.HAZARDOUS_COLD_WORK);
                WorkPermitLubesValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(new DateTime(2011, 01, 01, 5, 46, 0), 60, 60);
                view.AssertWasNotCalled(x => x.SetWarningForStartAndEndNotWithinCurrentShiftOrFutureShift());
            }
        }

        [Test]
        public void GasDetectorBumpTestedShouldBeRequiredForIssuingWhenAtmosphericGasTestRequiredIsChecked()
        {
            {
                IWorkPermitLubesView view = GetMockFormView(new DateTime(2011, 02, 01, 8, 0, 0), new DateTime(2011, 02, 01, 18, 31, 0), WorkPermitLubesType.HAZARDOUS_COLD_WORK);
                view.AtmosphericGasTestRequired = true;
                view.GasDetectorBumpTested = false;
                WorkPermitLubesValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now, 60, 60);
                view.AssertWasCalled(x => x.SetWarningForGasDetectorBumpTestedRequired());
            }

            {
                IWorkPermitLubesView view = GetMockFormView(new DateTime(2011, 02, 01, 8, 0, 0), new DateTime(2011, 02, 01, 18, 31, 0), WorkPermitLubesType.HAZARDOUS_COLD_WORK);
                view.AtmosphericGasTestRequired = true;
                view.GasDetectorBumpTested = true;
                WorkPermitLubesValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now, 60, 60);
                view.AssertWasNotCalled(x => x.SetWarningForGasDetectorBumpTestedRequired());
            }

            {
                IWorkPermitLubesView view = GetMockFormView(new DateTime(2011, 02, 01, 8, 0, 0), new DateTime(2011, 02, 01, 18, 31, 0), WorkPermitLubesType.HAZARDOUS_COLD_WORK);
                view.AtmosphericGasTestRequired = false;
                view.GasDetectorBumpTested = false;
                WorkPermitLubesValidator validator = CreateValidator(view);
                validator.ValidateAndSetErrors(Clock.Now, 60, 60);
                view.AssertWasNotCalled(x => x.SetWarningForGasDetectorBumpTestedRequired());
            }
        }

        private static IWorkPermitLubesView GetMockFormView(DateTime startDateTime, DateTime endDateTime, WorkPermitLubesType permitType)
        {
            IWorkPermitLubesView view = MockRepository.GenerateStub<IWorkPermitLubesView>();
            view.WorkPermitType = permitType;

            view.FunctionalLocation = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            view.StartDateTime = startDateTime;
            view.ExpireDateTime = endDateTime;

            view.IssuedToSuncor = true;

            return view;
        }

        private WorkPermitLubesValidator CreateValidator(IWorkPermitLubesView view)
        {
            LabelAttributes labelAttributes = new LabelAttributes(new Font(FontFamily.GenericSansSerif, 10), 100, 100);
            return new WorkPermitLubesValidator(new WorkPermitLubesValidationViewAdapter(view), labelAttributes, labelAttributes);
        }

    }
}
