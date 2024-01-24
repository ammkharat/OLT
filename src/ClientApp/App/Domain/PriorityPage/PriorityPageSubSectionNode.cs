using System.Collections.Generic;
using System.Threading;
using log4net;

namespace Com.Suncor.Olt.Client.Domain.PriorityPage
{
    public class PriorityPageSubSectionNode : PriorityPageGroupNode
    {
        private const int LOCK_TIMEOUT = 10000;
        private static readonly ILog logger = LogManager.GetLogger(typeof (PriorityPageSubSectionNode));

        private readonly List<PriorityPageDataNode> dataNodes = new List<PriorityPageDataNode>();
        private readonly PriorityPageTree tree;

        public PriorityPageSubSectionNode(PriorityPageTree tree, long nodeId, PriorityPageSectionNode parentNode,
            string groupName)
            : base(nodeId, parentNode.NodeId, groupName)
        {
            this.tree = tree;
        }

        public void Add(NodeData nodeData, bool hasLock = false)
        {
            if (hasLock || Monitor.TryEnter(tree.LockObject, LOCK_TIMEOUT))
            {
                try
                {
                    if (!Contains(nodeData))
                    {
                        var dataNode = tree.CreateDataNode(this, nodeData);
                        dataNodes.Add(dataNode);
                    }
                }
                finally
                {
                    if (hasLock == false)
                    {
                        Monitor.Exit(tree.LockObject);
                    }
                }
            }
            else
            {
                logger.Error("Timed out waiting for tree lock to add.");
            }
        }

        public void Update(NodeData nodeData)
        {
            if (Monitor.TryEnter(tree.LockObject, LOCK_TIMEOUT))
            {
                try
                {
                    var node = Find(nodeData);
                    if (node != null)
                    {
                        node.UpdateNodeData(nodeData);
                        
                            if (nodeData.GetType() == typeof(Com.Suncor.Olt.Client.Domain.PriorityPage.FormSarniaNodeData) &&
                            ((Com.Suncor.Olt.Client.Domain.PriorityPage.FormSarniaNodeData) (nodeData)).StatusToolTip
                                .Equals("Approved") && nodeData.Text.ToLower().Contains("eip issue"))                                //ayman Sarnia eip DMND0008992
                        {
                            tree.RemoveDataNode(node);
                        }
                    }
                    else
                    {
                        Add(nodeData, true);
                    }
                }
                finally
                {
                    Monitor.Exit(tree.LockObject);
                }
            }
            else
            {
                logger.Error("Timed out waiting for tree lock to update.");
            }
        }

        public void Remove(NodeData nodeData)
        {
            if (Monitor.TryEnter(tree.LockObject, LOCK_TIMEOUT))
            {
                try
                {
                    var node = Find(nodeData);
                    if (node != null)
                    {
                        dataNodes.Remove(node);
                        tree.RemoveDataNode(node);
                    }
                }
                finally
                {
                    Monitor.Exit(tree.LockObject);
                }
            }
            else
            {
                logger.Error("Timed out waiting for tree lock to remove.");
            }
        }

        private bool Contains(NodeData nodeData)
        {
            return Find(nodeData) != null;
        }

        private PriorityPageDataNode Find(NodeData nodeData)
        {
            var domainObjectId = nodeData.DomainObjectId;
            foreach (var node in dataNodes)
            {
                if (node != null)
                {
                    if (node.NodeData.DomainObjectId == domainObjectId)
                    {
                        return node;
                    }
                }
            }
            return null;
        }

        public ExcursionEventNodeData FindMatchingExcursionEventNodeData(long id)
        {
            // Search all the DataNodes in this subsection;
            // look for dataNode.NodeData which contains the 
            // same dto (by id)

            if (Monitor.TryEnter(tree.LockObject, LOCK_TIMEOUT))
            {
                foreach (var node in dataNodes)
                {
                    var data = node.NodeData as ExcursionEventNodeData;
                    if (data == null || data.Dto == null) continue;

                    var potentialDto = data.Dto;
                    if (potentialDto.Id.HasValue && potentialDto.IdValue == id)
                    {
                        return data;
                    }
                }
                return null;
            }

            logger.Error("Timed out waiting for tree lock to find excursion event node.");

            return null;
        }

        public PriorityPageDataNode Find(long domainObjectId)
        {
            if (Monitor.TryEnter(tree.LockObject, LOCK_TIMEOUT))
            {
                foreach (var node in dataNodes)
                {
                    if (node.NodeData.DomainObjectId == domainObjectId)
                    {
                        return node;
                    }
                }
                return null;
            }

            logger.Error("Timed out waiting for tree lock to find.");

            return null;
        }


        public void ClearAllDataNodes()
        {
            if (Monitor.TryEnter(tree.LockObject, LOCK_TIMEOUT))
            {
                try
                {
                    var nodesToRemove = new List<PriorityPageDataNode>(dataNodes);
                    dataNodes.Clear();
                    foreach (var node in nodesToRemove)
                    {
                        tree.RemoveDataNode(node);
                    }
                }
                finally
                {
                    Monitor.Exit(tree.LockObject);
                }
            }
            else
            {
                logger.Error("Timed out waiting for tree lock to clear.");
            }
        }
    }
}