using System;
using Com.Suncor.Olt.Common.Utility.Cache;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class VisibilityGroup : DomainObject, ICacheBySiteId
    {
        public VisibilityGroup(long? id, string name, long siteId, bool isSiteDefault)
        {
            Id = id;
            Name = name;
            SiteId = siteId;
            IsSiteDefault = isSiteDefault;
        }

        public string Name { get; set; }
        public bool IsSiteDefault { get; private set; }
        public long SiteId { get; private set; }
    }

    public enum VisibilityType
    {
        Read = 1,
        Write = 2
    }

    [Serializable]
    public class WorkAssignmentVisibilityGroup : DomainObject
    {
        public WorkAssignmentVisibilityGroup(long? id, long? workAssignmentId, long visibilityGroupId,
            string visibilityGroupName, VisibilityType visibilityType)
        {
            Id = id;
            WorkAssignmentId = workAssignmentId;
            VisibilityGroupId = visibilityGroupId;
            VisibilityGroupName = visibilityGroupName;
            VisibilityType = visibilityType;
        }

        public long? WorkAssignmentId { get; internal set; }
        public long VisibilityGroupId { get; private set; }
        public string VisibilityGroupName { get; private set; }
        public VisibilityType VisibilityType { get; private set; }
    }
}