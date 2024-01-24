using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IWorkPermitFortHillsDTODao : IDao
    {
        List<WorkPermitFortHillsDTO> QueryByDateRangeAndFlocs(Range<Date> dateRange, IFlocSet flocSet);
        List<WorkPermitFortHillsDTO> QueryByDateRangeAndFlocsAndPriorityIds(Range<Date> dateRange, IFlocSet flocSet, List<long> priorityIds, bool excludeTheGivenPriorityIds);
        //List<WorkPermitFortHillsDTO> QueryByFormGN59Id(long formGN59Id);
        //List<WorkPermitFortHillsDTO> QueryByFormGN7Id(long formGN7Id);
        //List<WorkPermitFortHillsDTO> QueryByFormGN24Id(long formGN24Id);
        //List<WorkPermitFortHillsDTO> QueryByFormGN6Id(long formGN6Id);
        //List<WorkPermitFortHillsDTO> QueryByFormGN75AId(long formGN6Id);
        //List<WorkPermitFortHillsDTO> QueryByFormGN1Id(long formGN1Id);
    }
}
