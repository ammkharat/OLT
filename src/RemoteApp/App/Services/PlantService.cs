using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class PlantService : IPlantService
    {
        private readonly IPlantDao dao;

        public PlantService()
        {
            dao = DaoRegistry.GetDao<IPlantDao>();
        }

        public Plant QueryById(long id)
        {
            return dao.QueryById(id);
        }
    }
}