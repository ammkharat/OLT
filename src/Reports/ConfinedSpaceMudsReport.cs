using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class ConfinedSpaceMudsReport : XtraReport, IOltReport<ConfinedSpaceMudsReportAdapter>
    {
        public ConfinedSpaceMudsReport()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<ConfinedSpaceMudsReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            DataSource = adapters;
            PrintDate.Value = currentTimeInSite;
        }
        private void SetGastestValues(ConfinedSpaceMudsReportAdapter adp)
        {
            int i = 1;
            foreach (GasTestElement elements in adp.confinedSpace.GasTests.Elements)
            {
                if (i < xrTable1.Rows.Count)
                {
                    xrTable1.Rows[i].Cells[0].Text = Convert.ToString(elements.ElementInfo.Name);
                    xrTable1.Rows[i].Cells[1].Text = Convert.ToString(elements.ImmediateAreaTestResult);
                    xrTable1.Rows[i].Cells[2].Text = Convert.ToString(elements.ConfinedSpaceTestResult);
                    xrTable1.Rows[i].Cells[3].Text = Convert.ToString(elements.ThirdTestResult);
                    xrTable1.Rows[i].Cells[4].Text = Convert.ToString(elements.FourthTestResult);
                  //  xrTable1.Rows[i].Cells[4].Text = Convert.ToString(elements.f);
                }
                i++;
            }

            //foreach (GasTestElement elements in adp.permit.GasTests.Elements)
            //{
            //    foreach (XRTableRow row in xrTable2.Rows)
            //    {
            //        if (Convert.ToString(row.Cells[0].Tag).Equals(elements.ElementInfo.Name))
            //        {
            //            //row.Cells[1].Text = elements.ElementInfo.HotLimit.ToLimitStringWithUnit(elements.ElementInfo.IsRangedLimit, elements.ElementInfo.DecimalPlaceCount,elements.ElementInfo.Unit);
            //            row.Cells[1].Text = Convert.ToString(elements.ImmediateAreaTestResult);
            //            row.Cells[2].Text = Convert.ToString(elements.ConfinedSpaceTestResult);
            //            row.Cells[3].Text = Convert.ToString(elements.ThirdTestResult);
            //            row.Cells[4].Text = Convert.ToString(elements.FourthTestResult);
            //        }


            //    }
            //}
           // xrTable1.Rows[1].Cells[1].Text = Convert.ToString(adp.confinedSpace.GasTests.);
            xrTable1.Rows[0].Cells[1].Text = Convert.ToString(adp.confinedSpace.GasTests.GasTestFirstResultTime);
            xrTable1.Rows[0].Cells[2].Text = Convert.ToString(adp.confinedSpace.GasTests.GasTestSecondResultTime);
            xrTable1.Rows[0].Cells[3].Text = Convert.ToString(adp.confinedSpace.GasTests.GasTestThirdResultTime);
            xrTable1.Rows[0].Cells[4].Text = Convert.ToString(adp.confinedSpace.GasTests.GasTestFourthResultTime);


        }
        private void ConfinedSpacetMudsReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            List<ConfinedSpaceMudsReportAdapter> adapters = this.DataSource as List<ConfinedSpaceMudsReportAdapter>;
            SetGastestValues(adapters[0]);
        }
    }
}