using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class GenricTemplateApprovalDao : AbstractManagedDao, IGenericTemplateApprovalDao
    {
        private const string INSERT_STORED_PROCEDURE = "InsertSpecialWork";
        private const string REMOVE_STORED_PROCEDURE = "RemoveSpecialWork";
        private const string UPDATE_STORED_PROCEDURE = "UpdateSpecialWork";
        private const string QUERY_BY_SITE_STORED_PROCEDURE = "QuerySpecialWorkBySite";

        private readonly ISiteDao siteDao;

        public GenricTemplateApprovalDao() 
        {
            siteDao = DaoRegistry.GetDao<ISiteDao>();
        }

        public List<GenericTemplateApproval> QueryBySite(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            return
                command.QueryForListResult<GenericTemplateApproval>(PopulateInstance, QUERY_BY_SITE_STORED_PROCEDURE);
        }

        public GenericTemplateApproval Insert(GenericTemplateApproval contractor)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(contractor, AddInsertParameters, INSERT_STORED_PROCEDURE);
            contractor.Id = long.Parse(idParameter.Value.ToString());
            return contractor;
        }

        public void Remove(GenericTemplateApproval contractor)
        {
            ManagedCommand.ExecuteNonQuery(contractor, REMOVE_STORED_PROCEDURE, AddRemoveParameters);
        }

        public void Update(GenericTemplateApproval contractor)
        {
            ManagedCommand.Update(contractor, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
        }

        private static void AddInsertParameters(GenericTemplateApproval contractor, SqlCommand command)
        {
            AddCommonParameters(command, contractor);
        }

        private static void AddCommonParameters(SqlCommand command, GenericTemplateApproval contractor)
        {
            command.AddParameter("@CompanyName", contractor.CompanyName);
            command.AddParameter("@SiteId",  contractor.Site.IdValue);
        }

        private static void AddRemoveParameters(GenericTemplateApproval contractor, SqlCommand command)
        {
            command.AddParameter("@Id",  contractor.Id);
        }

        private static void AddUpdateParameters(GenericTemplateApproval contractor, SqlCommand command)
        {
            command.AddParameter("@Id",  contractor.Id);
            AddCommonParameters(command, contractor);
        }

        private GenericTemplateApproval PopulateInstance(SqlDataReader reader)
        {
            long? id = reader.Get<long?>("Id");
            string companyName = reader.Get<string>("CompanyName");
            Site site = siteDao.QueryById(reader.Get<long>("SiteId"));

            return new GenericTemplateApproval(id, companyName, site);
        }
    }
}