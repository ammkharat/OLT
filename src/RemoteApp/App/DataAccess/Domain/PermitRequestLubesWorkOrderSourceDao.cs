using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class PermitRequestLubesWorkOrderSourceDao : AbstractManagedDao, IPermitRequestLubesWorkOrderSourceDao
    {
        private const string INSERT_STORED_PROC = "InsertPermitRequestLubesWorkOrderSource";
        private const string DELETE_STORED_PROC = "DeletePermitRequestLubesWorkOrderSourceByPermitRequestId";
        private const string QUERY_BY_PERMIT_REQUEST_ID_STORED_PROC = "QueryPermitRequestLubesWorkOrderSourceByPermitRequestId";

        public List<PermitRequestWorkOrderSource> QueryByPermitRequest(PermitRequestLubes permitRequest)
        {
            SqlCommand command = ManagedCommand;
            command.Parameters.Clear();
            command.AddParameter("@PermitRequestId", permitRequest.IdValue);

            return command.QueryForListResult(reader => PopulateInstance(reader, permitRequest), QUERY_BY_PERMIT_REQUEST_ID_STORED_PROC);
        }

        public void DeleteByPermitRequestId(SqlCommand command, long permitRequestId)
        {
            command.CommandText = DELETE_STORED_PROC;
            command.Parameters.Clear();
            command.AddParameter("@PermitRequestId",  permitRequestId);
            command.ExecuteNonQuery();
        }
     
        public void InsertWorkOrderSourceList(SqlCommand command, PermitRequestLubes permitRequest)
        {
            if (permitRequest.WorkOrderSourceList.Count > 0)
            {
                command.CommandText = INSERT_STORED_PROC;

                foreach (PermitRequestWorkOrderSource workOrderSource in permitRequest.WorkOrderSourceList)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@PermitRequestId",  permitRequest.IdValue);
                    command.AddParameter("@OperationNumber", workOrderSource.OperationNumber);
                    command.AddParameter("@SubOperationNumber", workOrderSource.SubOperationNumber);
                    command.ExecuteNonQuery();
                }
            }            
        }

        private static PermitRequestWorkOrderSource PopulateInstance(SqlDataReader reader, PermitRequestLubes permitRequest)
        {
            string operationNumber = reader.Get<string>("OperationNumber");
            string subOperationNumber = reader.Get<string>("SubOperationNumber");

            return new PermitRequestWorkOrderSource(permitRequest.WorkOrderNumber, operationNumber, subOperationNumber);
        }
    }
}
