using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IConfinedSpaceService
    {
        [OperationContract]
        ConfinedSpace QueryById(long id);

        [OperationContract]
        List<ConfinedSpaceDTO> QueryByFlocUnitAndBelow(
            IFlocSet flocSet, DateRange dateRange);

        [OperationContract]
        List<NotifiedEvent> Insert(ConfinedSpace confinedSpace);

        [OperationContract]
        List<NotifiedEvent> Update(ConfinedSpace confinedSpace);

        [OperationContract]
        List<NotifiedEvent> Remove(ConfinedSpace arg);
    }
}