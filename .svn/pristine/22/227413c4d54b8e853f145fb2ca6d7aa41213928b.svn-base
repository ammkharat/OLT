using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Reporting;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Client.Presenters.Reporting
{
    public abstract class AbstractReportPagePresenter<TParametersControl, TDomainObject, TReport, TReportAdapter> 
        where TParametersControl : class, IReportParametersControl
        where TDomainObject : DomainObject
        where TReportAdapter : IReportAdapter
        where TReport : XtraReport, IOltReport<TReportAdapter>
    {
        private readonly bool cacheReportParameters;
        protected readonly IReportingService service;
        private readonly IShiftPatternService shiftPatternService;
        private readonly IReportsPage page;
        protected readonly TParametersControl parameters;

        protected AbstractReportPagePresenter(string reportName, IReportsPage page)
            : this(reportName, ClientServiceRegistry.Instance.GetService<IReportingService>(), page, ClientServiceRegistry.Instance.GetService<IShiftPatternService>(), true)
        {
        }

        protected AbstractReportPagePresenter(string reportName, IReportsPage page, bool cacheReportParameters)
            : this(reportName, ClientServiceRegistry.Instance.GetService<IReportingService>(), page, ClientServiceRegistry.Instance.GetService<IShiftPatternService>(), cacheReportParameters)
        {
        }

        private AbstractReportPagePresenter(
            string reportName,
            IReportingService service,
            IReportsPage page,
            IShiftPatternService shiftPatternService,
            bool cacheReportParameters)
        {
            this.service = service;
            this.page = page;
            this.cacheReportParameters = cacheReportParameters; // Note: the call the GetParametersControl below depends on this being set first.
            parameters = GetParametersControl();
            this.shiftPatternService = shiftPatternService;            

            page.Title = reportName;
            page.Load += Page_Load;
            page.RunReportClicked += Page_RunReportClicked;
        }

        protected abstract TParametersControl CreateParametersControl();
        protected abstract void InitializeParameters();
        protected abstract List<TDomainObject> CreateDataSource();

        public IReportsPage Page
        {
            get { return page; }
        }

        private TParametersControl GetParametersControl()
        {
            Type key = GetType();

            TParametersControl control;

            if (cacheReportParameters)
            {
                control = ReportParametersControlRegistry.GetParametersControl<TParametersControl>(key);
                if (control == null)
                {
                    control = CreateControl();
                    ReportParametersControlRegistry.RegisterParametersControl(key, control);
                }                
            }
            else
            {
                control = CreateControl();                
            }

            return control;
        }

        private TParametersControl CreateControl()
        {
            TParametersControl control = CreateParametersControl();
            control.Load += ParameterControl_Load;
            return control;
        }

        private void ParameterControl_Load(object sender, EventArgs e)
        {
            // need to do this on parameter control load and not page load
            // for controls that contain floc trees
            InitializeParameters();
        }

        private void Page_Load(object sender, EventArgs e)
        {
            // Need to set parameter on page load so that the control sizes are preserved
            // each time the report is run.
            page.ParametersControl = parameters;
        }

        protected virtual void Page_RunReportClicked(object sender, EventArgs e)
        {
            if (parameters.IsValid)
            {
                List<TDomainObject> reportDataSource = CreateDataSource();
                if (null == reportDataSource || reportDataSource.Count == 0)
                {
                    page.DisplayErrorMessage(StringResources.ReportsPage_NoResultsFound);
                }
                else
                {
                    XtraReport xtraReport = PrintActions.CreateReport(reportDataSource);
                    page.Report = xtraReport;
                }
            }
            else
            {
                page.DisplayErrorMessage(parameters.ErrorMessage);
            }
        }

        protected abstract PrintActions<TDomainObject, TReport, TReportAdapter> PrintActions { get; }
     
        protected List<ShiftPattern> GetPossibleShifts()
        {
            return GetPossibleShifts(ClientSession.GetUserContext().Site);
        }

        protected List<ShiftPattern> GetPossibleShifts(Site site)
        {
            return shiftPatternService.QueryBySite(site);
        }

        protected static List<UserShift> GetUserShifts(List<ShiftPattern> shiftPatterns, Date selectedDay)
        {
            List<UserShift> userShifts =
                shiftPatterns.ConvertAll(shiftPattern => CreateCorrectUserShift(
                    shiftPattern, selectedDay));
            return userShifts;
        }

        public static UserShift CreateCorrectUserShift(ShiftPattern pattern, Date selectedDay)
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

    }
}