using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility.Comparer;
using log4net;

namespace Com.Suncor.Olt.Client.Controls
{
    // TODO: (2014 cleanup) rename this to match what it is. It's a custom Dictionary. Could even use HashSet? 
    public class FunctionalLocationTreeViewNodeLookup
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(FunctionalLocationTreeViewNodeLookup));

        private readonly IDictionary<FunctionalLocation, FunctionalLocationTreeNode> treeNodeDictionary;

        public FunctionalLocationTreeViewNodeLookup()
        {
            treeNodeDictionary = new Dictionary<FunctionalLocation, FunctionalLocationTreeNode>(new DomainObjectIdEqualityComparer<FunctionalLocation>());
        }

        public void Initialize(FunctionalLocationTreeNode[] value)
        {
            treeNodeDictionary.Clear();
            AddNodesToDictionary(value);
        }

        public void AddNodesToDictionary(FunctionalLocationTreeNode[] value)
        {
            foreach (FunctionalLocationTreeNode node in VisitAllTreeNode(value))
            {
                if (!node.IsPlaceholder)
                    treeNodeDictionary.Add(node.Tag, node);
            }
        }

        public void RemoveNodesFromDictionary(FunctionalLocationTreeNode[] value)
        {
            foreach (FunctionalLocationTreeNode node in VisitAllTreeNode(value))
            {
                if (!node.IsPlaceholder)
                    treeNodeDictionary.Remove(node.Tag);
            }
        }

        public bool Contains(FunctionalLocation floc)
        {
            return treeNodeDictionary.ContainsKey(floc);
        }

        public FunctionalLocationTreeNode Get(FunctionalLocation floc)
        {
            try
            {
                return treeNodeDictionary[floc];
            }
            catch (KeyNotFoundException ex)
            {
                logger.ErrorFormat("The Key {0} was not found in the dictionary. " + Environment.NewLine + "Data: {1}", floc, ex.Data);
                throw;
            }

        }

        private static IEnumerable<FunctionalLocationTreeNode> VisitAllTreeNode(IEnumerable<FunctionalLocationTreeNode> nodeArray)
        {
            foreach (FunctionalLocationTreeNode childNode in nodeArray)
            {
                foreach (FunctionalLocationTreeNode grandChildNode in VisitAllTreeNode(childNode.Nodes))
                {
                    yield return grandChildNode;
                }
                yield return childNode;
            }
        }

        private static IEnumerable<FunctionalLocationTreeNode> VisitAllTreeNode(TreeNodeCollection nodeCollection)
        {
            foreach (FunctionalLocationTreeNode childNode in nodeCollection)
            {
                foreach (FunctionalLocationTreeNode grandChildNode in VisitAllTreeNode(childNode.Nodes))
                    yield return grandChildNode;
                yield return childNode;
            }
        }
    }
}