using System;
using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using log4net;

namespace Com.Suncor.Olt.Client.Domain.PriorityPage
{
    public class ActionItemNodeData : NodeData<ActionItemDTO>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ActionItemNodeData));

        private static readonly Dictionary<ActionItemStatus, IImageMapItem<ActionItemStatus>> imageMapItems =
            CreateDictionary(ActionItemStatusImageColumn.GetImageMapItems());

        private readonly bool displayWorkAssignment;

        public ActionItemNodeData(ActionItemDTO dto, bool displayWorkAssignment) : base(dto)
        {
            this.displayWorkAssignment = displayWorkAssignment;
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
            get { return DisplayedUser; }
        }

        private string DisplayedUser
        {
            get { return dto.FunctionalLocationNames; }
        }

        public override bool ShowOptionalText
        {
            get { return displayWorkAssignment; }
        }

        public override string OptionalText
        {
            get { return dto.WorkAssignmentName; }
        }

        public override string Text
        {
            get
            {
                try
                {
                    if (dto.DataSource.Id == DataSource.SAP.Id)
                    {
                        string description = dto.Description;
                        if (!string.IsNullOrEmpty(description))
                        {
                            description = description.Replace(StringResources.ActionItemDefinitionWorkOrderDescriptionHeader, "");
                        }
                        if (!string.IsNullOrEmpty(description))
                        {
                            description = description.TrimStart();
                        }
                        // RITM0360089 : Condition added By Vibhor
                        if (ClientSession.GetUserContext().SiteConfiguration.AllowToDisplayActionItemTitleOnPriorityPage)                        
                            return dto.Name;                        
                        //End
                        return description;
                    }
                    if (dto.DataSource.Id == DataSource.TARGET.Id)
                    {
                        string description = dto.Description;
                        if (!string.IsNullOrEmpty(description) && 
                            !string.IsNullOrEmpty(dto.Name) &&
                            !description.StartsWith(dto.Name))
                        {
                            description = dto.Name + " - " + description;
                        }
                        // RITM0360089 : Condition added By Vibhor
                        if (ClientSession.GetUserContext().SiteConfiguration.AllowToDisplayActionItemTitleOnPriorityPage)                        
                            return dto.Name;                        
                        //End
                        return description;
                    }
                    // RITM0360089 : Condition added By Vibhor
                    if (ClientSession.GetUserContext().SiteConfiguration.AllowToDisplayActionItemTitleOnPriorityPage)                    
                        return dto.Name;                     
                    //End

                    return dto.Description; 
                    
                }
                catch (Exception e)
                {
                    logger.Error(String.Format("Error trying to get action item text for Id:{0}: ", dto.Id), e);
                    return dto.Description;
                }
            }
        }

        public override int CompareTo(NodeData nodeData)
        {
            ActionItemNodeData other = nodeData as ActionItemNodeData;
            if (other == null)
            {
                return 0;
            }
            {
                // descending
                int compareResult = other.DisplayedDateTime.CompareTo(DisplayedDateTime);
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }

            {
                int compareResult = string.CompareOrdinal(DisplayedUser, other.DisplayedUser);
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }

            return string.CompareOrdinal(Text.NullToEmpty(), other.Text.NullToEmpty());
        }
    }
}
