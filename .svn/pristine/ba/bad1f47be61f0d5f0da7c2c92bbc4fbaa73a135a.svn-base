using System.Drawing;

namespace Com.Suncor.Olt.Client.Domain.PriorityPage
{
    public abstract class PriorityPageGroupNode : PriorityPageNode
    {
        private readonly string groupName;

        protected PriorityPageGroupNode(long nodeId, long? parentNodeId, string groupName) : base(nodeId, parentNodeId)
        {
            this.groupName = "  " + groupName;
        }

        public override string GroupName
        {
            get { return groupName; }
        }

        public override Bitmap Status
        {
            get { return null; }
        }

        public override Bitmap Priority
        {
            get { return null; }
        }

        public override Bitmap SecondaryStatus
        {
            get { return null; }
        }

        public override string When
        {
            get { return null; }
        }

        public override string WhoWhat
        {
            get { return null; }
        }

        public override string SecondaryWhoWhat
        {
            get { return null; }
        }

        public override string OptionalText
        {
            get { return null; }
        }

        public override string StartEndText
        {
            get { return null; }
        }

        public override string Text
        {
            get { return null; }
        }
    }
}
