using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IWorkPermitMudsTemplateService
    {
        [OperationContract]
        WorkPermitMudsTemplate Insert(WorkPermitMudsTemplate mudsWorkPermitTemplate);

        [OperationContract]
        List<WorkPermitMudsTemplate> QueryAllNotDeleted();

        [OperationContract]
        List<WorkPermitMudsTemplate> QueryAll();

        [OperationContract]
        void Update(WorkPermitMudsTemplate workPermitMudsTemplate);

        [OperationContract]
        void Delete(WorkPermitMudsTemplate workPermitMudsTemplate);

        [OperationContract]
        WorkPermitMudsTemplate QueryByIdToMapPermit(long templateId, long permitId);
    }
}