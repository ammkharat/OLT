using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class AdministratorList : DomainObject
    {
        public AdministratorList( string siteName, string group, string siteRepresntative, string siteAdmin, string bea)
        {
            SiteName = siteName;
            Group = group;
            SiteRepresentative = siteRepresntative;
            SiteAdmin = siteAdmin;
            BEA = bea;
        }


        public string SiteName { get; set; }
        public string Group { get; set; }
        public string SiteRepresentative { get; set; }
        public string SiteAdmin { get; set; }
        public string BEA { get; set; }
       
    }
}