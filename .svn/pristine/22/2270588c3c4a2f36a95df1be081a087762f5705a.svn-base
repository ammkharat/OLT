using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IObjectLockingService
    {
        [OperationContract(Name = "GetLockWithStringIdentifier")]
        ObjectLockResult GetLock(string objectIdentifier, long userid, string guid);

        [OperationContract]
        ObjectLockResult GetLock(DomainObject obj, long userid, string guid);

        [OperationContract]
        void ReleaseLock(DomainObject obj, long userid);

        [OperationContract(Name = "ReleaseLockWithStringIdentifier")]
        void ReleaseLock(string objectIdentifier, long userid);

        [OperationContract(Name = "ReleaseLockWithGuid")]
        void ReleaseLock(string guid);

        /// <summary>
        ///     Expire locks older then the timeout value
        /// </summary>
        /// <param name="timeoutInMinutes">The number of minutes to define which locks we should expire</param>
        [OperationContract]
        void ExpireLocks(int timeoutInMinutes);
    }
}