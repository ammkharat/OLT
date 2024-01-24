using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class EventSinkDao : AbstractManagedDao, IEventSinkDao
    {
        private const string QUERY_ALL = "QueryEventSinks";
        private const string INSERT_STORED_PROCEDURE = "InsertEventSink";
        private const string REMOVE_BY_CLIENT_URI = "RemoveEventSinkByClientUri";

        public void Insert(EventSink eventSink)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(eventSink, AddInsertParameters, INSERT_STORED_PROCEDURE);
            eventSink.Id = long.Parse(idParameter.Value.ToString());
        }

        private static void AddInsertParameters(EventSink eventSink, SqlCommand command)
        {
            command.AddParameter("@ClientUri", eventSink.ClientUri);
            command.AddParameter("@FullHierarchyList", eventSink.FullHierarchyList.ToCommaSeparatedString());
            command.AddParameter("@WorkPermitEdmontonFullHierarchyList", eventSink.WorkPermitEdmontonFullHierarchyList.ToCommaSeparatedString());
            command.AddParameter("@RestrictionFullHierarchyList", eventSink.RestrictionFullHierarchyList.ToCommaSeparatedString());
            command.AddParameter("@ClientReadableVisibilityGroupIdList", eventSink.ClientReadableVisibilityGroupIdList.ToCommaSeparatedString());
            command.AddParameter("@SiteId",  eventSink.SiteId);
        }

        public void DeleteByClientUri(string clientUri)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ClientUri", clientUri);
            command.ExecuteNonQuery(REMOVE_BY_CLIENT_URI);
        }

        public List<EventSink> QueryAll()
        {
            SqlCommand command = ManagedCommand;
            return command.QueryForListResult<EventSink>(PopulateInstance, QUERY_ALL);
        }

        private static EventSink PopulateInstance(SqlDataReader reader)
        {
            string fullHierarchyList = reader.Get<string>("FullHierarchyList");
            string workPermitEdmontonFullHierarchyList = reader.Get<string>("WorkPermitEdmontonFullHierarchyList");
            string restrictionFullHierarchyList = reader.Get<string>("RestrictionFullHierarchyList");
            string readableClientVisibilityGroupIdList = reader.Get<string>("ClientReadableVisibilityGroupIdList");

            var result = new EventSink(reader.Get<string>("ClientUri"), fullHierarchyList.BuildListFromCommaSeparatedList(),
                                       workPermitEdmontonFullHierarchyList.BuildListFromCommaSeparatedList(), restrictionFullHierarchyList.BuildListFromCommaSeparatedList(),
                                       new List<long>(readableClientVisibilityGroupIdList.BuildLongArrayFromCsv()),
                                       reader.Get<long?>("SiteId")) {Id = (reader.Get<int>("Id"))};
            return result;
        }
    }
}