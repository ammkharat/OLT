using System;
using System.Data.SqlClient;
using System.Threading;

namespace Com.Suncor.Olt.Remote.DataAccess
{
    public abstract class AbstractManagedDao
    {
        public const string COMMAND_STORE_NAME = "dbcommand";

        protected SqlCommand ManagedCommand
        {
            get
            {
                LocalDataStoreSlot dataStore = Thread.GetNamedDataSlot(COMMAND_STORE_NAME);
                SqlCommand command = Thread.GetData(dataStore) as SqlCommand;
                command.CommandTimeout = 400;   //testing ayman
                command.Parameters.Clear();
                return command;
            }
        }
    }
}