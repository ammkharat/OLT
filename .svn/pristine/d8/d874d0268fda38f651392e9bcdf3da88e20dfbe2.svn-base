using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ObjectLockingService : IObjectLockingService
    {
        private readonly IObjectLockDao dao;

        public ObjectLockingService()
        {
            dao = DaoRegistry.GetDao<IObjectLockDao>();
        }

        public ObjectLockingService(IObjectLockDao dao)
        {
            this.dao = dao;
        }

        public ObjectLockResult GetLock(DomainObject obj, long userid, string guid)
        {
            return dao.GetLock(obj, userid, guid);
        }

        public ObjectLockResult GetLock(string objectIdentifier, long userid, string guid)
        {
            return dao.GetLock(objectIdentifier, userid, guid);
        }

        public void ReleaseLock(DomainObject obj, long userid)
        {
            dao.ReleaseLock(obj, userid);
        }

        public void ReleaseLock(string objectIdentifier, long userid)
        {
            dao.ReleaseLock(objectIdentifier, userid);
        }
        
        public void ReleaseLock(string guid)
        {
            dao.ReleaseLock(guid);
        }

        /// <summary>
        /// Expire the locks that are older than the timeout value
        /// </summary>
        /// <param name="timeoutInMinutes">The number of minutes to define which locks we should expire</param>
        public void ExpireLocks(int timeoutInMinutes)
        {
            dao.ExpireLocks(timeoutInMinutes);
        }      
    }
}