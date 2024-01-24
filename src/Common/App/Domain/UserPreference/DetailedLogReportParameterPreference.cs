using System;
using System.Xml.Serialization;

namespace Com.Suncor.Olt.Common.Domain.UserPreference
{
    [Serializable]
    public class DetailedLogReportParameterPreference : ReportParameterPreference
    {
        private int groupById;

        [XmlElement("GroupById")]
        public int GroupById
        {
            get { return groupById; }
            set { groupById = value; }
        }
    }
}