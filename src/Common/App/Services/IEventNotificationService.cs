using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IEventNotificationService
    {
        [OperationContract(IsOneWay = true)]
        void Notify(DomainEventArgs<DomainObject> e);
    }
}