using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Exceptions;

namespace Com.Suncor.Olt.Remote.DataAccess
{
    public delegate T PopulateInstance<T>(SqlDataReader reader);

    public delegate void AddParameters<T>(T domainObject, SqlCommand command) where T : DomainObject;

    public static class SqlCommandExtensions
    {
        public static void AddParameter(this SqlCommand command, string parameterName, object parameterValue)
        {
            if (!parameterName.StartsWith("@", StringComparison.Ordinal))
                parameterName = "@" + parameterName;

            SqlParameter param = new SqlParameter(parameterName, parameterValue ?? DBNull.Value);
            command.Parameters.Add(param);
        }

        public static void AddParameter(this SqlCommand command, string parameterName, ValueType parameterValue)
        {
            if (!parameterName.StartsWith("@", StringComparison.Ordinal))
                parameterName = "@" + parameterName;

            SqlParameter param = parameterValue == null ? new SqlParameter(parameterName, DBNull.Value) : new SqlParameter(parameterName, parameterValue);
            command.Parameters.Add(param);
        }

        public static List<T> QueryForListResult<T>(this SqlCommand command, PopulateInstance<T> populateHandler, string storedProcedureName)
        {
            command.CommandText = storedProcedureName;
            return command.ExecuteCommandForListResult(populateHandler);
        }

        public static List<T> QueryForListResult<T>(this SqlCommand command, PopulateInstance<T> populateHandler, string storedProcedureName, Action<OLTException> populateExceptionHandler)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;

            List<T> result = new List<T>();

