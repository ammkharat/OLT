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
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using DevExpress.XtraPrinting;

namespace Com.Suncor.Olt.Reports
{
    public partial class WorkPermitFortHillsReport : XtraReport, IOltReport<WorkPermitFortHillsReportAdapter>
    {
        public WorkPermitFortHillsReport()
        {
            InitializeComponent();
            partHDisclamerxrRichText.TextAlignment = TextAlignment.MiddleCenter;
        }


        public void SetMasterAndSubReportDataSource(List<WorkPermitFortHillsReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            DataSource = adapters;
            if (adapters.Count > 0)
            {
                descriptionTooLongLabel.Visible = !adapters[0].TaskDescriptionTooLongWarning.IsNullOrEmptyOrWhitespace();
                
                if (adapters[0].PartCWorkSectionNotApplicableToJob)
                {
                    partCPanel.ForeColor = Color.Gray;
                }
                if (adapters[0].PartDWorkSectionNotApplicableToJob)
                {
                    partDPanel.ForeColor = Color.Gray;
                }
                if (adapters[0].PartEWorkSectionNotApplicableToJob)
                {
                    partEPanel.ForeColor = Color.Gray;
                }
                if (adapters[0].PartFWorkSectionNotApplicableToJob)
                {
                    partFPanel.ForeColor = Color.Gray;
                } 
                if (adapters[0].PartGWorkSectionNotApplicableToJob)
                {
                    partGPanel.ForeColor = Color.Gray;
                }
                if (!adapters[0].Other1PartG)
                {
                    xrTableCell86.Text = "OTHERS";
                }
                if (!adapters[0].Other2PartG)
                {
                    xrTableCell100.Text = "OTHERS";
                }
                if (adapters[0].IsFieldTourRequired)
                {
                    IsFieldtourRequiredYesCheckBox.Checked = adapters[0].IsFieldTourRequired;
                    IsFieldtourRequiredNoCheckBox.Checked = !adapters[0].IsFieldTourRequired;
                }
                else
                {
                    IsFieldtourRequiredYesCheckBox.Checked = !adapters[0].IsFieldTourRequired;
                    IsFieldtourRequiredNoCheckBox.Checked = adapters[0].IsFieldTourRequired;
                }
                if (adapters[0].IssuedToSuncor && adapters[0].IssuedToContractor)
                {
                    CompanyTableCell.Text = string.Format("Suncor / {0}", adapters[0].Company);
                }
                else if (adapters[0].IssuedToSuncor)
                {
                    
                    CompanyTableCell.Text = "Suncor";
                }
                else
                {
                    CompanyTableCell.Text = adapters[0].Company;
                }
                if (adapters[0].WorkPermitType == WorkPermitFortHillsType.BLANKET_HOT.Name || adapters[0].WorkPermitType == WorkPermitFortHillsType.SPECIFIC_HOT.Name)
                {
                    WpCode.Text = "H";
                }
                else if (adapters[0].WorkPermitType == WorkPermitFortHillsType.BLANKET_COLD.Name || adapters[0].WorkPermitType == WorkPermitFortHillsType.SPECIFIC_COLD.Name)
                {
                    WpCode.Text = "C";
                }
                else
                {
                    WpCode.Text = "NA";
                }
                if (adapters[0].LockBoxNumber == string.Empty)
                {
                    lockBoxNoTableCell.Font = new Font("Arial", 6, FontStyle.Italic | FontStyle.Regular);
                    isolationNoTableCell.Font = new Font("Arial", 6, FontStyle.Italic | FontStyle.Regular);
                }
                else
                {
                    lockBoxNoTableCell.Text = adapters[0].LockBoxNumber;
                    isolationNoTableCell.Text = adapters[0].IsolationNo;
                }
                if (adapters[0].ExtensionDateTime == null)
                {
                    extensionDateTableCell.Font = new Font("Arial", 6, FontStyle.Italic | FontStyle.Regular);
                }
                if (adapters[0].RevalidationDateTime == null)
                {
                    revalidationDateTableCell.Font = new Font("Arial", 6, FontStyle.Italic | FontStyle.Regular);
                }
                if (adapters[0].FieldTourConductedBy.IsNullOrEmptyOrWhitespace())
                {
                    conductedByTableCell.Font = new Font("Arial", 6, FontStyle.Italic | FontStyle.Regular);
                }
                if (adapters[0].ExtendedByUser==null)
                {
                    extendedByUserTableCell.Font = new Font("Arial", 6, FontStyle.Italic | FontStyle.Regular);
                }
                else
                {
                    extendedByUserTableCell.Text = adapters[0].ExtendedByUser.FullName;  
                }

                //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - point 3.2 - 01-Nov-2018 start
                //xrPanelSignature.Visible = adapters[0].JobsiteEquipmentInspectedYes;         //ayman Edmonton work permit
                //xrPanelSignature.Visible = adapters[1].JobsiteEquipmentInspectedYes;        //ayman Edmonton work permit

                //if (adapters[0].JobsiteEquipmentInspectedYes && adapters[1].JobsiteEquipmentInspectedYes)
                //{
                //    xrPanelJobSite.Visible = true;
                //}
                //else
                //{
                //    xrPanelJobSite.Visible = false;
                //}
                //if (adapters[0].StatusOfPipingEquipmentSectionNotApplicableToJob && adapters[1].StatusOfPipingEquipmentSectionNotApplicableToJob)
                //{
                //    xrPanelMiddel.Visible = false;
                //    xrPanelLower.Location = xrPanelMiddel.Location;
                //}
                //else
                //{
                //    xrPanelMiddel.Visible = true;  //statusOfPipingEquipmentNotApplicable
                //}
                //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - point 3.2 -  01-Nov-2018 end
            }
        }

        public bool StringWillFitIntoTaskDescriptionField(string description)
        {
            return DevExpressMeasurementUtility.StringWillFitIntoField(
                taskDescriptionDataLabel.CreateLabelAttributes(), description);
        }

        public static LabelAttributes GetAttributesForHazardsLabel()
        {
            var report = new WorkPermitFortHillsReport();
            return report.hazardsDataLabel.CreateLabelAttributes();
        }

    }
}