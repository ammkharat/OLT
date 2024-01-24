using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Excursions;

namespace Com.Suncor.Olt.Common.DTO.Excursions
{
    [Serializable]
    public class OpmExcursionImportStatusDTO : DomainObject
    {
        public OpmExcursionImportStatusDTO(long id, OpmExcursionImportStatus status,
            DateTime? lastSuccessfulExcursionImportDateTime) : base(id)
        {
            Status = status;
            LastSuccessfulExcursionImportDateTime = lastSuccessfulExcursionImportDateTime;
        }

        public OpmExcursionImportStatus Status { get; set; }
        public DateTime? LastSuccessfulExcursionImportDateTime { get; set; }
    }
}