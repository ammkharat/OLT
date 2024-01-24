using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IFormLubesCsdHistoryDao : IDao
    {
        [CachedQueryHistory]
        List<LubesCsdFormHistory> GetById(long id);

        [CachedInsertHistory]
        void Insert(LubesCsdFormHistory history);
    }
}