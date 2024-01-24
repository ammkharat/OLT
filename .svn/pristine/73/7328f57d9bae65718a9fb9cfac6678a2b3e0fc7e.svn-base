using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.DataAccess.DTO;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class RestrictionFlocsConfigurationService : IRestrictionFlocsConfigurationService
    {
        private readonly IFunctionalLocationDao functionalLocationDao;

        private readonly IWorkAssignmentDTODao workAssignmentDTODao;
        private readonly IWorkAssignmentDao workAssignmentDao;

        public RestrictionFlocsConfigurationService()
        {
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            workAssignmentDTODao = DaoRegistry.GetDao<IWorkAssignmentDTODao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
        }

        public List<AssignmentFlocConfiguration> QueryBySite(Site site)
        {
            var assignments = workAssignmentDTODao.QueryBySiteId(site.IdValue);
            return BuildConfigurationList(assignments);
        }

        public void UpdateFunctionalLocations(List<AssignmentFlocConfiguration> listToSave)
        {
            foreach (var configuration in listToSave)
            {
                workAssignmentDao.UpdateFunctionalLocationsForRestrictions(configuration);
            }
        }

        private List<AssignmentFlocConfiguration> BuildConfigurationList(List<WorkAssignmentDTO> sourcesAssignments)
        {
            var results = new List<AssignmentFlocConfiguration>();

            foreach (var assignmentDto in sourcesAssignments)
            {
                var flocs =
                    functionalLocationDao.QueryByWorkAssignmentIdForRestrictionFlocs(assignmentDto.IdValue);

                var configuration =
                    new AssignmentFlocConfiguration(
                        assignmentDto.IdValue,
                        assignmentDto.Name,
                        assignmentDto.Role,
                        assignmentDto.Description,
                        assignmentDto.Category,
                        flocs);

                results.Add(configuration);
            }

            return results;
        }
    }
}