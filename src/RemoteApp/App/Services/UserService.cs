using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using log4net;

namespace Com.Suncor.Olt.Remote.Services
{
    public class UserService : IUserService
    {
        /// <summary>
        /// We have one SAP user in the system, and that ID is hardcoded.
        /// </summary>
        public const long SAP_USER_ID = 0; 
        public const long REMOTER_APP_USER_ID = -1;

        private readonly IUserDao userDao;
        private readonly IUserDTODao userDTODao;
        private readonly IUserPrintPreferenceDao userPrintPreferenceDao;
        private readonly IUserPreferencesDao userPreferencesDao;
        private readonly IUserWorkPermitDefaultTimePreferencesDao userWorkPermitDefaultTimePreferencesDao;
        private readonly IUserGridLayoutDao userGridLayoutDao;

        public UserService()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            userDTODao = DaoRegistry.GetDao<IUserDTODao>();
            userPrintPreferenceDao = DaoRegistry.GetDao<IUserPrintPreferenceDao>();
            userPreferencesDao = DaoRegistry.GetDao<IUserPreferencesDao>();
            userWorkPermitDefaultTimePreferencesDao = DaoRegistry.GetDao<IUserWorkPermitDefaultTimePreferencesDao>();
            userGridLayoutDao = DaoRegistry.GetDao<IUserGridLayoutDao>();
        }

        public User GetSAPUser()
        {
            User sapUser = QueryById(SAP_USER_ID);

            if (sapUser == null)
            {
                throw new ApplicationException("Cannot find fixed SAP import user.");
            }

            return sapUser;
        }

        public User GetRemoteAppUser()
        {
            User remoteApp = QueryById(REMOTER_APP_USER_ID);

            if (remoteApp == null)
            {
                throw new ApplicationException("Cannot find fixed Remote App user.");
            }

            return remoteApp;
        }

        public User QueryById(long id)
        {
            return userDao.QueryById(id);
        }

        public UserPrintPreference UpdatePrintPreferences(User user)
        {
            UserPrintPreference current = userPrintPreferenceDao.QueryByUserId(user.IdValue);
            if (null == current)
            {
                return userPrintPreferenceDao.Insert(user.WorkPermitPrintPreference);
            }
            userPrintPreferenceDao.Update(user.WorkPermitPrintPreference);
            return user.WorkPermitPrintPreference;
        }

        public void UpdateUserPreferences(User user)
        {
            UserPreferences current = userPreferencesDao.QueryByUserId(user.IdValue);
            if (null == current)
            {

                userPreferencesDao.Insert(user.UserPreferences);
            }
            else
            {
                userPreferencesDao.Update(user.UserPreferences);
            }
        }

        public void UpdateWorkPermitDefaultTimesPreferences(User user)
        {
            UserWorkPermitDefaultTimePreferences currentPreferences = userWorkPermitDefaultTimePreferencesDao.QueryByUserId(user.IdValue);
            if (null == currentPreferences)
            {
                userWorkPermitDefaultTimePreferencesDao.Insert(user.WorkPermitDefaultTimePreferences);
            }
            else
            {
                userWorkPermitDefaultTimePreferencesDao.Update(user.WorkPermitDefaultTimePreferences);
            }
        }       

        public void SaveGridLayout(long userId, UserGridLayoutIdentifier userGridLayoutIdentifier, string xml)
        {
            userGridLayoutDao.DeleteGridLayout(userId, userGridLayoutIdentifier);
            userGridLayoutDao.SaveGridLayout(userId, userGridLayoutIdentifier, xml);
        }

        public string GetGridLayout(long userId, UserGridLayoutIdentifier userGridLayoutIdentifier)
        {
            return userGridLayoutDao.GetGridLayout(userId, userGridLayoutIdentifier);
        }

        public void DeleteGridLayout(long userId, UserGridLayoutIdentifier userGridLayoutIdentifier)
        {
            userGridLayoutDao.DeleteGridLayout(userId, userGridLayoutIdentifier);
        }

        public void DeleteGridLayoutsForUser(long userId)
        {
            userGridLayoutDao.DeleteAllGridLayoutsForUser(userId);
        }

        public List<UserDTO> QueryUsersWhoHaveCreatedOilsandsTrainingForms()
        {
            return userDTODao.QueryUsersWhoHaveCreatedOilsandsTrainingForms();
        }
    }
}