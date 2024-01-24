using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Reports.SubReports.WorkPermitMuds
{
    public partial class WorkPermitMudsHotReport : DevExpress.XtraReports.UI.XtraReport
    {
        public WorkPermitMudsHotReport()
        {
            InitializeComponent();
        }

        private void xrPanel6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }


        private void SetGastestValues(WorkPermitMudsReportAdapter adp)
        {
            int i = 1;
            foreach (GasTestElement elements in adp.permit.GasTests.Elements)
            {
                if (i < xrTable2.Rows.Count - 1)
                {
                    xrTable2.Rows[i].Cells[0].Text = Convert.ToString(elements.ElementInfo.Name);
                    xrTable2.Rows[i].Cells[1].Text = Convert.ToString(elements.ImmediateAreaTestResult);
                    xrTable2.Rows[i].Cells[2].Text = Convert.ToString(elements.ConfinedSpaceTestResult);
                    xrTable2.Rows[i].Cells[3].Text = Convert.ToString(elements.ThirdTestResult);
                    xrTable2.Rows[i].Cells[4].Text = Convert.ToString(elements.FourthTestResult);
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
            xrTable2.Rows[0].Cells[1].Text = Convert.ToString(adp.permit.GasTests.GasTestFirstResultTime);
            xrTable2.Rows[0].Cells[2].Text = Convert.ToString(adp.permit.GasTests.GasTestSecondResultTime);
            xrTable2.Rows[0].Cells[3].Text = Convert.ToString(adp.permit.GasTests.GasTestThirdResultTime);
            xrTable2.Rows[0].Cells[4].Text = Convert.ToString(adp.permit.GasTests.GasTestFourthResultTime);
            

        }

        private void WorkPermitMudsHotReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            List<WorkPermitMudsReportAdapter> adapters = this.DataSource as List<WorkPermitMudsReportAdapter>;
            SetGastestValues(adapters[0]);
        }

    }
}
