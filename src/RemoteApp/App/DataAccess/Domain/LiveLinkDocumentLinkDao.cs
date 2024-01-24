using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class DocumentLinkDao : AbstractManagedDao, IDocumentLinkDao
    {
        private const string QUERY_BY_SUMMARY_LOG_ID_STORED_PROCEDURE = "QueryDocumentLinkBySummaryLogId";

        private const string QUERY_BY_ACTIONITEMDEFINITION_ID_STORED_PROCEDURE =
            "QueryDocumentLinkByActionItemDefinitionId";

        private const string QUERY_BY_ACTIONITEM_ID_STORED_PROCEDURE = "QueryDocumentLinkByActionItemId";
        private const string QUERY_BY_WORKPERMIT_ID_STORED_PROCEDURE = "QueryDocumentLinkByWorkPermitId";

        private const string QUERY_BY_WORKPERMIT_EDMONTON_ID_STORED_PROCEDURE =
            "QueryDocumentLinkByWorkPermitEdmontonId";

        private const string QUERY_BY_PERMITREQUEST_EDMONTON_ID_STORED_PROCEDURE =
            "QueryDocumentLinkByPermitRequestEdmontonId";

        private const string QUERY_BY_WORKPERMIT_MONTREAL_ID_STORED_PROCEDURE =
            "QueryDocumentLinkByWorkPermitMontrealId";

        private const string QUERY_BY_PERMITREQUEST_MONTREAL_ID_STORED_PROCEDURE =
            "QueryDocumentLinkByPermitRequestMontrealId";

        private const string QUERY_BY_WORKPERMIT_LUBES_ID_STORED_PROCEDURE = "QueryDocumentLinkByWorkPermitLubesId";

        private const string QUERY_BY_PERMITREQUEST_LUBES_ID_STORED_PROCEDURE =
            "QueryDocumentLinkByPermitRequestLubesId";

        //RITM0301321 mangesh
        private const string QUERY_BY_WORKPERMIT_MUDS_ID_STORED_PROCEDURE =
            "QueryDocumentLinkByWorkPermitMudsId";
        private const string QUERY_BY_PERMITREQUEST_MUDS_ID_STORED_PROCEDURE =
           "QueryDocumentLinkByPermitRequestMudsId";

        private const string QUERY_BY_FORM_GN24_ID_STORED_PROCEDURE = "QueryDocumentLinkByFormGN24Id";
        private const string QUERY_BY_FORM_GN6_ID_STORED_PROCEDURE = "QueryDocumentLinkByFormGN6Id";
        private const string QUERY_BY_FORM_GN75A_ID_STORED_PROCEDURE = "QueryDocumentLinkByFormGN75AId";
        private const string QUERY_BY_FORM_GN75B_ID_STORED_PROCEDURE = "QueryDocumentLinkByFormGN75BId";
        private const string QUERY_BY_FORM_GN75B_ID_STORED_PROCEDURESarnia = "QueryDocumentLinkByFormGN75BSarniaId";//INC0453097 Aarti
        private const string QUERY_BY_FORM_GN75B_ID_STORED_PROCEDURETemplateSarnia = "QueryDocumentLinkByFormGN75BTemplateId";//INC0458107  Aarti (OLT::EIP template Sarnia:: attachment crash)
        private const string QUERY_BY_FORM_GN1_ID_STORED_PROCEDURE = "QueryDocumentLinkByFormGN1Id";
        private const string QUERY_BY_FORM_GN7_ID_STORED_PROCEDURE = "QueryDocumentLinkByFormGN7Id";
        private const string QUERY_BY_FORM_OP14_ID_STORED_PROCEDURE = "QueryDocumentLinkByFormOP14Id";
        private const string QUERY_BY_FORM_PERMIT_ASSESSMENT_ID_STORED_PROCEDURE = "QueryDocumentLinkByFormPermitAssessmentId";
        private const string QUERY_BY_FORM_MONTREAL_CSD_ID_STORED_PROCEDURE = "QueryDocumentLinkByFormMontrealCsdId";
        private const string QUERY_BY_FORM_LUBESCSD_ID_STORED_PROCEDURE = "QueryDocumentLinkByFormLubesCsdId";
        private const string QUERY_BY_FORM_LUBES_ALARMDISABLE_ID_STORED_PROCEDURE = "QueryDocumentLinkByFormLubesAlarmDisableId";
        private const string QUERY_BY_FORM_GN59_ID_STORED_PROCEDURE = "QueryDocumentLinkByFormGN59Id";
        private const string QUERY_BY_OVERTIME_FORM_ID_STORED_PROCEDURE = "QueryDocumentLinkByOvertimeFormId";
        private const string QUERY_BY_LOG_ID_STORED_PROCEDURE = "QueryDocumentLinkByLogId";
        private const string QUERY_BY_LOGDEFINITION_ID_STORED_PROCEDURE = "QueryDocumentLinkByLogDefinitionId";
        private const string QUERY_BY_TARGETDEFINITION_ID_STORED_PROCEDURE = "QueryDocumentLinkByTargetDefinitionId";
        private const string QUERY_BY_TARGETALERT_ID_STORED_PROCEDURE = "QueryDocumentLinkByTargetAlertId";
        private const string QUERY_BY_DIRECTIVE_ID_STORED_PROCEDURE = "QueryDocumentLinkByDirectiveId";
        private const string QUERY_BY_FORM_DOCUMENT_SUGGESTION_ID_STORED_PROCEDURE = "QueryDocumentLinkByFormDocumentSuggestionId";
        private const string QUERY_BY_FORM_PROCEDURE_DEVIATION_ID_STORED_PROCEDURE = "QueryDocumentLinkByFormProcedureDeviationId";

        //generic template - mangesh
        private const string QUERY_BY_FORM_GenericTemplate_ID_STORED_PROCEDURE = "QueryDocumentLinkByFormGenericTemplateId";

        //RITM0268131 - mangesh
        private const string QUERY_BY_FORM_MUDS_TemporaryInstallation_ID_STORED_PROCEDURE = "QueryDocumentLinkByFormMudsTemporaryInstallationId";

        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryDocumentLinkById";
        private const string INSERT_STORED_PROCEDURE = "InsertDocumentLink";
        private const string REMOVE_STORED_PROCEDURE = "RemoveDocumentLink";

        private const string QUERY_BY_PERMITREQUEST_FORTHILLS_ID_STORED_PROCEDURE = "QueryDocumentLinkByPermitRequestFortHillsId";

        private readonly IFunctionalLocationDao flocDao;

        public DocumentLinkDao()
        {
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
        }

        public DocumentLink QueryById(long id)
        {
            return ManagedCommand.QueryById(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public void InsertForAssociatedFormGN59(DocumentLink documentLink, long formGN59Id)
        {
            const string parameterName = "@FormGN59Id";
            Insert(documentLink, parameterName, formGN59Id);
        }

        public void InsertForAssociatedFormGN7(DocumentLink documentLink, long formGN7Id)
        {
            const string parameterName = "@FormGN7Id";
            Insert(documentLink, parameterName, formGN7Id);
        }

        public void InsertForAssociatedFormOP14(DocumentLink documentLink, long formOP14Id)
        {
            const string parameterName = "@FormOP14Id";
            Insert(documentLink, parameterName, formOP14Id);
        }

        //generic template - mangesh
        public void InsertForAssociatedFormGenericTemplate(DocumentLink documentLink, long formGenericTemplateId)
        {
            const string parameterName = "@FormGenericTemplateId";
            Insert(documentLink, parameterName, formGenericTemplateId);
        }
        public List<DocumentLink> QueryByFormGenericTemplateId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGenericTemplateId", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_GenericTemplate_ID_STORED_PROCEDURE);
        }


        public void InsertForAssociatedFormMontrealCsd(DocumentLink documentLink, long formMontrealCsdId)
        {
            const string parameterName = "@FormMontrealCsdId";
            Insert(documentLink, parameterName, formMontrealCsdId);
        }

        //RITM0268131 - mangesh
        public void InsertForAssociatedFormMudsTemporaryInstallation(DocumentLink documentLink, long formMudsTemporaryInstallationId)
        {
            const string parameterName = "@FormMudsTemporaryInstallationId";
            Insert(documentLink, parameterName, formMudsTemporaryInstallationId);
        }

        public void InsertForAssociatedFormLubesCsd(DocumentLink documentLink, long formLubesCsdId)
        {
            const string parameterName = "@FormLubesCsdId";
            Insert(documentLink, parameterName, formLubesCsdId);
        }

        public void InsertForAssociatedFormLubesAlarmDisable(DocumentLink documentLink, long formLubesAlarmDisableId)
        {
            const string parameterName = "@FormLubesAlarmDisableId";
            Insert(documentLink, parameterName, formLubesAlarmDisableId);
        }

        public void InsertForAssociatedFormOilsandsPermitAssessment(DocumentLink documentLink, long formOilsandsPermitAssessmentId)
        {
            const string parameterName = "@FormOilsandsPermitAssessmentId";
            Insert(documentLink, parameterName, formOilsandsPermitAssessmentId);
        }

        public void InsertForAssociatedFormDocumentSuggestion(DocumentLink documentLink, long formDocumentSuggestionId)
        {
            const string parameterName = "@FormDocumentSuggestionId";
            Insert(documentLink, parameterName, formDocumentSuggestionId);
        }

        public void InsertForAssociatedFormProcedureDeviation(DocumentLink documentLink, long formProcedureDeviationId)
        {
            const string parameterName = "@FormProcedureDeviationId";
            Insert(documentLink, parameterName, formProcedureDeviationId);
        }

        public List<DocumentLink> QueryByFormGN7Id(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGN7Id", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_GN7_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByFormOP14Id(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormOP14Id", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_OP14_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByFormOilsandsPermitAssessmentId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@PermitAssessmentId", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_PERMIT_ASSESSMENT_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByFormDocumentSuggestionId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormDocumentSuggestionId", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_DOCUMENT_SUGGESTION_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByFormProcedureDeviationId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormProcedureDeviationId", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_PROCEDURE_DEVIATION_ID_STORED_PROCEDURE);
        }

        //RITM0268131 - mangesh
        public List<DocumentLink> QueryByFormMudsTemporaryInstallationId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormMudsTemporaryInstallationId", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_MUDS_TemporaryInstallation_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByFormMontrealCsdId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormMontrealCsdId", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_MONTREAL_CSD_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByFormLubesCsdId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormLubesCsdId", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_LUBESCSD_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByFormLubesAlarmDisableId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormLubesAlarmDisableId", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_LUBES_ALARMDISABLE_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByFormGN59Id(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGN59Id", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_GN59_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByActionItemDefinitionId(long actionItemDefinitionId)
        {
            var command = ManagedCommand;
            command.AddParameter("@ActionItemDefinitionId", actionItemDefinitionId);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_ACTIONITEMDEFINITION_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByActionItemId(long actionItemId)
        {
            var command = ManagedCommand;
            command.AddParameter("@ActionItemId", actionItemId);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_ACTIONITEM_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByWorkPermitId(long workPermitId)
        {
            var command = ManagedCommand;
            command.AddParameter("@WorkPermitID", workPermitId);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_WORKPERMIT_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByWorkPermitEdmontonId(long workPermitEdmontonId)
        {
            var command = ManagedCommand;
            command.AddParameter("@WorkPermitEdmontonId", workPermitEdmontonId);
            return command.QueryForListResult(PopulateInstance,
                QUERY_BY_WORKPERMIT_EDMONTON_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByPermitRequestEdmontonId(long permitRequestEdmontonId)
        {
            var command = ManagedCommand;
            command.AddParameter("@PermitRequestEdmontonId", permitRequestEdmontonId);
            return command.QueryForListResult(PopulateInstance,
                QUERY_BY_PERMITREQUEST_EDMONTON_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByWorkPermitMontrealId(long workPermitMontrealId)
        {
            var command = ManagedCommand;
            command.AddParameter("@WorkPermitMontrealId", workPermitMontrealId);
            return command.QueryForListResult(PopulateInstance,
                QUERY_BY_WORKPERMIT_MONTREAL_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByPermitRequestMontrealId(long permitRequestMontrealId)
        {
            var command = ManagedCommand;
            command.AddParameter("@PermitRequestMontrealId", permitRequestMontrealId);
            return command.QueryForListResult(PopulateInstance,
                QUERY_BY_PERMITREQUEST_MONTREAL_ID_STORED_PROCEDURE);
        }

        //RITM0301321 mangesh
        public List<DocumentLink> QueryByWorkPermitMudsId(long workPermitMudsId)
        {
            var command = ManagedCommand;
            command.AddParameter("@WorkPermitMudsId", workPermitMudsId);
            return command.QueryForListResult(PopulateInstance,
                QUERY_BY_WORKPERMIT_MUDS_ID_STORED_PROCEDURE);
        }
        public List<DocumentLink> QueryByPermitRequestMudsId(long permitRequestMudsId)
        {
            var command = ManagedCommand;
            command.AddParameter("@PermitRequestMudsId", permitRequestMudsId);
            return command.QueryForListResult(PopulateInstance,
                QUERY_BY_PERMITREQUEST_MUDS_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByWorkPermitLubesId(long workPermitLubesId)
        {
            var command = ManagedCommand;
            command.AddParameter("@WorkPermitLubesId", workPermitLubesId);
            return command.QueryForListResult(PopulateInstance,
                QUERY_BY_WORKPERMIT_LUBES_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByPermitRequestLubesId(long permitRequestLubesId)
        {
            var command = ManagedCommand;
            command.AddParameter("@PermitRequestLubesId", permitRequestLubesId);
            return command.QueryForListResult(PopulateInstance,
                QUERY_BY_PERMITREQUEST_LUBES_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByFormGN24Id(long formGN24Id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGN24Id", formGN24Id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_GN24_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByFormGN6Id(long formGN6Id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGN6Id", formGN6Id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_GN6_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByFormGN75AId(long formGN75AId)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGN75AId", formGN75AId);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_GN75A_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByFormGN75BId(long formGN75BId)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGN75BId", formGN75BId);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_GN75B_ID_STORED_PROCEDURE);
        }

        //INC0453097 Aarti
        public List<DocumentLink> QueryByFormGN75BIdSarnia(long formGN75BIdSarnia)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGN75BSarniaId", formGN75BIdSarnia);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_GN75B_ID_STORED_PROCEDURESarnia);
        }

        //INC0458107  Aarti (OLT::EIP template Sarnia:: attachment crash)
        public List<DocumentLink> QueryByFormGN75BIdTemplateSarnia(long formGN75BTemplateId)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGN75BTemplateId", formGN75BTemplateId);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_GN75B_ID_STORED_PROCEDURETemplateSarnia);
        }
        public List<DocumentLink> QueryByLogId(long logId)
        {
            var command = ManagedCommand;
            command.AddParameter("@LogId", logId);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_LOG_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryBySummaryLogId(long summaryLogId)
        {
            var command = ManagedCommand;
            command.AddParameter("@SummaryLogId", summaryLogId);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_SUMMARY_LOG_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByLogDefinitionId(long logDefinitionId)
        {
            var command = ManagedCommand;
            command.AddParameter("@LogDefinitionId", logDefinitionId);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_LOGDEFINITION_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByTargetDefinitionId(long targetDefinitionId)
        {
            var command = ManagedCommand;
            command.AddParameter("@TargetDefinitionId", targetDefinitionId);
            return command.QueryForListResult(PopulateInstance,
                QUERY_BY_TARGETDEFINITION_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByTargetAlertId(long targetAlertId)
        {
            var command = ManagedCommand;
            command.AddParameter("@TargetAlertId", targetAlertId);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_TARGETALERT_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByDirectiveId(long directiveId)
        {
            var command = ManagedCommand;
            command.AddParameter("@DirectiveId", directiveId);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_DIRECTIVE_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByFormGN1Id(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGN1Id", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_GN1_ID_STORED_PROCEDURE);
        }

        public List<DocumentLink> QueryByOvertimeFormId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@OvertimeFormId", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_OVERTIME_FORM_ID_STORED_PROCEDURE);
        }

        public void RemoveDeletedDocumentLinks(IDocumentLinksObject documentLinksObject,
            QueryDocumentLinksByDomainObjectId queryDocumentLinksByDomainObjectId)
        {
            var retrievedLinks = queryDocumentLinksByDomainObjectId(documentLinksObject.IdValue);

            // NOTE: If you call 'Remove' directly on this same DAO below, it will not work because
            //       'QueryDocumentLinksByDomainObjectId' closes the connection on the current thread.
            //       So, we get the DAO again to obtain a new connection.
            var documentLinkDaoWithNewSqlConnection = DaoRegistry.GetDao<IDocumentLinkDao>();

            foreach (var retrievedLink in retrievedLinks)
            {
                if (!documentLinksObject.DocumentLinks.Exists(link => link.Id == retrievedLink.Id))
                {
                    documentLinkDaoWithNewSqlConnection.Remove(retrievedLink);
                }
            }
        }

        public void Remove(DocumentLink documentLink)
        {
            ManagedCommand.ExecuteNonQuery(documentLink, REMOVE_STORED_PROCEDURE, AddRemoveParameters);
        }

        public void InsertForAssociatedActionItemDefinition(DocumentLink documentLink,
            long associatedActionItemDefinitionId)
        {
            const string parameterName = "@ActionItemDefinitionID";
            Insert(documentLink, parameterName, associatedActionItemDefinitionId);
        }

        public void InsertForAssociatedActionItem(DocumentLink documentLink, long associatedActionItemId)
        {
            const string parameterName = "@ActionItemId";
            Insert(documentLink, parameterName, associatedActionItemId);
        }

        public void InsertForAssociatedWorkPermit(DocumentLink documentLink, long associatedWorkPermitId)
        {
            const string parameterName = "@WorkPermitID";
            Insert(documentLink, parameterName, associatedWorkPermitId);
        }

        public void InsertForAssociatedSummaryLog(DocumentLink documentLink, long summaryLogId)
        {
            const string paramaterName = "@SummaryLogID";
            Insert(documentLink, paramaterName, summaryLogId);
        }

        public void InsertForAssociatedLog(DocumentLink documentLink, long associatedLogId)
        {
            const string parameterName = "@LogID";
            Insert(documentLink, parameterName, associatedLogId);
        }

        public void InsertForAssociatedLogDefinition(DocumentLink documentLink, long associatedLogDefinitionId)
        {
            const string parameterName = "@LogDefinitionID";
            Insert(documentLink, parameterName, associatedLogDefinitionId);
        }

        public void InsertForAssociatedTargetDefinition(DocumentLink documentLink, long associatedTargetDefinitionId)
        {
            const string parameterName = "@TargetDefinitionID";
            Insert(documentLink, parameterName, associatedTargetDefinitionId);
        }

        public void InsertForAssociatedTargetAlert(DocumentLink documentLink, long associatedTargetAlertId)
        {
            const string parameterName = "@TargetAlertID";
            Insert(documentLink, parameterName, associatedTargetAlertId);
        }

        public void InsertForAssociatedWorkPermitEdmonton(DocumentLink documentLink, long associatedWorkPermitEdmontonId)
        {
            const string parameterName = "@WorkPermitEdmontonId";
            Insert(documentLink, parameterName, associatedWorkPermitEdmontonId);
        }

        public void InsertForAssociatedPermitRequestEdmonton(DocumentLink documentLink,
            long associatedPermitRequestEdmontonId)
        {
            const string parameterName = "@PermitRequestEdmontonId";
            Insert(documentLink, parameterName, associatedPermitRequestEdmontonId);
        }

        //RITM0301321 mangesh
        public void InsertForAssociatedWorkPermitMuds(DocumentLink documentLink, long associatedWorkPermitMudsId)
        {
            const string parameterName = "@FormWorkPermitMudsId";
            Insert(documentLink, parameterName, associatedWorkPermitMudsId);
        }
        public void InsertForAssociatedPermitRequestMuds(DocumentLink documentLink,
           long associatedPermitRequestMudsId)
        {
            const string parameterName = "@PermitRequestMudsId";
            Insert(documentLink, parameterName, associatedPermitRequestMudsId);
        }

        public void InsertForAssociatedWorkPermitMontreal(DocumentLink documentLink, long associatedWorkPermitMontrealId)
        {
            const string parameterName = "@WorkPermitMontrealId";
            Insert(documentLink, parameterName, associatedWorkPermitMontrealId);
        }

        public void InsertForAssociatedPermitRequestMontreal(DocumentLink documentLink,
            long associatedPermitRequestMontrealId)
        {
            const string parameterName = "@PermitRequestMontrealId";
            Insert(documentLink, parameterName, associatedPermitRequestMontrealId);
        }

        public void InsertForAssociatedWorkPermitLubes(DocumentLink documentLink, long associatedWorkPermitLubesId)
        {
            const string parameterName = "@WorkPermitLubesId";
            Insert(documentLink, parameterName, associatedWorkPermitLubesId);
        }

        public void InsertForAssociatedPermitRequestLubes(DocumentLink documentlink, long permitRequestLubesId)
        {
            const string parameterName = "@PermitRequestLubesId";
            Insert(documentlink, parameterName, permitRequestLubesId);
        }

        public void InsertForAssociatedFormGN24(DocumentLink documentlink, long formGN24Id)
        {
            const string parameterName = "@FormGN24Id";
            Insert(documentlink, parameterName, formGN24Id);
        }

        public void InsertForAssociatedFormGN6(DocumentLink documentlink, long formGN6Id)
        {
            const string parameterName = "@FormGN6Id";
            Insert(documentlink, parameterName, formGN6Id);
        }

        public void InsertForAssociatedFormGN75A(DocumentLink documentlink, long formGN75AId)
        {
            const string parameterName = "@FormGN75AId";
            Insert(documentlink, parameterName, formGN75AId);
        }

        public void InsertForAssociatedFormGN75B(DocumentLink documentlink, long formGN75BId)
        {
            const string parameterName = "@FormGN75BId";
            Insert(documentlink, parameterName, formGN75BId);
        }
        //INC0453097 Aarti
        public void InsertForAssociatedFormGN75BSarnia(DocumentLink documentlink, long formGN75BSarniaId)
        {
            const string parameterName = "@FormGN75BSarniaId";
            Insert(documentlink, parameterName, formGN75BSarniaId);

        }

        //INC0458107  Aarti (OLT::EIP template Sarnia:: attachment crash)
        public void InsertForAssociatedFormGN75BTemplateSarnia(DocumentLink documentlink, long formGN75BTemplateId)
        {
            const string parameterName = "@FormGN75BTemplateId";
            Insert(documentlink, parameterName, formGN75BTemplateId);

        }
        public void InsertForAssociatedDirective(DocumentLink documentLink, long directiveId)
        {
            const string parameterName = "@DirectiveId";
            Insert(documentLink, parameterName, directiveId);
        }

        public void InsertForAssociatedFormGN1(DocumentLink documentLink, long formGN1Id)
        {
            const string parameterName = "@FormGN1Id";
            Insert(documentLink, parameterName, formGN1Id);
        }

        public void InsertForAssociatedOvertimeForm(DocumentLink documentlink, long overtimeFormId)
        {
            const string parameterName = "OvertimeFormId";
            Insert(documentlink, parameterName, overtimeFormId);
        }
        
        public void InsertNewDocumentLinks(IDocumentLinksObject documentLinksObject,
            InsertDocumentLinkForAssociatedDomainObjectId insertDocumentLinkForAssociatedDomainObjectId)
        {
            if(documentLinksObject.DocumentLinks != null)                        //ayman custom fields DMND0010030
                foreach (var documentLink in documentLinksObject.DocumentLinks)
            {
                //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
                //if (!documentLink.IsInDatabase())
                //{
                //    insertDocumentLinkForAssociatedDomainObjectId(documentLink, documentLinksObject.IdValue);
                //}
                insertDocumentLinkForAssociatedDomainObjectId(documentLink, documentLinksObject.IdValue);
                //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            }

        }


        public List<DocumentRootUncPath> QueryRootsBySiteId(long siteId)
        {
            var command = ManagedCommand;
            command.AddParameter("SiteId", siteId);
            return command.QueryForListResult(PopulateDocumentRoots, "QueryDocumentRootsBySite");
        }

        public List<DocumentRootUncPath> QueryRootsByFunctionalLocation(SectionOnlyFlocSet flocSet)
        {
            var command = ManagedCommand;
            command.AddParameter("CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            return command.QueryForListResult(PopulateDocumentRoots,
                "QueryDocumentRootsBySecondLevelFlocIds");
        }

        public void InsertRootPath(DocumentRootUncPath editObject)
        {
            var command = ManagedCommand;
            command.AddParameter("PathName", editObject.PathName);
            command.AddParameter("UncPath", editObject.Path);

            var id = command.InsertAndReturnId("InsertDocumentRootPathConfiguration");
            editObject.Id = id;

            AssociateFunctionalLocationsToDocumentRoots(command, editObject);
        }

        public void UpdateRootPath(DocumentRootUncPath editObject)
        {
            var command = ManagedCommand;
            command.AddParameter("PathName", editObject.PathName);
            command.AddParameter("UncPath", editObject.Path);
            command.AddParameter("Id", editObject.IdValue);
            command.Update("UpdateDocumentRootPathConfiguration");

            command.Parameters.Clear();
            command.AddParameter("DocumentRootPathId", editObject.IdValue);
            command.ExecuteNonQuery("RemoveAllDocumentRootFunctionalLocationAssociations");

            AssociateFunctionalLocationsToDocumentRoots(command, editObject);
        }

        public void RemoveRootPath(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("Id", id);
            command.ExecuteNonQuery("RemoveDocumentRootPathConfiguration");
        }

        private static DocumentLink PopulateInstance(SqlDataReader reader)
        {
            var link = reader.Get<string>("Link");
            var title = reader.Get<string>("Title");

            var result = new DocumentLink(link, title) {Id = (reader.Get<long>("Id"))};

            return result;
        }

        private static void AddRemoveParameters(DocumentLink documentLink, SqlCommand command)
        {
            command.AddParameter("@Id", documentLink.Id);
        }

        private static void AddInsertParameters(DocumentLink documentLink, SqlCommand command)
        {
            SetCommonAttributes(documentLink, command);
        }

        private static void SetCommonAttributes(DocumentLink documentLink, SqlCommand command)
        {
            command.AddParameter("@Link", documentLink.Url);
            command.AddParameter("@Title", documentLink.Title);
        }

        private void Insert(DocumentLink documentLink, string parameterName, long associatedId)
        {
            var command = ManagedCommand;
            var idParameter = command.AddIdOutputParameter();
            command.Parameters.AddWithValue(parameterName, associatedId);
            command.Insert(documentLink, AddInsertParameters, INSERT_STORED_PROCEDURE);
            documentLink.Id = idParameter.GetValue<long>();
        }

        private static void AssociateFunctionalLocationsToDocumentRoots(SqlCommand command,
            DocumentRootUncPath editObject)
        {
            foreach (var floc in editObject.FirstLevelFunctionalLocations)
            {
                command.Parameters.Clear();
                command.AddParameter("DocumentRootPathId", editObject.IdValue);
                command.AddParameter("FunctionalLocationId", floc.Id);
                command.ExecuteNonQuery("InsertDocumentRootFunctionaLocationAssociation");
            }
        }

        private DocumentRootUncPath PopulateDocumentRoots(SqlDataReader reader)
        {
            var id = reader.Get<long?>("Id");
            var pathName = reader.Get<String>("PathName");
            var firstLevelFlocs = flocDao.QueryByDocumentRootPathId(id.Value);
            var documentRootUncPath = reader.Get<String>("UncPath");

            return new DocumentRootUncPath(pathName, documentRootUncPath, firstLevelFlocs) {Id = id};
        }

        public List<DocumentLink> QueryByPermitRequestFortHillsId(long permitRequestFortHillsId)
        {
            var command = ManagedCommand;
            command.AddParameter("@PermitRequestFortHillsId", permitRequestFortHillsId);
            return command.QueryForListResult(PopulateInstance,
                QUERY_BY_PERMITREQUEST_FORTHILLS_ID_STORED_PROCEDURE);
        }

        public void InsertForAssociatedWorkPermitFortHills(DocumentLink documentLink, long associatedWorkPermitFortHillsId)
        {
            const string parameterName = "@WorkPermitFortHillsId";
            Insert(documentLink, parameterName, associatedWorkPermitFortHillsId);
        }

        public void InsertForAssociatedPermitRequestFortHills(DocumentLink documentLink,
            long associatedPermitRequestFortHillsId)
        {
            const string parameterName = "@PermitRequestFortHillsId";
            Insert(documentLink, parameterName, associatedPermitRequestFortHillsId);
        }
    }
}