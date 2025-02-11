﻿using System.Collections.Generic;
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
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common
{
    public class TestRemoteEventRepeater : IRemoteEventRepeater
    {
        public event ServiceEventHandler<TargetAlert> ServerTargetAlertCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<TargetAlert> ServerTargetAlertUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<ActionItemDefinition> ServerActionItemDefinitionCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<ActionItemDefinition> ServerActionItemDefinitionUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<ActionItemDefinition> ServerActionItemDefinitionRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<ActionItem> ServerActionItemUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<ActionItem> ServerActionItemCreated;

        public event ServiceEventHandler<ActionItem> ServerActionItemRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<Site> ServerActionItemRefresh
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<TargetDefinition> ServerTargetDefinitionCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<TargetDefinition> ServerTargetDefinitionUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<TargetDefinition> ServerTargetDefinitionRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<RestrictionDefinition> ServerRestrictionDefinitionCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<RestrictionDefinition> ServerRestrictionDefinitionUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<RestrictionDefinition> ServerRestrictionDefinitionRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<LabAlertDefinition> ServerLabAlertDefinitionCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<LabAlertDefinition> ServerLabAlertDefinitionUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<LabAlertDefinition> ServerLabAlertDefinitionRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<LabAlert> ServerLabAlertCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<LabAlert> ServerLabAlertUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<ShiftHandoverQuestionnaire> ServerShiftHandoverQuestionnaireCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<ShiftHandoverQuestionnaire> ServerShiftHandoverQuestionnaireUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<ShiftHandoverQuestionnaire> ServerShiftHandoverQuestionnaireRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<ShiftHandoverQuestionnaire>
            ServerShiftHandoverQuestionnaireMarkedAsReadByCurrentUser
            {
                add { }
                remove { }
            }

        public event ServiceEventHandler<Log> ServerLogCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<Log> ServerLogUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<Log> ServerLogRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<Log> ServerLogMarkedAsReadByCurrentUser
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<LogDefinition> ServerLogDefinitionCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<LogDefinition> ServerLogDefinitionRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<LogDefinition> ServerLogDefinitionUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<LogDefinition> ServerLogCancelledRecurringDefinition
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<SummaryLog> ServerSummaryLogCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<SummaryLog> ServerSummaryLogUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<SummaryLog> ServerSummaryLogRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<CokerCard> ServerCokerCardCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<CokerCard> ServerCokerCardUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<CokerCard> ServerCokerCardRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<WorkPermit> ServerWorkPermitCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<WorkPermit> ServerWorkPermitUpdated;

        public event ServiceEventHandler<WorkPermit> ServerWorkPermitRemoved
        {
            add { }
            remove { }
        }

        //RITM0301321
        public event ServiceEventHandler<WorkPermitMuds> ServerWorkPermitMudsCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<WorkPermitMuds> ServerWorkPermitMudsUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<WorkPermitMuds> ServerWorkPermitMudsRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<PermitRequestMuds> ServerPermitRequestMudsCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<PermitRequestMuds> ServerPermitRequestMudsUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<PermitRequestMuds> ServerPermitRequestMudsRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<WorkPermitMontreal> ServerWorkPermitMontrealCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<WorkPermitMontreal> ServerWorkPermitMontrealUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<WorkPermitMontreal> ServerWorkPermitMontrealRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<PermitRequestMontreal> ServerPermitRequestCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<PermitRequestMontreal> ServerPermitRequestUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<PermitRequestMontreal> ServerPermitRequestRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<ConfinedSpace> ServerConfinedSpaceCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<ConfinedSpace> ServerConfinedSpaceUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<ConfinedSpace> ServerConfinedSpaceRemoved
        {
            add { }
            remove { }
        }

        //RITM0301321 - mangesh
        public event ServiceEventHandler<ConfinedSpaceMuds> ServerConfinedSpaceMudsCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<ConfinedSpaceMuds> ServerConfinedSpaceMudsUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<ConfinedSpaceMuds> ServerConfinedSpaceMudsRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<SAPNotification> ServerSAPNotificationCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<SAPNotification> ServerSAPNotificationProcessed
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<SAPNotification> ServerSAPNotificationUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FunctionalLocation> ServerFunctionalLocationOperationalModeUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<DeviationAlert> ServerDeviationAlertCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<DeviationAlert> ServerDeviationAlertUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<WorkPermitEdmonton> ServerWorkPermitEdmontonCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<WorkPermitEdmonton> ServerWorkPermitEdmontonUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<WorkPermitEdmonton> ServerWorkPermitEdmontonRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<PermitRequestEdmonton> ServerPermitRequestEdmontonCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<PermitRequestEdmonton> ServerPermitRequestEdmontonUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<PermitRequestEdmonton> ServerPermitRequestEdmontonRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN7> ServerGN7FormCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN7> ServerGN7FormUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN7> ServerGN7FormRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN59> ServerGN59FormCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN59> ServerGN59FormUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN59> ServerGN59FormRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormOP14> ServerOP14FormCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormOP14> ServerOP14FormUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormOP14> ServerOP14FormRemoved
        {
            add { }
            remove { }
        }

        //generic template - mangesh
        public event ServiceEventHandler<FormGenericTemplate> ServerGenericTemplateFormCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGenericTemplate> ServerGenericTemplateFormUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGenericTemplate> ServerGenericTemplateFormRemoved
        {
            add { }
            remove { }
        }

        //DMND0011225 OLT - CSD for WBR

        public event ServiceEventHandler<GenericCsd> ServerGenericCsdFormCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<GenericCsd> ServerGenericCsdFormUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<GenericCsd> ServerGenericCsdFormRemoved
        {
            add { }
            remove { }
        }

        //--
        public event ServiceEventHandler<MontrealCsd> ServerMontrealCsdFormCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<MontrealCsd> ServerMontrealCsdFormUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<MontrealCsd> ServerMontrealCsdFormRemoved
        {
            add { }
            remove { }
        }

   //RITM0268131 - mangesh
        public event ServiceEventHandler<TemporaryInstallationsMUDS> ServerMudsTemporaryInstallationsFormCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<TemporaryInstallationsMUDS> ServerMudsTemporaryInstallationsFormUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<TemporaryInstallationsMUDS> ServerMudsTemporaryInstallationsFormRemoved
        {
            add { }
            remove { }
        }
        //----
        public event ServiceEventHandler<LubesCsdForm> ServerLubesCsdFormCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<LubesCsdForm> ServerLubesCsdFormUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<LubesCsdForm> ServerLubesCsdFormRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<LubesAlarmDisableForm> ServerLubesAlarmDisableFormCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<LubesAlarmDisableForm> ServerLubesAlarmDisableFormUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<LubesAlarmDisableForm> ServerLubesAlarmDisableFormRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN24> ServerGN24FormCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN24> ServerGN24FormUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN24> ServerGN24FormRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN6> ServerGN6FormCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN6> ServerGN6FormUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN6> ServerGN6FormRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN75A> ServerGN75AFormCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN75A> ServerGN75AFormUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN75A> ServerGN75AFormRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN75B> ServerGN75BFormCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN75B> ServerGN75BFormUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN75B> ServerGN75BFormRemoved
        {
            add { }
            remove { }
        }


        //ayman Sarnia eip DMND0008992
        public event ServiceEventHandler<FormGN75B> ServerGN75BTemplateFormCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN75B> ServerGN75BTemplateFormUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN75B> ServerGN75BTemplateFormRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN1> ServerGN1FormCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN1> ServerGN1FormUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormGN1> ServerGN1FormRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<PermitAssessment> ServerOilsandsPermitAssessmentFormCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<PermitAssessment> ServerOilsandsPermitAssessmentFormUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<PermitAssessment> ServerOilsandsPermitAssessmentFormRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<DocumentSuggestion> ServerDocumentSuggestionFormCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<DocumentSuggestion> ServerDocumentSuggestionFormUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<DocumentSuggestion> ServerDocumentSuggestionFormRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<ProcedureDeviation> ServerProcedureDeviationFormCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<ProcedureDeviation> ServerProcedureDeviationFormUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<ProcedureDeviation> ServerProcedureDeviationFormRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<OvertimeForm> ServerOvertimeFormCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<OvertimeForm> ServerOvertimeFormUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<OvertimeForm> ServerOvertimeFormRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<OnPremisePersonnel> ServerOnPremisePersonnelCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<OnPremisePersonnel> ServerOnPremisePersonnelUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<OnPremisePersonnel> ServerOnPremisePersonnelRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<ShiftHandoverEmailConfiguration> ServerShiftHandoverEmailConfigurationCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<ShiftHandoverEmailConfiguration> ServerShiftHandoverEmailConfigurationUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<ShiftHandoverEmailConfiguration> ServerShiftHandoverEmailConfigurationRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<WorkPermitLubes> ServerWorkPermitLubesCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<WorkPermitLubes> ServerWorkPermitLubesUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<WorkPermitLubes> ServerWorkPermitLubesRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<PermitRequestLubes> ServerPermitRequestLubesCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<PermitRequestLubes> ServerPermitRequestLubesUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<PermitRequestLubes> ServerPermitRequestLubesRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormOilsandsTraining> ServerFormOilsandsTrainingCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormOilsandsTraining> ServerFormOilsandsTrainingUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<FormOilsandsTraining> ServerFormOilsandsTrainingRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<BaseFormOilsands> ServerFormOilsandsCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<BaseFormOilsands> ServerFormOilsandsUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<BaseFormOilsands> ServerFormOilsandsRemoved
        {
            add { }
            remove { }
        }

        public void UnsubscribeFromEvents(EventConnectDisconnectReason reason)
        {
        }

        public event ServiceEventHandler<SapAutoImportConfiguration> ServerSapAutoImportConfigurationEnabled
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<SapAutoImportConfiguration> ServerSapAutoImportConfigurationUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<SapAutoImportConfiguration> ServerSapAutoImportConfigurationDisabled
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<Directive> ServerDirectiveCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<Directive> ServerDirectiveUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<Directive> ServerDirectiveRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<Directive> ServerDirectiveMarkedAsReadByCurrentUser
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<OpmExcursion> ServerOpmExcursionCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<OpmExcursion> ServerOpmExcursionUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<OpmExcursion> ServerOpmExcursionRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<OpmToeDefinition> ServerOpmToeDefinitionCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<OpmToeDefinition> ServerOpmToeDefinitionUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<OpmToeDefinition> ServerOpmToeDefinitionRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<OpmExcursionImportStatusDTO> ServerOpmExcursionImportStatusUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<Site> ServerOpmExcursionItemRefresh
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<OpmExcursionBatch> ServerOpmExcursionBatchCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<OpmExcursionBatch> ServerOpmExcursionBatchUpdated
        {
            add { }
            remove { }
        }

        public void Disconnect(EventConnectDisconnectReason reason)
        {
        }

        public void Connect(List<FunctionalLocation> relevantFunctionalLocations, List<FunctionalLocation> workPermitEdmontonFunctionalLocations, List<FunctionalLocation> rootFlocSetForRestrictions, List<long> clientReadableVisibilityGroupIds, EventConnectDisconnectReason reason)
        {
        }

        public void Notify(DomainEventArgs<DomainObject> e)
        {
        }

        public void Dispatch(ApplicationEvent appEvent, DomainObject domain)
        {
        }

        public void ReConnect(IEventService eventService, string clientServiceHostAddress,
            List<FunctionalLocation> filterFunctionalLocations,
            List<FunctionalLocation> workPermitEdmontonFunctionalLocations, List<FunctionalLocation> restrictionFunctionalLocations, List<long> clientReadableVisibilityGroupIds)
        {
        }

        public event ServiceEventHandler<BaseEdmontonForm> ServerFormCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<BaseEdmontonForm> ServerFormUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<BaseEdmontonForm> ServerFormRemoved
        {
            add { }
            remove { }
        }

        public void FireWorkPermitUpdatedEvent(WorkPermit workPermit)
        {
            ServerWorkPermitUpdated(this, new DomainEventArgs<WorkPermit>(workPermit));
        }

        public void FireActionItemCreateEvent(ActionItem actionItem)
        {
            ServerActionItemCreated(this, new DomainEventArgs<ActionItem>(actionItem));
        }

        public event ServiceEventHandler<WorkPermitFortHills> ServerWorkPermitFortHillsCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<WorkPermitFortHills> ServerWorkPermitFortHillsUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<WorkPermitFortHills> ServerWorkPermitFortHillsRemoved
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<PermitRequestFortHills> ServerPermitRequestFortHillsCreated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<PermitRequestFortHills> ServerPermitRequestFortHillsUpdated
        {
            add { }
            remove { }
        }

        public event ServiceEventHandler<PermitRequestFortHills> ServerPermitRequestFortHillsRemoved
        {
            add { }
            remove { }
        }



        public event ServiceEventHandler<BaseEdmontonForm> ServerCSDMarkedAsReadByCurrentUser;


        public event ServiceEventHandler<WorkPermit> ServerWorkPermitCreated_Template;


        public event ServiceEventHandler<WorkPermitMuds> ServerWorkPermitMudsTemplateCreated;


        public event ServiceEventHandler<PermitRequestMuds> ServerPermitRequestMudsTemplateCreated;
    }
}