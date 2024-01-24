using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Domain.PriorityPage
{
    public abstract class NodeData<TDto> : NodeData where TDto : DomainObject
    {
        protected readonly TDto dto;

        protected NodeData(TDto dto)
        {
            this.dto = dto;
        }

        public override long DomainObjectId
        {
            get { return dto.IdValue; }
        }
    }

    public abstract class NodeData
    {
        public abstract Bitmap Status { get; }
        public abstract Bitmap Priority { get; }
        public virtual Bitmap SecondaryStatus { get { return null; } }
        public virtual string SecondaryStatusToolTip { get { return string.Empty; } }
        public abstract string StatusToolTip { get; }
        public abstract string PriorityToolTip { get; }
        public abstract string When { get; }
        public abstract string WhoWhat { get; }
        public virtual string SecondaryWhoWhat { get { return string.Empty; } }
        public virtual bool ShowSecondaryWhoWhat { get { return false; } }
        public virtual bool ShowOptionalText { get { return false; } }
        public virtual string StartEndText { get { return string.Empty; } }
        public abstract string OptionalText { get; }
        public abstract string Text { get; }
        public abstract int CompareTo(NodeData nodeData);
        
        public abstract long DomainObjectId { get; }

        public virtual bool EmphasizeOptionalText { get { return false; } }

        public bool ShowStartEndText
        {
            get { return StartEndText.HasValue(); }
        }

        protected static Dictionary<T, IImageMapItem<T>> CreateDictionary<T>(List<IImageMapItem<T>> list)
        {
            Dictionary<T, IImageMapItem<T>> dictionary = new Dictionary<T, IImageMapItem<T>>();
            foreach (IImageMapItem<T> item in list)
            {
                if (!dictionary.ContainsKey(item.Key))
                {
                    dictionary.Add(item.Key, item);
                }
            }
            return dictionary;
        }

        protected static Bitmap GetImage<T>(Dictionary<T, IImageMapItem<T>> dictionary, T key)
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key].Image;
            }
            return null;
        }

        protected static string GetToolTip<T>(Dictionary<T, IImageMapItem<T>> dictionary, T key)
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key].ToolTip;
            }
            return null;
        }
    }
}
