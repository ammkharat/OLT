using System;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public class LdapGroupMembership : IOltGroupMembership
    {
        private long plantId;
        private string siteIdentifier;
        private string roleIdentifier;

        public LdapGroupMembership(string oltGroupMembershipString)
        {
            SplitGroupMembership(oltGroupMembershipString);
        }

        public long PlantId
        {
            get { return plantId; }
        }

        public string SiteIdentifier
        {
            get { return siteIdentifier; }
        }

        public string RoleIdentifier
        {
            get { return roleIdentifier; }
        }

        private void SplitGroupMembership(string oltGroupMembershipString)
        {
            int indexOfFirstEquals = oltGroupMembershipString.IndexOf("=", StringComparison.Ordinal);
            string cnFieldStartingAfterFirstEquals = oltGroupMembershipString.Substring(indexOfFirstEquals + 1);
            int indexOfFirstComma = cnFieldStartingAfterFirstEquals.IndexOf(",", StringComparison.Ordinal);
            string cnField = cnFieldStartingAfterFirstEquals.Substring(0, indexOfFirstComma);

            string[] pieces = cnField.Split('-');

            siteIdentifier = pieces[1];
            plantId = Convert.ToInt64(pieces[2]);
            //To chnag a PlantId from OLT as 999 to "9999-ConstructionManagement-999-technicaladmin"
            if (siteIdentifier.ToUpper() == "ConstructionManagement".ToUpper())
            {
                plantId = 9999;
            }
            roleIdentifier = pieces[3];
        }
 
    }
}
