using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Controls
{
    [TestFixture]
    public class FunctionalLocationTreeNodeTest
    {
        private FunctionalLocationTreeNode nodeDivisionA;
        private FunctionalLocationTreeNode nodeSectionA;
        private FunctionalLocationTreeNode nodeUnitA;
        private FunctionalLocationTreeNode nodeEq1A;
        private FunctionalLocationTreeNode nodeEq2A;

        [SetUp]
        public void SetUp()
        {
            // DivisionA
            //    +-- SectionA
            //           +-- UnitA
            //                 +-- Equipment1A
            //                      +-- Equipment2A

            FunctionalLocation flocDivisionA = FunctionalLocationFixture.CreateNew("DivA");
            FunctionalLocation flocSectionA = FunctionalLocationFixture.CreateNew("DivA-SecA");
            FunctionalLocation flocUnitA = FunctionalLocationFixture.CreateNew("DivA-SecA-UnitA");
            FunctionalLocation flocEq1A = FunctionalLocationFixture.CreateNew("DivA-SecA-UnitA-Equip1");
            FunctionalLocation flocEq2A = FunctionalLocationFixture.CreateNew("DivA-SecA-UnitA-Equip1-Equip2");

            nodeDivisionA = new FunctionalLocationTreeNode(flocDivisionA);
            nodeSectionA = new FunctionalLocationTreeNode(flocSectionA);
            nodeUnitA = new FunctionalLocationTreeNode(flocUnitA);
            nodeEq1A = new FunctionalLocationTreeNode(flocEq1A);
            nodeEq2A = new FunctionalLocationTreeNode(flocEq2A);

            nodeDivisionA.Nodes.Add(nodeSectionA);
            nodeSectionA.Nodes.Add(nodeUnitA);
            nodeUnitA.Nodes.Add(nodeEq1A);
            nodeEq1A.Nodes.Add(nodeEq2A);
        }

        [Test]
        public void ShouldFindParentNodesForEquipment1Nodes()
        {
            Assert.AreEqual(nodeEq1A, nodeEq1A.ParentEquipment1Node);
            Assert.AreEqual(nodeUnitA, nodeEq1A.ParentUnitNode);
            Assert.AreEqual(nodeSectionA, nodeEq1A.ParentSectionNode);
            Assert.AreEqual(nodeDivisionA, nodeEq1A.ParentDivisionNode);
        }

        [Test]
        public void ShouldFindParentNodesForSectionNode()
        {
            Assert.AreEqual(null, nodeSectionA.ParentEquipment1Node);
            Assert.AreEqual(null, nodeSectionA.ParentUnitNode);
            Assert.AreEqual(nodeSectionA, nodeSectionA.ParentSectionNode);
            Assert.AreEqual(nodeDivisionA, nodeSectionA.ParentDivisionNode);
        }
        [Test]
        public void ShouldReturnNullIfLookingForANodeLowerInTheHierachy()
        {
            Assert.AreEqual(null, nodeDivisionA.ParentEquipment1Node);
            Assert.AreEqual(null, nodeDivisionA.ParentUnitNode);
            Assert.AreEqual(null, nodeDivisionA.ParentSectionNode);
            Assert.AreEqual(nodeDivisionA, nodeDivisionA.ParentDivisionNode);
        }

        [Test]
        public void ShouldFindParentNodesForEquipment2Node()
        {
            Assert.AreEqual(nodeEq1A, nodeEq2A.ParentEquipment1Node);
            Assert.AreEqual(nodeUnitA, nodeEq2A.ParentUnitNode);
            Assert.AreEqual(nodeSectionA, nodeEq2A.ParentSectionNode);
            Assert.AreEqual(nodeDivisionA, nodeEq2A.ParentDivisionNode);
        }

        [Test]
        public void ShouldReturnNullIfParentIsNull()
        {
            FunctionalLocation invalidUnitFlocA = FunctionalLocationFixture.CreateNew("DivA-SecA-UnitA");
            FunctionalLocationTreeNode nodeUnitWithNoParent = new FunctionalLocationTreeNode(invalidUnitFlocA);

            Assert.AreEqual(null, nodeUnitWithNoParent.ParentDivisionNode);
            Assert.AreEqual(null, nodeUnitWithNoParent.ParentSectionNode);
            Assert.AreEqual(nodeUnitWithNoParent, nodeUnitWithNoParent.ParentUnitNode);
            Assert.AreEqual(null, nodeUnitWithNoParent.ParentEquipment1Node);
        }
    }
}