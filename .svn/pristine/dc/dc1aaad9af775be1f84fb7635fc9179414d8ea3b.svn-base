using System;
using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Domain.PriorityPage
{
    public class FormSarniaNodeData : NodeData<FormEdmontonGN75BDTO>
    {
        private static readonly Dictionary<FormStatus, IImageMapItem<FormStatus>> imageMapItems = CreateDictionary(FormStatusImageColumn.GetImageMapItems());

        public FormSarniaNodeData(FormEdmontonGN75BDTO dto)
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
                return dto.FunctionalLocation;
            }
        }

        public override string StartEndText
        {
            get { return String.Empty; }
            //  string.Format("{0}  {1}", dto.ValidFrom.ToShortDateString(), dto.ValidTo.ToShortDateString()); }
        }

        public override string OptionalText
        {
            // Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
             get{
                if (dto.Location == null)
                {
                    return string.Format("{0} #{1}", dto.FormType, dto.FormNumber); ////RITM0465936:EN50 : OLT:: Sarnia : Priorities page changes:Aarti
                }
                else
                {
                    return string.Format("{0} #{1} - {2}", dto.FormType, dto.FormNumber, dto.Location); ////RITM0465936:EN50 : OLT:: Sarnia : Priorities page changes:Aarti
                }
            }
            
        }

        public override string Text
        {
            // Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
            get
            {
                return String.Empty; // dto.RemainingApprovalsString;
            }

            // get { return string.Format("{0} #{1}#{2}", dto.FormType.Name, dto.FormNumber, dto.Location); } ////RITM0465936:EN50 : OLT:: Sarnia : Priorities page changes:Aarti
           
        }

        public EdmontonFormType FormType
        {
            get { return dto.FormType; }
        }

        public override int CompareTo(NodeData nodeData)
        {
            FormSarniaNodeData other = nodeData as FormSarniaNodeData;
            if (other == null || other.dto == null)
            {
                return -1;
            }
            // ascending by Valid From
            return 0; // dto.ValidFrom.CompareTo(other.dto.ValidFrom);
        }
    }
}