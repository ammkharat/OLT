using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class CsdSubreportBuilder
    {
        private readonly IActionItemDefinitionService actionItemDefinitionService;
        private readonly IActionItemService actionItemService;
        private readonly IFormEdmontonService lubesCsdService;
        private readonly IFunctionalLocationOperationalModeService operationalModeService;
        private readonly RootFlocSet rootFlocSet;
        private readonly SiteConfiguration siteConfiguration;

        public CsdSubreportBuilder(
            IActionItemDefinitionService actionItemDefinitionService,
            IActionItemService actionItemService,
            IFormEdmontonService lubesCsdService,
            RootFlocSet rootFlocSet,
            IFunctionalLocationOperationalModeService operationalModeService,
            SiteConfiguration siteConfiguration)
        {
            this.actionItemDefinitionService = actionItemDefinitionService;
            this.actionItemService = actionItemService;
            this.lubesCsdService = lubesCsdService;
            this.rootFlocSet = rootFlocSet;
            this.operationalModeService = operationalModeService;
            this.siteConfiguration = siteConfiguration;
        }

        private List<CsdReportAdapter> SortCsdReportAdapters(IEnumerable<CsdReportAdapter> originalList)
        {
            return
                originalList.OrderByDescending(adapter => adapter.SystemDefeatedDateRawDateTime)
                    .ThenByDescending(adapter => adapter.EstimatedBackInServiceDateRawDateTime)
                    .ToList();
        }

        public List<CsdReportAdapter> GetCsdReportAdapters(ShiftHandoverQuestionnaire questionnaire, Site site)
        {
            var activeCsdReportAdapters = GetActiveCsdReportAdapters(questionnaire);

            var sortedList = SortCsdReportAdapters(activeCsdReportAdapters);

            return sortedList;
        }

        /// <summary>
        ///     Gets all active CSDs where the FLOC of the CSD matches the FLOCs on the handover report (up or down the tree, along the same branch
        ///     only).
        /// </summary>
        private IEnumerable<CsdReportAdapter> GetActiveCsdReportAdapters(ShiftHandoverQuestionnaire questionnaire)
        {
            var handoverQuestionnaireFlocs = new RootFlocSet(questionnaire.FunctionalLocations);

            var expiredOrActiveAndApprovedCsdDTOs =
                lubesCsdService.QueryFormLubesCsdsThatAreExpiredOrApprovedAndActiveByFunctionalLocations(
                    handoverQuestionnaireFlocs,
                    Clock.Now);

            var activeCsdReportAdapters = expiredOrActiveAndApprovedCsdDTOs.ConvertAll(
                csdDto => new CsdReportAdapter(questionnaire.IdValue.ToString(CultureInfo.InvariantCulture), csdDto));

            return activeCsdReportAdapters;
        }
    }
}