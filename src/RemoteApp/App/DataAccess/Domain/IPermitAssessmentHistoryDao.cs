﻿using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IPermitAssessmentHistoryDao : IDao
    {
        [CachedQueryHistory]
        List<PermitAssessmentHistory> GetById(long id);

        [CachedInsertHistory]
        void Insert(PermitAssessmentHistory history);
    }
}