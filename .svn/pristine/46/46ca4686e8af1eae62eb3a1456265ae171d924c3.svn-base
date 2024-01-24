using System.Drawing;
using System.Drawing.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports.SubReports.ShiftHandoverQuestionnaire
{
    public partial class CustomFieldsSubReport : XtraReport
    {
        public CustomFieldsSubReport()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, PrintEventArgs e)
        {
            var tableCell = sender as XRLabel;
            if (tableCell == null) return;
            if (tableCell.Text != string.Empty && !tableCell.Text.Contains(":"))
            {
                tableCell.Font = new Font(tableCell.Font.FontFamily, 10f, FontStyle.Bold);
            }
            else
            {
                tableCell.Font = new Font(tableCell.Font, FontStyle.Regular);
            }
        }
    }
}