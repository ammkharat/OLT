using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    /// <summary>
    /// Used to Save and Retrieve SAP Notification objects from the data tier
    /// </summary>   
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)] 
    public class SAPNotificationService : ISAPNotificationService
    {
        private readonly ISAPNotificationDao dao;
        private readonly ISAPNotificationDTODao dtoDao;        
        private readonly ITimeService timeService;
        private readonly ILogService logService;

        public SAPNotificationService()
            : this(DaoRegistry.GetDao<ISAPNotificationDao>(),
                   DaoRegistry.GetDao<ISAPNotificationDTODao>(),                   
                   new LogService(),
                   new TimeService())
        {
        }

        public SAPNotificationService(
            ISAPNotificationDao dao, 
            ISAPNotificationDTODao dtoDao,            
            ILogService logService,
            ITimeService timeService)
        {
            this.dao = dao;
            this.dtoDao = dtoDao;            
            this.timeService = timeService;
            this.logService = logService;
        }
        
        public List<SAPNotificationDTO> QueryDTOsByUnitLevelFunctionalLocationsAndDateRange(
            IFlocSet flocSet, DateTime startDateTime, DateTime endDateTime)
        {
            return dtoDao.QueryByUnitLevelFunctionalLocationsAndDateRange(flocSet, startDateTime, endDateTime);
        }

        /// <summary>
        /// Query for a specific SAP Notification given an id
        /// </summary>
        /// <param name="id">ID to look for</param>
        /// <returns>SAP Notification object</returns>
        public SAPNotification QueryById(long id)
        {
            return dao.QueryById(id);
        }

        /// <summary>
        /// Query for a specific SAP Notification given a notification number
        /// </summary>
        /// <param name="notificationNumber">notification number to use for lookup</param>
        /// <returns>SAP notification object matching number</returns>
        public SAPNotification QueryByNotificationNumber(string notificationNumber)
        {
            return dao.QueryByNotificationNumber(notificationNumber);
        }

        /// <summary>
        /// Inserts an SAP Notification object and returns the inserted object (with id)
        /// </summary>
        /// <param name="sapNotification">SAP Notification to insert</param>
        /// <returns>Inserted SAP Notification object</returns>
        public SAPNotification Insert(SAPNotification sapNotification)
        {
            SAPNotification result = dao.Insert(sapNotification);

            ServiceUtility.PushEventIntoQueue(ApplicationEvent.SapNotificationCreate, sapNotification);
            return result;
        }

        /// <summary>
        /// Updates the SAP Notification object associated with Notification Number
        /// </summary>
        /// <param name="sapNotification">SAP Notification object to insert</param>
        public List<NotifiedEvent> UpdateByNotificationNumber(SAPNotification sapNotification)
        {
            dao.UpdateByNotificationNumber(sapNotification);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.SapNotificationUpdate, sapNotification));
            return notifiedEvents;
        }

        public List<NotifiedEvent> ProcessNotificationAndCreateLog(
            SAPNotification sapNotification, User currentUser, ShiftPattern shiftPattern, bool isOperatingEngineerLog, 
            Role currentUserRole, WorkAssignment currentUserWorkAssignment)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            DateTime currentTimeAtSite = timeService.GetTime(sapNotification.FunctionalLocation.Site.TimeZone);            

            Log log = sapNotification.CreateLogFromNotification(
                currentUser, shiftPattern, isOperatingEngineerLog, currentTimeAtSite, 
                currentUserRole, currentUserWorkAssignment);

            notifiedEvents.AddRange(logService.Insert(log));

            //update the sap notification object
            sapNotification.Processed();
            dao.UpdateByNotificationNumber(sapNotification);

            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.SapNotificationProcess, sapNotification));

            return notifiedEvents;
        }
    }
}
