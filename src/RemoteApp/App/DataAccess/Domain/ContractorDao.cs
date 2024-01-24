using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ContractorDao : AbstractManagedDao, IContractorDao
    {
        private const string INSERT_STORED_PROCEDURE = "InsertContractor";
        private const string REMOVE_STORED_PROCEDURE = "RemoveContractor";
        private const string UPDATE_STORED_PROCEDURE = "UpdateContractor";
        private const string QUERY_BY_SITE_STORED_PROCEDURE = "QueryContractorsBySite";

        private readonly ISiteDao siteDao;

        public ContractorDao() 
        {
            siteDao = DaoRegistry.GetDao<ISiteDao>();
        }

        public List<Contractor> QueryBySite(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            return
                command.QueryForListResult<Contractor>(PopulateInstance, QUERY_BY_SITE_STORED_PROCEDURE);
        }

        public Contractor Insert(Contractor contractor)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(contractor, AddInsertParameters, INSERT_STORED_PROCEDURE);
            contractor.Id = long.Parse(idParameter.Value.ToString());
            return contractor;
        }

        public void Remove(Contractor contractor)
        {
            ManagedCommand.ExecuteNonQuery(contractor, REMOVE_STORED_PROCEDURE, AddRemoveParameters);
        }

        public void Update(Contractor contractor)
        {
            ManagedCommand.Update(contractor, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
        }

        private static void AddInsertParameters(Contractor contractor, SqlCommand command)
        {
            AddCommonParameters(command, contractor);
        }

        private static void AddCommonParameters(SqlCommand command, Contractor contractor)
        {
            command.AddParameter("@CompanyName", contractor.CompanyName);
            command.AddParameter("@SiteId",  contractor.Site.IdValue);
        }

        private static void AddRemoveParameters(Contractor contractor, SqlCommand command)
        {
            command.AddParameter("@Id",  contractor.Id);
        }

        private static void AddUpdateParameters(Contractor contractor, SqlCommand command)
        {
            command.AddParameter("@Id",  contractor.Id);
            AddCommonParameters(command, contractor);
        }
        
        private Contractor PopulateInstance(SqlDataReader reader)
        {
            long? id = reader.Get<long?>("Id");
            string companyName = reader.Get<string>("CompanyName");
            Site site = siteDao.QueryById(reader.Get<long>("SiteId"));
            
            return new Contractor(id, companyName, site);
        }
    }
}