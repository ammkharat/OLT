using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class GasTestElementInfoService : IGasTestElementInfoService
    {
        private readonly IGasTestElementInfoDao dao;
        private readonly IGasTestElementInfoDTODao dtoDao;

        public GasTestElementInfoService()
        {
            dao = DaoRegistry.GetDao<IGasTestElementInfoDao>();
            dtoDao = DaoRegistry.GetDao<IGasTestElementInfoDTODao>();
        }

        public List<GasTestElementInfo> QueryStandardElementInfosBySiteId(long siteId)
        {
            return dao.QueryStandardInfosBySiteId(siteId);
        }

        public List<GasTestElementInfoDTO> QueryStandardElementInfoDTOsBySiteId(long siteId)
        {
            return dtoDao.QueryStandardInfoDTOsBySiteId(siteId);
        }

        public void UpdateGasTestElementInfoList(List<GasTestElementInfo> infoList)
        {
            foreach (GasTestElementInfo info in infoList)
            {
                dao.Update(info);
            }
        }

        public void UpdateGasTestElementInfoDTOList(List<GasTestElementInfoDTO> infoDTOList)
        {
            foreach (GasTestElementInfoDTO dto in infoDTOList)
            {
                dtoDao.Update(dto);
            }
        }
    }
}
