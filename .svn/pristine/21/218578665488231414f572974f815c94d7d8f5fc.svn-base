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
    public class WorkPermitMontrealTemplateService : IWorkPermitMontrealTemplateService
    {
        private readonly IWorkPermitMontrealTemplateDao workPermitMontrealTemplateDao;

        public WorkPermitMontrealTemplateService(): this(DaoRegistry.GetDao<IWorkPermitMontrealTemplateDao>())
        {
        }

        public WorkPermitMontrealTemplateService(IWorkPermitMontrealTemplateDao workPermitMontrealTemplateDao)
        {
            this.workPermitMontrealTemplateDao = workPermitMontrealTemplateDao;
        }

        public WorkPermitMontrealTemplate Insert(WorkPermitMontrealTemplate workPermitMontrealTemplate)
        {
            return workPermitMontrealTemplateDao.Insert(workPermitMontrealTemplate);
        }

        public List<WorkPermitMontrealTemplate> QueryAllNotDeleted()
        {
            return workPermitMontrealTemplateDao.QueryAllNotDeleted();
        }

        public List<WorkPermitMontrealTemplate> QueryAll()
        {
            return workPermitMontrealTemplateDao.QueryAll();
        }

        public void Update(WorkPermitMontrealTemplate workPermitMontrealTemplate)
        {
            workPermitMontrealTemplateDao.Update(workPermitMontrealTemplate);
        }

        public void Delete(WorkPermitMontrealTemplate workPermitMontrealTemplate)
        {
            workPermitMontrealTemplateDao.Delete(workPermitMontrealTemplate);
        }
    }
}
