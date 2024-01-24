using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Wcf;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IEventService
    {
        [OperationContract]
        void Subscribe(string clientAddress, List<FunctionalLocation> relevantFunctionalLocations, List<FunctionalLocation> workPermitEdmontonRelevantFunctionalLocations, List<FunctionalLocation> rootFlocSetForRestrictions, List<long> clientReadableVisibilityGroupIds, long? siteId, string machineName, EventConnectDisconnectReason reason);

        [OperationContract]
        void Unsubscribe(string clientAddress, EventConnectDisconnectReason reason);

        [OperationContract(IsOneWay = true)]
        [NonTransactionalOperation]
        void PublishEvent(DomainEventArgs<DomainObject> domainObjectArgs, InitiatingEventSink initiatingEventSink);
    }
}