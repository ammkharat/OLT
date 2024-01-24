using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class User : DomainObject
    {
        private readonly DateTime lastModifiedDate;
        private readonly string sapId;
        private readonly List<SiteRolePlant> siteRolePlants = new List<SiteRolePlant>();
        private readonly string userName;
        private string firstName;
        private string lastName;
        private UserPreferences userPreferences;
        private UserPrintPreference workPermitPrintPreference;

        public User(long userId, string userName, string firstName, string lastName, List<SiteRolePlant> siteRolePlants,
            string sapId, UserPreferences userPreferences, UserPrintPreference workPermitPrintPreference,
            UserWorkPermitDefaultTimePreferences workPermitDefaultTimePreferences, DateTime lastModifiedDate)
            : this(
                userName, firstName, lastName, siteRolePlants, sapId, userPreferences, workPermitPrintPreference,
                workPermitDefaultTimePreferences,
                lastModifiedDate)
        {
            id = userId;
        }

        public User(string userName, string firstName, string lastName, List<SiteRolePlant> siteRolePlants, string sapId,
            UserPreferences userPreferences, UserPrintPreference workPermitPrintPreference,
            UserWorkPermitDefaultTimePreferences workPermitDefaultTimePreferences, DateTime lastModifiedDate)
        {
            if (sapId == null)
            {
                throw new NullReferenceException("The SAP ID cannot be null");
            }
            this.userPreferences = userPreferences;
            this.userName = userName;
            this.firstName = firstName;
            this.lastName = lastName;
            this.sapId = sapId;
            this.workPermitPrintPreference = workPermitPrintPreference;
            WorkPermitDefaultTimePreferences = workPermitDefaultTimePreferences;
            this.lastModifiedDate = lastModifiedDate;
            SiteRolePlants = siteRolePlants;
        }

        public IList<Site> AvailableSites
        {
            get
            {
                var sites = new List<Site>();
                sites.AddNonDuplicatesById(siteRolePlants.ConvertAll(srp => srp.Site));

                return sites;
            }
        }

        public List<SiteRolePlant> SiteRolePlants
        {
            get { return siteRolePlants; }
            set
            {
                siteRolePlants.Clear();
                if (value != null && value.Count > 0)
                {
                    siteRolePlants.AddRange(value);
                }
            }
        }

        public string FirstName
        {
            get { return firstName ?? string.Empty; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName ?? string.Empty; }
            set { lastName = value; }
        }

        public string FullName
        {
            get { return ToFullName(firstName, lastName); }
        }

        public string FullNameWithFirstNameFirst
        {
            get { return ToFullName(firstName, lastName, false); }
        }

        public string Username
        {
            get { return userName; }
        }

        public UserPreferences UserPreferences
        {
            get { return userPreferences; }
            set { userPreferences = value; }
        }

        public UserPrintPreference WorkPermitPrintPreference
        {
            get { return workPermitPrintPreference; }
            set { workPermitPrintPreference = value; }
        }

        public UserWorkPermitDefaultTimePreferences WorkPermitDefaultTimePreferences { get; set; }

        public string FullNameWithUserName
        {
            get { return ToFullNameWithUserName(lastName, firstName, userName); }
        }

        public string SAPId
        {
            get { return sapId; }
        }

        public DateTime LastModifiedDate
        {
            get { return lastModifiedDate; }
        }

        public long LastModifiedById { set; get; }

        public List<Role> GetRoles(Site site)
        {
            var roles = new List<Role>();

            var siteRolePlantsInSite = siteRolePlants.FindAll(srp => srp.Site.Id == site.Id);
            roles.AddNonDuplicatesById(siteRolePlantsInSite.ConvertAll(srp => srp.Role));

            return roles;
        }

        public static string ToFullName(string first, string last)
        {
            return ToFullName(first, last, true);
        }

        public static string ToFullName(string first, string last, bool lastNameFirst)
        {
            string name;

            if (first == null && last == null)
            {
                return string.Empty;
            }

            if (first == null)
            {
                name = last.Trim();
            }
            else if (last == null)
            {
                name = first.Trim();
            }
            else
            {
                if (lastNameFirst)
                {
                    name = last.Trim() + ", " + first.Trim();
                }
                else
                {
                    name = string.Format("{0} {1}", first.Trim(), last.Trim());
                }
            }

            return name;
        }

        public override string ToString()
        {
            return userName;
        }

        public static string ToFullNameWithUserName(string lastName, string firstName, string userName)
        {
            var fullName = ToFullName(firstName, lastName);
            var spacer = string.IsNullOrEmpty(fullName) ? string.Empty : " ";
            return string.Format("{0}{1}[{2}]", fullName, spacer, userName.Trim());
        }
    }
}