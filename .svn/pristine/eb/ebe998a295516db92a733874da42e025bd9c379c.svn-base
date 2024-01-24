using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Utilities
{
    public class SubmitPermitRequestFormPresenterHelper<TPermitRequestDTO>
        where TPermitRequestDTO : BasePermitRequestDTO
    {

        public Date GetUnambiguousSubmissionDate(List<TPermitRequestDTO> requests)
        {
            Date unambiguousDate = null;

            foreach (TPermitRequestDTO request in requests)
            {
                Date submitDate;
                Date startDate = request.StartDate;
                Date endDate = request.EndDate;

                if (startDate == endDate)
                {
                    submitDate = endDate;
                }
                else if (endDate == Clock.DateNow)
                {
                    submitDate = endDate;
                }
                else
                {
                    return null;
                }

                if (unambiguousDate == null)
                {
                    unambiguousDate = submitDate;
                }
                else if (unambiguousDate != submitDate)
                {
                    return null;
                }
            }

            return unambiguousDate;
        }

        public Date GetDefaultWorkPermitDate(List<TPermitRequestDTO> requests)
        {
            Date date = Clock.DateNow.NextWeekDayDay;
            foreach (TPermitRequestDTO request in requests)
            {
                Date endDate = request.EndDate;
                if (endDate < date)
                {
                    date = endDate;
                }
            }
            return date;
        }
        
        public DateRange GetSharedDates(List<TPermitRequestDTO> requests)
        {
            Date latestStartDate = null;
            Date earliestEndDate = null;

            foreach (TPermitRequestDTO dto in requests)
            {
                if (latestStartDate == null || dto.StartDate > latestStartDate)
                {
                    latestStartDate = dto.StartDate;
                }

                if (earliestEndDate == null || dto.EndDate < earliestEndDate)
                {
                    earliestEndDate = dto.EndDate;
                }
            }

            if (latestStartDate == null || earliestEndDate == null || (earliestEndDate < latestStartDate))
            {
                return null;
            }

            return new DateRange(latestStartDate, earliestEndDate);
        }



    }
}
