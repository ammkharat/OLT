using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ILabAlertDao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        LabAlert Insert(LabAlert alert);
        [CachedInsertOrUpdate(false, false)]
        void UpdateStatusAndResponses(LabAlert alert);
        [CachedQueryById]
        LabAlert QueryById(long id);
    }
}
