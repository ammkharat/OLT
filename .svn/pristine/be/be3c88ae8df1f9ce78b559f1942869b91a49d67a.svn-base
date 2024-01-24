using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ConfiguredDocumentLinkDao : AbstractManagedDao, IConfiguredDocumentLinkDao
    {
        private const string UPDATE_STORED_PROCEDURE = "UpdateConfiguredDocumentLink";
        private const string INSERT_STORED_PROCEDURE = "InsertConfiguredDocumentLink";
        private const string REMOVE_STORED_PROCEDURE = "RemoveConfiguredDocumentLink";
        private const string QUERY_BY_LOCATION_STORED_PROCEDURE = "QueryConfiguredDocumentLinksByLocation";

        public List<ConfiguredDocumentLink> QueryByLocation(ConfiguredDocumentLinkLocation location)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Location", location.LocationName);

            return command.QueryForListResult<ConfiguredDocumentLink>(PopulateInstance, QUERY_BY_LOCATION_STORED_PROCEDURE);
        }

        private static ConfiguredDocumentLink PopulateInstance(SqlDataReader reader)
        {
            long? id = reader.Get<long>("Id");
            string title = reader.Get<string>("Title");
            string link = reader.Get<string>("Link");
            string locationName = reader.Get<string>("Location");
            int displayOrder = reader.Get<int>("DisplayOrder");

            return new ConfiguredDocumentLink(id, title, link, ConfiguredDocumentLinkLocation.FromName(locationName), displayOrder);
        }

        public void Remove(ConfiguredDocumentLink link)
        {
            ManagedCommand.ExecuteNonQuery(link, REMOVE_STORED_PROCEDURE, AddRemoveParameters);
        }

        public ConfiguredDocumentLink Insert(ConfiguredDocumentLink link)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();

            command.Insert(link, AddInsertParameters, INSERT_STORED_PROCEDURE);
            link.Id = (long)idParameter.Value;

            return link;
        }

        public void UpdateLinks(List<ConfiguredDocumentLink> documentLinks, List<ConfiguredDocumentLink> deletedLinks)
        {
            foreach (ConfiguredDocumentLink value in deletedLinks)
            {
                Remove(value);
            }

            List<ConfiguredDocumentLink> newLinks = documentLinks.FindAll(obj => !obj.IsInDatabase());
            List<ConfiguredDocumentLink> possiblyChangedLinks = documentLinks.FindAll(obj => obj.IsInDatabase());

            foreach (ConfiguredDocumentLink link in possiblyChangedLinks)
            {
                Update(link);
            }

            foreach (ConfiguredDocumentLink link in newLinks)
            {
                Insert(link);
            }

        }

        private void Update(ConfiguredDocumentLink link)
        {
            ManagedCommand.Update(link, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
        }

        private void AddUpdateParameters(ConfiguredDocumentLink link, SqlCommand command)
        {
            command.AddParameter("@Id", link.Id);
            SetCommonAttributes(link, command);
        }

        private static void AddInsertParameters(ConfiguredDocumentLink link, SqlCommand command)
        {
            SetCommonAttributes(link, command);
        }

        private void AddRemoveParameters(ConfiguredDocumentLink link, SqlCommand command)
        {
            command.AddParameter("@Id", link.Id);
        }

        private static void SetCommonAttributes(ConfiguredDocumentLink link, SqlCommand command)
        {
            command.AddParameter("@Title", link.Title);
            command.AddParameter("@Link", link.Link);
            command.AddParameter("@Location", link.Location.LocationName);
            command.AddParameter("@DisplayOrder", link.DisplayOrder);
        }
    }
}
