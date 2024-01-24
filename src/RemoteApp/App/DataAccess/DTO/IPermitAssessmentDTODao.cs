using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IPermitAssessmentDTODao : IDao
    {
        List<PermitAssessmentDTO> QueryPermitAssessmentDtos(IFlocSet flocSet, DateRange dateRange);
    }
}