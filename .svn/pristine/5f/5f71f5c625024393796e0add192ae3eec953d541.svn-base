using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class SAPNotificationDTODao : AbstractManagedDao, ISAPNotificationDTODao
    {
        private SAPNotificationDTO PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string description = reader.Get<string>("Description");
            string notificationType = reader.Get<string>("NotificationType");
            string notificationNumber = reader.Get<string>("NotificationNumber");
            DateTime creationDateTime = reader.Get<DateTime>("CreationDateTime");
            string functionalLocationName = reader.Get<string>("FullHierarchy");
            string shortText = reader.Get<string>("ShortText");
            string incidentId = reader.Get<string>("IncidentID");
            bool isProcessed = reader.Get<bool>("Processed");

            SAPNotificationDTO result =
                new SAPNotificationDTO(id, description, functionalLocationName, notificationType, notificationNumber, creationDateTime, isProcessed,
                                       shortText, incidentId);

            return result;
        }

        public List<SAPNotificationDTO>
            QueryByUnitLevelFunctionalLocationsAndDateRange(IFlocSet flocSet,
                                                        DateTime startDateTime, DateTime endDateTime)
        {
            string csvFunctionalLocationIds =
                flocSet.FunctionalLocations.BuildIdStringFromList();

            SqlCommand command = ManagedCommand;
            command.AddParameter("@IDs", csvFunctionalLocationIds);
            command.AddParameter("@StartDateTime", startDateTime);
            command.AddParameter("@EndDateTime", endDateTime);

            command.CommandText = "QuerySAPNotificationDTOsByFLOCIDsAndDateRange";
            List<SAPNotificationDTO> result = new List<SAPNotificationDTO>();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(PopulateInstance(reader));
                }
            }
            return result;
        }
    }
}