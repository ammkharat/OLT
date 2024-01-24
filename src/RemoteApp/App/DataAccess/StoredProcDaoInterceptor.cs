using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using Castle.DynamicProxy;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.DataAccess
{
    public class StoredProcDaoInterceptor : IInterceptor
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<StoredProcDaoInterceptor>();
        private readonly string connectionString;

        public StoredProcDaoInterceptor(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Intercept(IInvocation invocation)
        {
            if (UseSharedConnection(invocation))
            {
                SqlConnection sqlConnection = GetConnection();
                RunCommand(sqlConnection, invocation);
            }
            else
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    RunCommand(sqlConnection, invocation);
                }
            }
        }

        private static bool UseSharedConnection(IInvocation invocation)
        {
            LocalDataStoreSlot slot = Thread.GetNamedDataSlot(Constants.SHOULD_SHARED_SQL_CONNECTION_STORE_NAME);
            object data = Thread.GetData(slot);
            if (data != null && data is bool)
            {
                bool useSharedConnection = (bool) data;
                return useSharedConnection;
            }

            string message = "Error determining whether sql connection should be shared for method: " + invocation.Method;
            logger.Error(message);
            throw new Exception(message);
        }

        private static void RunCommand(SqlConnection sqlConnection, IInvocation invocation)
        {
            LocalDataStoreSlot commandStore = Thread.GetNamedDataSlot(AbstractManagedDao.COMMAND_STORE_NAME);
            using (SqlCommand command = sqlConnection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                Thread.SetData(commandStore, command);
                invocation.Proceed();
            }
        }

        private SqlConnection GetConnection()
        {
            try
            {
                LocalDataStoreSlot sharedSqlConnectionSlot = Thread.GetNamedDataSlot(Constants.SHARED_SQL_CONNECTION_STORE_NAME);
                SqlConnection connection = Thread.GetData(sharedSqlConnectionSlot) as SqlConnection;
                if (connection == null)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    Thread.SetData(sharedSqlConnectionSlot, connection);
                }
                return connection;
            }
            catch (SqlException e)
            {
                logger.ErrorFormat("Sql Exception getting db connection to Server {0}. Message: {1}\n{2}", e.Server, e.Message, GetErrors(e.Errors));
                throw;
            }
            catch (Exception e)
            {
                logger.Error("Error getting connection: " + e);
                throw;
            }
        }
     
        private static string GetErrors(SqlErrorCollection sqlErrorCollection)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (SqlError error in sqlErrorCollection)
            {
                stringBuilder.AppendLine(string.Format("Class: {0}, Number: {1}, State: {2}, Message: {3}", error.Class, error.Number, error.State, error.Message));
            }
            return stringBuilder.ToString();
        }
    }
}