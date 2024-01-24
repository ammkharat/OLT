using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain.PlantHistorian;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IHoneywellPhdConfigurationService
    {
        [OperationContract]
        List<ScadaConnectionInfo> QueryBySiteId(long siteId);

        [OperationContract]
        ScadaConnectionInfo QueryByScadaConnectionInfoId(long scadaConnectionInfoId);
        
        [OperationContract]
        List<ScadaConnectionInfo> QueryAll();

        [OperationContract]
        void Update(ScadaConnectionInfo connectionInfo);
    }
}