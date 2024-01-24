using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Validation.Edmonton;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    [TestFixture]
    public class WorkPermitEdmontonOtherWarningsTest
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
        public void ShouldGiveSupervisorWarningUnderCertainCircumstances()
        {
            IWorkPermitEdmontonView view = GetMockFormView(Clock.Now, Clock.Now, WorkPermitEdmontonType.HOT_WORK);
            view.ShiftSupervisor = null;

            {
                view.Group = WorkPermitEdmontonGroupFixture.CreateP1();
                view.WorkPermitType = WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK;
                view.ConfinedSpace = false;
                view.SpecialWork = false;

                WorkPermitEdmontonOtherWarnings otherWarnings = new WorkPermitEdmontonOtherWarnings(view);
                otherWarnings.Validate();

                List<string> warnings = otherWarnings.Warnings(false);
                Assert.IsTrue(warnings.Contains(StringResources.WorkPermitEdmonton_NoShiftSupervisorEntered));
            }

            {
                view.Group = WorkPermitEdmontonGroupFixture.CreateP1();
                view.WorkPermitType = WorkPermitEdmontonType.HOT_WORK;
                view.ConfinedSpace = true;
                view.SpecialWork = false;

                WorkPermitEdmontonOtherWarnings otherWarnings = new WorkPermitEdmontonOtherWarnings(view);
                otherWarnings.Validate();

                List<string> warnings = otherWarnings.Warnings(false);
                Assert.IsTrue(warnings.Contains(StringResources.WorkPermitEdmonton_NoShiftSupervisorEntered));
            }

            {
                view.Group = WorkPermitEdmontonGroupFixture.CreateP1();
                view.WorkPermitType = WorkPermitEdmontonType.HOT_WORK;
                view.ConfinedSpace = false;
                view.SpecialWork = true;

                WorkPermitEdmontonOtherWarnings otherWarnings = new WorkPermitEdmontonOtherWarnings(view);
                otherWarnings.Validate();

                List<string> warnings = otherWarnings.Warnings(false);
                Assert.IsTrue(warnings.Contains(StringResources.WorkPermitEdmonton_NoShiftSupervisorEntered));
            }

            {
                view.Group = WorkPermitEdmontonGroupFixture.CreateP4();
                view.WorkPermitType = WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK;
                view.ConfinedSpace = true;
                view.SpecialWork = true;

                WorkPermitEdmontonOtherWarnings otherWarnings = new WorkPermitEdmontonOtherWarnings(view);
                otherWarnings.Validate();

                List<string> warnings = otherWarnings.Warnings(false);
                Assert.IsFalse(warnings.Contains(StringResources.WorkPermitEdmonton_NoShiftSupervisorEntered));
            }

            {
                view.Group = WorkPermitEdmontonGroupFixture.CreateP4();
                view.WorkPermitType = WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK;
                view.ConfinedSpace = true;
                view.SpecialWork = true;
                view.GN24 = true;

                WorkPermitEdmontonOtherWarnings otherWarnings = new WorkPermitEdmontonOtherWarnings(view);
                otherWarnings.Validate();

                List<string> warnings = otherWarnings.Warnings(false);
                Assert.IsTrue(warnings.Contains(StringResources.WorkPermitEdmonton_NoShiftSupervisorEntered));
            }

            {
                view.ShiftSupervisor = null;
                view.Group = WorkPermitEdmontonGroupFixture.CreateP4();
                view.WorkPermitType = WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK;
                view.ConfinedSpace = true;
                view.SpecialWork = true;
                view.GN75A = true;

                WorkPermitEdmontonOtherWarnings otherWarnings = new WorkPermitEdmontonOtherWarnings(view);
                otherWarnings.Validate();

                List<string> warnings = otherWarnings.Warnings(false);
                Assert.IsTrue(warnings.Contains(StringResources.WorkPermitEdmonton_NoShiftSupervisorEntered));
            }

            {
                view.ShiftSupervisor = "supervisor name";
                view.Group = WorkPermitEdmontonGroupFixture.CreateP1();
                view.WorkPermitType = WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK;
                view.ConfinedSpace = true;
                view.SpecialWork = true;

                WorkPermitEdmontonOtherWarnings otherWarnings = new WorkPermitEdmontonOtherWarnings(view);
                otherWarnings.Validate();

                List<string> warnings = otherWarnings.Warnings(false);
                Assert.IsFalse(warnings.Contains(StringResources.WorkPermitEdmonton_NoShiftSupervisorEntered));
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


    }
}
