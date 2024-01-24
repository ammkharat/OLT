using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class CraftOrTradeDao : AbstractManagedDao, ICraftOrTradeDao
    {
        private const string QueryByIdStoredProcedure = "QueryCraftOrTradeById";
        private const string QueryByIdNotDeletedStoredProcedure = "QueryCraftOrTradeByIdNotDeleted";
        private const string QueryBySiteIdStoredProcedure = "QueryCraftOrTradesBySiteId";
        private const string QueryByNameAndWorkCentreAndSiteIdStoredProcedure = "QueryCraftOrTradesByNameAndWorkCentreAndSiteId";
        private const string QueryByWorkCentreAndSiteIdStoredProcedure = "QueryCraftOrTradeByWorkCenterAndSiteId";
        private const string QueryByWorkCentreNameAndSiteIdStoredProcedure = "QueryCraftOrTradeByWorkCentreNameAndSiteId";

        private const string InsertStoredProcedure = "InsertCraftOrTrade";
        private const string UpdateStoredProcedure = "UpdateCraftOrTrade";
        private const string RemoveStoredProcedure = "RemoveCraftOrTrade";

        //mangesh for RoadAccessOnPermit
        private const string QueryRoadAccessOnPermitByNameAndWorkCentreAndSiteIdStoredProcedure = "QueryRoadAccessOnPermitByNameAndWorkCentreAndSiteId";
        private const string QueryBySiteIdStoredProcedureRoadAccessOnPermit = "QueryRoadAccessOnPermitBySiteId";
        private const string InsertRoadAccessPermit = "InsertRoadAccessOnPermit";
        private const string UpdateRoadAccessPermit = "UpdateRoadAccessOnPermit";
        private const string RemoveRoadAccessPermit = "RemoveRoadAccessOnPermit";


        public CraftOrTrade QueryById(long id)
        {
            return ManagedCommand.QueryById<CraftOrTrade>(id, PopulateInstance, QueryByIdStoredProcedure);
        }

        public CraftOrTrade QueryByIdAndNotDeleted(long id)
        {
            return ManagedCommand.QueryById<CraftOrTrade>(id, PopulateInstance, QueryByIdNotDeletedStoredProcedure);
        }

        public CraftOrTrade QueryByWorkCentreNameAndSiteId(string workCentreName, long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("@Name", workCentreName);

            return command.QueryForSingleResult<CraftOrTrade>(PopulateInstance, QueryByWorkCentreNameAndSiteIdStoredProcedure);
        }

        public CraftOrTrade QueryByWorkCentreCodeAndSiteId(string workCentreCode, long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("@WorkCenter", workCentreCode);

            return command.QueryForSingleResult<CraftOrTrade>(PopulateInstance, QueryByWorkCentreAndSiteIdStoredProcedure);
        }

        public CraftOrTrade QueryByWorkCentreAndNameAndSiteId(string workCentreCode, string name, long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("@WorkCenter", workCentreCode);
            command.AddParameter("@Name", name);

            return command.QueryForSingleResult<CraftOrTrade>(PopulateInstance, QueryByNameAndWorkCentreAndSiteIdStoredProcedure);
        }

        public CraftOrTrade QueryRoadAccessOnPermitByWorkCentreAndNameAndSiteId(string workCentreCode, string name, long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("@WorkCenter", workCentreCode);
            command.AddParameter("@Name", name);

            return command.QueryForSingleResult<CraftOrTrade>(PopulateInstance, QueryRoadAccessOnPermitByNameAndWorkCentreAndSiteIdStoredProcedure);
        }

        public List<CraftOrTrade> QueryBySiteId(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            return
                command.QueryForListResult<CraftOrTrade>(PopulateInstance, QueryBySiteIdStoredProcedure);
        }

        public List<CraftOrTrade> QueryBySiteIdRoadAccessOnPermit(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            return
                command.QueryForListResult<CraftOrTrade>(PopulateInstance, QueryBySiteIdStoredProcedureRoadAccessOnPermit);
        }
        
        public List<CraftOrTrade> QueryBySiteIdNoCache(long siteId)
        {
            return QueryBySiteId(siteId);
        }

        public List<CraftOrTrade> QueryBySiteIdNoCacheRoadAccessOnPermit(long siteId)
        {
            return QueryBySiteIdRoadAccessOnPermit(siteId);
        }
        
        public CraftOrTrade Insert(CraftOrTrade craftOrTrade)
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.AddIdOutputParameter();
            command.AddParameter("@SiteId", craftOrTrade.SiteId);
            command.Insert(craftOrTrade, SetCommonAttributes, InsertStoredProcedure);
            craftOrTrade.Id = (long?) idParameter.Value;
            return craftOrTrade;
        }

        public void Update(CraftOrTrade craftOrTrade)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", craftOrTrade.Id);
            command.Insert(craftOrTrade, SetCommonAttributes, UpdateStoredProcedure);
        }

        public void Remove(CraftOrTrade craftOrTrade)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("Id", craftOrTrade.IdValue);
            command.Update(RemoveStoredProcedure);
        }

        public CraftOrTrade InsertRoadAccessOnPermit(CraftOrTrade craftOrTrade)
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.AddIdOutputParameter();
            command.AddParameter("@SiteId", craftOrTrade.SiteId);
            command.Insert(craftOrTrade, SetCommonAttributes, InsertRoadAccessPermit);
            craftOrTrade.Id = (long?)idParameter.Value;
            return craftOrTrade;
        }

        public void UpdateRoadAccessOnPermit(CraftOrTrade craftOrTrade)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", craftOrTrade.Id);
            command.Insert(craftOrTrade, SetCommonAttributes, UpdateRoadAccessPermit);
        }

        public void RemoveRoadAccessOnPermit(CraftOrTrade craftOrTrade)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("Id", craftOrTrade.IdValue);
            command.Update(RemoveRoadAccessPermit);
        }

        private void SetCommonAttributes(CraftOrTrade craftOrTrade, SqlCommand command)
        {
            command.AddParameter("@Name", craftOrTrade.Name);
            command.AddParameter("@WorkCenter", craftOrTrade.WorkCenterCode);                        
        }

        private CraftOrTrade PopulateInstance(SqlDataReader reader)
        {
            long? newId = reader.Get<long?>("Id");
            string name = reader.Get<string>("Name");
            string workCenterId = reader.Get<string>("WorkCenter");
            long siteId = reader.Get<long>("SiteId");

            return new CraftOrTrade(newId, name, workCenterId, siteId);
        }
    }
}