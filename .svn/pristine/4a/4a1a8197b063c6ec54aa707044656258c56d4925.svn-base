using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Domain.PriorityPage
{
    public class ProcedureDeviationNodeData : NodeData<ProcedureDeviationDTO>
    {
        private static readonly Dictionary<FormStatus, IImageMapItem<FormStatus>> imageMapItems = CreateDictionary(ProcedureDeviationFormStatusImageColumn.GetImageMapItems());

        private ProcedureDeviationDTO dto;

        public ProcedureDeviationNodeData(ProcedureDeviationDTO dto)
            : base(dto)
        {
            this.dto = dto;
        }

        public ProcedureDeviationDTO Dto
        {
            get { return dto; }
        }

        public override Bitmap Status
        {
            get { return GetImage(imageMapItems, dto.GetStatusForDisplay()); }
        }

        public override Bitmap Priority
        {
            get { return ResourceUtils.NORMAL_PRIORITY; }
        }

        public override string StatusToolTip
        {
            get { return GetToolTip(imageMapItems, dto.GetStatusForDisplay()); }
        }

        public override string PriorityToolTip
        {
            get { return string.Empty; }
        }

        public override string When
        {
            get { return dto.CreatedDateTime.ToLongDateAndTimeString(); }
        }

        public override bool ShowOptionalText
        {
            get { return true; }
        }

        public override string WhoWhat
        {
            get
            {
                return dto.FunctionalLocationNames;
            }
        }

        public override string StartEndText
        {
            get
            {
                return dto.CreatedByFullName.IsNullOrEmptyOrWhitespace() ? "Unknown" : dto.CreatedByFullName;
            }
        }

        public override string OptionalText
        {
            get
            {
                return dto.CreatedByFullName;
            }
        }

        public override string Text
        {
            get { return BuildFormLinkText(); }
        }

        private string BuildFormLinkText()
        {
            return string.Format("# {0} - ({1}) {2}", dto.FormNumber, dto.OperatingProcedureNumber, dto.OperatingProcedureTitle);
        }

        public EdmontonFormType FormType
        {
            get { return dto.FormType; }
        }

        public override int CompareTo(NodeData nodeData)
        {
            ProcedureDeviationNodeData other = nodeData as ProcedureDeviationNodeData;
            if (other == null || other.dto == null)
            {
                return 1;
            }
            // descending by ValidFrom
            return other.dto.CreatedDateTime.CompareTo(dto.CreatedDateTime);
        }
    }
}