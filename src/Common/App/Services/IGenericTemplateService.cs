using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IGenericTemplateService
    {
        [OperationContract]
        List<GenericTemplateApproval> QueryBySite(Site site, long plantId, long formTypeId);

        [OperationContract]
        List<GenericTemplateApproval> QueryForEGenericForms(Site site, long plantId);

        [OperationContract]
        void UpdateContractors(Site site, IList<GenericTemplateApproval> contractors, long plantId, long formTypeId);

        //INC0251500 - mangesh
        [OperationContract]
        void DeleteFormApprover(GenericTemplateApproval contractor);

         //DMND0009363-#950321920-Mukesh
         [OperationContract]
        void UpdateTemplateHeader(GenericTemplateApproval contractor);
         //Added by ppanigrahi

         [OperationContract]
         List<GenericTemplateEmailApprovalConfiguration> QueryFormGenericTemplateEmailEFormsBySite(Site site);

         [OperationContract]
         List<GenericTemplateEmailApprovalConfiguration> QueryByEmailSite(Site site, long formTypeId);


         [OperationContract]
         void UpdateContractorsEmail(Site site, IList<GenericTemplateEmailApprovalConfiguration> contractors, long plantId, long formTypeId);

         [OperationContract]
         void DeleteFormApproverEmail(GenericTemplateEmailApprovalConfiguration contractor);

         [OperationContract]
         void UpdateTemplateHeaderEmail(GenericTemplateEmailApprovalConfiguration contractor);

         [OperationContract]
         string QueryEmailListApproverBySite(Site site, long formTypeId, string name);

         [OperationContract]
         void UpdateEmailApprover(GenericTemplateEmailApprovalConfiguration selectedContractor);

    }
}