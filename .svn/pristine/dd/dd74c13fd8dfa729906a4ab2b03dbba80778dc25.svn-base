using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common
{
    public class TestDataAccessUtil
    {
        private const string SQL_SERVER_KEY = "SqlServer";

        public static T ExecuteScalarExpression<T>(string sqlStatementFormat, params object[] args)
        {
            return ExecuteScalarExpression<T>(string.Format(sqlStatementFormat, args));
        }

        public static t ExecuteScalarExpression<t>(string sqlStatement)
        {
            t scalarValue = default(t);

            Execute(sqlStatement, command => scalarValue = (t) command.ExecuteScalar());

            return scalarValue;
        }

        public static SqlDataReader ExecuteReader(string sqlStatement)
        {
            SqlDataReader reader = null;

            Execute(sqlStatement, delegate(SqlCommand command)
                                      {
                                          reader = command.ExecuteReader();
                                      });

            return reader;
        }

        public static int ExecuteExpression(string sqlStatementFormat, params object[] args)
        {
            return ExecuteExpression(string.Format(sqlStatementFormat, args));
        }

        public static int ExecuteExpression(string sqlStatement)
        {
            int result = default(int);

            Execute(sqlStatement, delegate(SqlCommand command)
                                      {
                                          result = command.ExecuteNonQuery();
                                      });

            return result;
        }

        private static void Execute(string sqlStatement, Action<SqlCommand> action)
        {
            LocalDataStoreSlot sharedSqlConnectionSlot = Thread.GetNamedDataSlot(Constants.SHARED_SQL_CONNECTION_STORE_NAME);
            SqlConnection conn = Thread.GetData(sharedSqlConnectionSlot) as SqlConnection;
            if (conn == null)
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings[SQL_SERVER_KEY].ConnectionString);
                Thread.SetData(sharedSqlConnectionSlot, conn);
                conn.Open();                
            }

            using (SqlCommand command = conn.CreateCommand())
            {
                command.CommandText = sqlStatement;
                action(command);
            }
        }
    }
}