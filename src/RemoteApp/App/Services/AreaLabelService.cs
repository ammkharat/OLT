using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class AreaLabelService : IAreaLabelService
    {
        private readonly IAreaLabelDao dao;

        public AreaLabelService()
        {
            dao = DaoRegistry.GetDao<IAreaLabelDao>();
        }

        public List<AreaLabel> QueryBySiteId(long siteId)
        {
            return dao.QueryBySiteId(siteId);
        }

        public void Update(List<AreaLabel> areaLabels, List<AreaLabel> deletedAreaLabels)
        {
            foreach (AreaLabel areaLabel in deletedAreaLabels)
            {
                dao.Remove(areaLabel);
            }

            List<AreaLabel> newAreaLabels = areaLabels.FindAll(obj => !obj.IsInDatabase());
            List<AreaLabel> possiblyChangedAreaLabels = areaLabels.FindAll(obj => obj.IsInDatabase());

            foreach (AreaLabel areaLabel in possiblyChangedAreaLabels)
            {
                dao.Update(areaLabel);
            }

            foreach (AreaLabel areaLabel in newAreaLabels)
            {
                dao.Insert(areaLabel);
            }
        }
    }
}
