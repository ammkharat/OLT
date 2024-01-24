using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class PermitAttributeDao : AbstractManagedDao, IPermitAttributeDao
    {
        private const string QUERY_BY_SITE_STORED_PROCEDURE = "QueryPermitAttributesBySiteId";
        
        private const string QUERY_BY_PERMIT_REQUEST_MONTREAL_STORED_PROCEDURE = "QueryPermitAttributesByPermitRequestMontrealId";
        private const string QUERY_BY_WORK_PERMIT_MONTREAL_STORED_PROCEDURE = "QueryPermitAttributesByWorkPermitMontrealId";
        private const string QUERY_BY_PERMIT_REQUEST_MUDS_STORED_PROCEDURE = "QueryPermitAttributesByPermitRequestMudsId";

        public List<PermitAttribute> QueryBySiteId(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            return command.QueryForListResult<PermitAttribute>(PopulateInstance, QUERY_BY_SITE_STORED_PROCEDURE);
        }

        public IEnumerable<PermitAttribute> QueryByPermitRequestMontreal(PermitRequestMontreal permitRequest)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@PermitRequestId", permitRequest.IdValue);
            return command.QueryForListResult<PermitAttribute>(PopulateInstance, QUERY_BY_PERMIT_REQUEST_MONTREAL_STORED_PROCEDURE);            
        }

        public IEnumerable<PermitAttribute> QueryByWorKPermitMontreal(WorkPermitMontreal permit)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitMontrealId", permit.IdValue);
            return command.QueryForListResult<PermitAttribute>(PopulateInstance, QUERY_BY_WORK_PERMIT_MONTREAL_STORED_PROCEDURE);
        }

        //RITM0301321 mangesh
        public IEnumerable<PermitAttribute> QueryByPermitRequestMuds(PermitRequestMuds permitRequest)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@PermitRequestId", permitRequest.IdValue);
            return command.QueryForListResult<PermitAttribute>(PopulateInstance, QUERY_BY_PERMIT_REQUEST_MUDS_STORED_PROCEDURE);
        }

        private static PermitAttribute PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string name = reader.Get<string>("Name");
            string sapCode = reader.Get<string>("SapCode");
            long siteId = reader.Get<long>("SiteId");

            return new PermitAttribute(id, name, sapCode, siteId);
        }
    }
}