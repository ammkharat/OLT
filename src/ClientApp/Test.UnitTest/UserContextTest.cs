using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client
{
    /// <summary>
    /// Summary description for UserContextTest
    /// </summary>
    [TestFixture]
    public class UserContextTest
    {
        [Test]
        public void TestGetSetUserShouldBe()
        {
            UserContext userContext = ClientSession.GetUserContext();
            var setUser = new User(null, null, null, new List<SiteRolePlant>(), "999", 
                null, 
                null,
                null, 
                DateTimeFixture.DateTimeNow);
            userContext.User = setUser;

            User getUser = userContext.User;
            Assert.AreEqual(setUser, getUser);
        }

        [Test]
        public void TestGetNewInstanceShouldHaveNothingInIt()
        {
            ClientSession.GetNewInstance();
            UserContext userContext = ClientSession.GetUserContext();
            Assert.IsNull(userContext.User);
            Assert.IsEmpty(userContext.RootsForSelectedFunctionalLocations);
        }

        [Test]
        public void TestFunctionalLocationIdStringSplit()
        {
            var selectedFLOCList = new List<FunctionalLocation>
                                       {
                                           FunctionalLocationFixture.CreateNew(123),
                                           FunctionalLocationFixture.CreateNew(456)
                                       };

            const string expectedString = "123, 456";
            string actualString = selectedFLOCList.BuildIdStringFromList();
            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void ShouldKnowIfUserIsInGracePeriod()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2006, 2, 8, 18, 5, 0);

            UserContext context = ClientSession.GetUserContext();
            context.UserShift = ShiftPatternFixture.CreateUserShiftDuringDayShift(Clock.Now);

            Assert.IsTrue(ClientSession.GetInstance().UserIsInGracePeriod());

            Clock.UnFreeze();
        }

        [Test]
        public void ShouldReportThatUserIsNotInGracePeriodIfTheCurrentTimeIsInTheFirstFifteenMinutesOfTheHour()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2006, 2, 8, 17, 5, 0);

            UserContext context = ClientSession.GetUserContext();
            context.UserShift = ShiftPatternFixture.CreateUserShiftDuringDayShift(new DateTime(2006, 2, 8, 17, 5, 0));

            Assert.IsFalse(ClientSession.GetInstance().UserIsInGracePeriod());

            Clock.UnFreeze();
        }

        [Test]
        public void ShouldReturnRootsForFlocsLevelTwoAndLower()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.CreateNew("a1");
            FunctionalLocation floc2 = FunctionalLocationFixture.CreateNew("a1-b");
            FunctionalLocation floc3 = FunctionalLocationFixture.CreateNew("a1-b-c1");
            FunctionalLocation floc4 = FunctionalLocationFixture.CreateNew("a1-b-c2");
                                       
            FunctionalLocation floc5 = FunctionalLocationFixture.CreateNew("a2");
            FunctionalLocation floc6 = FunctionalLocationFixture.CreateNew("a2-b");
            FunctionalLocation floc7 = FunctionalLocationFixture.CreateNew("a2-b-c");
            
            FunctionalLocation floc8 = FunctionalLocationFixture.CreateNew("a3-b-c");
            FunctionalLocation flocDiv1 = FunctionalLocationFixture.CreateNew("a3");
            FunctionalLocation flocSec1 = FunctionalLocationFixture.CreateNew("a3-b");

            FunctionalLocation floc9 = FunctionalLocationFixture.CreateNew("a4-b");
            FunctionalLocation flocDiv2 = FunctionalLocationFixture.CreateNew("a4");

            {
                // These would have been the selected flocs back when we took everything from division down to unit:
                // List<FunctionalLocation> selectedFlocs = new List<FunctionalLocation> { floc1, floc2, floc3, floc4, floc5, floc6, floc7, floc8, floc9 };

                List<FunctionalLocation> selectedFlocs = new List<FunctionalLocation> { floc1, floc5, floc8, floc9 };
                List<FunctionalLocation> divisions = new List<FunctionalLocation> { floc1, floc5, flocDiv1, flocDiv2 };
                List<FunctionalLocation> sections = new List<FunctionalLocation> { floc2, floc6, flocSec1, floc9 };

                UserContext context = ClientSession.GetUserContext();
                context.SetSelectedFunctionalLocations(selectedFlocs, divisions, sections);

                List<FunctionalLocation> roots = context.RootsForFunctionalLocationsLevelTwoAndLower(selectedFlocs);
                Assert.AreEqual(4, roots.Count);
                Assert.IsTrue(roots.Exists(floc => floc.FullHierarchy == "a1-b"));
                Assert.IsTrue(roots.Exists(floc => floc.FullHierarchy == "a2-b"));
                Assert.IsTrue(roots.Exists(floc => floc.FullHierarchy == "a3-b-c"));
                Assert.IsTrue(roots.Exists(floc => floc.FullHierarchy == "a4-b"));
            }

            {
                List<FunctionalLocation> selectedFlocs = new List<FunctionalLocation> { floc1 };
                List<FunctionalLocation> divisions = new List<FunctionalLocation> { floc1 };
                List<FunctionalLocation> sections = new List<FunctionalLocation> { floc2 };

                UserContext context = ClientSession.GetUserContext();
                context.SetSelectedFunctionalLocations(selectedFlocs, divisions, sections);

                List<FunctionalLocation> roots = context.RootsForFunctionalLocationsLevelTwoAndLower(selectedFlocs);
                Assert.AreEqual(1, roots.Count);
                Assert.IsTrue(roots.Exists(floc => floc.FullHierarchy == "a1-b"));
            }

            {
                // it seems that sometimes the selected flocs can include the children (when the subtree is expanded), so
                // we need to test for that
                List<FunctionalLocation> selectedFlocs = new List<FunctionalLocation> { floc1, floc2, floc3, floc4 };
                List<FunctionalLocation> divisions = new List<FunctionalLocation> { floc1 };
                List<FunctionalLocation> sections = new List<FunctionalLocation> { floc2 };

                UserContext context = ClientSession.GetUserContext();
                context.SetSelectedFunctionalLocations(selectedFlocs, divisions, sections);

                List<FunctionalLocation> roots = context.RootsForFunctionalLocationsLevelTwoAndLower(selectedFlocs);
                Assert.AreEqual(1, roots.Count);
                Assert.IsTrue(roots.Exists(floc => floc.FullHierarchy == "a1-b"));
            }
        }

    }
}
