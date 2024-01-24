using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using System.Data;
using System.Drawing.Text;
using Com.Suncor.Olt.Common.Annotations;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class GenericTemplateApprovalDao : AbstractManagedDao, IGenericTemplateApprovalDao
    {
        private const string INSERT_STORED_PROCEDURE = "InsertFormGenericTemplateApprover";
        private const string REMOVE_STORED_PROCEDURE = "RemoveFormGenericTemplateApprover";
        private const string UPDATE_STORED_PROCEDURE = "UpdateFormGenericTemplateApprover";
        private const string QUERY_BY_SITE_STORED_PROCEDURE = "QueryFormGenericTemplateApproverBySite";
        private const string QUERY_BY_SITE_EMAIL_STORED_PROCEDURE = "QueryFormGenericTemplateEmailApproverBySite";
        private const string QUERY_FOR_EGENERICFORMSSITE_STORED_PROCEDURE = "QueryFormGenericTemplateEFormsBySite";
        private const string UPDATE_TEMPLATE_STORED_PROCEDURE = "UpdateFormGenericTemplateHeader";//
        private const string QUERY_BY_SITE_EGENERICEMAIL_STORED_PROCEDURE = "QueryFormGenericTemplateEmailEFormsBySite";//Added by ppanigrahi
        private const string INSERT_STORED_PROCEDURE_EMAIL = "InsertFormGenericTemplateEmailApprover";//Added by ppanigrahi
        private const string UPDATE__STORED_PROCEDURE_EMAIL = "UpdateFormGenericTemplateEmailByApprover";//Added by ppanigrahi
        private const string REMOVE_STORED_PROCEDURE_EMAIL = "RemoveFormGenericTemplateApproverEmail";//Added by ppanigrahi
        private const string UPDATE_TEMPLATE_STORED_PROCEDURE_EMAIL = "UpdateFormGenericTemplateHeaderEmail";//Added by ppanigrahi
        private const string QUERY_BY_SITE_EMAILLIST = "QueryEmailListApproverBySite";

        private readonly ISiteDao siteDao;

        public GenericTemplateApprovalDao()
        {
            siteDao = DaoRegistry.GetDao<ISiteDao>();
        }

        public List<GenericTemplateApproval> QueryBySite(long siteId, long plantId, long formTypeId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("@PlantId", plantId);
            command.AddParameter("@FormTypeId", formTypeId);
            return
                command.QueryForListResult<GenericTemplateApproval>(PopulateInstance, QUERY_BY_SITE_STORED_PROCEDURE);
        }
        //Added by ppanigrahi
        public List<GenericTemplateEmailApprovalConfiguration> QueryByEmailSite(long siteId, long formTypeId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("@FormTypeId", formTypeId);
            return
                command.QueryForListResult<GenericTemplateEmailApprovalConfiguration>(PopulateInstanceEmail, QUERY_BY_SITE_EMAIL_STORED_PROCEDURE);
        }

        public string QueryEmailListApproverBySite(long siteId, long formTypeId, string name)
        {

            string Name = "";
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("@FormTypeId", formTypeId);
            command.AddParameter("@Name", name);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {

                Name = dr["Name"].ToString();
            }

            return Name;
        }

        public List<GenericTemplateApproval> QueryForEGenericForms(long siteId, long plantId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("@PlantId", plantId);
            return
                command.QueryForListResult<GenericTemplateApproval>(PopulateInstance, QUERY_FOR_EGENERICFORMSSITE_STORED_PROCEDURE);
        }
        //Added by ppanigrahi
        public List<GenericTemplateEmailApprovalConfiguration> QueryFormGenericTemplateEmailEFormsBySite(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);

            return
                command.QueryForListResult<GenericTemplateEmailApprovalConfiguration>(PopulateInstanceEmailSite, QUERY_BY_SITE_EGENERICEMAIL_STORED_PROCEDURE);
        }
        public GenericTemplateApproval Insert(GenericTemplateApproval contractor)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(contractor, AddInsertParameters, INSERT_STORED_PROCEDURE);
            contractor.Id = long.Parse(idParameter.Value.ToString());
            return contractor;
        }
        //Addded by ppanigrahi
        public GenericTemplateEmailApprovalConfiguration InsertEmail(GenericTemplateEmailApprovalConfiguration contractor)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(contractor, AddInsertParametersEmail, INSERT_STORED_PROCEDURE_EMAIL);
            contractor.Id = long.Parse(idParameter.Value.ToString());
            return contractor;
        }

        public void Remove(GenericTemplateApproval contractor)
        {
            ManagedCommand.ExecuteNonQuery(contractor, REMOVE_STORED_PROCEDURE, AddRemoveParameters);
        }
        //Added by ppanigrahi
        public void RemoveEmail(GenericTemplateEmailApprovalConfiguration contractor)
        {
            ManagedCommand.ExecuteNonQuery(contractor, REMOVE_STORED_PROCEDURE_EMAIL, AddRemoveParametersEmail);
        }
        public void Update(GenericTemplateApproval contractor)
        {
            ManagedCommand.Update(contractor, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
        }
        //Added by ppanigrahi

        public GenericTemplateEmailApprovalConfiguration UpdateEmail(GenericTemplateEmailApprovalConfiguration contractor)
        {
            //SqlCommand command = ManagedCommand;
            ManagedCommand.Update(contractor, AddUpdateParametersEmail, UPDATE__STORED_PROCEDURE_EMAIL);
            //command.CommandText = "UpdateFormGenericTemplateEmailByApprover";
            //command.AddParameter("@FormTypeId", contractor.FormTypeId);
            //command.AddParameter("@PlantId", contractor.PlantId);
            //command.AddParameter("@SiteId", contractor.Site.IdValue);
            //command.AddParameter("@Name", contractor.CompanyName);
            //command.AddParameter("@EmailList", contractor.EmailList);
            //command.ExecuteNonQuery();


            return contractor;
            //ManagedCommand.EndExecuteNonQuery(()//ManagedCommand.Update(contractor, AddUpdateParametersEmail, UPDATE__STORED_PROCEDURE_EMAIL);
        }
        private static void AddInsertParameters(GenericTemplateApproval contractor, SqlCommand command)
        {
            AddCommonParameters(command, contractor);
        }
        //Added by ppanigrahi
        private static void AddInsertParametersEmail(GenericTemplateEmailApprovalConfiguration contractor, SqlCommand command)
        {
            AddCommonParametersEmail(command, contractor);
        }
        private static void AddCommonParameters(SqlCommand command, GenericTemplateApproval contractor)
        {
            command.AddParameter("@Name", contractor.CompanyName);
            command.AddParameter("@FormTypeId", contractor.FormTypeId);
            command.AddParameter("@PlantId", contractor.PlantId);
            command.AddParameter("@SiteId", contractor.Site.IdValue);


        }
        //Added by ppanigrahi
        private static void AddCommonParametersEmail(SqlCommand command, GenericTemplateEmailApprovalConfiguration contractor)
        {

            command.AddParameter("@FormTypeId", contractor.FormTypeId);
            command.AddParameter("@PlantId", contractor.PlantId);
            command.AddParameter("@SiteId", contractor.Site.IdValue);
            command.AddParameter("@Name", contractor.CompanyName);
            command.AddParameter("@EmailList", contractor.EmailList);


        }

        private static void AddRemoveParameters(GenericTemplateApproval contractor, SqlCommand command)
        {
            command.AddParameter("@Id", contractor.Id);
        }
        //Added by ppanigrahi
        private static void AddRemoveParametersEmail(GenericTemplateEmailApprovalConfiguration contractor, SqlCommand command)
        {
            command.AddParameter("@FormTypeID", contractor.FormTypeId);
            command.AddParameter("@SiteID", contractor.Site.IdValue);
            command.AddParameter("@PlantID", contractor.PlantId);
            command.AddParameter(" @Name", contractor.CompanyName);
            command.AddParameter("@EmailList", contractor.EmailList);
            //  AddCommonParameters(command, contractor);
        }

        private static void AddUpdateParameters(GenericTemplateApproval contractor, SqlCommand command)
        {
            command.AddParameter("@Id", contractor.Id);
            AddCommonParameters(command, contractor);
        }
        //Added by ppanigrahi
        private static void AddUpdateParametersEmail(GenericTemplateEmailApprovalConfiguration contractor, SqlCommand command)
        {
            // command.AddParameter("@", contractor.Id);
            AddCommonParametersEmail(command, contractor);
        }
        private GenericTemplateApproval PopulateInstance(SqlDataReader reader)
        {
            long? id = reader.Get<long?>("Id");
            long formTypeId = reader.Get<long>("FormTypeId");
            long plantId = reader.Get<long>("PlantId");
            string Name = reader.Get<string>("Name");
            Site site = siteDao.QueryById(reader.Get<long>("SiteId"));
            //DMND0009363-#950321920-Mukesh
            GenericTemplateApproval objTemplate = new GenericTemplateApproval(id, Name, site, formTypeId, plantId);
            if (IsclumnExistinReader(reader, "isNeverEnd"))
                objTemplate.ShowneverEnd = reader.Get<bool>("isNeverEnd");

            return objTemplate;
            // return new GenericTemplateApproval(id, Name, site, formTypeId, plantId);        

        }
        //Added by ppanigrahi
        private GenericTemplateEmailApprovalConfiguration PopulateInstanceEmailSite(SqlDataReader reader)
        {
            long? id = reader.Get<long?>("Id");
            long formTypeId = reader.Get<long>("FormTypeId");
            long plantId = reader.Get<long>("PlantId");
            string Name = reader.Get<string>("Name");
            Site site = siteDao.QueryById(reader.Get<long>("SiteId"));
            // string emaillist = reader.Get<string>("EmailList");
            GenericTemplateEmailApprovalConfiguration objTemplate = new GenericTemplateEmailApprovalConfiguration(id, Name, site, formTypeId, plantId, null);
            if (IsclumnExistinReader(reader, "isNeverEnd"))
                objTemplate.ShowneverEnd = reader.Get<bool>("isNeverEnd");

            return objTemplate;
            // return new GenericTemplateApproval(id, Name, site, formTypeId, plantId);        

        }

        //Added by ppanigrahi

        private GenericTemplateEmailApprovalConfiguration PopulateInstanceEmail(SqlDataReader reader)
        {
            long? id = reader.Get<long?>("Id");
            long formTypeId = reader.Get<long>("FormTypeId");
            long plantId = reader.Get<long>("PlantId");
            string Name = reader.Get<string>("Name");
            Site site = siteDao.QueryById(reader.Get<long>("SiteId"));
            string emaillist = reader.Get<string>("EmailList");
            GenericTemplateEmailApprovalConfiguration objTemplate = new GenericTemplateEmailApprovalConfiguration(id, Name, site, formTypeId, plantId, emaillist);
            if (IsclumnExistinReader(reader, "isNeverEnd"))
                objTemplate.ShowneverEnd = reader.Get<bool>("isNeverEnd");

            return objTemplate;
            // return new GenericTemplateApproval(id, Name, site, formTypeId, plantId);        

        }

        //DMND0009363-#950321920-Mukesh
        public void UpdateTemplateHeader(GenericTemplateApproval contractor)
        {
            ManagedCommand.Update(contractor, UpdateTemplateCommonParameters, UPDATE_TEMPLATE_STORED_PROCEDURE);
        }

        //Added by ppanigrahi
        public void UpdateTemplateHeaderEmail(GenericTemplateEmailApprovalConfiguration contractor)
        {
            ManagedCommand.Update(contractor, UpdateTemplateCommonParametersEmail, UPDATE_TEMPLATE_STORED_PROCEDURE_EMAIL);
        }
        private static void UpdateTemplateCommonParameters(GenericTemplateApproval TemplateHeader, SqlCommand command)
        {
            command.AddParameter("@FormTypeId", TemplateHeader.FormTypeId);
            command.AddParameter("@PlantId", TemplateHeader.PlantId);
            command.AddParameter("@SiteId", TemplateHeader.Site.IdValue);
            command.AddParameter("@isNeverEnd", TemplateHeader.ShowneverEnd);


        }
        //Added by ppanigrahi
        private static void UpdateTemplateCommonParametersEmail(GenericTemplateEmailApprovalConfiguration TemplateHeader, SqlCommand command)
        {
            command.AddParameter("@FormTypeId", TemplateHeader.FormTypeId);
            command.AddParameter("@PlantId", TemplateHeader.PlantId);
            command.AddParameter("@SiteId", TemplateHeader.Site.IdValue);
            command.AddParameter("@isNeverEnd", TemplateHeader.ShowneverEnd);


        }
        private static bool IsclumnExistinReader(SqlDataReader dr, string strColumnName)
        {
            dr.GetSchemaTable().DefaultView.RowFilter = string.Format("ColumnName= '{0}'", strColumnName);
            if (dr.GetSchemaTable().DefaultView.Count > 0)
            {
                return true;
            }
            return false;
        }
        //End DMND0009363-#950321920-Mukesh

    }


}