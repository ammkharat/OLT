using System;
using System.Drawing;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Domain.PriorityPage
{
    public class DirectiveNodeData : NodeData<DirectiveDTO>
    {
        private readonly ReadStatus readStatus;

        public DirectiveNodeData(DirectiveDTO dto, ReadStatus readStatus)
            : base(dto)
        {
            this.readStatus = readStatus;
        }

        public override Bitmap Status
        {
            get
            {
                if (readStatus.Id == ReadStatus.Read.Id)
                {
                    return ResourceUtils.READ;
                }
                if (readStatus.Id == ReadStatus.Unread.Id)
                {
                    return ResourceUtils.UNREAD;
                }
                return null;
            }
        }

        public override string StatusToolTip
        {
            get { return readStatus.Name; }
        }

        public override Bitmap Priority
        {
            get { return ResourceUtils.NORMAL_PRIORITY; }
        }

        public override string PriorityToolTip
        {
            get { return String.Empty; }
        }

        public override string When
        {
            get { return ActiveFromDateTime.ToDateString(); }
        }

        private DateTime ActiveFromDateTime
        {
            get { return dto.ActiveFromDateTime; }
        }

        public override string WhoWhat
        {
            get { return dto.LastModifiedByFullName; }
        }

        public override string OptionalText
        {
            get { return string.Empty; }
        }

        public override string Text
        {
            get { return dto.Content; }
        }

        public override int CompareTo(NodeData nodeData)
        {
            DirectiveNodeData other = nodeData as DirectiveNodeData;
            if (other == null)
            {
                return 0;
            }
            // descending
            return other.ActiveFromDateTime.CompareTo(ActiveFromDateTime);
        }
    }
}
