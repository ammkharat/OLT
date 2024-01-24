using System;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Exceptions;
using DayOfWeek = Com.Suncor.Olt.Common.Domain.DayOfWeek;

namespace Com.Suncor.Olt.Remote.DataAccess
{
    public static class SqlDataReaderExtensions
    {
        /// <summary>
        /// Gets the value of the columnName in a type safe manner
        /// </summary>
        /// <typeparam name="T">The type that the value should be</typeparam>
        /// <param name="dataRecord">the record to get values from</param>
        /// <param name="columnName">the column that we want the value for</param>
        /// <returns>the value of the column as the type specified</returns>
        public static T Get<T>(this IDataRecord dataRecord, string columnName)
        {
            try
            {
                object o = dataRecord[columnName];
                if (o == DBNull.Value)
                    return default(T);
                return (T)o;
            }
            catch (IndexOutOfRangeException)
            {
                throw new NoDataFoundException(string.Format("Could not find column '{0}' in the ResultSet.", columnName));
            }
            catch (NullReferenceException)
            {
                throw new NoDataFoundException(string.Format("Coulmn was found in ResultSet, but attempting to return the .NET type of {0} which may be incorrect.", typeof(T).FullName));
            }
        }

        public static TernaryString GetTernaryString(this IDataReader dataReader, string boolColumnName, string stringColumnName)
        {
            bool b = dataReader.Get<bool>(boolColumnName);
            string value = dataReader.Get<string>(stringColumnName);
            return new TernaryString(b, value);
        }

        public static object Get(this IDataRecord dataRecord, string columnName)
        {
            object result = dataRecord[columnName];
            return (result == DBNull.Value ? null : result);
        }

        /// <summary>
        /// Gets a TernaryString where the column names are named columnA for bool and columnAValue for the string.
        /// </summary>
        /// <param name="dataReader"></param>
        /// <param name="boolColumnName"></param>
        /// <returns></returns>
        /// <example>two columns that help make up a TernaryString are corrosif and corrosifValue, use
        /// GetTernaryString(corrosif)
        /// </example>
        public static TernaryString GetTernaryString(this IDataReader dataReader, string boolColumnName)
        {
            string valueColumn = boolColumnName + "Value";
            return dataReader.GetTernaryString(boolColumnName, valueColumn);
        }

        public static string GetUser(this IDataReader reader, string firstNameColumn, string lastNameColumn, string usernameColumn)
        {
            string first = reader.Get<string>(firstNameColumn);
            string last = reader.Get<string>(lastNameColumn);
            string userName = reader.Get<string>(usernameColumn);

            if (IsRemoteAppUser(userName))
            {
                return "System Activity [RemoteAppUser]";
            }

            if (NoneAreNull(userName, first, last))
            {
                return User.ToFullNameWithUserName(last, first, userName);
            }
            if (NoneAreNull(first, last))
            {
                return User.ToFullName(first, last);
            }
            return string.Empty;
        }

        private static bool IsRemoteAppUser(string userName)
        {
            return userName == "RemoteAppUser";
        }

        public static string GetUserFullName(this IDataReader reader, string firstNameColumn, string lastNameColumn)
        {
            string first = reader.Get<string>(firstNameColumn);
            string last = reader.Get<string>(lastNameColumn);            
           
            if (NoneAreNull(first, last))
            {
                return User.ToFullName(first, last);
            }

            return string.Empty;            
        }

        private static bool NoneAreNull(params string[] values)
        {
            return Array.TrueForAll(values, s => s != null);
        }

        public static DayOfMonth GetDayOfMonth(this SqlDataReader reader, string columnName)
        {
            int? dayOfMonth = reader.Get<int?>(columnName);
            if (dayOfMonth.HasValue )
            {
                return DayOfMonth.Day(dayOfMonth.Value);
            }
            return null;
        }
        public static DayOfWeek GetDayOfWeek(this SqlDataReader reader, string columnName)
        {
            int? dayOfWeekValue = reader.Get<int?>(columnName);
            if (dayOfWeekValue.HasValue)
            {
                return DayOfWeek.ConvertFromValue(dayOfWeekValue.Value);
            }
            return null;
        }

        public static WeekOfMonth GetWeekOfMonth(this SqlDataReader reader, string columnName)
        {
            int? dayOfMonth = reader.Get<int?>(columnName);
            if (dayOfMonth.HasValue)
            {
                return WeekOfMonth.Week(dayOfMonth.Value);
            }
            return null;
        }
    }
}