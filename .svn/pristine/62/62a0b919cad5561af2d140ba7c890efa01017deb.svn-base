using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    // Note: Evict SiteConfiguration from the cache when any of the update methods are called;
    // causing the next query to retrieve the latest SiteConfiguration and add to the cache.
    public interface ISiteConfigurationDao : IDao
    {
        [CachedQueryById]
        SiteConfiguration QueryBySiteId(long siteId);

        SiteConfiguration QueryBySiteIdWithNoCaching(long siteId);

        [CachedInsertOrUpdate(false, false)]
        void Update(SiteConfiguration siteConfiguration);

      
        ///Sarika... Floc structure level changes...9Jan2017
        [CachedInsertOrUpdate(false, false)]
        void UPDATESiteConfigurationByAdministrator(long siteId, int ActionItemFlocLevel,
            int ShiftLogFlocLevel,
            int ShiftHandoverFlocLevel);

        [CachedInsertOrUpdate(false, false)]
        void UpdateSiteConfigurationPriorityPageConfiguration(SiteConfiguration siteConfiguration);

        // TODO: find all references to Update* methods below and convert/wrap them so they get
        // TODO: the site configuration and set the property values, then call Update(SiteConfiguration)
        // TODO: in order to evict the cache and cause the SiteConfiguration data to be reloaded.

        void UpdateDisplayLimits(long siteId, int actionItemDisplayLimit, int shiftLogDisplayLimit,
            int shiftHandoversDisplayLimit, int deviationAslertDisplayLimit, int workPermitsDisplayLimitBackwards,
            int workPermitDisplayLimitForwards, int labAlertDisplayLimit, int cokerCardsDisplayLimit,
            int daysToDisplayPermitRequestsBackwards, int daysToDisplayPermitRequestsForwards,
            int daysToDisplayElectronicFormsBackwards, int? daysToDisplayElectronicFormsForwards,
            int daysToDisplaySAPNotificationsBackwards, int daysToDisplayDirectivesBackwards,
            int? toDisplayDirectivesForwards, int? daysToDisplayEvents,
            int daysToDisplayDocumentSuggestionFormsBackwards, int? daysToDisplayDocumentSuggestionFormsForwards);

        void UpdateWorkPermitArchivalProcess(long siteId,
            int daysBeforeArchivingClosedWorkPermits,
            int daysBeforeDeletingPendingWorkPermits,
            int daysBeforeClosingIssuedWorkPermits);

        void UpdateActionItemSettings(long siteId,
            bool autoApproveWorkOrderActionItemDefinition,
            bool autoApproveSAPAMActionItemDefinition,
            bool autoApproveSAPMCActionItemDefinition,
            bool requireLogForActionItemResponse,
            bool actionItemRequiresApprovalDefaultValue,
            bool actionItemRequiresResponseDefaultValue);

        void UpdateTargetDefinitionAutoReApprovalConfiguration(
            TargetDefinitionAutoReApprovalConfiguration targetDefConfig);

        void UpdateActionItemDefinitionAutoReApprovalConfiguration(
            ActionItemDefinitionAutoReApprovalConfiguration aidConfig);

        void UpdateRestrictionReportingLimits(long siteId, int daysToEditDeviationAlerts);

        void UpdateDORCutoffTime(long siteId, Time dorCutoffTime);

        void UpdateHideDORCommentsTextBox(long siteId, bool hideDORCommentsTextBox);

        void UpdateLabAlertRetryAttemptLimit(long siteId, int retryAttemptLimit);

        List<WorkPermitLoggableStatus> QueryWorkPermitStatusesForClosingBySite(long siteId);

        bool SiteIsUsingLogBasedDirectives(long siteId);
    }
}