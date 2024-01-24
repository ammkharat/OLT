using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class SiteConfigurationService : ISiteConfigurationService
    {
        private readonly ISapAutoImportConfigurationDao sapAutoImportConfigurationDao;
        private readonly ISiteConfigurationDao siteConfigurationDao;
        private readonly ISiteConfigurationDefaultsDao siteConfigurationDefaultsDao;
        private readonly ISiteDao siteDao;
        private readonly ITimeService timeService;

        public SiteConfigurationService()
        {
            siteConfigurationDao = DaoRegistry.GetDao<ISiteConfigurationDao>();
            siteConfigurationDefaultsDao = DaoRegistry.GetDao<ISiteConfigurationDefaultsDao>();
            sapAutoImportConfigurationDao = DaoRegistry.GetDao<ISapAutoImportConfigurationDao>();
            siteDao = DaoRegistry.GetDao<ISiteDao>();
            timeService = new TimeService();
        }

        public void UpdateWorkPermitArchivalProcess(long siteId, int daysBeforeArchivingClosedWorkPermits,
            int daysBeforeDeletingPendingWorkPermits, int daysBeforeClosingIssuedWorkPermits)
        {
            siteConfigurationDao.UpdateWorkPermitArchivalProcess(siteId, daysBeforeArchivingClosedWorkPermits,
                daysBeforeDeletingPendingWorkPermits, daysBeforeClosingIssuedWorkPermits);
        }

        public void UpdateActionItemSettings(long siteId, bool autoApproveWorkOrderActionItemDefinition,
            bool autoApproveSAPAMActionItemDefinition, bool autoApproveSAPMCActionItemDefinition,
            bool requireLogForActionItemResponse, bool actionItemRequiresApprovalDefaultValue,
            bool actionItemRequiresResponseDefaultValue)
        {
            siteConfigurationDao.UpdateActionItemSettings(
                siteId, autoApproveWorkOrderActionItemDefinition,
                autoApproveSAPAMActionItemDefinition, autoApproveSAPMCActionItemDefinition,
                requireLogForActionItemResponse, actionItemRequiresApprovalDefaultValue,
                actionItemRequiresResponseDefaultValue);
        }

        public void UpdateTargetDefinitionAutoReApprovalConfiguration(
            TargetDefinitionAutoReApprovalConfiguration targetDefConfig)
        {
            siteConfigurationDao.UpdateTargetDefinitionAutoReApprovalConfiguration(targetDefConfig);
        }

        public void UpdateActionItemDefinitionAutoReApprovalConfiguration(
            ActionItemDefinitionAutoReApprovalConfiguration aidConfig)
        {
            siteConfigurationDao.UpdateActionItemDefinitionAutoReApprovalConfiguration(aidConfig);
        }

        public void UpdateRestrictionReportingLimits(long siteId, int daysToEditDeviationAlerts)
        {
            siteConfigurationDao.UpdateRestrictionReportingLimits(siteId, daysToEditDeviationAlerts);
        }

        public void UpdateDORCutoffTime(long siteId, Time dorCutoffTime)
        {
            siteConfigurationDao.UpdateDORCutoffTime(siteId, dorCutoffTime);
        }

        public SiteConfiguration QueryBySiteId(long siteId)
        {
            return siteConfigurationDao.QueryBySiteId(siteId);
        }

        public SiteConfiguration QueryBySiteIdWithNoCaching(long siteId)
        {
            return siteConfigurationDao.QueryBySiteIdWithNoCaching(siteId);
        }

        public void UpdateLabAlertRetryAttemptLimit(long siteId, int retryAttemptLimit)
        {
            siteConfigurationDao.UpdateLabAlertRetryAttemptLimit(siteId, retryAttemptLimit);
        }

        public void UpdateSiteConfigurationPriorityPageConfiguration(SiteConfiguration siteConfiguration)
        {
            siteConfigurationDao.UpdateSiteConfigurationPriorityPageConfiguration(siteConfiguration);
        }

        public List<WorkPermitLoggableStatus> QueryWorkPermitStatusesForClosingBySite(long siteId)
        {
            return siteConfigurationDao.QueryWorkPermitStatusesForClosingBySite(siteId);
        }

        public SiteConfigurationDefaults QuerySiteConfigurationDefaultsBySiteId(long siteId)
        {
            return siteConfigurationDefaultsDao.QueryBySiteId(siteId);
        }

        public void Update(SiteConfiguration siteConfiguration)
        {
            siteConfigurationDao.Update(siteConfiguration);
        }

        ///Sarika... Floc structure level changes...9 Jan 2017
        public void UPDATESiteConfigurationByAdministrator(long siteId, int ActionItemFlocLevel,int ShiftLogFlocLevel,int ShiftHandoverFlocLevel)
        {
            siteConfigurationDao.UPDATESiteConfigurationByAdministrator(siteId,ActionItemFlocLevel,ShiftLogFlocLevel,ShiftHandoverFlocLevel);
        }

        
        
        public SapAutoImportConfiguration QuerySapAutoImportConfiguration(long siteId)
        {
            return sapAutoImportConfigurationDao.QueryBySiteId(siteId);
        }

        public void EnableOrUpdateSapAutoImportConfiguration(long siteId, Time importTime)
        {
            var site = siteDao.QueryById(siteId);
            var dateNow = new Date(timeService.GetTime(site.TimeZone));

            var configuration = sapAutoImportConfigurationDao.QueryBySiteId(siteId);

            if (configuration.Schedule == null)
            {
                configuration.Schedule = new RecurringDailySchedule(dateNow, null, importTime, importTime, 1, site);
                sapAutoImportConfigurationDao.Update(configuration);
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.SapAutoImportConfigurationEnabled, configuration);
            }
            else
            {
                configuration.Schedule.StartDate = dateNow;
                configuration.Schedule.StartTime = importTime;
                configuration.Schedule.EndTime = importTime;
                sapAutoImportConfigurationDao.Update(configuration);
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.SapAutoImportConfigurationUpdated, configuration);
            }
        }

        public void DisableSapAutoImportConfiguration(long siteId)
        {
            var configuration = sapAutoImportConfigurationDao.QueryBySiteId(siteId);

            if (configuration.Schedule != null)
            {
                sapAutoImportConfigurationDao.Disable(configuration);
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.SapAutoImportConfigurationDisabled, configuration);
            }
        }

        public bool SiteIsUsingLogBasedDirectives(long siteId)
        {
            return siteConfigurationDao.SiteIsUsingLogBasedDirectives(siteId);
        }

        public void UpdateDisplayLimits(long siteId, int actionItemDisplayLimit, int shiftLogDisplayLimit,
            int shiftHandoversDisplayLimit, int deviationAlertDisplayLimit, int workPermitDisplayLimitBackwards,
            int workPermitDisplayLimitForwards, int labAlertDisplayLimit, int cokerCardsDisplayLimit,
            int daysToDisplayPermitRequestsBackwards, int daysToDisplayPermitRequestsForwards,
            int daysToDisplayElectronicFormsBackwards, int? daysToDisplayElectronicFormsForwards,
            int daysToDisplaySAPNotificationsBackwards, int daysToDisplayDirectivesBackwards,
            int? daysToDisplayDirectivesForwards, int? daysToDisplayEvents,
            int daysToDisplayDocumentSuggestionFormsBackwards, int? daysToDisplayDocumentSuggestionFormsForwards)
        {
            siteConfigurationDao.UpdateDisplayLimits(
                siteId,
                actionItemDisplayLimit,
                shiftLogDisplayLimit,
                shiftHandoversDisplayLimit,
                deviationAlertDisplayLimit,
                workPermitDisplayLimitBackwards,
                workPermitDisplayLimitForwards,
                labAlertDisplayLimit,
                cokerCardsDisplayLimit,
                daysToDisplayPermitRequestsBackwards,
                daysToDisplayPermitRequestsForwards,
                daysToDisplayElectronicFormsBackwards,
                daysToDisplayElectronicFormsForwards,
                daysToDisplaySAPNotificationsBackwards,
                daysToDisplayDirectivesBackwards,
                daysToDisplayDirectivesForwards,
                daysToDisplayEvents,
                daysToDisplayDocumentSuggestionFormsBackwards,
                daysToDisplayDocumentSuggestionFormsForwards);
        }
    }
}