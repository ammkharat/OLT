using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class ActionItemPrintActions : PrintActions<ActionItem, ActionItemReport, ActionItemMainReportAdapter>
    {
        protected override ActionItemReport CreateSpecificReport()
        {
            return new ActionItemReport();
        }

        protected override List<ActionItemMainReportAdapter> CreateReportAdapter(ActionItem actionItem)
        {
            ActionItemMainReportAdapter adapter = new ActionItemMainReportAdapter(actionItem);
            adapter.Images = actionItem.Imagelist;  //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
            return new List<ActionItemMainReportAdapter> {adapter};
        }

        public override string ReportTitle(ActionItem domainObject)
        {
            return StringResources.PrintActionItem;
        }

        protected override ReportPrintPreference CreateReportPrintPreference(ActionItemReport report, UserPrintPreference userPrintPreference)
        {
            return new ReportPrintPreference(report, 1, false, false, string.Empty, true);
        }
    }
}