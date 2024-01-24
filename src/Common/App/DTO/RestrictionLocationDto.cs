using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class RestrictionLocationDto : DomainObject
    {
        public RestrictionLocationDto(RestrictionLocation domainObject)
            : this(domainObject.IdValue, domainObject.Name)
        {
        }

        public RestrictionLocationDto(long id, string name) : base(id)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}