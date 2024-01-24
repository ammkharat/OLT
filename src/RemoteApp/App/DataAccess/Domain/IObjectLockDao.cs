using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IObjectLockDao : IDao
    {
        void ReleaseAllLocks();

        ObjectLockResult GetLock(DomainObject obj, long userid, string guid);

        ObjectLockResult GetLock(string objectIdentifier, long userid, string guid);

        bool IsLocked(DomainObject obj);

        void ReleaseLock(DomainObject obj, long userid);

        void ReleaseLock(string objectIdentifier, long userid);

        void ReleaseLock(string guid);

        void ExpireLocks(int timeoutInMinutes);

    }
}