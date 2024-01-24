using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class WorkPermitAssignmentConfigurationService : IWorkPermitAssignmentConfigurationService
    {
        private readonly IWorkAssignmentDao workAssignmentDao;
        private readonly IWorkAssignmentDTODao workAssignmentDTODao;
        private readonly IFunctionalLocationDao functionalLocationDao;

        public WorkPermitAssignmentConfigurationService() : this(DaoRegistry.GetDao<IWorkAssignmentDao>(), DaoRegistry.GetDao<IWorkAssignmentDTODao>(), DaoRegistry.GetDao<IFunctionalLocationDao>())
        {
        }

        public WorkPermitAssignmentConfigurationService(IWorkAssignmentDao workAssignmentDao, IWorkAssignmentDTODao workAssignmentDtoDao, IFunctionalLocationDao functionalLocationDao)
        {
            this.workAssignmentDao = workAssignmentDao;
            workAssignmentDTODao = workAssignmentDtoDao;
            this.functionalLocationDao = functionalLocationDao;
        }

        public List<AssignmentFlocConfiguration> QueryBySite(Site site)
        {
            List<WorkAssignmentDTO> assignments = workAssignmentDTODao.QueryBySiteId(site.IdValue);
            return BuildConfigurationList(assignments);
        }

        public void UpdateFunctionalLocations(List<AssignmentFlocConfiguration> listToSave)
        {
            foreach (AssignmentFlocConfiguration configuration in listToSave)
            {
                workAssignmentDao.UpdateFunctionalLocationsForWorkPermits(configuration);
            }
        }

        private List<AssignmentFlocConfiguration> BuildConfigurationList(List<WorkAssignmentDTO> sourcesAssignments)
        {
            List<AssignmentFlocConfiguration> results = new List<AssignmentFlocConfiguration>();

            foreach (WorkAssignmentDTO assignmentDto in sourcesAssignments)
            {
                List<FunctionalLocation> flocs =
                    functionalLocationDao.QueryByWorkAssignmentIdForWorkPermits(assignmentDto.IdValue);

                AssignmentFlocConfiguration configuration =
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