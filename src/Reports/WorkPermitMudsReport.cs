﻿using System;
using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Reports
{
    public partial class WorkPermitMudsReport : XtraReport, IOltReport<WorkPermitMudsReportAdapter>
    {
        public static WorkPermitMudsReportAdapter mudsWP;

        public WorkPermitMudsReport()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<WorkPermitMudsReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            DataSource = adapters;
            PrintDate.Value = currentTimeInSite;
            
            
            if (adapters.Count > 0)
            {
                subReportHot.ReportSource.DataSource = adapters;
                subReportMod.ReportSource.DataSource = adapters;
                xrSubreport1.ReportSource.DataSource = adapters;
                mudsWP = adapters[0];

                subReportConfinedSpace.Visible = false;

                //var a = adapters[0].ConfinedSpaceAdapters[0].confinedSpace;


                //if (adapters[0].ConfinedSpaceAdapters[0].confinedSpace != null)
                //{
                //    subReportConfinedSpace.ReportSource.DataSource = adapters[0].ConfinedSpaceAdapters;
                //    subReportConfinedSpace.Visible = true;
                //}
                
                if (Convert.ToString(adapters[0].PermitType) == WorkPermitMudsType.ELEVATED_HOT.ToString())
                {
                    subReportHot.Visible = true;
                    subReportMod.Visible = false;

                    //to set GasTest Value
                    
                }
                else
                {
                    subReportHot.Visible = false;
                    subReportMod.Visible = true;

                

                    //panelMod.Location. = 0;

                    //if (adapters[0].UtilisationMoteur_CheckBox || adapters[0].NettoyageAu_CheckBox || adapters[0].UtilisationElectronics_CheckBox ||
                    //    adapters[0].Radiographie_CheckBox || adapters[0].UtilisationOutlis_CheckBox || adapters[0].UtilisationEquipments_CheckBox ||
                    //    adapters[0].Demolition_CheckBox || adapters[0].AutresInstruction_CheckBox)
                    //{
                    //    panelModCold.Visible = true;
                    //}
                    //else
                    //{
                    //    panelModCold.Visible = false;
                    //}
                }
                
               // xrPanel1.Location = new Point(0, 2600);
            
            }

        }

      

        private void WorkPermitMudsReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //detailHot.Visible = false;
        }
    }
}