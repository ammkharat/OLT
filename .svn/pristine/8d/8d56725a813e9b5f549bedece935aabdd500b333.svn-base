using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class AreaLabelDao : AbstractManagedDao, IAreaLabelDao
    {
        public List<AreaLabel> QueryBySiteId(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);

            return command.QueryForListResult<AreaLabel>(PopulateInstance, "QueryAreaLabelBySiteId");
        }

        public AreaLabel Insert(AreaLabel areaLabel)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();

            command.Insert(areaLabel, AddInsertParameters, "InsertAreaLabel");
            areaLabel.Id = (long) idParameter.Value;

            return areaLabel;
        }

        public AreaLabel QueryById(long id)
        {
            return ManagedCommand.QueryById<AreaLabel>(id, PopulateInstance, "QueryAreaLabelById");
        }

        public AreaLabel QueryBySiteIdAndPlannerGroup(long siteId, string plannerGroup)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("SiteId", siteId);
            command.AddParameter("PlannerGroup", plannerGroup);
            return command.QueryForSingleResult<AreaLabel>(PopulateInstance, "QueryAreaLabelBySiteAndPlannerGroup");
        }

        public void Update(AreaLabel areaLabel)
        {
            ManagedCommand.Update(areaLabel, AddUpdateParameters, "UpdateAreaLabel");
        }

        public void Remove(AreaLabel areaLabel)
        {
            ManagedCommand.ExecuteNonQuery(areaLabel, "RemoveAreaLabel", AddRemoveParameters);
        }

        private static void AddUpdateParameters(AreaLabel areaLabel, SqlCommand command)
        {
            command.AddParameter("@Id", areaLabel.Id);
            SetInsertAndUpdateParameters(areaLabel, command);
        }

        private void AddInsertParameters(AreaLabel areaLabel, SqlCommand command)
        {
            SetInsertAndUpdateParameters(areaLabel, command);
            command.AddParameter("SiteId", areaLabel.SiteId);
        }

        private static void SetInsertAndUpdateParameters(AreaLabel areaLabel, SqlCommand command)
        {
            command.AddParameter("Name", areaLabel.Name);
            command.AddParameter("DisplayOrder", areaLabel.DisplayOrder);
            command.AddParameter("AllowManualSelection", areaLabel.AllowManualSelection);
            command.AddParameter("SapPlannerGroup", areaLabel.SapPlannerGroup);
        }

        private void AddRemoveParameters(AreaLabel areaLabel, SqlCommand command)
        {
            command.AddParameter("@Id", areaLabel.Id);
        }

        private static AreaLabel PopulateInstance(SqlDataReader reader)
        {
            long? id = reader.Get<long?>("Id");
            string name = reader.Get<string>("Name");
            long siteId = reader.Get<long>("SiteId");
            int displayOrder = reader.Get<int>("DisplayOrder");
            bool allowManualSelection = reader.Get<bool>("AllowManualSelection");
            string sapPlannerGroup = reader.Get<string>("SapPlannerGroup");

            return new AreaLabel(id, name, siteId, displayOrder, allowManualSelection, sapPlannerGroup);
        }
    }
}