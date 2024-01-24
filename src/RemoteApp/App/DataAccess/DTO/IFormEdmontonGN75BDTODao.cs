using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface  IFormEdmontonGN75BDTODao : IDao
    {
        List<FormEdmontonGN75BDTO> QueryDTOs(IFlocSet flocSet, List<FormStatus> formStatuses,long siteId);   //ayman Sarnia eip DMND0008992

        List<FormEdmontonGN75BDTO> QuerySarniaFormDTOs(IFlocSet flocSet, List<FormStatus> formStatuses, long siteId);   //ayman Sarnia eip DMND0008992
        List<FormEdmontonGN75BDTOforPriorityScreen> QuerySarniaFormDTOsForPriorityScreen(IFlocSet flocSet, List<FormStatus> formStatuses, long siteId);   //ayman Sarnia eip DMND0008992
        List<FormEdmontonGN75BDTO> QueryTemplateDTOs(IFlocSet flocSet, List<FormStatus> formStatuses);      //ayman Sarnia eip DMND0008992
        FormEdmontonGN75BDTO QueryById(long idValue);
        List<FormEdmontonGN75BDTO> QueryApprovedTemplateDTOs(long id, long siteid);            //ayman Sarnia eip DMND0008992
    }
}