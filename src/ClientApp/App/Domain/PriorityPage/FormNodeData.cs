using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Domain.PriorityPage
{
    public class FormNodeData : NodeData<FormEdmontonDTO>
    {
        private static readonly Dictionary<FormStatus, IImageMapItem<FormStatus>> imageMapItems = CreateDictionary(FormStatusImageColumn.GetImageMapItems());

        public FormNodeData(FormEdmontonDTO dto) : base(dto)
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
                return dto.FunctionalLocationNames;
            }
        }

        public override string StartEndText
        {
            get
            {
                if (dto.FormType.Equals(EdmontonFormType.GN75BSarniaEIP))
                    return string.Empty;
                return string.Format("{0}  {1}", dto.ValidFrom.ToShortDateString(), dto.ValidTo.ToShortDateString());
            }
        }

        public override string OptionalText
        {
            get
            {
                // If condition Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
                if (ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
                {
                    if (dto.FormType.Equals(EdmontonFormType.TemporaryInstallationsMuds))
                    {
                        return string.Format("#{0} - {1}", dto.FormNumber, ((TemporaryInstallationsMudsDTO)(dto)).CriticalSystemDefeated);
                    }
                    else
                    {
                        if (dto.Location == null)
                        {
                            return string.Format("{0} #{1}", dto.FormType, dto.FormNumber); 
                        }
                        else
                        {
                            return string.Format("{0} #{1} - {2}", dto.FormType, dto.FormNumber, dto.Location); 
                        }
                    }
                }
                else
                {
                     return dto.RemainingApprovalsString;
                }
            }
        }

        

        public override string Text
        {
            get
            {
                // If condition Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
                if (ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
                {
                    if (dto.ApprovedDateTime == null && FormType.Name == "EIP Issue") // If condition Added By Vibhor : RITM0567942 OLT - To Show Waiting for approver list for EIP Issue Form on Priority page for Sarnia Site
                    {
                        return "Click Here to Approve";
                    }
                    else
                    {
                        return dto.RemainingApprovalsString;
                    }
                    
                }
                else
                {
                    //changed by ppanigrahi-TASK0428706
                    if (dto.FormType.Equals(EdmontonFormType.TemporaryInstallationsMuds))
                    {
                        //return string.Format("{0}", ((TemporaryInstallationsMudsDTO)(dto)).CriticalSystemDefeated);
                        return string.Format("#{0} - {1}", dto.FormNumber,
                            ((TemporaryInstallationsMudsDTO)(dto)).CriticalSystemDefeated);
                    }
                    else
                    {
                        if (dto.Location == null)
                        {
                            return string.Format("{0} #{1}", dto.FormType, dto.FormNumber);
                            ////RITM0465936:EN50 : OLT:: Sarnia : Priorities page changes:Aarti
                        }
                        else
                        {
                            return string.Format("{0} #{1} - {2}", dto.FormType, dto.FormNumber, dto.Location);
                            ////RITM0465936:EN50 : OLT:: Sarnia : Priorities page changes:Aarti
                        }
                    }
                }



            }
        }

        public EdmontonFormType FormType
        {
            get { return dto.FormType; }
        }

       
        public override int CompareTo(NodeData nodeData)
        {
            FormNodeData other = nodeData as FormNodeData;
            if (other == null || other.dto == null)
            {
                return -1;
            }
            // ascending by Valid From
            return dto.ValidFrom.CompareTo(other.dto.ValidFrom);
        }
    }
}