using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class WorkPermitAutoAssignmentConfigurationService : IWorkPermitAutoAssignmentConfigurationService
    {
        private readonly IWorkAssignmentDao workAssignmentDao;
        private readonly IWorkAssignmentDTODao workAssignmentDTODao;
        private readonly IFunctionalLocationDao functionalLocationDao;

        private readonly IFunctionalLocationService functionalLocationService;

        public WorkPermitAutoAssignmentConfigurationService()
        {
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            workAssignmentDTODao = DaoRegistry.GetDao<IWorkAssignmentDTODao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();

            functionalLocationService = new FunctionalLocationService();
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
                workAssignmentDao.UpdateFunctionalLocationsForWorkPermitAutoAssignment(configuration);
            }
        }

        public long? GetWorkAssignmentIdForFunctionalLocation(FunctionalLocation functionalLocation, long siteId)
        {
            List<WorkAssignmentDTO> assignments = workAssignmentDTODao.QueryBySiteId(siteId);
            List<AssignmentFlocConfiguration> configurations = BuildConfigurationList(assignments);

            WorkPermitWorkAssignmentDeterminator determinator = 
                new WorkPermitWorkAssignmentDeterminator(configurations, functionalLocationService);

            AssignmentFlocConfiguration assignment = determinator.GetWorkAssignment(functionalLocation);

            if (assignment != null)
            {
                return assignment.IdValue;
            }

            return null;
        }

        private List<AssignmentFlocConfiguration> BuildConfigurationList(List<WorkAssignmentDTO> sourcesAssignments)
        {
            List<AssignmentFlocConfiguration> results = new List<AssignmentFlocConfiguration>();

            foreach (WorkAssignmentDTO assignmentDto in sourcesAssignments)
            {
                List<FunctionalLocation> flocs =
                    functionalLocationDao.QueryByWorkAssignmentIdForWorkPermitAutoAssignment(assignmentDto.IdValue);

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