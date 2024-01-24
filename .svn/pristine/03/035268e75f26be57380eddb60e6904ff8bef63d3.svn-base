using System;
using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Domain.PriorityPage
{
    public class TargetAlertNodeData : NodeData<TargetAlertDTO>
    {
        private static readonly Dictionary<TargetAlertStatus, IImageMapItem<TargetAlertStatus>> imageMapItems =
            CreateDictionary(TargetAlertStatusImageColumn.GetImageMapItems());

        private static readonly Dictionary<Priority, IImageMapItem<Priority>> priorityImageMapItems =
            CreateDictionary(
                PriorityImageColumn<TargetAlertDTO>.GetImageMapItems(new List<Priority>(TargetDefinition.Priorities)));

        public TargetAlertNodeData(TargetAlertDTO dto) : base(dto)
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
            get { return GetImage(priorityImageMapItems, dto.Priority); }
        }

        public override string PriorityToolTip
        {
            get { return GetToolTip(priorityImageMapItems, dto.Priority); }
        }

        public override string When
        {
            get { return DisplayedDateTime.ToLongDateAndTimeString(); }
        }

        private DateTime DisplayedDateTime
        {
            get { return dto.CreatedDateTime; }
        }

        public override string WhoWhat
        {
            get { return dto.FunctionalLocationName; }
        }

        public override bool ShowOptionalText
        {
            get { return true; }
        }

        public override bool ShowSecondaryWhoWhat
        {
            get { return false; }
        }

        public override string OptionalText
        {
            get { return dto.WorkAssignmentName; }
        }

        public override string StartEndText
        {
            get { return dto.TargetName; }
        }

        public override string Text
        {
            get
            {
                return String.Format(
                    "{0}: {1}; {2}: {3}; {4}",
                    RendererStringResources.Target, dto.TargetValue,
                    RendererStringResources.Actual, dto.ActualValue.Format(),
                    dto.Description);
            }
        }

        public override int CompareTo(NodeData nodeData)
        {
            var other = nodeData as TargetAlertNodeData;
            if (other == null)
            {
                return 0;
            }
            // descending
            return other.DisplayedDateTime.CompareTo(DisplayedDateTime);
        }
    }
}