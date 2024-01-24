using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain
{
    public class EventSink : DomainObject
    {
        public EventSink(string clientUri, List<string> fullHierarchyList,
            List<string> workPermitEdmontonFullHierarchyList,List<string> restrictionFullHierarchyList, List<long> clientReadableVisibilityGroupIdList,
            long? siteId)
        {
            ClientUri = clientUri;
            FullHierarchyList = fullHierarchyList;
            WorkPermitEdmontonFullHierarchyList = workPermitEdmontonFullHierarchyList;
            RestrictionFullHierarchyList = restrictionFullHierarchyList;
            ClientReadableVisibilityGroupIdList = clientReadableVisibilityGroupIdList;
            SiteId = siteId;
        }

        public string ClientUri { get; private set; }

        public List<string> FullHierarchyList { get; private set; }

        public List<string> WorkPermitEdmontonFullHierarchyList { get; private set; }
        public List<string> RestrictionFullHierarchyList { get; private set; }

        public List<long> ClientReadableVisibilityGroupIdList { get; private set; }

        public long? SiteId { get; private set; }
    }
}