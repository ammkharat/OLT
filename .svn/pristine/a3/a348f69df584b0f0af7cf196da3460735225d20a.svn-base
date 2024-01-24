using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class ShiftHandoverQuestionnaireReportAdapterBuilder
    {
        private readonly ActionItemSubreportBuilder actionItemSubreportBuilder;
        private readonly CsdSubreportBuilder csdSubreportBuilder;
        private readonly EventExcursionsBuilder eventExcursionSubreportBuilder;
        private readonly IShiftHandoverService shiftHandoverService;
        private readonly IShiftPatternService shiftPatternService;

        public ShiftHandoverQuestionnaireReportAdapterBuilder(IShiftHandoverService shiftHandoverService,
            IActionItemDefinitionService actionItemDefinitionService, IShiftPatternService shiftPatternService,
            IActionItemService actionItemService, IFunctionalLocationOperationalModeService operationalModeService,
            SiteConfiguration siteConfiguration, IFormEdmontonService lubesCsdService, RootFlocSet rootFlocSet,
            IExcursionResponseService excursionResponseService)
        {
            this.shiftHandoverService = shiftHandoverService;
            this.shiftPatternService = shiftPatternService;

            actionItemSubreportBuilder = new ActionItemSubreportBuilder(actionItemDefinitionService, actionItemService,
                operationalModeService, siteConfiguration);

            csdSubreportBuilder = new CsdSubreportBuilder(actionItemDefinitionService, actionItemService,
                lubesCsdService, rootFlocSet, operationalModeService, siteConfiguration);
            eventExcursionSubreportBuilder = new EventExcursionsBuilder(excursionResponseService);
        }

        public List<ShiftHandoverQuestionnaireReportAdapter> GetShiftHandoverQuestionnaireReportAdapters(
            ShiftHandoverQuestionnaire questionnaire, SiteConfiguration siteConfiguration, Site site)
        {
            var actionItemReportAdaptersForQuestionnaire = QueryActionItems(questionnaire, siteConfiguration, site);

            var associatedItems = shiftHandoverService.QueryAssocationedItems(questionnaire.IdValue,
                questionnaire.CreatedShiftStartDate,
                questionnaire.Shift.IdValue, questionnaire.Assignment.IdValue,
                questionnaire.RelevantCokerCardConfigurations,site.Id.Value);//Aarti

            var csdReportAdaptersForQuestionnaire = QueryCsds(questionnaire, siteConfiguration, site);
            var eventExcursionsReportAdaptersForQuestionnaire = QueryEventExcursions(questionnaire);

            var questionnaireAdapter = new ShiftHandoverQuestionnaireReportAdapter(questionnaire, associatedItems,
                actionItemReportAdaptersForQuestionnaire, csdReportAdaptersForQuestionnaire,eventExcursionsReportAdaptersForQuestionnaire);

            return new List<ShiftHandoverQuestionnaireReportAdapter> {questionnaireAdapter};
        }

        private List<CsdReportAdapter> QueryCsds(ShiftHandoverQuestionnaire questionnaire,
            SiteConfiguration siteConfiguration, Site site)
        {
            var showLubesCsdsOnShiftHandoverReport = questionnaire.Assignment != null &&
                                                     questionnaire.Assignment.ShowLubesCsdOnShiftHandoverReport;

            List<CsdReportAdapter> csdReportAdaptersForQuestionnaire = null;

            if (showLubesCsdsOnShiftHandoverReport)
            {
                csdReportAdaptersForQuestionnaire = csdSubreportBuilder.GetCsdReportAdapters(questionnaire, site);
            }

            return csdReportAdaptersForQuestionnaire;
        }

        private List<EventExcursionReportAdapter> QueryEventExcursions(ShiftHandoverQuestionnaire questionnaire)
        {
            var showEventExcursionsOnShiftHandoverReport = questionnaire.Assignment != null &&
                                                           questionnaire.Assignment
                                                               .ShowEventExcursionsOnShiftHandoverReport;

            List<EventExcursionReportAdapter> eventExcursionReportAdapters = null;

            if (showEventExcursionsOnShiftHandoverReport)
            {
                eventExcursionReportAdapters =
                    eventExcursionSubreportBuilder.GetEventExcursionReportAdapters(questionnaire);
            }

            return eventExcursionReportAdapters;
        }


        private List<ActionItemReportAdapter> QueryActionItems(ShiftHandoverQuestionnaire questionnaire,
            SiteConfiguration siteConfiguration, Site site)
        {
            var actionItemReportAdaptersForQuestionnaire =
                siteConfiguration.ShowActionItemsOnShiftHandover
                    ? actionItemSubreportBuilder.GetActionItemReportAdapters(questionnaire,
                        ChooseNextShift(questionnaire, site))
                    : new List<ActionItemReportAdapter>(0);

            return actionItemReportAdaptersForQuestionnaire;
        }

        private UserShift ChooseNextShift(ShiftHandoverQuestionnaire questionnaire, Site site)
        {
            var potentialNextShifts = shiftPatternService.QueryBySite(site);
            var questionnaireUserShift = new UserShift(questionnaire.Shift, questionnaire.CreatedShiftStartDate);
            return questionnaireUserShift.ChooseNextShift(potentialNextShifts);
        }
    }
}