using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class ConfiguredDocumentLink : DomainObject, IHasDisplayOrder
    {
        public ConfiguredDocumentLink(long? id, string title, string link, ConfiguredDocumentLinkLocation location,
            int displayOrder)
        {
            Id = id;
            Title = title;
            Link = link;
            Location = location;
            DisplayOrder = displayOrder;
        }

        public string Title { get; set; }
        public string Link { get; set; }
        public ConfiguredDocumentLinkLocation Location { get; private set; }
        public int DisplayOrder { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }

    [Serializable]
    public class ConfiguredDocumentLinkLocation : DomainObject
    {
        public static readonly ConfiguredDocumentLinkLocation WorkPermitMontreal =
            new ConfiguredDocumentLinkLocation(Site.MONTREAL_ID, "WorkPermitMontreal", "Permis de travail");

        public static readonly ConfiguredDocumentLinkLocation ConfinedSpaceMontreal =
            new ConfiguredDocumentLinkLocation(Site.MONTREAL_ID, "ConfinedSpaceMontreal", "Espace clos");

        public static readonly ConfiguredDocumentLinkLocation WorkPermitEdmonton =
            new ConfiguredDocumentLinkLocation(Site.EDMONTON_ID, "WorkPermitEdmonton", "Work Permit");
       // DMND0009632 - Fort Hills OLT - E-Permit Development 
        public static readonly ConfiguredDocumentLinkLocation WorkPermitFortHills =
           new ConfiguredDocumentLinkLocation(Site.FORT_HILLS_ID, "WorkPermitFortHills", "Work Permit");

        public static readonly ConfiguredDocumentLinkLocation WorkPermitLubes =
            new ConfiguredDocumentLinkLocation(Site.LUBES_ID, "WorkPermitLubes", "Work Permit");

        //RITM0301321 mangesh
        public static readonly ConfiguredDocumentLinkLocation WorkPermitMuds =
            new ConfiguredDocumentLinkLocation(Site.MontrealSulphur_ID, "WorkPermitMuds", "Permis de travail");

        public static readonly ConfiguredDocumentLinkLocation ConfinedSpaceMuds =
            new ConfiguredDocumentLinkLocation(Site.MontrealSulphur_ID, "ConfinedSpaceMuds", "Espace clos");

        private static readonly List<ConfiguredDocumentLinkLocation> AllLocations =
            new List<ConfiguredDocumentLinkLocation>
            {
                WorkPermitMontreal,
                ConfinedSpaceMontreal,
                WorkPermitEdmonton,
                WorkPermitLubes,
                WorkPermitMuds,  //RITM0301321 mangesh
                ConfinedSpaceMuds
            };

        private readonly long siteId;

        private ConfiguredDocumentLinkLocation(long siteId, string locationName, string displayName)
        {
            this.siteId = siteId;
            DisplayName = displayName;
            LocationName = locationName;
        }

        public string LocationName { get; private set; }
        public string DisplayName { get; private set; }

        public static List<ConfiguredDocumentLinkLocation> AllLocationsForSite(long siteId)
        {
            return AllLocations.FindAll(location => location.siteId == siteId);
        }

        public static ConfiguredDocumentLinkLocation FromName(string locationName)
        {
            return AllLocations.Find(location => location.LocationName == locationName);
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}