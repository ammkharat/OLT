using System;

namespace Com.Suncor.Olt.Integration.HTTPHandlers.Fixtures
{
    public class NotificationSAPData
    {
        private readonly string NOTIFICATION_MSG = "<?xml version=\"1.0\"?>" + Environment.NewLine + "" +
                                                   "<NotificationOLTData>" + Environment.NewLine + "" +
                                                   "   <NotificationRecord>" + Environment.NewLine + "" +
                                                   "       <header></header>" + Environment.NewLine + "" +
                                                   "       <NotificationDetails>" + Environment.NewLine + "" +
                                                   "           <NotificationNumber>{0}</NotificationNumber>" +
                                                   Environment.NewLine + "" +
                                                   "           <NotificationType>{1}</NotificationType>" +
                                                   Environment.NewLine + "" +
                                                   "           <ShortText>{2}</ShortText>" + Environment.NewLine + "" +
                                                   "           <FunctionalLocation>{3}</FunctionalLocation>" +
                                                   Environment.NewLine + "" +
                                                   "           <EquipmentNumber>{4}</EquipmentNumber>" +
                                                   Environment.NewLine + "" +
                                                   "           <CreateDate>{5}</CreateDate>" + Environment.NewLine + "" +
                                                   "           <CreateTime>{6}</CreateTime>" + Environment.NewLine + "" +
                                                   "           <IncidentID>{7}</IncidentID>" + Environment.NewLine + "" +
                                                   "           <PlantID>{8}</PlantID>" + Environment.NewLine + "" +
                                                   "           <LongText>{9}</LongText>" + Environment.NewLine + "" +
                                                   "           <Tasks>" + Environment.NewLine + "" +
                                                   "               <MANUM>{10}</MANUM>" + Environment.NewLine + "" +
                                                   "               <TaskCode>{11}</TaskCode>" + Environment.NewLine + "" +
                                                   "               <TaskCodeText>{12}</TaskCodeText>" +
                                                   Environment.NewLine + "" +
                                                   "               <TaskText>{13}</TaskText>" + Environment.NewLine + "" +
                                                   "               <Creator>{14}</Creator>" + Environment.NewLine + "" +
                                                   "               <CreationDate>{15}</CreationDate>" +
                                                   Environment.NewLine + "" +
                                                   "               <PlannedStartDate>{16}</PlannedStartDate>" +
                                                   Environment.NewLine + "" +
                                                   "               <PlannedStartTime>{17}</PlannedStartTime>" +
                                                   Environment.NewLine + "" +
                                                   "               <PlannedFinishDate>{18}</PlannedFinishDate>" +
                                                   Environment.NewLine + "" +
                                                   "               <PlannedFinishTime>{19}</PlannedFinishTime>" +
                                                   Environment.NewLine + "" +
                                                   "               <ExceptionText>{20}</ExceptionText>" +
                                                   Environment.NewLine + "" +
                                                   "               <ContactPerson>{21}</ContactPerson>" +
                                                   Environment.NewLine + "" +
                                                   "           </Tasks>" + Environment.NewLine + "" +
                                                   "       </NotificationDetails>" + Environment.NewLine + "" +
                                                   "   </NotificationRecord>" + Environment.NewLine + "" +
                                                   "</NotificationOLTData>";

        public string ContactPerson = string.Empty;

        public string CreateDate = string.Empty;
        public string CreateTime = string.Empty;
        public string CreationDate = string.Empty;
        public string Creator = string.Empty;
        public string EquipmentNumber = string.Empty;
        public string ExceptionText = string.Empty;
        public string FunctionalLocation = string.Empty;
        public string IncidentID = string.Empty;
        public string LongText = string.Empty;
        public string Manum = string.Empty;
        public string NotificationNumber = string.Empty;
        public string NotificationType = string.Empty;
        public string PlannedFinishDate = string.Empty;
        public string PlannedFinishTime = string.Empty;
        public string PlannedStartDate = string.Empty;
        public string PlannedStartTime = string.Empty;
        public string PlantID = string.Empty;
        public string ShortText = string.Empty;
        public string TaskCode = string.Empty;
        public string TaskCodeText = string.Empty;
        public string TaskText = string.Empty;
        public string Tasks = string.Empty;

        public NotificationSAPData(string notificationNumber,
            string notificationType,
            string shortText,
            string functionalLocation,
            string equipmentNumber,
            string createDate,
            string createTime,
            string incidentID,
            string plantID,
            string longText,
            string manum,
            string taskCode,
            string taskCodeText,
            string taskText,
            string creator,
            string creationDate,
            string plannedStartDate,
            string plannedStartTime,
            string plannedFinishDate,
            string plannedFinishTime,
            string exceptionText,
            string contactPerson)
        {
            NotificationNumber = notificationNumber;
            NotificationType = notificationType;
            ShortText = shortText;
            FunctionalLocation = functionalLocation;
            EquipmentNumber = equipmentNumber;
            CreateDate = createDate;
            CreateTime = createTime;
            IncidentID = incidentID;
            PlantID = plantID;
            LongText = longText;
            Manum = manum;
            TaskCode = taskCode;
            TaskCodeText = taskCodeText;
            TaskText = taskText;
            Creator = creator;
            CreationDate = creationDate;
            PlannedStartDate = plannedStartDate;
            PlannedStartTime = plannedStartTime;
            PlannedFinishDate = plannedFinishDate;
            PlannedFinishTime = plannedFinishTime;
            ExceptionText = exceptionText;
            ContactPerson = contactPerson;
        }

        public string CreateMessage()
        {
            var msg = string.Format(NOTIFICATION_MSG, NotificationNumber,
                NotificationType,
                ShortText,
                FunctionalLocation,
                EquipmentNumber,
                CreateDate,
                CreateTime,
                IncidentID,
                PlantID,
                LongText,
                Manum,
                TaskCode,
                TaskCodeText,
                TaskText,
                Creator,
                CreationDate,
                PlannedStartDate,
                PlannedStartTime,
                PlannedFinishDate,
                PlannedFinishTime,
                ExceptionText,
                ContactPerson);
            return msg;
        }
    }
}