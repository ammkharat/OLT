using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Utilities;

namespace Com.Suncor.Olt.Remote.Providers
{
    public class MockAuthenticationProvider : IAuthenticationProvider
    {
        private const string ALL_SITE_USER = "superuserall";
        private const string SUPER_USER = "superuser";
        private const string TRAINING_USER = "train";

        private readonly LdapAuthenticationProvider ldapAuthenticationProvider;
        private readonly string ldapUserName;
        private readonly string ldapPassword;

        private const string OltGroupsFile = "groups.txt";

        public MockAuthenticationProvider()
        {
            ldapAuthenticationProvider = new LdapAuthenticationProvider();
            ldapUserName = ConfigurationManager.AppSettings["MockAuthenticationProviderUserName"];
            ldapPassword = ConfigurationManager.AppSettings["MockAuthenticationProviderPassword"];
        }

        public bool IsValidActiveDirectoryLogon(string username, string password)
        {
            return true;
        }

        private string GetOltGroupsFilePath()
        {
            string root = Path.GetPathRoot(Path.GetTempPath());
            return Path.Combine(root, OltGroupsFile);
        }

        public List<IOltGroupMembership> GetOltGroupMemberships(string username, string password)
        {
            // return new List<IOltGroupMembership> { new LdapGroupMembership("CN=OLT-OilSands-1200-Supervisor,OU=Users and Groups,DC=network,DC=dev") };

            if (File.Exists(GetOltGroupsFilePath()))
            {
                return GetMembershipsFromFile(GetOltGroupsFilePath());
            }
            if (IsAllSiteUser(username))
            {
                return GetAllMemberships();
            }
            if (IsSuperUser(username))
            {
                return GetAllPossibleMemberships(username, false);
            }
            if (IsTrainingUser(username))
            {
                return GetAllPossibleMemberships(username, true);
            }
            else
            {
                List<IOltGroupMembership> memberships = ldapAuthenticationProvider.GetOltGroupMemberships(ldapUserName, ldapPassword, username);
                return memberships;                
            }
        }

        private static bool IsAllSiteUser(string username)
        {
            return username.ToLower().Contains(ALL_SITE_USER);            
        }

        private static bool IsSuperUser(string username)
        {
            return username.ToLower().Contains(SUPER_USER);
        }

        private static bool IsTrainingUser(string username)
        {
            return username.ToLower().StartsWith(TRAINING_USER);
        }

        private static List<IOltGroupMembership> GetAllMemberships()
        {
            List<IOltGroupMembership> memberships = new List<IOltGroupMembership>();

            ISiteDao siteDao = DaoRegistry.GetDao<ISiteDao>();
            IFunctionalLocationInfoDao flocDao = DaoRegistry.GetDao<IFunctionalLocationInfoDao>();
            IRoleDao roleDao = DaoRegistry.GetDao<IRoleDao>();

            List<Site> allSites = siteDao.QueryAll();
            foreach (Site site in allSites)
            {
                List<FunctionalLocationInfo> divisions = flocDao.QueryFunctionalLocationDivisionInfosBySiteId(site.IdValue);
                if (divisions.Count > 0)
                {
                    divisions.Sort((x, y) => string.Compare(y.Floc.FullHierarchy, x.Floc.FullHierarchy, StringComparison.Ordinal));
                    FunctionalLocationInfo division = divisions[0];

                    List<Role> allRoles = roleDao.QueryBySiteId(site.IdValue);
                    foreach (Role role in allRoles)
                    {
                        memberships.Add(new LdapGroupMembership(
                            string.Format("abc=-{0}-{1}-{2},def",
                            division.Floc.Site.ActiveDirectoryKey,
                            division.Floc.PlantId,
                            role.ActiveDirectoryKey)));
                    }
                }
            }

            return memberships;
        }

        private static List<IOltGroupMembership> GetAllPossibleMemberships(string username, bool getOnlyFirstMatchingRole)
        {
            List<IOltGroupMembership> memberships = new List<IOltGroupMembership>();
                
            FunctionalLocationInfo division = GetMatchingDivision(username);
            if (division != null)
            {
                List<Role> matchingRoles = GetMatchingRoles(username, division.Floc.Site);
                if (getOnlyFirstMatchingRole && matchingRoles.Count > 0)
                {
                    memberships.Add(new LdapGroupMembership(
                            string.Format("abc=-{0}-{1}-{2},def",
                            division.Floc.Site.ActiveDirectoryKey,
                            division.Floc.PlantId,
                            matchingRoles[0].ActiveDirectoryKey)));
                }
                else
                {
                    foreach (Role role in matchingRoles)
                    {
                        memberships.Add(new LdapGroupMembership(
                            string.Format("abc=-{0}-{1}-{2},def",
                            division.Floc.Site.ActiveDirectoryKey,
                            division.Floc.PlantId,
                            role.ActiveDirectoryKey)));
                    }
                }
            }

            return memberships;
        }

