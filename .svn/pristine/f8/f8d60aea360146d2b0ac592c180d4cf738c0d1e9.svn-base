using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Validation.Montreal;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Validation.Montreal;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Client.Validator
{
    [TestFixture]
    public class PermitRequestMontrealValidatorTest
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
        public void WorkPermitTypeIsRequired()
        {
            {
                IPermitRequestMontrealFormView view = GetMockFormView();
                PermitRequestMontrealValidator validator = CreateValidator(view);
                validator.Validate(Clock.DateNow);

                view.AssertWasNotCalled(x => x.ShowNoWorkPermitTypeSelectedError());
            }

            {
                IPermitRequestMontrealFormView view = GetMockFormView();
                view.WorkPermitType = null;

                PermitRequestMontrealValidator validator = CreateValidator(view);
                validator.Validate(Clock.DateNow);

                view.AssertWasCalled(x => x.ShowNoWorkPermitTypeSelectedError());
            }
        }

        [Test]
        public void EndDateMustBeOnOrAfterToday()
        {
            {
                IPermitRequestMontrealFormView view = GetMockFormView();
                view.StartDate = Clock.DateNow;
                view.EndDate = Clock.DateNow;

                PermitRequestMontrealValidator validator = CreateValidator(view);
                validator.Validate(Clock.DateNow);

                view.AssertWasNotCalled(x => x.ShowEndDateMustBeOnOrAfterTodayError());
            }

            {
                IPermitRequestMontrealFormView view = GetMockFormView();
                view.StartDate = Clock.DateNow.AddDays(-1);
                view.EndDate = Clock.DateNow.AddDays(-1);

                PermitRequestMontrealValidator validator = CreateValidator(view);
                validator.Validate(Clock.DateNow);

                view.AssertWasCalled(x => x.ShowEndDateMustBeOnOrAfterTodayError());
            }
        }

        private static IPermitRequestMontrealFormView GetMockFormView()
        {
            IPermitRequestMontrealFormView view = MockRepository.GenerateStub<IPermitRequestMontrealFormView>();

            view.WorkPermitType = WorkPermitMontrealType.COLD;

            view.FunctionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_MT1_A001_U010() };
            view.StartDate = Clock.DateNow;
            view.EndDate = Clock.DateNow;

            return view;
        }

        private PermitRequestMontrealValidator CreateValidator(IPermitRequestMontrealFormView view)
        {
            return new PermitRequestMontrealValidator(new PermitRequestMontrealValidationViewAdapter(view));
        }
    }
}
