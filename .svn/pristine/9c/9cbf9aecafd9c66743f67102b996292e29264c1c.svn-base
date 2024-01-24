//***************************************************************************
//
// FLOC Class:
// 
// Written By: Paul Carter
// 
// Date: 21 Dec 2005
// 
// Description:
//
// Data storage class for SAP FLOC messages. The class is used to deserialise
// the XML data received from SAP.
// 
//****************************************************************************
// Amendment History
// -----------------
// 
// Date		Developer	Description
// ----		---------	-----------
// 
//***************************************************************************
// dd/mm/yy	[Name]	    	[Description]
//
//***************************************************************************


using System.Xml.Serialization;

namespace Com.Suncor.Olt.Integration.Handlers.MessageObjects
{
    [XmlRoot("FLOCOLTData", Namespace = "", IsNullable = false)]
    public class FunctionalLocationXmlMessage
    {
        [XmlElement("FLOCRecord")] public FunctionalLocationXmlRecord FunctionalLocationXmlRecord;
    }

    public class FunctionalLocationXmlRecord
    {
        [XmlElement("FLOCDetails")] public FunctionalLocationDetails[] FunctionalLocationDetails;
    }

    public class FunctionalLocationDetails
    {
        [XmlElement("Action")] public string Action;
        [XmlElement("Description")] public string Description;
        [XmlElement("FLOCID")] public string FullHierarchy;

        [XmlElement("LanguageCode")] public string LanguageCode;
        [XmlElement("OldFLOC")] public string OldFLOC;
        [XmlElement("PlantID")] public string PlantId;

        [XmlElement("SuperiorFLOCID")] public string SuperiorFullHierarchy;
    }
}