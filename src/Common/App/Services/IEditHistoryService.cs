using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IEditHistoryService
    {
        [OperationContract(Name = "GetEditHistoryActionItemDefinition")]
        List<DomainObjectChangeSet> GetEditHistoryForActionItemDefinition(long actionItemDefinitionId);

        [OperationContract(Name = "GetEditHistoryLog")]
        List<DomainObjectChangeSet> GetEditHistoryForLog(long logId);

        [OperationContract(Name = "GetEditHistorySummaryLog")]
        List<DomainObjectChangeSet> GetEditHistoryForSummaryLog(long summaryLogId);

        [OperationContract(Name = "GetEditHistoryTargetDefinition")]
        List<DomainObjectChangeSet> GetEditHistoryForTargetDefinition(long targetDefinitionId);

        [OperationContract(Name = "GetEditHistoryRestrictionDefinition")]
        List<DomainObjectChangeSet> GetEditHistoryForRestrictionDefinition(long definitionId);

        [OperationContract(Name = "GetEditHistoryDeviationAlertResponse")]
        List<DomainObjectChangeSet> GetEditHistoryForDeviationAlertResponse(long responseId);

        [OperationContract(Name = "GetEditHistoryWorkPermit")]
        List<DomainObjectChangeSet> GetEditHistoryForWorkPermit(long workPermitId);

        [OperationContract(Name = "GetEditHistoryWorkPermitMontreal")]
        List<DomainObjectChangeSet> GetEditHistoryForMontrealWorkPermit(long workPermitId);

        //RITM0301321 mangesh
        [OperationContract(Name = "GetEditHistoryWorkPermitMuds")]
        List<DomainObjectChangeSet> GetEditHistoryForMudsWorkPermit(long workPermitId);

        [OperationContract(Name = "GetEditHistoryLogDefinition")]
        List<DomainObjectChangeSet> GetEditHistoryForLogDefinition(long logDefinitionId);

        [OperationContract(Name = "GetEditHistoryGasTestElement")]
        List<DomainObjectChangeSet> GetEditHistory(Site gasTestElementInfoConfigHistorySite);

        [OperationContract(Name = "GetEditHistoryShiftHandoverQuestionnaire")]
        List<DomainObjectChangeSet> GetEditHistoryForShiftHandoverQuestionnaire(long questionnaireId);

        [OperationContract(Name = "GetEditHistoryLabAlertDefinition")]
        List<DomainObjectChangeSet> GetEditHistoryForLabAlertDefinition(long labAlertDefinitionId);

        [OperationContract(Name = "GetEditHistoryCokerCard")]
        List<DomainObjectChangeSet> GetEditHistoryForCokerCard(long cokerCardId);

        [OperationContract(Name = "GetEditHistoryPermitRequest")]
        List<DomainObjectChangeSet> GetEditHistoryForMontrealPermitRequest(long permitRequestId);

        [OperationContract(Name = "GetEditHistoryConfinedSpace")]
        List<DomainObjectChangeSet> GetEditHistoryForConfinedSpace(long confinedSpaceId);

        //RITM0301321 - mangesh
        [OperationContract(Name = "GetEditHistoryConfinedSpaceMuds")]
        List<DomainObjectChangeSet> GetEditHistoryForConfinedSpaceMuds(long confinedSpaceMudsId);
        
        [OperationContract(Name = "GetEditHistoryPermitRequestMuds")]
        List<DomainObjectChangeSet> GetEditHistoryForMudsPermitRequest(long permitRequestId);

        [OperationContract(Name = "GetEditHistoryWorkPermitEdmonton")]
        List<DomainObjectChangeSet> GetEditHistoryForEdmontonPermit(long permitId);

        [OperationContract(Name = "GetEditHistoryPermitRequestEdmonton")]
        List<DomainObjectChangeSet> GetEditHistoryForEdmontonPermitRequest(long permitRequestId);

        [OperationContract(Name = "GetEditHistoryFormGN24")]
        List<DomainObjectChangeSet> GetEditHistoryForFormGn24(long formId);

        [OperationContract(Name = "GetEditHistoryFormGN6")]
        List<DomainObjectChangeSet> GetEditHistoryForFormGn6(long formId);

        [OperationContract(Name = "GetEditHistoryFormGN7")]
        List<DomainObjectChangeSet> GetEditHistoryFormGn7(long formId);

        [OperationContract(Name = "GetEditHistoryFormGN59")]
        List<DomainObjectChangeSet> GetEditHistoryForFormGn59(long formId);

        [OperationContract(Name = "GetEditHistoryFormOP14")]
        List<DomainObjectChangeSet> GetEditHistoryForFormOp14(long formId);

        //generic template - mangesh
        [OperationContract(Name = "GetEditHistoryForFormGenericTemplate")]
        List<DomainObjectChangeSet> GetEditHistoryForFormGenericTemplate(long formId);

        //RITM0268131 - mangesh
        [OperationContract(Name = "GetEditHistoryForFormTemporaryInstallations")]
        List<DomainObjectChangeSet> GetEditHistoryForFormTemporaryInstallations(long formId);
        
        [OperationContract(Name = "GetEditHistoryMontrealCsd")]
        List<DomainObjectChangeSet> GetEditHistoryForMontrealCsd(long formId);

        [OperationContract(Name = "GetEditHistoryForOvertimeForm")]
        List<DomainObjectChangeSet> GetEditHistoryForOvertimeForm(long formId);

        [OperationContract(Name = "GetEditHistoryFormGN75A")]
        List<DomainObjectChangeSet> GetEditHistoryForFormGN75A(long formId);

        [OperationContract(Name = "GetEditHistoryFormGN75B")]
        List<DomainObjectChangeSet> GetEditHistoryForFormGN75B(long formId, long siteid);//Aarti

        [OperationContract(Name = "GetEditHistoryFormGN1")]
        List<DomainObjectChangeSet> GetEditHistoryForFormGN1(long formId);

        [OperationContract(Name = "GetEditHistoryTradeChecklist")]
        List<DomainObjectChangeSet> GetEditHistoryForTradeChecklist(long formId);

        [OperationContract(Name = "GetEditHistoryFormOilsandsTraining")]
        List<DomainObjectChangeSet> GetEditHistoryForOilsandsTrainingForm(long formId);

        [OperationContract(Name = "GetEditHistoryForOilsandsPermitAssessment")]
        List<DomainObjectChangeSet> GetEditHistoryForOilsandsPermitAssessmentForm(long formId);

        [OperationContract(Name = "GetEditHistoryWorkPermitLubes")]
        List<DomainObjectChangeSet> GetEditHistoryForLubesWorkPermit(long permitId);

        [OperationContract(Name = "GetEditHistoryPermitRequestLubes")]
        List<DomainObjectChangeSet> GetEditHistoryForLubesPermitRequest(long permitRequestId);

        [OperationContract(Name = "GetEditHistoryLubesCsdForm")]
        List<DomainObjectChangeSet> GetEditHistoryForLubesCsdForm(long formId);

        [OperationContract(Name = "GetEditHistoryDirective")]
        List<DomainObjectChangeSet> GetEditHistoryForDirective(long id);

        [OperationContract(Name = "TakeSnapshotActionItemDefnition")]
        void TakeSnapshot(ActionItemDefinition actionItemDefinition);

        [OperationContract(Name = "TakeSnapshotLog")]
        void TakeSnapshot(Log log);

        [OperationContract(Name = "TakeSnapshotSummaryLog")]
        void TakeSnapshot(SummaryLog log);

        [OperationContract(Name = "TakeSnapshotLogDefinition")]
        void TakeSnapshot(LogDefinition definition);

        [OperationContract(Name = "TakeSnapshotTargetDefinition")]
        void TakeSnapshot(TargetDefinition log);

        [OperationContract(Name = "TakeSnapshotRestrictionDefinition")]
        void TakeSnapshot(RestrictionDefinition definition);

        [OperationContract(Name = "TakeSnapshotDeviationAlertResponse")]
        void TakeSnapshot(DeviationAlertResponse response);

        [OperationContract(Name = "TakeSnapshotGasTestElement")]
        void TakeSnapshot(List<GasTestElementInfoDTO> gasTestElementInfoDtoList, DateTime lastModifiedDateTime,
            User lastModifiedUser, long siteId);

        [OperationContract(Name = "TakeSnapshotWorkPermit")]
        void TakeSnapshot(WorkPermit workPermit);

        [OperationContract(Name = "TakeSnapshotWorkPermitMontreal")]
        void TakeSnapshot(WorkPermitMontreal workPermitMontreal);

        //RITM0301321 mangesh
        [OperationContract(Name = "TakeSnapshotWorkPermitMuds")]
        void TakeSnapshot(WorkPermitMuds workPermitMuds);

        [OperationContract(Name = "TakeSnapshotFunctionalLocationOperationalMode")]
        void TakeSnapshot(FunctionalLocationOperationalMode flocOpMode, User lastModifiedUser);

        [OperationContract(Name = "TakeSnapshotShiftHandoverQuestionnaire")]
        void TakeSnapshot(ShiftHandoverQuestionnaire questionnaire);

        [OperationContract(Name = "TakeSnapshotLabAlertDefinition")]
        void TakeSnapshot(LabAlertDefinition labAlertDefinition);

        [OperationContract(Name = "TakeSnapshotCokerCard")]
        void TakeSnapshot(CokerCard cokerCard, List<CokerCardCycleStepEntry> previousEntries);

        [OperationContract(Name = "TakeSnapshotPermitRequest")]
        void TakeSnapshot(PermitRequestMontreal permitRequest);

        [OperationContract(Name = "TakeSnapshotConfinedSpace")]
        void TakeSnapshot(ConfinedSpace confinedSpace);

        //RITM0301321 - mangesh
        [OperationContract(Name = "TakeSnapshotConfinedSpaceMuds")]
        void TakeSnapshot(ConfinedSpaceMuds confinedSpace);

        [OperationContract(Name = "TakeSnapshotPermitRequestMuds")]
        void TakeSnapshot(PermitRequestMuds permitRequest);

        [OperationContract(Name = "TakeSnapshotWorkPermitEdmonton")]
        void TakeSnapshot(WorkPermitEdmonton permit);

        [OperationContract(Name = "TakeSnapshotPermitRequestEdmonton")]
        void TakeSnapshot(PermitRequestEdmonton permitRequest);

        [OperationContract(Name = "TakeSnapshotFormGN7")]
        void TakeSnapshot(FormGN7 form);

        [OperationContract(Name = "TakeSnapshotFormGN59")]
        void TakeSnapshot(FormGN59 form);

        [OperationContract(Name = "TakeSnapshotFormOP14")]
        void TakeSnapshot(FormOP14 form);

        //generic template - mangesh
        [OperationContract(Name = "TakeSnapshotFormGenericTemplate")]
        void TakeSnapshot(FormGenericTemplate form);

        //RITM0268131 - mangesh
        [OperationContract(Name = "TakeSnapshotFormTemporaryInstallationsMUDS")]
        void TakeSnapshot(TemporaryInstallationsMUDS form);

        //DMND0011225 CSD for WBR
        [OperationContract(Name = "TakeSnapshotFormGenericCsd")]
        void TakeSnapshot(GenericCsd form);

        [OperationContract(Name = "TakeSnapshotFormMontrealCsd")]
        void TakeSnapshot(MontrealCsd form);

        [OperationContract(Name = "TakeSnapshotLubesCsdForm")]
        void TakeSnapshot(LubesCsdForm form);

        [OperationContract(Name = "TakeSnapshotFormGN24")]
        void TakeSnapshot(FormGN24 form);

        [OperationContract(Name = "TakeSnapshotFormGN6")]
        void TakeSnapshot(FormGN6 form);

        [OperationContract(Name = "TakeSnapshotFormGN75A")]
        void TakeSnapshot(FormGN75A form);

        [OperationContract(Name = "TakeSnapshotFormGN75B")]
        void TakeSnapshot(FormGN75B form);

        [OperationContract(Name = "TakeSnapshotFormGN1")]
        void TakeSnapshot(FormGN1 form);

        [OperationContract(Name = "TakeSnapshotTradeChecklist")]
        void TakeSnapshot(List<TradeChecklist> tradeChecklist);

        [OperationContract(Name = "TakeSnapshotFormOilsandsTraining")]
        void TakeSnapshot(FormOilsandsTraining form);

        [OperationContract(Name = "TakeSnapshotWorkPermitLubes")]
        void TakeSnapshot(WorkPermitLubes workPermit);

        [OperationContract(Name = "TakeSnapshotPermitRequestLubes")]
        void TakeSnapshot(PermitRequestLubes permitRequest);

        [OperationContract(Name = "TakeSnapshotDirective")]
        void TakeSnapshot(Directive directive);

        [OperationContract(Name = "GetRecentEditHistoryLog")]
        List<DomainObjectChangeSet> GetRecentEditHistoryForLog(long logId);

        [OperationContract(Name = "GetRecentEditHistorySummaryLog")]
        List<DomainObjectChangeSet> GetRecentEditHistoryForSummaryLog(long summaryLogId);

        [OperationContract(Name = "TakeSnapshotOvertimeForm")]
        void TakeSnapshot(OvertimeForm overtimeForm);

        [OperationContract(Name = "TakeSnapshotLubesAlarmDisableForm")]
        void TakeSnapshot(LubesAlarmDisableForm form);

        [OperationContract(Name = "GetEditHistoryLubesAlarmDisableForm")]
        List<DomainObjectChangeSet> GetEditHistoryForLubesAlarmDisableForm(long formId);

        [OperationContract(Name = "TakeSnapshotExcursionResponse")]
        void TakeSnapshot(OpmExcursionResponse excursionResponse);

        [OperationContract(Name = "TakeSnapshotOpmToeDefinitionCommentHistory")]
        void TakeSnapshot(OpmToeDefinitionComment opmToeDefinitionComment);

        [OperationContract(Name = "GetEditHistoryForExcursionResponse")]
        List<DomainObjectChangeSet> GetEditHistoryForExcursionResponse(long id);

        [OperationContract(Name = "GetEditHistoryForOpmToeDefinitionComment")]
        List<DomainObjectChangeSet> GetEditHistoryForOpmToeDefinitionComment(string toeName);

        [OperationContract(Name = "TakeSnapshotPermitAssessmentForm")]
        void TakeSnapshot(PermitAssessment form);

        [OperationContract(Name = "GetEditHistoryForDocumentSuggestion")]
        List<DomainObjectChangeSet> GetEditHistoryForDocumentSuggestion(long formId);

        [OperationContract(Name = "TakeSnapshotDocumentSuggestionForm")]
        void TakeSnapshot(DocumentSuggestion form);

        [OperationContract(Name = "GetEditHistoryForProcedureDeviation")]
        List<DomainObjectChangeSet> GetEditHistoryForProcedureDeviation(long formId);

        [OperationContract(Name = "TakeSnapshotProcedureDeviationForm")]
        void TakeSnapshot(ProcedureDeviation form);

        [OperationContract(Name = "TakeSnapshotPermitRequestFortHills")]
        void TakeSnapshot(PermitRequestFortHills permitRequest);

        [OperationContract(Name = "TakeSnapshotWorkPermitFortHills")]
        void TakeSnapshot(WorkPermitFortHills permit);

        [OperationContract]
        List<DomainObjectChangeSet> GetEditHistoryForWorkPermitSign(string workPermitnumber);

        [OperationContract]
        List<DomainObjectChangeSet> GetEditHistoryForWorkPermitMudsSign(string workPermitnumber);

        [OperationContract]
        List<DomainObjectChangeSet> GetEditHistoryForConfinedSpaceMudsSign(string confinespacenumber);
    }
}