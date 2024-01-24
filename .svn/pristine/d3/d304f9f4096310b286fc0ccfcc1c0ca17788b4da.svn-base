using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Analytics;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Services.Excel;
using log4net;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class StreamingReportingService : IStreamingReportingService
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(StreamingReportingService).Name);

        private readonly ReportingService service;

        public StreamingReportingService()
        {
            service = new ReportingService();
        }

        // AutoDisposeParameters is the default but I want to be explicit. This should dispose of the returned stream on the server side.
        [OperationBehavior(AutoDisposeParameters = true)]
        public Stream GetCustomFieldTrendReportData(RootFlocSet rootFlocSet, UserShift startUserShift,
                                                    UserShift endUserShift, List<WorkAssignment> workAssignments,
                                                    bool includeNullWorkAssignment, bool includeLogs,
                                                    bool includeSummaryLogs, bool includeDailyDirectives)
        {
            List<CustomFieldTrendReportDTO> result = service.GetCustomFieldTrendReportData(rootFlocSet, startUserShift,
                                                                                           endUserShift, workAssignments,
                                                                                           includeNullWorkAssignment,
                                                                                           includeLogs,
                                                                                           includeSummaryLogs,
                                                                                           includeDailyDirectives);

            ExcelWriter excelStreamWriter = new ExcelWriter();
            Stream stream = excelStreamWriter.RenderExcelDataToMemoryStream(new CustomFieldTrendReportExcelDataRenderer(result));

            logger.DebugFormat("Stream size is {0}", stream.Length);
            return stream;
        }

        [OperationBehavior(AutoDisposeParameters = true)]
        public Stream GetFormOilsandsTrainingReportData(RootFlocSet rootFlocSet, UserShift startUserShift,
                                                    UserShift endUserShift, List<WorkAssignment> workAssignments)
        {
            List<FormOilsandsTrainingReportDTO> result = service.GetFormOilsandsTrainingReportData(rootFlocSet, startUserShift,
                                                                                           endUserShift, workAssignments);

            ExcelWriter excelStreamWriter = new ExcelWriter();
            Stream stream = excelStreamWriter.RenderExcelDataToMemoryStream(new FormOilsandsTrainingReportExcelDataRenderer(result));

            logger.DebugFormat("Stream size is {0}", stream.Length);
            return stream;
        }

        [OperationBehavior(AutoDisposeParameters = true)]
        public Stream GetMarkedAsReadReportData(Site site, Date fromDate, Date toDate, IFlocSet flocSet, bool includeLogs, bool includeSummaryLogs, bool includeDirectiveLogs,
                                                bool includeShiftHandovers, bool includeDirectives, bool includeFlexiShiftDataonly)
        {
            MarkedAsReadReportDTO markedAsReadReportData = service.GetMarkedAsReadReportData(site, fromDate, toDate, flocSet, includeLogs, includeSummaryLogs, includeDirectiveLogs,
                                                                                             includeShiftHandovers, includeDirectives, includeFlexiShiftDataonly);

            ExcelWriter excelStreamWriter = new ExcelWriter();
            Stream stream =
                excelStreamWriter.RenderExcelDataToMemoryStream(new MarkedAsReadReportExcelDataRenderer(markedAsReadReportData, includeLogs, includeSummaryLogs, includeDirectiveLogs,
                                                                                                        includeShiftHandovers, includeDirectives, includeFlexiShiftDataonly));

            logger.DebugFormat("Stream size is {0}", stream.Length);
            return stream;
        }
        //Added by ppanigrahi

        [OperationBehavior(AutoDisposeParameters = true)]
        public Stream GetMarkedAsNotReadReportData(Site site, Date fromDate, Date toDate, IFlocSet flocSet, bool includeDirectiveLogs,
                                                bool includeShiftHandovers, bool includeDirectives)
        {
           // MarkedAsReadReportDTO markedAsReadReportData = service.GetMarkedAsReadReportData(site, fromDate, toDate, flocSet,  includeDirectiveLogs,
                                                                                            // includeShiftHandovers, includeDirectives,);
            MarkedAsNotReadReportDTO markedAsNotReadReportData = service.GetMarkedAsNotReadReportData(site, fromDate, toDate, flocSet,includeDirectiveLogs,includeShiftHandovers,includeDirectives);
            ExcelWriter excelStreamWriter = new ExcelWriter();
            Stream stream =  excelStreamWriter.RenderExcelDataToMemoryStream(new MarkedAsNotReadReportExcelDataRenderer(markedAsNotReadReportData,includeDirectiveLogs,includeShiftHandovers, includeDirectives));

            logger.DebugFormat("Stream size is {0}", stream.Length);
            return stream;
        }

        [OperationBehavior(AutoDisposeParameters = true)]
        public Stream GetRestrictionReportData(Date startDate, Date endDate, IFlocSet flocSet)
        {
            List<DeviationAlertReportDTO> result = service.GetRestrictionReportData(startDate, endDate, flocSet);

            ExcelWriter excelStreamWriter = new ExcelWriter();
            Stream stream = excelStreamWriter.RenderExcelDataToMemoryStream(new RestrictionReportExcelDataRenderer(result));

            logger.DebugFormat("Stream size is {0}", stream.Length);
            return stream;
        }

        [OperationBehavior(AutoDisposeParameters = true)]
        public Stream GetTargetAlertReportData(IFlocSet flocSet, DateRange dateRange)
        {
            List<TargetAlertExcelReportDTO> result = service.GetTargetAlertReportData(flocSet, dateRange);

            ExcelWriter excelStreamWriter = new ExcelWriter();
            Stream stream = excelStreamWriter.RenderExcelDataToMemoryStream(new TargetAlertReportExcelDataRenderer(result));

            logger.DebugFormat("Stream size is {0}", stream.Length);
            return stream;
        }

        [OperationBehavior(AutoDisposeParameters = true)]
        public Stream GetSafeWorkPermitAssessmentReportData(IFlocSet flocSet, DateRange dateRange)
        {
            List<SafeWorkPermitAssessmentReportDTO> result = service.GetSafeWorkPermitAssessmentReportDtos(flocSet, dateRange);

            ExcelWriter excelStreamWriter = new ExcelWriter();
            Stream stream = excelStreamWriter.RenderExcelDataToMemoryStream(new SafewWorkPermitAssessmentReportExcelDataRenderer(result));

            logger.DebugFormat("Stream size is {0}", stream.Length);
            return stream;
        }

        [OperationBehavior(AutoDisposeParameters = true)]
        public Stream GetAnalyticsExcelExportData(DateTime fromDateTime, DateTime toDateTime, List<string> eventNames)
        {
            List<Event> result = service.GetAnalyticsExcelExportData(fromDateTime, toDateTime, eventNames);

            ExcelWriter excelStreamWriter = new ExcelWriter();
            Stream stream = excelStreamWriter.RenderExcelDataToMemoryStream(new AnalyticsExcelExportDataRenderer(result));

            logger.DebugFormat("Stream size is {0}", stream.Length);
            return stream;
        }
    }
}
