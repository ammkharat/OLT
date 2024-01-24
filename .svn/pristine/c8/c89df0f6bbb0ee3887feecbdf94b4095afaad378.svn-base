using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface ILogTemplateService
    {
        [OperationContract]
        LogTemplate Insert(LogTemplate logTemplate);

        [OperationContract]
        List<LogTemplate> QueryBySite(Site site);

        [OperationContract]
        void Update(LogTemplate logTemplate);

        [OperationContract]
        void Delete(LogTemplate logTemplate);

        [OperationContract]
        List<LogTemplateDTO> QueryByWorkAssignmentReturnOnlyUniqueLogTemplates(WorkAssignment workAssignments,
            LogTemplate.LogType logType);

        [OperationContract]
        List<LogTemplate> QueryLogTemplatesSetAsAutoInsertForTheseAssignments(List<WorkAssignment> workAssignments);

        [OperationContract]
        LogTemplate QueryById(long logTemplateId);
    }
}