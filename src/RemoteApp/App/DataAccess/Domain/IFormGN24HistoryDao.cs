using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IFormGN24HistoryDao : IDao
    {
        [CachedQueryHistory]
        List<FormGN24History> GetById(long id);

        [CachedInsertHistory]
        void Insert(FormGN24History history);
    }
}