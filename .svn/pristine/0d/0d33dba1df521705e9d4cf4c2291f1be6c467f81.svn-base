using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class WorkPermitMudsTemplateService : IWorkPermitMudsTemplateService
    {
        private readonly IWorkPermitMudsTemplateDao workPermitMudsTemplateDao;

        public WorkPermitMudsTemplateService(): this(DaoRegistry.GetDao<IWorkPermitMudsTemplateDao>())
        {
        }

        public WorkPermitMudsTemplateService(IWorkPermitMudsTemplateDao workPermitMudsTemplateDao)
        {
            this.workPermitMudsTemplateDao = workPermitMudsTemplateDao;
        }

        public WorkPermitMudsTemplate Insert(WorkPermitMudsTemplate workPermitMudsTemplate)
        {
            return workPermitMudsTemplateDao.Insert(workPermitMudsTemplate);
        }

        public List<WorkPermitMudsTemplate> QueryAllNotDeleted()
        {
            return workPermitMudsTemplateDao.QueryAllNotDeleted();
        }

        public WorkPermitMudsTemplate QueryByIdToMapPermit(long templateId, long permitId)
        {
            return workPermitMudsTemplateDao.QueryByIdToMapPermit(templateId, permitId);
        }

        public List<WorkPermitMudsTemplate> QueryAll()
        {
            return workPermitMudsTemplateDao.QueryAll();
        }

        public void Update(WorkPermitMudsTemplate workPermitMudsTemplate)
        {
            workPermitMudsTemplateDao.Update(workPermitMudsTemplate);
        }

        public void Delete(WorkPermitMudsTemplate workPermitMudsTemplate)
        {
            workPermitMudsTemplateDao.Delete(workPermitMudsTemplate);
        }
    }
}
