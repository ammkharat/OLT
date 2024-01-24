using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class LogTemplateService : ILogTemplateService
    {
        private readonly ILogTemplateDao logTemplateDao;
        private readonly ILogTemplateDTODao dtoDao;

        public LogTemplateService()
            : this(DaoRegistry.GetDao<ILogTemplateDao>(), DaoRegistry.GetDao<ILogTemplateDTODao>())
        {
        }

        public LogTemplateService(ILogTemplateDao logTemplateDao, ILogTemplateDTODao dtoDao)
        {
            this.logTemplateDao = logTemplateDao;
            this.dtoDao = dtoDao;
        }

        public LogTemplate Insert(LogTemplate logTemplate)
        {
            return logTemplateDao.Insert(logTemplate);
        }

        public List<LogTemplate> QueryBySite(Site site)
        {
            return logTemplateDao.QueryBySiteId(site.IdValue);
        }

        public void Update(LogTemplate logTemplate)
        {
            logTemplateDao.Update(logTemplate);
        }

        public void Delete(LogTemplate logTemplate)
        {
            logTemplateDao.Delete(logTemplate);
        }

        public List<LogTemplateDTO> QueryByWorkAssignmentReturnOnlyUniqueLogTemplates(WorkAssignment workAssignment, LogTemplate.LogType logType)
        {
            if (workAssignment == null)
            {
                return new List<LogTemplateDTO>(0);
            }

            return dtoDao.QueryByWorkAssignmentId(workAssignment.IdValue, logType);
        }

        public List<LogTemplate> QueryLogTemplatesSetAsAutoInsertForTheseAssignments(List<WorkAssignment> workAssignments)
        {
            if (workAssignments.IsEmpty())
            {
                return new List<LogTemplate>();
            }

            return logTemplateDao.QueryLogTemplatesSetAsAutoInsertForTheseAssignments(workAssignments);
        }

        public LogTemplate QueryById(long logTemplateId)
        {
            return logTemplateDao.QueryById(logTemplateId);
        }
    }
}
