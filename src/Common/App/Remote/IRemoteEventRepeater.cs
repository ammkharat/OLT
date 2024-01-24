using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO.Excursions;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Remote
{
    public interface IRemoteEventRepeater
    {
        event ServiceEventHandler<TargetAlert> ServerTargetAlertCreated;
        event ServiceEventHandler<TargetAlert> ServerTargetAlertUpdated;

        event ServiceEventHandler<ActionItemDefinition> ServerActionItemDefinitionCreated;
        event ServiceEventHandler<ActionItemDefinition> ServerActionItemDefinitionUpdated;
        event ServiceEventHandler<ActionItemDefinition> ServerActionItemDefinitionRemoved;

        event ServiceEventHandler<ActionItem> ServerActionItemUpdated;
        event ServiceEventHandler<ActionItem> ServerActionItemCreated;
        event ServiceEventHandler<ActionItem> ServerActionItemRemoved;
        event ServiceEventHandler<Site> ServerActionItemRefresh;

        event ServiceEventHandler<TargetDefinition> ServerTargetDefinitionCreated;
        event ServiceEventHandler<TargetDefinition> ServerTargetDefinitionUpdated;
        event ServiceEventHandler<TargetDefinition> ServerTargetDefinitionRemoved;

        event ServiceEventHandler<RestrictionDefinition> ServerRestrictionDefinitionCreated;
        event ServiceEventHandler<RestrictionDefinition> ServerRestrictionDefinitionUpdated;
        event ServiceEventHandler<RestrictionDefinition> ServerRestrictionDefinitionRemoved;

        event ServiceEventHandler<LabAlertDefinition> ServerLabAlertDefinitionCreated;
        event ServiceEventHandler<LabAlertDefinition> ServerLabAlertDefinitionUpdated;
        event ServiceEventHandler<LabAlertDefinition> ServerLabAlertDefinitionRemoved;

        event ServiceEventHandler<LabAlert> ServerLabAlertCreated;
        event ServiceEventHandler<LabAlert> ServerLabAlertUpdated;

        event ServiceEventHandler<ShiftHandoverQuestionnaire> ServerShiftHandoverQuestionnaireCreated;
        event ServiceEventHandler<ShiftHandoverQuestionnaire> ServerShiftHandoverQuestionnaireUpdated;
        event ServiceEventHandler<ShiftHandoverQuestionnaire> ServerShiftHandoverQuestionnaireRemoved;
        event ServiceEventHandler<ShiftHandoverQuestionnaire> ServerShiftHandoverQuestionnaireMarkedAsReadByCurrentUser;

        event ServiceEventHandler<Log> ServerLogCreated;
        event ServiceEventHandler<Log> ServerLogUpdated;
        event ServiceEventHandler<Log> ServerLogRemoved;
        event ServiceEventHandler<Log> ServerLogMarkedAsReadByCurrentUser;

        event ServiceEventHandler<LogDefinition> ServerLogDefinitionCreated;
        event ServiceEventHandler<LogDefinition> ServerLogDefinitionRemoved;
        event ServiceEventHandler<LogDefinition> ServerLogDefinitionUpdated;
        event ServiceEventHandler<LogDefinition> ServerLogCancelledRecurringDefinition;

        event ServiceEventHandler<SummaryLog> ServerSummaryLogCreated;
        event ServiceEventHandler<SummaryLog> ServerSummaryLogUpdated;
        event ServiceEventHandler<SummaryLog> ServerSummaryLogRemoved;

        event ServiceEventHandler<CokerCard> ServerCokerCardCreated;
        event ServiceEventHandler<CokerCard> ServerCokerCardUpdated;
        event ServiceEventHandler<CokerCard> ServerCokerCardRemoved;

        event ServiceEventHandler<WorkPermit> ServerWorkPermitCreated;
        event ServiceEventHandler<WorkPermit> ServerWorkPermitUpdated;
        event ServiceEventHandler<WorkPermit> ServerWorkPermitRemoved;

        event ServiceEventHandler<WorkPermit> ServerWorkPermitCreated_Template;

        

        event ServiceEventHandler<WorkPermitMontreal> ServerWorkPermitMontrealCreated;
        event ServiceEventHandler<WorkPermitMontreal> ServerWorkPermitMontrealUpdated;
        event ServiceEventHandler<WorkPermitMontreal> ServerWorkPermitMontrealRemoved;

        event ServiceEventHandler<PermitRequestMontreal> ServerPermitRequestCreated;
        event ServiceEventHandler<PermitRequestMontreal> ServerPermitRequestUpdated;
        event ServiceEventHandler<PermitRequestMontreal> ServerPermitRequestRemoved;

        event ServiceEventHandler<ConfinedSpace> ServerConfinedSpaceCreated;
        event ServiceEventHandler<ConfinedSpace> ServerConfinedSpaceUpdated;
        event ServiceEventHandler<ConfinedSpace> ServerConfinedSpaceRemoved;

        //RITM0301321 - mangesh
        event ServiceEventHandler<ConfinedSpaceMuds> ServerConfinedSpaceMudsCreated;
        event ServiceEventHandler<ConfinedSpaceMuds> ServerConfinedSpaceMudsUpdated;
        event ServiceEventHandler<ConfinedSpaceMuds> ServerConfinedSpaceMudsRemoved;

        event ServiceEventHandler<SAPNotification> ServerSAPNotificationCreated;
        event ServiceEventHandler<SAPNotification> ServerSAPNotificationProcessed;
        event ServiceEventHandler<SAPNotification> ServerSAPNotificationUpdated;

        event ServiceEventHandler<FunctionalLocation> ServerFunctionalLocationOperationalModeUpdated;

        event ServiceEventHandler<DeviationAlert> ServerDeviationAlertCreated;
        event ServiceEventHandler<DeviationAlert> ServerDeviationAlertUpdated;

        event ServiceEventHandler<WorkPermitEdmonton> ServerWorkPermitEdmontonCreated;
        event ServiceEventHandler<WorkPermitEdmonton> ServerWorkPermitEdmontonUpdated;
        event ServiceEventHandler<WorkPermitEdmonton> ServerWorkPermitEdmontonRemoved;

        event ServiceEventHandler<PermitRequestEdmonton> ServerPermitRequestEdmontonCreated;
        event ServiceEventHandler<PermitRequestEdmonton> ServerPermitRequestEdmontonUpdated;
        event ServiceEventHandler<PermitRequestEdmonton> ServerPermitRequestEdmontonRemoved;

        event ServiceEventHandler<FormGN7> ServerGN7FormCreated;
        event ServiceEventHandler<FormGN7> ServerGN7FormUpdated;
        event ServiceEventHandler<FormGN7> ServerGN7FormRemoved;

        event ServiceEventHandler<FormGN59> ServerGN59FormCreated;
        event ServiceEventHandler<FormGN59> ServerGN59FormUpdated;
        event ServiceEventHandler<FormGN59> ServerGN59FormRemoved;

        event ServiceEventHandler<FormOP14> ServerOP14FormCreated;
        event ServiceEventHandler<FormOP14> ServerOP14FormUpdated;
        event ServiceEventHandler<FormOP14> ServerOP14FormRemoved;
        event ServiceEventHandler<BaseEdmontonForm> ServerCSDMarkedAsReadByCurrentUser;

        //RITM0301321 - mangesh
        event ServiceEventHandler<WorkPermitMuds> ServerWorkPermitMudsCreated;
        event ServiceEventHandler<WorkPermitMuds> ServerWorkPermitMudsTemplateCreated;
        
        event ServiceEventHandler<WorkPermitMuds> ServerWorkPermitMudsUpdated;
        event ServiceEventHandler<WorkPermitMuds> ServerWorkPermitMudsRemoved;

        event ServiceEventHandler<PermitRequestMuds> ServerPermitRequestMudsCreated;
        event ServiceEventHandler<PermitRequestMuds> ServerPermitRequestMudsTemplateCreated;
        
        event ServiceEventHandler<PermitRequestMuds> ServerPermitRequestMudsUpdated;
        event ServiceEventHandler<PermitRequestMuds> ServerPermitRequestMudsRemoved;

        //generic template - mangesh
        event ServiceEventHandler<FormGenericTemplate> ServerGenericTemplateFormCreated;
        event ServiceEventHandler<FormGenericTemplate> ServerGenericTemplateFormUpdated;
        event ServiceEventHandler<FormGenericTemplate> ServerGenericTemplateFormRemoved;

        event ServiceEventHandler<MontrealCsd> ServerMontrealCsdFormCreated;
        event ServiceEventHandler<MontrealCsd> ServerMontrealCsdFormUpdated;
        event ServiceEventHandler<MontrealCsd> ServerMontrealCsdFormRemoved;

        //DMND0011225 OLT - CSD for WBR
        event ServiceEventHandler<GenericCsd> ServerGenericCsdFormCreated;
        event ServiceEventHandler<GenericCsd> ServerGenericCsdFormUpdated;
        event ServiceEventHandler<GenericCsd> ServerGenericCsdFormRemoved;


     //RITM0268131 - mangesh
        event ServiceEventHandler<TemporaryInstallationsMUDS> ServerMudsTemporaryInstallationsFormCreated;
        event ServiceEventHandler<TemporaryInstallationsMUDS> ServerMudsTemporaryInstallationsFormUpdated;
        event ServiceEventHandler<TemporaryInstallationsMUDS> ServerMudsTemporaryInstallationsFormRemoved;  
      event ServiceEventHandler<LubesCsdForm> ServerLubesCsdFormCreated;
        event ServiceEventHandler<LubesCsdForm> ServerLubesCsdFormUpdated;
        event ServiceEventHandler<LubesCsdForm> ServerLubesCsdFormRemoved;

        event ServiceEventHandler<LubesAlarmDisableForm> ServerLubesAlarmDisableFormCreated;
        event ServiceEventHandler<LubesAlarmDisableForm> ServerLubesAlarmDisableFormUpdated;
        event ServiceEventHandler<LubesAlarmDisableForm> ServerLubesAlarmDisableFormRemoved;

        event ServiceEventHandler<FormGN24> ServerGN24FormCreated;
        event ServiceEventHandler<FormGN24> ServerGN24FormUpdated;
        event ServiceEventHandler<FormGN24> ServerGN24FormRemoved;

        event ServiceEventHandler<FormGN6> ServerGN6FormCreated;
        event ServiceEventHandler<FormGN6> ServerGN6FormUpdated;
        event ServiceEventHandler<FormGN6> ServerGN6FormRemoved;

        event ServiceEventHandler<FormGN75A> ServerGN75AFormCreated;
        event ServiceEventHandler<FormGN75A> ServerGN75AFormUpdated;
        event ServiceEventHandler<FormGN75A> ServerGN75AFormRemoved;

        event ServiceEventHandler<FormGN75B> ServerGN75BFormCreated;
        event ServiceEventHandler<FormGN75B> ServerGN75BFormUpdated;
        event ServiceEventHandler<FormGN75B> ServerGN75BFormRemoved;

        //ayman Sarnia eip DMND0008992
        event ServiceEventHandler<FormGN75B> ServerGN75BTemplateFormCreated;
        event ServiceEventHandler<FormGN75B> ServerGN75BTemplateFormUpdated;
        event ServiceEventHandler<FormGN75B> ServerGN75BTemplateFormRemoved;





        event ServiceEventHandler<FormGN1> ServerGN1FormCreated;
        event ServiceEventHandler<FormGN1> ServerGN1FormUpdated;
        event ServiceEventHandler<FormGN1> ServerGN1FormRemoved;

        event ServiceEventHandler<PermitAssessment> ServerOilsandsPermitAssessmentFormCreated;
        event ServiceEventHandler<PermitAssessment> ServerOilsandsPermitAssessmentFormUpdated;
        event ServiceEventHandler<PermitAssessment> ServerOilsandsPermitAssessmentFormRemoved;

        event ServiceEventHandler<DocumentSuggestion> ServerDocumentSuggestionFormCreated;
        event ServiceEventHandler<DocumentSuggestion> ServerDocumentSuggestionFormUpdated;
        event ServiceEventHandler<DocumentSuggestion> ServerDocumentSuggestionFormRemoved;

        event ServiceEventHandler<ProcedureDeviation> ServerProcedureDeviationFormCreated;
        event ServiceEventHandler<ProcedureDeviation> ServerProcedureDeviationFormUpdated;
        event ServiceEventHandler<ProcedureDeviation> ServerProcedureDeviationFormRemoved;

        event ServiceEventHandler<OvertimeForm> ServerOvertimeFormCreated;
        event ServiceEventHandler<OvertimeForm> ServerOvertimeFormUpdated;
        event ServiceEventHandler<OvertimeForm> ServerOvertimeFormRemoved;

        event ServiceEventHandler<OnPremisePersonnel> ServerOnPremisePersonnelCreated;
        event ServiceEventHandler<OnPremisePersonnel> ServerOnPremisePersonnelUpdated;
        event ServiceEventHandler<OnPremisePersonnel> ServerOnPremisePersonnelRemoved;

        event ServiceEventHandler<ShiftHandoverEmailConfiguration> ServerShiftHandoverEmailConfigurationCreated;
        event ServiceEventHandler<ShiftHandoverEmailConfiguration> ServerShiftHandoverEmailConfigurationUpdated;
        event ServiceEventHandler<ShiftHandoverEmailConfiguration> ServerShiftHandoverEmailConfigurationRemoved;

        event ServiceEventHandler<WorkPermitLubes> ServerWorkPermitLubesCreated;
        event ServiceEventHandler<WorkPermitLubes> ServerWorkPermitLubesUpdated;
        event ServiceEventHandler<WorkPermitLubes> ServerWorkPermitLubesRemoved;

        event ServiceEventHandler<PermitRequestLubes> ServerPermitRequestLubesCreated;
        event ServiceEventHandler<PermitRequestLubes> ServerPermitRequestLubesUpdated;
        event ServiceEventHandler<PermitRequestLubes> ServerPermitRequestLubesRemoved;

        event ServiceEventHandler<FormOilsandsTraining> ServerFormOilsandsTrainingCreated;
        event ServiceEventHandler<FormOilsandsTraining> ServerFormOilsandsTrainingUpdated;
        event ServiceEventHandler<FormOilsandsTraining> ServerFormOilsandsTrainingRemoved;

        event ServiceEventHandler<SapAutoImportConfiguration> ServerSapAutoImportConfigurationEnabled;
        event ServiceEventHandler<SapAutoImportConfiguration> ServerSapAutoImportConfigurationUpdated;
        event ServiceEventHandler<SapAutoImportConfiguration> ServerSapAutoImportConfigurationDisabled;


        event ServiceEventHandler<Directive> ServerDirectiveCreated;
        event ServiceEventHandler<Directive> ServerDirectiveUpdated;
        event ServiceEventHandler<Directive> ServerDirectiveRemoved;
        event ServiceEventHandler<Directive> ServerDirectiveMarkedAsReadByCurrentUser;

        event ServiceEventHandler<OpmExcursion> ServerOpmExcursionCreated;
        event ServiceEventHandler<OpmExcursion> ServerOpmExcursionUpdated;
        event ServiceEventHandler<OpmExcursion> ServerOpmExcursionRemoved;

        event ServiceEventHandler<OpmToeDefinition> ServerOpmToeDefinitionCreated;
        event ServiceEventHandler<OpmToeDefinition> ServerOpmToeDefinitionUpdated;
        event ServiceEventHandler<OpmToeDefinition> ServerOpmToeDefinitionRemoved;

        event ServiceEventHandler<OpmExcursionImportStatusDTO> ServerOpmExcursionImportStatusUpdated;
        event ServiceEventHandler<Site> ServerOpmExcursionItemRefresh;

        event ServiceEventHandler<OpmExcursionBatch> ServerOpmExcursionBatchCreated;
        event ServiceEventHandler<OpmExcursionBatch> ServerOpmExcursionBatchUpdated;

        event ServiceEventHandler<WorkPermitFortHills> ServerWorkPermitFortHillsCreated;
        event ServiceEventHandler<WorkPermitFortHills> ServerWorkPermitFortHillsUpdated;
        event ServiceEventHandler<WorkPermitFortHills> ServerWorkPermitFortHillsRemoved;

        event ServiceEventHandler<PermitRequestFortHills> ServerPermitRequestFortHillsCreated;
        event ServiceEventHandler<PermitRequestFortHills> ServerPermitRequestFortHillsUpdated;
        event ServiceEventHandler<PermitRequestFortHills> ServerPermitRequestFortHillsRemoved;

        /// <summary>
        ///     Remove connection with remote
        /// </summary>
        void Disconnect(EventConnectDisconnectReason reason);

        /// <summary>
        ///     Establish connection with remote and passes in the list of functional location
        ///     to filter events of.  Pass in an empty list if you want All of the events (ie. like the scheduler)
        /// </summary>
        /// <param name="relevantFunctionalLocations"></param>
        /// <param name="relevantWorkPermitEdmontonFunctionalLocations"></param>
        /// <param name="rootFlocSetForRestrictions"></param>
        /// <param name="clientReadableVisibilityGroupIds"></param>
        /// <param name="reason"></param>
        void Connect(List<FunctionalLocation> relevantFunctionalLocations, List<FunctionalLocation> relevantWorkPermitEdmontonFunctionalLocations, List<FunctionalLocation> rootFlocSetForRestrictions, List<long> clientReadableVisibilityGroupIds, EventConnectDisconnectReason reason);

        void Notify(DomainEventArgs<DomainObject> e);

        void Dispatch(ApplicationEvent appEvent, DomainObject domain);

        void ReConnect(IEventService eventService, string clientServiceHostAddress,
            List<FunctionalLocation> filterFunctionalLocations,
            List<FunctionalLocation> workPermitEdmontonFunctionalLocations, List<FunctionalLocation> restrictionFunctionalLocations, List<long> clientReadableVisibilityGroupIds);


        event ServiceEventHandler<BaseFormOilsands> ServerFormOilsandsCreated;
        event ServiceEventHandler<BaseFormOilsands> ServerFormOilsandsUpdated;
        event ServiceEventHandler<BaseFormOilsands> ServerFormOilsandsRemoved;
        void UnsubscribeFromEvents(EventConnectDisconnectReason reason);
    }
}