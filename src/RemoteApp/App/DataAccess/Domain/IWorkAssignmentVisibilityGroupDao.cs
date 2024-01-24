using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IWorkAssignmentVisibilityGroupDao : IDao
    {
        List<WorkAssignmentVisibilityGroup> QueryByWorkAssignmentId(long workAssignmentId);
        WorkAssignmentVisibilityGroup Insert(WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup);
        void Remove(WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup);
        List<WorkAssignmentVisibilityGroup> QueryByVisibilityGroupId(long visibilityGroupId);
    }
}