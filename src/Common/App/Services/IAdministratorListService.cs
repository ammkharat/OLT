using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IAdministratorListService
    {
        [OperationContract]
        void Remove(long id);

        [OperationContract]
        List<AdministratorList> QueryAdminMember();

        [OperationContract]
        void Insert(AdministratorList editObject);

        [OperationContract]
        void Update(AdministratorList editObject);
    }
}