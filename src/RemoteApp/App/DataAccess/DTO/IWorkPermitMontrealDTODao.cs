using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IWorkPermitMontrealDTODao : IDao
    {
        List<WorkPermitMontrealDTO> QueryByDateRangeAndFlocs(Range<Date> dateRangeToQuery, IFlocSet flocSet);

        List<WorkPermitMontrealDTO> QueryByDateRangeAndFlocsForTemplate(Range<Date> dateRangeToQuery, IFlocSet flocSet, string username);
    }
}
