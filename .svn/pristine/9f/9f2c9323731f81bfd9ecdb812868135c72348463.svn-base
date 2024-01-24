using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public delegate List<DocumentLink> QueryDocumentLinksByDomainObjectId(long id);

    public delegate void InsertDocumentLinkForAssociatedDomainObjectId(DocumentLink documentLink, long id);

    public interface IDocumentLinkDao : IDao
    {
        /// <summary>
        /// Return the document link associated with the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DocumentLink QueryById(long id);


        /// <summary>
        /// return All document links by the given Action Iem ID
        /// </summary>
        /// <returns></returns>
        List<DocumentLink> QueryByActionItemId(long actionItemId);

        /// <summary>
        /// return All document links by the given Action Iem Definition ID
        /// </summary>
        /// <param name="actionItemDefinitionId"></param>
        /// <returns></returns>
        List<DocumentLink> QueryByActionItemDefinitionId(long actionItemDefinitionId);

        /// <summary>
        /// return All document links by the given work permit ID
        /// </summary>
        /// <param name="workPermitId"></param>
        /// <returns></returns>
        List<DocumentLink> QueryByWorkPermitId(long workPermitId);

        /// <summary>
        /// return All document links by the given log ID
        /// </summary>
        /// <param name="logId"></param>
        /// <returns></returns>
        List<DocumentLink> QueryByLogId(long logId);

        /// <summary>
        /// return All document links by the given log definition ID
        /// </summary>
        /// <param name="logDefinitionId"></param>
        /// <returns></returns>
        List<DocumentLink> QueryByLogDefinitionId(long logDefinitionId);

        /// <summary>
        /// return All document links by the given target definition ID
        /// </summary>
        /// <param name="targetDefinitionId"></param>
        /// <returns></returns>
        List<DocumentLink> QueryByTargetDefinitionId(long targetDefinitionId);

        /// <summary>
        /// return All document links by the given target alert ID
        /// </summary>
        /// <param name="targetAlertId"></param>
        /// <returns></returns>
        List<DocumentLink> QueryByTargetAlertId(long targetAlertId);

        /// <summary>
        /// Insert a document link with an associated action item definition id
        /// </summary>
        /// <param name="documentLink"></param>
        /// <param name="associatedActionItemDefinitionId"></param>
        void InsertForAssociatedActionItemDefinition(DocumentLink documentLink, long associatedActionItemDefinitionId);

        /// <summary>
        /// Insert a document link with an associated action item id
        /// </summary>
        /// <param name="documentLink"></param>
        /// <param name="associatedActionItemId"></param>
        void InsertForAssociatedActionItem(DocumentLink documentLink, long associatedActionItemId);

        /// <summary>
        /// Insert a document link with an associated work permit id
        /// </summary>
        /// <param name="documentLink"></param>
        /// <param name="associatedWorkPermitId"></param>
        void InsertForAssociatedWorkPermit(DocumentLink documentLink, long associatedWorkPermitId);

        /// <summary>
        /// Insert a document link with an associated log id
        /// </summary>
        /// <param name="documentLink"></param>
        /// <param name="associatedLogId"></param>
        void InsertForAssociatedLog(DocumentLink documentLink, long associatedLogId);

        /// <summary>
        /// Insert a document link with an associated log definition id
        /// </summary>
        /// <param name="documentLink"></param>
        /// <param name="associatedLogDefinitionId"></param>
        void InsertForAssociatedLogDefinition(DocumentLink documentLink, long associatedLogDefinitionId);

        /// <summary>
        /// Insert a document link with an associated target definition id
        /// </summary>
        /// <param name="documentLink"></param>
        /// <param name="associatedTargetDefinitionId"></param>
        void InsertForAssociatedTargetDefinition(DocumentLink documentLink, long associatedTargetDefinitionId);

        /// <summary>
        /// Insert a document link with an associated target alert id
        /// </summary>
        /// <param name="documentLink"></param>
        /// <param name="associatedTargetAlertId"></param>
        void InsertForAssociatedTargetAlert(DocumentLink documentLink, long associatedTargetAlertId);

        void InsertNewDocumentLinks(IDocumentLinksObject documentLinksObject,
            InsertDocumentLinkForAssociatedDomainObjectId insertDocumentLinkForAssociatedDomainObjectId);

        /// <summary>
        /// Remove the document link
        /// </summary>
        /// <param name="documentLink"></param>
        void Remove(DocumentLink documentLink);

        void RemoveDeletedDocumentLinks(IDocumentLinksObject documentLinksObject,
            QueryDocumentLinksByDomainObjectId queryDocumentLinksByDomainObjectId);

        void InsertForAssociatedSummaryLog(DocumentLink documentLink, long summaryLogId);
        List<DocumentLink> QueryBySummaryLogId(long summaryLogId);

        List<DocumentRootUncPath> QueryRootsBySiteId(long siteId);
        List<DocumentRootUncPath> QueryRootsByFunctionalLocation(SectionOnlyFlocSet flocSet);

        void InsertRootPath(DocumentRootUncPath editObject);
        void UpdateRootPath(DocumentRootUncPath editObject);
        void RemoveRootPath(long id);

        List<DocumentLink> QueryByWorkPermitEdmontonId(long workPermitEdmontonId);
        List<DocumentLink> QueryByPermitRequestEdmontonId(long permitRequestEdmontonId);
        void InsertForAssociatedWorkPermitEdmonton(DocumentLink documentLink, long associatedWorkPermitEdmontonId);
        void InsertForAssociatedPermitRequestEdmonton(DocumentLink documentLink, long associatedPermitRequestEdmontonId);

        List<DocumentLink> QueryByWorkPermitMontrealId(long workPermitMontrealId);
        List<DocumentLink> QueryByPermitRequestMontrealId(long permitRequestMontrealId);
        void InsertForAssociatedWorkPermitMontreal(DocumentLink documentLink, long associatedWorkPermitMontrealId);
        void InsertForAssociatedPermitRequestMontreal(DocumentLink documentLink, long associatedPermitRequestMontrealId);
        
        //DMND0009632 - Fort Hills OLT - E-Permit Development
        List<DocumentLink> QueryByPermitRequestFortHillsId(long permitRequestFortHillsId);
        void InsertForAssociatedPermitRequestFortHills(DocumentLink documentLink, long associatedPermitRequestFortHillsId);


        List<DocumentLink> QueryByWorkPermitLubesId(long workPermitLubesId);
        void InsertForAssociatedWorkPermitLubes(DocumentLink documentlink, long workPermitLubesId);

        List<DocumentLink> QueryByPermitRequestLubesId(long permitRequestLubesId);
        void InsertForAssociatedPermitRequestLubes(DocumentLink documentlink, long permitRequestLubesId);

        List<DocumentLink> QueryByFormGN24Id(long formGN24Id);
        void InsertForAssociatedFormGN24(DocumentLink documentlink, long formGN24Id);

        List<DocumentLink> QueryByFormGN6Id(long formGN6Id);
        void InsertForAssociatedFormGN6(DocumentLink documentlink, long formGN6Id);

        List<DocumentLink> QueryByFormGN75AId(long id);
        void InsertForAssociatedFormGN75A(DocumentLink documentlink, long formGN75AId);

        List<DocumentLink> QueryByFormGN75BId(long id);
        void InsertForAssociatedFormGN75B(DocumentLink documentlink, long formGN75BId);

        //INC0453097 Aarti
        List<DocumentLink> QueryByFormGN75BIdSarnia(long id);
        void InsertForAssociatedFormGN75BSarnia(DocumentLink documentlink, long formGN75BIdSarnia);

        //INC0458107  Aarti (OLT::EIP template Sarnia:: attachment crash)
        List<DocumentLink> QueryByFormGN75BIdTemplateSarnia(long id);
        void InsertForAssociatedFormGN75BTemplateSarnia(DocumentLink documentlink, long formGN75BTemplateId);

        List<DocumentLink> QueryByDirectiveId(long id);
        void InsertForAssociatedDirective(DocumentLink documentLink, long documentLinkId);

        List<DocumentLink> QueryByFormGN1Id(long id);
        void InsertForAssociatedFormGN1(DocumentLink documentlink, long formGN1Id);

        List<DocumentLink> QueryByOvertimeFormId(long id);
        void InsertForAssociatedOvertimeForm(DocumentLink documentlink, long overtimeFormId);
        
        List<DocumentLink> QueryByFormGN59Id(long id);
        void InsertForAssociatedFormGN59(DocumentLink documentlink, long formGN59Id);

        List<DocumentLink> QueryByFormGN7Id(long id);
        void InsertForAssociatedFormGN7(DocumentLink documentlink, long formGN7Id);

        List<DocumentLink> QueryByFormOP14Id(long id);
        void InsertForAssociatedFormOP14(DocumentLink documentlink, long formOP14Id);

        List<DocumentLink> QueryByFormMontrealCsdId(long id);
        void InsertForAssociatedFormMontrealCsd(DocumentLink documentlink, long formMontrealCsdId);

        List<DocumentLink> QueryByFormLubesCsdId(long id);
        void InsertForAssociatedFormLubesCsd(DocumentLink documentlink, long formLubesCsdId);

        List<DocumentLink> QueryByFormLubesAlarmDisableId(long id);
        void InsertForAssociatedFormLubesAlarmDisable(DocumentLink documentlink, long formLubesAlarmDisableId);

        List<DocumentLink> QueryByFormOilsandsPermitAssessmentId(long id);
        void InsertForAssociatedFormOilsandsPermitAssessment(DocumentLink documentLink,
            long formOilsandsPermitAssessmentId);

        List<DocumentLink> QueryByFormDocumentSuggestionId(long id);
        void InsertForAssociatedFormDocumentSuggestion(DocumentLink documentlink, long formDocumentSuggestionId);

        List<DocumentLink> QueryByFormProcedureDeviationId(long id);
        void InsertForAssociatedFormProcedureDeviation(DocumentLink documentlink, long formProcedureDeviationId);

        //generic template - mangesh
        List<DocumentLink> QueryByFormGenericTemplateId(long id);
        void InsertForAssociatedFormGenericTemplate(DocumentLink documentLink, long formGenericTemplateId);

        //RITM0268131 - mangesh
        List<DocumentLink> QueryByFormMudsTemporaryInstallationId(long id);
        void InsertForAssociatedFormMudsTemporaryInstallation(DocumentLink documentlink, long formMontrealCsdId);

        //RITM0301321 mangesh
        List<DocumentLink> QueryByWorkPermitMudsId(long workPermitMudsId);
        void InsertForAssociatedWorkPermitMuds(DocumentLink documentLink, long associatedWorkPermitMudsId);
        List<DocumentLink> QueryByPermitRequestMudsId(long permitRequestMudsId);
        void InsertForAssociatedPermitRequestMuds(DocumentLink documentLink, long associatedPermitRequestMudsId);
    }
}