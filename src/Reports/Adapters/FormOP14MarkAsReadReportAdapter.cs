using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;


namespace Com.Suncor.Olt.Reports.Adapters
{
    public class FormOP14MarkAsReadReportAdapter :  AbstractLocalizedReportAdapter, IReportAdapter
    {
        /*amitshukla testing*/
        //private readonly CSDMarkAsReadReportItemByDate csdMarkAsReadReportItem;
        private readonly CSDMarkAsReadReportItem csdMarkAsReadReportItem;
        private readonly string thedateofreportItem;


        private readonly DateTime dateTime;
        private readonly string userFullNameWithUserName;
        private readonly string csdDesc;
        private readonly Date theDate;
        private readonly string shiftName;

        /*amitshukla testing*/
       // public FormOP14MarkAsReadReportAdapter(String ReportdateTitle, CSDMarkAsReadReportItemByDate reportDTO)
        public FormOP14MarkAsReadReportAdapter(CSDMarkAsReadReportItem reportDTO)
        {
           csdMarkAsReadReportItem = reportDTO;
          // thedateofreportItem = ReportdateTitle;
        }

        public Date TheDateofReportItem
        {
            get { return csdMarkAsReadReportItem.TheDate; }
        }
        /*amitshukla testing*/
        //public CSDMarkAsReadReportItemByDate CsdMarkAsReadReportItem
        public CSDMarkAsReadReportItem CsdMarkAsReadReportItem
        {
            get { return csdMarkAsReadReportItem; }
        }


        /*amitshukla testing*/

        public DateTime DateTime
        {
            get { return csdMarkAsReadReportItem.DateTime; }
        }

        public string UserFullNameWithUserName
        {
            get { return csdMarkAsReadReportItem.UserFullNameWithUserName; }
        }
        //thedate used for group by 
        public Date TheDate
        {
            get { return csdMarkAsReadReportItem.TheDate; }
        }
        public string ShiftName
        {
            get { return csdMarkAsReadReportItem.ShiftName; }
        }
        public string CsdDesc
        {
            get { return csdMarkAsReadReportItem.CsdDesc; }
        }
    }


}