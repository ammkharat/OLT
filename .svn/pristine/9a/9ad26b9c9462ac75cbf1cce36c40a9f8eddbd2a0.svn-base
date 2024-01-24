using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class WorkPermitFortHillsGroupDao : AbstractManagedDao, IWorkPermitFortHillsGroupDao
    {
        private const string QueryByIdStoredProcedure = "QueryWorkPermitFortHillsGroupById";
        private const string QueryAllStoredProcedure = "QueryAllWorkPermitFortHillsGroups";
        private const string InsertStoredProcedure = "InsertWorkPermitEdmontonGroup";
        private const string InsertPriorityStoredProcedure = "InsertSAPImportPriorityWorkPermitEdmontonGroup";

        public WorkPermitFortHillsGroup QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            List<WorkPermitFortHillsGroup> workPermitFortHillsGroups = GetGroups(command, QueryByIdStoredProcedure);

            if (workPermitFortHillsGroups.Count > 0)
            {
                return workPermitFortHillsGroups[0];
            }

            return null;
        }

        public List<WorkPermitFortHillsGroup> QueryAll()
        {
            SqlCommand command = ManagedCommand;
            return GetGroups(command, QueryAllStoredProcedure);
        }

        public WorkPermitFortHillsGroup Insert(WorkPermitFortHillsGroup group)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();           
            command.Insert(group, SetCommonAttributes, InsertStoredProcedure);
            group.Id = (long?) idParameter.Value;
            InsertPriorities(command, group);
            return group;
        }

        private void InsertPriorities(SqlCommand command, WorkPermitFortHillsGroup group)
        {
            command.CommandText = InsertPriorityStoredProcedure;
            foreach (int priority in group.SAPImportPriorityList)
            {
                command.Parameters.Clear();
                command.AddParameter("@SAPImportPriority", priority);
                command.AddParameter("@WorkPermitEdmontonGroupId", group.Id);
                command.ExecuteNonQuery();
            }
        }

        private void SetCommonAttributes(WorkPermitFortHillsGroup group, SqlCommand command)
        {
            command.AddParameter("@Name", group.Name);
            command.AddParameter("@DisplayOrder", group.SortOrder);
            command.AddParameter("@DefaultToDayShiftOnSapImport", group.DefaultToDayShiftOnSapImport);
        }

        private List<WorkPermitFortHillsGroup> GetGroups(SqlCommand command, string query)
        {
            Dictionary<long, WorkPermitFortHillsGroup> result = new Dictionary<long, WorkPermitFortHillsGroup>();

            command.CommandText = query;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = GetId(reader);
                    if (result.ContainsKey(id))
                    {
                        WorkPermitFortHillsGroup group = result[id];
                        group.AddSAPImportPriority(GetSAPImportPriority(reader));
                    }
                    else
                    {
                        result.Add(id, PopulateInstance(reader));
                    }
                }
            }

            return new List<WorkPermitFortHillsGroup>(result.Values);
        }

        private static int GetSAPImportPriority(SqlDataReader reader)
        {
            return reader.Get<int>("SAPImportPriority");
        }

        private static long GetId(SqlDataReader reader)
        {
            return reader.Get<long>("Id");
        }

        private WorkPermitFortHillsGroup PopulateInstance(SqlDataReader reader)
        {
            long id = GetId(reader);
            string name = reader.Get<string>("Name");
            int priority = GetSAPImportPriority(reader);
            int displayOrder = reader.Get<int>("DisplayOrder");
            bool defaultToDayShiftOnSapImport = reader.Get<bool>("DefaultToDayShiftOnSapImport");
            
            WorkPermitFortHillsGroup group = new WorkPermitFortHillsGroup(id, name, new List<long> { priority }, displayOrder, defaultToDayShiftOnSapImport);

            return group;
        }

    }
}
