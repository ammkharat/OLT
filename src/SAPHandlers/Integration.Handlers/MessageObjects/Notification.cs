using System.Xml.Serialization;

namespace Com.Suncor.Olt.Integration.Handlers.MessageObjects
{
    [XmlRoot("NotificationOLTData", Namespace = "", IsNullable = false)]
    public class Notification
    {
        [XmlElement("NotificationRecord")] public NotificationRecord NotificationRecord;
    }

    public class NotificationRecord
    {
        [XmlElement("NotificationDetails")] public NotificationDetails[] NotificationDetails;
    }

    public class NotificationDetails
    {
        [XmlElement("CreateDate")] public string CreateDate;

        [XmlElement("CreateTime")] public string CreateTime;
        [XmlElement("EquipmentNumber")] public string EquipmentNumber;
        [XmlElement("FunctionalLocation")] public string FunctionalLocation;

        [XmlElement("IncidentID")] public string IncidentID;
        [XmlElement("LanguageCode")] public string LanguageCode;

        [XmlElement("LongText")] public string LongText;
        [XmlElement("NotificationNumber")] public string NotificationNumber;

        [XmlElement("NotificationType")] public string NotificationType;

        [XmlElement("PlantID")] public string PlantID;
        [XmlElement("ShortText")] public string ShortText;

        [XmlElement("Tasks")] public Tasks[] Tasks;
    }

    public class Tasks
    {
        [XmlElement("ContactPerson")] public string ContactPerson;
        [XmlElement("CreationDate")] public string CreationDate;
        [XmlElement("Creator")] public string Creator;
        [XmlElement("ExceptionText")] public string ExceptionText;

        [XmlElement("PlannedFinishDate")] public string PlannedFinishDate;

        [XmlElement("PlannedFinishTime")] public string PlannedFinishTime;
        [XmlElement("PlannedStartDate")] public string PlannedStartDate;

        [XmlElement("PlannedStartTime")] public string PlannedStartTime;
        [XmlElement("TaskCode")] public string TaskCode;

        [XmlElement("TaskCodeText")] public string TaskCodeText;

        [XmlElement("TaskText")] public string TaskText;
    }
}