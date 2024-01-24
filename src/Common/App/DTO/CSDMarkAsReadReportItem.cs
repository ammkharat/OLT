using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO.Reporting;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class CSDMarkAsReadReportItem : DomainObject
    {
        private readonly DateTime dateTime;
        private readonly string userFullNameWithUserName;
        private readonly string csdDesc;
        private readonly Date theDate;
        private readonly string shiftName;

        public CSDMarkAsReadReportItem(string userFullNameWithUserName, DateTime signatureTimeStampDateTime, string csdDesc, Date theDate, string shiftName)
        {
            this.userFullNameWithUserName = userFullNameWithUserName;
            this.dateTime = signatureTimeStampDateTime;
            this.csdDesc = csdDesc;
            this.theDate = theDate;
            this.shiftName = shiftName;
        }
        //date and time when user clicked on mark as read button
        public DateTime DateTime
        {
            get { return dateTime; }
        }

        public string UserFullNameWithUserName
        {
            get { return userFullNameWithUserName; }
        }
        //thedate used for group by 
        public Date TheDate
        {
            get { return theDate; }
        }
        public string ShiftName
        {
            get { return shiftName; }
        }
        public string CsdDesc
        {
            get { return csdDesc; }
        }
        /*trying code*/
        //public static List<CSDMarkAsReadReportItemByDate> GroupByDate(CSDMarkAsReadReportItem reportData)
        //{
        //    List<CSDMarkAsReadReportItemByDate> data = new List<CSDMarkAsReadReportItemByDate>();
        //    return data;
        //}
    }
}