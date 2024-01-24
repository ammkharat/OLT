using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class WorkPermitMontrealGroupDao : AbstractManagedDao, IWorkPermitMontrealGroupDao
    {
        private const string QueryByIdStoredProcedure = "QueryWorkPermitMontrealGroupById";
        private const string QueryAllStoredProcedure = "QueryAllWorkPermitMontrealGroups";
        private const string InsertStoredProcedure = "InsertWorkPermitMontrealGroup";
        private const string UpdateStoredProcedure = "UpdateWorkPermitMontrealGroup";
        private const string RemoveStoredProcedure = "RemoveWorkPermitMontrealGroup";

        public WorkPermitMontrealGroup QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryById<WorkPermitMontrealGroup>(id, PopulateInstance, QueryByIdStoredProcedure);
        }

        public List<WorkPermitMontrealGroup> QueryAll()
        {
            SqlCommand command = ManagedCommand;
            return command.QueryForListResult<WorkPermitMontrealGroup>(PopulateInstance, QueryAllStoredProcedure);
        }

        public void Insert(WorkPermitMontrealGroup group)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(group, SetCommonAttributes, InsertStoredProcedure);
            group.Id = (long?) idParameter.Value;
        }

        public void Update(WorkPermitMontrealGroup workPermitGroup)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", workPermitGroup.IdValue);
            command.Update(workPermitGroup, SetCommonAttributes, UpdateStoredProcedure);            
        }

        public void Remove(WorkPermitMontrealGroup groupToDelete)
        {
            SqlCommand managedCommand = ManagedCommand;
            managedCommand.ExecuteNonQuery(groupToDelete, RemoveStoredProcedure, AddRemoveParameters);

        }

        private void AddRemoveParameters(WorkPermitMontrealGroup theGroup, SqlCommand command)
        {
            command.AddParameter("@Id", theGroup.IdValue);
        }

        private void SetCommonAttributes(WorkPermitMontrealGroup group, SqlCommand command)
        {
            command.AddParameter("@Name", group.Name);
            command.AddParameter("@DisplayOrder", group.DisplayOrder);
        }

        private static long GetId(SqlDataReader reader)
        {
            return reader.Get<long>("Id");
        }

        private WorkPermitMontrealGroup PopulateInstance(SqlDataReader reader)
        {
            long id = GetId(reader);
            string name = reader.Get<string>("Name");
            int displayOrder = reader.Get<int>("DisplayOrder");

            WorkPermitMontrealGroup group = new WorkPermitMontrealGroup(name, displayOrder);
            group.Id = id;

            return group;
        }
    }
}
