using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Forms.Reporting;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;
using Com.Suncor.Olt.Reports.Adapters;
using ExcelExporter = Com.Suncor.Olt.Client.Excel.ExcelExporter;
using System.Data;
using System.Windows.Forms;
using System.Text;

namespace Com.Suncor.Olt.Client.Presenters.Reporting
{
    public class ActionItemReadingReportFormPresenter //: AddEditBaseFormPresenter<IActionItemResponseFormView, TrackerReport> //AbstractReportPagePresenter<IDailyShiftLogReportParametersControl, ActionItemDTO, ReadingReport, ReadingReportAdapter>
    {
        private readonly BackgroundWorker backgroundWorker = new ClientBackgroundWorker();
        private readonly IDateRangeWithActionItemReadingReportCriteriaFormView view;
        private readonly IStreamingReportingService reportingService;
        private readonly IActionItemDefinitionService actionItemsDefService;
        private readonly IShiftPatternService shiftPatternService;
        private readonly IActionItemService Service;
        private readonly PrintActions<TrackerReport, ReadingReport, ReadingReportAdapter> printActions;
        private readonly IReportPrintManager<ActionItem> reportPrintManager;      

        public ActionItemReadingReportFormPresenter() //: base(new IActionItemResponseFormView(), TrackerReport)
        {
            view = new DateRangeWithActionItemReadingReportCriteriaForm()
            { Title = "Action Item Reading Report" };  // StringResources.CustomFieldTrendReportFormTitle };

            view.FormLoad += HandleFormLoad;
            view.RunReportButtonClick += HandleRunReportButtonClick;
            view.CancelButtonClick += HandleCancelButtonClick;
            view.FormClose += HandleFormClose;
            view.GetDefinitionsButtonClick += HandleGetDefinitionClick;

             Service = ClientServiceRegistry.Instance.GetService<IActionItemService>();
            printActions = new ReadingReportPrintActions("Reading Report");
            //            PrintActions<ActionItem, ReadingReport, ReadingReportAdapter> printActions = new ReadingPrintActions(actionItemService);
            //            var printActions = new ReadingPrintActions(Service);            //ReportPrintManager = new ReportPrintManager<ActionItem, ActionItemReport, ActionItemMainReportAdapter>(new ActionItemPrintActions());
            //  reportPrintManager = new ReportPrintManager<ActionItem, ReadingReport, ReadingReportAdapter>(printActions);           //ayman Sarnia eip DMND0008992
            reportingService = ClientServiceRegistry.Instance.GetService<IStreamingReportingService>();
            actionItemsDefService = ClientServiceRegistry.Instance.GetService<IActionItemDefinitionService>();
            shiftPatternService = ClientServiceRegistry.Instance.GetService<IShiftPatternService>();

            //backgroundWorker.DoWork += GenerateReportInBackground;
            backgroundWorker.RunWorkerCompleted += GenerateReportInBackgroundComplete;
            backgroundWorker.WorkerSupportsCancellation = true;
        }

        protected PrintActions<TrackerReport, ReadingReport, ReadingReportAdapter> PrintActions
        {
            get { return printActions; }
        }

        public void Run(IMainForm form)
        {
            view.ShowDialog(form);
            view.Dispose();
        }

        

        public void HandleFormLoad()
        {
            Date now = Clock.Now.ToDate();
            view.StartDate = now;
            view.EndDate = now;
            view.RunReportButtonEnabled = false;

            IAuthorized authorized = new Authorized();
            UserRoleElements userRoleElements = ClientSession.GetUserContext().UserRoleElements;

        }

        private void HandleFormClose()
        {
            if (backgroundWorker != null && backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
            }
        }

        protected List<ShiftPattern> GetPossibleShifts(Site site)
        {
            return shiftPatternService.QueryBySite(site);
        }

        public void HandleRunReportButtonClick()
        {

            if (Validate())
            {
                List<TrackerReport> TrackersToShow = Service.GetTrackersByAidId(view.SelectedAId,Convert.ToDateTime(view.StartDate.ToString()),Convert.ToDateTime(view.EndDate.ToString()));

                //view.RunReportButtonEnabled = false;
               
              
                DataTable dt = new DataTable();
                if (TrackersToShow.Count > 0)
                {
                    string[] strcol = TrackersToShow[0].ListTime.Split(';');
                    dt.Columns.Add("Field Name");
                    foreach(string str in strcol)
                    {
                      
                        string str1=str;//.Substring(0,str.Length-2);
                       
                        dt.Columns.Add(str1.ToUpper());
                    }
                    foreach (TrackerReport rpt in TrackersToShow)
                    {
                        DataRow drow = dt.NewRow();
                        drow[0] = rpt.CustomFieldName;
                        int i = 0;
                        foreach(string str in rpt.ListValue.Split(';'))
                        {
                            i++;
                            drow[i] = str;
                        }
                        dt.Rows.Add(drow);
                    }
                }

                if (view.RptType == "Excel")
                {
                    Export(dt);
                    return;
                }
                

                //For Graph Report
                  if (TrackersToShow != null)
                {
                    TrackerReport Trackers = TrackersToShow[0];
                    Trackers.ActionItemDefinitionName = view.ActionItemName.ToUpper();
                    Trackers.dt = dt;
                    Trackers.ActionItemDefinitionName = view.ActionItemName;
                    Trackers.GraphType = view.graphtype;
                    XtraReport report = printActions.CreateReport(Trackers);
                    ReportPrintTool printTool = new ReportPrintTool(report);
                    UserLookAndFeel userLookAndFeel = new UserLookAndFeel(this);
                    userLookAndFeel.UseDefaultLookAndFeel = false;
                    userLookAndFeel.SkinName = "office 2016 colorful";
                    printTool.ShowRibbonPreview(userLookAndFeel);
                    return;
                }


                 
                
            }
        }