        private static FunctionalLocationInfo GetMatchingDivision(string username)
        {
            ISiteDao siteDao = DaoRegistry.GetDao<ISiteDao>();
            IFunctionalLocationInfoDao flocDao = DaoRegistry.GetDao<IFunctionalLocationInfoDao>();

            List<Site> allSites = siteDao.QueryAll();
            foreach (Site site in allSites)
            {
                List<FunctionalLocationInfo> divisions = flocDao.QueryFunctionalLocationDivisionInfosBySiteId(site.IdValue);

                foreach (FunctionalLocationInfo division in divisions)
                {
                    if (CanHaveDivision(username, division))
                    {
                        return division;
                    }
                }
            }
            return null;
        }

        private static List<Role> GetMatchingRoles(string username, Site site)
        {
            IRoleDao roleDao = DaoRegistry.GetDao<IRoleDao>();
            List<Role> allRoles = roleDao.QueryBySiteId(site.IdValue);
            allRoles.Sort((x,y) => y.Alias.Length.CompareTo(x.Alias.Length));

            List<Role> matchingRoles = new List<Role>();
            foreach (Role role in allRoles)
            {
                if (CanHaveRole(username, role))
                {
                    matchingRoles.Add(role);
                }
            }
            return matchingRoles;
        }

        private static bool CanHaveRole(string username, Role role)
        {
            if (IsSuperUser(username))
            {
                return true;
            }
            else if (IsTrainingUser(username))
            {
                if (username.ToLower().Contains(role.Name.ToLower().Replace(" ", "")) ||
                    username.ToLower().Contains(role.Alias.ToLower().Replace(" ", "")))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CanHaveDivision(string username, FunctionalLocationInfo division)
        {
            return username.ToLower().Contains(division.Floc.FullHierarchy.ToLower()) ||
                   username.ToLower().Contains(GetAlternateDivisionName(division.Floc.FullHierarchy));
        }

        private static string GetAlternateDivisionName(string fullHierarchy)
        {
            if (fullHierarchy == "ED1")
            {
                return "edm";
            }
            else if (fullHierarchy == "EU1")
            {
                return "energy";
            }
            else if (fullHierarchy == "MN1")
            {
                return "mining";
            }
            else if (fullHierarchy == "EX1")
            {
                return "ext";
            }
            else if (fullHierarchy == "UP2")
            {
                return "upg";
            }
            else if (fullHierarchy == "SR1")
            {
                return "sarnia";
            }
            else if (fullHierarchy == "DN1")
            {
                return "denver";
            }
            //ayman USPipeline workpermit
            else if (fullHierarchy == "USP")
            {
                return "uspipeline";
            }
            else if (fullHierarchy == "MR1")
            {
                return "mackay";
            }
            else if (fullHierarchy == "FB1")
            {
                return "firebag";
            }
            else if (fullHierarchy == "MT1")
            {
                return "mtl";
            }
            else if (fullHierarchy == "MI1")
            {
                return "mississauga";
            }    
            else if (fullHierarchy == "WBL")
            {
                return "woodbuffalo";
            }
            else if (fullHierarchy == "MP1")
            {
                return "majorprojects";
            }
            else if (fullHierarchy == "FH1")
            {
                return "forthills";
            }
            else
            {
                return fullHierarchy;
            }
        }

        public UserInformation GetUserInformation(string username, string password)
        {
            return new UserInformation("John", username, "100");
        }

        // reads from the file groups.txt located in the root drive of where the server is running (e.g. C:\, D:\, etc.)
        // each line of the groups.txt file should have a group such as OLT-OilSands-1200-Supervisor
        private List<IOltGroupMembership> GetMembershipsFromFile(string filename)
        {
            List<IOltGroupMembership> oltGroupMemberships = new List<IOltGroupMembership>();

            string line;

            StreamReader file = new StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                // line should be something like "OLT-OilSands-1200-Supervisor"
                string membershipString = String.Format("CN=#{0},OU=Users and Groups,DC=network,DC=dev", line);
                oltGroupMemberships.Add(new LdapGroupMembership(membershipString));
            }

            file.Close();

            return oltGroupMemberships;
        }
    }
}
