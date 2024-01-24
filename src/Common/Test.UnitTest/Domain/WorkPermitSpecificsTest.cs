using System;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class WorkPermitSpecificsTest
    {
        private WorkPermitSpecifics specifics;

        [SetUp]
        public void SetUp()
        {
            specifics = WorkPermitFixture.CreateWorkPermit().Specifics;
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void ShouldReturnCraftOrTradeName()
        {
            specifics.CraftOrTrade = new CraftOrTrade(-99, TestUtil.RandomString(), "don't matter", 0);
            Assert.AreEqual(specifics.CraftOrTrade.Name, specifics.CraftOrTradeName);
        }

        [Test]
        public void ShouldReturnEmptyCraftOrTradeNameIfNoCraftOrTrade()
        {
            specifics.CraftOrTrade = null;
            Assert.AreEqual(string.Empty, specifics.CraftOrTradeName);
        }

        [Test]
        public void ShouldReturnFunctionalLocationName()
        {
            FunctionalLocation functionalLocation = specifics.FunctionalLocation;
            functionalLocation.FullHierarchy = TestUtil.RandomString();
            Assert.AreEqual(functionalLocation.FullHierarchy, specifics.FunctionalLocationName);
        }

        [Test]
        public void ShouldReturnEmptyFunctionalLocationNameIfNoFunctionalLocation()
        {
            specifics.FunctionalLocation = null;
            Assert.AreEqual(string.Empty, specifics.FunctionalLocationName);
        }

        [Test]
        public void InitializeStartEndDateTimesShouldSetAccordingToUserPreference()
        {
            DateTime now = new DateTime(2007, 2, 3, 12, 00, 00);

            UserShift userShift = UserShiftFixture.CreateUserShift(new Time(09, 00), new Time(17, 00));
            User denverUser = UserFixture.CreateUser(SiteFixture.Denver());
            specifics = WorkPermitFixture.CreateWorkPermit(denverUser, true).Specifics;

            UserWorkPermitDefaultTimePreferences preferences = 
                UserWorkPermitDefaultTimePreferencesFixture.Create(new TimeSpan(02, 00, 00), new TimeSpan(01, 00, 00));
            denverUser.WorkPermitDefaultTimePreferences = preferences;

            specifics.InitializeDateTimes(preferences, userShift, now);
            Assert.AreEqual(preferences.DefaultDateTimeRange(userShift),
                    new Range<DateTime>(specifics.StartDateTime, specifics.EndDateTime.Value));
        }

        [Test]
        public void InitializeStartTimeShouldDefaultToNowForSarnia()
        {
            DateTime now = new DateTime(2007, 2, 3, 13, 00, 00);
            UserShift userShift = UserShiftFixture.CreateUserShift(new Time(09, 00), new Time(17, 00));

            User sarniaUser = UserFixture.CreateUser(SiteFixture.Sarnia());
            specifics = WorkPermitFixture.CreateWorkPermit(sarniaUser, true).Specifics;

            UserWorkPermitDefaultTimePreferences preferences = UserWorkPermitDefaultTimePreferencesFixture.Create(
                new TimeSpan(02, 00, 00), new TimeSpan(01, 00, 00));
            sarniaUser.WorkPermitDefaultTimePreferences = preferences;

            specifics.InitializeDateTimes(preferences, userShift, now);
            Assert.AreEqual(now, specifics.StartDateTime);
        }

        [Test]
        public void CloneShouldUseProvidedStartAndEndDates()
        {
            User sarniaUser = UserFixture.CreateUser(SiteFixture.Sarnia());
            specifics = WorkPermitFixture.CreateWorkPermit(sarniaUser, true).Specifics;
            WorkPermitSpecifics copy = specifics.Copy(true, new DateTime(2004, 1, 1), new DateTime(2005, 1, 1));
            Assert.AreEqual(new DateTime(2004, 1, 1), copy.StartDateTime);
            Assert.AreEqual(new DateTime(2005, 1, 1), copy.EndDateTime);
        }

    }
}
