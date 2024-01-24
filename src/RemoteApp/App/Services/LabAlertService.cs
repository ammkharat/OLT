﻿using System;
﻿using System.Collections.Generic;
﻿using Com.Suncor.Olt.Common.Domain;
﻿using Com.Suncor.Olt.Common.Domain.FlocSet;
﻿using Com.Suncor.Olt.Common.Domain.LabAlert;
﻿using Com.Suncor.Olt.Common.DTO;
﻿using Com.Suncor.Olt.Common.Services;
﻿using Com.Suncor.Olt.Common.Utility;
﻿using Com.Suncor.Olt.Remote.DataAccess;
﻿using Com.Suncor.Olt.Remote.DataAccess.DTO;
﻿using Com.Suncor.Olt.Remote.DataAccess.Domain;
﻿using log4net;

namespace Com.Suncor.Olt.Remote.Services
{
    public class LabAlertService : ILabAlertService
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<LabAlertService>();

        private readonly IUserService userService;

        private readonly ITimeDao timeDao;
        private readonly ILabAlertDao labAlertDao;
        private readonly ILabAlertDTODao labAlertDtoDao;
        private readonly IPlantHistorianService historianService;
        private readonly ILogService logService;
        
        public LabAlertService() : this(new UserService(), new PlantHistorianService(), new LogService())
        {            
        }

        public LabAlertService(IUserService userService, IPlantHistorianService historianService, ILogService logService)
        {
            this.userService = userService;
            this.historianService = historianService;
            this.logService = logService;

            timeDao = DaoRegistry.GetDao<ITimeDao>();
            labAlertDao = DaoRegistry.GetDao<ILabAlertDao>();
            labAlertDtoDao = DaoRegistry.GetDao<ILabAlertDTODao>();            
        }

        public bool EvaluateDefinition(LabAlertDefinition definition, DateTime? intendedScheduleExecutionTime)
        {
            try
            {                
                string debugString = string.Format("Evaluating Definition: {0}, {1}", definition.IdValue, definition.Name);
                logger.Debug(debugString);

                Site site = definition.FunctionalLocation.Site;
                DateTime currentTimeAtSite = timeDao.GetTime(site.TimeZone);            
          
                LabAlertCheckRangeCalculator rangeCalculator = 
                    new LabAlertCheckRangeCalculator(definition, intendedScheduleExecutionTime.Value);
            
                // 1. Determine the range to check
                DateTime fromRange = rangeCalculator.FromDateTime;            
                DateTime toRange = rangeCalculator.ToDateTime;
            
                // 2. Check if samples are missing for the given range
                int minimumNumberOfSamples = definition.MinimumNumberOfSamples;
                int actualNumberOfSamples = GetActualNumberOfSamples(definition.TagInfo, fromRange, toRange);                

                // 3. Fire the alert if needed.
                if (actualNumberOfSamples < minimumNumberOfSamples)
                {
                    LabAlert labAlert = CreateAlert(definition, fromRange, toRange, currentTimeAtSite, actualNumberOfSamples);

                    LabAlert insertedAlert = labAlertDao.Insert(labAlert);
                    ServiceUtility.PushEventIntoQueue(ApplicationEvent.LabAlertCreate, insertedAlert);
                }
            }
            catch (Exception e)
            {
                logger.Error("There was an error evaluating the Lab Alert Definition.", e);
                return false;
            }

            return true;
        }

        private int GetActualNumberOfSamples(TagInfo tagInfo, DateTime fromRange, DateTime toRange)
        {
            List<TagValue> tagValues = historianService.ReadLabAlertTagValues(tagInfo, fromRange, toRange);

            OutputDebuggingInformationForTagValues(tagValues, fromRange, toRange);
          
            return tagValues.Count;
        }

        private static void OutputDebuggingInformationForTagValues(List<TagValue> tagValues, DateTime fromRange, DateTime toRange)
        {           
            logger.Debug(string.Format("Queried tags from {0} to {1}", fromRange, toRange));

            if (tagValues.Count == 0)
            {
                logger.Debug("There were no tags returned.");
            }

            foreach (TagValue tagValue in tagValues)
            {
                string tagString = string.Format("{0}, {1}, {2}", tagValue.TagName, tagValue.DateTime, tagValue.Value);
                logger.Debug(tagString);
            }                           
        }

        private LabAlert CreateAlert(LabAlertDefinition definition, DateTime fromRange, DateTime toRange, DateTime currentTimeAtSite, int actualNumberOfSamples)
        {           
            User systemUser = userService.GetRemoteAppUser();

            LabAlert labAlert = new LabAlert
                                    {
                                        Name = definition.Name,
                                        Description = definition.Description,
                                        FunctionalLocation = definition.FunctionalLocation,
                                        TagInfo = definition.TagInfo,
                                        MinimumNumberOfSamples = definition.MinimumNumberOfSamples,
                                        ActualNumberOfSamples = actualNumberOfSamples,
                                        LabAlertTagQueryRangeFromDateTime = fromRange,
                                        LabAlertTagQueryRangeToDateTime = toRange,
                                        ScheduleDescription = definition.ScheduleDescription,
                                        LabAlertDefinitionId = definition.IdValue,
                                        LastModifiedBy = systemUser,
                                        LastModifiedDate = currentTimeAtSite,
                                        CreatedDateTime = currentTimeAtSite
                                    };

            return labAlert;
        }

        public List<NotifiedEvent> UpdateStatusAndResponses(LabAlert labAlert, Log logForResponse)
        {
            labAlertDao.UpdateStatusAndResponses(labAlert);
            
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            if (logForResponse != null)
            {
                notifiedEvents.AddRange(logService.Insert(logForResponse));
            }
            
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.LabAlertUpdate, labAlert));

            return notifiedEvents;
        }

        public LabAlert QueryById(long id)
        {
            return labAlertDao.QueryById(id);
        }

        public List<LabAlertDTO> QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(
            IFlocSet flocSet, Range<Date> dateRange, List<LabAlertStatus> statuses)
        {
            return labAlertDtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(flocSet,
                                                                                                   new DateRange(dateRange),
                                                                                                   statuses);
        }

        public void InsertLabAlert(LabAlert labAlert)
        {
            LabAlert newLabAlert = labAlertDao.Insert(labAlert);
            ServiceUtility.PushEventIntoQueue(ApplicationEvent.LabAlertCreate, newLabAlert);
        }
    }
}
