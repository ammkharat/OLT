using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IWorkPermitMudsDTODao : IDao
    {
        List<WorkPermitMudsDTO> QueryByDateRangeAndFlocs(Range<Date> dateRangeToQuery, IFlocSet flocSet);
        List<WorkPermitMudsTemplateDTO> QueryByDateRangeAndFlocsTemplate(Range<Date> dateRangeToQuery, IFlocSet flocSet, string username);
        
    }
}
