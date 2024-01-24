using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Analytics;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class PropertyDao : AbstractManagedDao, IPropertyDao
    {
        public List<Property> QueryByEventId(long eventId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@EventId", eventId);
            return command.QueryForListResult<Property>(PopulateProperty, "QueryPropertyByEventId");
        }

        private Property PopulateProperty(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            long eventId = reader.Get<long>("EventId");
            string key = reader.Get<string>("PropertyKey");
            PropertyType propertyType = PropertyType.FindById((int) reader.Get<long>("TypeId"));
            string textValue = reader.Get<string>("TextValue");
            DateTime? dateTimeValue = reader.Get<DateTime?>("DateTimeValue");
            decimal? numberValue = reader.Get<decimal?>("NumberValue");

            return Property.CreateFullProperty(id, eventId, key, propertyType, textValue, dateTimeValue, numberValue);
        }
    }
}
