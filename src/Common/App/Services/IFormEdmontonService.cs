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
    public interface IFormEdmontonService
    {
        //ayman generic forms
        [OperationContract]
        FormGN7 QueryFormGN7ByIdAndSiteId(long id, long siteid);

        //ayman Sarnia eip DMND0008992
        [OperationContract]
        FormGN75B QueryFormGN75BSarniaByIdAndSiteId(long id, long siteid);

        [OperationContract]
        FormGN7 QueryFormGN7ById(long id);

        [OperationContract]
        List<FormEdmontonDTO> QueryFormGN7DTOs(IFlocSet flocSet, DateRange dateRange, List<FormStatus> formStasuses,
            bool includeAllDraftFormsRegardlessOfDateRange);

        [OperationContract]
        List<FormEdmontonDTO> QueryFormGN59DTOs(IFlocSet flocSet, DateRange dateRange, List<FormStatus> formStasuses,
            bool includeAllDraftFormsRegardlessOfDateRange);

        [OperationContract]
        List<FormEdmontonOP14DTO> QueryFormOP14DTOs(IFlocSet flocSet, DateRange dateRange, List<FormStatus> formStasuses,
            bool includeAllDraftFormsRegardlessOfDateRange);

        //generic template - mangesh
        [OperationContract]
        List<FormGenericTemplateDTO> QueryFormGenericTemplateDTOs(IFlocSet flocSet, DateRange dateRange, List<FormStatus> formStasuses,
            bool includeAllDraftFormsRegardlessOfDateRange, long formtypeid, long plantid);

        //DMND0011225 CSD for WBR
        [OperationContract]
        List<GenericCsdDTO> QueryGenericCsdDTOs(IFlocSet flocSet, DateRange dateRange, List<FormStatus> formStasuses,
            bool includeAllDraftFormsRegardlessOfDateRange);

        [OperationContract]
        List<MontrealCsdDTO> QueryMontrealCsdDTOs(IFlocSet flocSet, DateRange dateRange, List<FormStatus> formStasuses,
            bool includeAllDraftFormsRegardlessOfDateRange);

        //RITM0268131 - mangesh        
        [OperationContract]
        List<TemporaryInstallationsMudsDTO> QueryMudsTemporaryInstallationsDTOs(IFlocSet flocSet, DateRange dateRange, List<FormStatus> formStasuses,
                    bool includeAllDraftFormsRegardlessOfDateRange);
        [OperationContract]
        List<TemporaryInstallationsMudsDTO> QueryMudsTemporaryInstallationsThatAreApprovedByFunctionalLocations(IFlocSet flocSet, DateTime now);

        [OperationContract]
        List<FormEdmontonDTO> QueryAllRequiringApprovalByFunctionalLocationsAndDateRange(IFlocSet flocSet,
            DateRange dateRange, bool authorizedToViewOvertimeForms);

        [OperationContract]
        List<FormEdmontonOP14DTO> QueryFormOP14sThatAreApprovedByFunctionalLocations(IFlocSet flocSet, DateTime now);

        //DMND0011225 OLT - CSD for WBR
        [OperationContract]
        List<GenericCsdDTO> QueryGenericCsdsThatAreApprovedByFunctionalLocations(IFlocSet flocSet, DateTime now);

        [OperationContract]
        List<MontrealCsdDTO> QueryMontrealCsdsThatAreApprovedByFunctionalLocations(IFlocSet flocSet, DateTime now);

        [OperationContract]
        List<NotifiedEvent> InsertGN7(FormGN7 form);

        [OperationContract]
        List<NotifiedEvent> UpdateGN7(FormGN7 form, LabelAttributes attributesForHazardsLabel);

        [OperationContract]
        List<NotifiedEvent> RemoveGN7(FormGN7 form);


        [OperationContract]
        List<FormTemplate> QueryFormTemplatesByFormType(EdmontonFormType formType, long siteid);   //ayman generic forms

        [OperationContract]
        FormTemplate QueryFormTemplateByFormTypeAndKey(EdmontonFormType formType, string key);

        [OperationContract]
        List<FormTemplate> QueryFormTemplates(long siteId);

        [OperationContract]
        void ReplaceFormTemplate(FormTemplate formTemplate, User user, DateTime now, long siteId);

        //ayman generic forms
        [OperationContract]
        FormGN59 QueryFormGN59ByIdAndSiteId(long id, long siteid);

        [OperationContract]
        FormGN59 QueryFormGN59ById(long id);

        [OperationContract]
        List<NotifiedEvent> InsertGN59(FormGN59 form);

        [OperationContract]
        List<NotifiedEvent> UpdateGN59(FormGN59 form, LabelAttributes attributesForHazardsLabel);

        [OperationContract]
        List<NotifiedEvent> RemoveGN59(FormGN59 form);

        //ayman generic forms
        [OperationContract]
        FormOP14 QueryFormOP14ByIdAndSiteId(long id, long siteid);

        [OperationContract]
        FormOP14 QueryFormOP14ById(long id);

        //generic template - mangesh
        [OperationContract]
        FormGenericTemplate QueryFormGenericTemplateByIdAndSiteId(long id, long siteid, long formtypeid, long plantid);

        [OperationContract]
        FormGenericTemplate QueryFormGenericTemplateById(long id);
        //---
        //ayman generic forms
        //[OperationContract]
        //MontrealCsd QueryMontrealCsdByIdAndSiteId(long id,long siteid);

        //DMND0011225 CSD for WBR
        [OperationContract]
        GenericCsd QueryGenericCsdById(long id);

        [OperationContract]
        MontrealCsd QueryMontrealCsdById(long id);

        [OperationContract]
        List<NotifiedEvent> InsertOP14(FormOP14 form);

        //generic template - mangesh
        [OperationContract]
        List<NotifiedEvent> InsertGenericTemplate(FormGenericTemplate form);

        [OperationContract]
        List<NotifiedEvent> InsertMontrealCsd(MontrealCsd form);

        [OperationContract]
        List<NotifiedEvent> UpdateOP14(FormOP14 form);

        //generic template - mangesh
        [OperationContract]
        List<NotifiedEvent> UpdateGenericTemplate(FormGenericTemplate form);

        //DMND0011225 CSD for WBR
        [OperationContract]
        List<NotifiedEvent> UpdateGenericCsd(GenericCsd form);

        [OperationContract]
        List<NotifiedEvent> UpdateMontrealCsd(MontrealCsd form);

        [OperationContract]
        List<NotifiedEvent> RemoveOP14(FormOP14 form);

        //generic template - mangesh
        [OperationContract]
        List<NotifiedEvent> RemoveGenericTemplate(FormGenericTemplate form);

        //DMND0011225 CSD for WBR
        [OperationContract]
        List<NotifiedEvent> RemoveGenericCsd(GenericCsd form);

        [OperationContract]
        List<NotifiedEvent> RemoveMontrealCsd(MontrealCsd form);

        //ayman generic forms
        [OperationContract]
        FormGN24 QueryFormGN24ByIdAndSiteId(long id, long siteid);

        [OperationContract]
        FormGN24 QueryFormGN24ById(long id);

        [OperationContract]
        List<NotifiedEvent> InsertGN24(FormGN24 form);

        [OperationContract]
        List<NotifiedEvent> UpdateGN24(FormGN24 form, LabelAttributes attributesForHazardsLabel);

        [OperationContract]
        List<NotifiedEvent> RemoveGN24(FormGN24 form, User user);

        [OperationContract]
        List<FormOP14> QueryAllFormOP14sThatAreApprovedAndAreMoreThan10DaysOutOfService(DateTime now);






        [OperationContract]
        List<FormEdmontonGN24DTO> QueryFormGN24DTOsByCriteria(IFlocSet flocSet, DateRange dateRange,
            List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange);

        [OperationContract]
        List<NotifiedEvent> InsertGN6(FormGN6 form);

        [OperationContract]
        List<NotifiedEvent> UpdateGN6(FormGN6 form, LabelAttributes attributesForHazardsLabel);

        [OperationContract]
        List<NotifiedEvent> RemoveGN6(FormGN6 form, User user);

        //ayman generic forms
        [OperationContract]
        FormGN6 QueryFormGN6ByIdAndSiteId(long id, long siteid);

        [OperationContract]
        FormGN6 QueryFormGN6ById(long id);

        [OperationContract]
        List<FormEdmontonGN6DTO> QueryFormGN6DTOsByCriteria(IFlocSet flocSet, DateRange dateRange,
            List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange);

        [OperationContract]
        List<NotifiedEvent> InsertGN75A(FormGN75A form);

        [OperationContract]
        List<NotifiedEvent> UpdateGN75A(FormGN75A form, LabelAttributes attributesForHazardsLabel);

        [OperationContract]
        List<NotifiedEvent> RemoveGN75A(FormGN75A form, User user);

        //ayman generic forms
        [OperationContract]
        FormGN75A QueryFormGN75AByIdAndSiteId(long id, long siteid);

        [OperationContract]
        FormGN75A QueryFormGN75AById(long id);

        [OperationContract]
        List<FormEdmontonGN75ADTO> QueryFormGN75ADTOsByCriteria(IFlocSet flocSet, DateRange dateRange,
            List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange);

        [OperationContract]
        List<NotifiedEvent> InsertGN75B(FormGN75B formGn75B, bool addDocumentLinkAssociation);

        //ayman Sarnia eip - 3
        [OperationContract]
        List<NotifiedEvent> InsertGN75BSarnia(FormGN75B formGn75B, bool addDocumentLinkAssociation);

        //ayman Sarnia eip DMND0008992
        [OperationContract]
        List<NotifiedEvent> InsertGN75BTemplate(FormGN75B formGn75B, bool addDocumentLinkAssociation);

        //INC0458107  Aarti (OLT::EIP template Sarnia:: attachment crash)
        [OperationContract]
        List<NotifiedEvent> InsertGN75BTemplateSarnia(FormGN75B formGn75B, bool addDocumentLinkAssociation);

        [OperationContract]
        List<NotifiedEvent> UpdateGN75B(FormGN75B formGn75B, bool addDocumentLinkAssociation);

        //ayman Sarnia eip DMND0008992
        [OperationContract]
        List<NotifiedEvent> UpdateSarniaGN75B(FormGN75B formGn75B, bool addDocumentLinkAssociation, string formType);

        [OperationContract]
        List<NotifiedEvent> RemoveGN75B(FormGN75B form, User user);

        // ayman generic forms
        [OperationContract]
        FormGN75B QueryFormGN75BByIdAndSiteId(long id, long siteid);

        //ayman Sarnia eip DMND0008992
        [OperationContract]
        FormGN75B QueryFormGN75BTemplateByIdAndSiteId(long id, long siteid);

        //ayman Sarnia eip DMND0008992
        [OperationContract]
        List<FormEdmontonGN75BDTO> QueryApprovedTemplateToShowEipFormsQueryApprovedTemplateToShowEipForms(long id, long siteid);

        [OperationContract]
        FormGN75B QueryFormGN75BById(long id);

        [OperationContract]
        FormGN75B QueryFormGN75BSarniaById(long id);              //ayman Sarnia - eip 3

        [OperationContract]
        List<FormEdmontonGN75BDTO> QueryFormGN75BDTOsByCriteria(IFlocSet flocSet, List<FormStatus> formStatuses, long siteId);    //ayman Sarnia eip DMND0008992

        [OperationContract]
        List<FormEdmontonGN75BDTO> QueryFormGN75BSarniaFormDTOsByCriteria(IFlocSet flocSet, List<FormStatus> formStatuses, long siteId);    //ayman Sarnia eip DMND0008992

        //ayman Sarnia eip DMND0008992
        [OperationContract]
        List<FormEdmontonGN75BDTO> QueryFormGN75BTemplateDTOsByCriteria(IFlocSet flocSet, List<FormStatus> formStatuses);

        [OperationContract]
        FormEdmontonGN75BDTO QueryFormGN75BDTOById(long id);

        [OperationContract]
        List<long> QueryAllGN75AFormsAssociatedToFormGN75B(long gn75BFormId);

        [OperationContract]
        bool GN75AIsAssociatedToAnIssuedWorkPermit(List<long> idsForSelectedItems);

        [OperationContract]
        bool GN75BIsAssociatedToAGN75AOrActionItem(List<long> idsForSelectedItems);

        [OperationContract]
        List<NotifiedEvent> InsertGN1(FormGN1 formGN1);

        [OperationContract]
        List<NotifiedEvent> UpdateGN1(FormGN1 formGN1, LabelAttributes labelAttributes);

        [OperationContract]
        List<NotifiedEvent> RemoveGN1(FormGN1 form, User user);

        //ayman generic forms
        [OperationContract]
        FormGN1 QueryFormGN1ByIdAndSiteId(long id, long siteid);


        [OperationContract]
        FormGN1 QueryFormGN1ById(long id);

        [OperationContract]
        int GetNextTradeChecklistSequenceNumber(long formGN1Id);

        [OperationContract]
        List<FormEdmontonGN1DTO> QueryFormGN1DTOsByCriteria(IFlocSet flocSet, DateRange dateRange,
            List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange);

        [OperationContract]
        List<TradeChecklistInfo> QueryFormGN1TradeChecklistDisplayItemsByFormGN1Id(long formGn1Id);

        [OperationContract]
        void InsertGN75BUserReadDocumentLinkAssociation(long formGN75BId, long userId);

        //INC0453097 Aarti
        [OperationContract]
        void InsertGN75BUserReadDocumentLinkAssociationSarnia(long formGN75BSarniaId, long userId);

        //INC0458107  Aarti (OLT::EIP template Sarnia:: attachment crash)
        [OperationContract]
        void InsertGN75BUserReadDocumentLinkAssociationTemplateSarnia(long formGN75BSarniaId, long userId);

        [OperationContract]
        bool HasUserReadAtLeastOneDocumentLinkOnFormGN75B(long userId, long formGN75BId);

        [OperationContract]
        bool HasUserReadAtLeastOneDocumentLinkOnEveryFormGN75BInList(long userId, List<long> formGN75BIdValues);
       
        //INC0453097 Aarti
        [OperationContract]
        bool HasUserReadAtLeastOneDocumentLinkOnFormGN75BSarnia(long userId, long formGN75BSarniaId);
      
        //INC0453097 Aarti
        [OperationContract]
        bool HasUserReadAtLeastOneDocumentLinkOnEveryFormGN75BInListSarnia(long userId, List<long> formGN75BSarniaIdValues);

        //INC0458107  Aarti (OLT::EIP template Sarnia:: attachment crash)
        [OperationContract]
        bool HasUserReadAtLeastOneDocumentLinkOnFormGN75BTemplateSarnia(long userId, long formGN75BTemplateId);

        [OperationContract]
        OvertimeForm QueryOvertimeFormById(long id);

        [OperationContract]
        List<NotifiedEvent> InsertOvertimeForm(OvertimeForm overtimeForm);

        [OperationContract]
        IList<EdmontonOvertimeFormDTO> QueryOvertimeFormsByCriteria(DateRange dateRange);

        [OperationContract]
        List<NotifiedEvent> UpdateOvertimeForm(OvertimeForm overtimeForm);

        [OperationContract]
        IList<OnPremisePersonnelSupervisorDTO> QueryOnPremisePersonnelSupervisorView(Range<DateTime> range, Site site);

        [OperationContract]
        IList<OnPremisePersonnelAuditDTO> QueryOnPremisePersonnelAuditView(Range<Date> range);

        [OperationContract]
        IList<OnPremisePersonnelShiftReportDTO> QueryOnPremisePersonnelShiftReport(Range<DateTime> reportingPeriod);

        [OperationContract]
        List<NotifiedEvent> InsertLubesCsd(LubesCsdForm lubesCsdForm);

        [OperationContract]
        List<NotifiedEvent> UpdateLubesCsd(LubesCsdForm lubesCsdForm);

        //ayman generic forms
        [OperationContract]
        LubesCsdForm QueryLubesCsdFormByIdAndSiteId(long id, long siteid);

        [OperationContract]
        LubesCsdForm QueryLubesCsdFormById(long id);

        [OperationContract]
        List<NotifiedEvent> RemoveLubesCsdForm(LubesCsdForm lubesCsdForm);

        [OperationContract]
        IList<LubesCsdFormDTO> QueryLubesCsdFormDTOs(RootFlocSet flocSet, DateRange dateRange,
            List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange);

        [OperationContract]
        List<LubesCsdFormDTO> QueryFormLubesCsdsThatAreApprovedByFunctionalLocations(IFlocSet flocSet, DateTime now);

        [OperationContract]
        List<LubesCsdForm> QueryAllLubeCsdsThatAreApprovedAndAreMoreThan7DaysOutOfService(DateTime now);

        [OperationContract]
        List<LubesCsdFormDTO> QueryFormLubesCsdsThatAreExpiredOrApprovedAndActiveByFunctionalLocations(IFlocSet flocSet,
            DateTime now);

        //DMND0011225 CSD for WBR
        [OperationContract]
        List<GenericCsdDTO> QueryAllGenericCsdsRequiringApprovalByFunctionalLocationsAndDateRange(IFlocSet flocSet,
            DateRange dateRange);

        [OperationContract]
        List<MontrealCsdDTO> QueryAllMontrealCsdsRequiringApprovalByFunctionalLocationsAndDateRange(IFlocSet flocSet,
            DateRange dateRange);

        [OperationContract]
        List<FormEdmontonDTO> QueryAllLubesFormsRequiringApprovalByFunctionalLocationsAndDateRange(IFlocSet flocSet,
            DateRange dateRange);

        [OperationContract]
        List<MontrealCsd> QueryAllMontrealCsdsThatAreApprovedAndAreMoreThan3DaysOutOfService(DateTime currentTimeAtSite);

        [OperationContract]
        List<MontrealCsd> QueryAllMontrealCsdsThatAreApprovedAndAreMoreThan5DaysOutOfService(DateTime currentTimeAtSite);

        [OperationContract]
        List<NotifiedEvent> InsertLubesAlarmDisable(LubesAlarmDisableForm lubesAlarmDisableForm);

        [OperationContract]
        List<NotifiedEvent> UpdateLubesAlarmDisable(LubesAlarmDisableForm lubesAlarmDisableForm);


        [OperationContract]
        List<NotifiedEvent> RemoveLubesAlarmDisable(LubesAlarmDisableForm lubesAlarmDisableForm);

        //ayman generic forms
        [OperationContract]
        LubesAlarmDisableForm QueryLubesAlarmDisableFormByIdAndSiteId(long id, long siteid);

        [OperationContract]
        LubesAlarmDisableForm QueryLubesAlarmDisableFormById(long id);

        //ayman generic forms
        [OperationContract]
        PermitAssessment QueryPermitAssessmentFormByIdAndSiteId(long id, long siteid);

        [OperationContract]
        PermitAssessment QueryPermitAssessmentFormById(long id);

        [OperationContract]
        IList<LubesAlarmDisableFormDTO> QueryLubesAlarmDisableFormDTOs(RootFlocSet flocSet, DateRange dateRange,
            List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange);

        [OperationContract]
        List<PermitAssessmentDTO> QueryOilsandsPermitAssessmentDtos(RootFlocSet flocSet, DateRange dateRange);

        [OperationContract]
        string GetFormGN6WorkerResponsibilitiesText();

        [OperationContract]
        List<NotifiedEvent> InsertOilsandsPermitAssessmentForm(PermitAssessment form);

        [OperationContract]
        List<NotifiedEvent> UpdateOilsandsPermitAssessmentForm(PermitAssessment form);

        //ayman generic forms
        [OperationContract]
        DocumentSuggestion QueryDocumentSuggestionFormByIdAndSiteId(long id, long siteid);

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

        //ayman generic forms
        [OperationContract]
        ProcedureDeviation QueryProcedureDeviationFormByIdAndSiteId(long id, long siteid);

        [OperationContract]
        ProcedureDeviation QueryProcedureDeviationFormById(long id);

        [OperationContract]
        List<ProcedureDeviationDTO> QueryProcedureDeviationDtos(RootFlocSet flocSet, DateRange dateRange, long userId);

        [OperationContract]
        List<ProcedureDeviationDTO> QueryProcedureDeviationsByFunctionalLocations(RootFlocSet flocSet, DateTime now, long userId);

        [OperationContract]
        List<NotifiedEvent> InsertProcedureDeviationForm(ProcedureDeviation form);

        [OperationContract]
        List<NotifiedEvent> UpdateProcedureDeviationForm(ProcedureDeviation form);

        [OperationContract]
        List<NotifiedEvent> DeleteProcedureDeviationForm(ProcedureDeviation form);

        //RITM0268131 - mangesh
        [OperationContract]
        TemporaryInstallationsMUDS QueryMudsTemporaryInstallationsById(long id);

        [OperationContract]
        List<NotifiedEvent> InsertMudsTemporaryInstallations(TemporaryInstallationsMUDS form);

        [OperationContract]
        List<NotifiedEvent> UpdateMudsTemporaryInstallations(TemporaryInstallationsMUDS form);

        [OperationContract]
        List<NotifiedEvent> RemoveMudsTemporaryInstallations(TemporaryInstallationsMUDS form);
       
        /*RITM0265746 - Sarnia CSD marked as read start*/
        [OperationContract]
        void InsertFormOp14MarkAsRead(long id, long userId, DateTime now, long shiftId);

        [OperationContract]
        List<ItemReadBy> UserMarkedFormOp14AsRead(long formOp14Id, long? userId, long shiftId);

        [OperationContract]
        List<ItemReadBy> UserMarkedFormOp14AsReadOnPriorityPage(long formOp14Id, long? userId, long shiftId, Date date);  //Added By Vibhor : RITM0613645 : OLT - Mark as read tick mark for sarnia CSD

        //[OperationContract]
        //List<CSDMarkAsReadReportItem> MarkedAsReadFormOp14Report(Date startDate, Date endDate);

        /*RITM0265746 - Sarnia CSD marked as read start*/
        //Addded by ppanigrahi
        [OperationContract]
        List<NotifiedEvent> UpdateOP14Email(long Id, long sitId, int uid, int statusid);
        //Added by ppanigrahi
        [OperationContract]
        long QueryUserId(string username);

        [OperationContract]
        long QueryByFormOp14ApprovalId(long? Id, string approver);
    }
}