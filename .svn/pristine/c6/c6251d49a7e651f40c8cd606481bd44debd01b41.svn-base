using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class EventExcursionsBuilder
    {
        private readonly IExcursionResponseService excursionResponseService;

        public EventExcursionsBuilder(IExcursionResponseService excursionResponseService)
        {
            this.excursionResponseService = excursionResponseService;
        }


        public List<EventExcursionReportAdapter> GetEventExcursionReportAdapters(
            ShiftHandoverQuestionnaire questionnaire)
        {
            var excursionResponseDtos =
                excursionResponseService.QueryDTOsByDateRangeAndFlocsForShiftHandover(
                    questionnaire.CreatedShiftStartDateWithPadding,
                    questionnaire.CreatedShiftEndDateWithPadding,
                    questionnaire.FunctionalLocations);

            var eventExcursionReportAdapters = excursionResponseDtos.ConvertAll(
                opmExcursionResponseDTO =>
                    new EventExcursionReportAdapter(questionnaire.IdValue.ToString(CultureInfo.InvariantCulture),
                        opmExcursionResponseDTO));

            return eventExcursionReportAdapters.OrderBy(adapter => adapter.StartDateTime).ToList();
        }
    }
}