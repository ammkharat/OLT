using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormTemplateDao : AbstractManagedDao, IFormTemplateDao
    {

        private const string QUERY_BY_FORM_TYPE_ID_STORED_PROCEDURE = "QueryFormTemplateByFormTypeId";
        private const string QUERY_BY_FORM_TYPE_ID_AND_KEY_STORED_PROCEDURE = "QueryFormTemplateByFormTypeIdAndKey";
        private const string QUERY_ALL_STORED_PROCEDURE = "QueryFormTemplate";
        private const string INSERT_STORED_PROCEDURE = "InsertFormTemplate";
        private const string REMOVE_STORED_PROCEDURE = "RemoveFormTemplate";

        public List<FormTemplate> QueryAll(long siteId)
        {
            var command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            return command.QueryForListResult(PopulateInstance, QUERY_ALL_STORED_PROCEDURE);
        }

        
        public List<FormTemplate> QueryByFormType(EdmontonFormType formType,long siteid)    // ayman generic forms
        {
            var command = ManagedCommand;
            command.AddParameter("@FormTypeId", formType.Id);
            command.AddParameter("@siteid",siteid);                                //ayman generic forms
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_TYPE_ID_STORED_PROCEDURE);
        }

        public FormTemplate QueryByFormTypeAndKey(EdmontonFormType formType, string key)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormTypeId", formType.Id);
            command.AddParameter("@TemplateKey", key);
            return command.QueryForSingleResult(PopulateInstance, QUERY_BY_FORM_TYPE_ID_AND_KEY_STORED_PROCEDURE);
        }

        public void Replace(FormTemplate formTemplate, User user, DateTime now, long siteId)
        {
            var templateToInsert = new FormTemplate(null, formTemplate.FormType, formTemplate.Template,
                formTemplate.Name, formTemplate.Key, siteId);
            Insert(templateToInsert, user, now, siteId);
            Remove(formTemplate);
        }

        public FormTemplate QueryById(long id)
        {
            var command = ManagedCommand;
            return command.QueryById(id, PopulateInstance, "QueryFormTemplateById");
        }

        private void Insert(FormTemplate formTemplate, User createdByUser, DateTime createdDateTime, long siteId)
        {
            var command = ManagedCommand;
            var idParameter = command.AddIdOutputParameter();
            command.AddParameter("FormTypeId", formTemplate.FormType.Id);
            command.AddParameter("Template", formTemplate.Template);
            command.AddParameter("Name", formTemplate.Name);
            command.AddParameter("TemplateKey", formTemplate.Key);
            command.AddParameter("CreatedByUserId", createdByUser.Id);
            command.AddParameter("CreatedDateTime", createdDateTime);
            command.AddParameter("SiteId", siteId);
            command.Insert(INSERT_STORED_PROCEDURE);

            formTemplate.Id = (long) idParameter.Value;
        }

        private void Remove(FormTemplate formTemplate)
        {
            var command = ManagedCommand;
            command.AddParameter("Id", formTemplate.Id);
            command.ExecuteNonQuery(REMOVE_STORED_PROCEDURE);
        }

        private FormTemplate PopulateInstance(SqlDataReader reader)
        {
            var id = reader.Get<long>("Id");
            var siteId = reader.Get<long>("SiteId");

            var formTypeId = reader.Get<int>("FormTypeId");
            var formType = EdmontonFormType.GetById(formTypeId);

            var template = reader.Get<string>("Template");
            var name = reader.Get<string>("Name");
            var key = reader.Get<string>("TemplateKey");

            return new FormTemplate(id, formType, template, name, key, siteId);
        }
    }
}