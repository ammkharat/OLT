using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Excursions;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IOpmExcursionDao : IDao
    {
        OpmExcursion QueryById(long id);
        OpmExcursion QueryByOpmExcursionId(long opmExcursionId);

        OpmExcursion Insert(OpmExcursion opmExcursion);
        void Update(OpmExcursion opmExcursion);
        OpmExcursion QueryMostRecentExcursionUpdateDateTime();
    }
}