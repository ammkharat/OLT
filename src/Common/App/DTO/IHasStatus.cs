using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.DTO
{
    public interface IHasStatus<T> where T : SortableSimpleDomainObject
    {
        T Status { get; }
    }
}