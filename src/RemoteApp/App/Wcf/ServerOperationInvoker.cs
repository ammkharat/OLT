using System;
using System.Configuration;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Transactions;
using System.ServiceModel.Dispatcher;
using System.Threading;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Wcf;
using Com.Suncor.Olt.Remote.Utilities;
using log4net;

namespace Com.Suncor.Olt.Remote.Wcf
{
    public class ServerOperationInvoker : IOperationInvoker
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<ServerOperationInvoker>();

        private readonly IOperationInvoker innerOperationInvoker;
        private readonly string syncMethodName;
        private readonly bool isTransactional = true;

        public ServerOperationInvoker(IOperationInvoker innerOperationInvoker, MethodInfo syncMethod)
        {
            this.innerOperationInvoker = innerOperationInvoker;

            if (syncMethod != null)
            {
                syncMethodName = syncMethod.ToString();
            }
            isTransactional = GetIsTransactional(syncMethod);
        }

        private static bool GetIsTransactional(MethodInfo methodInfo)
        {
            bool isTransactional = true;

            if (methodInfo != null)
            {
                if (methodInfo.HasAttribute<NonTransactionalOperationAttribute>(true))
                {
                    isTransactional = false;
                    logger.DebugFormat("Operation {0} is not transactional.", methodInfo);
                }
            }

            return isTransactional;
        }

        #region Pass to inner invoker
        public object[] AllocateInputs()
        {
            return innerOperationInvoker.AllocateInputs();
        }

        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            return innerOperationInvoker.InvokeBegin(instance, inputs, callback, state);
        }

        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            return innerOperationInvoker.InvokeEnd(instance, out outputs, result);
        }

        public bool IsSynchronous
        {
            get { return innerOperationInvoker.IsSynchronous; }
        }
        #endregion

        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            try
            {
                PullClientUrlOffHeader();
                SetThreadCultureInfo();

                EventQueue.InitializeEventQueue();
                InitializeSqlConnectionDataStore();

                object result = isTransactional ? 
                    InvokeWithTransaction(instance, inputs, out outputs) : 
                    InvokeNoTransaction(instance, inputs, out outputs);

                EventQueue.FlushAllEventsRegistered();

                return result;
            }
            catch (Exception e)
            {
                string messageHeader = MessageHeaderUtility.GetUserHeaderInformation(OperationContext.Current);
                string inputsAsString = ConvertToString(inputs);
                string message =
                    "An error has occured while executing server operation." + Environment.NewLine +
                    "Error GUID: " + Guid.NewGuid() + Environment.NewLine +
                    "Method: " + syncMethodName + Environment.NewLine +
                    "User Information: " + messageHeader + Environment.NewLine +
                    inputsAsString + 
                    "Exception Information: " + e;
                logger.ErrorFormat(message);
                // As there is no guarantee that the exception is serializable, we shall throw a serializable
                //  OLTException containing the messages + stack trace inside.
                throw new OLTException(message);
            }
            finally
            {
                EventQueue.CleanUpEventQueue();
                CleanUpSqlConnectionDataStore();
            }
        }

        private static void SetThreadCultureInfo()
        {
            string cultureInfoName = MessageHeaderUtility.GetClientCultureInfoName(OperationContext.Current);
            if (cultureInfoName.HasValue())
            {
                Culture.SetSpecificCultureOnThread(cultureInfoName);
            }
        }

        private static void PullClientUrlOffHeader()
        {
            string clientUri = MessageHeaderUtility.GetClientUri(OperationContext.Current);
            LocalDataStoreSlot slot = Thread.GetNamedDataSlot("ClientUri");
            Thread.SetData(slot, clientUri);
        }

        private static string ConvertToString(object[] inputs)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (inputs != null)
                {
                    for (int i = 0; i < inputs.Length; i++)
                    {
                        sb.Append("Input[" + i + "]: ");
                        object input = inputs[i];
                        if (input != null)
                        {
                            sb.Append("Type:" + input.GetType().Name + " - ");
                            sb.AppendLine(input.ToString());
                        }
                        else
                        {
                            sb.AppendLine("<null>");
                        }
                    }
                }
                return sb.ToString();
            }
            catch (Exception e)
            {
                return "Error converting inputs to string: " + e;
            }
        }

        private object InvokeNoTransaction(object instance, object[] inputs, out object[] outputs)
        {
            object result = innerOperationInvoker.Invoke(instance, inputs, out outputs);
            return result;
        }

        private object InvokeWithTransaction(object instance, object[] inputs, out object[] outputs)
        {
            object result;

            TransactionOptions transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = new TimeSpan(0, GetTransactionScopeTimeoutMinutes(), 0)
                };

            using (TransactionScope trans = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
            {
                result = innerOperationInvoker.Invoke(instance, inputs, out outputs);
                trans.Complete();
            }
            return result;
        }

        private static int GetTransactionScopeTimeoutMinutes()
        {
            const int defaultTimeout = 10;

            string transactionScopeTimeout = ConfigurationManager.AppSettings.Get("TransactionScopeTimeoutMinutes");
            if (transactionScopeTimeout == null)
            {
                return defaultTimeout;
            }

            int timeout;
            return int.TryParse(transactionScopeTimeout, out timeout) ? timeout : defaultTimeout;
        }

        private void InitializeSqlConnectionDataStore()
        {
            try
            {
                {
                    LocalDataStoreSlot slot = Thread.GetNamedDataSlot(Constants.SHOULD_SHARED_SQL_CONNECTION_STORE_NAME);
                    Thread.SetData(slot, isTransactional);
                }
                {
                    LocalDataStoreSlot slot = Thread.GetNamedDataSlot(Constants.SHARED_SQL_CONNECTION_STORE_NAME);
                    Thread.SetData(slot, null);
                }
            }
            catch (Exception e)
            {
                logger.Error("Error initializing SharedSqlConnection: " + e);
            }
        }

        private static void CleanUpSqlConnectionDataStore()
        {
            try
            {
                {
                    LocalDataStoreSlot slot = Thread.GetNamedDataSlot(Constants.SHOULD_SHARED_SQL_CONNECTION_STORE_NAME);
                    Thread.SetData(slot, null);
                }
                {
                    LocalDataStoreSlot slot = Thread.GetNamedDataSlot(Constants.SHARED_SQL_CONNECTION_STORE_NAME);
                    IDisposable connection = Thread.GetData(slot) as IDisposable;
                    if (connection != null)
                    {
                        connection.Dispose();
                    }
                    Thread.SetData(slot, null);
                }
            }
            catch (Exception e)
            {
                logger.Error("Error cleaning up SharedSqlConnection: " + e);
            }
        }

    }
}
