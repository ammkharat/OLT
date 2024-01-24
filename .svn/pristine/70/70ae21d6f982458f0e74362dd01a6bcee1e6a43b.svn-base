using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IFormGN75AHistoryDao : IDao
    {
        [CachedQueryHistory]
        List<FormGN75AHistory> GetById(long id);

        [CachedInsertHistory]
        void Insert(FormGN75AHistory history);
    }
}
