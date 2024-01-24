using System.Collections.Generic;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class FunctionalLocationCollectionTest
    {
        private FunctionalLocation division;
        private FunctionalLocation section;
        private FunctionalLocation unitA;
        private FunctionalLocation unitB;
        private FunctionalLocation equipment1;
        private FunctionalLocation equipment2A;
        private FunctionalLocation equipment2B;

        private FunctionalLocation[] testFlocs;

        [SetUp]
        public void SetUp()
        {
            division = FunctionalLocationFixture.GetAny_Division();
            section = CreateSection(division);
            unitA = CreateUnit(section, "A");
            unitB = CreateUnit(section, "B");
            equipment1 = CreateEquipment1(unitA);
            equipment2A = CreateEquipment2(equipment1, "A");
            equipment2B = CreateEquipment2(equipment1, "B");

            testFlocs = new[] { division, unitA, unitB, equipment1, equipment2A, equipment2B };
        }

        [Test]
        public void ShouldReturnAllFunctionalLocationsOfAGivenLevel()
        {
            FunctionalLocationCollection flocs = new FunctionalLocationCollection(testFlocs);

            List<FunctionalLocation> units = flocs[FunctionalLocationType.Level3];
            Assert.AreEqual(2, units.Count);
            Assert.AreSame(unitA, units[0]);
            Assert.AreSame(unitB, units[1]);

            List<FunctionalLocation> result = flocs[FunctionalLocationType.Level4];
            Assert.AreEqual(1, result.Count);
            Assert.AreSame(equipment1, result[0]);
        }

        [Test]
        public void ShouldReturnChildrenOfGivenFunctionalLocation()
        {
            FunctionalLocationCollection flocs = new FunctionalLocationCollection(testFlocs);

            Assert.AreEqual(0, flocs.GetChildren(unitB).Count, "Unit B has no equipment 1's.");

            List<FunctionalLocation> result = flocs.GetChildren(equipment1);
            Assert.AreEqual(2, result.Count, "Equipment1 A has two Equipment2's.");
            Assert.AreSame(equipment2A, result[0]);
            Assert.AreSame(equipment2B, result[1]);

            Assert.AreEqual(0, flocs.GetChildren(equipment2A).Count, "Equipment2 A has no children FLOC's.");
        }

        private FunctionalLocation CreateSection(FunctionalLocation parentDivision)
        {
            return FunctionalLocationFixture.CreateNewSectionUnderGivenDivision(parentDivision,
                                                                                FunctionalLocationFixture.GetAny_Section
                                                                                    ().Section);
        }

        private FunctionalLocation CreateUnit(FunctionalLocation parentSection, string unitSegment)
        {
            return FunctionalLocationFixture.CreateNewUnitUnderGivenSection(parentSection, unitSegment);
        }

        private FunctionalLocation CreateEquipment1(FunctionalLocation parentUnit)
        {
            return FunctionalLocationFixture.CreateNewEquipment1UnderAGivenUnit(parentUnit,
                                                                                FunctionalLocationFixture.GetAny_Equip1()
                                                                                    .Equipment1);
        }

        private FunctionalLocation CreateEquipment2(FunctionalLocation parentEquipment1, string equipment2Segment)
        {
            return FunctionalLocationFixture.CreateNewEquipment2UnderGivenEquipment1Unit(parentEquipment1, equipment2Segment);
        }
    }
}
