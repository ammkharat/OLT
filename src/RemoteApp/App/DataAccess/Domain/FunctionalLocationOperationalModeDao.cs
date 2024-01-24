using System;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.DataAccess.DTO;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FunctionalLocationOperationalModeDao : AbstractManagedDao, IFunctionalLocationOperationalModeDao
    {
        private const string INSERT_STORED_PROC = "InsertFunctionalLocationOperationalMode";
        private const string UPDATE_STORED_PROC = "UpdateFunctionalLocationOperationalMode";
        private const string QUERY_STORED_PROC = "QueryFunctionalLocationOperationalModeById";
        
        public void Update(FunctionalLocationOperationalMode functionalLocationOperationalMode)
        {
            ManagedCommand.Update(functionalLocationOperationalMode, AddUpdateParameters, UPDATE_STORED_PROC);
        }

        public void Insert(FunctionalLocationOperationalMode functionalLocationOperationalMode)
        {
            ManagedCommand.Insert(functionalLocationOperationalMode, AddInsertParameters, INSERT_STORED_PROC);
        }

        private static void AddInsertParameters(FunctionalLocationOperationalMode functionalLocationOperationalMode, SqlCommand command)
        {
            SetCommonAttributes(functionalLocationOperationalMode, command);
        }

        private static void AddUpdateParameters(FunctionalLocationOperationalMode functionalLocationOperationalMode, SqlCommand command)
        {
            SetCommonAttributes(functionalLocationOperationalMode, command);
        }

        private static void SetCommonAttributes(FunctionalLocationOperationalMode functionalLocationOperationalMode, SqlCommand command)
        {
            command.AddParameter("@UnitId", functionalLocationOperationalMode.Id);
            command.AddParameter("@AvailabilityReasonId", functionalLocationOperationalMode.AvailabilityReason.Id);
            command.AddParameter("@OperationalModeId", functionalLocationOperationalMode.OperationalMode.Id);
            command.AddParameter("@LastModifiedDateTime", functionalLocationOperationalMode.LastModifiedDateTime);
        }

        public FunctionalLocationOperationalMode QueryById(long id)
        {
            return ManagedCommand.QueryById(id, (PopulateInstance<FunctionalLocationOperationalMode>) PopulateInstance, QUERY_STORED_PROC);
        }

        protected static FunctionalLocationOperationalMode PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("UnitId");
            
            long operationalModeId = reader.Get<long>("OperationalModeId");
            OperationalMode opMode = OperationalMode.GetById((int)operationalModeId);

            long availabilityReasonId = reader.Get<long>("AvailabilityReasonId");
            AvailabilityReason reason = AvailabilityReason.GetById((int)availabilityReasonId);
            
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            var result =
                new FunctionalLocationOperationalMode(id, opMode, reason, lastModifiedDateTime);
            
            return result;
        }
        
    }
}