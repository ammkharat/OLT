using System.IO;
using Com.Suncor.Olt.Client.Controls;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class FunctionalLocationTreeNodeArrayMatcher : Matcher
    {
        private readonly FunctionalLocationTreeNode[] expectedNodes;

        public FunctionalLocationTreeNodeArrayMatcher(FunctionalLocationTreeNode[] expectedNodes)
        {
            this.expectedNodes = expectedNodes;
        }

        public override void DescribeTo(TextWriter writer)
        {
            writer.Write("tree nodes:<" + expectedNodes + ">");
        }

        public override bool Matches(object o)
        {
            FunctionalLocationTreeNode[] divisions = (FunctionalLocationTreeNode[])o;

            try
            {
                AssertNodesEqual(expectedNodes, divisions);
                return true;
            }
            catch (AssertionException)
            {
                return false;
            }
        }

        private static void AssertNodesEqual(FunctionalLocationTreeNode[] expected, FunctionalLocationTreeNode[] actual)
        {
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i].Tag, actual[i].Tag);
                FunctionalLocationTreeNode[] expectedChildNodesAsArray = new FunctionalLocationTreeNode[expected[i].Nodes.Count];
                FunctionalLocationTreeNode[] actualChildNodesAsArray = new FunctionalLocationTreeNode[expected[i].Nodes.Count];
                expected[i].Nodes.CopyTo(expectedChildNodesAsArray, 0);
                actual[i].Nodes.CopyTo(actualChildNodesAsArray, 0);
                AssertNodesEqual(expectedChildNodesAsArray, actualChildNodesAsArray);
            }
        }
    }
}