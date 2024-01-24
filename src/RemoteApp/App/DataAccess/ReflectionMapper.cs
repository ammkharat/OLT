using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.DataAccess
{
    /// <summary>
    /// This is a Utility Mapper class which uses reflection to transform a 
    /// DataReader's information into Domain objects
    /// </summary>
    public class ReflectionMapper
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<ReflectionMapper>();

        private readonly Set<string> ignoredObjectProperties = new Set<string> { "IdValue", "ObjectIdentifier" };
        private readonly Set<string> ignoredDatabaseFields = new Set<string>();
        private readonly Dictionary<string, string> objectToDatabaseMapping = new Dictionary<string, string>();

        public ReflectionMapper IgnoreDatabaseField(string dbFieldName)
        {
            ignoredDatabaseFields.Add(dbFieldName);
            return this;
        }

        public ReflectionMapper IgnoreObjectProperty(string objectPropertyName)
        {
            ignoredObjectProperties.Add(objectPropertyName);
            return this;
        }

        public ReflectionMapper Ignore(string objectPropertyName, string dbFieldName)
        {
            ignoredObjectProperties.Add(objectPropertyName);
            ignoredDatabaseFields.Add(dbFieldName);
            return this;
        }

        public ReflectionMapper Map(string objectPropertyName, string databaseFieldName)
        {
            try
            {
                objectToDatabaseMapping.Add(objectPropertyName, databaseFieldName);
            } 
            catch (Exception e)
            {
                logger.Error("objectPropertyName = " + objectPropertyName, e);
                throw;
            }
            return this;
        }

        public void Populate(IDataReader reader, object obj)
        {
            var objectMembersNotPopulated = new List<string>();
            var objectMembersSucessfullyPopulated = new List<string>();
            var databaseFieldsPopulated = new Set<string>();
            var databaseFieldsNotPopulated = new List<string>();

            Type targetType = obj.GetType();

            foreach (PropertyInfo propertyInfo in targetType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy))
            {
                // Assuming a straight forward fieldname to Property Relationship
                string propertyName = propertyInfo.Name;
                if (!ignoredObjectProperties.Contains(propertyName))
                {
                    try
                    {
                        string dbFieldName = GetDbFieldNameFromPropertyName(propertyName);

                        object columnValue = ConvertSQLServerColumnValueToFieldType(reader.Get(dbFieldName),
                                                                   propertyInfo.PropertyType);

                        if (propertyInfo.PropertyType.IsEnum)
                        {
                            object o = Enum.ToObject(propertyInfo.PropertyType, columnValue);
                            propertyInfo.SetValue(obj, o, null);
                        }
                        else
                        {
                            propertyInfo.SetValue(obj, columnValue, null);
                        }

                        objectMembersSucessfullyPopulated.Add(propertyName);
                        databaseFieldsPopulated.Add(dbFieldName);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        objectMembersNotPopulated.Add(propertyName);
                    }
                    catch (Exception e)
                    {
                        logger.Error("Problem setting field " + propertyName, e);
                        throw;
                    }
                }
            }

            DataTable schemaTable = reader.GetSchemaTable();
            if (schemaTable != null)
            {
                DataRowCollection rows = schemaTable.Rows;
                foreach (DataRow row in rows)
                {
                    var columnName = (string)row["ColumnName"];
                    if (!databaseFieldsPopulated.Contains(columnName) && !ignoredDatabaseFields.Contains(columnName))
                    {
                        databaseFieldsNotPopulated.Add(columnName);
                    }
                }
            }

            AssertThatAllObjectPropertiesAndDatabaseFieldsHaveBeenIncludedInMapping(objectMembersNotPopulated, databaseFieldsNotPopulated);
            
        }

        private string GetDbFieldNameFromPropertyName(string propertyName)
        {
            if (objectToDatabaseMapping.ContainsKey(propertyName))
            {
                return objectToDatabaseMapping[propertyName];
            }
            return propertyName;
        }

        private static void AssertThatAllObjectPropertiesHaveBeenIncludedInMapping(List<string> objectMembersNotPopulated)
        {
            AssertThatAllObjectPropertiesAndDatabaseFieldsHaveBeenIncludedInMapping(objectMembersNotPopulated,
                                                                                    new List<string>());
        }
        
        private static void AssertThatAllObjectPropertiesAndDatabaseFieldsHaveBeenIncludedInMapping(List<string> objectMembersNotPopulated, List<string> databaseFieldsNotPopulated)
        {
            var errorMessage = new StringBuilder();
            if (objectMembersNotPopulated.Count > 0)
            {
                errorMessage.Append("Object properties not populated: ");
                errorMessage.Append(objectMembersNotPopulated.BuildCommaSeparatedList());
                errorMessage.Append(Environment.NewLine);
            }

            if (databaseFieldsNotPopulated.Count > 0)
            {
                errorMessage.Append("Database properties not populated: ");
                errorMessage.Append(databaseFieldsNotPopulated.BuildCommaSeparatedList());
                errorMessage.Append(Environment.NewLine);
            }

            if (objectMembersNotPopulated.Count > 0 || databaseFieldsNotPopulated.Count > 0)
            {
                throw new ApplicationException(errorMessage.ToString());
            }
        }
        
        public void SetCommandParameters(object obj, SqlCommand sqlCommand)
        {
            sqlCommand.DiscoverStoredProcedureParameters();
            sqlCommand.Parameters.Clear();

            var objectMembersNotPopulated = new List<string>();
            var objectMembersSucessfullyPopulated = new List<string>();

            Type targetType = obj.GetType();

            foreach (PropertyInfo thisPropertyInfo in targetType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy))
            {
                string propertyName = thisPropertyInfo.Name;
                if (!ignoredObjectProperties.Contains(propertyName))
                {
                    object propertyValue = GetSQLServerFriendlyColumnValue(obj, thisPropertyInfo);

                    try
                    {
                        string dbFieldName = GetDbFieldNameFromPropertyName(propertyName);
                        sqlCommand.Parameters.AddWithValue(dbFieldName, propertyValue ?? DBNull.Value);
                        objectMembersSucessfullyPopulated.Add(propertyName);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        objectMembersNotPopulated.Add(propertyName);
                    }
                    catch (Exception e)
                    {
                        logger.Error("Problem setting field " + propertyName, e);
                        throw;
                    }
                }
            }

            AssertThatAllObjectPropertiesHaveBeenIncludedInMapping(objectMembersNotPopulated);

        }

        private static object ConvertSQLServerColumnValueToFieldType(object dbFieldValue, Type objectFieldType)
        {
            if (objectFieldType == typeof(TimeSpan))
            {
                var dbvalue = (DateTime?)dbFieldValue;
                return (dbvalue == null) ? new TimeSpan() : dbvalue.Value.TimeOfDay;
            }
            if (objectFieldType == typeof(Time))
            {
                var dbvalue = (DateTime?)dbFieldValue;
                return (dbvalue == null) ? null : new Time(dbvalue.Value);
            }
            return dbFieldValue;
        }

        private static object GetSQLServerFriendlyColumnValue(object obj, PropertyInfo thisPropertyInfo)
        {
            if (thisPropertyInfo.PropertyType == typeof(TimeSpan))
            {
                var timeSpan = (TimeSpan) thisPropertyInfo.GetValue(obj, null);
                return ToSQLServerFriendlyDateTimeColumnValue(new Time(timeSpan));
            }
            return thisPropertyInfo.PropertyType == typeof(Time)
                       ? ToSQLServerFriendlyDateTimeColumnValue((Time) thisPropertyInfo.GetValue(obj, null))
                       : thisPropertyInfo.GetValue(obj, null);
        }

        private static DateTime? ToSQLServerFriendlyDateTimeColumnValue(Time time)
        {
            return (time == null) ? (DateTime?) null : time.ToDateTime();
        }
    }
}