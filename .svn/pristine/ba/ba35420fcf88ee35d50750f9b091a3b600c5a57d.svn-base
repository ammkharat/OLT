using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class DuplicateReasonCodeValidatorTest
    {
        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldValidateValidateIfOnlyOneItem()
        {
            DateTime now = DateTimeFixture.DateTimeNow;
            User user = UserFixture.CreateOperator();
            RestrictionReasonCode restrictionReasonCodeA = new RestrictionReasonCode("ReasonCodeA", user, now, ClientSession.GetUserContext().SiteId) { Id = 1 };      //ayman restriction reason codes
            RestrictionLocationItem restrictionLocationItem = RestrictionLocationItemFixture.CreateWithReasonCodes(FunctionalLocationFixture.CreateNew(1, "EX1-PLT2-SPI3"),
                restrictionReasonCodeA);

            var deviationAlertResponseReasonCodeAssignmentA =
                new DeviationAlertResponseReasonCodeAssignment(restrictionLocationItem, restrictionReasonCodeA, null, 100, string.Empty, user, now, now);
            var list = new List<DeviationAlertResponseReasonCodeAssignment>
                           {
                               deviationAlertResponseReasonCodeAssignmentA
                           };
            bool result = new DuplicateReasonCodeValidator(list).HasDuplicateAssignments();
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldNotValidateIfTwoReasonCodesSameAndFunctionalLocationAreSame()
        {
            Clock.Freeze();
            DateTime now = DateTimeFixture.DateTimeNow;
            User user = UserFixture.CreateOperator();
            RestrictionReasonCode restrictionReasonCodeA = new RestrictionReasonCode("ReasonCodeA", user, now, ClientSession.GetUserContext().SiteId) { Id = 1 };    //ayman restriction reason codes
            RestrictionReasonCode restrictionReasonCodeB = new RestrictionReasonCode("ReasonCodeA", user, now, ClientSession.GetUserContext().SiteId) { Id = 1 };     //ayman restriction reason codes

            FunctionalLocation reasonCodeFunctionalLocationA = FunctionalLocationFixture.CreateNew(1, "EX1-PLT2-SPI3");
            FunctionalLocation reasonCodeFunctionalLocationB = FunctionalLocationFixture.CreateNew(1, "EX1-PLT2-SPI3");

            RestrictionLocationItem itemA = RestrictionLocationItemFixture.CreateWithReasonCodes(reasonCodeFunctionalLocationA, restrictionReasonCodeA);
            RestrictionLocationItem itemB = RestrictionLocationItemFixture.CreateWithReasonCodes(reasonCodeFunctionalLocationB, restrictionReasonCodeB);

            var deviationAlertResponseReasonCodeAssignmentA =
                new DeviationAlertResponseReasonCodeAssignment(itemA, restrictionReasonCodeA, "Plant state", 100, string.Empty, user, now, now);
            var deviationAlertResponseReasonCodeAssignmentB =
                new DeviationAlertResponseReasonCodeAssignment(itemB, restrictionReasonCodeB, null, 100, string.Empty, user, now, now);

            var list = new List<DeviationAlertResponseReasonCodeAssignment>
                           {
                               deviationAlertResponseReasonCodeAssignmentA,
                               deviationAlertResponseReasonCodeAssignmentB
                           };

            bool result = new DuplicateReasonCodeValidator(list).HasDuplicateAssignments();
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldValidateIfTwoReasonCodesSameButFunctionalLocationsAreDifferent()
        {
            DateTime now = DateTimeFixture.DateTimeNow;
            User user = UserFixture.CreateOperator();
            RestrictionReasonCode restrictionReasonCodeA = new RestrictionReasonCode("ReasonCodeA", user, now, ClientSession.GetUserContext().SiteId) { Id = 1 };   //ayman restriction reason codes

            RestrictionReasonCode restrictionReasonCodeB = new RestrictionReasonCode("ReasonCodeA", user, now, ClientSession.GetUserContext().SiteId) { Id = 1 };    //ayman restriction reason codes

            FunctionalLocation reasonCodeFunctionalLocationA = FunctionalLocationFixture.CreateNew(1, "EX1-PLT2-A");
            FunctionalLocation reasonCodeFunctionalLocationB = FunctionalLocationFixture.CreateNew(2, "EX1-PLT2-B");

            RestrictionLocationItem itemA = RestrictionLocationItemFixture.CreateWithReasonCodes(reasonCodeFunctionalLocationA, restrictionReasonCodeA);
            RestrictionLocationItem itemB = RestrictionLocationItemFixture.CreateWithReasonCodes(reasonCodeFunctionalLocationB, restrictionReasonCodeB);

            var deviationAlertResponseReasonCodeAssignmentA =
                new DeviationAlertResponseReasonCodeAssignment(itemA, restrictionReasonCodeA, "Plant state", 100, string.Empty, user, now, now);
            var deviationAlertResponseReasonCodeAssignmentB =
                new DeviationAlertResponseReasonCodeAssignment(itemB, restrictionReasonCodeB, "Plant State", 100, string.Empty, user, now, now);

            var list = new List<DeviationAlertResponseReasonCodeAssignment>
                           {
                               deviationAlertResponseReasonCodeAssignmentA,
                               deviationAlertResponseReasonCodeAssignmentB
                           };

            bool result = new DuplicateReasonCodeValidator(list).HasDuplicateAssignments();
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldValidateIfTwoReasonCodesDifferentButFunctionalLocationsAreSame()
        {
            DateTime now = DateTimeFixture.DateTimeNow;
            User user = UserFixture.CreateOperator();
            RestrictionReasonCode restrictionReasonCodeA = new RestrictionReasonCode("ReasonCodeA", user, now, ClientSession.GetUserContext().SiteId) { Id = 1 };   //ayman restriction reason codes
            RestrictionReasonCode restrictionReasonCodeB = new RestrictionReasonCode("ReasonCodeB", user, now,ClientSession.GetUserContext().SiteId) { Id = 2 };

            FunctionalLocation reasonCodeFunctionalLocationA = FunctionalLocationFixture.CreateNew(1, "EX1-PLT2-SPI3");
            FunctionalLocation reasonCodeFunctionalLocationB = FunctionalLocationFixture.CreateNew(1, "EX1-PLT2-SPI3");

            RestrictionLocationItem itemA = RestrictionLocationItemFixture.CreateWithReasonCodes(reasonCodeFunctionalLocationA, restrictionReasonCodeA);
            RestrictionLocationItem itemB = RestrictionLocationItemFixture.CreateWithReasonCodes(reasonCodeFunctionalLocationB, restrictionReasonCodeB);

            var deviationAlertResponseReasonCodeAssignmentA =
                new DeviationAlertResponseReasonCodeAssignment(itemA, restrictionReasonCodeA, "plant state", 100, string.Empty, user, now, now);
            var deviationAlertResponseReasonCodeAssignmentB =
                new DeviationAlertResponseReasonCodeAssignment(itemB, restrictionReasonCodeB, "plant state", 100, string.Empty, user, now, now);

            var list = new List<DeviationAlertResponseReasonCodeAssignment>
                           {
                               deviationAlertResponseReasonCodeAssignmentA,
                               deviationAlertResponseReasonCodeAssignmentB
                           };

            bool result = new DuplicateReasonCodeValidator(list).HasDuplicateAssignments();
            Assert.IsFalse(result);

        }
    }
}
