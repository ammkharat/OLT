using System;
using System.ComponentModel;
using System.Drawing;

namespace Com.Suncor.Olt.Client.Domain.PriorityPage
{
    public abstract class PriorityPageNode : INotifyPropertyChanged, IComparable
    {
        // These fields are bound in the priority page tree. Do not remove or rename without changing the binding.
        protected PriorityPageNode(long nodeId, long? parentNodeId)
        {
            NodeId = nodeId;
            ParentNodeId = parentNodeId;
        }

        public long NodeId { get; private set; }
        public long? ParentNodeId { get;  set; }// removed private set and ,made it as set only
        public abstract string GroupName { get; }
        public abstract Bitmap Status { get; }
        public abstract string When { get; }
        public abstract string WhoWhat { get; }
        public abstract string SecondaryWhoWhat { get; }
        public abstract string OptionalText { get; }
        public abstract string StartEndText { get; }
        public abstract string Text { get; }
        public abstract Bitmap Priority { get; }
        public abstract Bitmap SecondaryStatus { get; }

        public virtual bool EmphasizeOptionalText { get { return false; } }

        public int CompareTo(object obj)
        {
            var other = obj as PriorityPageNode;
            if (other == null)
            {
                return 1;
            }
            if (ParentNodeId != other.ParentNodeId)
            {
                return 0;
            }
            return CompareTo(other);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangeEvent(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual int CompareTo(PriorityPageNode other)
        {
            return NodeId.CompareTo(other.NodeId);
        }
    }
}