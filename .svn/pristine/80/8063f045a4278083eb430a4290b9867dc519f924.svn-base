using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.Serialization.Formatters;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports.SubReports.GenericSingleLog
{
    public partial class CustomFieldsSubReport : XtraReport
    {
        public CustomFieldsSubReport()
        {
            InitializeComponent();
        }

        private void XrtTableCellOnBeforePrint(object sender, PrintEventArgs printEventArgs)
        {
            var tableCell = sender as XRLabel;
            if (tableCell == null) return;
            if (tableCell.Text != string.Empty && !tableCell.Text.Contains(":"))
            {
                tableCell.Font = new Font(tableCell.Font.FontFamily, 10f, FontStyle.Bold);
            }
            else
            {
                tableCell.Font = new Font(tableCell.Font,FontStyle.Regular);
            }

            //if (Convert.ToString(fieldOneColor.Text) == "R")
            //{
            //    fieldOneValue.ForeColor = Color.Red;
            //}
            //if (Convert.ToString(fieldTwoColor.Text) == "R")
            //{
            //    fieldTwoValue.ForeColor = Color.Red;
            //}
            //if (Convert.ToString(fieldThreeColor.Text) == "R")
            //{
            //    fieldThreeValue.ForeColor = Color.Red;
            //}
            
        }

        
    }
}