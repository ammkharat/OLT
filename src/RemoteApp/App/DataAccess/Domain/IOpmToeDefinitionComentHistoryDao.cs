using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Excursions;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IOpmToeDefinitionCommentHistoryDao : IDao
    {
        List<OpmToeDefinitionCommentHistory> GetByToeName(string toeName);
        void Insert(OpmToeDefinitionCommentHistory history);
    }
}