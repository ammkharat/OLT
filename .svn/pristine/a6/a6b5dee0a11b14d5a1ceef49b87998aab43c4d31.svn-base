using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IGenericTemplateApprovalDao : IDao
    {
        [CachedQueryBySiteId]
        List<GenericTemplateApproval> QueryBySite(long siteId, long plantId, long formTypeId);

        [CachedQueryBySiteId]
        List<GenericTemplateApproval> QueryForEGenericForms(long siteId, long plantId);

        [CachedQueryBySiteId]
        List<GenericTemplateEmailApprovalConfiguration> QueryFormGenericTemplateEmailEFormsBySite(long siteId);

        [CachedInsertOrUpdate(true, false)]
        GenericTemplateApproval Insert(GenericTemplateApproval approval);

        [CachedRemove(true, false)]
        void Remove(GenericTemplateApproval contractor);

        [CachedInsertOrUpdate(true, false)]
        void Update(GenericTemplateApproval approval);

        //DMND0009363-#950321920-Mukesh
        void UpdateTemplateHeader(GenericTemplateApproval contractor);

        //Added by ppanigrahi
        void UpdateTemplateHeaderEmail(GenericTemplateEmailApprovalConfiguration contractor);

        //Added by ppanigrahi
        [CachedQueryBySiteId]
        List<GenericTemplateEmailApprovalConfiguration> QueryByEmailSite(long siteId, long formTypeId);

        [CachedQueryBySiteId]
        string QueryEmailListApproverBySite(long siteId, long formTypeId, string name);

        [CachedInsertOrUpdate(true, false)]
        GenericTemplateEmailApprovalConfiguration InsertEmail(GenericTemplateEmailApprovalConfiguration approval);

        [CachedRemove(true, false)]
        void RemoveEmail(GenericTemplateEmailApprovalConfiguration contractor);

        [CachedInsertOrUpdate(true, false)]
        GenericTemplateEmailApprovalConfiguration UpdateEmail(GenericTemplateEmailApprovalConfiguration approval);



    }
}
