using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class WorkAssignmentService : IWorkAssignmentService
    {
        private readonly IWorkAssignmentDao workAssignmentDao;

        public WorkAssignmentService()
        {
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
        }

        public WorkAssignment QueryById(long id)
        {
            return workAssignmentDao.QueryById(id);
        }

        public WorkAssignment QueryByIdWithoutCache(long id)
        {
            return workAssignmentDao.QueryByIdWithoutCache(id);
        }

        public List<WorkAssignment> QueryBySite(Site site)
        {
            return workAssignmentDao.QueryBySiteId(site.IdValue);
        }
        public List<WorkAssignment> TemplateCategoriesQueryBySite(Site site)
        {
            return workAssignmentDao.TemplateCategoriesQueryBySiteId(site.IdValue);
        }
        public List<WorkAssignment> PermitRequestTemplateCategoriesQueryBySite(Site site)
        {
            return workAssignmentDao.PermitRequestTemplateCategoriesQueryBySiteId(site.IdValue);
        }
        

        public List<WorkAssignment> QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant(IFlocSet flocSet)
        {
            return workAssignmentDao.QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant(flocSet);
        }

        public WorkAssignment Insert(WorkAssignment workAssignment)
        {
            return workAssignmentDao.Insert(workAssignment);
        }

        public void Remove(WorkAssignment workAssignment)
        {
            workAssignmentDao.Remove(workAssignment);
        }

        public void Update(WorkAssignment workAssignment)
        {
            workAssignmentDao.Update(workAssignment);
        }

        public void UpdateFunctionalLocations(List<WorkAssignment> listToSave)
        {
            foreach (WorkAssignment assignment in listToSave)
            {
                workAssignmentDao.UpdateFunctionalLocations(assignment);
            }
        }

        public void Update(List<WorkAssignment> workAssignments)
        {
            foreach (WorkAssignment workAssignment in workAssignments)
            {
                workAssignmentDao.Update(workAssignment);
            }
        }

        public List<WorkAssignment> QueryByUserAndSite(User user, Site site)
        {
            if (site.Id == null)
            {                
                return new List<WorkAssignment>();
            }
            List<WorkAssignment> assignmentsForSite = workAssignmentDao.QueryBySiteId(site.Id.Value);
            List<Role> rolesForUser = user.GetRoles(site);

            return assignmentsForSite.FindAll(assignment => assignment.Role.IsOneOf(rolesForUser));
        }     
    }
}