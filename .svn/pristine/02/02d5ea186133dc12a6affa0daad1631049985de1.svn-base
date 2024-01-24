using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Target;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class TargetDefinitionStateDao : AbstractManagedDao, ITargetDefinitionStateDao
    {
        private const string QueryAllAtOrUnderAGivenThirdLevelFloc = "QueryAllTargetDefinitionStatesAtOrBelowAGivenLevelThreeFloc";
        private const string InsertStoredProcedure = "InsertTargetDefinitionState";
        private const string UpdateStoredProcedure = "UpdateTargetDefinitionState";
        private const string QueryByIdStoredProcedure = "QueryTargetDefinitionStateById";

        public TargetDefinitionState QueryById(long id)
        {
            return ManagedCommand.QueryById<TargetDefinitionState>(id, PopulateInstance, QueryByIdStoredProcedure);            
        }

        private static TargetDefinitionState PopulateInstance(SqlDataReader reader)
        {
            long targetDefinitionId = reader.Get<long>("TargetDefinitionId");
            bool isExceedingBoundaries = reader.Get<bool>("ExceedingBoundaries");
            DateTime? lastSuccessfulAccess = reader.Get<DateTime?>("LastSuccessfulTagAccess");

            return new TargetDefinitionState(targetDefinitionId, isExceedingBoundaries, lastSuccessfulAccess);
        }

        public void Update(TargetDefinitionState currentTargetDefinitionState)
        {
            SqlCommand command = ManagedCommand;
            command.Update(currentTargetDefinitionState, AddInsertOrUpdateParameters, UpdateStoredProcedure);
        }

        public List<TargetDefinitionState> QueryAllTargetDefinitionStatesUnderAUnitId(long thirdLevelFlocId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@UnitId", thirdLevelFlocId);
            return command.QueryForListResult<TargetDefinitionState>(PopulateInstance, QueryAllAtOrUnderAGivenThirdLevelFloc);
        }

        public void Insert(TargetDefinitionState targetDefinitionState)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(targetDefinitionState, AddInsertOrUpdateParameters, InsertStoredProcedure);
        }

        private static void AddInsertOrUpdateParameters(TargetDefinitionState targetDefinitionState, SqlCommand command)
        {
            command.AddParameter("@TargetDefinitionId", targetDefinitionState.IdValue);
            command.AddParameter("@ExceedingBoundaries", targetDefinitionState.IsExceedingBoundary);
            command.AddParameter("@LastSuccessfulTagAccess", targetDefinitionState.LastSuccessfulTagAccess);
        }

    }
}