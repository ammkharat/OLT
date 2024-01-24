using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface ISiteConfigurationService
    {
        [OperationContract]
        void UpdateDisplayLimits(long siteId, int actionItemDisplayLimit, int shiftLogDisplayLimit,
            int daysToDisplayShiftHandovers, int deviationAlertDisplayLimit, int workPermitDisplayLimitBackwards,
            int workPermitDisplayLimitForwards, int labAlertDisplayLimit, int cokerCardsDisplayLimit,
            int daysToDisplayPermitRequestsBackwards, int daysToDisplayPermitRequestsForwards,
            int daysToDisplayElectronicFormsBackwards, int? daysToDisplayElectronicFormsForwards,
            int daysToDisplaySAPNotificationsBackwards, int daysToDisplayDirectivesBackwards,
            int? daysToDisplayDirectivesForwards, int? daysToDisplayEvents,
            int daysToDisplayDocumentSuggestionFormsBackwards, int? daysToDisplayDocumentSuggestionFormsForwards);

        [OperationContract]
        void UpdateWorkPermitArchivalProcess(long siteId,
            int daysBeforeArchivingClosedWorkPermits,
            int daysBeforeDeletingPendingWorkPermits,
            int daysBeforeClosingIssuedWorkPermits);

        [OperationContract]
        void UpdateActionItemSettings(long siteId,
            bool autoApproveWorkOrderActionItemDefinition,
            bool autoApproveSAPAMActionItemDefinition,
            bool autoApproveSAPMCActionItemDefinition,
            bool requireLogForActionItemResponse,
            bool actionItemRequiresApprovalDefaultValue,
            bool actionItemRequiresResponseDefaultValue);

        [OperationContract]
        void UpdateTargetDefinitionAutoReApprovalConfiguration(
            TargetDefinitionAutoReApprovalConfiguration targetDefConfig);

        [OperationContract]
        void UpdateActionItemDefinitionAutoReApprovalConfiguration(
            ActionItemDefinitionAutoReApprovalConfiguration aidConfig);

        [OperationContract]
        void UpdateRestrictionReportingLimits(long siteId, int daysToEditDeviationAlerts);

        [OperationContract]
        void UpdateDORCutoffTime(long siteId, Time dorCutoffTime);

        [OperationContract]
        SiteConfiguration QueryBySiteId(long siteId);

        [OperationContract]
        SiteConfiguration QueryBySiteIdWithNoCaching(long siteId);

        [OperationContract]
        void UpdateLabAlertRetryAttemptLimit(long siteId, int retryAttemptLimit);

        [OperationContract]
        void UpdateSiteConfigurationPriorityPageConfiguration(SiteConfiguration siteConfiguration);

        [OperationContract]
        List<WorkPermitLoggableStatus> QueryWorkPermitStatusesForClosingBySite(long siteId);

        [OperationContract]
        SiteConfigurationDefaults QuerySiteConfigurationDefaultsBySiteId(long siteId);

        [OperationContract]
        void Update(SiteConfiguration siteConfiguration);

        [OperationContract]
        SapAutoImportConfiguration QuerySapAutoImportConfiguration(long siteId);

        [OperationContract]
        void EnableOrUpdateSapAutoImportConfiguration(long siteId, Time importTime);

        [OperationContract]
        void DisableSapAutoImportConfiguration(long siteId);

        [OperationContract]
        bool SiteIsUsingLogBasedDirectives(long siteId);

        //Sarika --Floc level settings - 9 jan 2017
        [OperationContract]
        void UPDATESiteConfigurationByAdministrator(long siteId, int ActionItemFlocLevel,int ShiftLogFlocLevel,int ShiftHandoverFlocLevel);
    }
}