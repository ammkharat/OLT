using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ILogTemplateWorkAssignmentDao : IDao
    {
        LogTemplateWorkAssignment Insert(LogTemplateWorkAssignment logTemplateWorkAssignment);
        List<LogTemplateWorkAssignment> QueryByLogTemplateId(long logTemplateId);
        void DeleteByLogTemplateId(long? logTemplateId);
    }
}
