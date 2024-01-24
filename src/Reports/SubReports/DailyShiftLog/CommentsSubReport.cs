using System;
using System.Drawing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports.SubReports.DailyShiftLog
{
    public partial class CommentsSubReport : XtraReport
    {
        public CommentsSubReport()
        {
            InitializeComponent();
        }

        private void CustomFieldDetailReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            object objectValue = GetCurrentColumnValue("CustomFieldLabelText");
            if (objectValue != null && Convert.ToString(objectValue) == string.Empty)
            {
                e.Cancel = true;
                CustomFieldDetailReport.Visible = false;
            }
            else
            {
                CustomFieldDetailReport.Visible = true;
            }
        }

    }
}