        public void Export(DataTable dset)
        {
            
            SaveFileDialog savefile = new SaveFileDialog();
           
            savefile.FileName = "Response"+ "_" + DateTime.Now.ToString("yyyyMMddHHmmss")+".xls";
            if (dset.Rows.Count > 0)
            {
                savefile.FileName =Convert.ToString(dset.Rows[0][dset.Columns.Count-2]) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            }
            savefile.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (dset.Rows.Count > 0)
            {
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter wr = new StreamWriter(savefile.FileName);
                    //StreamWriter wr = new StreamWriter(savefile.FileName, false, Encoding.UTF8);
                    wr.Write("<HTML><HEAD>");
                    wr.Write("<style>TD {font-family:Verdana; font-size: 11px;} </style>");
                    wr.Write("</HEAD><BODY>");
                    wr.Write("<TABLE border='1'  >");
                   // wr.Write("<TR>" + dset.Rows[0][dset.Columns.Count-2] + "</TR>");
                    wr.Write("<TD align='center' style='font-family: Verdana; font-size: 13px; font-weight: bold''>Action Item Name :- " + dset.Rows[0][dset.Columns.Count - 2] + "</TD>");
                    wr.Write("<TR>");
                    for (int i = 0; i < dset.Columns.Count - 1; i++)
                    {

                        string strcolmn = dset.Columns[i].ToString().ToUpper();
                        if (strcolmn.Contains("_"))
                        {
                            strcolmn = strcolmn.Substring(0, strcolmn.Length - 2);
                        }
                        strcolmn = "<TD align='center' style='font-family: Verdana; font-size: 13px; font-weight: bold;background-color: gray'>" + strcolmn + "</TD>";
                        wr.Write(strcolmn);                     

                    }

                    wr.WriteLine("</TR>");
                    for (int i = 0; i < (dset.Rows.Count); i++)
                    {
                        wr.Write("<TR>");
                        for (int j = 0; j < dset.Columns.Count - 1; j++)
                        {
                            if (dset.Rows[i][j] != null)
                            {
                                if (j == 0)
                                {
                                    wr.Write("<TD align='center' style='font-family: Verdana; font-size: 13px; font-weight: bold''>" + dset.Rows[i][j] + "</TD>");
                                }
                                else
                                {
                                    wr.Write("<TD align='center' style='font-family: Verdana; font-size: 13px''>" + dset.Rows[i][j] + "</TD>");
                                }
                               // wr.Write(Convert.ToString(dset.Rows[i][j]) + "\t");
                            }
                            else
                            {
                                wr.Write("<TD<</TD>");
                            }
                        }
                        //go to next line
                        wr.WriteLine();
                    }

                    wr.Write("</TABLE>");
                    wr.Write("</BODY></HTML>");
                    wr.WriteLine();
 
                    //close file
                    wr.Close();
                    Olt.Client.OltControls.OltMessageBox.Show("Data saved in Excel format at location " + savefile.FileName );
                }
            }
            else
            {
                Olt.Client.OltControls.OltMessageBox.Show("No record to export");
            }


        }
      

        protected static UserShift CreateCorrectUserShift(ShiftPattern pattern, Date selectedDay)
        {
            return new UserShift(pattern, CreateCorrectDateTimeForShiftPattern(selectedDay, pattern));
        }

        private static DateTime CreateCorrectDateTimeForShiftPattern(Date day, ShiftPattern pattern)
        {
            const int shiftPaddingAsMinutes = 10;
            return new DateTime(day.Year,
                                day.Month,
                                day.Day,
                                pattern.StartTime.Hour,
                                pattern.StartTime.Minute + shiftPaddingAsMinutes,
                                pattern.StartTime.Second);
        }

        private bool Validate()
        {
            view.ClearErrors();

            bool isValid = true;

            if (view.StartDate > view.EndDate)
            {
                view.SetErrorForStartDate(StringResources.FromDateBeforeToDate);
                view.SetErrorForEndDate(StringResources.FromDateBeforeToDate);
                isValid = false;
            }


            return isValid;
        }

        public void HandleCancelButtonClick()
        {
            view.CloseForm();
        }

        public void HandleGetDefinitionClick()
        {
            LoadActionItems();
        }

        private void LoadActionItems()
        {
            var actionitems = actionItemsDefService.QueryActionItemDefReadingBySiteId(ClientSession.GetUserContext().Site.IdValue,view.StartDate,view.EndDate);

            view.RunReportButtonEnabled = (actionitems != null && actionitems.Count > 0);
            view.ActionitemDefinitions = actionitems;

        }


        private void GenerateReportInBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }

            view.RunReportButtonEnabled = true;

            if (e.Error != null)
            {
                throw e.Error;
            }

            using (Stream stream = (Stream) e.Result)
            {
                ExcelExporter excelExporter = new ExcelExporter();
                excelExporter.Export(stream);
            }

            view.CloseForm();
        }

        private class BackgroundJobArgs
        {

            public List<ActionItemResponseTracker> Trackers { get; private set; }
            public BackgroundJobArgs(List<ActionItemResponseTracker> trackers)
            {
                Trackers = trackers;
            }
        }

    }
}
