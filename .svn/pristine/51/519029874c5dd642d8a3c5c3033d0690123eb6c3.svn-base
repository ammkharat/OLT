using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface INumericAndNonnumericCustomFieldEntryListService
    {
        [OperationContract]
        List<NumericCustomFieldEntryDTO> QueryNumericCustomFieldEntries(long customFieldId, long workAssignmentId,
            Site site, DateRange dateRange);

        [OperationContract]
        List<NonnumericCustomFieldEntryDTO> QueryNonnumericCustomFieldEntries(long customFieldId, long workAssignmentId,
            Site site, DateRange dateRange);
    }
}