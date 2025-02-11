﻿using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IPermitRequestMudsDTODao : IDao
    {
        List<PermitRequestMudsDTO> QueryByFlocUnitAndBelow(IFlocSet flocSet, DateRange dateRange);

        List<PermitRequestMudsDTO> QueryByFlocUnitAndBelowForTemplate(IFlocSet flocSet, DateRange dateRange, string username);

        
    }
}
