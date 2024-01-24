using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Reports.Printing
{
    public interface IOltReport<TReportAdapter> : IOltReport where TReportAdapter : IReportAdapter
    {
        void SetMasterAndSubReportDataSource(List<TReportAdapter> adapters, DateTime currentTimeInSite);
    }

    public interface IOltReport
    {
        void ExportToPdf(string filename);
    }
}