using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class WorkPermitMudsGroupDao : AbstractManagedDao, IWorkPermitMudsGroupDao
    {
        private const string QueryByIdStoredProcedure = "QueryWorkPermitMudsGroupById";
        private const string QueryAllStoredProcedure = "QueryAllWorkPermitMudsGroups";
        private const string InsertStoredProcedure = "InsertWorkPermitMudsGroup";
        private const string UpdateStoredProcedure = "UpdateWorkPermitMudsGroup";
        private const string RemoveStoredProcedure = "RemoveWorkPermitMudsGroup";

        public WorkPermitMudsGroup QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryById<WorkPermitMudsGroup>(id, PopulateInstance, QueryByIdStoredProcedure);
        }

        public List<WorkPermitMudsGroup> QueryAll()
        {
            SqlCommand command = ManagedCommand;
            return command.QueryForListResult<WorkPermitMudsGroup>(PopulateInstance, QueryAllStoredProcedure);
        }

        public void Insert(WorkPermitMudsGroup group)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(group, SetCommonAttributes, InsertStoredProcedure);
            group.Id = (long?) idParameter.Value;
        }

        public void Update(WorkPermitMudsGroup workPermitGroup)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", workPermitGroup.IdValue);
            command.Update(workPermitGroup, SetCommonAttributes, UpdateStoredProcedure);            
        }

        public void Remove(WorkPermitMudsGroup groupToDelete)
        {
            SqlCommand managedCommand = ManagedCommand;
            managedCommand.ExecuteNonQuery(groupToDelete, RemoveStoredProcedure, AddRemoveParameters);

        }

        private void AddRemoveParameters(WorkPermitMudsGroup theGroup, SqlCommand command)
        {
            command.AddParameter("@Id", theGroup.IdValue);
        }

        private void SetCommonAttributes(WorkPermitMudsGroup group, SqlCommand command)
        {
            command.AddParameter("@Name", group.Name);
            command.AddParameter("@DisplayOrder", group.DisplayOrder);
        }

        private static long GetId(SqlDataReader reader)
        {
            return reader.Get<long>("Id");
        }

        private WorkPermitMudsGroup PopulateInstance(SqlDataReader reader)
        {
            long id = GetId(reader);
            string name = reader.Get<string>("Name");
            int displayOrder = reader.Get<int>("DisplayOrder");

            WorkPermitMudsGroup group = new WorkPermitMudsGroup(name, displayOrder);
            group.Id = id;

            return group;
        }
    }
}
