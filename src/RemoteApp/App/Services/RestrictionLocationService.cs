using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class RestrictionLocationService : IRestrictionLocationService
    {
        private readonly IRestrictionLocationDao dao;
        private readonly IRestrictionLocationItemDao locationItemDao;
        
        public RestrictionLocationService()
        {
            dao = DaoRegistry.GetDao<IRestrictionLocationDao>();
            locationItemDao = DaoRegistry.GetDao<IRestrictionLocationItemDao>();
        }

        public List<RestrictionLocation> QueryAll(long siteid)       //ayman restriction
        {
            return dao.QueryAll(siteid);
        }

        public RestrictionLocation QueryById(long id)
        {
            return dao.QueryById(id);
        }

        public List<WorkAssignment> QueryAllAssignedWorkAssignments(long siteid)        //ayman restriction
        {
            List<WorkAssignment> allAssignedWorkAssignments = new List<WorkAssignment>();

            List<RestrictionLocation> restrictionLocations = QueryAll(siteid);
            restrictionLocations.ForEach(l => allAssignedWorkAssignments.AddRange(l.WorkAssignments));
            return allAssignedWorkAssignments;
        }

        public void Insert(RestrictionLocation restrictionLocation)
        {
            dao.Insert(restrictionLocation);
        }

        public void Update(RestrictionLocation restrictionLocation)
        {
            dao.Update(restrictionLocation);
        }

        public void Remove(RestrictionLocation restrictionLocation)
        {
            dao.Remove(restrictionLocation);
        }

        public RestrictionLocation QueryByWorkAssignment(long workAssignmentId)
        {
            long restrictionLocationId = dao.QueryRestrictionLocationIdByWorkAssignment(workAssignmentId);
            return dao.QueryById(restrictionLocationId);
        }

        public bool AllItemsAreInGivenRestrictionLocation(long existingRestrictionLocationId, List<long> restrictionLocationItemsToCheck)
        {
            RestrictionLocation restrictionLocation = dao.QueryById(existingRestrictionLocationId);
            
            foreach (long restrictionLocationId in restrictionLocationItemsToCheck)
            {
                if(!restrictionLocation.LocationItems.Exists(li => li.IdValue == restrictionLocationId))
                {
                    return false;
                }
            }

            return true;
        }

        public long GetNextLocationItemSequenceNumber()
        {
            return dao.GetNextLocationItemSequenceNumber();
        }
    }
}