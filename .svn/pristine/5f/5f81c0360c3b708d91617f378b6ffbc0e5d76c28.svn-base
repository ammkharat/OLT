using System;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class SAPNotificationDao : AbstractManagedDao, ISAPNotificationDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QuerySAPNotificationById";
        private const string INSERT_STORED_PROCEDURE = "InsertSAPNotification";
        private const string UPDATE__BY_NOTIFICATION_NUMBER_STORED_PROCEDURE = "UpdateSAPNotificationByNotificationNumber";
        private const string QUERY_BY_NOTIFICATION_NUMBER_STORED_PROCEDURE = "QuerySAPNotificationByNotificationNumber";


        private readonly IFunctionalLocationDao functionalLocationDao;

        public SAPNotificationDao()
        {
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
        }

        /// <summary>
        /// Query by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SAPNotification QueryById(long id)
        {
            return ManagedCommand.QueryById(id, (PopulateInstance<SAPNotification>) PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        /// <summary>
        /// Query by Notification Number
        /// </summary>
        /// <returns></returns>
        public SAPNotification QueryByNotificationNumber(string notificationNumber)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@NotificationNumber", notificationNumber);
            return command.QueryForSingleResult < SAPNotification>(PopulateInstance, QUERY_BY_NOTIFICATION_NUMBER_STORED_PROCEDURE);
        }

        /// <summary>
        /// Inserts a new SAPNotification into the database and returns the newly created object (with ID)
        /// </summary>
        /// <returns></returns>
        public SAPNotification Insert(SAPNotification sapNotification)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(sapNotification, AddInsertParameters, INSERT_STORED_PROCEDURE);
            sapNotification.Id = long.Parse(idParameter.Value.ToString());
            return sapNotification;
        }

        /// <summary>
        /// Set the parameters required for the Update statement (calls SetCommonAttributes)
        /// </summary>
        /// <param name="sapNotification"></param>
        /// <param name="command"></param>
        private static void AddUpdateParameters(SAPNotification sapNotification, SqlCommand command)
        {
            SetCommonAttributes(sapNotification, command);
        }

        /// <summary>
        /// Set the parameters required for the Insert statement (calls SetCommonAttributes)
        /// </summary>
        /// <param name="sapNotification"></param>
        /// <param name="command"></param>
        private static void AddInsertParameters(SAPNotification sapNotification, SqlCommand command)
        {
            SetCommonAttributes(sapNotification, command);
        }

        /// <summary>
        /// Populate a new SAPNotification object based on a SQLDataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private SAPNotification PopulateInstance(SqlDataReader reader)
        {
            FunctionalLocation functionalLocation = functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationId"));
            string description = reader.Get<string>("Description");
            string notificationType = reader.Get<string>("NotificationType");
            string shortText = reader.Get<string>("ShortText");
            string longText = reader.Get<string>("LongText");
            string incidentId = reader.Get<string>("IncidentId");
            DateTime creationDateTime = reader.Get<DateTime>("CreationDateTime");
            string notificationNumber = reader.Get<string>("NotificationNumber");
            if (notificationNumber.HasValue()) notificationNumber = notificationNumber.Trim();
            bool isProcessed = reader.Get<bool>("Processed");
            long? id = reader.Get<long?>("Id");
            string comments = reader.Get<string>("Comments");

            return new SAPNotification(id, functionalLocation,
                                       description, notificationType, shortText, longText, incidentId, creationDateTime,
                                       notificationNumber, isProcessed, comments);
        }

        /// <summary>
        /// Set the common attributes for the SQL Command from the domain object
        /// </summary>
        /// <param name="sapNotification"></param>
        /// <param name="command"></param>
        private static void SetCommonAttributes(SAPNotification sapNotification, SqlCommand command)
        {
            command.AddParameter("@NotificationNumber", sapNotification.NotificationNumber);
            command.AddParameter("@NotificationType", sapNotification.NotificationType);
            command.AddParameter("@Processed", sapNotification.IsProcessed);
            command.AddParameter("@FunctionalLocationId", sapNotification.FunctionalLocation.Id);
            command.AddParameter("@Description", sapNotification.Description);
            command.AddParameter("@Comments", sapNotification.Comments);
            command.AddParameter("@CreationDateTime", sapNotification.CreationDateTime);
            command.AddParameter("@ShortText", sapNotification.ShortText);
            command.AddParameter("@LongText", sapNotification.LongText);
            command.AddParameter("@IncidentID", sapNotification.IncidentId);
        }

        /// <summary>
        /// Updates the SAP notification object by Notification Number
        /// </summary>
        /// <param name="sapNotification"></param>
        public void UpdateByNotificationNumber(SAPNotification sapNotification)
        {
            SqlCommand command = ManagedCommand;

            command.Update(sapNotification, AddUpdateParameters, UPDATE__BY_NOTIFICATION_NUMBER_STORED_PROCEDURE);
        }
    }
}