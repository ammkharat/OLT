using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class FunctionalLocationTreeTest
    {
        [Test]
        public void ShouldBuildNodesFromUnitDownToEquipment2()
        {
            List<FunctionalLocation> selectedFLOCs = new List<FunctionalLocation>();
            ClientSession.GetUserContext().SetSelectedFunctionalLocations(selectedFLOCs, new List<FunctionalLocation>(), new List<FunctionalLocation>());

            // Section
            //  +-- Unit
            //       +-- Equipment1 A
            //       |    +-- Equipment2 AA
            //       |    +-- Equipment2 AB
            //       +-- Equipment1 B
            //            +-- Equipment2 BA

            FunctionalLocationTreeNode section = CreateNode("Div-Section");
            FunctionalLocationTreeNode unit = CreateNode("Div-Section-Unit");
            FunctionalLocationTreeNode equip1A = CreateNode("Div-Section-Unit-Equip1A");
            FunctionalLocationTreeNode equip2AA = CreateNode("Div-Section-Unit-Equip1A-Equip2AA");
            FunctionalLocationTreeNode equip2AB = CreateNode("Div-Section-Unit-Equip1A-Equip2AB");
            FunctionalLocationTreeNode equip1B = CreateNode("Div-Section-Unit-Equip1B");
            FunctionalLocationTreeNode equip2BA = CreateNode("Div-Section-Unit-Equip1B-Equip2BA");

            section.Nodes.Add(unit);
            unit.Nodes.Add(equip1A);
            equip1A.Nodes.Add(equip2AA);
            equip1A.Nodes.Add(equip2AB);
            unit.Nodes.Add(equip1B);
            equip1B.Nodes.Add(equip2BA);

            FunctionalLocationCollection flocs = new FunctionalLocationCollection(new [] {
                section.Tag, unit.Tag, equip1A.Tag, equip2AA.Tag, equip2AB.Tag, equip1B.Tag, equip2BA.Tag });

            // Execute:
            FunctionalLocationTree tree = new FunctionalLocationTree(flocs);
            List<FunctionalLocationTreeNode> nodes = 
                tree.BuildNodes(FunctionalLocationType.Level3, FunctionalLocationType.Level5);

            // Assert that we only get the tree from the unit-level down to equipment2-level:
            AssertNodesAreEqual(CreateTreeNodeCollection(unit), CreateTreeNodeCollection(nodes.ToArray()));
        }

        private static FunctionalLocationTreeNode CreateNode(string fullHierarchy)
        {
            return new FunctionalLocationTreeNode(FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), fullHierarchy));
        }

        private static TreeNodeCollection CreateTreeNodeCollection(params FunctionalLocationTreeNode[] nodes)
        {
            TreeNodeCollection nodeCollection = new TreeNode().Nodes;
            nodeCollection.AddRange(nodes);
            return nodeCollection;
        }

        private static void AssertNodesAreEqual(TreeNodeCollection expected, TreeNodeCollection actual)
        {
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreSame(expected[i].Tag, actual[i].Tag);
                AssertNodesAreEqual(expected[i].Nodes, actual[i].Nodes);
            }
        }
    }
}
