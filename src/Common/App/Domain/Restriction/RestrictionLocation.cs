using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.Restriction
{
    [Serializable]
    public class RestrictionLocation : ModifiableDomainObject
    {
        private readonly List<long> removedItems = new List<long>();

        public RestrictionLocation(long id, string name, List<WorkAssignment> workAssignments, User lastModifiedBy,
            DateTime lastModifiedDateTime,long siteid) : this(name, workAssignments, lastModifiedBy, lastModifiedDateTime,siteid)            //ayman restriction location
        {
            this.id = id;
        }

        public RestrictionLocation(string name, List<WorkAssignment> workAssignments, User lastModifiedBy,
            DateTime lastModifiedDateTime,long siteid) : base(lastModifiedBy, lastModifiedDateTime)              //ayman restriction location
        {
            Name = name;
            WorkAssignments = workAssignments;
            LocationItems = new List<RestrictionLocationItem>();
            SiteID = siteid;                         //ayman restriction location
        }

        public string Name { get; set; }
        public List<WorkAssignment> WorkAssignments { get; set; }
        public List<RestrictionLocationItem> LocationItems { get; private set; }

        public long SiteID { get; set; }      //ayman restriction location

        public List<long> RemovedItems
        {
            get { return removedItems; }
        }

        public void AddLocationItem(RestrictionLocationItem restrictionLocationItem)
        {
            LocationItems.Add(restrictionLocationItem);
        }

        public void RemoveLocationItem(RestrictionLocationItem restrictionLocationItem)
        {
            LocationItems.RemoveById(restrictionLocationItem);
            removedItems.Add(restrictionLocationItem.IdValue);
        }

        public void SortLocationItems()
        {
            LocationItems = LocationItems.OrderBy(x => x.ParentItemId).ThenBy(y => y.Name).ToList();
        }
    }
}