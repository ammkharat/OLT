using System;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.DTO.Excursions;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class OpmExcursionImportStatusDTOFixture
    {
        public static OpmExcursionImportStatusDTO CreateAvailable()
        {
            return new OpmExcursionImportStatusDTO(998, OpmExcursionImportStatus.Available,
                DateTime.Now.Subtract(TimeSpan.FromMinutes(10)));
        }

        public static OpmExcursionImportStatusDTO CreateUnavailable()
        {
            return new OpmExcursionImportStatusDTO(999, OpmExcursionImportStatus.Unavailable,
                DateTime.Now.Subtract(TimeSpan.FromMinutes(30)));
        }
    }
}