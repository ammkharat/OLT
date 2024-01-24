using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Remote.Utilities;

namespace Com.Suncor.Olt.Remote.Providers
{
    public class LdapAuthenticationProvider : IAuthenticationProvider
    {
        private readonly string path;
        private readonly string domain;

        private const string SITE_PLANT_ROLE_LDAP_KEY = "memberOf";
        private const string LAST_NAME_LDAP_KEY = "sn";
        private const string FIRST_NAME_LDAP_KEY = "givenName";
        private const string SAP_NUMBER_LDAP_KEY = "employeeNumber";
        private const string USERNAME_LDAP_KEY = "sAMAccountName";
        private const string DISTINGUISHED_NAME_LDAP_KEY = "distinguishedName";

        public LdapAuthenticationProvider() : this(ConfigurationManager.AppSettings["LDAP_PATH"], ConfigurationManager.AppSettings["LDAP_USER_DOMAIN"])
        {
        }

        public LdapAuthenticationProvider(string path, string domain)
        {
            this.path = path;
            this.domain = domain;
        }

        public bool IsValidActiveDirectoryLogon(string username, string password)
        {
            return IsValidActiveDirectoryLogon(username, password, AuthenticationTypes.Delegation | AuthenticationTypes.Secure);
        }

        private DirectoryEntry GetDirectoryEntry(string username, string password,
                                                 AuthenticationTypes types)
        {
            string userAndDomain = domain + @"\" + username;

            return types == AuthenticationTypes.None
                       ? new DirectoryEntry(path, userAndDomain, password)
                       : new DirectoryEntry(path, userAndDomain, password, types);
        }

        private bool IsValidActiveDirectoryLogon(string username, string password,
                                                AuthenticationTypes types)
        {
            using (DirectoryEntry entry = GetDirectoryEntry(username, password, types))
            {
                try
                {
                    // Bind to the native AdsObject to force authentication.
                    object obj = entry.NativeObject;

                    var search = new DirectorySearcher(entry) { Filter = UsernameFilter(username) };
                    search.PropertiesToLoad.Add("cn");
                    SearchResult result = search.FindOne();

                    if (null == result)
                    {
                        return false;
                    }
                }
                catch (Exception) // exception is ignored.
                {
                    return false;
                }
            }
            return true;
        }

        public List<IOltGroupMembership> GetOltGroupMemberships(string username, string password)
        {
            return GetOltGroupMemberships(username, password, username);
        }

        public List<IOltGroupMembership> GetOltGroupMemberships(string username, string password, string usernameToFindMembershipsOf)
        {
            Dictionary<string, List<IOltGroupMembership>> oltGroupMemberships = GetOltGroupMemberships(username, password, new List<string> { usernameToFindMembershipsOf });
            if (!oltGroupMemberships.ContainsKey(usernameToFindMembershipsOf))
            {
                return new List<IOltGroupMembership>();
            }
            else
            {
                return oltGroupMemberships[usernameToFindMembershipsOf] ?? new List<IOltGroupMembership>();
            }
        }

        public Dictionary<string, List<IOltGroupMembership>> GetOltGroupMemberships(string username, string password, List<string> usernamesToFindMembershipsOf)
        {
            Dictionary<string, List<IOltGroupMembership>> oltGroupsMap = new Dictionary<string, List<IOltGroupMembership>>(StringComparer.InvariantCultureIgnoreCase);

            using (DirectoryEntry entry = GetDirectoryEntry(username, password, AuthenticationTypes.Delegation | AuthenticationTypes.Secure))
            {
                SearchResultCollection results = GetEntriesForAccounts(entry, usernamesToFindMembershipsOf, SITE_PLANT_ROLE_LDAP_KEY);

                if (results == null)
                {
                    return oltGroupsMap;
                }

                foreach (SearchResult result in results)
                {
                    if (result.Properties.Contains(USERNAME_LDAP_KEY.ToLower()) && result.Properties.Contains(SITE_PLANT_ROLE_LDAP_KEY.ToLower()))
                    {
                        List<IOltGroupMembership> groupMemberships = new List<IOltGroupMembership>();

                        ResultPropertyValueCollection resultPropertyValueCollection = result.Properties[USERNAME_LDAP_KEY];
                        string sAMAccountName = (string)resultPropertyValueCollection[0];

                        resultPropertyValueCollection = result.Properties[SITE_PLANT_ROLE_LDAP_KEY];
                        foreach (object item in resultPropertyValueCollection)
                        {
                            string membership = (string)item;
                            if (membership.StartsWith("CN=OLT-"))
                            {
                                groupMemberships.Add(new LdapGroupMembership(membership));
                            }
                        }

                        oltGroupsMap.Add(sAMAccountName, groupMemberships);
                    }
                }
            }

            return oltGroupsMap;
        }

