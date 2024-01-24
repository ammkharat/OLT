using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using log4net;

namespace Com.Suncor.Olt.Remote.Services
{
    public class DeviationAlertService : IDeviationAlertService
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<DeviationAlertService>();
        private readonly IDeviationAlertDTODao deviationAlertDtoDao;
        private readonly IUserService userService;
        private readonly ITimeDao timeDao;
        private readonly IDeviationAlertDao deviationAlertDao;
        private readonly IPlantHistorianService historianService;
        private readonly ISiteConfigurationDao siteConfigurationDao;
        private readonly IEditHistoryService editHistoryService;

        public DeviationAlertService() : this(
            new UserService(),
            new PlantHistorianService(),
            new EditHistoryService())
        {
        }

        public DeviationAlertService(
            IUserService userService,
            IPlantHistorianService historianService,
            IEditHistoryService editHistoryService)
        {
            deviationAlertDtoDao = DaoRegistry.GetDao<IDeviationAlertDTODao>();
            this.userService = userService;
            timeDao = DaoRegistry.GetDao<ITimeDao>();
            deviationAlertDao = DaoRegistry.GetDao<IDeviationAlertDao>();
            this.historianService = historianService;
            siteConfigurationDao = DaoRegistry.GetDao<ISiteConfigurationDao>();
            this.editHistoryService = editHistoryService;
        }

        public DateTime? EvaluateDefinition(RestrictionDefinition definition, DateTime currentInvocationDateTime)
        {
            DateTime? lastSuccessfulAlertDateTime = null;

            if (!definition.IsActive)
            {
                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("Restriction definition {0} with ID {1} and status {2} not evaluated as it is inactive or deleted.",
                        definition.Name, definition.Id, definition.Status.Name);
                }
                lastSuccessfulAlertDateTime = currentInvocationDateTime;
            }
            else
            {
                User systemUser = userService.GetRemoteAppUser();
                DateTime currentTimeAtSite = timeDao.GetTime(definition.FunctionalLocation.Site.TimeZone);

                List<Range<DateTime>> alertHours = definition.GetAlertHours(currentInvocationDateTime);
                foreach (Range<DateTime> alertHour in alertHours)
                {                    
                    lastSuccessfulAlertDateTime = EvaluateDefinitionForAlertHour(
                            definition, alertHour, currentTimeAtSite, systemUser, lastSuccessfulAlertDateTime);                                       
                }
            }

