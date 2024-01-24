using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using Com.Suncor.Olt.Reports.Adapters;
using DevExpress.Utils;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports.SubReports.WorkPermitMuds
{
    public partial class WorkPermitMudsModColdReport : DevExpress.XtraReports.UI.XtraReport
    {
        public WorkPermitMudsModColdReport()
        {
            InitializeComponent();
        }



        private void WorkPermitMudsModColdReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            WorkPermitMudsReportAdapter wp = WorkPermitMudsReport.mudsWP;

            if (    wp.UtilisationMoteur_CheckBox || wp.NettoyageAu_CheckBox
                  || wp.UtilisationElectronics_CheckBox || wp.Radiographie_CheckBox
                  || wp.UtilisationEquipments_CheckBox 
                  || wp.Demolition_CheckBox || wp.AutresInstruction_CheckBox
                  || wp.UtilisationOutlis_CheckBox  
                )
            {
                panelModCold.Visible = true;
                panelModColdHead.Visible = true;
                panelModUtilItems.Visible = true;

                panelAttributes.LocationFloat = new PointFloat(0, 209);
            }
            else
            {
                panelModCold.Visible = false;
                panelModColdHead.Visible = false;
                panelModUtilItems.Visible = false;

                panelAttributes.LocationFloat = new PointFloat(0, 2);
            }

        }

    }
}
