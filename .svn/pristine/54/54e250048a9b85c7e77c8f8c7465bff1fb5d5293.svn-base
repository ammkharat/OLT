using System;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.DTO.Excursions;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IExcursionImportService
    {
        [OperationContract]
        OpmExcursionImportResult ImportOpmExcursionDtosFromDate(DateTime dateAndTimeQueryFrom);

        [OperationContract]
        OpmToeDefinitionImportResult ImportOpmToeDefinition(string historianTag, long? versionId);

        [OperationContract]
        OpmTagValueDTO GetCurrentOpmTagValue(string historianTag);

        [OperationContract]
        DateTime GetMostRecentExcursionUpdateDateTime();

        [OperationContract]
        OpmExcursionImportStatusDTO GetLastSuccessfulExcursionImportStatus();

        [OperationContract]
        void UpdateExcursionImportStatus(OpmExcursionImportStatusDTO opmExcursionImportStatusDTO);

        [OperationContract]
        void NotifyOpmExcursionImportStatus(OpmExcursionImportStatusDTO opmExcursionImportStatusDTO,
            ApplicationEvent applicationEvent);

        [OperationContract]
        void NotifyOpmExcursionItemRefresh(Site site);
    }
}