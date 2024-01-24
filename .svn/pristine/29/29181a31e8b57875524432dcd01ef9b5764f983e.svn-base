using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Utility.Cache;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class AreaLabel : DomainObject, IHasDisplayOrder, ICacheBySiteId
    {
        public static readonly AreaLabel EMPTY = new AreaLabel(null, string.Empty, 0, 0, true, null);

        private readonly long siteId;
        private bool allowManualSelection;
        private int displayOrder;
        private string name;
        private string sapPlannerGroup;

        public AreaLabel(long? id, string name, long siteId, int displayOrder, bool allowManualSelection,
            string sapPlannerGroup)
        {
            this.id = id;
            this.name = name;
            this.siteId = siteId;
            this.displayOrder = displayOrder;
            this.allowManualSelection = allowManualSelection;
            this.sapPlannerGroup = sapPlannerGroup;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool AllowManualSelection
        {
            get { return allowManualSelection; }
            set { allowManualSelection = value; }
        }

        public string SapPlannerGroup
        {
            get { return sapPlannerGroup; }
            set { sapPlannerGroup = value; }
        }

        public long SiteId
        {
            get { return siteId; }
        }

        public int DisplayOrder
        {
            get { return displayOrder; }
            set { displayOrder = value; }
        }

        public static List<AreaLabel> ManuallySelectableAreaLabels(AreaLabel selectedAreaLabel,
            List<AreaLabel> areaLabels)
        {
            return
                areaLabels.FindAll(
                    al => al.AllowManualSelection || (selectedAreaLabel != null && al.Id == selectedAreaLabel.Id));
        }
    }
}