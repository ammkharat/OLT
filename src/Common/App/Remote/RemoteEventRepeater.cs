using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
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
using log4net;

namespace Com.Suncor.Olt.Common.Remote
{
    public delegate void ServiceEventHandler<T>(object sender, DomainEventArgs<T> e) where T : DomainObject;

    /// <summary>
    ///     Client side event repeater of service side events. Client side classes should hook into events here
    /// </summary>
    public class RemoteEventRepeater : IRemoteEventRepeater
    {
        private const int TIMER_PERIOD_IN_MS = 5000;
        private static readonly ILog logger = GenericLogManager.GetLogger<RemoteEventRepeater>();
        private readonly string machineName;
        private readonly RemoteEventQueue remoteEventQueue;
        private readonly Timer timer;
        private readonly object timerLockObject = new object();
        private string clientServiceHostAddress;
        private bool connected;
        private IEventService eventService;

        /// <summary>
        ///     Creating an instance of remote repeater by getting the services and hooking up services to this class
        /// </summary>
        public RemoteEventRepeater(IEventService eventService, string clientServiceHostAddress) : this(
            eventService, clientServiceHostAddress, 0)
        {
        }

        public RemoteEventRepeater(IEventService eventService, string clientServiceHostAddress, int timerDueTime)
        {
            this.eventService = eventService;
            this.clientServiceHostAddress = clientServiceHostAddress;

            remoteEventQueue = new RemoteEventQueue();
            timer = new Timer(TimerFiredCallback, null, timerDueTime, TIMER_PERIOD_IN_MS);

            machineName = OltEnvironment.MachineName;
        }

        public event ServiceEventHandler<TargetAlert> ServerTargetAlertCreated;
        public event ServiceEventHandler<TargetAlert> ServerTargetAlertUpdated;

        public event ServiceEventHandler<Log> ServerLogCreated;
        public event ServiceEventHandler<Log> ServerLogUpdated;
        public event ServiceEventHandler<Log> ServerLogRemoved;
        public event ServiceEventHandler<Log> ServerLogMarkedAsReadByCurrentUser;

        public event ServiceEventHandler<SummaryLog> ServerSummaryLogCreated;
        public event ServiceEventHandler<SummaryLog> ServerSummaryLogUpdated;
        public event ServiceEventHandler<SummaryLog> ServerSummaryLogRemoved;

        public event ServiceEventHandler<CokerCard> ServerCokerCardCreated;
        public event ServiceEventHandler<CokerCard> ServerCokerCardUpdated;
        public event ServiceEventHandler<CokerCard> ServerCokerCardRemoved;

        public event ServiceEventHandler<LogDefinition> ServerLogDefinitionCreated;
        public event ServiceEventHandler<LogDefinition> ServerLogDefinitionRemoved;
        public event ServiceEventHandler<LogDefinition> ServerLogDefinitionUpdated;
        public event ServiceEventHandler<LogDefinition> ServerLogCancelledRecurringDefinition;

        public event ServiceEventHandler<ActionItemDefinition> ServerActionItemDefinitionCreated;
        public event ServiceEventHandler<ActionItemDefinition> ServerActionItemDefinitionUpdated;
        public event ServiceEventHandler<ActionItemDefinition> ServerActionItemDefinitionRemoved;

        public event ServiceEventHandler<ActionItem> ServerActionItemUpdated;
        public event ServiceEventHandler<ActionItem> ServerActionItemCreated;
        public event ServiceEventHandler<ActionItem> ServerActionItemRemoved;
        public event ServiceEventHandler<Site> ServerActionItemRefresh;

        public event ServiceEventHandler<TargetDefinition> ServerTargetDefinitionCreated;
        public event ServiceEventHandler<TargetDefinition> ServerTargetDefinitionUpdated;
        public event ServiceEventHandler<TargetDefinition> ServerTargetDefinitionRemoved;

        public event ServiceEventHandler<RestrictionDefinition> ServerRestrictionDefinitionCreated;
        public event ServiceEventHandler<RestrictionDefinition> ServerRestrictionDefinitionUpdated;
        public event ServiceEventHandler<RestrictionDefinition> ServerRestrictionDefinitionRemoved;

        public event ServiceEventHandler<LabAlertDefinition> ServerLabAlertDefinitionCreated;
        public event ServiceEventHandler<LabAlertDefinition> ServerLabAlertDefinitionUpdated;
        public event ServiceEventHandler<LabAlertDefinition> ServerLabAlertDefinitionRemoved;

        public event ServiceEventHandler<LabAlert> ServerLabAlertCreated;
        public event ServiceEventHandler<LabAlert> ServerLabAlertUpdated;

        public event ServiceEventHandler<ShiftHandoverQuestionnaire> ServerShiftHandoverQuestionnaireCreated;
        public event ServiceEventHandler<ShiftHandoverQuestionnaire> ServerShiftHandoverQuestionnaireUpdated;
        public event ServiceEventHandler<ShiftHandoverQuestionnaire> ServerShiftHandoverQuestionnaireRemoved;

        public event ServiceEventHandler<ShiftHandoverQuestionnaire>
            ServerShiftHandoverQuestionnaireMarkedAsReadByCurrentUser;

        public event ServiceEventHandler<WorkPermit> ServerWorkPermitCreated;
        public event ServiceEventHandler<WorkPermit> ServerWorkPermitCreated_Template;
        
        public event ServiceEventHandler<WorkPermit> ServerWorkPermitUpdated;
        public event ServiceEventHandler<WorkPermit> ServerWorkPermitRemoved;

        public event ServiceEventHandler<SAPNotification> ServerSAPNotificationCreated;
        public event ServiceEventHandler<SAPNotification> ServerSAPNotificationUpdated;
        public event ServiceEventHandler<SAPNotification> ServerSAPNotificationProcessed;

        public event ServiceEventHandler<DeviationAlert> ServerDeviationAlertCreated;
        public event ServiceEventHandler<DeviationAlert> ServerDeviationAlertUpdated;

        public event ServiceEventHandler<WorkPermitMontreal> ServerWorkPermitMontrealCreated;
        public event ServiceEventHandler<WorkPermitMontreal> ServerWorkPermitMontrealUpdated;
        public event ServiceEventHandler<WorkPermitMontreal> ServerWorkPermitMontrealRemoved;

        public event ServiceEventHandler<PermitRequestMontreal> ServerPermitRequestCreated;
        public event ServiceEventHandler<PermitRequestMontreal> ServerPermitRequestUpdated;
        public event ServiceEventHandler<PermitRequestMontreal> ServerPermitRequestRemoved;

        public event ServiceEventHandler<ConfinedSpace> ServerConfinedSpaceCreated;
        public event ServiceEventHandler<ConfinedSpace> ServerConfinedSpaceUpdated;
        public event ServiceEventHandler<ConfinedSpace> ServerConfinedSpaceRemoved;

        //RITM0301321 - mangesh
        public event ServiceEventHandler<ConfinedSpaceMuds> ServerConfinedSpaceMudsCreated;
        public event ServiceEventHandler<ConfinedSpaceMuds> ServerConfinedSpaceMudsUpdated;
        public event ServiceEventHandler<ConfinedSpaceMuds> ServerConfinedSpaceMudsRemoved;
        
        public event ServiceEventHandler<FunctionalLocation> ServerFunctionalLocationOperationalModeUpdated;

        public event ServiceEventHandler<WorkPermitEdmonton> ServerWorkPermitEdmontonCreated;
        public event ServiceEventHandler<WorkPermitEdmonton> ServerWorkPermitEdmontonUpdated;
        public event ServiceEventHandler<WorkPermitEdmonton> ServerWorkPermitEdmontonRemoved;

        public event ServiceEventHandler<PermitRequestEdmonton> ServerPermitRequestEdmontonCreated;
        public event ServiceEventHandler<PermitRequestEdmonton> ServerPermitRequestEdmontonUpdated;
        public event ServiceEventHandler<PermitRequestEdmonton> ServerPermitRequestEdmontonRemoved;

        public event ServiceEventHandler<FormGN7> ServerGN7FormCreated;
        public event ServiceEventHandler<FormGN7> ServerGN7FormUpdated;
        public event ServiceEventHandler<FormGN7> ServerGN7FormRemoved;

        public event ServiceEventHandler<FormGN59> ServerGN59FormCreated;
        public event ServiceEventHandler<FormGN59> ServerGN59FormUpdated;
        public event ServiceEventHandler<FormGN59> ServerGN59FormRemoved;

        public event ServiceEventHandler<FormOP14> ServerOP14FormCreated;
        public event ServiceEventHandler<FormOP14> ServerOP14FormUpdated;
        public event ServiceEventHandler<FormOP14> ServerOP14FormRemoved;

        //generic template - mangesh
        public event ServiceEventHandler<FormGenericTemplate> ServerGenericTemplateFormCreated;
        public event ServiceEventHandler<FormGenericTemplate> ServerGenericTemplateFormUpdated;
        public event ServiceEventHandler<FormGenericTemplate> ServerGenericTemplateFormRemoved;

        public event ServiceEventHandler<MontrealCsd> ServerMontrealCsdFormCreated;
        public event ServiceEventHandler<MontrealCsd> ServerMontrealCsdFormUpdated;
        public event ServiceEventHandler<MontrealCsd> ServerMontrealCsdFormRemoved;

        //DMND0011225 CSD for WBR
        public event ServiceEventHandler<GenericCsd> ServerGenericCsdFormCreated;
        public event ServiceEventHandler<GenericCsd> ServerGenericCsdFormUpdated;
        public event ServiceEventHandler<GenericCsd> ServerGenericCsdFormRemoved;

        //RITM0268131 - mangesh
        public event ServiceEventHandler<TemporaryInstallationsMUDS> ServerMudsTemporaryInstallationsFormCreated;
        public event ServiceEventHandler<TemporaryInstallationsMUDS> ServerMudsTemporaryInstallationsFormUpdated;
        public event ServiceEventHandler<TemporaryInstallationsMUDS> ServerMudsTemporaryInstallationsFormRemoved;

        //RITM0301321 - mangesh
        public event ServiceEventHandler<WorkPermitMuds> ServerWorkPermitMudsCreated;
        public event ServiceEventHandler<WorkPermitMuds> ServerWorkPermitMudsTemplateCreated;
        
        public event ServiceEventHandler<WorkPermitMuds> ServerWorkPermitMudsUpdated;
        public event ServiceEventHandler<WorkPermitMuds> ServerWorkPermitMudsRemoved;

        public event ServiceEventHandler<PermitRequestMuds> ServerPermitRequestMudsCreated;
        public event ServiceEventHandler<PermitRequestMuds> ServerPermitRequestMudsTemplateCreated;
        
        public event ServiceEventHandler<PermitRequestMuds> ServerPermitRequestMudsUpdated;
        public event ServiceEventHandler<PermitRequestMuds> ServerPermitRequestMudsRemoved;

      
        public event ServiceEventHandler<LubesCsdForm> ServerLubesCsdFormCreated;
        public event ServiceEventHandler<LubesCsdForm> ServerLubesCsdFormUpdated;
        public event ServiceEventHandler<LubesCsdForm> ServerLubesCsdFormRemoved;

        public event ServiceEventHandler<LubesAlarmDisableForm> ServerLubesAlarmDisableFormCreated;
        public event ServiceEventHandler<LubesAlarmDisableForm> ServerLubesAlarmDisableFormUpdated;
        public event ServiceEventHandler<LubesAlarmDisableForm> ServerLubesAlarmDisableFormRemoved;

