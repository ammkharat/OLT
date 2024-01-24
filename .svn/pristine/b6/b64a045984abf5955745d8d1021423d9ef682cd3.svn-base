using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class DirectivePrintActions : PrintActions<Directive, DirectiveReport, DirectiveReportAdapter>
    {
        protected override DirectiveReport CreateSpecificReport()
        {
            return new DirectiveReport();
        }

        protected override List<DirectiveReportAdapter> CreateReportAdapter(Directive domainObject)
        {
            //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
            DirectiveReportAdapter Dra = new DirectiveReportAdapter(domainObject);
            Dra.Images = domainObject.Imagelist;
            return new List<DirectiveReportAdapter> {Dra};

            //return new List<DirectiveReportAdapter> { new DirectiveReportAdapter(domainObject) }; //comented by vibhor
        }

        public override string ReportTitle(Directive domainObject)
        {
            return StringResources.Directives;
        }

        protected override ReportPrintPreference CreateReportPrintPreference(DirectiveReport report, UserPrintPreference userPrintPreferences)
        {            
            return new ReportPrintPreference(report, 1, true, false, string.Empty, true);
        }
    }
}
