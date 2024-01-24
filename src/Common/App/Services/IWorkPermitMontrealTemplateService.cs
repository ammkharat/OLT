using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IWorkPermitMontrealTemplateService
    {
        [OperationContract]
        WorkPermitMontrealTemplate Insert(WorkPermitMontrealTemplate montrealWorkPermitTemplate);

        [OperationContract]
        List<WorkPermitMontrealTemplate> QueryAllNotDeleted();

        [OperationContract]
        List<WorkPermitMontrealTemplate> QueryAll();

        [OperationContract]
        void Update(WorkPermitMontrealTemplate workPermitMontrealTemplate);

        [OperationContract]
        void Delete(WorkPermitMontrealTemplate workPermitMontrealTemplate);
    }
}