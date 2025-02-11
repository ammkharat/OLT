using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Domain.PriorityPage
{
    public class FormOP14NodeData : NodeData<FormEdmontonOP14DTO>
    {
        
        private static readonly Dictionary<FormStatus, IImageMapItem<FormStatus>> imageMapItems = CreateDictionary(FormStatusImageColumn.GetImageMapItems());

        public FormOP14NodeData(FormEdmontonOP14DTO dto) : base(dto)
        {
        }

        public override Bitmap Status
        {
            get { return GetImage(imageMapItems, dto.Status); }
        }

//Added By Vibhor : RITM0613645 : OLT - Mark as read tick mark for sarnia CSD

        public override Bitmap SecondaryStatus
        {
            get
            {
                if (dto.MarkAsReadCSD)
                {
                    return ResourceUtils.READ;
                }

                return ResourceUtils.UNREAD;
            }
        }

        public override string SecondaryStatusToolTip
        {
            get
            {
                if (dto.MarkAsReadCSD)
                {
                    return "Read";
                }
                else
                {
                    return "UnRead"; 
                }

                
            }
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
             get { return string.Format("{0}-{1}", dto.ValidFrom.ToShortDateString(), dto.ValidTo.ToShortDateString()); } //RITM0465936:EN50 : OLT:: Sarnia : Priorities page changes:Aarti
            
        }

        public override bool ShowOptionalText
        {
            get { return true; }
           
        }
        

        public override string WhoWhat
        {
            get { return string.Format(" {0} ", dto.FunctionalLocationNames); }
        }

        public override string StartEndText
        {
            get { return string.Empty; }
          //  get { return string.Format("{0}", dto.RemainingApprovalsString); }  
            
        }

        public override string OptionalText
        {
            get
            {
                // If condition Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
                if (ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
                {
                    return BuildFormLinkText();
                }
                else
                {
                    return string.Format("{0}", dto.RemainingApprovalsString);   
                }
                
            }


           // get { return string.Empty; }
           // get { return string.Format("{0}", dto.RemainingApprovalsString); }  
           // get { return string.Format("{0}  {1}", dto.ValidFrom.ToShortDateString(), dto.ValidTo.ToShortDateString()); } //RITM0465936:EN50 : OLT:: Sarnia : Priorities page changes:Aarti
        }

        public override string Text
        {
            

            get
            {
                // If condition Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
                if (ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
                {
                    return string.Format("{0}", dto.RemainingApprovalsString);
                }
                else
                {
                    return BuildFormLinkText();
                }
                
            }  
        }

        //RITM0465936:EN50 : OLT:: Sarnia : Priorities page changes:Aarti
        private string BuildFormLinkText()
        {
            string linkText;
            if (dto.CriticalSystemDefeated== null)
            {
                 linkText = string.Format("#{0}", dto.FormNumber);
            }
            else if (dto.CriticalSystemDefeated.Length > 35)
            {
                if (ClientSession.GetUserContext().Site.Id == Site.EDMONTON_ID) //Added by Vibhor : RITM0565862 - Op14 form on priority page changes for Edmonton 
                {
                    linkText = string.Format("#{0} - {1}", dto.FormNumber, dto.CriticalSystemDefeated);
                }
                else
                {
                    linkText = string.Format("#{0} - {1}", dto.FormNumber, dto.CriticalSystemDefeated.Remove(35));
                }
                
            }
            else
            {
                 linkText = string.Format("#{0} - {1}", dto.FormNumber, dto.CriticalSystemDefeated);
            }
            //string linkText = !string.IsNullOrEmpty(dto.CriticalSystemDefeated)
            //    ? string.Format("#{0} - {1}", dto.FormNumber, dto.CriticalSystemDefeated)
            //    : string.Format("#{0}", dto.FormNumber);

            return linkText;
        }

        public override int CompareTo(NodeData nodeData)
        {
            FormOP14NodeData other = nodeData as FormOP14NodeData;
            if (other == null || other.dto == null)
            {
                return 1;
            }
            // descending by ValidFrom
            return other.dto.ValidFrom.CompareTo(dto.ValidFrom);
        }
    }
}