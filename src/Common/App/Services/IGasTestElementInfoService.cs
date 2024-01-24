using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IGasTestElementInfoService
    {
        [OperationContract]
        List<GasTestElementInfo> QueryStandardElementInfosBySiteId(long siteId);

        [OperationContract]
        void UpdateGasTestElementInfoList(List<GasTestElementInfo> infoList);

        [OperationContract]
        List<GasTestElementInfoDTO> QueryStandardElementInfoDTOsBySiteId(long siteId);

        [OperationContract]
        void UpdateGasTestElementInfoDTOList(List<GasTestElementInfoDTO> infoDTOList);
    }
}