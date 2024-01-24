using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IFormGN75BHistoryDao : IDao
    {
        [CachedQueryHistory]
        // List<FormGN75BHistory> GetById(long id);
        List<FormGN75BHistory> GetById(long id, long SiteId); //Aarti INC0548411

        [CachedInsertHistory]
        // void Insert(FormGN75BHistory history);
        void Insert(FormGN75BHistory history, long SiteId); //Aarti INC0548411
    }
}