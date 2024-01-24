using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Client.Controls;

namespace Com.Suncor.Olt.Client.Presenters
{
    /// <summary>
    /// Represents a tree of functional locations, from a higher level type (like Division) spreading
    /// down to a lower level type (like Equipment2).
    /// </summary>
    public class FunctionalLocationTree
    {
        private readonly FunctionalLocationCollection flocs;

        public FunctionalLocationTree(FunctionalLocationCollection flocs)
        {
            this.flocs = flocs;
        }

        public List<FunctionalLocationTreeNode> BuildNodes(FunctionalLocationType higherLevelType,
            FunctionalLocationType lowerLevelType)
        {
            var rootNodes = new List<FunctionalLocationTreeNode>();

            foreach (FunctionalLocation root in flocs[higherLevelType])
            {
                var rootNode = new FunctionalLocationTreeNode(root);
                rootNodes.Add(rootNode);
                AddChildrenNodes(rootNode, lowerLevelType);
            }

            return rootNodes;
        }

        private void AddChildrenNodes(FunctionalLocationTreeNode parent,
            FunctionalLocationType upToChildType)
        {
            if (parent.Tag.Type == upToChildType) { return; }

            List<FunctionalLocation> children = flocs.GetChildren(parent.Tag);
            foreach (FunctionalLocation child in children)
            {
                var childNode = new FunctionalLocationTreeNode(child);
                parent.Nodes.Add(childNode);

                // Recurse depth-first to build children nodes for this new node:
                AddChildrenNodes(childNode, upToChildType);
            }
        }
    }
}
