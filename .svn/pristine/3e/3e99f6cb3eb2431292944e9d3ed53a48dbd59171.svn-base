using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Remote.Providers;
using Com.Suncor.Olt.Remote.Utilities;

namespace RoleReport
{
    internal class Builder
    {
        private const int batchSize = 100;
        private const string fileName = "UsersAndRoles.csv";

        private readonly string activeDirectoryUsername;
        private readonly string activeDirectoryPassword;
        private readonly string domain;
        private readonly string path;

        public Builder(string activeDirectoryUsername, string activeDirectoryPassword, string domain, string path)
        {
            this.activeDirectoryUsername = activeDirectoryUsername;
            this.activeDirectoryPassword = activeDirectoryPassword;
            this.domain = domain;
            this.path = path;
        }

        public string Build(string username)
        {
            LdapAuthenticationProvider ldapAuthenticationProvider = CreateLdapAuthenticationProvider();
            List<IOltGroupMembership> oltGroupMemberships = ldapAuthenticationProvider.GetOltGroupMemberships(
                activeDirectoryUsername, activeDirectoryPassword, username);

            StringBuilder sb = new StringBuilder();
            foreach (IOltGroupMembership oltGroupMembership in oltGroupMemberships)
            {
                sb.Append(oltGroupMembership.SiteIdentifier);
                sb.Append(" ");
                sb.Append(oltGroupMembership.PlantId);
                sb.Append(" ");
                sb.Append(oltGroupMembership.RoleIdentifier);
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public void Build()
        {
            LdapAuthenticationProvider ldapAuthenticationProvider = CreateLdapAuthenticationProvider();
            List<string> allUsernames = ldapAuthenticationProvider.GetAllUsersWithOltRoles(activeDirectoryUsername,
                                                                                           activeDirectoryPassword);

            File.Delete(fileName);
            CreateFileHeader();

            allUsernames.ForEachSlice(batchSize, usernames =>
               {
                   Dictionary<string, List<IOltGroupMembership>> setsOfMemberships = GetMembershipsFromActiveDirectory(usernames);

                   using (StreamWriter sw = File.AppendText(fileName))
                   {
                       foreach (string username in usernames)
                       {
                           List<IOltGroupMembership> memberships = FindMembershipInDictionary(setsOfMemberships, username);
                           WriteUserToFile(username, memberships, sw);
                       }
                       sw.Close();
                   }
               });
        }

        private void WriteUserToFile(string username, List<IOltGroupMembership> memberships, StreamWriter sw)
        {
            if (memberships.Count == 0)
            {
                sw.WriteLine(String.Format("{0},{1},{2},{3}", username, string.Empty, string.Empty, string.Empty));
            }
            else
            {
                Dictionary<long, List<IOltGroupMembership>> membershipsGroupedByPlantId = memberships.GroupUsing(x => x.PlantId);
                foreach (long plantId in membershipsGroupedByPlantId.Keys)
                {
                    List<IOltGroupMembership> membershipsForPlant = membershipsGroupedByPlantId[plantId];

                    List<string> roles = membershipsForPlant.ConvertAll(m => m.RoleIdentifier);
                    string siteIdentifier = membershipsForPlant[0].SiteIdentifier;

                    sw.WriteLine(String.Format("{0},{1},{2},\"{3}\"", username, siteIdentifier, plantId, roles.Join(",")));
                }
            }
        }

        private void CreateFileHeader()
        {
            using (StreamWriter sw = File.CreateText(fileName))
            {
                sw.WriteLine("Username,Last Name,First Name,Site,Plant,Roles");
                sw.Close();
            }
        }

        private List<IOltGroupMembership> FindMembershipInDictionary(Dictionary<string, List<IOltGroupMembership>> setsOfMemberships, string fullname)
        {
            string username = fullname.Split(',')[0];
            string usernameKey = setsOfMemberships.Keys.Find(adUsername => adUsername.ToLower() == username.ToLower());
            if (usernameKey == null)
            {
                return new List<IOltGroupMembership>();
            }
            return setsOfMemberships[usernameKey];
        }

        private Dictionary<string, List<IOltGroupMembership>> GetMembershipsFromActiveDirectory(List<string> batchOfNames)
        {
            List<string> batchOfUsernames = batchOfNames.ConvertAll(obj => obj.Split(',')[0]);
            LdapAuthenticationProvider ldapAuthenticationProvider = CreateLdapAuthenticationProvider();
            Dictionary<string, List<IOltGroupMembership>> oltGroupMemberships =
                ldapAuthenticationProvider.GetOltGroupMemberships(activeDirectoryUsername, activeDirectoryPassword,
                                                                  batchOfUsernames);
            return oltGroupMemberships;
        }

        private LdapAuthenticationProvider CreateLdapAuthenticationProvider()
        {
            return new LdapAuthenticationProvider(path, domain);
        }
    }
}
