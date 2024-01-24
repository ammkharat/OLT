using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain
{
    public interface IFunctionalLocationRelevant
    {
        bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies, List<string> workPermitEdmontonFullHierarchies, List<string> restrictionFullHierarchies,SiteConfiguration siteConfiguration);
    }

    /// <summary>
    ///     Domain Object is relevant if the clients's floc is a Parent (Ancestor) of the Domain Object's Floc
    ///     Another way of saying it,  Domain Object is relevant if its Floc is a child (Descendent) of the client's floc
    /// </summary>
    public class WalkDownRelevance
    {
        private readonly FunctionalLocation functionalLocationOfDomainObject;

        public WalkDownRelevance(FunctionalLocation functionalLocationOfDomainObject)
        {
            this.functionalLocationOfDomainObject = functionalLocationOfDomainObject;
        }

        public bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies)
        {
            if (functionalLocationOfDomainObject.Site.IdValue != siteIdOfClient)
                return false;

            foreach (var clientFullHierarchy in clientFullHierarchies)
            {
                if (functionalLocationOfDomainObject.IsChildOf(clientFullHierarchy, siteIdOfClient))
                    return true;
            }
            return false;
        }
    }

    /// <summary>
    ///     Domain Object is relevant if its floc is a Parent (Ancestor) of the Client Flocs
    ///     Another way of saying it,  Domain Object is relevant if the client's Floc is a child (Descendent) of the domain
    ///     object's floc.
    /// </summary>
    public class WalkUpRelevance
    {
        private readonly FunctionalLocation functionalLocationOfDomainObject;

        public WalkUpRelevance(FunctionalLocation functionalLocationOfDomainObject)
        {
            this.functionalLocationOfDomainObject = functionalLocationOfDomainObject;
        }

        public bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies)
        {
            if (functionalLocationOfDomainObject.Site.IdValue != siteIdOfClient)
                return false;

            foreach (var clientFullHierarchy in clientFullHierarchies)
            {
                if (functionalLocationOfDomainObject.IsParentOf(clientFullHierarchy, siteIdOfClient))
                    return true;
            }
            return false;
        }
    }

    /// <summary>
    ///     Domain Object is only relevant if it's Functional Location is a exact match to one of the Client Flocs
    /// </summary>
    public class ExactMatchRelevance
    {
        private readonly FunctionalLocation functionalLocationOfDomainObject;

        public ExactMatchRelevance(FunctionalLocation functionalLocationOfDomainObject)
        {
            this.functionalLocationOfDomainObject = functionalLocationOfDomainObject;
        }

        public bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies)
        {
            if (functionalLocationOfDomainObject.Site.IdValue != siteIdOfClient)
                return false;

            return
                clientFullHierarchies.Exists(
                    clientFloc =>
                        string.Equals(functionalLocationOfDomainObject.FullHierarchy, clientFloc,
                            StringComparison.Ordinal));
        }
    }
}