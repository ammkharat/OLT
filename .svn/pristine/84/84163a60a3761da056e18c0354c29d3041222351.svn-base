using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class CraftOrTradeService : ICraftOrTradeService
    {
        private readonly ICraftOrTradeDao dao;
        private readonly IWorkPermitService workPermitService;
        
        public CraftOrTradeService() : this(new WorkPermitService())
        {
        }

        public CraftOrTradeService(IWorkPermitService workPermitService)
        {
            this.workPermitService = workPermitService;
            dao = DaoRegistry.GetDao<ICraftOrTradeDao>();
        }

        public CraftOrTrade QueryById(long craftOrTradeId)
        {
            return dao.QueryById(craftOrTradeId);
        }

        /// <summary>
        /// Queries first the work center code and if not found, then the name to find an existing craft or trade
        /// </summary>
        /// <param name="workCentreCode"> </param>
        /// <param name="workCentreFullName"> </param>
        /// <param name="siteId"> </param>
        /// <returns></returns>
        public CraftOrTrade QueryByWorkCenterOrName(string workCentreCode, string workCentreFullName, long siteId)
        {
            CraftOrTrade retrievedCraftOrTrade = null;

            //try the work center id
            if (workCentreCode.HasValue())
                retrievedCraftOrTrade = dao.QueryByWorkCentreCodeAndSiteId(workCentreCode, siteId);

            //none by work center id so try the name
            if (retrievedCraftOrTrade == null && workCentreFullName.HasValue())
                retrievedCraftOrTrade = dao.QueryByWorkCentreNameAndSiteId(workCentreFullName, siteId);

            return retrievedCraftOrTrade;
        }

        public CraftOrTrade QueryByWorkCentreAndNameAndSiteId(string workCentre, string name, long siteId)
        {
            return dao.QueryByWorkCentreAndNameAndSiteId(workCentre, name, siteId);
        }
        //mangesh for RoadAccessOnPermit Methods
        public List<CraftOrTrade> QueryBySiteIdRoadAccessOnPermit(Site site)
        {
            List<CraftOrTrade> list = dao.QueryBySiteIdRoadAccessOnPermit(site.IdValue);
            return list.Unique(cot => cot.Name);
        }

            public List<CraftOrTrade> QueryBySite(Site site)
        {
            List<CraftOrTrade> list = dao.QueryBySiteId(site.IdValue);
            return list.Unique(cot => cot.Name);
        }

        public List<CraftOrTrade> QueryBySiteNoCache(Site site)
        {
            return dao.QueryBySiteIdNoCache(site.IdValue);
        }

        public CraftOrTrade Insert(CraftOrTrade craftOrTrade)
        {
            CraftOrTrade insertedCraftOrTrade = dao.Insert(craftOrTrade);
            return insertedCraftOrTrade;
        }

        public void Update(CraftOrTrade craftOrTrade)
        {
            dao.Update(craftOrTrade);
        }

        public void Remove(CraftOrTrade craftOrTrade)
        {
            workPermitService.UpdateWorkPermitsOnDeletedCraftOrTrade(craftOrTrade.Id);
            dao.Remove(craftOrTrade);
        }

        public CraftOrTrade QueryRoadAccessOnPermitByWorkCentreAndNameAndSiteId(string workCentre, string name, long siteId)
        {
            return dao.QueryRoadAccessOnPermitByWorkCentreAndNameAndSiteId(workCentre, name, siteId);
        }

        public List<CraftOrTrade> QueryBySiteNoCacheRoadAccessOnPermit(Site site)
        {
            return dao.QueryBySiteIdNoCacheRoadAccessOnPermit(site.IdValue);
        }

        public CraftOrTrade InsertRoadAccesOnPermit(CraftOrTrade craftOrTrade)
        {
            CraftOrTrade insertedCraftOrTrade = dao.InsertRoadAccessOnPermit(craftOrTrade);
            return insertedCraftOrTrade;
        }

        public void UpdateRoadAccesOnPermit(CraftOrTrade craftOrTrade)
        {
            dao.UpdateRoadAccessOnPermit(craftOrTrade);
        }

        public void RemoveRoadAccesOnPermit(CraftOrTrade craftOrTrade)
        {
            //workPermitService.UpdateWorkPermitsOnDeletedCraftOrTrade(craftOrTrade.Id);
            dao.RemoveRoadAccessOnPermit(craftOrTrade);
        }


    }
}