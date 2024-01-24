using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class LogTest
    {
        [Test]
        public void ShouldBeSerializable()
        {
            Assert.IsTrue(typeof (Log).IsSerializable);
        }

        [Test]
        public void ShouldBeEqualWhenCompareSameFixturesAlthoughTheyAreDifferentObject()
        {
            DateTime now = DateTimeFixture.DateTimeNow;
            Assert.AreEqual(LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp(now),
                            LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp(now));
        }

        [Test]
        public void ShouldNotBeEqualWhenCompareDifferentFixture()
        {
            Assert.AreNotEqual(LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp(),
                               LogFixture.CreateLogItemGoofySarnia());
        }

        [Test]
        public void IsRootShouldReturnTrueIfRootLogIdIsNull()
        {
            Log rootLog = LogFixture.CreateLogItemGoofySarnia();
            Assert.IsTrue(rootLog.IsRoot());
        }

        [Test]
        public void IsRootShouldReturnFalseIfRootLogIdIsNotNull()
        {
            Log replyLog = LogFixture.CreateReplyLogItem();
            Assert.IsFalse(replyLog.IsRoot());
        }

        [Test]
        public void CreatingAReplyLogShouldSetTheReplyToIdToBeTheIdOfTheParent()
        {
            Log parentLog = LogFixture.CreateLogItemGoofySarnia();
            Log replyLog = LogFixture.CreateLogItemGoofySarnia();
            replyLog.SetReplyTo(parentLog);
            Assert.IsNotNull(parentLog.Id);
            Assert.AreEqual(parentLog.Id, replyLog.ReplyToLogId);
        }

        [Test]
        public void CreatingAReplyLogFromARootLogEntryShouldSetTheRootIdToTheIdOfTheParent()
        {
            Log parentLog = LogFixture.CreateLogItemGoofySarnia();
            Log replyLog = LogFixture.CreateLogItemGoofySarnia();
            replyLog.SetReplyTo(parentLog);
            Assert.IsNotNull(parentLog.Id);
            Assert.AreEqual(parentLog.Id, replyLog.RootLogId);
        }

        [Test]
        public void CreatingAReplyLogFromAnotherReplyLogEntryShouldCopyTheRootIdFromTheParent()
        {
            Log replyLog = LogFixture.CreateReplyLogItem();
            Log replyReplyLog = LogFixture.CreateLogItem(replyLog.LogDateTime, replyLog.LastModifiedDate);
            replyReplyLog.SetReplyTo(replyLog);
            Assert.IsNotNull(replyLog.RootLogId);
            Assert.AreNotEqual(replyLog.Id, replyLog.RootLogId);
            Assert.AreEqual(replyLog.RootLogId, replyReplyLog.RootLogId);
        }     

        [Test]
        public void ShouldBeReleventToUserWhenLogIsAtTheSameSiteAsUsersFlocs()
        {
            int flocId = 1;

            FunctionalLocation flocDivisionB = FunctionalLocationFixture.CreateNew("DivB");
            flocDivisionB.Id = flocId++;

            FunctionalLocation flocSectionB = FunctionalLocationFixture.CreateNew("DivB-SecB");
            flocSectionB.Id = flocId++;

            FunctionalLocation flocUnitB = FunctionalLocationFixture.CreateNew("DivB-SecB-UnitB");
            flocUnitB.Id = flocId++;

            List<FunctionalLocation> flocsOfLog = new List<FunctionalLocation> { flocSectionB };
            WorkAssignment assignment = WorkAssignmentFixture.CreateShiftEngineer();
            DateTime loggedDate = new DateTime(2001, 3, 15, 11, 00, 00);
            Log log = LogFixture.CreateLog(loggedDate, flocsOfLog, assignment);

            Assert.IsTrue(log.IsRelevantTo(flocUnitB.Site.IdValue));

        }

        [Test]
        public void ShouldKnowIfItIsADirectiveThatIsRelevantForDisplay()
        {
            FunctionalLocation rootFloc_UP1 = FunctionalLocationFixture.CreateNew(1, "UP1");
            rootFloc_UP1.Site = SiteFixture.Oilsands();

            FunctionalLocation rootFloc_UP2_FACL_TOOL = FunctionalLocationFixture.CreateNew(2, "UP2-FACL-TOOL");
            rootFloc_UP2_FACL_TOOL.Site = SiteFixture.Oilsands();

            FunctionalLocation UP1_P001 = FunctionalLocationFixture.CreateNew(3, "UP1-P001");
            UP1_P001.Site = SiteFixture.Oilsands();
            FunctionalLocation UP1_P001_COMS = FunctionalLocationFixture.CreateNew(4, "UP1-P001-COMS");
            UP1_P001_COMS.Site = SiteFixture.Oilsands();
            FunctionalLocation UP1_P001_COMS_SEG = FunctionalLocationFixture.CreateNew(5, "UP1-P001-COMS-SEG");
            UP1_P001_COMS_SEG.Site = SiteFixture.Oilsands();
            FunctionalLocation UP1_P001_COMS_SEG_PP0004 = FunctionalLocationFixture.CreateNew(6, "UP1-P001-COMS-SEG-PP0004");
            UP1_P001_COMS_SEG_PP0004.Site = SiteFixture.Oilsands();
           
            FunctionalLocation UP2 = FunctionalLocationFixture.CreateNew(7, "UP2");
            UP2.Site = SiteFixture.Oilsands();
            FunctionalLocation UP2_FACL = FunctionalLocationFixture.CreateNew(8, "UP2-FACL");
            UP2_FACL.Site = SiteFixture.Oilsands();
            FunctionalLocation UP2_P034 = FunctionalLocationFixture.CreateNew(9, "UP2-P034");
            UP2_P034.Site = SiteFixture.Oilsands();
            FunctionalLocation UP2_P035 = FunctionalLocationFixture.CreateNew(10, "UP2-P035");
            UP2_P035.Site = SiteFixture.Oilsands();

            List<FunctionalLocation> rootFlocs = new List<FunctionalLocation> { rootFloc_UP1, rootFloc_UP2_FACL_TOOL };

            List<string> rootFlocsFullHierarchies = rootFlocs.ConvertAll(f => f.FullHierarchy);

            // logs match using the same rules as directives
            {
                Log log = LogFixture.CreateLog(DateTimeFixture.DateTimeNow, 
                    new List<FunctionalLocation> { UP2 }, null, LogType.Standard );

                Assert.IsTrue(log.IsRelevantTo(Site.OILSAND_ID, rootFlocsFullHierarchies, null,null, null));
            }

            // UP2 matches because it's a direct ancestor
            {
                Log directive = LogFixture.CreateLog(DateTimeFixture.DateTimeNow, 
                    new List<FunctionalLocation> { UP2 }, null, LogType.DailyDirective);

                Assert.IsTrue(directive.IsRelevantTo(Site.OILSAND_ID, rootFlocsFullHierarchies, null, null, null));
            }

            // UP2-FACL matches because it's the parent
            {
                Log directive = LogFixture.CreateLog(DateTimeFixture.DateTimeNow, 
                    new List<FunctionalLocation> { UP2_FACL }, null, LogType.DailyDirective);

                Assert.IsTrue(directive.IsRelevantTo(Site.OILSAND_ID, rootFlocsFullHierarchies, null,null, null));
            }

            // UP2-FACL-TOOL matches because it's a direct match
            {
                Log directive = LogFixture.CreateLog(DateTimeFixture.DateTimeNow, 
                    new List<FunctionalLocation> { rootFloc_UP2_FACL_TOOL }, null, LogType.DailyDirective);

                Assert.IsTrue(directive.IsRelevantTo(Site.OILSAND_ID, rootFlocsFullHierarchies, null,null, null));
            }

            // UP2-P034, UP2-P035 does not match because it's not in the same linage
            {
                Log directive = LogFixture.CreateLog(DateTimeFixture.DateTimeNow,
                    new List<FunctionalLocation> { UP2_P034, UP2_P035 }, null, LogType.DailyDirective);

                Assert.IsFalse(directive.IsRelevantTo(Site.OILSAND_ID, rootFlocsFullHierarchies, null, null,null));
            }

            // Anything in UP1 should match
            {
                Log directive = LogFixture.CreateLog(DateTimeFixture.DateTimeNow,
                    new List<FunctionalLocation> { UP1_P001, UP1_P001_COMS }, null, LogType.DailyDirective);

                Assert.IsTrue(directive.IsRelevantTo(Site.OILSAND_ID, rootFlocsFullHierarchies, null,null, null));
            }

            // Anything in UP1 should match
            {
                Log directive = LogFixture.CreateLog(DateTimeFixture.DateTimeNow,
                    new List<FunctionalLocation> { UP1_P001_COMS_SEG_PP0004, UP1_P001_COMS_SEG }, null, LogType.DailyDirective);

                Assert.IsTrue(directive.IsRelevantTo(Site.OILSAND_ID, rootFlocsFullHierarchies, null,null, null));
            }

            // Mixture
            {
                Log directive = LogFixture.CreateLog(DateTimeFixture.DateTimeNow,
                    new List<FunctionalLocation> { UP2_P034, UP2_P035, rootFloc_UP1 }, null, LogType.DailyDirective);

                Assert.IsTrue(directive.IsRelevantTo(Site.OILSAND_ID, rootFlocsFullHierarchies, null, null,null));
            }
        }

        [Test]
        public void IsRelevantToShouldReturnTrueIfUserIsLoggedInUnderRelevantFunctionalLocations()
        {
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Montreal());

            FunctionalLocation flocEq1A;
            FunctionalLocation flocEqOther;
            FunctionalLocation flocUnitA;
            FunctionalLocation flocSectionA;
            FunctionalLocation flocDivisionA;
            FunctionalLocation flocEq2A;
            FunctionalLocation flocDivisionB;
            FunctionalLocation flocSectionB;

            // DivA
            //  - SecA
            //     - UnitA
            //        - Equip1
            //           - Equip2
            // DivB
            //  -  SecB

            int flocId = 1;

            flocDivisionA = FunctionalLocationFixture.CreateNew("DivA");
            flocDivisionA.Id = flocId++;

            flocSectionA = FunctionalLocationFixture.CreateNew("DivA-SecA");
            flocSectionA.Id = flocId++;

            flocUnitA = FunctionalLocationFixture.CreateNew("DivA-SecA-UnitA");
            flocUnitA.Id = flocId++;

            flocEq1A = FunctionalLocationFixture.CreateNew("DivA-SecA-UnitA-Equip1");
            flocEq1A.Id = flocId++;

            flocEq2A = FunctionalLocationFixture.CreateNew("DivA-SecA-UnitA-Equip1-Equip2");
            flocEq2A.Id = flocId++;

            flocEqOther = FunctionalLocationFixture.CreateNew("DivA-SecA-UnitA-EquipOther");

            flocDivisionB = FunctionalLocationFixture.CreateNew("DivB");
            flocDivisionB.Id = flocId++;

            flocSectionB = FunctionalLocationFixture.CreateNew("DivB-SecB");
            flocSectionB.Id = flocId++;

            // -------------------------------


            List<FunctionalLocation> flocsOfLog = new List<FunctionalLocation> { flocEq1A, flocSectionB };
            WorkAssignment assignment = WorkAssignmentFixture.CreateShiftEngineer();
            DateTime loggedDate = new DateTime(2001, 3, 15, 11, 00, 00);
            Log log = LogFixture.CreateLog(loggedDate, flocsOfLog, assignment);

            List<FunctionalLocation> usersFlocs = new List<FunctionalLocation> { flocSectionA, flocUnitA, flocEq1A, flocEq2A };
            Assert.IsTrue(log.IsRelevantTo(flocDivisionA.Site.IdValue, usersFlocs.ConvertAll(f => f.FullHierarchy), null,null, siteConfiguration));

            usersFlocs = new List<FunctionalLocation> { flocDivisionB, flocSectionB };
            Assert.IsTrue(log.IsRelevantTo(flocDivisionA.Site.IdValue, usersFlocs.ConvertAll(f => f.FullHierarchy), null, null,siteConfiguration));

            usersFlocs = new List<FunctionalLocation> { flocEqOther };
            Assert.IsFalse(log.IsRelevantTo(flocDivisionA.Site.IdValue, usersFlocs.ConvertAll(f => f.FullHierarchy), null,null, siteConfiguration));

            usersFlocs = new List<FunctionalLocation> { flocEq2A, flocSectionB };
            Assert.IsTrue(log.IsRelevantTo(flocDivisionA.Site.IdValue, usersFlocs.ConvertAll(f => f.FullHierarchy), null,null, siteConfiguration));
        }       
        
        [Test]
        public void IsRelevantToVisibilityGroupsShouldReturnTrueIfUserCanReadGroupsThatTheLogCanWriteTo()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.CreateNew("A-B-C") };
            DateTime loggedDate = new DateTime(2001, 3, 15, 11, 00, 00);

            WorkAssignment assignment = WorkAssignmentFixture.CreateShiftEngineer();

            List<WorkAssignmentVisibilityGroup> groups = new List<WorkAssignmentVisibilityGroup>{
                                                             new WorkAssignmentVisibilityGroup(null, assignment.IdValue, 1, "one", VisibilityType.Write),
                                                             new WorkAssignmentVisibilityGroup(null, assignment.IdValue, 1, "one", VisibilityType.Read),
                                                             new WorkAssignmentVisibilityGroup(null, assignment.IdValue, 2, "two", VisibilityType.Read)
                                                         };
            assignment.SetVisibilityGroups(groups);
            Log log = LogFixture.CreateLog(loggedDate, flocs, assignment);

            Assert.IsTrue(log.IsRelevantTo(new List<long> { 1, 2, 3 }));
            Assert.IsFalse(log.IsRelevantTo(new List<long> { 2 }));
        }

        [Test]
        public void IsRelevantToVisibilityGroupsShouldReturnTrueIfTheLogHasNoWorkAssignment()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.CreateNew("A-B-C") };
            DateTime loggedDate = new DateTime(2001, 3, 15, 11, 00, 00);

            Log log = LogFixture.CreateLog(loggedDate, flocs, null);

            Assert.IsTrue(log.IsRelevantTo(new List<long> { 1, 2, 3 }));
        }

        [Test]
        public void IsRelevantToVisibilityGroupsShouldReturnFalseIfTheLogHasNoWritableVisibilityGroups()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.CreateNew("A-B-C") };
            DateTime loggedDate = new DateTime(2001, 3, 15, 11, 00, 00);

            WorkAssignment assignment = WorkAssignmentFixture.CreateShiftEngineer();
            assignment.SetVisibilityGroups(new List<WorkAssignmentVisibilityGroup>(0));
            Log log = LogFixture.CreateLog(loggedDate, flocs, assignment);

            Assert.IsFalse(log.IsRelevantTo(new List<long> { 1, 2, 3 }));
        }
    }


}
