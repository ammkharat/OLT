using System;
using System.Drawing;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO.PriorityPage;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Domain.PriorityPage
{   
    public class DirectiveLogNodeData : NodeData<LogPriorityPageDTO>
    {
        private readonly ReadStatus readStatus;

        public DirectiveLogNodeData(LogPriorityPageDTO dto, ReadStatus readStatus)
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
            get { return DisplayedDateTime.ToLongDateAndTimeString(); }
        }

        private DateTime DisplayedDateTime
        {
            get { return dto.LogDateTime; }
        }

        public override string WhoWhat
        {
            get { return dto.CreatedByFullName; }
        }

        public override string OptionalText
        {
            get { return null; }
        }

        public override string Text
        {
            get { return dto.Comments; }
        }

        public override int CompareTo(NodeData nodeData)
        {
            DirectiveLogNodeData other = nodeData as DirectiveLogNodeData;
            if (other == null)
            {
                return 0;
            }
            // descending
            return other.DisplayedDateTime.CompareTo(DisplayedDateTime);
        }
    }
}