            return lastSuccessfulAlertDateTime;
        }

        private DateTime? EvaluateDefinitionForAlertHour(RestrictionDefinition definition, Range<DateTime> alertHour, DateTime currentTimeAtSite, User systemUser, DateTime? lastSuccessfulAlertDateTime)
        {
            DateTime fromDateTime = alertHour.LowerBound;
            DateTime toDateTime = alertHour.UpperBound;

            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("Creating alert for restriction definition {0}({1}) from {2} to {3}.",
                    definition.Name, definition.Id, fromDateTime, toDateTime);
            }

            int? measurementValue = ReadTagValue(definition.MeasurementTagInfo, fromDateTime, toDateTime);          
                    
            int? productionValue = GetProductionValue(definition, fromDateTime, toDateTime);           

            if (!measurementValue.HasValue)
            {
                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("No measurement tag value found for {4} for restriction definition {0}({1}) from {2} to {3}.",
                        definition.Name, definition.Id, fromDateTime, toDateTime, definition.MeasurementTagInfo.Name);
                }                        
            }
            else if (!productionValue.HasValue)
            {
                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("No production value found for {4} for restriction definition {0}({1}) from {2} to {3}.",
                        definition.Name, definition.Id, fromDateTime, toDateTime,
                        definition.ProductionTargetTagInfo != null ? definition.ProductionTargetTagInfo.Name : "");
                }
            }
            else
            {
                DeviationAlert alert = definition.CreateDeviationAlert(
                    fromDateTime,
                    toDateTime,
                    measurementValue,
                    productionValue,
                    currentTimeAtSite,
                    systemUser);
                Insert(alert);

                if (!lastSuccessfulAlertDateTime.HasValue || toDateTime > lastSuccessfulAlertDateTime.Value)
                {
                    lastSuccessfulAlertDateTime = toDateTime;
                }
            }
            return lastSuccessfulAlertDateTime;
        }

        private int? GetProductionValue(RestrictionDefinition definition, DateTime fromDateTime, DateTime toDateTime)
        {
            int? productionValue = null;

            if (definition.ProductionTargetValue.HasValue)
            {
                productionValue = definition.ProductionTargetValue.Value;
            }
            else if (definition.ProductionTargetTagInfo != null)
            {
                productionValue = ReadTagValue(definition.ProductionTargetTagInfo, fromDateTime, toDateTime);
            }

            return productionValue;
        }

        private int? ReadTagValue(TagInfo tagInfo, DateTime fromDateTime, DateTime toDateTime)
        {
            try
            {
                decimal? value = historianService.ReadRestrictionDeviationTagValue(tagInfo,fromDateTime, toDateTime);

                if (value != null)
                {
                    return Convert.ToInt32(value);
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void Insert(DeviationAlert alert)
        {
            deviationAlertDao.Insert(alert);
            ServiceUtility.PushEventIntoQueue(ApplicationEvent.DeviationAlertCreate, alert);
        }

        public DeviationAlert QueryById(long id)
        {
            return deviationAlertDao.QueryById(id);
        }

        public List<DeviationAlertDTO> QueryDTOsByFLOCAndDaysPrecedingGivenDate(IFlocSet flocSet, Range<Date> dateRange)
        {
            DateTime? fromDate = null;
            DateTime? toDate = null;

            if (dateRange != null)
            {
                fromDate = dateRange.LowerBound.CreateDateTime(Time.START_OF_DAY);
                toDate = dateRange.UpperBound.CreateDateTime(Time.END_OF_DAY);
            }

            return deviationAlertDtoDao.QueryByFunctionalLocationsAndTimePeriod(flocSet, fromDate, toDate);
        }

        public List<DeviationAlertDTO> QueryDTOsByFLOCAndShift(
            IFlocSet flocSet, UserShift userShift)
        {
            return deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                flocSet, userShift.StartDateTime, userShift.EndDateTime);
        }

        public bool IsWithinDaysToEditResponse(Site site, List<DeviationAlertDTO> alerts)
        {
            SiteConfiguration siteConfiguration = siteConfigurationDao.QueryBySiteId(site.IdValue);
            int days = siteConfiguration.DaysToEditDeviationAlerts;

            DateTime currentTimeAtSite = timeDao.GetTime(site.TimeZone);
            DateTime startTime = currentTimeAtSite.SubtractDays(days);

            return alerts.TrueForAll(alert => alert.StartDateTime >= startTime);
        }

        public List<NotifiedEvent> UpdateDeviationAlertComment(DeviationAlert deviationAlert, DateTime lastModifiedDate, User lastModifiedBy)
        {           
            deviationAlert.LastModifiedBy = lastModifiedBy;
            deviationAlert.LastModifiedDateTime = lastModifiedDate;

            deviationAlertDao.UpdateDeviationAlertComment(deviationAlert);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.DeviationAlertUpdate, deviationAlert));
            return notifiedEvents;
        }

        public List<NotifiedEvent> UpdateDeviationAlertResponse(DeviationAlert deviationAlert, DateTime lastModifiedDate, User lastModifiedBy)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            if (deviationAlert.DeviationAlertResponse != null)
            {
                deviationAlert.DeviationAlertResponse.LastModifiedBy = lastModifiedBy;
                deviationAlert.DeviationAlertResponse.LastModifiedDateTime = lastModifiedDate;

                deviationAlertDao.UpdateDeviationAlertResponse(deviationAlert);
                editHistoryService.TakeSnapshot(deviationAlert.DeviationAlertResponse);

                notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.DeviationAlertUpdate, deviationAlert));
            }

            return notifiedEvents;
        }
      
        public DeviationAlert GetLastRespondedToAlert(RestrictionDefinition restrictionDefinition)
        {
            return deviationAlertDao.GetLastRespondedToAlert(restrictionDefinition);
        }
    }
}