        public event ServiceEventHandler<FormGN24> ServerGN24FormCreated;
        public event ServiceEventHandler<FormGN24> ServerGN24FormUpdated;
        public event ServiceEventHandler<FormGN24> ServerGN24FormRemoved;

        public event ServiceEventHandler<FormGN6> ServerGN6FormCreated;
        public event ServiceEventHandler<FormGN6> ServerGN6FormUpdated;
        public event ServiceEventHandler<FormGN6> ServerGN6FormRemoved;

        public event ServiceEventHandler<FormGN75A> ServerGN75AFormCreated;
        public event ServiceEventHandler<FormGN75A> ServerGN75AFormUpdated;
        public event ServiceEventHandler<FormGN75A> ServerGN75AFormRemoved;

        public event ServiceEventHandler<FormGN75B> ServerGN75BFormCreated;
        public event ServiceEventHandler<FormGN75B> ServerGN75BFormUpdated;
        public event ServiceEventHandler<FormGN75B> ServerGN75BFormRemoved;

        //ayman Sarnia eip DMND0008992
        public event ServiceEventHandler<FormGN75B> ServerGN75BTemplateFormCreated;
        public event ServiceEventHandler<FormGN75B> ServerGN75BTemplateFormUpdated;
        public event ServiceEventHandler<FormGN75B> ServerGN75BTemplateFormRemoved;


        public event ServiceEventHandler<FormGN1> ServerGN1FormCreated;
        public event ServiceEventHandler<FormGN1> ServerGN1FormUpdated;
        public event ServiceEventHandler<FormGN1> ServerGN1FormRemoved;

        public event ServiceEventHandler<PermitAssessment> ServerOilsandsPermitAssessmentFormCreated;
        public event ServiceEventHandler<PermitAssessment> ServerOilsandsPermitAssessmentFormUpdated;
        public event ServiceEventHandler<PermitAssessment> ServerOilsandsPermitAssessmentFormRemoved;

        public event ServiceEventHandler<DocumentSuggestion> ServerDocumentSuggestionFormCreated;
        public event ServiceEventHandler<DocumentSuggestion> ServerDocumentSuggestionFormUpdated;
        public event ServiceEventHandler<DocumentSuggestion> ServerDocumentSuggestionFormRemoved;

        public event ServiceEventHandler<ProcedureDeviation> ServerProcedureDeviationFormCreated;
        public event ServiceEventHandler<ProcedureDeviation> ServerProcedureDeviationFormUpdated;
        public event ServiceEventHandler<ProcedureDeviation> ServerProcedureDeviationFormRemoved;

        public event ServiceEventHandler<OvertimeForm> ServerOvertimeFormCreated;
        public event ServiceEventHandler<OvertimeForm> ServerOvertimeFormUpdated;
        public event ServiceEventHandler<OvertimeForm> ServerOvertimeFormRemoved;

        public event ServiceEventHandler<OnPremisePersonnel> ServerOnPremisePersonnelCreated;
        public event ServiceEventHandler<OnPremisePersonnel> ServerOnPremisePersonnelUpdated;
        public event ServiceEventHandler<OnPremisePersonnel> ServerOnPremisePersonnelRemoved;

        public event ServiceEventHandler<ShiftHandoverEmailConfiguration> ServerShiftHandoverEmailConfigurationCreated;
        public event ServiceEventHandler<ShiftHandoverEmailConfiguration> ServerShiftHandoverEmailConfigurationUpdated;
        public event ServiceEventHandler<ShiftHandoverEmailConfiguration> ServerShiftHandoverEmailConfigurationRemoved;

        public event ServiceEventHandler<WorkPermitLubes> ServerWorkPermitLubesCreated;
        public event ServiceEventHandler<WorkPermitLubes> ServerWorkPermitLubesUpdated;
        public event ServiceEventHandler<WorkPermitLubes> ServerWorkPermitLubesRemoved;

        public event ServiceEventHandler<PermitRequestLubes> ServerPermitRequestLubesCreated;
        public event ServiceEventHandler<PermitRequestLubes> ServerPermitRequestLubesUpdated;
        public event ServiceEventHandler<PermitRequestLubes> ServerPermitRequestLubesRemoved;

        public event ServiceEventHandler<BaseFormOilsands> ServerFormOilsandsCreated;
        public event ServiceEventHandler<BaseFormOilsands> ServerFormOilsandsUpdated;
        public event ServiceEventHandler<BaseFormOilsands> ServerFormOilsandsRemoved;

        public event ServiceEventHandler<FormOilsandsTraining> ServerFormOilsandsTrainingCreated;
        public event ServiceEventHandler<FormOilsandsTraining> ServerFormOilsandsTrainingUpdated;
        public event ServiceEventHandler<FormOilsandsTraining> ServerFormOilsandsTrainingRemoved;

        public event ServiceEventHandler<SapAutoImportConfiguration> ServerSapAutoImportConfigurationEnabled;
        public event ServiceEventHandler<SapAutoImportConfiguration> ServerSapAutoImportConfigurationUpdated;
        public event ServiceEventHandler<SapAutoImportConfiguration> ServerSapAutoImportConfigurationDisabled;

        public event ServiceEventHandler<Directive> ServerDirectiveCreated;
        public event ServiceEventHandler<Directive> ServerDirectiveUpdated;
        public event ServiceEventHandler<Directive> ServerDirectiveRemoved;
        public event ServiceEventHandler<Directive> ServerDirectiveMarkedAsReadByCurrentUser;

        public event ServiceEventHandler<OpmExcursion> ServerOpmExcursionCreated;
        public event ServiceEventHandler<OpmExcursion> ServerOpmExcursionUpdated;
        public event ServiceEventHandler<OpmExcursion> ServerOpmExcursionRemoved;

        public event ServiceEventHandler<OpmToeDefinition> ServerOpmToeDefinitionCreated;
        public event ServiceEventHandler<OpmToeDefinition> ServerOpmToeDefinitionUpdated;
        public event ServiceEventHandler<OpmToeDefinition> ServerOpmToeDefinitionRemoved;

        public event ServiceEventHandler<OpmExcursionImportStatusDTO> ServerOpmExcursionImportStatusUpdated;
        public event ServiceEventHandler<Site> ServerOpmExcursionItemRefresh;

        public event ServiceEventHandler<OpmExcursionBatch> ServerOpmExcursionBatchCreated;
        public event ServiceEventHandler<OpmExcursionBatch> ServerOpmExcursionBatchUpdated;

        public event ServiceEventHandler<WorkPermitFortHills> ServerWorkPermitFortHillsCreated;
        public event ServiceEventHandler<WorkPermitFortHills> ServerWorkPermitFortHillsUpdated;
        public event ServiceEventHandler<WorkPermitFortHills> ServerWorkPermitFortHillsRemoved;

        public event ServiceEventHandler<PermitRequestFortHills> ServerPermitRequestFortHillsCreated;
        public event ServiceEventHandler<PermitRequestFortHills> ServerPermitRequestFortHillsUpdated;
        public event ServiceEventHandler<PermitRequestFortHills> ServerPermitRequestFortHillsRemoved;

        public void UnsubscribeFromEvents(EventConnectDisconnectReason reason)
        {
            connected = false;
            remoteEventQueue.Clear();

            logger.Info("Clearing service event hooks for remote event repeater methods.");
            eventService.Unsubscribe(clientServiceHostAddress, reason);
            logger.Info("Finished clearing service event hooks for remote event repeater methods.");
        }

        public void ReConnect(IEventService eventService, string clientServiceHostAddress,
            List<FunctionalLocation> filterFunctionalLocations,
            List<FunctionalLocation> workPermitEdmontonFunctionalLocations,List<FunctionalLocation> restrictionFunctionalLocations, List<long> clientReadableVisibilityGroupIds)
        {
            this.eventService = eventService;
            this.clientServiceHostAddress = clientServiceHostAddress;

            if (connected)
            {
                UnsubscribeFromEvents(EventConnectDisconnectReason.ReconnectOnNetworkAvailabilityChange);
            }

            SubscribeToEvents(filterFunctionalLocations, workPermitEdmontonFunctionalLocations, restrictionFunctionalLocations,
                clientReadableVisibilityGroupIds, EventConnectDisconnectReason.ReconnectOnNetworkAvailabilityChange);
        }

        public void Connect(List<FunctionalLocation> filterFunctionalLocations, List<FunctionalLocation> workPermitEdmontonFunctionalLocations, List<FunctionalLocation> rootFlocSetForRestrictions, List<long> clientReadableVisibilityGroupIds, EventConnectDisconnectReason reason)
        {
            Disconnect(reason);

            SubscribeToEvents(filterFunctionalLocations, workPermitEdmontonFunctionalLocations,rootFlocSetForRestrictions,
                clientReadableVisibilityGroupIds, reason);
        }

