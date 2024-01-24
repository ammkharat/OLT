using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Providers;
using log4net;
using Com.Suncor.Olt.Remote.Utilities;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class SecurityService : ISecurityService
    {
        private readonly IUserDao userDao;
        private static readonly ILog logger = GenericLogManager.GetLogger<SecurityService>();
        private IAuthenticationProvider authenticationProvider;
        private readonly ISiteDao siteDao;
        private readonly IRoleDao roleDao;

        public SecurityService()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            roleDao = DaoRegistry.GetDao<IRoleDao>();
            siteDao = DaoRegistry.GetDao<ISiteDao>();

            ConfigureAuthenticationProvider();
        }

        public SecurityService(IAuthenticationProvider authProvider) : this()
        {
            authenticationProvider = authProvider;
        }
        
        public SecurityService(IUserDao userDao, IAuthenticationProvider authProvider)
        {
            this.userDao = userDao;
            authenticationProvider = authProvider;
        }

        private void ConfigureAuthenticationProvider()
        {
            string authenticationProviderClass = ConfigurationManager.AppSettings["AuthenticationProvider"];
            Type classType = Type.GetType(authenticationProviderClass);
            authenticationProvider = (IAuthenticationProvider)Activator.CreateInstance(classType);
        }

        private User GetUser(string username, string password)
        {
            User user;
            try
            {
                user = userDao.QueryByUsername(username);
                user = UpdateUserIfNecessary(user, username, password);
            }
            catch (NoDataFoundException)
            {
                user = CreateOrUndeleteUser(username, password);
            }

            if (user != null)
            {
                user.SiteRolePlants = GetSiteRolePlants(username, password);
                if (user.SiteRolePlants.Count == 0)
                {
                    logger.InfoFormat("Could not authenticate user {0} because they have no roles configured.", username);
                }
            }

            return user;
        }

        private User CreateOrUndeleteUser(string username, string password)
        {
            User user = userDao.QueryDeletedUserByUserName(username);

            if (user == null)
            {
                logger.DebugFormat("Creating user {0} in the OLT database.", username);
                user = CreateUser(username, password);
            }
            else
            {
                logger.DebugFormat("Undeleting user {0} in the OLT database.", username);
                userDao.UndoRemove(user, user.IdValue);
            }

            return user;
        }

        private User UpdateUserIfNecessary(User user, string username, string password)
        {
            UserInformation userInformation = authenticationProvider.GetUserInformation(username, password);
            if (user.FirstName != userInformation.FirstName || user.LastName != userInformation.LastName)
            {
                logger.DebugFormat("Updating user {0}'s first and/or last name in the OLT database.", username);
                user.FirstName = userInformation.FirstName;
                user.LastName = userInformation.LastName;
                userDao.Update(user);
            }
            return user;
        }

        private User CreateUser(string username, string password)
        {
            UserInformation userInformation = authenticationProvider.GetUserInformation(username, password);

            User user = new User(username,
                                 userInformation.FirstName,
                                 userInformation.LastName,
                                 new List<SiteRolePlant>(),
                                 userInformation.SapId ?? string.Empty, 
                                 new UserPreferences(0), 
                                 new UserPrintPreference(0),
                                 new UserWorkPermitDefaultTimePreferences(0),
                                 DateTime.Now.GetNetworkPortable());

            user = userDao.Insert(user);
            
            // this will cause the right version of Preferences to go into the cache before doing a Query.
            // See Mingle card #3196 for Technical Debt refactoring of this.
            user.UserPreferences = new UserPreferences(user.IdValue);
            user.WorkPermitPrintPreference = new UserPrintPreference(user.IdValue);
            user.WorkPermitDefaultTimePreferences = new UserWorkPermitDefaultTimePreferences(user.IdValue);
            userDao.Update(user);

            user = userDao.QueryById(user.IdValue); // so that preferences are populated correctly
            return user;
        }

        public User Authenticate(string username, string encryptedPassword)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }

            string password = encryptedPassword.Decrypt();

            bool isCorrectCredentials = authenticationProvider.IsValidActiveDirectoryLogon(username, password);

            return !isCorrectCredentials ? null : GetUser(username, password);
        }

        private List<SiteRolePlant> GetSiteRolePlants(string username, string password)
        {
            List<IOltGroupMembership> oltGroupMemberships = authenticationProvider.GetOltGroupMemberships(username, password);

            List<SiteRolePlant> siteRolePlants = new List<SiteRolePlant>();
            foreach (IOltGroupMembership membership in oltGroupMemberships)
            {
                Site site = siteDao.QueryByActiveDirectoryKey(membership.SiteIdentifier);

                if (site != null && site.Plants.Exists(p => p.IdValue == membership.PlantId))
                {
                    Role role = roleDao.QueryByActiveDirectoryKey(site, membership.RoleIdentifier);
                    if (role != null)
                    {
                        SiteRolePlant siteRolePlant = new SiteRolePlant(site, role, membership.PlantId);
                        siteRolePlants.Add(siteRolePlant);
                    }
                }
            }

            return siteRolePlants;
        }

        public Version GetAssemblyVersion()
        {
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            return v;
        }
    }
}