using System;
using System.Drawing;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO.PriorityPage;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Domain.PriorityPage
{
    public class ShiftHandoverNodeData : NodeData<ShiftHandoverQuestionnairePriorityPageDTO>
    {
        private readonly ReadStatus readStatus;

        public ShiftHandoverNodeData(ShiftHandoverQuestionnairePriorityPageDTO dto, ReadStatus readStatus) : base(dto)
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

        public override Bitmap SecondaryStatus
        {
            get
            {
                if (dto.HasYesAnswer)
                {
                    return ResourceUtils.FLAG;
                }

                return ResourceUtils.NO_FLAG;
            }
        }

        public override string SecondaryStatusToolTip
        {
            get
            {
                if (dto.HasYesAnswer)
                {
                    return RendererStringResources.HasAYesAnswer;
                }

                return RendererStringResources.DoesNotHaveAYesAnswer;
            }
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
            get { return dto.ShiftDisplayName; }
        }

        public override string WhoWhat
        {
            get { return DisplayedUser; }
        }

        private string DisplayedUser
        {
            get { return dto.CreateUserFullName; }
        }

        public override string OptionalText
        {
            get { return null; }
        }

        public override string Text
        {
            get { return dto.WorkAssignmentName; }
        }

        public override int CompareTo(NodeData nodeData)
        {
            ShiftHandoverNodeData other = nodeData as ShiftHandoverNodeData;
            if (other == null)
            {
                return 0;
            }
            {
                // descending
                int compareResult = other.dto.ShiftStartDate.CompareTo(dto.ShiftStartDate);
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }
            {
                // descending
                int compareResult = other.dto.ShiftId.CompareTo(dto.ShiftId);
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }
            {
                int compareResult = dto.WorkAssignmentName.CompareTo(other.dto.WorkAssignmentName);
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }
            {
                int compareResult = DisplayedUser.CompareTo(other.DisplayedUser);
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }

            return 0;
        }
    }
}