        public void Disconnect(EventConnectDisconnectReason reason)
        {
            if (connected)
            {
                UnsubscribeFromEvents(reason);

                ServerTargetAlertCreated =
                    (ServiceEventHandler<TargetAlert>)
                        Delegate.RemoveAll(ServerTargetAlertCreated, ServerTargetAlertCreated);
                ServerTargetAlertUpdated =
                    (ServiceEventHandler<TargetAlert>)
                        Delegate.RemoveAll(ServerTargetAlertUpdated, ServerTargetAlertUpdated);

                ServerLogCreated = (ServiceEventHandler<Log>) Delegate.RemoveAll(ServerLogCreated, ServerLogCreated);
                ServerLogUpdated = (ServiceEventHandler<Log>) Delegate.RemoveAll(ServerLogUpdated, ServerLogUpdated);
                ServerLogRemoved = (ServiceEventHandler<Log>) Delegate.RemoveAll(ServerLogRemoved, ServerLogRemoved);

                ServerLogMarkedAsReadByCurrentUser =
                    (ServiceEventHandler<Log>)
                        Delegate.RemoveAll(ServerLogMarkedAsReadByCurrentUser, ServerLogMarkedAsReadByCurrentUser);

                ServerSummaryLogCreated =
                    (ServiceEventHandler<SummaryLog>)
                        Delegate.RemoveAll(ServerSummaryLogCreated, ServerSummaryLogCreated);
                ServerSummaryLogUpdated = (
                    ServiceEventHandler<SummaryLog>)
                    Delegate.RemoveAll(ServerSummaryLogUpdated, ServerSummaryLogUpdated);
                ServerSummaryLogRemoved =
                    (ServiceEventHandler<SummaryLog>)
                        Delegate.RemoveAll(ServerSummaryLogRemoved, ServerSummaryLogRemoved);

                ServerShiftHandoverQuestionnaireCreated =
                    (ServiceEventHandler<ShiftHandoverQuestionnaire>)
                        Delegate.RemoveAll(ServerShiftHandoverQuestionnaireCreated,
                            ServerShiftHandoverQuestionnaireCreated);
                ServerShiftHandoverQuestionnaireUpdated =
                    (ServiceEventHandler<ShiftHandoverQuestionnaire>)
                        Delegate.RemoveAll(ServerShiftHandoverQuestionnaireUpdated,
                            ServerShiftHandoverQuestionnaireUpdated);
                ServerShiftHandoverQuestionnaireRemoved =
                    (ServiceEventHandler<ShiftHandoverQuestionnaire>)
                        Delegate.RemoveAll(ServerShiftHandoverQuestionnaireRemoved,
                            ServerShiftHandoverQuestionnaireRemoved);
                ServerShiftHandoverQuestionnaireMarkedAsReadByCurrentUser =
                    (ServiceEventHandler<ShiftHandoverQuestionnaire>)
                        Delegate.RemoveAll(ServerShiftHandoverQuestionnaireMarkedAsReadByCurrentUser,
                            ServerShiftHandoverQuestionnaireMarkedAsReadByCurrentUser);

                ServerCokerCardCreated =
                    (ServiceEventHandler<CokerCard>) Delegate.RemoveAll(ServerCokerCardCreated, ServerCokerCardCreated);
                ServerCokerCardUpdated =
                    (ServiceEventHandler<CokerCard>) Delegate.RemoveAll(ServerCokerCardUpdated, ServerCokerCardUpdated);
                ServerCokerCardRemoved =
                    (ServiceEventHandler<CokerCard>) Delegate.RemoveAll(ServerCokerCardRemoved, ServerCokerCardRemoved);

                ServerLogDefinitionCreated =
                    (ServiceEventHandler<LogDefinition>)
                        Delegate.RemoveAll(ServerLogDefinitionCreated, ServerLogDefinitionCreated);
                ServerLogDefinitionRemoved =
                    (ServiceEventHandler<LogDefinition>)
                        Delegate.RemoveAll(ServerLogDefinitionRemoved, ServerLogDefinitionRemoved);
                ServerLogDefinitionUpdated =
                    (ServiceEventHandler<LogDefinition>)
                        Delegate.RemoveAll(ServerLogDefinitionUpdated, ServerLogDefinitionUpdated);
                ServerLogCancelledRecurringDefinition =
                    (ServiceEventHandler<LogDefinition>)
                        Delegate.RemoveAll(ServerLogCancelledRecurringDefinition, ServerLogCancelledRecurringDefinition);

                ServerActionItemDefinitionCreated =
                    (ServiceEventHandler<ActionItemDefinition>)
                        Delegate.RemoveAll(ServerActionItemDefinitionCreated, ServerActionItemDefinitionCreated);
                ServerActionItemDefinitionUpdated =
                    (ServiceEventHandler<ActionItemDefinition>)
                        Delegate.RemoveAll(ServerActionItemDefinitionUpdated, ServerActionItemDefinitionUpdated);
                ServerActionItemDefinitionRemoved =
                    (ServiceEventHandler<ActionItemDefinition>)
                        Delegate.RemoveAll(ServerActionItemDefinitionRemoved, ServerActionItemDefinitionRemoved);

                ServerActionItemUpdated =
                    (ServiceEventHandler<ActionItem>)
                        Delegate.RemoveAll(ServerActionItemUpdated, ServerActionItemUpdated);
                ServerActionItemCreated =
                    (ServiceEventHandler<ActionItem>)
                        Delegate.RemoveAll(ServerActionItemCreated, ServerActionItemCreated);
                ServerActionItemRemoved =
                    (ServiceEventHandler<ActionItem>)
                        Delegate.RemoveAll(ServerActionItemRemoved, ServerActionItemRemoved);
                ServerActionItemRefresh =
                    (ServiceEventHandler<Site>)
                        Delegate.RemoveAll(ServerActionItemRefresh, ServerActionItemRefresh);

                ServerTargetDefinitionCreated =
                    (ServiceEventHandler<TargetDefinition>)
                        Delegate.RemoveAll(ServerTargetDefinitionCreated, ServerTargetDefinitionCreated);
                ServerTargetDefinitionUpdated =
                    (ServiceEventHandler<TargetDefinition>)
                        Delegate.RemoveAll(ServerTargetDefinitionUpdated, ServerTargetDefinitionUpdated);
                ServerTargetDefinitionRemoved =
                    (ServiceEventHandler<TargetDefinition>)
                        Delegate.RemoveAll(ServerTargetDefinitionRemoved, ServerTargetDefinitionRemoved);

                ServerRestrictionDefinitionCreated =
                    (ServiceEventHandler<RestrictionDefinition>)
                        Delegate.RemoveAll(ServerRestrictionDefinitionCreated, ServerRestrictionDefinitionCreated);
                ServerRestrictionDefinitionUpdated =
                    (ServiceEventHandler<RestrictionDefinition>)
                        Delegate.RemoveAll(ServerRestrictionDefinitionUpdated, ServerRestrictionDefinitionUpdated);
                ServerRestrictionDefinitionRemoved =
                    (ServiceEventHandler<RestrictionDefinition>)
                        Delegate.RemoveAll(ServerRestrictionDefinitionRemoved, ServerRestrictionDefinitionRemoved);

                ServerLabAlertDefinitionCreated =
                    (ServiceEventHandler<LabAlertDefinition>)
                        Delegate.RemoveAll(ServerLabAlertDefinitionCreated, ServerLabAlertDefinitionCreated);
                ServerLabAlertDefinitionUpdated =
                    (ServiceEventHandler<LabAlertDefinition>)
                        Delegate.RemoveAll(ServerLabAlertDefinitionUpdated, ServerLabAlertDefinitionUpdated);
                ServerLabAlertDefinitionRemoved =
                    (ServiceEventHandler<LabAlertDefinition>)
                        Delegate.RemoveAll(ServerLabAlertDefinitionRemoved, ServerLabAlertDefinitionRemoved);

                ServerLabAlertCreated =
                    (ServiceEventHandler<LabAlert>)
                        Delegate.RemoveAll(ServerLabAlertCreated, ServerLabAlertCreated);
                ServerLabAlertUpdated =
                    (ServiceEventHandler<LabAlert>)
                        Delegate.RemoveAll(ServerLabAlertUpdated, ServerLabAlertUpdated);

                ServerWorkPermitCreated =
                    (ServiceEventHandler<WorkPermit>)
                        Delegate.RemoveAll(ServerWorkPermitCreated, ServerWorkPermitCreated);

                ServerWorkPermitCreated_Template =
                    (ServiceEventHandler<WorkPermit>)
                        Delegate.RemoveAll(ServerWorkPermitCreated_Template, ServerWorkPermitCreated_Template);

                
                ServerWorkPermitUpdated =
                    (ServiceEventHandler<WorkPermit>)
                        Delegate.RemoveAll(ServerWorkPermitUpdated, ServerWorkPermitUpdated);
                ServerWorkPermitRemoved =
                    (ServiceEventHandler<WorkPermit>)
                        Delegate.RemoveAll(ServerWorkPermitRemoved, ServerWorkPermitRemoved);

                ServerSAPNotificationCreated =
                    (ServiceEventHandler<SAPNotification>)
                        Delegate.RemoveAll(ServerSAPNotificationCreated, ServerSAPNotificationCreated);
                ServerSAPNotificationUpdated =
                    (ServiceEventHandler<SAPNotification>)
                        Delegate.RemoveAll(ServerSAPNotificationUpdated, ServerSAPNotificationUpdated);
                ServerSAPNotificationProcessed =
                    (ServiceEventHandler<SAPNotification>)
                        Delegate.RemoveAll(ServerSAPNotificationProcessed, ServerSAPNotificationProcessed);

                ServerDeviationAlertCreated =
                    (ServiceEventHandler<DeviationAlert>)
                        Delegate.RemoveAll(ServerDeviationAlertCreated, ServerDeviationAlertCreated);
                ServerDeviationAlertUpdated =
                    (ServiceEventHandler<DeviationAlert>)
                        Delegate.RemoveAll(ServerDeviationAlertUpdated, ServerDeviationAlertUpdated);

                ServerWorkPermitMontrealCreated =
                    (ServiceEventHandler<WorkPermitMontreal>)
                        Delegate.RemoveAll(ServerWorkPermitMontrealCreated, ServerWorkPermitMontrealCreated);
                ServerWorkPermitMontrealUpdated =
                    (ServiceEventHandler<WorkPermitMontreal>)
                        Delegate.RemoveAll(ServerWorkPermitMontrealUpdated, ServerWorkPermitMontrealUpdated);
                ServerWorkPermitMontrealRemoved =
                    (ServiceEventHandler<WorkPermitMontreal>)
                        Delegate.RemoveAll(ServerWorkPermitMontrealRemoved, ServerWorkPermitMontrealRemoved);

                ServerPermitRequestCreated =
                    (ServiceEventHandler<PermitRequestMontreal>)
                        Delegate.RemoveAll(ServerPermitRequestCreated, ServerPermitRequestCreated);
                ServerPermitRequestUpdated =
                    (ServiceEventHandler<PermitRequestMontreal>)
                        Delegate.RemoveAll(ServerPermitRequestUpdated, ServerPermitRequestUpdated);
                ServerPermitRequestRemoved =
                    (ServiceEventHandler<PermitRequestMontreal>)
                        Delegate.RemoveAll(ServerPermitRequestRemoved, ServerPermitRequestRemoved);

                ServerConfinedSpaceCreated =
                    (ServiceEventHandler<ConfinedSpace>)
                        Delegate.RemoveAll(ServerConfinedSpaceCreated, ServerConfinedSpaceCreated);
                ServerConfinedSpaceUpdated =
                    (ServiceEventHandler<ConfinedSpace>)
                        Delegate.RemoveAll(ServerConfinedSpaceUpdated, ServerConfinedSpaceUpdated);
                ServerConfinedSpaceRemoved =
                    (ServiceEventHandler<ConfinedSpace>)
                        Delegate.RemoveAll(ServerConfinedSpaceRemoved, ServerConfinedSpaceRemoved);

                //RITM0301321 - mangesh
                ServerConfinedSpaceMudsCreated =
                   (ServiceEventHandler<ConfinedSpaceMuds>)
                       Delegate.RemoveAll(ServerConfinedSpaceMudsCreated, ServerConfinedSpaceMudsCreated);
                ServerConfinedSpaceMudsUpdated =
                    (ServiceEventHandler<ConfinedSpaceMuds>)
                        Delegate.RemoveAll(ServerConfinedSpaceMudsUpdated, ServerConfinedSpaceMudsUpdated);
                ServerConfinedSpaceMudsRemoved =
                    (ServiceEventHandler<ConfinedSpaceMuds>)
                        Delegate.RemoveAll(ServerConfinedSpaceMudsRemoved, ServerConfinedSpaceMudsRemoved);

                ServerFunctionalLocationOperationalModeUpdated =
                    (ServiceEventHandler<FunctionalLocation>)
                        Delegate.RemoveAll(ServerFunctionalLocationOperationalModeUpdated,
                            ServerFunctionalLocationOperationalModeUpdated);

                ServerWorkPermitEdmontonCreated =
                    (ServiceEventHandler<WorkPermitEdmonton>)
                        Delegate.RemoveAll(ServerWorkPermitEdmontonCreated, ServerWorkPermitEdmontonCreated);
                ServerWorkPermitEdmontonUpdated =
                    (ServiceEventHandler<WorkPermitEdmonton>)
                        Delegate.RemoveAll(ServerWorkPermitEdmontonUpdated, ServerWorkPermitEdmontonUpdated);
                ServerWorkPermitEdmontonRemoved =
                    (ServiceEventHandler<WorkPermitEdmonton>)
                        Delegate.RemoveAll(ServerWorkPermitEdmontonRemoved, ServerWorkPermitEdmontonRemoved);

                ServerPermitRequestEdmontonCreated =
                    (ServiceEventHandler<PermitRequestEdmonton>)
                        Delegate.RemoveAll(ServerPermitRequestEdmontonCreated, ServerPermitRequestEdmontonCreated);
                ServerPermitRequestEdmontonUpdated =
                    (ServiceEventHandler<PermitRequestEdmonton>)
                        Delegate.RemoveAll(ServerPermitRequestEdmontonUpdated, ServerPermitRequestEdmontonUpdated);
                ServerPermitRequestEdmontonRemoved =
                    (ServiceEventHandler<PermitRequestEdmonton>)
                        Delegate.RemoveAll(ServerPermitRequestEdmontonRemoved, ServerPermitRequestEdmontonRemoved);

                ServerGN7FormCreated =
                    (ServiceEventHandler<FormGN7>) Delegate.RemoveAll(ServerGN7FormCreated, ServerGN7FormCreated);
                ServerGN7FormUpdated =
                    (ServiceEventHandler<FormGN7>) Delegate.RemoveAll(ServerGN7FormUpdated, ServerGN7FormUpdated);
                ServerGN7FormRemoved =
                    (ServiceEventHandler<FormGN7>) Delegate.RemoveAll(ServerGN7FormRemoved, ServerGN7FormRemoved);

                ServerGN59FormCreated =
                    (ServiceEventHandler<FormGN59>) Delegate.RemoveAll(ServerGN59FormCreated, ServerGN59FormCreated);
                ServerGN59FormUpdated =
                    (ServiceEventHandler<FormGN59>) Delegate.RemoveAll(ServerGN59FormUpdated, ServerGN59FormUpdated);
                ServerGN59FormRemoved =
                    (ServiceEventHandler<FormGN59>) Delegate.RemoveAll(ServerGN59FormRemoved, ServerGN59FormRemoved);

                ServerOP14FormCreated =
                    (ServiceEventHandler<FormOP14>) Delegate.RemoveAll(ServerOP14FormCreated, ServerOP14FormCreated);
                ServerOP14FormUpdated =
                    (ServiceEventHandler<FormOP14>) Delegate.RemoveAll(ServerOP14FormUpdated, ServerOP14FormUpdated);
                ServerOP14FormRemoved =
                    (ServiceEventHandler<FormOP14>) Delegate.RemoveAll(ServerOP14FormRemoved, ServerOP14FormRemoved);

                //generic template - mangesh
                ServerGenericTemplateFormCreated =
                    (ServiceEventHandler<FormGenericTemplate>)Delegate.RemoveAll(ServerGenericTemplateFormCreated, ServerGenericTemplateFormCreated);
                ServerGenericTemplateFormUpdated =
                    (ServiceEventHandler<FormGenericTemplate>)Delegate.RemoveAll(ServerGenericTemplateFormUpdated, ServerGenericTemplateFormUpdated);
                ServerGenericTemplateFormRemoved =
                    (ServiceEventHandler<FormGenericTemplate>)Delegate.RemoveAll(ServerGenericTemplateFormRemoved, ServerGenericTemplateFormRemoved);
                //--
                ServerOilsandsPermitAssessmentFormCreated =
                    (ServiceEventHandler<PermitAssessment>)
                        Delegate.RemoveAll(ServerOilsandsPermitAssessmentFormCreated,
                            ServerOilsandsPermitAssessmentFormCreated);
                ServerOilsandsPermitAssessmentFormUpdated =
                    (ServiceEventHandler<PermitAssessment>)
                        Delegate.RemoveAll(ServerOilsandsPermitAssessmentFormUpdated,
                            ServerOilsandsPermitAssessmentFormUpdated);
                ServerOilsandsPermitAssessmentFormRemoved =
                    (ServiceEventHandler<PermitAssessment>)
                        Delegate.RemoveAll(ServerOilsandsPermitAssessmentFormRemoved,
                            ServerOilsandsPermitAssessmentFormRemoved);

                ServerDocumentSuggestionFormCreated =
                    (ServiceEventHandler<DocumentSuggestion>)
                        Delegate.RemoveAll(ServerDocumentSuggestionFormCreated,
                            ServerDocumentSuggestionFormCreated);
                ServerDocumentSuggestionFormUpdated =
                    (ServiceEventHandler<DocumentSuggestion>)
                        Delegate.RemoveAll(ServerDocumentSuggestionFormUpdated,
                            ServerDocumentSuggestionFormUpdated);
                ServerDocumentSuggestionFormRemoved =
                    (ServiceEventHandler<DocumentSuggestion>)
                        Delegate.RemoveAll(ServerDocumentSuggestionFormRemoved,
                            ServerDocumentSuggestionFormRemoved);

                ServerProcedureDeviationFormCreated =
                    (ServiceEventHandler<ProcedureDeviation>)
                        Delegate.RemoveAll(ServerProcedureDeviationFormCreated,
                            ServerProcedureDeviationFormCreated);
                ServerProcedureDeviationFormUpdated =
                    (ServiceEventHandler<ProcedureDeviation>)
                        Delegate.RemoveAll(ServerProcedureDeviationFormUpdated,
                            ServerProcedureDeviationFormUpdated);
                ServerProcedureDeviationFormRemoved =
                    (ServiceEventHandler<ProcedureDeviation>)
                        Delegate.RemoveAll(ServerProcedureDeviationFormRemoved,
                            ServerProcedureDeviationFormRemoved);

                ServerLubesCsdFormCreated =
                    (ServiceEventHandler<LubesCsdForm>)
                        Delegate.RemoveAll(ServerLubesCsdFormCreated, ServerLubesCsdFormCreated);
                ServerLubesCsdFormUpdated =
                    (ServiceEventHandler<LubesCsdForm>)
                        Delegate.RemoveAll(ServerLubesCsdFormUpdated, ServerLubesCsdFormUpdated);
                ServerLubesCsdFormRemoved =
                    (ServiceEventHandler<LubesCsdForm>)
                        Delegate.RemoveAll(ServerLubesCsdFormRemoved, ServerLubesCsdFormRemoved);

                ServerLubesAlarmDisableFormCreated =
                    (ServiceEventHandler<LubesAlarmDisableForm>)
                        Delegate.RemoveAll(ServerLubesAlarmDisableFormCreated, ServerLubesAlarmDisableFormCreated);
                ServerLubesAlarmDisableFormUpdated =
                    (ServiceEventHandler<LubesAlarmDisableForm>)
                        Delegate.RemoveAll(ServerLubesAlarmDisableFormUpdated, ServerLubesAlarmDisableFormUpdated);
                ServerLubesAlarmDisableFormRemoved =
                    (ServiceEventHandler<LubesAlarmDisableForm>)
                        Delegate.RemoveAll(ServerLubesAlarmDisableFormRemoved, ServerLubesAlarmDisableFormRemoved);

                ServerMontrealCsdFormCreated =
                    (ServiceEventHandler<MontrealCsd>)
                        Delegate.RemoveAll(ServerMontrealCsdFormCreated, ServerMontrealCsdFormCreated);
                ServerMontrealCsdFormUpdated =
                    (ServiceEventHandler<MontrealCsd>)
                        Delegate.RemoveAll(ServerMontrealCsdFormUpdated, ServerMontrealCsdFormUpdated);
                ServerMontrealCsdFormRemoved =
                    (ServiceEventHandler<MontrealCsd>)
                        Delegate.RemoveAll(ServerMontrealCsdFormRemoved, ServerMontrealCsdFormRemoved);

                //DMND0011225 OLT - CSD for WBR
                ServerGenericCsdFormCreated =
                    (ServiceEventHandler<GenericCsd>)
                        Delegate.RemoveAll(ServerGenericCsdFormCreated, ServerGenericCsdFormCreated);
                ServerGenericCsdFormUpdated =
                    (ServiceEventHandler<GenericCsd>)
                        Delegate.RemoveAll(ServerGenericCsdFormUpdated, ServerGenericCsdFormUpdated);
                ServerGenericCsdFormRemoved =
                    (ServiceEventHandler<GenericCsd>)
                        Delegate.RemoveAll(ServerGenericCsdFormRemoved, ServerGenericCsdFormRemoved);

                //RITM0268131 - mangesh
                ServerMudsTemporaryInstallationsFormCreated =
                   (ServiceEventHandler<TemporaryInstallationsMUDS>)
                       Delegate.RemoveAll(ServerMudsTemporaryInstallationsFormCreated, ServerMudsTemporaryInstallationsFormCreated);
                ServerMudsTemporaryInstallationsFormUpdated =
                    (ServiceEventHandler<TemporaryInstallationsMUDS>)
                        Delegate.RemoveAll(ServerMudsTemporaryInstallationsFormUpdated, ServerMudsTemporaryInstallationsFormUpdated);
                ServerMudsTemporaryInstallationsFormRemoved =
                    (ServiceEventHandler<TemporaryInstallationsMUDS>)
                        Delegate.RemoveAll(ServerMudsTemporaryInstallationsFormRemoved, ServerMudsTemporaryInstallationsFormRemoved);

                //RITM0301321 - mangesh
                ServerWorkPermitMudsCreated =
                    (ServiceEventHandler<WorkPermitMuds>)
                        Delegate.RemoveAll(ServerWorkPermitMudsCreated, ServerWorkPermitMudsCreated);

                ServerWorkPermitMudsTemplateCreated =
                    (ServiceEventHandler<WorkPermitMuds>)
                        Delegate.RemoveAll(ServerWorkPermitMudsTemplateCreated, ServerWorkPermitMudsTemplateCreated);
                ServerWorkPermitMudsUpdated =
                    (ServiceEventHandler<WorkPermitMuds>)
                        Delegate.RemoveAll(ServerWorkPermitMudsUpdated, ServerWorkPermitMudsUpdated);
                ServerWorkPermitMudsRemoved =
                    (ServiceEventHandler<WorkPermitMuds>)
                        Delegate.RemoveAll(ServerWorkPermitMudsRemoved, ServerWorkPermitMudsRemoved);
                
                ServerPermitRequestMudsCreated =
                    (ServiceEventHandler<PermitRequestMuds>)
                        Delegate.RemoveAll(ServerPermitRequestMudsCreated, ServerPermitRequestMudsCreated);

                ServerPermitRequestMudsTemplateCreated =
                    (ServiceEventHandler<PermitRequestMuds>)
                        Delegate.RemoveAll(ServerPermitRequestMudsTemplateCreated, ServerPermitRequestMudsTemplateCreated);
                
                ServerPermitRequestMudsUpdated =
                    (ServiceEventHandler<PermitRequestMuds>)
                        Delegate.RemoveAll(ServerPermitRequestMudsUpdated, ServerPermitRequestMudsUpdated);
                ServerPermitRequestMudsRemoved =
                    (ServiceEventHandler<PermitRequestMuds>)
                        Delegate.RemoveAll(ServerPermitRequestMudsRemoved, ServerPermitRequestMudsRemoved);

                ServerGN24FormCreated =
                    (ServiceEventHandler<FormGN24>) Delegate.RemoveAll(ServerGN24FormCreated, ServerGN24FormCreated);
                ServerGN24FormUpdated =
                    (ServiceEventHandler<FormGN24>) Delegate.RemoveAll(ServerGN24FormUpdated, ServerGN24FormUpdated);
                ServerGN24FormRemoved =
                    (ServiceEventHandler<FormGN24>) Delegate.RemoveAll(ServerGN24FormRemoved, ServerGN24FormRemoved);

                ServerGN6FormCreated =
                    (ServiceEventHandler<FormGN6>) Delegate.RemoveAll(ServerGN6FormCreated, ServerGN6FormCreated);
                ServerGN6FormUpdated =
                    (ServiceEventHandler<FormGN6>) Delegate.RemoveAll(ServerGN6FormUpdated, ServerGN6FormUpdated);
                ServerGN6FormRemoved =
                    (ServiceEventHandler<FormGN6>) Delegate.RemoveAll(ServerGN6FormRemoved, ServerGN6FormRemoved);

                ServerGN75AFormCreated =
                    (ServiceEventHandler<FormGN75A>) Delegate.RemoveAll(ServerGN75AFormCreated, ServerGN75AFormCreated);
                ServerGN75AFormUpdated =
                    (ServiceEventHandler<FormGN75A>) Delegate.RemoveAll(ServerGN75AFormUpdated, ServerGN75AFormUpdated);
                ServerGN75AFormRemoved =
                    (ServiceEventHandler<FormGN75A>) Delegate.RemoveAll(ServerGN75AFormRemoved, ServerGN75AFormRemoved);

                ServerGN75BFormCreated =
                    (ServiceEventHandler<FormGN75B>) Delegate.RemoveAll(ServerGN75BFormCreated, ServerGN75BFormCreated);
                ServerGN75BFormUpdated =
                    (ServiceEventHandler<FormGN75B>) Delegate.RemoveAll(ServerGN75BFormUpdated, ServerGN75BFormUpdated);
                ServerGN75BFormRemoved =
                    (ServiceEventHandler<FormGN75B>) Delegate.RemoveAll(ServerGN75BFormRemoved, ServerGN75BFormRemoved);


                //ayman Sarnia eip DMND0008992
                ServerGN75BTemplateFormCreated =
                    (ServiceEventHandler<FormGN75B>)Delegate.RemoveAll(ServerGN75BTemplateFormCreated, ServerGN75BTemplateFormCreated);
                ServerGN75BTemplateFormUpdated =
                    (ServiceEventHandler<FormGN75B>)Delegate.RemoveAll(ServerGN75BTemplateFormUpdated, ServerGN75BTemplateFormUpdated);
                ServerGN75BTemplateFormRemoved =
                    (ServiceEventHandler<FormGN75B>)Delegate.RemoveAll(ServerGN75BTemplateFormRemoved, ServerGN75BTemplateFormRemoved);






                ServerGN1FormCreated =
                    (ServiceEventHandler<FormGN1>) Delegate.RemoveAll(ServerGN1FormCreated, ServerGN1FormCreated);
                ServerGN1FormUpdated =
                    (ServiceEventHandler<FormGN1>) Delegate.RemoveAll(ServerGN1FormUpdated, ServerGN1FormUpdated);
                ServerGN1FormRemoved =
                    (ServiceEventHandler<FormGN1>) Delegate.RemoveAll(ServerGN1FormRemoved, ServerGN1FormRemoved);

                ServerOvertimeFormCreated =
                    (ServiceEventHandler<OvertimeForm>)
                        Delegate.RemoveAll(ServerOvertimeFormCreated, ServerOvertimeFormCreated);
                ServerOvertimeFormUpdated =
                    (ServiceEventHandler<OvertimeForm>)
                        Delegate.RemoveAll(ServerOvertimeFormUpdated, ServerOvertimeFormUpdated);
                ServerOvertimeFormRemoved =
                    (ServiceEventHandler<OvertimeForm>)
                        Delegate.RemoveAll(ServerOvertimeFormRemoved, ServerOvertimeFormRemoved);

                ServerOnPremisePersonnelCreated =
                    (ServiceEventHandler<OnPremisePersonnel>)
                        Delegate.RemoveAll(ServerOnPremisePersonnelCreated, ServerOnPremisePersonnelCreated);
                ServerOnPremisePersonnelUpdated =
                    (ServiceEventHandler<OnPremisePersonnel>)
                        Delegate.RemoveAll(ServerOnPremisePersonnelUpdated, ServerOnPremisePersonnelUpdated);
                ServerOnPremisePersonnelRemoved =
                    (ServiceEventHandler<OnPremisePersonnel>)
                        Delegate.RemoveAll(ServerOnPremisePersonnelRemoved, ServerOnPremisePersonnelRemoved);

                ServerShiftHandoverEmailConfigurationCreated =
                    (ServiceEventHandler<ShiftHandoverEmailConfiguration>)
                        Delegate.RemoveAll(ServerShiftHandoverEmailConfigurationCreated,
                            ServerShiftHandoverEmailConfigurationCreated);
                ServerShiftHandoverEmailConfigurationUpdated =
                    (ServiceEventHandler<ShiftHandoverEmailConfiguration>)
                        Delegate.RemoveAll(ServerShiftHandoverEmailConfigurationUpdated,
                            ServerShiftHandoverEmailConfigurationUpdated);
                ServerShiftHandoverEmailConfigurationRemoved =
                    (ServiceEventHandler<ShiftHandoverEmailConfiguration>)
                        Delegate.RemoveAll(ServerShiftHandoverEmailConfigurationRemoved,
                            ServerShiftHandoverEmailConfigurationRemoved);

                ServerDirectiveCreated =
                    (ServiceEventHandler<Directive>) Delegate.RemoveAll(ServerDirectiveCreated, ServerDirectiveCreated);
                ServerDirectiveUpdated =
                    (ServiceEventHandler<Directive>) Delegate.RemoveAll(ServerDirectiveUpdated, ServerDirectiveUpdated);
                ServerDirectiveRemoved =
                    (ServiceEventHandler<Directive>) Delegate.RemoveAll(ServerDirectiveRemoved, ServerDirectiveRemoved);
                ServerDirectiveMarkedAsReadByCurrentUser =
                    (ServiceEventHandler<Directive>)
                        Delegate.RemoveAll(ServerDirectiveMarkedAsReadByCurrentUser,
                            ServerDirectiveMarkedAsReadByCurrentUser);

                ServerOpmExcursionCreated =
                    (ServiceEventHandler<OpmExcursion>)
                        Delegate.RemoveAll(ServerOpmExcursionCreated, ServerOpmExcursionCreated);
                ServerOpmExcursionUpdated =
                    (ServiceEventHandler<OpmExcursion>)
                        Delegate.RemoveAll(ServerOpmExcursionUpdated, ServerOpmExcursionUpdated);
                ServerOpmExcursionRemoved =
                    (ServiceEventHandler<OpmExcursion>)
                        Delegate.RemoveAll(ServerOpmExcursionRemoved, ServerOpmExcursionRemoved);

                ServerOpmToeDefinitionCreated =
                    (ServiceEventHandler<OpmToeDefinition>)
                        Delegate.RemoveAll(ServerOpmToeDefinitionCreated, ServerOpmToeDefinitionCreated);
                ServerOpmToeDefinitionUpdated =
                    (ServiceEventHandler<OpmToeDefinition>)
                        Delegate.RemoveAll(ServerOpmToeDefinitionUpdated, ServerOpmToeDefinitionUpdated);
                ServerOpmToeDefinitionRemoved =
                    (ServiceEventHandler<OpmToeDefinition>)
                        Delegate.RemoveAll(ServerOpmToeDefinitionRemoved, ServerOpmToeDefinitionRemoved);

                ServerOpmExcursionImportStatusUpdated =
                    (ServiceEventHandler<OpmExcursionImportStatusDTO>)
                        Delegate.RemoveAll(ServerOpmExcursionImportStatusUpdated, ServerOpmExcursionImportStatusUpdated);

                ServerOpmExcursionItemRefresh =
                    (ServiceEventHandler<Site>)
                        Delegate.RemoveAll(ServerOpmExcursionItemRefresh, ServerOpmExcursionItemRefresh);

                ServerOpmExcursionBatchCreated =
                    (ServiceEventHandler<OpmExcursionBatch>)
                        Delegate.RemoveAll(ServerOpmExcursionBatchCreated, ServerOpmExcursionBatchCreated);
                ServerOpmExcursionBatchUpdated =
                    (ServiceEventHandler<OpmExcursionBatch>)
                        Delegate.RemoveAll(ServerOpmExcursionBatchUpdated, ServerOpmExcursionBatchUpdated);

                ServerWorkPermitFortHillsCreated =
                   (ServiceEventHandler<WorkPermitFortHills>)
                       Delegate.RemoveAll(ServerWorkPermitFortHillsCreated, ServerWorkPermitFortHillsCreated);
                ServerWorkPermitFortHillsUpdated =
                    (ServiceEventHandler<WorkPermitFortHills>)
                        Delegate.RemoveAll(ServerWorkPermitFortHillsUpdated, ServerWorkPermitFortHillsUpdated);
                ServerWorkPermitFortHillsRemoved =
                    (ServiceEventHandler<WorkPermitFortHills>)
                        Delegate.RemoveAll(ServerWorkPermitFortHillsRemoved, ServerWorkPermitFortHillsRemoved);

                ServerPermitRequestFortHillsCreated =
                    (ServiceEventHandler<PermitRequestFortHills>)
                        Delegate.RemoveAll(ServerPermitRequestFortHillsCreated, ServerPermitRequestFortHillsCreated);
                ServerPermitRequestFortHillsUpdated =
                    (ServiceEventHandler<PermitRequestFortHills>)
                        Delegate.RemoveAll(ServerPermitRequestFortHillsUpdated, ServerPermitRequestFortHillsUpdated);
                ServerPermitRequestFortHillsRemoved =
                    (ServiceEventHandler<PermitRequestFortHills>)
                        Delegate.RemoveAll(ServerPermitRequestFortHillsRemoved, ServerPermitRequestFortHillsRemoved);

            }
        }

