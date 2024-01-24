using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class WorkAssignmentVisibilityGroupDao : AbstractManagedDao, IWorkAssignmentVisibilityGroupDao
    {
        public List<WorkAssignmentVisibilityGroup> QueryByWorkAssignmentId(long workAssignmentId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkAssignmentId", workAssignmentId);
            return command.QueryForListResult<WorkAssignmentVisibilityGroup>(PopulateInstance, "QueryWorkAssignmentVisibilityGroups");
        }

        public WorkAssignmentVisibilityGroup Insert(WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.AddParameter("@WorkAssignmentId", workAssignmentVisibilityGroup.WorkAssignmentId);
            command.AddParameter("@GroupId", workAssignmentVisibilityGroup.VisibilityGroupId);
            command.AddParameter("@VisibilityType", workAssignmentVisibilityGroup.VisibilityType);
            command.Insert("InsertWorkAssignmentVisibilityGroup");

            workAssignmentVisibilityGroup.Id = (long) idParameter.Value;

            return workAssignmentVisibilityGroup;
        }

        public void Remove(WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", workAssignmentVisibilityGroup.IdValue);
            command.ExecuteNonQuery("RemoveWorkAssignmentVisibilityGroup");
        }

        public List<WorkAssignmentVisibilityGroup> QueryByVisibilityGroupId(long visibilityGroupId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@VisibilityGroupId", visibilityGroupId);
            return command.QueryForListResult<WorkAssignmentVisibilityGroup>(PopulateInstance, "QueryWorkAssignmentVisibilityGroupsByVisibilityGroupId");
        }

        private WorkAssignmentVisibilityGroup PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            long workAssignmentId = reader.Get<long>("WorkAssignmentId");
            long groupId = reader.Get<long>("VisibilityGroupId");
            string groupName = reader.Get<string>("VisibilityGroupName");
            byte visibilityType = reader.Get<byte>("VisibilityType");
            VisibilityType type = visibilityType.ToEnum<VisibilityType>();

            return new WorkAssignmentVisibilityGroup(id, workAssignmentId, groupId, groupName, type);
        }
    }

    public class VisibilityGroupDao : AbstractManagedDao, IVisibilityGroupDao
    {
        public List<VisibilityGroup> QueryAll(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            return command.QueryForListResult<VisibilityGroup>(PopulateInstance, "QueryAllVisibilityGroups");
        }

        public VisibilityGroup Insert(VisibilityGroup visibilityGroup)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();

            command.AddParameter("@SiteId", visibilityGroup.SiteId);
            command.AddParameter("@Name", visibilityGroup.Name);            
            command.AddParameter("@IsSiteDefault", false);
            command.Insert("InsertVisibilityGroup");
            
            visibilityGroup.Id = (long) idParameter.Value;

            return visibilityGroup;
        }

        public bool IsAssociatedToWorkAssignments(VisibilityGroup visibilityGroup, VisibilityType visibilityType)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@VisibilityGroupId", visibilityGroup.IdValue);
            command.AddParameter("@VisibilityType", (int) visibilityType);
            return command.GetCount("CountWorkAssignmentsAssociatedToVisibilityGroup") > 0;
        }

        public void Remove(VisibilityGroup visibilityGroup)
        {
            ManagedCommand.Remove(visibilityGroup.IdValue, "RemoveVisibilityGroup");
        }

        public void Update(VisibilityGroup visibilityGroup)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", visibilityGroup.IdValue);
            command.AddParameter("@Name", visibilityGroup.Name);
            command.Update("UpdateVisibilityGroup");
        }

        private VisibilityGroup PopulateInstance(SqlDataReader reader)
        {
            return new VisibilityGroup(
                reader.Get<long>("Id"),
                reader.Get<string>("Name"),
                reader.Get<long>("SiteId"),
                reader.Get<bool>("IsSiteDefault"));
        }
    }
}