using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class FunctionalLocationTest
    {
        [Test]
        public void ShouldReturnTheCorrectFunctionLocationTypeForDivision()
        {
            FunctionalLocation location = FunctionalLocationFixture.GetAny_Division();
            Assert.AreEqual(FunctionalLocationType.Level1, location.Type);            
        }

        [Test]
        public void ShouldReturnTheCorrectFunctionLocationTypeForSection()
        {
            FunctionalLocation location = FunctionalLocationFixture.GetAny_Section();
            Assert.AreEqual(FunctionalLocationType.Level2, location.Type);
        }

        [Test]
        public void ShouldReturnTheCorrectFunctionLocationTypeForUnit()
        {
            FunctionalLocation location = FunctionalLocationFixture.GetAny_Unit1();
            Assert.AreEqual(FunctionalLocationType.Level3, location.Type);
        }

        [Test]
        public void ShouldReturnTheCorrectFunctionLocationTypeForEquipment1()
        {
            FunctionalLocation location = FunctionalLocationFixture.GetAny_Equip1();
            Assert.AreEqual(FunctionalLocationType.Level4, location.Type);
        }

        [Test]
        public void ShouldReturnTheCorrectFunctionLocationTypeForEquipment2()
        {
            FunctionalLocation location = FunctionalLocationFixture.GetAny_Equip2();
            Assert.AreEqual(FunctionalLocationType.Level5, location.Type);
        }

        [Test]
        public void ShouldReturnHierarchyDescription()
        {
            TestHierarchyProperty("A-B-C-D-E");
            TestHierarchyProperty("A-B-C-D");
            TestHierarchyProperty("A-B-C");
            TestHierarchyProperty("A-B");
            TestHierarchyProperty("A");
        }

        [Test]
        public void IsPartOfUnitShouldReturnTrueIfHierarchyMatchesFromSiteToUnit()
        {
            FunctionalLocation location = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), "A-B-C-D-E");
            FunctionalLocation unit = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), "A-B-C");
            Assert.IsTrue(location.IsPartOfUnit(unit));

            location.Site = SiteFixture.Denver();
            Assert.IsFalse(location.IsPartOfUnit(unit));

            location = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), "A1-B-C-D-E");
            Assert.IsFalse(location.IsPartOfUnit(unit));

            location = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), "A-B1-C-D-E");
            Assert.IsFalse(location.IsPartOfUnit(unit));

            location = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), "A-B-C1-D-E");
            Assert.IsFalse(location.IsPartOfUnit(unit));
        }
        
        private void TestHierarchyProperty(string fullHierarchy)
        {
            Assert.AreEqual(new FunctionalLocationHierarchy(fullHierarchy),
                FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), fullHierarchy).FunctionalLocationHierarchy);
        }

        [Test]
        public void ShouldBeParentOfAnotherFloc()
        {
            FunctionalLocation parent = FunctionalLocationFixture.CreateNew("SR1");
            parent.Site = SiteFixture.Sarnia();

            FunctionalLocation child = FunctionalLocationFixture.CreateNew("SR1-PLT2-UNIT");
            child.Site = SiteFixture.Sarnia();

            Assert.That(parent.IsParentOf(child), Is.True);
        }

        [Test]
        public void ShouldBeNotBeParentOfAnotherFloc()
        {
            FunctionalLocation parent = FunctionalLocationFixture.CreateNew("SR1");
            parent.Site = SiteFixture.Sarnia();

            FunctionalLocation child = FunctionalLocationFixture.CreateNew("SR2-PLT2-UNIT");
            child.Site = SiteFixture.Sarnia();

            Assert.That(parent.IsParentOf(child), Is.False);
        }

        [Test]
        public void ShouldBeNotBeParentOfAnotherFlocThatJustHappensToContainSameStuff1()
        {
            FunctionalLocation parent = FunctionalLocationFixture.CreateNew("SR1");
            parent.Site = SiteFixture.Sarnia();

            FunctionalLocation child = FunctionalLocationFixture.CreateNew("SR2-SR1-UNIT");
            child.Site = SiteFixture.Sarnia();

            Assert.That(parent.IsParentOf(child), Is.False);
        }

        [Test]
        public void ShouldBeNotBeParentOfAnotherFlocThatJustHappensToContainSameStuff2()
        {
            FunctionalLocation parent = FunctionalLocationFixture.CreateNew("SR-SR1-UNIT");
            parent.Site = SiteFixture.Sarnia();

            FunctionalLocation child = FunctionalLocationFixture.CreateNew("SR1-UNIT");
            child.Site = SiteFixture.Sarnia();

            Assert.That(parent.IsParentOf(child), Is.False);
        }

        [Test]
        public void TestDustinWroteToConfirmFlocTypeOrdering()
        {
            FunctionalLocation unit = FunctionalLocationFixture.CreateNew("SR1-SR2-UNIT");

            FunctionalLocation section = FunctionalLocationFixture.CreateNew("SR1-SR2");

            Assert.IsTrue(section.Type < FunctionalLocationType.Level3);

            // So a section is LESS than a unit.
        }

        [Test]
        public void ShouldHelpMikeLearnWhatRootFlocsAre()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal("MT1");
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal("MT1-A001");
            FunctionalLocation floc3 = FunctionalLocationFixture.GetReal("MT1-A001-U010");
            FunctionalLocation floc4 = FunctionalLocationFixture.GetReal("MT1-A001-U010-SEG");
            FunctionalLocation floc5 = FunctionalLocationFixture.GetReal("MT1-A001-U010-SEG-BPM0115");
            FunctionalLocation floc6 = FunctionalLocationFixture.GetReal("MT1-A001-U010-SEG-BTM0115");

            FunctionalLocation flocB = FunctionalLocationFixture.GetReal("MT1-A002");
            FunctionalLocation flocC = FunctionalLocationFixture.GetReal("MT1-A002-U400");

            {
                List<FunctionalLocation> roots = new List<FunctionalLocation> { floc6 }.GetRoots();
                Assert.AreEqual(1, roots.Count);
                Assert.AreEqual(floc6.FullHierarchy, roots[0].FullHierarchy);
            }

            {
                List<FunctionalLocation> roots = new List<FunctionalLocation> { floc5, floc6 }.GetRoots();
                Assert.AreEqual(2, roots.Count);
                Assert.AreEqual(floc5.FullHierarchy, roots[0].FullHierarchy);
                Assert.AreEqual(floc6.FullHierarchy, roots[1].FullHierarchy);
            }

            {
                List<FunctionalLocation> roots = new List<FunctionalLocation> { floc4, floc5, floc6 }.GetRoots();
                Assert.AreEqual(1, roots.Count);
                Assert.AreEqual(floc4.FullHierarchy, roots[0].FullHierarchy);
            }

            {
                List<FunctionalLocation> roots = new List<FunctionalLocation> { floc1, floc2, floc3 }.GetRoots();
                Assert.AreEqual(1, roots.Count);
                Assert.IsTrue(roots.Exists(floc => floc.FullHierarchy == floc1.FullHierarchy));
            }

            {
                List<FunctionalLocation> roots = new List<FunctionalLocation> { floc4, flocB, flocC }.GetRoots();
                Assert.AreEqual(2, roots.Count);
                Assert.IsTrue(roots.Exists(floc => floc.FullHierarchy == floc4.FullHierarchy));
                Assert.IsTrue(roots.Exists(floc => floc.FullHierarchy == flocB.FullHierarchy));
            }
        }

        [Test]
        public void ShouldGetNumbericLevelForFLOCType()
        {
            Assert.AreEqual(1, (int) FunctionalLocationType.Level1);
            Assert.AreEqual(2, (int) FunctionalLocationType.Level2);
            Assert.AreEqual(3, (int) FunctionalLocationType.Level3);
            Assert.AreEqual(4, (int) FunctionalLocationType.Level4);
            Assert.AreEqual(5, (int) FunctionalLocationType.Level5);
            Assert.AreEqual(6, (int) FunctionalLocationType.Level6);
            Assert.AreEqual(7, (int) FunctionalLocationType.Level7);
        }

        [Test]
        public void ShouldReturnFullHierarchyOfClosestSharedAncestor()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal("MT1-A001");
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal("MT1-A001-U010");
            FunctionalLocation floc3 = FunctionalLocationFixture.GetReal("MT1-A001-U010-SEG");
            FunctionalLocation floc4 = FunctionalLocationFixture.GetReal("MT1-A001-U010-SEG-BPM0115");
            FunctionalLocation floc5 = FunctionalLocationFixture.GetReal("MT1-A002-U400");
            FunctionalLocation floc6 = FunctionalLocationFixture.GetReal("SR1-A001");

            Assert.AreEqual("MT1-A001-U010", new List<FunctionalLocation> { floc2, floc3, floc4 }.FullHierarchyOfClosestAncestor());
            Assert.AreEqual("MT1", new List<FunctionalLocation> { floc1, floc5 }.FullHierarchyOfClosestAncestor());
            Assert.AreEqual(null, new List<FunctionalLocation> { floc2, floc6 }.FullHierarchyOfClosestAncestor());
        }

        [Test]
        public void ShouldNotThinkAFlocIsAChildJustBecauseItsNameBeginsWithTheOtherFlocsName()
        {
            FunctionalLocation flocOne = FunctionalLocationFixture.CreateNew(SiteFixture.Edmonton(), "A-B-C-DAG");
            FunctionalLocation flocTwo = FunctionalLocationFixture.CreateNew(SiteFixture.Edmonton(), "A-B-C-DAGNABBIT");
            FunctionalLocation flocThree = FunctionalLocationFixture.CreateNew(SiteFixture.Edmonton(), "A-B-C-DAG-NABBIT");

            Assert.IsFalse(flocTwo.IsChildOf(flocOne.FullHierarchy, flocOne.Site.IdValue));
            Assert.IsFalse(flocTwo.IsChildOf(flocOne));

            Assert.IsTrue(flocThree.IsChildOf(flocOne.FullHierarchy, flocOne.Site.IdValue));
            Assert.IsTrue(flocThree.IsChildOf(flocOne));

            Assert.IsFalse(flocOne.IsParentOf(flocOne));
            Assert.IsFalse(flocOne.IsParentOf(flocOne.FullHierarchy, flocOne.Site.IdValue));

            Assert.IsTrue(flocOne.IsParentOf(flocThree));
            Assert.IsTrue(flocOne.IsParentOf(flocThree.FullHierarchy, flocThree.Site.IdValue));
        }
    }
}
