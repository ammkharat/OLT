using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IFormGN1HistoryDao : IDao
    {
        [CachedQueryHistory]
        List<FormGN1History> GetById(long id);

        [CachedInsertHistory]
        void Insert(FormGN1History history);
    }
}
