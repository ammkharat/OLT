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
    public class WorkPermitMontrealNodeData : NodeData<WorkPermitMontrealDTO>
    {
        private static readonly Dictionary<PermitRequestBasedWorkPermitStatus, IImageMapItem<PermitRequestBasedWorkPermitStatus>> imageMapItems = 
            CreateDictionary(PermitRequestBasedWorkPermitStatusImageColumn<WorkPermitMontrealDTO>.GetImageMapItems());

        public WorkPermitMontrealNodeData(WorkPermitMontrealDTO dto) : base(dto)
        {
        }

        public override Bitmap Status
        {
            get { return GetImage(imageMapItems, dto.Status); }
        }

        public override Bitmap Priority
        {
            get { return ResourceUtils.NORMAL_PRIORITY; }
        }

        public override string PriorityToolTip
        {
            get { return String.Empty; }
        }

        public override string StatusToolTip
        {
            get { return GetToolTip(imageMapItems, dto.Status); }
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
            get { return dto.FunctionalLocationFullHierarchies; }
        }

        public override bool ShowOptionalText
        {
            get { return true; }
        }
        
        public override string OptionalText
        {
            get { return dto.Trade; }
        }

        public override string Text
        {
            get { return dto.Description; }
        }

        public override int CompareTo(NodeData nodeData)
        {
            WorkPermitMontrealNodeData other = nodeData as WorkPermitMontrealNodeData;
            if (other == null)
            {
                return 0;
            }
            // descending
            return other.DisplayedDateTime.CompareTo(DisplayedDateTime);
        }

    }
}
