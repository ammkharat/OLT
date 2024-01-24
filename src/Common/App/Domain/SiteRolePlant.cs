using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class SiteRolePlant : ComparableObject
    {
        private readonly long plantId;
        private readonly Role role;
        private readonly Site site;

        public SiteRolePlant(Site site, Role role, long plantId)
        {
            this.plantId = plantId;
            this.site = site;
            this.role = role;
        }

        public Site Site
        {
            get { return site; }
        }

        public Role Role
        {
            get { return role; }
        }

        public long PlantId
        {
            get { return plantId; }
        }

        public static List<long> ChoosePlantIds(Role role, List<SiteRolePlant> siteRolePlants)
        {
            return siteRolePlants.FindAll(srp => srp.Role.Id == role.Id).ConvertAll(srp => srp.PlantId).Unique();
        }
    }
}