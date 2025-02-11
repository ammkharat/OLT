﻿using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IDirectiveDTODao : IDao
    {

        List<DirectiveDTO> QueryByDateRangeAndFlocs(Range<Date> dateRange, IFlocSet flocSet, List<long> visibilityGroupIds, long? readByUserId);     
        List<MarkedAsReadReportDirectiveDTO> QueryByParentFlocListAndMarkedAsRead(DateTime fromDateTime, DateTime toDateTime, IFlocSet flocSet);

        List<MarkedAsNotReadReportDirectiveDTO> QueryByParentFlocListAndMarkedAsNotRead(DateTime fromDateTime, DateTime toDateTime, IFlocSet flocSet);
    }
}
