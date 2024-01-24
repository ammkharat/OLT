using System;
using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class ActionItemReport : XtraReport, IOltReport<ActionItemMainReportAdapter>
    {
        public ActionItemReport()
        {
            InitializeComponent();

        }

        public void SetMasterAndSubReportDataSource(List<ActionItemMainReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            DataSource = adapters;
            if (adapters != null && adapters.Count > 0)
            {
                var adapter = adapters[0];
                flocSubreport.ReportSource.DataSource = adapter.GetFunctionalLocationsAdapters();
                customFieldsSubreport.ReportSource.DataSource = adapter.GetCustomFieldAdapters();   //ayman action item email
            }
            printDateTime.Value = currentTimeInSite.ToLongDateAndTimeString();

//RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

#region Adding Image to Report

            if (adapters[0].Images != null && adapters[0].Images.Count > 0)
            {
                xrLabelImage.Text = "Action Item Images";
                //xrTableImage.Rows.Clear();

                foreach (ImageUploader Img in adapters[0].Images)
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


                        Picture.WidthF = 450;//xrTableImage.Rows[0].Cells[2].WidthF;
                        Picture.HeightF = 200;//xrTableImage.Rows[0].Cells[2].WidthF;
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
                    else if (Img.Types.ToString().ToUpper() == "TITLE")
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

#endregion
        }
    }
}