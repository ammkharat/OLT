using System;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    public interface IFormSarniaDTO
    {
        long FormNumber { get; }
        FormStatus Status { get; }
        EdmontonFormType FormType { get; }
        long CreatedByUserId { get; set; }
        long LastModifiedByUserId { get; set; }
        bool IsWorkPermitDateTimesWithinFormDateTimes(Range<DateTime> workPermitDateRange);
        bool IsPermitRequestDatesWithinFormDates(Range<Date> workPermitDateRange);
    }
}