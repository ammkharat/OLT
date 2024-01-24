using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IDeviationAlertService
    {
        [OperationContract]
        DateTime? EvaluateDefinition(RestrictionDefinition definition, DateTime currentInvocationDateTime);

        [OperationContract]
        DeviationAlert QueryById(long id);

        [OperationContract]
        List<DeviationAlertDTO> QueryDTOsByFLOCAndDaysPrecedingGivenDate(
            IFlocSet flocSet, Range<Date> dateRange);

        [OperationContract]
        List<DeviationAlertDTO> QueryDTOsByFLOCAndShift(
            IFlocSet flocSet, UserShift userShift);

        [OperationContract]
        bool IsWithinDaysToEditResponse(Site site, List<DeviationAlertDTO> alerts);

        [OperationContract]
        List<NotifiedEvent> UpdateDeviationAlertComment(DeviationAlert deviationAlert, DateTime lastModifiedDate,
            User lastModifiedBy);

        [OperationContract]
        List<NotifiedEvent> UpdateDeviationAlertResponse(DeviationAlert deviationAlert, DateTime lastModifiedDate,
            User lastModifiedBy);

        [OperationContract]
        DeviationAlert GetLastRespondedToAlert(RestrictionDefinition restrictionDefinition);
    }
}