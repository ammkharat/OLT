using System;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.Data.XtraReports.Wizard.Presenters;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports.SubReports.PermitAssessment
{
    public partial class PermitAssessmentAnswerSubReport : XtraReport
    {
        public PermitAssessmentAnswerSubReport()
        {
            InitializeComponent();
        }

        private void ScoreXrtTableCellOnBeforePrint(object sender, PrintEventArgs printEventArgs)
        {
            var tableCell = sender as XRTableCell;
            if (tableCell == null) return;
            var score = GetCurrentColumnValue("Score") as int?;
            if(!score.HasValue) return;
            const int translucentAlpha = 128;

            var redTranslucentArgb = Color.FromArgb(translucentAlpha, Color.PaleVioletRed.R, Color.PaleVioletRed.G,
                Color.PaleVioletRed.B);

            var greenTranslucentArgb = Color.FromArgb(translucentAlpha, Color.LightGreen.R, Color.LightGreen.G,
                Color.LightGreen.B);

            var yellowTranslucentArgb = Color.FromArgb(translucentAlpha, Color.PaleGoldenrod.R, Color.PaleGoldenrod.G,
                Color.PaleGoldenrod.B);

            var translucentColor = (score == 0 || score == 1)
                ? redTranslucentArgb
                : (score == 2 || score == 3) ? yellowTranslucentArgb : greenTranslucentArgb;

            tableCell.BackColor = translucentColor;
        }
    }
}