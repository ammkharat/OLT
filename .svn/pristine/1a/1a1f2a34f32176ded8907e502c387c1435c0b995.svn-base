using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IWorkAssignmentService
    {
        [OperationContract]
        WorkAssignment QueryById(long id);

        [OperationContract]
        WorkAssignment QueryByIdWithoutCache(long id);

        [OperationContract]
        List<WorkAssignment> QueryBySite(Site site);

        [OperationContract]
        List<WorkAssignment> TemplateCategoriesQueryBySite(Site site);

         [OperationContract]
        List<WorkAssignment> PermitRequestTemplateCategoriesQueryBySite(Site site);

        
        

        [OperationContract]
        List<WorkAssignment> QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant(IFlocSet flocSet);

        [OperationContract]
        WorkAssignment Insert(WorkAssignment workAssignment);

        [OperationContract]
        void Update(WorkAssignment workAssignment);

        [OperationContract]
        void UpdateFunctionalLocations(List<WorkAssignment> listToSave);

        [OperationContract]
        void Remove(WorkAssignment workAssignment);

        [OperationContract]
        List<WorkAssignment> QueryByUserAndSite(User user, Site site);

        [OperationContract(Name = "UpdateMultipleWorkAssignments")]
        void Update(List<WorkAssignment> workAssignments);
    }
}