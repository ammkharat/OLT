using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using Com.Suncor.Olt.Reports.SubReports.ShiftHandoverQuestionnaire;
using DevExpress.XtraReports.UI;
using Com.Suncor.Olt.Common.Domain;
using System.Drawing;
using DevExpress.XtraPrinting;

namespace Com.Suncor.Olt.Reports
{
    public partial class RtfShiftHandoverQuestionnaireReport : XtraReport,
        IOltReport<ShiftHandoverQuestionnaireReportAdapter>
    {
        public RtfShiftHandoverQuestionnaireReport()
        {
            InitializeComponent();
        }

        public void SetMasterAndSubReportDataSource(List<ShiftHandoverQuestionnaireReportAdapter> questionnaireAdapters,
            DateTime currentTimeInSite)
        {
            DataSource = questionnaireAdapters;

            var commentsReportAdapters = new List<CommentsReportAdapter>();
            questionnaireAdapters.ForEach(a => commentsReportAdapters.AddRange(a.CommentsReportAdapters));
            CommentsSubreport.ReportSource.DataSource = commentsReportAdapters;

            var answerReportAdapters = new List<ShiftHandoverAnswerReportAdapter>();
            questionnaireAdapters.ForEach(a => answerReportAdapters.AddRange(a.AnswerReportAdapters));
            AnswersSubreport.ReportSource.DataSource = answerReportAdapters;

            var actionItemsAdapters = new List<ActionItemReportAdapter>();
            questionnaireAdapters.ForEach(a => actionItemsAdapters.AddRange(a.ActionItemReportReportAdapters));
            ActionItemsSubreport.ReportSource.DataSource = actionItemsAdapters;

            var cokerCardsAdapters = new List<CokerCardReportAdapter>();
            questionnaireAdapters.ForEach(a => cokerCardsAdapters.AddRange(a.CokerCardReportAdapters));
            CokerCardsSubreport.ReportSource.DataSource = cokerCardsAdapters;

            var customFieldsReportAdapters = new List<CustomFieldsReportAdapter>();
            questionnaireAdapters.ForEach(a => customFieldsReportAdapters.AddRange(a.CustomFieldsReportAdapters));
            CustomFieldsSubreport.ReportSource.DataSource = customFieldsReportAdapters;

            var csdAdapters = new List<CsdReportAdapter>();
            questionnaireAdapters.ForEach(a => csdAdapters.AddRange(a.CsdReportReportAdapters));
            CsdsSubreport.ReportSource.DataSource = csdAdapters;

            var excursionReportAdapters = new List<EventExcursionReportAdapter>();
            questionnaireAdapters.ForEach(a => excursionReportAdapters.AddRange(a.EventExcursionReportAdapters));
            EventExcursionSubReport.ReportSource.DataSource = excursionReportAdapters;

            printDateTime.Value = currentTimeInSite.ToLongDateAndTimeString();

            //Mukesh for Log Image
            bindImagelist(commentsReportAdapters);

        }

        private void EventExcursionSubReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var currentId = GetCurrentColumnValue("Id");

            var currentShiftHandoverId =
                ((EventExcursionsSubReport)((XRSubreport)sender).ReportSource).ShiftHandoverQuestionnaireId.Value;

            ((EventExcursionsSubReport)((XRSubreport)sender).ReportSource).ShiftHandoverQuestionnaireId.Value =
                GetCurrentColumnValue("Id");
        }

        //Mukesh for Log Image
        private void bindImagelist(List<CommentsReportAdapter> adp)
        {
            foreach (CommentsReportAdapter Cadp in adp)
            {
              
                if (Cadp.Imagelist != null && Cadp.Imagelist.Count > 0)
                {
                    xrTableImage.Visible = true;
                  
                    XRTableRow Hrow = new XRTableRow();
                    XRTableCell Hcell = new XRTableCell();
                    Hcell.Text = Cadp.LogDateTime + Cadp.LogTime;
                    Hrow.Cells.Add(Hcell);
                   
                    Hcell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                    Hrow.BackColor = Color.Silver;
                    xrTableImage.Rows.Add(Hrow);
                    foreach (LogImage Img in Cadp.Imagelist)
                    {

                        XRTableRow row = new XRTableRow();
                        XRTableCell cell1 = new XRTableCell();
                        XRTableCell cell2 = new XRTableCell();
                        XRTableCell cell3 = new XRTableCell();
                        XRPictureBox Picture = new XRPictureBox();
                        cell1.Text = Img.Name;
                        cell2.Text = Img.Description;
                        //Picture.ImageUrl = Img.ImagePath;


                       
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
                        else if (Img.Types.ToString().ToUpper() == "TITLE")
                        {
                            row.Cells.Add(cell1);
                            cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                            row.BackColor = Color.WhiteSmoke;
                        }
                        xrTableImage.Rows.Add(row);




                    }
                }
            }
        }
    }
}