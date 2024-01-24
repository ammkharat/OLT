using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class VisibilityGroupService : IVisibilityGroupService
    {
        private readonly IVisibilityGroupDao dao;
        private readonly IWorkAssignmentVisibilityGroupDao workAssignmentVisibilityGroupDao;

        public VisibilityGroupService()
        {
            dao = DaoRegistry.GetDao<IVisibilityGroupDao>();
            workAssignmentVisibilityGroupDao = DaoRegistry.GetDao<IWorkAssignmentVisibilityGroupDao>();
        }

        public List<VisibilityGroup> QueryAll(Site site)
        {
            return dao.QueryAll(site.IdValue);
        }

        public bool IsAssociatedToWorkAssignmentsWithRead(VisibilityGroup visibilityGroup)
        {
            return dao.IsAssociatedToWorkAssignments(visibilityGroup, VisibilityType.Read);
        }

        public bool IsAssociatedToWorkAssignmentsWithWrite(VisibilityGroup visibilityGroup)
        {
            return dao.IsAssociatedToWorkAssignments(visibilityGroup, VisibilityType.Write);
        }

        public void Remove(VisibilityGroup visibilityGroup)
        {
            List<WorkAssignmentVisibilityGroup> workAssignmentVisibilityGroups = workAssignmentVisibilityGroupDao.QueryByVisibilityGroupId(visibilityGroup.IdValue);
            foreach(WorkAssignmentVisibilityGroup group in workAssignmentVisibilityGroups)
            {
                workAssignmentVisibilityGroupDao.Remove(group);
            }
            dao.Remove(visibilityGroup);
        }

        public VisibilityGroup Insert(VisibilityGroup visibilityGroup)
        {
            return dao.Insert(visibilityGroup);
        }

        public void Update(VisibilityGroup visibilityGroup)
        {
            dao.Update(visibilityGroup);
        }
    }
}