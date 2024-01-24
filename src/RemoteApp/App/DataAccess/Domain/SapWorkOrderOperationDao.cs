using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class SapWorkOrderOperationDao : AbstractManagedDao, ISapWorkOrderOperationDao
    {
        private const string INSERT_STORED_PROCEDURE = "InsertSapWorkOrderOperation";
        private const string FIND_BY_KEYS_STORED_PROCEDURE = "QuerySapWorkOrderOperationByKeys";

        public SapWorkOrderOperation Insert(SapWorkOrderOperation operation)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(operation, AddInsertParameters, INSERT_STORED_PROCEDURE);
            operation.Id = long.Parse(idParameter.Value.ToString());
            return operation;
        }

        public SapWorkOrderOperation FindByKeys(string workOrderNumber, string operationNumber, string subOperation, SapOperationType operationType)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@WorkOrderNumber", workOrderNumber);
            command.AddParameter("@OperationNumber", operationNumber);
            command.AddParameter("@OperationType", operationType.Name);

            if (subOperation != null)
            {
                command.AddParameter("@SubOperation", subOperation);
            }

            return command.QueryForSingleResult<SapWorkOrderOperation>(PopulateInstance , FIND_BY_KEYS_STORED_PROCEDURE);
        }

        private static void AddInsertParameters(SapWorkOrderOperation operation, SqlCommand command)
        {
            command.AddParameter("@WorkOrderNumber", operation.WorkOrderNumber);
            command.AddParameter("@OperationNumber", operation.OperationNumber);
            command.AddParameter("@SubOperation", operation.SubOperation);
            command.AddParameter("@OperationType", operation.SapOperationType.Name);
        }

        private static SapWorkOrderOperation PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string workOrderNumber = reader.Get<string>("WorkOrderNumber").TrimOrNull();
            string operationNumber = reader.Get<string>("OperationNumber").TrimOrNull();
            string subOperation = reader.Get<string>("SubOperation").TrimOrNull();
            string operationTypeString = reader.Get<string>("OperationType").TrimOrNull();

            SapOperationType operationType = SapOperationType.GetByName(operationTypeString);

            return new SapWorkOrderOperation(id, workOrderNumber, operationNumber, subOperation, operationType);
        }
    }
}