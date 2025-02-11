using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IFormGenericTemplateService
    { 
     
        [OperationContract]
        List<FormGenericTemplateDTO> QueryFormGenericTemplateDTOs(IFlocSet flocSet, DateRange dateRange, List<FormStatus> formStasuses,
            bool includeAllDraftFormsRegardlessOfDateRange);
        
        [OperationContract]
        List<FormGenericTemplateDTO> QueryAllRequiringApprovalByFunctionalLocationsAndDateRange(IFlocSet flocSet,
            DateRange dateRange, bool authorizedToViewOvertimeForms);

        [OperationContract]
        List<FormTemplate> QueryFormTemplatesByFormType(EdmontonFormType formType,long siteid);  

        [OperationContract]
        FormTemplate QueryFormTemplateByFormTypeAndKey(EdmontonFormType formType, string key);

        [OperationContract]
        List<FormTemplate> QueryFormTemplates(long siteId);

        [OperationContract]
        void ReplaceFormTemplate(FormTemplate formTemplate, User user, DateTime now, long siteId);


        //generic forms
        [OperationContract]
        FormGenericTemplate QueryFormGenericTemplateByIdAndSiteId(long id, long siteid, long formtypeid, long plantid);
        
        [OperationContract]
        List<FormApproval> QueryFormGenericTemplateEFormApproverByIdAndSiteId(long siteid, long formtypeid, long plantid);


        //ayman Sarnia eip DMND0008992
        [OperationContract]
        List<FormApproval> QueryByFormSarniaEipIssueApproverByIdAndSiteId(long siteid, long formtypeid, long plantid);

        [OperationContract]
        FormGenericTemplate QueryFormGenericTemplateById(long id);
        
        [OperationContract]
        List<NotifiedEvent> Insert(FormGenericTemplate form);

        [OperationContract]
        List<NotifiedEvent> Update(FormGenericTemplate form);

        [OperationContract]
        List<NotifiedEvent> Remove(FormGenericTemplate form);

        [OperationContract]
        List<FormGenericTemplate> QueryAllFormGenericTemplatesThatAreApprovedAndAreMoreThan10DaysOutOfService(DateTime now);

        //generic forms
        [OperationContract]
        DocumentSuggestion QueryDocumentSuggestionFormByIdAndSiteId(long id,long siteid);
        
        [OperationContract]
        DocumentSuggestion QueryDocumentSuggestionFormById(long id);

        [OperationContract]
        List<DocumentSuggestionDTO> QueryDocumentSuggestionDtos(RootFlocSet flocSet, DateRange dateRange, long userId);

        [OperationContract]
        List<DocumentSuggestionDTO> QueryDocumentSuggestionsByFunctionalLocations(RootFlocSet flocSet, DateTime now, long userId);

        [OperationContract]
        List<NotifiedEvent> InsertDocumentSuggestionForm(DocumentSuggestion form);

        [OperationContract]
        List<NotifiedEvent> UpdateDocumentSuggestionForm(DocumentSuggestion form);

        [OperationContract]
        List<NotifiedEvent> DeleteDocumentSuggestionForm(DocumentSuggestion form);
        //Added by ppanigrahi
        [OperationContract]
        List<FormApproval> QueryByFormSarniaCsdApproverByIdAndSiteId(long siteid, long formtypeid, long plantid);

        [OperationContract]
        int Updatemailsentflag(long? Id, bool isMailSent);

        [OperationContract]
       List<FormApproval> QueryByFormOP14Id(long Id);

    }
}