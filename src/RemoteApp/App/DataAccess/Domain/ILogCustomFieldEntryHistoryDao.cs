using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ILogCustomFieldEntryHistoryDao : IDao
    {
        List<CustomFieldEntryHistory> GetByHistoryId(long id);

        void Insert(List<CustomFieldEntryHistory> histories);
    }
}