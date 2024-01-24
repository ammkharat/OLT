using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    /*amitshukla testing*/
    public class FormOP14MarkAsReadReportPrintActions : PrintActions<CSDMarkAsReadReportItem, FormOP14MarkAsReadReport, FormOP14MarkAsReadReportAdapter>
    {
        private readonly string labelTitle;

        public FormOP14MarkAsReadReportPrintActions(string labelTitle)
        {
            this.labelTitle = labelTitle;
        }

        protected override FormOP14MarkAsReadReport CreateSpecificReport()
        {
            return new FormOP14MarkAsReadReport();
        }
        /*amitshukla testing*/
        //protected override List<FormOP14MarkAsReadReportAdapter> CreateReportAdapter(CSDMarkAsReadReportItemByDate dto)
        protected override List<FormOP14MarkAsReadReportAdapter> CreateReportAdapter(CSDMarkAsReadReportItem dto)
        {
            return new List<FormOP14MarkAsReadReportAdapter> { new FormOP14MarkAsReadReportAdapter(dto) };
        }
        /*amitshukla testing*/
        //public override string ReportTitle(CSDMarkAsReadReportItemByDate domainObject)
        public override string ReportTitle(CSDMarkAsReadReportItem domainObject)
        {
            return StringResources.ReportLabel_Title_FORMOP14MarkAsReadReport;
        }

        protected override ReportPrintPreference CreateReportPrintPreference(FormOP14MarkAsReadReport report, UserPrintPreference userPrintPreference)
        {
            return new ReportPrintPreference(report, 1, false, false, string.Empty, true);
        }
    }
}