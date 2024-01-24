using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class ShiftHandoverQuestionnairePrintActions :
        PrintActions
            <ShiftHandoverQuestionnaire, RtfShiftHandoverQuestionnaireReport, ShiftHandoverQuestionnaireReportAdapter>
    {
        private readonly ShiftHandoverQuestionnaireReportAdapterBuilder shiftHandoverQuestionnaireReportAdapterBuilder;

        public ShiftHandoverQuestionnairePrintActions(IShiftHandoverService shiftHandoverService,
            IActionItemDefinitionService actionItemDefinitionService,
            IShiftPatternService shiftPatternService, IActionItemService actionItemService,
            IFunctionalLocationOperationalModeService operationalModeService,
            IFormEdmontonService lubesCsdService,IExcursionResponseService excursionResponseService)
        {
            var userContext = ClientSession.GetUserContext();
            var rootFlocSet = userContext.RootFlocSet;

            shiftHandoverQuestionnaireReportAdapterBuilder =
                new ShiftHandoverQuestionnaireReportAdapterBuilder(shiftHandoverService, actionItemDefinitionService,
                    shiftPatternService, actionItemService, operationalModeService,
                    ClientSession.GetUserContext().SiteConfiguration, lubesCsdService, rootFlocSet, excursionResponseService);
        }

        protected override RtfShiftHandoverQuestionnaireReport CreateSpecificReport()
        {
            return new RtfShiftHandoverQuestionnaireReport();
        }

        protected override List<ShiftHandoverQuestionnaireReportAdapter> CreateReportAdapter(
            ShiftHandoverQuestionnaire questionnaire)
        {
            return
                shiftHandoverQuestionnaireReportAdapterBuilder.GetShiftHandoverQuestionnaireReportAdapters(
                    questionnaire, ClientSession.GetUserContext().SiteConfiguration, ClientSession.GetUserContext().Site);
        }

        public override string ReportTitle(ShiftHandoverQuestionnaire domainObject)
        {
            return StringResources.ShiftHandoverPrintFormTitle;
        }

        protected override ReportPrintPreference CreateReportPrintPreference(RtfShiftHandoverQuestionnaireReport report,
            UserPrintPreference userPrintPreference)
        {
            return new ReportPrintPreference(report, 1, true, false, string.Empty, true);
        }
    }
}