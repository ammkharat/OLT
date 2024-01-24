using System;
using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Domain.PriorityPage
{
    public class WorkPermitFortHillsNodeData : NodeData<WorkPermitFortHillsDTO>
    {
        private static readonly Dictionary<PermitRequestBasedWorkPermitStatus, IImageMapItem<PermitRequestBasedWorkPermitStatus>> imageMapItems =
            CreateDictionary(PermitRequestBasedWorkPermitStatusImageColumn<WorkPermitFortHillsDTO>.GetImageMapItems());

        private static readonly Dictionary<Priority, IImageMapItem<Priority>> priorityImageMapItems =
            CreateDictionary(PriorityImageColumn<WorkPermitFortHillsDTO>.GetImageMapItems(new List<Priority>(WorkPermitFortHills.Priorities)));

        public WorkPermitFortHillsNodeData(WorkPermitFortHillsDTO dto) : base(dto)
        {
        }

        public override Bitmap Status
        {
            get { return GetImage(imageMapItems, dto.Status); }
        }

        public override Bitmap Priority
        {
            get { return GetImage(priorityImageMapItems, dto.Priority); }
        }

        public override string PriorityToolTip
        {
            get { return dto.Priority == null ? string.Empty : dto.Priority.GetName(); }
        }

        public override string StatusToolTip
        {
            get { return GetToolTip(imageMapItems, dto.Status); }
        }

        public override string When
        {
            get { return DisplayedDateTime.ToLongDateAndTimeString(); }
        }

        public override string WhoWhat
        {
            get { return dto.FunctionalLocation; }
        }

        public override bool ShowOptionalText
        {
            get { return true; }
        }

        public override string OptionalText
        {
            get { return dto.Occupation; }
        }

        public override string Text
        {
            get { return dto.Description; }
        }

        public override int CompareTo(NodeData nodeData)
        {
            WorkPermitFortHillsNodeData other = nodeData as WorkPermitFortHillsNodeData;
            if (other == null)
            {
                return 0;
            }
            // descending
            return other.DisplayedDateTime.CompareTo(DisplayedDateTime);
        }

        private DateTime DisplayedDateTime
        {
            get { return dto.RequestedOrIssuedDateTime; }
        }
    }
}
