using System.Xml.Serialization;

namespace Com.Suncor.Olt.Integration.Handlers.MessageObjects
{
    [XmlRoot("WorkOrderOLTdata", Namespace = "", IsNullable = false)]
    public class WorkOrder
    {
        [XmlElement("WorkOrderRecord")] public WorkOrderRecord WorkOrderRecord;
    }

    public class WorkOrderRecord
    {
        [XmlElement("WorkOrderDetails")] public WorkOrderDetails[] WorkOrderDetails;
    }

    public class WorkOrderDetails
    {
        [XmlElement("EquipmentNumber")] public string EquipmentNumber;
        [XmlElement("FunctionalLocation")] public string FunctionalLocation;

        [XmlElement("LanguageCode")] public string LanguageCode;

        [XmlElement("Operations")] public Operations[] Operations;
        [XmlElement("PlantID")] public string PlantID;
        [XmlElement("ShortText")] public string ShortText;
        [XmlElement("WONumber")] public string WorkOrderNumber;
    }

    public class Operations
    {
        [XmlElement("EarliestFinishDate")] public string EarliestFinishDate;

        [XmlElement("EarliestFinishTime")] public string EarliestFinishTime;
        [XmlElement("EarliestStartDate")] public string EarliestStartDate;

        [XmlElement("EarliestStartTime")] public string EarliestStartTime;

        [XmlElement("LongText")] public string LongText;
        [XmlElement("OperationKeyNo")] public string OperationKeyNumber;
        [XmlElement("OperationNumber")] public string OperationNumber;
        [XmlElement("SubOperation")] public string Suboperation;

        [XmlElement("WorkCenterID")] public string WorkCenterID;

        [XmlElement("WorkCenterName")] public string WorkCenterName;

        [XmlElement("WorkCenterText")] public string WorkCenterText;
        [XmlElement("WorkPermitAttrib")] public string WorkPermitAttrib;
        [XmlElement("WorkPermitType")] public string WorkPermitType;
    }
}