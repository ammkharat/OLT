using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IRestrictionDefinitionService
    {
        [OperationContract]
        RestrictionDefinition QueryById(long id);

        [OperationContract]
        List<RestrictionDefinitionDTO> QueryByFunctionalLocationsAndTheirChildrenFunctionalLocations(IFlocSet flocSet,
            Range<Date> dateRange);

        [OperationContract]
        SchedulingList<RestrictionDefinition, OLTException> QueryAllAvailableForScheduling();

        [OperationContract]
        List<NotifiedEvent> Insert(RestrictionDefinition restrictionDefinition);

        [OperationContract]
        List<NotifiedEvent> Update(RestrictionDefinition restrictionDefinition);

        [OperationContract]
        void UpdateLastInvokedDateTime(RestrictionDefinition restrictionDefinition);

        [OperationContract]
        List<NotifiedEvent> Remove(RestrictionDefinition restrictionDefinition);

        [OperationContract]
        void UpdateStatusForValidTag(TagInfo tag, Site site);

        [OperationContract]
        void UpdateStatusForInvalidTag(TagInfo tag, Site site);

        [OperationContract]
        Error IsValidName(string name, Site site, RestrictionDefinition restrictionDefinition);
    }
}