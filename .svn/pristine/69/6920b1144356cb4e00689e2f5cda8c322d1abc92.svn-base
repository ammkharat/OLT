using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class WorkPermitLubesGroupDao : AbstractManagedDao, IWorkPermitLubesGroupDao
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<WorkPermitLubesGroupDao>();

        public WorkPermitLubesGroup QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            List<WorkPermitLubesGroup> groups = GetGroups(command, "QueryWorkPermitLubesGroupById");

            if (groups.Count > 1)
            {
                logger.Error("Multiple groups were returned when only one was expected.");
                throw new OLTException("Multiple groups were returned when only one was expected.");
            }
            
            if (groups.Count == 0)
            {
                return null;
            }
           
            return groups[0];                               
        }

        public List<WorkPermitLubesGroup> QueryAll()
        {
            SqlCommand command = ManagedCommand;
            return GetGroups(command, "QueryAllWorkPermitLubesGroups");
        }

        private static long GetId(SqlDataReader reader)
        {
            return reader.Get<long>("Id");
        }

        private List<WorkPermitLubesGroup> GetGroups(SqlCommand command, string sql)
        {
            Dictionary<long, WorkPermitLubesGroup> result = new Dictionary<long, WorkPermitLubesGroup>();

            command.CommandText = sql;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = GetId(reader);
                    if (result.ContainsKey(id))
                    {
                        WorkPermitLubesGroup group = result[id];
                        
                        int? sapImportPriority = reader.Get<int?>("SAPImportPriority");
                        if (sapImportPriority != null)
                        {
                            group.AddSAPImportPriority(sapImportPriority.Value);
                        }

                        string sapPlannerGroup = reader.Get<string>("SAPPlannerGroup");
                        if (sapPlannerGroup != null)
                        {
                            group.AddSAPPlannerGroup(sapPlannerGroup);
                        }
                        
                    }
                    else
                    {
                        result.Add(id, PopulateInstance(reader));
                    }
                }
            }

            return new List<WorkPermitLubesGroup>(result.Values);

        }

        private WorkPermitLubesGroup PopulateInstance(SqlDataReader reader)
        {
            long id = GetId(reader);
            string name = reader.Get<string>("Name");
            int displayOrder = reader.Get<int>("DisplayOrder");
            int? sapImportPriority = reader.Get<int?>("SAPImportPriority");
            string sapPlannerGroup = reader.Get<string>("SAPPlannerGroup");

            WorkPermitLubesGroup group = new WorkPermitLubesGroup(id, name, displayOrder);            

            if (sapImportPriority != null)
            {
                group.AddSAPImportPriority(sapImportPriority.Value);
            }
            
            if (sapPlannerGroup != null)
            {
                group.AddSAPPlannerGroup(sapPlannerGroup);
            }

            return group;
        }




    }
}
