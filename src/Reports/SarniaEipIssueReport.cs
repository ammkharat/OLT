using System;
using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class SarniaEipIssueReport : XtraReport, IOltReport<SarniaEipIssueReportAdapter>
    {
        private int detailrowCount = 0;
        public int count = 0;
        //private XRTable xrTablegroupfooter
        public SarniaEipIssueReport()
        {
            InitializeComponent();

            this.ShowPrintMarginsWarning = false;


            //xrTableCell4.ForeColor = Color.FromArgb(150, 204, 204, 204);  

        }

        public void SetMasterAndSubReportDataSource(List<SarniaEipIssueReportAdapter> adapters, DateTime currentTimeInSite)
        {
            if (adapters == null || adapters.Count < 1)
                return;
            DataSource = adapters;

            if(adapters[0].IsolationReportAdapters.Count < 14)
            {
               // adapters[0].IsolationReportAdapters.Add(IsolationForSarniaReportAdapter item {null});
            }

            var sarniaeipissueReportAdapter = adapters[0];
            count = adapters[0].IsolationReportAdapters.Count; //DMND0010815 : Added By Vibhor - Sarnia Issues for CSD, EIP forms   
           
            printDateTime.Value = currentTimeInSite.ToLongDateAndTimeString();
            
        }

        private void Detail1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            detailrowCount++;
            Detail1.PageBreak = PageBreak.None;


            if (count > 14)     //DMND0010815 : Added By Vibhor - Sarnia Issues for CSD, EIP forms  
            {
                if (detailrowCount == 14)
                {
                    Detail1.PageBreak = PageBreak.AfterBand;
                }
            }
        }

        //DMND0010815 : Added By Vibhor - Sarnia Issues for CSD, EIP forms   

        private void xrLabel25_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            e.Cancel = e.PageIndex > 0;
        }

        private void xrPanel1_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            e.Cancel = e.PageIndex > 0;
            
        }
        //bool firstPage = true;
        private void GroupFooter1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
                //e.Cancel = !firstPage;
                //firstPage = false;
        }

        //end
        
       
        
    }
}