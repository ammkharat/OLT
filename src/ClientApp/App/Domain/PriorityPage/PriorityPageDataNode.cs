using System;
using System.Drawing;
using log4net;

namespace Com.Suncor.Olt.Client.Domain.PriorityPage
{
    public class PriorityPageDataNode : PriorityPageNode
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (PriorityPageDataNode));

        private NodeData nodeData;

        public PriorityPageDataNode(long nodeId, PriorityPageNode parentNode, NodeData nodeData)
            : base(nodeId, parentNode.NodeId)
        {
            this.nodeData = nodeData;
        }

        public override string GroupName
        {
            get { return null; }
        }

        public override Bitmap Status
        {
            get { return nodeData.Status; }
        }

        public override Bitmap SecondaryStatus
        {
            get { return nodeData.SecondaryStatus; }
        }

        public override Bitmap Priority
        {
            get { return nodeData.Priority; }
        }

        public override string When
        {
            get { return nodeData.When; }
        }

        public override string WhoWhat
        {
            get { return nodeData.WhoWhat; }
        }

        public override string SecondaryWhoWhat
        {
            get { return nodeData.SecondaryWhoWhat; }
        }

        public override string OptionalText
        {
            get { return nodeData.OptionalText; }
        }

        public override string StartEndText
        {
            get { return nodeData.StartEndText; }
        }

        public override string Text
        {
            get { return nodeData.Text; }
        }

        public override bool EmphasizeOptionalText
        {
            get { return NodeData.EmphasizeOptionalText; }
        }

        public NodeData NodeData
        {
            get { return nodeData; }
        }

        public void UpdateNodeData(NodeData newNodeData)
        {
            var oldNodeData = nodeData;
            nodeData = newNodeData;

            try
            {
                if (!Equals(oldNodeData.Status, nodeData.Status))
                {
                    RaisePropertyChangeEvent("Status");
                }
                else if (!Equals(oldNodeData.SecondaryStatus, nodeData.SecondaryStatus))
                {
                    RaisePropertyChangeEvent("SecondaryStatus");
                }
                else if (!Equals(oldNodeData.When, nodeData.When))
                {
                    RaisePropertyChangeEvent("When");
                }
                else if (!Equals(oldNodeData.WhoWhat, nodeData.WhoWhat))
                {
                    RaisePropertyChangeEvent("WhoWhat");
                }
                else if (!Equals(oldNodeData.SecondaryWhoWhat, nodeData.SecondaryWhoWhat))
                {
                    RaisePropertyChangeEvent("SecondaryWhoWhat");
                }
                else if (!Equals(oldNodeData.OptionalText, nodeData.OptionalText))
                {
                    RaisePropertyChangeEvent("OptionalText");
                }
                else if (!Equals(oldNodeData.StartEndText, nodeData.StartEndText))
                {
                    RaisePropertyChangeEvent("StartEndText");
                }
                else if (!Equals(oldNodeData.Text, nodeData.Text))
                {
                    RaisePropertyChangeEvent("Text");
                }
            }
            catch (Exception e)
            {
                logger.Error("Error updating node data for: ", e);
            }
        }

        protected override int CompareTo(PriorityPageNode other)
        {
            var otherDataNode = other as PriorityPageDataNode;
            if (otherDataNode == null)
            {
                return base.CompareTo(other);
            }
            return NodeData.CompareTo(otherDataNode.NodeData);
        }
    }
}