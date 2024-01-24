using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IAreaLabelService
    {
        [OperationContract]
        List<AreaLabel> QueryBySiteId(long siteId);

        [OperationContract]
        void Update(List<AreaLabel> areaLabels, List<AreaLabel> deletedAreaLabels);
    }
}