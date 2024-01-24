using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Analytics;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class EventDao : AbstractManagedDao, IEventDao
    {
        private readonly IPropertyDao propertyDao;

        public EventDao()
        {
            propertyDao = DaoRegistry.GetDao<IPropertyDao>();
        }

        public void Insert(Event @event)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(@event, AddInsertParameters, "InsertEvent");
            @event.Id = long.Parse(idParameter.Value.ToString());

            InsertProperties(command, @event);
        }

        public List<string> QueryUniqueEventNames()
        {
            SqlCommand command = ManagedCommand;
            return command.QueryForListResult<string>(PopulateEventName, "QueryEventNameWithUniqueness");
        }

        // TODO: this has an n+1 problem. Consider refactoring.
        public List<Event> QueryByDateRangeAndEventNames(DateTime fromDateTime, DateTime toDateTime, List<string> eventNames)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FromDateTime", fromDateTime);
            command.AddParameter("@ToDateTime", toDateTime);
            command.AddParameter("@CsvEventNames", eventNames.ToDelimitedString(','));
            return command.QueryForListResult<Event>(PopulateEvent, "QueryEventByDateRangeAndEventNames");
        }

        public void DeleteAnalyticsCreatedBeforeGivenDateTime(DateTime dateTime)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = "DeleteEventsCreatedBeforeGivenDateTime";
            command.AddParameter("@GivenDateTime", dateTime);
            command.ExecuteNonQuery();
        }

        private void AddInsertParameters(Event @event, SqlCommand command)
        {
            command.AddParameter("@UserId", @event.UserId);
            command.AddParameter("@SiteId", @event.SiteId);
            command.AddParameter("@Name", @event.Name);
            command.AddParameter("@DateTime", @event.DateTime);
        }

        private void InsertProperties(SqlCommand command, Event @event)
        {
            command.CommandText = "InsertProperty";
            foreach (Property property in @event.Properties)
            {
                command.Parameters.Clear();
                SqlParameter idParameter = command.AddIdOutputParameter();
                command.AddParameter("@EventId", @event.IdValue);
                command.AddParameter("@PropertyKey", property.Key);
                command.AddParameter("@TypeId", property.Type.IdValue);
                command.AddParameter("@TextValue", property.TextValue);
                command.AddParameter("@DateTimeValue", property.DateTimeValue);
                command.AddParameter("@NumberValue", property.NumberValue);
                command.ExecuteNonQuery();

                property.Id = long.Parse(idParameter.Value.ToString());
            }
        }

        private Event PopulateEvent(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            long userId = reader.Get<long>("UserId");
            long? siteId = reader.Get<long?>("SiteId");
            string name = reader.Get<string>("Name");
            DateTime dateTime = reader.Get<DateTime>("DateTime");

            List<Property> properties = propertyDao.QueryByEventId(id);

            return new Event(id, userId, siteId, name, dateTime, properties);
        }

        private string PopulateEventName(SqlDataReader reader)
        {
            return reader.Get<string>("Name");
        }



    }
}
