using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    /// <summary>
    /// SAP Notification Data access object
    /// </summary>
    public interface ISAPNotificationDao : IDao
    {
        /// <summary>
        /// Query for the specific SAP notification record associated with the Notification Number
        /// </summary>
        /// <param name="notificationNumber">Notification number to look for</param>
        /// <returns>SAP notification object</returns>
        SAPNotification QueryByNotificationNumber(string notificationNumber);

        /// <summary>
        /// Query for the specific SAP notification record associated with the ID
        /// </summary>
        /// <param name="id">ID to check in the database</param>
        /// <returns>SAP notification object</returns>
        SAPNotification QueryById(long id);

        /// <summary>
        /// Inserts an SAP notificatioin record into the database
        /// </summary>
        /// <param name="sAPNotification">SAP Notification object to insert</param>
        /// <returns>Newly added SAP notification object</returns>
        SAPNotification Insert(SAPNotification sAPNotification);

        /// <summary>
        /// Updates the sapNotification object by the Notification Number
        /// </summary>
        /// <param name="sapNotification">The SAP notification object to update</param>
        void UpdateByNotificationNumber(SAPNotification sapNotification);

    }
}