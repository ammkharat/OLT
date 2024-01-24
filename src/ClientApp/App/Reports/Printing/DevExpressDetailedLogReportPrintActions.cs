using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class DevExpressDetailedLogReportPrintActions : PrintActions<DetailedLogReportDTO, RtfGenericMultiLogReport, GenericMultiLogReportAdapter>
    {
        private readonly AssignmentSectionUnitReportGroupBy groupBy;

        public DevExpressDetailedLogReportPrintActions(AssignmentSectionUnitReportGroupBy groupBy)
        {
            this.groupBy = groupBy;
        }

        protected override RtfGenericMultiLogReport CreateSpecificReport()
        {
            return new RtfGenericMultiLogReport();
        }

        protected override List<GenericMultiLogReportAdapter> CreateReportAdapter(DetailedLogReportDTO dto)
        {
            GenericMultiLogReportAdapterBuilder genericMultiLogReportAdapterBuilder = new GenericMultiLogReportAdapterBuilder(groupBy);
            return genericMultiLogReportAdapterBuilder.BuildAdapter(dto);
        }

        public override string ReportTitle(DetailedLogReportDTO domainObject)
        {
            return StringResources.ReportLabel_Title_DetailedLogReport;
        }

        protected override ReportPrintPreference CreateReportPrintPreference(RtfGenericMultiLogReport report, UserPrintPreference userPrintPreference)
        {
            return new ReportPrintPreference(report, 1, true, false, string.Empty, true);
        }
    }
}