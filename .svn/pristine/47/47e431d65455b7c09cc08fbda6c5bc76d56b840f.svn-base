using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ILogDao : IDao
    {
        //[CachedQueryById]
        Log QueryById(long id);
        [CachedInsertOrUpdate(false, false)]
        Log Insert(Log log);
        [CachedRemove(false, false)]
        void Remove(Log log);
        [CachedInsertOrUpdate(false, false)]
        void Update(Log log);
        Log Insert(Log log, ActionItem associatedActionItem);
        Log Insert(Log log, ActionItemDefinition associatedActionItemDefinition);
        Log Insert(Log log, WorkPermitEdmonton associatedWorkPermit);
        Log Insert(Log log, WorkPermitLubes associatedWorkPermit);
        Log Insert(Log log, TargetAlert targetAlert);

        void InsertAssociationToActionItem(Log log, long actionItemId);
        void InsertAssociationToActionItemDefinition(Log log, long actionItemDefinitionId);
        bool HasLogForDefinitionSameDayAndAtLeastOneOfTheQueriedFlocs(LogDefinition definition, DateTime check, ExactFlocSet flocSet);

        int QueryCountOfLogsAssociatedToActionItem(long actionItemId);
        int QueryCountOfLogsAssociatedToActionItemDefinition(long actionItemDefinitionId);
        int QueryCountOfLogsAssociatedToWorkPermitEdmonton(long workPermitEdmontonId);
        int QueryCountOfLogsAssociatedToWorkPermitLubes(long workPermitLubesId);
        int QueryCountOfLogsAssociatedToTargetAlert(long targetAlertId);

        bool HasChildren(Log log);
        List<Log> QueryLogsInBatches(long siteId, int batchNumber, int batchSize, LogType logType);
        int QueryCountOfLogs(long siteId, LogType logType);
        Log Insert(Log log, WorkPermitMontreal associatedWorkPermit);
        int QueryCountOfLogsAssociatedToWorkPermitMontreal(long workPermitMontrealId);

        int QueryCountOfLogsByFunctionalLocation(long siteId, LogType logType, List<FunctionalLocation> flocs);
        List<Log> QueryLogsInBatchesByFunctionalLocation(long siteId, int batchNumber, int batchSize, LogType logType, List<FunctionalLocation> flocs);

        //RITM0301321 mangesh
        int QueryCountOfLogsAssociatedToWorkPermitMuds(long workPermitMudsId);
        Log Insert(Log log, WorkPermitMuds associatedWorkPermit);
    }
}