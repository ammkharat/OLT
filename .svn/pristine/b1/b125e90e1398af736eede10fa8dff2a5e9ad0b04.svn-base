using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Controls
{
    [TestFixture]
    public class TreeViewMagicTest
    {
        private FunctionalLocationTreeViewNodeLookup functionalLocationTreeViewNodeLookup;
        private FunctionalLocation flocDivisionA;
        private FunctionalLocation flocDivisionB;
        private FunctionalLocation flocSectionA;
        private FunctionalLocation flocUnitA;
        private FunctionalLocation flocEq1A;
        private FunctionalLocation flocEq2A;

        private FunctionalLocationTreeNode nodeDivisionA;
        private FunctionalLocationTreeNode nodeDivisionB;
        private FunctionalLocationTreeNode nodeSectionA;
        private FunctionalLocationTreeNode nodeUnitA;
        private FunctionalLocationTreeNode nodeEq1A;
        private FunctionalLocationTreeNode nodeEq2A;

        [SetUp]
        public void Setup()
        {
            functionalLocationTreeViewNodeLookup = new FunctionalLocationTreeViewNodeLookup();

            // DivisionA
            //    +-- SectionA
            //           +-- UnitA
            //                 +-- Equipment1A
            //                      +-- Equipment2A
            // Division B
            //   +-- Placeholder
            long id = 1000;
            flocDivisionA = FunctionalLocationFixture.CreateNew(1000);
            flocSectionA = FunctionalLocationFixture.GetAny_Section();
            flocSectionA.Id = ++id;
            flocUnitA = FunctionalLocationFixture.GetAny_Unit1();
            flocUnitA.Id = ++id;
            flocEq1A = FunctionalLocationFixture.GetAny_Equip1();
            flocEq1A.Id = ++id;
            flocEq2A = FunctionalLocationFixture.GetAny_Equip2();
            flocEq2A.Id = ++id;

            nodeDivisionA = new FunctionalLocationTreeNode(flocDivisionA);
            nodeSectionA = new FunctionalLocationTreeNode(flocSectionA);
            nodeUnitA = new FunctionalLocationTreeNode(flocUnitA);
            nodeEq1A = new FunctionalLocationTreeNode(flocEq1A);
            nodeEq2A = new FunctionalLocationTreeNode(flocEq2A);

            nodeDivisionA.Nodes.Add(nodeSectionA);
            nodeSectionA.Nodes.Add(nodeUnitA);
            nodeUnitA.Nodes.Add(nodeEq1A);
            nodeEq1A.Nodes.Add(nodeEq2A);

            flocDivisionB = FunctionalLocationFixture.CreateNew(2000);
            nodeDivisionB = new FunctionalLocationTreeNode(flocDivisionB, true);
        }

        [Test]
        public void InitiailizeShouldBuildDictionary()
        {
            functionalLocationTreeViewNodeLookup.Initialize(new[] { nodeDivisionA, nodeDivisionB });
            Assert.AreEqual(nodeDivisionA, functionalLocationTreeViewNodeLookup.Get(flocDivisionA));
            Assert.AreEqual(nodeDivisionB, functionalLocationTreeViewNodeLookup.Get(flocDivisionB));
            Assert.AreEqual(nodeSectionA, functionalLocationTreeViewNodeLookup.Get(flocSectionA));
            Assert.AreEqual(nodeUnitA, functionalLocationTreeViewNodeLookup.Get(flocUnitA));
            Assert.AreEqual(nodeEq1A, functionalLocationTreeViewNodeLookup.Get(flocEq1A));
            Assert.AreEqual(nodeEq2A, functionalLocationTreeViewNodeLookup.Get(flocEq2A));
        }

        [Test]
        public void AddToDictionaryShouldExcludePlaceholders()
        {
            // Division 
            //   +--- Section
            //   +--- Placeholder            
            FunctionalLocationTreeNode nodeDivision = new FunctionalLocationTreeNode(flocDivisionA, true);
            FunctionalLocation flocPlaceHolder = ((FunctionalLocationTreeNode)(nodeDivision.Nodes[0])).Tag;
            FunctionalLocationTreeNode nodeSectionA = new FunctionalLocationTreeNode(flocSectionA);
            nodeDivision.Nodes.Add(nodeSectionA);

            functionalLocationTreeViewNodeLookup.AddNodesToDictionary(new[] {nodeDivision});

            Assert.AreEqual(nodeDivision, functionalLocationTreeViewNodeLookup.Get(flocDivisionA));
            Assert.AreEqual(nodeSectionA, functionalLocationTreeViewNodeLookup.Get(flocSectionA));
            try
            {
                functionalLocationTreeViewNodeLookup.Get(flocPlaceHolder);
                Assert.Fail("Placeholder floc should not have been added to the dictionary.  Expected KeyNotFoundException.");
            }
            catch (KeyNotFoundException)
            {                    
            }
        }
    }
}
