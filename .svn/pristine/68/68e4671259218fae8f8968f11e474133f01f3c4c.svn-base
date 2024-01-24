using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public abstract class PrintActions<TDomainObject, TReport, TReportAdapter> 
        where TDomainObject : DomainObject
        where TReportAdapter : IReportAdapter
        where TReport : XtraReport, IOltReport<TReportAdapter>
    {
        protected abstract TReport CreateSpecificReport();
        protected abstract List<TReportAdapter> CreateReportAdapter(TDomainObject domainObject);
        public abstract string ReportTitle(TDomainObject domainObject);

        public TReport CreateReport(IEnumerable<TDomainObject> domainObjects)
        {
            TReport specificReport = CreateSpecificReport();
            BeforeCreateReportAdapter();
            List<TReportAdapter> reportAdapters = new List<TReportAdapter>();
            foreach (TDomainObject domainObject in domainObjects)
            {
                reportAdapters.AddRange(CreateReportAdapter(domainObject));
            //    AddAssociatedReports(xtraReport, workPermit); // Not sure when this needs to be done, and nothing calling this method is using this right now.
            }

            specificReport.SetMasterAndSubReportDataSource(reportAdapters, Clock.Now);
            //AddPageSpecificWatermarks(xtraReport, reportAdapters);  // Not sure when this needs to be done, and nothing calling this method is putting page specific watermarks.

            specificReport.CreateDocument();  // this is very important in order to make sure the report respects the page size.
            //xtraReport.PrintingSystem.ContinuousPageNumbering = true;  // Not sure when this needs to be done, and nothing calling this method is putting page specific watermarks.

            return specificReport;
        }

        public TReport CreateReport(TDomainObject domainObject)
        {
            BeforeCreateReportAdapter();
            List<TReportAdapter> reportAdapters = CreateReportAdapter(domainObject);
            TReport specificReport = CreateSpecificReport();
            specificReport.SetMasterAndSubReportDataSource(reportAdapters, Clock.Now);
            specificReport.CreateDocument();  // this is very important in order to make sure the report respects the page size.

            AddPageSpecificWatermarks(specificReport, reportAdapters);
            AddAssociatedReports(specificReport, domainObject);

            specificReport.PrintingSystem.ContinuousPageNumbering = true;

            return specificReport;
        }

        protected virtual void AddAssociatedReports(TReport mainReport, TDomainObject domainObject)
        {
        }

        protected virtual void AddPageSpecificWatermarks(TReport report, IEnumerable<TReportAdapter> adapters)
        {
        }

        public virtual void BeforePrintAction(TDomainObject domainObject)
        {
        }

        public virtual void AfterPrintAction(TDomainObject domainObject)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectsToPrint"></param>
        /// <returns>true if printing should continue, otherwise false.</returns>
        public virtual bool BeforeFirstPrint(List<TDomainObject> objectsToPrint)
        {
            return true;
        }

        protected Watermark CreateTextWatermark(string text)
        {
            Watermark textWatermark = new Watermark
            {
                Text = text,
                TextDirection = DirectionMode.ForwardDiagonal,
                ForeColor = Color.Gray,
                TextTransparency = 150,
                ShowBehind = false
            };

            FontFamily fontFamily = textWatermark.Font.FontFamily;
            Font font = new Font(fontFamily, 48);  // hold your horses.  Don't increase the font size over 48 or the report will take forever to print!
            textWatermark.Font = font;

            return textWatermark;
        }


        public virtual void ShowNotAbleToPrintError()
        {
        }

        public ReportPrintPreference CreateReportPrintPreferences()
        {
            return CreateReportPrintPreference(CreateSpecificReport(), ClientSession.GetUserContext().User.WorkPermitPrintPreference);            
        }

        public virtual void BeforeCreateReportAdapter()
        {
            
        }

        protected abstract ReportPrintPreference CreateReportPrintPreference(TReport report, UserPrintPreference userPrintPreferences);
    }
}