        private string UsernameFilter(string username)
        {
            return String.Format("({0}={1})", USERNAME_LDAP_KEY, username);
        }

        private SearchResultCollection GetEntriesForAccounts(DirectoryEntry entry, List<string> usernames, params string[] propertiesToLoad)
        {
            string filter = "(|" +
                            usernames.ConvertAll(username => UsernameFilter(username)).AsString(
                                "", str => str) +
                            ")";

            var search = new DirectorySearcher(entry) { Filter = filter };
            search.PropertiesToLoad.Add(USERNAME_LDAP_KEY);
            if (propertiesToLoad != null)
            {
                propertiesToLoad.ForEach(prop => search.PropertiesToLoad.Add(prop));
            }
            return search.FindAll();
        }

        private SearchResult GetEntryForAccount(DirectoryEntry entry, string username, params string[] propertiesToLoad)
        {
            var search = new DirectorySearcher(entry) { Filter = UsernameFilter(username) };
            if (propertiesToLoad != null)
            {
                propertiesToLoad.ForEach(prop => search.PropertiesToLoad.Add(prop));
            }
            return search.FindOne();
        }

        public bool HasPath()
        {
            return !path.IsNullOrEmptyOrWhitespace();
        }

        public UserInformation GetUserInformation(string username, string password)
        {
            string usernameToFind = username;
            return GetUserInformation(username, password, usernameToFind);
        }

        public UserInformation GetUserInformation(string username, string password, string usernameToFind)
        {
            using (var entry = GetDirectoryEntry(username, password, AuthenticationTypes.Delegation | AuthenticationTypes.Secure))
            {
                SearchResult result = GetEntryForAccount(entry, usernameToFind, FIRST_NAME_LDAP_KEY, LAST_NAME_LDAP_KEY, SAP_NUMBER_LDAP_KEY);

                string firstName = GetSingleStringAttribute(result, FIRST_NAME_LDAP_KEY);
                string lastName = GetSingleStringAttribute(result, LAST_NAME_LDAP_KEY);
                string sapNumber = GetSingleStringAttribute(result, SAP_NUMBER_LDAP_KEY);

                return new UserInformation(firstName, lastName, sapNumber);
            }
        }

        private static string GetSingleStringAttribute(SearchResult result, string key)
        {
            string value = null;

            if (result.Properties.Contains(key.ToLower()))
            {
                ResultPropertyValueCollection resultPropertyValueCollection = result.Properties[key];
                if (!resultPropertyValueCollection.IsEmpty())
                {
                    value = (string)resultPropertyValueCollection[0];
                    if (!string.IsNullOrEmpty(value))
                    {
                        value = value.Replace("&apos;", "'");
                    }
                }
            }

            return value;
        }

        public List<string> GetAllUsersWithOltRoles(string username, string password)
        {
            List<string> oltGroupNames = GetOltGroupNames(username, password);
            return GetAllUsernamesWithRoles(username, password, oltGroupNames);
        }

        public List<string> GetAllUsersWithVersion30Role(string username, string password)
        {
            List<string> groupNames = GetGroupNames(username, password, "HRD-SUNCOR-OPERATORLOGTOOL-3-0*");
            if (groupNames.Count != 1)
            {
                throw new Exception("Either could not find the OLT 3.0 group or there were too many groups found.");
            }

            return GetAllUsernamesWithRoles(username, password, groupNames);
        }

