using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Domain.PriorityPage
{
    public class MontrealCsdNodeData : NodeData<MontrealCsdDTO>
    {
        private static readonly Dictionary<FormStatus, IImageMapItem<FormStatus>> imageMapItems =
            CreateDictionary(FormStatusImageColumn.GetImageMapItems());

        public MontrealCsdNodeData(MontrealCsdDTO dto)
            : base(dto)
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

        public override string StatusToolTip
        {
            get { return GetToolTip(imageMapItems, dto.Status); }
        }

        public override string PriorityToolTip
        {
            get { return string.Empty; }
        }

        public override string When
        {
            get { return string.Empty; }
        }

        public override bool ShowOptionalText
        {
            get { return false; }
        }

        public override string WhoWhat
        {
            get { return dto.FunctionalLocationNames; }
        }

        public override string StartEndText
        {
            get { return string.Empty; }
        }

        public override string OptionalText
        {
            get
            {
                return string.Format("{0}  {1}", dto.ValidFrom.ToShortDateString(), dto.ValidTo.ToShortDateString());
            }
        }

        public override string Text
        {
            get { return BuildFormLinkText(); }
        }

        private string BuildFormLinkText()
        {
            var linkText = !string.IsNullOrEmpty(dto.CriticalSystemDefeated)
                ? string.Format("#{0} - {1}", dto.FormNumber, dto.CriticalSystemDefeated)
                : string.Format("#{0}", dto.FormNumber);

            return linkText;
        }

        public override int CompareTo(NodeData nodeData)
        {
            var other = nodeData as MontrealCsdNodeData;
            if (other == null || other.dto == null)
            {
                return 1;
            }
            // descending by ValidFrom
            return other.dto.ValidFrom.CompareTo(dto.ValidFrom);
        }
    }
}