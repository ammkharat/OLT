using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormGN75BIsolationDao : AbstractManagedDao, IFormGN75BIsolationDao
    {
        private const string REMOVE_ALL_NOT_IN_LIST_STORED_PROCEDURE = "RemoveGn75BIsolationItemsNotInTheList";
        ////Aarti INC0548411 
        private const string REMOVE_ALL_NOT_IN_LIST_Template_STORED_PROCEDURE = "RemoveGn75BTemplateIsolationItemsNotInTheList";

        public List<IsolationItem> QueryByFormGN75BTemplateId(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("FormGN75BId", id);
            return command.QueryForListResult<IsolationItem>(PopulateInstanceForTemplateIsolation, "QueryFormGN75BIsolationItemsByGN75BTemplateId");
        }


        public List<IsolationItem> QueryByFormGN75BId(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("FormGN75BId", id);
            return command.QueryForListResult<IsolationItem>(PopulateInstance, "QueryFormGN75BIsolationItemsByGN75BId");
        }


        //ayman Sarnia eip - 3
        public void InsertForTemplate(IsolationItem item)
        {
            SqlCommand command = ManagedCommand;
            long id = command.InsertAndReturnId(item, AddCommonParameters, "InsertFormGN75BTemplateIsolation");
            item.Id = id;
        }

        public void Insert(IsolationItem item)
        {
            SqlCommand command = ManagedCommand;
            long id = command.InsertAndReturnId(item, AddCommonParameters, "InsertFormGN75BIsolation");
            item.Id = id;
        }

        private static void AddCommonParameters(IsolationItem item, SqlCommand command)
        {
            command.AddParameter("@FormGN75BId", item.FormGn75BId);
            command.AddParameter("@DisplayOrder", item.DisplayOrder);
            command.AddParameter("@IsolationType", item.IsolationType);
            command.AddParameter("@LocationOfEnergyIsolation", item.LocationOfEnergyIsolation);
            command.AddParameter("@DevicePosition",item.DevicePosition);                         //ayman Sarnia eip DMND0008992
            command.AddParameter("@Siteid",item.SiteId);                                         //ayman Sarnia eip DMND0008992
        }

        public void RemoveAllThatAreNotInThisList(long gn75BId, List<IsolationItem> items)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGn75BId", gn75BId);
            command.AddParameter("@CsvItemIds", items.BuildIdStringFromList());
            command.ExecuteNonQuery(REMOVE_ALL_NOT_IN_LIST_STORED_PROCEDURE);
        }

        ////Aarti INC0548411 
        public void RemoveAllThatAreNotInThisListTemplate(long gn75BTemplateId, List<IsolationItem> items)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN75BTemplateId",gn75BTemplateId);
            command.AddParameter("@CsvItemIds", items.BuildIdStringFromList());
            command.ExecuteNonQuery(REMOVE_ALL_NOT_IN_LIST_Template_STORED_PROCEDURE);
        }

        //ayman Sarnia eip - 3
        public void UpdateForTemplate(IsolationItem item)
        {
            SqlCommand command = ManagedCommand;
            command.Update(item, AddUpdateParameters, "UpdateFormGN75BTemplateIsolation");
        }


        public void Update(IsolationItem item)
        {
            SqlCommand command = ManagedCommand;
            command.Update(item, AddUpdateParameters, "UpdateFormGN75BIsolation");
        }

        private static void AddUpdateParameters(IsolationItem isolationItem, SqlCommand command)
        {
            command.AddParameter("@Id", isolationItem.Id);
            AddCommonParameters(isolationItem, command);
        }

        //ayman Sarnia eip - 3
        private IsolationItem PopulateInstanceForTemplateIsolation(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            int displayOrder = reader.Get<int>("DisplayOrder");
            string isolationType = reader.Get<string>("IsolationType");
            string locationOfEnergyIsolation = reader.Get<string>("LocationOfEnergyIsolation");
            long formGn75BId = reader.Get<long>("FormGN75BTemplateId");
            long siteid = reader.Get<long>("Siteid");             //ayman Sarnia eip DMND0008992
            string deviceposition = reader.Get<string>("DevicePosition");     //ayman Sarnia eip DMND0008992
            return new IsolationItem(id, formGn75BId, displayOrder, isolationType, locationOfEnergyIsolation, deviceposition, siteid);            //ayman Sarnia eip DMND0008992
        }

        private IsolationItem PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            int displayOrder = reader.Get<int>("DisplayOrder");
            string isolationType = reader.Get<string>("IsolationType");
            string locationOfEnergyIsolation = reader.Get<string>("LocationOfEnergyIsolation");
            long formGn75BId = reader.Get<long>("FormGN75BId");
            long siteid = reader.Get<long>("Siteid");             //ayman Sarnia eip DMND0008992
            string deviceposition = reader.Get<string>("DevicePosition");     //ayman Sarnia eip DMND0008992
            return new IsolationItem(id, formGn75BId, displayOrder, isolationType, locationOfEnergyIsolation, deviceposition,siteid);            //ayman Sarnia eip DMND0008992
        }
    }
}