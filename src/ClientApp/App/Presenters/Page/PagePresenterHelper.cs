using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public static class PagePresenterHelper
    {
        private static bool LockAll<TDomainObject>(List<TDomainObject> domainObjects, List<string> successfullyLockedIdentifiers, LockType lockType, User user,
                                                  IObjectLockingService objectLockingService) where TDomainObject : DomainObject
        {
            foreach (TDomainObject domainObject in domainObjects)
            {
                string lockIdentifier = domainObject.ObjectIdentifier;
                ObjectLockResult lockResult = objectLockingService.GetLock(lockIdentifier, user.IdValue, ClientSession.GetInstance().GuidAsString);
                if (lockResult.Succeeded)
                {
                    successfullyLockedIdentifiers.Add(lockIdentifier);
                }
                else
                {
                    PageHelper.LaunchLockDeniedMessage(Form.ActiveForm, lockResult.LockedByUserName, lockType);           
                    return false;
                }
            }
            return true;
        }

        private static void ReleaseAllLocks(List<string> successfullyLockedIdentifiers, User user, IObjectLockingService objectLockingService)
        {            
            foreach (string lockIdentifier in successfullyLockedIdentifiers)
            {
                try
                {
                    objectLockingService.ReleaseLock(lockIdentifier, user.IdValue);
                }
                catch (Exception)
                {
                }
            }
        }

        public static bool LockDatabaseObjectWhileInUse<TDomainObject>(Action<TDomainObject> action, TDomainObject domainObject, string lockIdentifier, LockType lockType, User user,
                                                                       IObjectLockingService objectLockingService) where TDomainObject : DomainObject
        {
            ObjectLockResult lockResult = objectLockingService.GetLock(lockIdentifier, user.IdValue, ClientSession.GetInstance().GuidAsString);

            bool lockAquired = lockResult.Succeeded;
            if (lockAquired)
            {
                try
                {
                    action(domainObject);
                }
                finally
                {
                    objectLockingService.ReleaseLock(lockIdentifier, user.IdValue);
                }
            }
            else
            {
                PageHelper.LaunchLockDeniedMessage(Form.ActiveForm, lockResult.LockedByUserName, lockType);           
            }

            return lockAquired;
        }

        public static bool LockMultipleDomainObjects<TDomainObject>(Action<List<TDomainObject>> action, List<TDomainObject> domainObjects, LockType lockType, User user, IObjectLockingService objectLockingService) where TDomainObject : DomainObject
        {
            List<string> successfullyLockedIdentifiers = new List<string>();
            bool allLocksAquired;

            try
            {
                allLocksAquired = LockAll(domainObjects, successfullyLockedIdentifiers, lockType, user, objectLockingService);
                if (allLocksAquired)
                {
                    action(domainObjects);
                }
            }
            finally
            {
                ReleaseAllLocks(successfullyLockedIdentifiers, user, objectLockingService);
            }
            return allLocksAquired;
        }
    }
}