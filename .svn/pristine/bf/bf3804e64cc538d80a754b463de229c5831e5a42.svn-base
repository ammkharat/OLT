using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Domain.PriorityPage
{
    public class FormOilsandsNodeData : NodeData<FormOilsandsPriorityPageDTO>
    {
        
        private static readonly Dictionary<FormStatus, IImageMapItem<FormStatus>> imageMapItems = CreateDictionary(FormStatusImageColumn.GetImageMapItems());

        public FormOilsandsNodeData(FormOilsandsPriorityPageDTO dto)
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

        public override Bitmap SecondaryStatus
        {
            get
            {
                if (dto.IsOutsideIdealNumberOfHours && ClientSession.GetUserContext().IsOilsandsSite)             //ayman forthills trainging form flag
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
                if (dto.IsOutsideIdealNumberOfHours)
                {
                    return StringResources.FormOilsandsTraining_HoursWarning;
                }

                return string.Empty;
            }
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
            get { return dto.CreatedDateTime.ToLongDateAndTimeString(); }
        }

        public override bool ShowOptionalText
        {
            get { return true; }
        }

        public override string WhoWhat
        {
            get { return dto.FunctionalLocationNames; }
        }

        public override string StartEndText
        {
            get { return string.Format("{0} - {1}", dto.TrainingDate.ToDateTimeAtStartOfDay().ToShortDateString(), dto.ShiftName); }
        }

        public override string OptionalText
        {
            get { return dto.CreatedByNameAndWorkAssignment; }
        }

        public override string Text
        {
            get { return string.Format("{0} #{1} ({2} hours)", dto.FormType, dto.FormNumber.GetValueOrDefault(0), dto.TotalHours.Format()); }
        }

        internal OilsandsFormType FormType
        {
            get { return dto.FormType; }
        }

        public override int CompareTo(NodeData nodeData)
        {
            FormOilsandsNodeData other = nodeData as FormOilsandsNodeData;
            if (other == null || other.dto == null)
            {
                return -1;
            }
            // ascending by Training Date
            return dto.TrainingDate.CompareTo(other.dto.TrainingDate);
        }
    }
}