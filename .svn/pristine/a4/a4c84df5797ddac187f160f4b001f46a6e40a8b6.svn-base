using System;
using System.Collections.Generic;
using System.IO;
using Com.Suncor.Olt.Client.Excel;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class AnalyticsExcelExportFormPresenter : BaseFormPresenter<IAnalyticsExcelExportView>
    {
        private readonly IAnalyticsService analyticsService;
        private readonly IStreamingReportingService reportingService;

        public AnalyticsExcelExportFormPresenter() : base(new AnalyticsExcelExportForm())
        {
            analyticsService = ClientServiceRegistry.Instance.GetService<IAnalyticsService>();
            reportingService = ClientServiceRegistry.Instance.GetService<IStreamingReportingService>();

            view.FormLoad += HandleFormLoad;
            view.RunButtonClicked += HandleRunButtonClicked;
        }

        private void HandleFormLoad()
        {
            List<string> eventNames = analyticsService.QueryUniqueEventNames();
            view.EventNameValues = eventNames;
        }

        private void HandleRunButtonClicked()
        {
            bool isValid = Validate();
            
            if (!isValid)
            {
                return;
            }

            DateTime fromDateTime = view.FromDateTime;
            DateTime toDateTime = view.ToDateTime;

            List<string> eventNames = view.SelectedEventNames;

            Stream stream = reportingService.GetAnalyticsExcelExportData(fromDateTime, toDateTime, eventNames);

            ExcelExporter excelExporter = new ExcelExporter();
            excelExporter.Export(stream);

            view.Close();
        }

        private bool Validate()
        {
            bool isValid = true;

            if (view.FromDateTime > view.ToDateTime)
            {
                view.SetErrorForFromDateAfterToDate();
                isValid = false;
            }

            if (view.SelectedEventNames.Count == 0)
            {
                view.SetErrorForNoEventNamesSelected();
                isValid = false;
            }

            return isValid;
        }
    }
}
