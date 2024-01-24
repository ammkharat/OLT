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
    public class ConfinedSpaceViewValidatorTest
    {
        private DateTime startOfShift;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2011, 01, 01, 8, 0, 0);
            UserContext userContext = ClientSession.GetUserContext();
            startOfShift = new DateTime(2011, 01, 01, 6, 0, 0);

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
            IConfinedSpaceView view = GetValidMockFormView(startOfShift, new DateTime(2010, 01, 01));
            IConfinedSpaceValidationAction action = GetConfinedSpaceValidationAction();
            ConfinedSpaceViewValidator validator = new ConfinedSpaceViewValidator(action);

            validator.ValidateViewAndSetErrors(view);
            view.AssertWasCalled(x => x.SetErrorForStartDateTimeAfterEndDateTime());
        }

        [Test]
        public void ShouldSetErrorWhenStartTimeAfterEndTimeOnSameDate()
        {
            DateTime startDateTime = new DateTime(2011, 01, 01, 14, 0, 0);
            DateTime endDateTime = new DateTime(2011, 01, 01, 13, 0, 0);

            IConfinedSpaceView view = GetValidMockFormView(startDateTime, endDateTime);
            IConfinedSpaceValidationAction action = GetConfinedSpaceValidationAction();
            ConfinedSpaceViewValidator validator = new ConfinedSpaceViewValidator(action);

            validator.ValidateViewAndSetErrors(view);
            view.AssertWasCalled(x => x.SetErrorForStartDateTimeAfterEndDateTime());
        }

        [Test][Ignore]
        public void ShouldSetErrorWhenEndDateTimeIsBeforeNow()
        {
            DateTime startDateTime = Clock.Now.AddMinutes(-30);
            DateTime endDateTime = Clock.Now.AddMinutes(-5);

            IConfinedSpaceView view = GetValidMockFormView(startDateTime, endDateTime);
            IConfinedSpaceValidationAction action = GetConfinedSpaceValidationAction();
            ConfinedSpaceViewValidator validator = new ConfinedSpaceViewValidator(action);
            validator.ValidateViewAndSetErrors(view);
            view.AssertWasCalled(x => x.SetErrorForEndDateMustBeonOrAfterTodayError());
        }

        private static IConfinedSpaceView GetValidMockFormView(DateTime startDateTime, DateTime endDateTime)
        {
            IConfinedSpaceView view = MockRepository.GenerateStub<IConfinedSpaceView>();

            view.FunctionalLocation = FunctionalLocationFixture.GetReal_MT1_A003_U120();
            view.StartDateTime = startDateTime;
            view.EndDateTime = endDateTime;

            view.Corrosif = new TernaryString(false, "");
            view.Aromatique = new TernaryString(false, "");
            view.AutresSubstances = new TernaryString(false, "");
            view.DessinsRequis = new TernaryString(false, "");
            view.AutreConditions = new TernaryString(false, "");
                        
            return view;
        }

        private static IConfinedSpaceValidationAction GetConfinedSpaceValidationAction()
        {
            return MockRepository.GenerateStub<IConfinedSpaceValidationAction>();
        }
    }
}