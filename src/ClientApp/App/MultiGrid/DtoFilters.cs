using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.MultiGrid
{
    public class DtoFilters
    {
        public Range<Date> Range { get; private set; }
        public List<FormStatus> FormStatus { get; private set; }

        public DtoFilters(Range<Date> range, List<FormStatus> formStatuses)
        {
            Range = range;
            FormStatus = formStatuses;
        }
    }
}