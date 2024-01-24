using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using System.Drawing;
using DevExpress.XtraPrinting;

namespace Com.Suncor.Olt.Reports
{
    public partial class RtfGenericSingleLogReport : XtraReport, IOltReport<GenericSingleLogReportAdapter>
    {
        public RtfGenericSingleLogReport()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<GenericSingleLogReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            DataSource = adapters;
            if (adapters.Count > 0)
            {
                
                
                var logReportAdapter = adapters[0];
                customFieldsSubreport.ReportSource.DataSource = logReportAdapter.GetCustomFieldAdapters();
                flocSubreport.ReportSource.DataSource = logReportAdapter.GetFunctionalLocationsAdapters();
                documentLinksSubreport.ReportSource.DataSource = logReportAdapter.GetDocumentLinkAdapters();
                lastModificationsSubreport.ReportSource.DataSource = logReportAdapter.GetLastModifiedByAdapters();
                markedAsReadBySubreport.ReportSource.DataSource = logReportAdapter.GetMarkedAsReadByAdapters();
                printDateTime.Value = currentTimeInSite.ToLongDateAndTimeString();

                //RITM0455787:EN50 : OLT - Rename the header in Construction Mgmt site  for Reports
                if (logReportAdapter.getSite != null)
                {
                    if (logReportAdapter.getSite.Id == Common.Domain.Site.Contruction_Mgnt_ID)
                    {
                        reportTitle.Text = logReportAdapter.Label_Title == StringResources.ReportLabel_Title_ShiftLog
                            ? StringResources.LogSectionNavigationTextForConstructionSite
                            : StringResources.SummaryLogTabTextForConstSite;
                    }
                }
                if (adapters[0].ActionItemResponseDetail == "")
                {
                    xrLabel1.Visible = false;
                    xrTableImage.Location = new Point(0,645);
                }
                //Mukesh for Log Image
                if (adapters[0].Images!=null && adapters[0].Images.Count > 0)
                {
                    xrLabelImage.Text ="Log Images" ;//StringResources.ReportLabel_CokerCards;
                    //xrTableImage.Rows.Clear();
                    
                   
                    foreach (LogImage Img in adapters[0].Images)
                    {
                      
                        XRTableRow row = new XRTableRow();
                        XRTableCell cell1 = new XRTableCell();
                        XRTableCell cell2 = new XRTableCell();
                        XRTableCell cell3 = new XRTableCell();
                        XRPictureBox Picture = new XRPictureBox();
                        cell1.Text = Img.Name;
                        cell2.Text = Img.Description;
                                                                    
                       
                        if (Img.ImagePath != "")
                        {

                           
                            Picture.WidthF = xrTableImage.Rows[0].Cells[2].WidthF;
                            Picture.HeightF = xrTableImage.Rows[0].Cells[2].WidthF;
                            Picture.Sizing = ImageSizeMode.StretchImage;
                           
                         
                            Picture.ImageUrl = Img.ImagePath;
                            cell3.Controls.Add(Picture);

                            row.Cells.Add(cell1);
                            row.Cells.Add(cell2);
                            row.Cells.Add(cell3);

                            row.BackColor = Color.Transparent;
                            cell1.WidthF = xrTableImage.Rows[0].Cells[0].WidthF;
                            cell2.WidthF = xrTableImage.Rows[0].Cells[1].WidthF;
                            cell3.WidthF = xrTableImage.Rows[0].Cells[2].WidthF;
                          
                           
                        }
                        else if(Img.Types.ToString().ToUpper() == "TITLE")
                        {
                            row.Cells.Add(cell1);
                            cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                            row.BackColor = Color.WhiteSmoke;
                        }
                      
                       
                       
                        xrTableImage.Rows.Add(row);
                      


                    }
                }
                else
                {
                    xrTableImage.Rows.Clear();
                    xrLabelImage.Visible = false;
                    xrTableImage.Visible = false;
                }
               
            }
        }

       
    }
}