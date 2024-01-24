using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormGN75BDevicePositionDao : AbstractManagedDao, IFormGN75BDevicePositionDao
    {
        private const string REMOVE_ALL_NOT_IN_LIST_STORED_PROCEDURE = "RemoveGn75BDevicePositionNotInTheList";

        public List<DevicePosition> QueryByFormGN75BId(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("FormGN75BId", id);
            return command.QueryForListResult<DevicePosition>(PopulateInstance, "QueryFormGN75BDevicePositionByGN75BId");
        }

        //ayman Sarnia eip - 3
        public List<DevicePosition> QueryByFormGN75BSarniaId(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("FormGN75BId", id);
            return command.QueryForListResult<DevicePosition>(PopulateInstance, "QueryFormGN75BDevicePositionByGN75BSarniaId");
        }

        public void Insert(DevicePosition item)
        {
            SqlCommand command = ManagedCommand;
            long id = command.InsertAndReturnId(item, AddCommonParameters, "InsertFormGN75BDevicePosition");
            item.Id = id;
        }

        private static void AddCommonParameters(DevicePosition item, SqlCommand command)
        {
            command.AddParameter("@FormGN75BId", item.FormGn75BId);
            command.AddParameter("@DisplayOrder", item.DisplayOrder);
            command.AddParameter("@DevicePosition", item.DevicePositionDesc);

        }

        public void RemoveAllThatAreNotInThisList(long gn75BId, List<DevicePosition> items)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGn75BId", gn75BId);
            command.AddParameter("@CsvItemIds", items.BuildIdStringFromList());
            command.ExecuteNonQuery(REMOVE_ALL_NOT_IN_LIST_STORED_PROCEDURE);
        }

        public void Update(DevicePosition item)
        {
            SqlCommand command = ManagedCommand;
            command.Update(item, AddUpdateParameters, "UpdateFormGN75BDevicePosition");
        }

        private static void AddUpdateParameters(DevicePosition devicePosition, SqlCommand command)
        {
            command.AddParameter("@Id", devicePosition.Id);
            AddCommonParameters(devicePosition, command);
        }

        private DevicePosition PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            int displayOrder = reader.Get<int>("DisplayOrder");
            string devicePosition = reader.Get<string>("DevicePosition");
            long formGn75BId = reader.Get<long>("FormGN75BId");

            return new DevicePosition(id, formGn75BId, displayOrder, devicePosition);
        }
    }
}
