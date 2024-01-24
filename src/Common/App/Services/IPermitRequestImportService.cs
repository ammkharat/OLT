using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IPermitRequestImportService
    {
        [OperationContract]
        PermitRequestImportResult Import(User user, Date from, string workOrderNumber,
            List<FunctionalLocation> userDivisions);

        [OperationContract]
        DateTime? GetLastImportDateTime();
    }
}