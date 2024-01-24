using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Extension;
using log4net.Core;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class RestrictionLocationDao : AbstractManagedDao, IRestrictionLocationDao
    {
        private readonly IRestrictionLocationWorkAssignmentDao restrictionLocationWorkAssignmentDao;
        private readonly IRestrictionLocationItemDao itemDao;
        private readonly IUserDao userDao;
        private readonly IWorkAssignmentDao workAssignmentDao;

        public RestrictionLocationDao()
        {
            restrictionLocationWorkAssignmentDao = DaoRegistry.GetDao<IRestrictionLocationWorkAssignmentDao>();
            itemDao = DaoRegistry.GetDao<IRestrictionLocationItemDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
        }

        public List<RestrictionLocation> QueryAll(long siteid)      //ayman restriction
        {
            SqlCommand command = ManagedCommand;
            command.Parameters.AddWithValue("@SiteID", siteid);
            return command.QueryForListResult<RestrictionLocation>(PopulateInstance, "QueryAllRestrictionLocations");
        }

        public long QueryRestrictionLocationIdByWorkAssignment(long workAssignmentId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkAssignmentId", workAssignmentId);
            return command.QueryForSingleResult(reader => reader.Get<long>("RestrictionLocationId"), "QueryRestrictionLocationByWorkAssignmentId");
        }

        public long GetNextLocationItemSequenceNumber()
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.AddIdOutputParameter();
            command.ExecuteNonQuery("GetNewSeqVal_RestrictionLocationItemIdSequence");

            long batchId = (long)idParameter.Value;

            return batchId;
        }

        public void Insert(RestrictionLocation location)
        {
            SqlCommand command = ManagedCommand;
            long id = command.InsertAndReturnId(location, AddParameters, "InsertRestrictionLocation");
            location.Id = id;
            InsertWorkAssignmentAssociations(location);
            InsertItems(location);
        }

        public RestrictionLocation QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryById<RestrictionLocation>(id, PopulateInstance, "QueryRestrictionLocationById");
        }

        public void Update(RestrictionLocation location)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", location.IdValue);
            command.Update(location, AddParameters, "UpdateRestrictionLocation");

            UpdateWorkAssignmentAssociations(command, location);
            UpdateLocationItems(location);
        }

        public void Remove(RestrictionLocation location)
        {
            SqlCommand command = ManagedCommand;
            command.Remove(location, "RemoveRestrictionLocation");
        }

        private void UpdateLocationItems(RestrictionLocation location)
        {
            foreach (RestrictionLocationItem item in location.LocationItems)
            {
                RestrictionLocationItem itemCurrentlyInDb = itemDao.QueryById(item.IdValue);
                if (itemCurrentlyInDb == null)
                {
                    itemDao.Insert(location.IdValue, item);
                }
                else
                {
                    // only update the item if something has changed. This avoids updating the item, plus all of it's reason code associations.
                    if (itemCurrentlyInDb.DoesNotEqual(item))
                    {
                        itemDao.Update(item);
                    }
                }
            }
            foreach (long itemId in location.RemovedItems)
            {
                itemDao.Remove(itemId);
            }
        }

        private void UpdateWorkAssignmentAssociations(SqlCommand command, RestrictionLocation location)
        {
            command.CommandText = "DeleteRestrictionLocationWorkAssignmentsByRestrictionLocationId";
            command.Parameters.Clear();
            command.AddParameter("@RestrictionLocationId", location.IdValue);
            command.ExecuteNonQuery();
            
            InsertWorkAssignmentAssociations(location);
        }

        private void InsertItems(RestrictionLocation location)
        {
            if (location.LocationItems.IsEmpty())
                return;

            foreach (RestrictionLocationItem item in location.LocationItems)
            {
                itemDao.Insert(location.IdValue, item); 
            }
        }

        private void AddParameters(RestrictionLocation domainobject, SqlCommand command)
        {
            command.AddParameter("@Name", domainobject.Name);
            command.AddParameter("@LastModifiedByUserId", domainobject.LastModifiedBy.IdValue);
            command.AddParameter("@LastModifiedDateTime", domainobject.LastModifiedDateTime);
            command.AddParameter("@SiteID",domainobject.SiteID);           //ayman restriction location
        }

        private RestrictionLocation PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string name = reader.Get<string>("Name");
            long lastModifiedUserId = reader.Get<long>("LastModifiedByUserId");
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            long siteid = reader.Get<long>("SiteID");                     //ayman restriction location

            List<WorkAssignment> workAssignments = workAssignmentDao.QueryByRestrictionLocation(id,siteid);       //ayman restriction location
            RestrictionLocation restrictionLocation = new RestrictionLocation(id, name, workAssignments, userDao.QueryById(lastModifiedUserId), lastModifiedDateTime,siteid);    //ayman restriction location

            List<RestrictionLocationItem> items = itemDao.QueryByRestrictionLocation(id);
            foreach (RestrictionLocationItem item in items)
            {
                restrictionLocation.AddLocationItem(item);
            }
            restrictionLocation.SortLocationItems();
            return restrictionLocation;
        }

        private void InsertWorkAssignmentAssociations(RestrictionLocation restrictionLocation)
        {
            if (restrictionLocation.WorkAssignments.IsEmpty())
                return;

            foreach (WorkAssignment workAssignment in restrictionLocation.WorkAssignments)
            {
                restrictionLocationWorkAssignmentDao.Insert(restrictionLocation.IdValue, workAssignment);
            }
        }
    }
}