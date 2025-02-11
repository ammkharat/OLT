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
    public interface IConfinedSpaceMudsService
    {
        [OperationContract]
        ConfinedSpaceMuds QueryById(long id);

        [OperationContract]
        List<ConfinedSpaceMudsDTO> QueryByFlocUnitAndBelow(
            IFlocSet flocSet, DateRange dateRange);

        [OperationContract]
        List<NotifiedEvent> Insert(ConfinedSpaceMuds confinedSpace);

        [OperationContract]
        List<NotifiedEvent> Update(ConfinedSpaceMuds confinedSpace);

        [OperationContract]
        List<NotifiedEvent> Remove(ConfinedSpaceMuds arg);
        //Added by ppanigrahi
        [OperationContract]
        ConfinedSpaceMudSign GetConfinedSpaceSign(string ConfinedSpaceId, int SiteId);
        [OperationContract]
        void InserUpdateConfinedSpaceSign(ConfinedSpaceMudSign confinedSpaceSign);
    }
}