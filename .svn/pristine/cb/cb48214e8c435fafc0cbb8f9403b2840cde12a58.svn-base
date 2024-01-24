using System;
using System.Drawing;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Domain.PriorityPage
{
    public class ExcursionEventNodeData : NodeData<ExcursionEventPriorityPageDTO>
    {
        private ExcursionEventPriorityPageDTO dto;

        public ExcursionEventNodeData(ExcursionEventPriorityPageDTO dto)
            : base(dto)
        {
            this.dto = dto;
        }

        public ExcursionEventPriorityPageDTO Dto
        {
            get { return dto; }
        }

        public override Bitmap Status
        {
            get
            {
                if (dto.ToeType.Id == ToeType.HighSl.Id)
                {
                    return ResourceUtils.HIGH_SL;
                }
                if (dto.ToeType.Id == ToeType.HighSol.Id)
                {
                    return ResourceUtils.HIGH_SOL;
                }
                if (dto.ToeType.Id == ToeType.HighTarget.Id)
                {
                    return ResourceUtils.HIGH_TARGET;
                }
                if (dto.ToeType.Id == ToeType.LowSl.Id)
                {
                    return ResourceUtils.LOW_SL;
                }
                if (dto.ToeType.Id == ToeType.LowSol.Id)
                {
                    return ResourceUtils.LOW_SOL;
                }
                if (dto.ToeType.Id == ToeType.LowTarget.Id)
                {
                    return ResourceUtils.LOW_TARGET;
                }
                return null;
            }
        }

        public override Bitmap Priority
        {
            get { return ResourceUtils.NORMAL_PRIORITY; }
        }

        public override string StatusToolTip
        {
            get { return dto.ToeType.Name; }
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
            get { return dto.StartDateTime; }
        }

        public override string WhoWhat
        {
            get { return DisplayedUser; }
        }

        private string DisplayedUser
        {
            get { return dto.FunctionalLocationNames; }
        }

        public override string OptionalText
        {
            get { return dto.Status.Name; }
        }

        public override bool EmphasizeOptionalText
        {
            get { return dto.Status == ExcursionStatus.Open; }
        }

        public override string Text
        {
            get { return BuildFormLinkText(); }
        }

        private string BuildFormLinkText()
        {
            var linkText = dto.ExcursionCount > 1
                ? string.Format("({0}) {1}", dto.ExcursionCount, dto.ToeName)
                : string.Format("{0}", dto.ToeName);

            return linkText;
        }

        public override int CompareTo(NodeData nodeData)
        {
            var other = nodeData as ExcursionEventNodeData;
            if (other == null || other.dto == null)
            {
                return 1;
            }
            // descending by StartDateTime
            return other.dto.StartDateTime.CompareTo(dto.StartDateTime);
        }
    }
}