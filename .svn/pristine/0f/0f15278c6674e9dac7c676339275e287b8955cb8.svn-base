using System;
using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Domain.PriorityPage
{
    public class WorkPermitNodeData : NodeData<WorkPermitDTO>
    {
        private static readonly Dictionary<WorkPermitStatus, IImageMapItem<WorkPermitStatus>> imageMapItems =
            CreateDictionary(WorkPermitStatusImageColumn.GetImageMapItems());

        public WorkPermitNodeData(WorkPermitDTO dto) : base(dto)
        {
        }

        public override Bitmap Status
        {
            get { return GetImage(imageMapItems, dto.Status); }
        }

        public override string StatusToolTip
        {
            get { return GetToolTip(imageMapItems, dto.Status); }
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
            get { return dto.StartDateTime; }
        }

        public override string WhoWhat
        {
            get { return dto.CraftOrTradeName; }
        }

        public override bool ShowOptionalText
        {
            get { return true; }
        }

        public override string OptionalText
        {
            get { return dto.CraftOrTradeName; }
        }

        public override string Text
        {
            get
            {
                string description = !string.IsNullOrEmpty(dto.JobStepsDescription) ? dto.JobStepsDescription : dto.WorkOrderDescription;
                return description;
            }
        }

        public override int CompareTo(NodeData nodeData)
        {
            WorkPermitNodeData other = nodeData as WorkPermitNodeData;
            if (other == null)
            {
                return 0;
            }
            // descending
            return other.DisplayedDateTime.CompareTo(DisplayedDateTime);
        }

    }
}
