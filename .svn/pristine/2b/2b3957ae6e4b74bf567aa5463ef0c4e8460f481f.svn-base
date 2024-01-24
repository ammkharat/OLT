using System;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Utility;
using log4net;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ObjectLockDao : AbstractManagedDao, IObjectLockDao
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<ObjectLockDao>();

        public void ReleaseAllLocks()
        {
            ManagedCommand.ExecuteNonQuery("RemoveAllObjectLocks");
        }

        public ObjectLockResult GetLock(DomainObject obj, long userid, string guid)
        {
            if (obj.Id == null)
            {
                throw new LockException("You can not get a lock for an object with a null id");
            }
            return GetLock(obj.ObjectIdentifier, userid, guid);
        }

        public ObjectLockResult GetLock(string objectIdentifier, long userid, string guid)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = "QueryObjectLockByOid";
            command.CommandType = CommandType.StoredProcedure;
            command.AddParameter("@ObjectIdentifier", objectIdentifier);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return PopulateFailedObjectLockResult(reader);
                }
            }
            // This can use DateTime.Now
            var objectLock = new ObjectLock(objectIdentifier, userid, DateTime.Now.GetNetworkPortable(), guid);
            InsertObjectLock(objectLock);
            return new ObjectLockResult(true, objectLock.LockedByUserId, null, objectLock.LockedOnDateTime);
        }

        private ObjectLockResult PopulateFailedObjectLockResult(SqlDataReader reader)
        {
            long lockedByUserId = reader.Get<long>("LockedByUserId");

            string lockedByUserName = reader.Get<string>("UserName");
            string lockedByFirstName = reader.Get<string>("FirstName");
            string lockedByLastName = reader.Get<string>("LastName");
            string lockedBy = lockedByUserName + "<" + lockedByFirstName + " " + lockedByLastName + ">";

            DateTime lockedOnDateTime = reader.Get<DateTime>("LockedOnDateTime");

            return new ObjectLockResult(false, lockedByUserId, lockedBy, lockedOnDateTime);
        }


        private void InsertObjectLock(ObjectLock objectLock)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ObjectIdentifier", objectLock.ObjectIdentifier);
            command.AddParameter("@LockedByUserId",  objectLock.LockedByUserId);
            command.AddParameter("@LockedOnDateTime",  objectLock.LockedOnDateTime);
            command.AddParameter("@LockedByGuid", objectLock.LockedByGuid);

            command.ExecuteNonQuery("InsertObjectLock");
        }

        public bool IsLocked(DomainObject obj)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = "QueryObjectLockByOid";
            command.CommandType = CommandType.StoredProcedure;
            command.AddParameter("@ObjectIdentifier", obj.ObjectIdentifier);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return true;
                }
                return false;
            }
        }

        public void ReleaseLock(DomainObject obj, long userid)
        {
            if (obj.Id == null)
            {
                throw new LockException("You can not get a lock for an object with a null id");
            }
            ReleaseLock(obj.ObjectIdentifier, userid);
        }

        public void ReleaseLock(string objectIdentifier, long userid)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ObjectIdentifier", objectIdentifier);
            command.AddParameter("@UserId",  userid);
            int numberOfRecordsAffected = command.ExecuteNonQuery("RemoveObjectLockByOidAndUserId");
            if (numberOfRecordsAffected == 0)
            {
                string message = String.Format(
                    "Unable to release lock with identifier: {0} for userid: {1}. Lock no longer exists.",
                    objectIdentifier,
                    userid);
                logger.Warn(message);
            }
        }

        public void ReleaseLock(string guid)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@LockedByGuid", guid);
            command.ExecuteNonQuery("RemoveObjectLockByGuId");
        }

        public void ExpireLocks(int timeoutInMinutes)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@TimeoutInMinutes",  timeoutInMinutes);
            command.AddParameter("@Now",  DateTime.Now.GetNetworkPortable());
            command.ExecuteNonQuery("RemoveExpiredObjectLocks");
        }
    }
}