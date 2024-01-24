using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IVisibilityGroupService
    {
        [OperationContract]
        List<VisibilityGroup> QueryAll(Site site);

        [OperationContract]
        bool IsAssociatedToWorkAssignmentsWithRead(VisibilityGroup visibilityGroup);

        [OperationContract]
        bool IsAssociatedToWorkAssignmentsWithWrite(VisibilityGroup visibilityGroup);

        [OperationContract]
        void Remove(VisibilityGroup visibilityGroup);

        [OperationContract]
        VisibilityGroup Insert(VisibilityGroup visibilityGroup);

        [OperationContract]
        void Update(VisibilityGroup visibilityGroup);
    }
}