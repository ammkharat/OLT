using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class AdministratorListService : IAdministratorListService
    {
        private readonly IAdministratorListDao dao;

        public AdministratorListService()
        {
            dao = DaoRegistry.GetDao<IAdministratorListDao>();
        }
        
        public void Remove(long id)
        {
            dao.RemoveAdminMember(id);
        }

        public List<AdministratorList> QueryAdminMember()
        {
            return dao.QueryAdminMember();
        }
        
        public void Insert(AdministratorList editObject)
        {
            dao.InsertAdminMember(editObject);
        }

        public void Update(AdministratorList editObject)
        {
            dao.UpdateAdminMember(editObject);
        }

        
    }
}