            try
            {
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(populateHandler(reader));
                    }
                }
                return result;
            }
            catch (SqlException ex)
            {
                string message =
                    String.Format(
                        "Error creating an item to put into the list. Inner Exception Message: {0}.{1}StackTrace: {2}",
                        ex.Message, Environment.NewLine, ex.StackTrace);

                populateExceptionHandler(new OLTException(message));
            }
             return result;
        }

        public static void QueryForListResult(this SqlCommand command, Action<OLTException> populateExceptionHandler, Action<SqlDataReader> readData)
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                        readData(reader);
                    }
                    catch (Exception ex)
                    {
                        string message =
                            String.Format(
                                "Error creating an item to put into the list. Inner Exception Message: {0}.{1}StackTrace: {2}",
                                ex.Message, Environment.NewLine, ex.StackTrace);

                        populateExceptionHandler(new OLTException(message));
                    }
                }
            }
        }

       
        // ayman generic forms
        public static T QueryByIdAndSiteId<T>(this SqlCommand command, long id,long siteid, PopulateInstance<T> populateHandler, String storedProcedureName)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            command.AddParameter("@Id", id);
            command.AddParameter("@siteid",siteid);
            T domainObject = command.ExecuteCommandForSingleResult(populateHandler);
            return domainObject;
        }

        //ayman Sarnia eip DMND0008992
        public static List<T> QueryApprovedTemplateByIdAndSiteIdToShowEipForms<T>(this SqlCommand command, long id, long siteid, PopulateInstance<T> populateHandler, String storedProcedureName)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            command.AddParameter("@Id", id);
            command.AddParameter("@siteid", siteid);
            List<T> domainObject = command.QueryApprovedTemplateByIdAndSiteIdToShowEipForms<T>(id, siteid,populateHandler,storedProcedureName);
            return domainObject;
        }

        //generic template - mangesh
        public static T QueryByIdAndSiteId<T>(this SqlCommand command, long id, long siteid, long formtypeid,long plantid,PopulateInstance<T> populateHandler, String storedProcedureName)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            command.AddParameter("@Id", id);
            command.AddParameter("@siteid", siteid);
            command.AddParameter("@formtypeid", formtypeid);
            command.AddParameter("@plantid", plantid);
            T domainObject = command.ExecuteCommandForSingleResult(populateHandler);
            return domainObject;
        }
        //generic template - mangesh
        public static T QueryFormGenericTemplateEFormApproverByIdAndSiteId<T>(this SqlCommand command, long siteid, long formtypeid, long plantid, PopulateInstance<T> populateHandler, String storedProcedureName)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            command.AddParameter("@siteid", siteid);
            command.AddParameter("@formtypeid", formtypeid);
            command.AddParameter("@plantid", plantid);
            T domainObject = command.ExecuteCommandForSingleResult(populateHandler);
            return domainObject;
        }
        
        public static T QueryById<T>(this SqlCommand command, long id, PopulateInstance<T> populateHandler, String storedProcedureName) 
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            command.AddParameter("@Id", id);
            T domainObject = command.ExecuteCommandForSingleResult(populateHandler);
            return domainObject;
        }

        public static T QueryByIdTemplate<T>(this SqlCommand command, long id, string templateName, string categories, PopulateInstance<T> populateHandler, String storedProcedureName)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            command.AddParameter("@Id", id);
            command.AddParameter("@TemplateName", templateName);
            command.AddParameter("@Categories", categories);
            T domainObject = command.ExecuteCommandForSingleResult(populateHandler);
            return domainObject;
        }

        public static T QueryForSingleResult<T>(this SqlCommand command, PopulateInstance<T> populateHandler, string storedProcedureName)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            return command.ExecuteCommandForSingleResult(populateHandler);
        }

        public static int ExecuteNonQuery<T>(this SqlCommand command, T domainObject, string storedProcedureName, AddParameters<T> parameterHandler) where T : DomainObject
        {
            parameterHandler(domainObject, command);
            return command.ExecuteNonQuery(storedProcedureName);
        }

        public static int ExecuteNonQuery(this SqlCommand command, string storedProcedureName)
        {
            try
            {
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;
                return command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new SqlWrapperException("Error on Insert/Update for stored procedure " + storedProcedureName + " - " + ex, ex);
            }
        }

        public static void Insert<T>(this SqlCommand command, T domainObject, AddParameters<T> parameterHandler, string storedProcedureName) where T : DomainObject
        {
            command.ExecuteNonQuery(domainObject, storedProcedureName, parameterHandler);
        }

        public static void Insert(this SqlCommand command, string storedProcedureName) 
        {
            command.ExecuteNonQuery(storedProcedureName);
        }

        public static long InsertAndReturnId<T>(this SqlCommand command, T domainObject, AddParameters<T> parameterHandler, string storedProcedureName) where T : DomainObject
        {
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.ExecuteNonQuery(domainObject, storedProcedureName, parameterHandler);
            return idParameter.GetValue<long>();
        }

        public static void InsertAndSetId<T>(this SqlCommand command, T domainObject, AddParameters<T> parameterHandler, string storedProcedureName) where T : DomainObject
        {
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.ExecuteNonQuery(domainObject, storedProcedureName, parameterHandler);
            long id = idParameter.GetValue<long>();
            domainObject.Id = id;
        }
        
        public static long InsertAndReturnId(this SqlCommand command, string storedProcedureName) 
        {
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.ExecuteNonQuery(storedProcedureName);
            return idParameter.GetValue<long>();
        }

        /// <summary>
        /// Adds an output parameter to the command, which is expected to hold the ID coming back
        /// from executing the command (usually an INSERT).
        /// </summary>
        public static SqlParameter AddIdOutputParameter(this SqlCommand command)
        {
            return command.AddOutputParameter("@Id", SqlDbType.BigInt);
        }

        public static SqlParameter AddOutputParameter(this SqlCommand command, string parameterName, SqlDbType type)
        {
            SqlParameter parameter = command.Parameters.Add(parameterName, type);
            parameter.Direction = ParameterDirection.Output;
            return parameter;
        }

        public static SqlParameter AddInputOutputParameter(this SqlCommand command, string parameterName, SqlDbType type, object value)
        {
            return command.Parameters.Add(new SqlParameter(parameterName, type)
                                       {Direction = ParameterDirection.InputOutput, Value = value});
        }

        public static int Update(this SqlCommand command, string storedProcedureName) 
        {
            return ExecuteNonQuery(command, storedProcedureName);
        }

        public static int Update<T>(this SqlCommand command, T domainObject, AddParameters<T> parameterHandler, string storedProcedureName) where T : DomainObject
        {
            return command.ExecuteNonQuery(domainObject, storedProcedureName, parameterHandler);            
        }

        public static void ClearParameters(this SqlCommand command)
        {
            command.Parameters.Clear();
        }


        private static List<T> ExecuteCommandForListResult<T>(this SqlCommand command, PopulateInstance<T> populateHandler)
        {
            try
            {
                var result = new List<T>();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(populateHandler(reader));
                    }
                }
                return result;
            }
            catch (SqlException ex)
            {
                throw new SqlWrapperException("Error on Query for a List Result", ex);
            }
        }

        private static T ExecuteCommandForSingleResult<T>(this SqlCommand command, PopulateInstance<T> populateHandler)
        {
            try
            {
                T domainObject = default(T);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        domainObject = populateHandler(reader);
                    }
                }
                return domainObject;
            }
            catch (SqlException ex)
            {
                throw new SqlWrapperException("Error on Query for a Single Result", ex);
            }
        }


        public static int GetCount(this SqlCommand command, string storedProcedureName)
        {
            try
            {
                command.CommandText = storedProcedureName;
                return (int)command.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw new SqlWrapperException("Error on GetCount using Stored Procedure " + storedProcedureName, ex);
            }
        }

        public static void Remove(this SqlCommand command, long id, String storedProcedureName)
        {
            command.AddParameter("@Id", id);
            command.ExecuteNonQuery(storedProcedureName);
        }

        public static void Remove<T>(this SqlCommand command, T domainObject, string storedProcedureName) where T : ModifiableDomainObject
        {
            command.AddParameter("@Id", domainObject.IdValue);
            command.AddParameter("@LastModifiedByUserId", domainObject.LastModifiedBy.IdValue);
            command.AddParameter("@LastModifiedDateTime", domainObject.LastModifiedDateTime);

            command.ExecuteNonQuery(storedProcedureName);
        }

        
        

        public static void DiscoverStoredProcedureParameters(this SqlCommand command)
        {
            SqlCommandBuilder.DeriveParameters(command);
            var discoveredParameters = new DbParameter[command.Parameters.Count];
            command.Parameters.CopyTo(discoveredParameters, 0);

            // Init the parameters with a DBNull value
            foreach (DbParameter discoveredParameter in discoveredParameters)
            {
                discoveredParameter.Value = DBNull.Value;
            }
        }
    }

    public static class SqlParameterExtensions
    {
        public static T GetValue<T>(this SqlParameter parameter)
        {
            object result = parameter.Value;
            return result == null ? default(T) : (T) result;
        }
    }
}