        private List<string> GetOltGroupNames(string username, string password)
        {
            return GetGroupNames(username, password, "OLT-*");
        }

        private List<string> GetGroupNames(string username, string password, string cn)
        {
            List<string> groupNames = new List<string>();

            string filter = String.Format("(CN={0})", cn);
            SearchResultCollection results = FindAll(username, password, filter, DISTINGUISHED_NAME_LDAP_KEY);

            foreach (SearchResult result in results)
            {
                string groupName = GetSingleStringAttribute(result, DISTINGUISHED_NAME_LDAP_KEY);
                if (groupName != null)
                {
                    groupNames.Add(groupName);
                }
            }

            return groupNames;
        }

        private SearchResultCollection FindAll(string adUsername, string adPassword, string filter, params string[] propertiesToLoad)
        {
            using (var entry = GetDirectoryEntry(adUsername, adPassword, AuthenticationTypes.Delegation | AuthenticationTypes.Secure))
            {
                var search = new DirectorySearcher(entry) { Filter = filter };
                search.PropertiesToLoad.AddRange(propertiesToLoad);
                SearchResultCollection results = search.FindAll();
                return results;
            }
        }

        private List<string> GetAllUsernamesWithRoles(string adUsername, string adPassword, List<string> roleDistinguishedNames)
        {
            List<string> users = new List<string>();

            string filter = "(|" + roleDistinguishedNames.ConvertAll(dn => String.Format("(memberOf={0})", dn)).AsString("", str => str) + ")";
            SearchResultCollection results = FindAll(adUsername, adPassword, filter, USERNAME_LDAP_KEY, LAST_NAME_LDAP_KEY, FIRST_NAME_LDAP_KEY);
            foreach (SearchResult result in results)
            {
                string username = GetSingleStringAttribute(result, USERNAME_LDAP_KEY);
                if (username != null)
                {
                    string lastName = GetSingleStringAttribute(result, LAST_NAME_LDAP_KEY);
                    string firstName = GetSingleStringAttribute(result, FIRST_NAME_LDAP_KEY);
                    username = username + "," + lastName + "," + firstName;
                    users.Add(username);
                }
            }

            return users;
        }

        private const string NameSearchStringFormat = "(&(objectCategory=CN=Person,CN=Schema,CN=Configuration,DC=network,DC=lan)(displayName=*{0}*)(mail=*))";
        private const string GroupSearchStringFormat = "(&(objectCategory=CN=Group,CN=Schema,CN=Configuration,DC=network,DC=lan)(displayName=*{0}*)(mail=*))";
        private const string GroupAndNameFormat = "(|{0}{1})";

        private readonly string[] propertiesToReturnFromSearch = new[] { "displayName", "mail" };

        public List<LdapAddressSearchResult> SearchForUserOrGroup(string searchString)
        {
            string nameSearchString = string.Format(NameSearchStringFormat, searchString);
            string groupSearchString = string.Format(GroupSearchStringFormat, searchString);
            string filterString = string.Format(GroupAndNameFormat, nameSearchString, groupSearchString);

            DirectoryEntry directoryEntry = new DirectoryEntry(path);
            DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry)
                                                      {
                                                          Filter = filterString
                                                      };
            
            directorySearcher.PropertiesToLoad.AddRange(propertiesToReturnFromSearch);

            SearchResultCollection searchResultCollection = directorySearcher.FindAll();

            List<LdapAddressSearchResult> displayNames = new List<LdapAddressSearchResult>(searchResultCollection.Count);

            foreach(SearchResult result in searchResultCollection)
            {
                string displayName = GetSingleStringAttribute(result, propertiesToReturnFromSearch[0]);
                string email = GetSingleStringAttribute(result, propertiesToReturnFromSearch[1]);
                displayNames.Add(new LdapAddressSearchResult(displayName, email));
            }
            displayNames.Sort(sr => sr.DisplayName, true);

            return displayNames;
        }

    }

    public class LdapAddressSearchResult
    {
        public LdapAddressSearchResult(string displayName, string email)
        {
            DisplayName = displayName;
            Email = email;
        }

        public string Email { get; private set; }

        public string DisplayName { get; private set; }
    }
   
}