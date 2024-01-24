using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IFormGenericTemplateDao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        FormGenericTemplate Insert(FormGenericTemplate form);

       

        [CachedQueryById]
        FormGenericTemplate QueryById(long id);

        
        [CachedQueryByIdAndSiteId]
        FormGenericTemplate QueryByIdAndSiteId(long id, long siteid, long formtypeid, long plantid);

        [CachedQueryByIdAndSiteId]
        List<FormApproval> QueryFormGenericTemplateEFormApproverByIdAndSiteId(long siteid, long formtypeid, long plantid);

        //ayman Sarnia eip DMND0008992
        [CachedQueryByIdAndSiteId]
        List<FormApproval> QueryFormSarniaEipIssueApproverByIdAndSiteId(long siteid, long formtypeid, long plantid);

        [CachedInsertOrUpdate(false, false)]
        void Update(FormGenericTemplate form);
        [CachedRemove(false, false)]
        void Remove(FormGenericTemplate form);
        List<FormGenericTemplate> QueryAllThatAreApprovedAndAreMoreThan10DaysOutOfService(DateTime now);

        List<FormGenericTemplateDTO> QueryFormGenericTemplate(IFlocSet flocSet, DateRange dateRange, List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange, long formtypeid, long plantid);

        //Added by ppanigrahi
        [CachedQueryByIdAndSiteId]
        List<FormApproval> QueryFormSarniaCsdApproverByIdAndSiteId(long siteid, long formtypeid, long plantid);

        [CachedQueryByIdAndSiteId]
         int Updatemailsentflag(long? Id, bool isMailSent);

         [CachedQueryByIdAndSiteId]
        List<FormApproval> QueryByFormOP14Id(long Id);


    }
}
