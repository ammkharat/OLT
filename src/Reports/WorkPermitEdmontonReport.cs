using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;
using System.Drawing.Printing;

namespace Com.Suncor.Olt.Reports
{
    public partial class WorkPermitEdmontonReport : XtraReport, IOltReport<WorkPermitEdmontonReportAdapter>
    {
        public WorkPermitEdmontonReport()
        {
            InitializeComponent();
        }


        public void SetMasterAndSubReportDataSource(List<WorkPermitEdmontonReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            DataSource = adapters;
            if (adapters.Count > 0)
            {
                descriptionTooLongLabel.Visible = !adapters[0].TaskDescriptionTooLongWarning.IsNullOrEmptyOrWhitespace();
                //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - point 3.2 - 01-Nov-2018 start
                //xrPanelSignature.Visible = adapters[0].JobsiteEquipmentInspectedYes;         //ayman Edmonton work permit
                //xrPanelSignature.Visible = adapters[1].JobsiteEquipmentInspectedYes;        //ayman Edmonton work permit

                if (adapters[0].JobsiteEquipmentInspectedYes && adapters[1].JobsiteEquipmentInspectedYes)
                {
                    xrPanelJobSite.Visible = true;
                }
                else
                {
                    xrPanelJobSite.Visible = false;
                }
                if (adapters[0].StatusOfPipingEquipmentSectionNotApplicableToJob && adapters[1].StatusOfPipingEquipmentSectionNotApplicableToJob)
                {
                    xrPanelMiddel.Visible = false;
                    // Start : INC0421183 : Added by Vibhor

                    if (adapters[0].ConfinedSpaceWorkSectionNotApplicableToJob)
                    {
                        xrLabel52.Location = new Point(6,372);
                        confinedSpaceWorkNotApplicable.Location = new Point(662,372);
                        xrPanelLower.Location = new Point(5,389);
                     
                     
                        
                    }
                    else
                    {
                        xrLabel52.Location = new Point(6, 372);
                        confinedSpaceWorkNotApplicable.Location = new Point(662, 372);
                        xrPanel_Confined_space.Location = new Point(1, 389);
                        xrPanelLower.Location = new Point(5, 519);
                       
                    }

                    //xrPanelLower.Location = adapters[0].ConfinedSpaceWorkSectionNotApplicableToJob ? xrPanelMiddel.Location : xrPanel_Confined_space.Location;
                    //xrPanel_Confined_space.Location = xrPanelMiddel.Location;
                    // End : INC0421183
                }
                else
                {
                    xrPanelMiddel.Visible = true;  //statusOfPipingEquipmentNotApplicable
                }
                //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - point 3.2 -  01-Nov-2018 end
                // Start : INC0421183 : if Confined space work details are not applicable , then it won't be the part of the print version -- Added by Vibhor

                if (adapters[0].ConfinedSpaceWorkSectionNotApplicableToJob)
                {
                    xrPanel_Confined_space.Visible = false;

                    if (adapters[0].StatusOfPipingEquipmentSectionNotApplicableToJob && adapters[1].StatusOfPipingEquipmentSectionNotApplicableToJob)
                    {
                        xrLabel52.Location = new Point(6, 372);
                        confinedSpaceWorkNotApplicable.Location = new Point(662, 372);
                        xrPanelLower.Location = new Point(5, 389);
                    }
                    else
                    {
                        //xrPanelLower.Location = xrPanel_Confined_space.Location;
                        xrPanelLower.Location = new Point(5, 537);
                    }

                    

                   // xrPanelLower.Location = (adapters[0].StatusOfPipingEquipmentSectionNotApplicableToJob && adapters[1].StatusOfPipingEquipmentSectionNotApplicableToJob) ? xrPanelMiddel.Location : xrPanel_Confined_space.Location;

                }
                // End : INC0421183

                xrPanel1.LocationF = new PointF(5, 1600);
            }

         
        }

        public bool StringWillFitIntoTaskDescriptionField(string description)
        {
            return DevExpressMeasurementUtility.StringWillFitIntoField(
                taskDescriptionDataLabel.CreateLabelAttributes(), description);
        }

        public static LabelAttributes GetAttributesForHazardsLabel()
        {
            var report = new WorkPermitEdmontonReport();
            return report.hazardsDataLabel.CreateLabelAttributes();
        }

    }
}