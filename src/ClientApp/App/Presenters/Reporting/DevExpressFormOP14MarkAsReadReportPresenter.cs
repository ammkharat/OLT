using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Client.Controls.Reporting;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters.Reporting
{
    public class DevExpressFormOP14MarkAsReadReportPresenter : AbstractReportPagePresenter<IDateRangeReportParametersControl, CSDMarkAsReadReportItem, FormOP14MarkAsReadReport, FormOP14MarkAsReadReportAdapter>
    {
       // private readonly ITagInfoGroupService tagInfoGroupService;
       // private readonly IFormEdmontonService service;
        /*amitshukla testing*/
        // private readonly PrintActions<CSDMarkAsReadReportItemByDate, FormOP14MarkAsReadReport, FormOP14MarkAsReadReportAdapter> printActions;
        private readonly PrintActions<CSDMarkAsReadReportItem, FormOP14MarkAsReadReport, FormOP14MarkAsReadReportAdapter> printActions;

        public DevExpressFormOP14MarkAsReadReportPresenter()
            : base(StringResources.ReportLabel_Title_FORMOP14MarkAsReadReport, new RtfReportsPage())
        {
           // tagInfoGroupService = ClientServiceRegistry.Instance.GetService<ITagInfoGroupService>();
            //printActions = new DailyShiftLogReportPrintActions(StringResources.ReportLabel_Title_DailyShiftLog);
            printActions = new FormOP14MarkAsReadReportPrintActions(StringResources.ReportLabel_Title_FORMOP14MarkAsReadReport);
        }

        protected override IDateRangeReportParametersControl CreateParametersControl()
        {
            return new DateRangeReportParametersControl();
        }

        protected override void InitializeParameters()
        {
            parameters.SelectedStartDate = Clock.Now.ToDate();
            parameters.SelectedEndDate = Clock.Now.AddDays(5).ToDate();
        }
        
        //protected override List<CSDMarkAsReadReportItemByDate> CreateDataSource()
        //{
        //    List<CSDMarkAsReadReportItemByDate> reportdata =  new List<CSDMarkAsReadReportItemByDate>();

        //    List<CSDMarkAsReadReportItem> reportDto = service.GetFormOP14MarkedAsReadReport(parameters.SelectedStartDate, parameters.SelectedEndDate);

        //    for (Date date = parameters.SelectedStartDate; parameters.SelectedEndDate.CompareTo(date) >= 0; date = date.AddDays(1))
        //    {
        //        List<CSDMarkAsReadReportItem> data = reportDto.Where(i => i.TheDate == date).ToList();
        //        CSDMarkAsReadReportItemByDate obj = new CSDMarkAsReadReportItemByDate(data,date);
        //       reportdata.Add(obj);
        //    }
        //    return reportdata;

        //}

        protected override List<CSDMarkAsReadReportItem> CreateDataSource()
        {
            return service.GetFormOP14MarkedAsReadReport(parameters.SelectedStartDate, parameters.SelectedEndDate, ClientSession.GetUserContext().SiteId); 
        }

        //protected override PrintActions<CSDMarkAsReadReportItemByDate, FormOP14MarkAsReadReport, FormOP14MarkAsReadReportAdapter> PrintActions
        //{
        //    get { return printActions; }
        //}
        /*amitshukla testing*/
        protected override PrintActions<CSDMarkAsReadReportItem, FormOP14MarkAsReadReport, FormOP14MarkAsReadReportAdapter> PrintActions
        {
            get { return printActions; }
        }
        
        //private List<TagInfoGroup> GetAvailableTagInfoGroupList()
        //{
        //    Site site = ClientSession.GetUserContext().Site;
        //    return tagInfoGroupService.QueryTagInfoGroupListBySite(site);
        //}

    }
}