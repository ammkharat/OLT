using System;
using Com.Suncor.Olt.Common.DTO.Excursions;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IOpmExcursionImportStatusDTODao : IDao
    {
        OpmExcursionImportStatusDTO QueryLastSuccessfulImport();
        void UpdateAvailableImportStatus(DateTime? lastExcursionImportDateTime);
        void UpdateUnavailableImportStatus(DateTime? lastExcursionImportDateTime);
    }
}