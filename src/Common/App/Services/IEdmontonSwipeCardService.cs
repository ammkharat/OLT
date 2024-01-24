using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IEdmontonSwipeCardService
    {
        [OperationContract]
        void SyncOltWithCardSwipeSystem();

        [OperationContract]
        List<EdmontonPerson> QueryAll();
    }
}