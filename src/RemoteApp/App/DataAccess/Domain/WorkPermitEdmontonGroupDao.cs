﻿using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class WorkPermitEdmontonGroupDao : AbstractManagedDao, IWorkPermitEdmontonGroupDao
    {
        private const string QueryByIdStoredProcedure = "QueryWorkPermitEdmontonGroupById";
        private const string QueryAllStoredProcedure = "QueryAllWorkPermitEdmontonGroups";
        private const string InsertStoredProcedure = "InsertWorkPermitEdmontonGroup";
        private const string InsertPriorityStoredProcedure = "InsertSAPImportPriorityWorkPermitEdmontonGroup";

        public WorkPermitEdmontonGroup QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            List<WorkPermitEdmontonGroup> workPermitEdmontonGroups = GetGroups(command, QueryByIdStoredProcedure);

            if (workPermitEdmontonGroups.Count > 0)
            {
                return workPermitEdmontonGroups[0];
            }

            return null;
        }

        public List<WorkPermitEdmontonGroup> QueryAll()
        {
            SqlCommand command = ManagedCommand;
            return GetGroups(command, QueryAllStoredProcedure);
        }

        public WorkPermitEdmontonGroup Insert(WorkPermitEdmontonGroup group)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();           
            command.Insert(group, SetCommonAttributes, InsertStoredProcedure);
            group.Id = (long?) idParameter.Value;
            InsertPriorities(command, group);
            return group;
        }

        private void InsertPriorities(SqlCommand command, WorkPermitEdmontonGroup group)
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

        private void SetCommonAttributes(WorkPermitEdmontonGroup group, SqlCommand command)
        {
            command.AddParameter("@Name", group.Name);
            command.AddParameter("@DisplayOrder", group.SortOrder);
            command.AddParameter("@DefaultToDayShiftOnSapImport", group.DefaultToDayShiftOnSapImport);
        }

        private List<WorkPermitEdmontonGroup> GetGroups(SqlCommand command, string query)
        {
            Dictionary<long, WorkPermitEdmontonGroup> result = new Dictionary<long, WorkPermitEdmontonGroup>();

            command.CommandText = query;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = GetId(reader);
                    if (result.ContainsKey(id))
                    {
                        WorkPermitEdmontonGroup group = result[id];
                        group.AddSAPImportPriority(GetSAPImportPriority(reader));
                    }
                    else
                    {
                        result.Add(id, PopulateInstance(reader));
                    }
                }
            }

            return new List<WorkPermitEdmontonGroup>(result.Values);
        }

        private static int GetSAPImportPriority(SqlDataReader reader)
        {
            return reader.Get<int>("SAPImportPriority");
        }

        private static long GetId(SqlDataReader reader)
        {
            return reader.Get<long>("Id");
        }

        private WorkPermitEdmontonGroup PopulateInstance(SqlDataReader reader)
        {
            long id = GetId(reader);
            string name = reader.Get<string>("Name");
            int priority = GetSAPImportPriority(reader);
            int displayOrder = reader.Get<int>("DisplayOrder");
            bool defaultToDayShiftOnSapImport = reader.Get<bool>("DefaultToDayShiftOnSapImport");
            
            WorkPermitEdmontonGroup group = new WorkPermitEdmontonGroup(id, name, new List<long> { priority }, displayOrder, defaultToDayShiftOnSapImport);

            return group;
        }

    }
}