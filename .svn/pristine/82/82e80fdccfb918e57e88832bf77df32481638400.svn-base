using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Services
{
    /// <summary>
    ///     Used to Save and Retrieve SAP Notification objects from the data tier
    /// </summary>
    [ServiceContract]
    public interface ISAPNotificationService
    {
        /// <summary>
        ///     Query All SAP Notification DTOs by given functional Locations and within the provided shift
        /// </summary>
        /// <param name="functionalLocations">List of functional locations to look for</param>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns>List of SAP notifications</returns>
        [OperationContract]
        List<SAPNotificationDTO> QueryDTOsByUnitLevelFunctionalLocationsAndDateRange(
            IFlocSet flocSet, DateTime startDateTime, DateTime endDateTime);

        /// <summary>
        ///     Query for a specific SAP Notification given an id
        /// </summary>
        /// <param name="id">ID to look for</param>
        /// <returns>SAP Notification object</returns>
        [OperationContract]
        SAPNotification QueryById(long id);

        /// <summary>
        ///     Query for a specific SAP Notification given a notification number
        /// </summary>
        /// <param name="notificationNumber">notification number to use for lookup</param>
        /// <returns>SAP notification object matching number</returns>
        [OperationContract]
        SAPNotification QueryByNotificationNumber(string notificationNumber);

        /// <summary>
        ///     Inserts an SAP Notification object and returns the inserted object (with id)
        /// </summary>
        /// <param name="sapNotification">SAP Notification to insert</param>
        /// <returns>Inserted SAP Notification object</returns>
        [OperationContract]
        SAPNotification Insert(SAPNotification sapNotification);

        /// <summary>
        ///     Updates the SAP Notification object associated with Notification Number
        /// </summary>
        /// <param name="sapNotification">SAP Notification object to insert</param>
        [OperationContract]
        List<NotifiedEvent> UpdateByNotificationNumber(SAPNotification sapNotification);

        /// <summary>
        ///     Process Notification from a SAP object (isprocessed=true) and create a new log (lastmodified by sapuser))
        /// </summary>
        [OperationContract]
        List<NotifiedEvent> ProcessNotificationAndCreateLog(SAPNotification sapNotification, User currentUser,
            ShiftPattern shiftPattern, bool isLogOperatingEngineerLog, Role currentUserRole,
            WorkAssignment currentUserWorkAssignment);
    }
}