        public void Notify(DomainEventArgs<DomainObject> e)
        {
            try
            {
                remoteEventQueue.Enqueue(e);
            }
            catch (Exception exception)
            {
                // NOTE: Eric: If we don't catch this exception, it will propagate back to the server
                //       trying to notify this client. We should handle these problems on the client side.
                logger.Error("Error handling server event:<" + e.ApplicationEventType + ">", exception);
            }
        }

        public void Dispatch(ApplicationEvent appEvent, DomainObject domain)
        {
            try
            {
                switch (appEvent)
                {
                    case ApplicationEvent.ActionItemDefinitionCreate:
                    {
                        if (ServerActionItemDefinitionCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerActionItemDefinitionCreated(this, new DomainEventArgs<ActionItemDefinition>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.ActionItemDefinitionUpdate:
                    {
                        if (ServerActionItemDefinitionUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerActionItemDefinitionUpdated(this, new DomainEventArgs<ActionItemDefinition>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.ActionItemDefinitionRemove:
                    {
                        if (ServerActionItemDefinitionRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerActionItemDefinitionRemoved(this, new DomainEventArgs<ActionItemDefinition>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.ActionItemCreate:
                    {
                        if (ServerActionItemCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerActionItemCreated(this, new DomainEventArgs<ActionItem>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.ActionItemDelete:
                    {
                        if (ServerActionItemRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerActionItemRemoved(this, new DomainEventArgs<ActionItem>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.ActionItemUpdate:
                    {
                        if (ServerActionItemUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerActionItemUpdated(this, new DomainEventArgs<ActionItem>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.ActionItemRefresh:
                    {
                        if (ServerActionItemRefresh != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerActionItemRefresh(this, new DomainEventArgs<Site>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.TargetDefinitionCreate:
                    {
                        if (ServerTargetDefinitionCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerTargetDefinitionCreated(this,
                                new DomainEventArgs<TargetDefinition>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.TargetDefinitionRemove:
                    {
                        if (ServerTargetDefinitionRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerTargetDefinitionRemoved(this,
                                new DomainEventArgs<TargetDefinition>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.TargetDefinitionUpdate:
                    {
                        if (ServerTargetDefinitionUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerTargetDefinitionUpdated(this,
                                new DomainEventArgs<TargetDefinition>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.LogCreate:
                    {
                        if (ServerLogCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerLogCreated(this, new DomainEventArgs<Log>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.LogRemove:
                    {
                        if (ServerLogRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerLogRemoved(this, new DomainEventArgs<Log>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.LogUpdate:
                    {
                        if (ServerLogUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerLogUpdated(this, new DomainEventArgs<Log>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.LogMarkedAsReadByCurrentUser:
                    {
                        if (ServerLogMarkedAsReadByCurrentUser != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerLogMarkedAsReadByCurrentUser(this, new DomainEventArgs<Log>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.SummaryLogCreate:
                    {
                        if (ServerSummaryLogCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerSummaryLogCreated(this, new DomainEventArgs<SummaryLog>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.SummaryLogRemove:
                    {
                        if (ServerSummaryLogRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerSummaryLogRemoved(this, new DomainEventArgs<SummaryLog>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.SummaryLogUpdate:
                    {
                        if (ServerSummaryLogUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerSummaryLogUpdated(this, new DomainEventArgs<SummaryLog>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.CokerCardCreate:
                    {
                        if (ServerCokerCardCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerCokerCardCreated(this, new DomainEventArgs<CokerCard>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.CokerCardRemove:
                    {
                        if (ServerCokerCardRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerCokerCardRemoved(this, new DomainEventArgs<CokerCard>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.CokerCardUpdate:
                    {
                        if (ServerCokerCardUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerCokerCardUpdated(this, new DomainEventArgs<CokerCard>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.LogDefinitionCreate:
                    {
                        if (ServerLogDefinitionCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerLogDefinitionCreated(this, new DomainEventArgs<LogDefinition>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.LogDefinitionRemove:
                    {
                        if (ServerLogDefinitionRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerLogDefinitionRemoved(this, new DomainEventArgs<LogDefinition>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.LogDefinitionUpdate:
                    {
                        if (ServerLogDefinitionUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerLogDefinitionUpdated(this, new DomainEventArgs<LogDefinition>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.LogDefinitionCancelRecurring:
                    {
                        if (ServerLogCancelledRecurringDefinition != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerLogCancelledRecurringDefinition(this, new DomainEventArgs<LogDefinition>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.TargetAlertCreate:
                    {
                        if (ServerTargetAlertCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerTargetAlertCreated(this, new DomainEventArgs<TargetAlert>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.TargetAlertUpdate:
                    {
                        if (ServerTargetAlertUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerTargetAlertUpdated(this, new DomainEventArgs<TargetAlert>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.WorkPermitCreate:
                    {
                        if (ServerWorkPermitCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerWorkPermitCreated(this, new DomainEventArgs<WorkPermit>(domain));
                        }
                        break;
                    }

                    case ApplicationEvent.WorkPermitCreateTemplate:
                    {
                        if (ServerWorkPermitCreated_Template != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerWorkPermitCreated_Template(this, new DomainEventArgs<WorkPermit>(domain));
                        }
                        break;
                    }

                    case ApplicationEvent.WorkPermitRemove:
                    {
                        if (ServerWorkPermitRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerWorkPermitRemoved(this, new DomainEventArgs<WorkPermit>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.WorkPermitUpdate:
                    {
                        if (ServerWorkPermitUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerWorkPermitUpdated(this, new DomainEventArgs<WorkPermit>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.SapNotificationCreate:
                    {
                        if (ServerSAPNotificationCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerSAPNotificationCreated(this, new DomainEventArgs<SAPNotification>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.SapNotificationProcess:
                    {
                        if (ServerSAPNotificationProcessed != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerSAPNotificationProcessed(this, new DomainEventArgs<SAPNotification>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.SapNotificationUpdate:
                    {
                        if (ServerSAPNotificationUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerSAPNotificationUpdated(this, new DomainEventArgs<SAPNotification>(domain));
                        }
                        break;
                    }

                    case ApplicationEvent.FunctionalLocationOperationalModeUpdate:
                    {
                        if (ServerFunctionalLocationOperationalModeUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerFunctionalLocationOperationalModeUpdated(this,
                                new DomainEventArgs<FunctionalLocation>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.RestrictionDefinitionCreate:
                    {
                        if (ServerRestrictionDefinitionCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerRestrictionDefinitionCreated(this, new DomainEventArgs<RestrictionDefinition>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.RestrictionDefinitionUpdate:
                    {
                        if (ServerRestrictionDefinitionUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerRestrictionDefinitionUpdated(this, new DomainEventArgs<RestrictionDefinition>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.RestrictionDefinitionRemove:
                    {
                        if (ServerRestrictionDefinitionRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerRestrictionDefinitionRemoved(this, new DomainEventArgs<RestrictionDefinition>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.DeviationAlertCreate:
                    {
                        if (ServerDeviationAlertCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerDeviationAlertCreated(this, new DomainEventArgs<DeviationAlert>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.DeviationAlertUpdate:
                    {
                        if (ServerDeviationAlertUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerDeviationAlertUpdated(this, new DomainEventArgs<DeviationAlert>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.LabAlertDefinitionCreate:
                    {
                        if (ServerLabAlertDefinitionCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerLabAlertDefinitionCreated(this, new DomainEventArgs<LabAlertDefinition>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.LabAlertDefinitionUpdate:
                    {
                        if (ServerLabAlertDefinitionUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerLabAlertDefinitionUpdated(this, new DomainEventArgs<LabAlertDefinition>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.LabAlertDefinitionRemove:
                    {
                        if (ServerLabAlertDefinitionRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerLabAlertDefinitionRemoved(this, new DomainEventArgs<LabAlertDefinition>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.LabAlertCreate:
                    {
                        if (ServerLabAlertCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerLabAlertCreated(this, new DomainEventArgs<LabAlert>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.LabAlertUpdate:
                    {
                        if (ServerLabAlertUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerLabAlertUpdated(this, new DomainEventArgs<LabAlert>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.ShiftHandoverQuestionnaireCreate:
                    {
                        if (ServerShiftHandoverQuestionnaireCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerShiftHandoverQuestionnaireCreated(this,
                                new DomainEventArgs<ShiftHandoverQuestionnaire>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.ShiftHandoverQuestionnaireUpdate:
                    {
                        if (ServerShiftHandoverQuestionnaireUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerShiftHandoverQuestionnaireUpdated(this,
                                new DomainEventArgs<ShiftHandoverQuestionnaire>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.ShiftHandoverQuestionnaireRemove:
                    {
                        if (ServerShiftHandoverQuestionnaireRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerShiftHandoverQuestionnaireRemoved(this,
                                new DomainEventArgs<ShiftHandoverQuestionnaire>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.ShiftHandoverQuestionnaireMarkedAsReadByCurrentUser:
                    {
                        if (ServerShiftHandoverQuestionnaireMarkedAsReadByCurrentUser != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerShiftHandoverQuestionnaireMarkedAsReadByCurrentUser(this,
                                new DomainEventArgs<ShiftHandoverQuestionnaire>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.WorkPermitMontrealCreate:
                    {
                        if (ServerWorkPermitMontrealCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerWorkPermitMontrealCreated(this, new DomainEventArgs<WorkPermitMontreal>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.WorkPermitMontrealUpdate:
                    {
                        if (ServerWorkPermitMontrealUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerWorkPermitMontrealUpdated(this, new DomainEventArgs<WorkPermitMontreal>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.WorkPermitMontrealRemove:
                    {
                        if (ServerWorkPermitMontrealRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerWorkPermitMontrealRemoved(this, new DomainEventArgs<WorkPermitMontreal>(domain));
                        }
                        break;
                    }
                    // RITM0301321 start - Mangesh
                    case ApplicationEvent.WorkPermitMudsCreate:
                    {
                        if (ServerWorkPermitMudsCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerWorkPermitMudsCreated(this, new DomainEventArgs<WorkPermitMuds>(domain));
                        }
                        break;
                    }

                    case ApplicationEvent.WorkPermitMudsTemplateCreate:
                    {
                        if (ServerWorkPermitMudsTemplateCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerWorkPermitMudsTemplateCreated(this, new DomainEventArgs<WorkPermitMuds>(domain));
                        }
                        break;
                    }


                    case ApplicationEvent.WorkPermitMudsUpdate:
                    {
                        if (ServerWorkPermitMudsUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerWorkPermitMudsUpdated(this, new DomainEventArgs<WorkPermitMuds>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.WorkPermitMudsRemove:
                    {
                        if (ServerWorkPermitMudsRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerWorkPermitMudsRemoved(this, new DomainEventArgs<WorkPermitMuds>(domain));
                        }
                        break;
                    }
                    
                    case ApplicationEvent.PermitRequestMudsCreate:
                    {
                        if (ServerPermitRequestMudsCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerPermitRequestMudsCreated(this, new DomainEventArgs<PermitRequestMuds>(domain));
                        }
                        break;
                    }
                     case ApplicationEvent.PermitRequestMudsTemplateCreate:
                    {
                        if (ServerPermitRequestMudsTemplateCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerPermitRequestMudsTemplateCreated(this, new DomainEventArgs<PermitRequestMuds>(domain));
                        }
                        break;
                    }
                        
                    case ApplicationEvent.PermitRequestMudsRemove:
                    {
                        if (ServerPermitRequestMudsRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerPermitRequestMudsRemoved(this, new DomainEventArgs<PermitRequestMuds>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.PermitRequestMudsUpdate:
                    {
                        if (ServerPermitRequestMudsUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerPermitRequestMudsUpdated(this, new DomainEventArgs<PermitRequestMuds>(domain));
                        }
                        break;
                    }

                    // RITM0301321 - End
                    case ApplicationEvent.PermitRequestCreate:
                    {
                        if (ServerPermitRequestCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerPermitRequestCreated(this, new DomainEventArgs<PermitRequestMontreal>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.PermitRequestRemove:
                    {
                        if (ServerPermitRequestRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerPermitRequestRemoved(this, new DomainEventArgs<PermitRequestMontreal>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.PermitRequestUpdate:
                    {
                        if (ServerPermitRequestUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerPermitRequestUpdated(this, new DomainEventArgs<PermitRequestMontreal>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.ConfinedSpaceCreate:
                    {
                        if (ServerConfinedSpaceCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerConfinedSpaceCreated(this, new DomainEventArgs<ConfinedSpace>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.ConfinedSpaceUpdate:
                    {
                        if (ServerConfinedSpaceUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerConfinedSpaceUpdated(this, new DomainEventArgs<ConfinedSpace>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.ConfinedSpaceRemove:
                    {
                        if (ServerConfinedSpaceRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerConfinedSpaceRemoved(this, new DomainEventArgs<ConfinedSpace>(domain));
                        }
                        break;
                    }
                    //RITM0301321 - mangesh
                    case ApplicationEvent.ConfinedSpaceMudsCreate:
                    {
                        if (ServerConfinedSpaceMudsCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerConfinedSpaceMudsCreated(this, new DomainEventArgs<ConfinedSpaceMuds>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.ConfinedSpaceMudsUpdate:
                    {
                        if (ServerConfinedSpaceMudsUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerConfinedSpaceMudsUpdated(this, new DomainEventArgs<ConfinedSpaceMuds>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.ConfinedSpaceMudsRemove:
                    {
                        if (ServerConfinedSpaceMudsRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerConfinedSpaceMudsRemoved(this, new DomainEventArgs<ConfinedSpaceMuds>(domain));
                        }
                        break;
                    }

                    case ApplicationEvent.WorkPermitEdmontonCreate:
                    {
                        if (ServerWorkPermitEdmontonCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerWorkPermitEdmontonCreated(this, new DomainEventArgs<WorkPermitEdmonton>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.WorkPermitEdmontonUpdate:
                    {
                        if (ServerWorkPermitEdmontonUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerWorkPermitEdmontonUpdated(this, new DomainEventArgs<WorkPermitEdmonton>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.WorkPermitEdmontonRemove:
                    {
                        if (ServerWorkPermitEdmontonRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerWorkPermitEdmontonRemoved(this, new DomainEventArgs<WorkPermitEdmonton>(domain));
                        }
                        break;
                    }
                    /**/
                    case ApplicationEvent.WorkPermitFortHillsCreate:
                    {
                        if (ServerWorkPermitFortHillsCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerWorkPermitFortHillsCreated(this, new DomainEventArgs<WorkPermitFortHills>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.WorkPermitFortHillsUpdate:
                    {
                        if (ServerWorkPermitFortHillsUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerWorkPermitFortHillsUpdated(this, new DomainEventArgs<WorkPermitFortHills>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.WorkPermitFortHillsRemove:
                    {
                        if (ServerWorkPermitFortHillsRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerWorkPermitFortHillsRemoved(this, new DomainEventArgs<WorkPermitFortHills>(domain));
                        }
                        break;
                    }
                    
                    /**/
                    case ApplicationEvent.PermitRequestEdmontonCreate:
                    {
                        if (ServerPermitRequestEdmontonCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerPermitRequestEdmontonCreated(this, new DomainEventArgs<PermitRequestEdmonton>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.PermitRequestEdmontonUpdate:
                    {
                        if (ServerPermitRequestEdmontonUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerPermitRequestEdmontonUpdated(this, new DomainEventArgs<PermitRequestEdmonton>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.PermitRequestEdmontonRemove:
                    {
                        if (ServerPermitRequestEdmontonRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerPermitRequestEdmontonRemoved(this, new DomainEventArgs<PermitRequestEdmonton>(domain));
                        }
                        break;
                    }
                   /**/
                    case ApplicationEvent.PermitRequestFortHillsCreate:
                    {
                        if (ServerPermitRequestFortHillsCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerPermitRequestFortHillsCreated(this, new DomainEventArgs<PermitRequestFortHills>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.PermitRequestFortHillsUpdate:
                    {
                        if (ServerPermitRequestFortHillsUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerPermitRequestFortHillsUpdated(this, new DomainEventArgs<PermitRequestFortHills>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.PermitRequestFortHillsRemove:
                    {
                        if (ServerPermitRequestFortHillsRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerPermitRequestFortHillsRemoved(this, new DomainEventArgs<PermitRequestFortHills>(domain));
                        }
                        break;
                    }
                    /**/
                    case ApplicationEvent.FormGN7Create:
                    {
                        if (ServerGN7FormCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN7FormCreated(this, new DomainEventArgs<FormGN7>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGN7Update:
                    {
                        if (ServerGN7FormUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN7FormUpdated(this, new DomainEventArgs<FormGN7>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGN7Remove:
                    {
                        if (ServerGN7FormRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN7FormRemoved(this, new DomainEventArgs<FormGN7>(domain));
                        }
                        break;
                    }

                    case ApplicationEvent.FormGN59Create:
                    {
                        if (ServerGN59FormCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN59FormCreated(this, new DomainEventArgs<FormGN59>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGN59Update:
                    {
                        if (ServerGN59FormUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN59FormUpdated(this, new DomainEventArgs<FormGN59>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGN59Remove:
                    {
                        if (ServerGN59FormRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN59FormRemoved(this, new DomainEventArgs<FormGN59>(domain));
                        }
                        break;
                    }

                    case ApplicationEvent.FormOP14Create:
                    {
                        if (ServerOP14FormCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerOP14FormCreated(this, new DomainEventArgs<FormOP14>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormOP14Update:
                    {
                        if (ServerOP14FormUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerOP14FormUpdated(this, new DomainEventArgs<FormOP14>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormOP14Remove:
                    {
                        if (ServerOP14FormRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerOP14FormRemoved(this, new DomainEventArgs<FormOP14>(domain));
                        }
                        break;
                    }

                    //generic template - mangesh
                    case ApplicationEvent.FormGenericTemplateCreate:
                    {
                        if (ServerGenericTemplateFormCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGenericTemplateFormCreated(this, new DomainEventArgs<FormGenericTemplate>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGenericTemplateUpdate:
                    {
                        if (ServerGenericTemplateFormUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGenericTemplateFormUpdated(this, new DomainEventArgs<FormGenericTemplate>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGenericTemplateRemove:
                    {
                        if (ServerGenericTemplateFormRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGenericTemplateFormRemoved(this, new DomainEventArgs<FormGenericTemplate>(domain));
                        }
                        break;
                    }
                    //---

                    case ApplicationEvent.FormPermitAssessmentCreate:
                    {
                        if (ServerOilsandsPermitAssessmentFormCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerOilsandsPermitAssessmentFormCreated(this,
                                new DomainEventArgs<PermitAssessment>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormPermitAssessmentUpdate:
                    {
                        if (ServerOilsandsPermitAssessmentFormUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerOilsandsPermitAssessmentFormUpdated(this,
                                new DomainEventArgs<PermitAssessment>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormPermitAssessmentRemove:
                    {
                        if (ServerOilsandsPermitAssessmentFormRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerOilsandsPermitAssessmentFormRemoved(this,
                                new DomainEventArgs<PermitAssessment>(domain));
                        }
                        break;
                    }

                    case ApplicationEvent.FormDocumentSuggestionCreate:
                    {
                        if (ServerDocumentSuggestionFormCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerDocumentSuggestionFormCreated(this,
                                new DomainEventArgs<DocumentSuggestion>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormDocumentSuggestionUpdate:
                    {
                        if (ServerDocumentSuggestionFormUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerDocumentSuggestionFormUpdated(this,
                                new DomainEventArgs<DocumentSuggestion>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormDocumentSuggestionRemove:
                    {
                        if (ServerDocumentSuggestionFormRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerDocumentSuggestionFormRemoved(this,
                                new DomainEventArgs<DocumentSuggestion>(domain));
                        }
                        break;
                    }

                    case ApplicationEvent.FormProcedureDeviationCreate:
                    {
                        if (ServerProcedureDeviationFormCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerProcedureDeviationFormCreated(this,
                                new DomainEventArgs<ProcedureDeviation>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormProcedureDeviationUpdate:
                    {
                        if (ServerProcedureDeviationFormUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerProcedureDeviationFormUpdated(this,
                                new DomainEventArgs<ProcedureDeviation>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormProcedureDeviationRemove:
                    {
                        if (ServerProcedureDeviationFormRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerProcedureDeviationFormRemoved(this,
                                new DomainEventArgs<ProcedureDeviation>(domain));
                        }
                        break;
                    }
                        
                    case ApplicationEvent.FormMontrealCsdCreate:
                    {
                        if (ServerMontrealCsdFormCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerMontrealCsdFormCreated(this, new DomainEventArgs<MontrealCsd>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormMontrealCsdUpdate:
                    {
                        if (ServerMontrealCsdFormUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerMontrealCsdFormUpdated(this, new DomainEventArgs<MontrealCsd>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormMontrealCsdRemove:
                    {
                        if (ServerMontrealCsdFormRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerMontrealCsdFormRemoved(this, new DomainEventArgs<MontrealCsd>(domain));
                        }
                        break;
                    }

                    //DMND0011225 CSD for WBR
                    case ApplicationEvent.FormGenericCsdCreate:
                    {
                        if (ServerGenericCsdFormCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGenericCsdFormCreated(this, new DomainEventArgs<GenericCsd>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGenericCsdUpdate:
                    {
                        if (ServerGenericCsdFormUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGenericCsdFormUpdated(this, new DomainEventArgs<GenericCsd>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGenericCsdRemove:
                    {
                        if (ServerGenericCsdFormRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGenericCsdFormRemoved(this, new DomainEventArgs<GenericCsd>(domain));
                        }
                        break;
                    }

   //RITM0268131 - mangesh
                    case ApplicationEvent.FormMudsTemporaryInstallationCreate:
                    {
                        if (ServerMudsTemporaryInstallationsFormCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerMudsTemporaryInstallationsFormCreated(this, new DomainEventArgs<TemporaryInstallationsMUDS>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormMudsTemporaryInstallationUpdate:
                    {
                        if (ServerMudsTemporaryInstallationsFormUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerMudsTemporaryInstallationsFormUpdated(this, new DomainEventArgs<TemporaryInstallationsMUDS>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormMudsTemporaryInstallationRemove:
                    {
                        if (ServerMudsTemporaryInstallationsFormRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerMudsTemporaryInstallationsFormRemoved(this, new DomainEventArgs<TemporaryInstallationsMUDS>(domain));
                        }
                        break;
                    }
                    //------                
    case ApplicationEvent.FormLubesCsdCreate:
                    {
                        if (ServerLubesCsdFormCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerLubesCsdFormCreated(this, new DomainEventArgs<LubesCsdForm>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormLubesCsdUpdate:
                    {
                        if (ServerLubesCsdFormUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerLubesCsdFormUpdated(this, new DomainEventArgs<LubesCsdForm>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormLubesCsdRemove:
                    {
                        if (ServerLubesCsdFormRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerLubesCsdFormRemoved(this, new DomainEventArgs<LubesCsdForm>(domain));
                        }
                        break;
                    }

                    case ApplicationEvent.FormLubesAlarmDisableCreate:
                    {
                        if (ServerLubesAlarmDisableFormCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerLubesAlarmDisableFormCreated(this, new DomainEventArgs<LubesAlarmDisableForm>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormLubesAlarmDisableUpdate:
                    {
                        if (ServerLubesAlarmDisableFormUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerLubesAlarmDisableFormUpdated(this, new DomainEventArgs<LubesAlarmDisableForm>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormLubesAlarmDisableRemove:
                    {
                        if (ServerLubesAlarmDisableFormRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerLubesAlarmDisableFormRemoved(this, new DomainEventArgs<LubesAlarmDisableForm>(domain));
                        }
                        break;
                    }

                    case ApplicationEvent.FormGN24Create:
                    {
                        if (ServerGN24FormCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN24FormCreated(this, new DomainEventArgs<FormGN24>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGN24Update:
                    {
                        if (ServerGN24FormUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN24FormUpdated(this, new DomainEventArgs<FormGN24>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGN24Remove:
                    {
                        if (ServerGN24FormRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN24FormRemoved(this, new DomainEventArgs<FormGN24>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGN6Create:
                    {
                        if (ServerGN6FormCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN6FormCreated(this, new DomainEventArgs<FormGN6>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGN6Update:
                    {
                        if (ServerGN6FormUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN6FormUpdated(this, new DomainEventArgs<FormGN6>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGN6Remove:
                    {
                        if (ServerGN6FormRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN6FormRemoved(this, new DomainEventArgs<FormGN6>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGN75ACreate:
                    {
                        if (ServerGN75AFormCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN75AFormCreated(this, new DomainEventArgs<FormGN75A>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGN75AUpdate:
                    {
                        if (ServerGN75AFormUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN75AFormUpdated(this, new DomainEventArgs<FormGN75A>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGN75ARemove:
                    {
                        if (ServerGN75AFormRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN75AFormRemoved(this, new DomainEventArgs<FormGN75A>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGN75BCreate:
                    {
                        if (ServerGN75BFormCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN75BFormCreated(this, new DomainEventArgs<FormGN75B>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGN75BUpdate:
                    {
                        if (ServerGN75BFormUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN75BFormUpdated(this, new DomainEventArgs<FormGN75B>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGN75BRemove:
                    {
                        if (ServerGN75BFormRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN75BFormRemoved(this, new DomainEventArgs<FormGN75B>(domain));
                        }
                        break;
                    }

                    //ayman Sarnia eip DMND0008992
                    case ApplicationEvent.FormGN75BTemplateCreate:
                    {
                        if (ServerGN75BTemplateFormCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN75BTemplateFormCreated(this, new DomainEventArgs<FormGN75B>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGN75BTemplateUpdate:
                    {
                        if (ServerGN75BTemplateFormUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN75BTemplateFormUpdated(this, new DomainEventArgs<FormGN75B>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGN75BTemplateRemove:
                    {
                        if (ServerGN75BTemplateFormRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN75BTemplateFormRemoved(this, new DomainEventArgs<FormGN75B>(domain));
                        }
                        break;
                    }

                    case ApplicationEvent.FormGN1Create:
                    {
                        if (ServerGN1FormCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN1FormCreated(this, new DomainEventArgs<FormGN1>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGN1Update:
                    {
                        if (ServerGN1FormUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN1FormUpdated(this, new DomainEventArgs<FormGN1>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormGN1Remove:
                    {
                        if (ServerGN1FormRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerGN1FormRemoved(this, new DomainEventArgs<FormGN1>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.OvertimeFormCreate:
                    {
                        if (ServerOvertimeFormCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerOvertimeFormCreated(this, new DomainEventArgs<OvertimeForm>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.OvertimeFormUpdate:
                    {
                        if (ServerOvertimeFormUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerOvertimeFormUpdated(this, new DomainEventArgs<OvertimeForm>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.OvertimeFormRemove:
                    {
                        if (ServerOvertimeFormRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerOvertimeFormRemoved(this, new DomainEventArgs<OvertimeForm>(domain));
                        }
                        break;
                    }

                    case ApplicationEvent.OnPremiseContractorCreate:
                    {
                        if (ServerOnPremisePersonnelCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerOnPremisePersonnelCreated(this, new DomainEventArgs<OnPremisePersonnel>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.OnPremiseContractorUpdate:
                    {
                        if (ServerOnPremisePersonnelUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerOnPremisePersonnelUpdated(this, new DomainEventArgs<OnPremisePersonnel>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.OnPremiseContractorRemove:
                    {
                        if (ServerOnPremisePersonnelRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerOnPremisePersonnelRemoved(this, new DomainEventArgs<OnPremisePersonnel>(domain));
                        }
                        break;
                    }

                    case ApplicationEvent.FormOilsandsTrainingCreate:
                    {
                        if (ServerFormOilsandsTrainingCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerFormOilsandsTrainingCreated(this, new DomainEventArgs<FormOilsandsTraining>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormOilsandsTrainingUpdate:
                    {
                        if (ServerFormOilsandsTrainingUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerFormOilsandsTrainingUpdated(this, new DomainEventArgs<FormOilsandsTraining>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormOilsandsTrainingRemove:
                    {
                        if (ServerFormOilsandsTrainingRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerFormOilsandsTrainingRemoved(this, new DomainEventArgs<FormOilsandsTraining>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormOilsandsCreate:
                    {
                        if (ServerFormOilsandsCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerFormOilsandsCreated(this, new DomainEventArgs<BaseFormOilsands>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormOilsandsUpdate:
                    {
                        if (ServerFormOilsandsUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerFormOilsandsUpdated(this, new DomainEventArgs<BaseFormOilsands>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.FormOilsandsRemove:
                    {
                        if (ServerFormOilsandsRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerFormOilsandsRemoved(this, new DomainEventArgs<BaseFormOilsands>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.ShiftHandoverEmailConfigurationCreate:
                    {
                        if (ServerShiftHandoverEmailConfigurationCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerShiftHandoverEmailConfigurationCreated(this,
                                new DomainEventArgs<ShiftHandoverEmailConfiguration>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.ShiftHandoverEmailConfigurationUpdate:
                    {
                        if (ServerShiftHandoverEmailConfigurationUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerShiftHandoverEmailConfigurationUpdated(this,
                                new DomainEventArgs<ShiftHandoverEmailConfiguration>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.ShiftHandoverEmailConfigurationRemove:
                    {
                        if (ServerShiftHandoverEmailConfigurationRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerShiftHandoverEmailConfigurationRemoved(this,
                                new DomainEventArgs<ShiftHandoverEmailConfiguration>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.WorkPermitLubesCreate:
                    {
                        if (ServerWorkPermitLubesCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerWorkPermitLubesCreated(this, new DomainEventArgs<WorkPermitLubes>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.WorkPermitLubesUpdate:
                    {
                        if (ServerWorkPermitLubesUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerWorkPermitLubesUpdated(this, new DomainEventArgs<WorkPermitLubes>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.WorkPermitLubesRemove:
                    {
                        if (ServerWorkPermitLubesRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerWorkPermitLubesRemoved(this, new DomainEventArgs<WorkPermitLubes>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.PermitRequestLubesCreate:
                    {
                        if (ServerPermitRequestLubesCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerPermitRequestLubesCreated(this, new DomainEventArgs<PermitRequestLubes>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.PermitRequestLubesUpdate:
                    {
                        if (ServerPermitRequestLubesUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerPermitRequestLubesUpdated(this, new DomainEventArgs<PermitRequestLubes>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.PermitRequestLubesRemove:
                    {
                        if (ServerPermitRequestLubesRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerPermitRequestLubesRemoved(this, new DomainEventArgs<PermitRequestLubes>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.SapAutoImportConfigurationEnabled:
                    {
                        if (ServerSapAutoImportConfigurationEnabled != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerSapAutoImportConfigurationEnabled(this,
                                new DomainEventArgs<SapAutoImportConfiguration>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.SapAutoImportConfigurationUpdated:
                    {
                        if (ServerSapAutoImportConfigurationUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerSapAutoImportConfigurationUpdated(this,
                                new DomainEventArgs<SapAutoImportConfiguration>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.SapAutoImportConfigurationDisabled:
                    {
                        if (ServerSapAutoImportConfigurationDisabled != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerSapAutoImportConfigurationDisabled(this,
                                new DomainEventArgs<SapAutoImportConfiguration>(domain));
                        }
                        break;
                    }

                    case ApplicationEvent.DirectiveCreate:
                    {
                        if (ServerDirectiveCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerDirectiveCreated(this, new DomainEventArgs<Directive>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.DirectiveUpdate:
                    {
                        if (ServerDirectiveUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerDirectiveUpdated(this, new DomainEventArgs<Directive>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.DirectiveRemove:
                    {
                        if (ServerDirectiveRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerDirectiveRemoved(this, new DomainEventArgs<Directive>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.DirectiveMarkedAsReadByCurrentUser:
                    {
                        if (ServerDirectiveMarkedAsReadByCurrentUser != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerDirectiveMarkedAsReadByCurrentUser(this, new DomainEventArgs<Directive>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.OpmExcursionCreate:
                    {
                        if (ServerOpmExcursionCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerOpmExcursionCreated(this, new DomainEventArgs<OpmExcursion>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.OpmExcursionUpdate:
                    {
                        if (ServerOpmExcursionUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerOpmExcursionUpdated(this, new DomainEventArgs<OpmExcursion>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.OpmExcursionRemove:
                    {
                        if (ServerOpmExcursionRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerOpmExcursionRemoved(this, new DomainEventArgs<OpmExcursion>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.OpmToeDefinitionCreate:
                    {
                        if (ServerOpmToeDefinitionCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerOpmToeDefinitionCreated(this, new DomainEventArgs<OpmToeDefinition>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.OpmToeDefinitionUpdate:
                    {
                        if (ServerOpmToeDefinitionUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerOpmToeDefinitionUpdated(this, new DomainEventArgs<OpmToeDefinition>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.OpmToeDefinitionRemove:
                    {
                        if (ServerOpmToeDefinitionRemoved != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerOpmToeDefinitionRemoved(this, new DomainEventArgs<OpmToeDefinition>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.OpmExcursionImportStatusUpdate:
                    {
                        if (ServerOpmExcursionImportStatusUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerOpmExcursionImportStatusUpdated(this,
                                new DomainEventArgs<OpmExcursionImportStatusDTO>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.OpmExcursionItemRefresh:
                    {
                        if (ServerOpmExcursionItemRefresh != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerOpmExcursionItemRefresh(this, new DomainEventArgs<Site>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.OpmExcursionBatchCreate:
                    {
                        if (ServerOpmExcursionBatchCreated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerOpmExcursionBatchCreated(this, new DomainEventArgs<OpmExcursionBatch>(domain));
                        }
                        break;
                    }
                    case ApplicationEvent.OpmExcursionBatchUpdate:
                    {
                        if (ServerOpmExcursionBatchUpdated != null)
                        {
                            LogReleventEvent(domain, appEvent);
                            ServerOpmExcursionBatchUpdated(this, new DomainEventArgs<OpmExcursionBatch>(domain));
                        }
                        break;
                    }
                    default:
                    {
                        logger.InfoFormat("No action found for Event {0}.  So skipping it.", appEvent);
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                // NOTE: Eric: If we don't catch this exception, it will propagate back to the server
                //       trying to notify this client. We should handle these problems on the client side.
                logger.Error("Error dispatching server event:<" + appEvent + ">", exception);
            }
        }

        private void SubscribeToEvents(List<FunctionalLocation> filterFunctionalLocations, List<FunctionalLocation> workPermitEdmontonFunctionalLocations, List<FunctionalLocation> rootFlocSetForRestrictions, List<long> clientReadableVisibilityGroupIds, EventConnectDisconnectReason reason)
        {
            connected = true;
            var siteId = filterFunctionalLocations.Count == 0 ? null : filterFunctionalLocations[0].Site.Id;

            logger.Info("Hooking up service events to our remote event repeater methods.");
            eventService.Subscribe(clientServiceHostAddress, filterFunctionalLocations,
                workPermitEdmontonFunctionalLocations, rootFlocSetForRestrictions, clientReadableVisibilityGroupIds, siteId, machineName, reason);
            logger.Info("Finished hooking up service events to our remote event repeater methods.");
        }

        public void TimerFiredCallback(object state)
        {
            if (Monitor.TryEnter(timerLockObject))
            {
                try
                {
                    var domainEventArgs = remoteEventQueue.Dequeue();
                    while (domainEventArgs != null)
                    {
                        Dispatch(domainEventArgs);
                        domainEventArgs = remoteEventQueue.Dequeue();
                    }
                }
                catch (Exception e)
                {
                    logger.Error("Error during timer callback: " + e);
                }
                finally
                {
                    Monitor.Exit(timerLockObject);
                }
            }
        }

        private void Dispatch(DomainEventArgs<DomainObject> e)
        {
            var appEvent = e.ApplicationEventType;
            var domainObject = e.SelectedItem;
            Dispatch(appEvent, domainObject);
        }

        private static void LogReleventEvent(DomainObject domain, ApplicationEvent appEvent)
        {
            if (logger.IsDebugEnabled)
            {
                var domainObjectId = domain == null || !domain.Id.HasValue
                    ? "null"
                    : domain.Id.Value.ToString(CultureInfo.InvariantCulture);
                logger.DebugFormat("Received and processing event {0} with Domain Object id {1}", appEvent,
                    domainObjectId);
            }
        }


        public event ServiceEventHandler<BaseEdmontonForm> ServerCSDMarkedAsReadByCurrentUser;
    }
}