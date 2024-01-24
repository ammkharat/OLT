using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FunctionalLocationDao : AbstractManagedDao, IFunctionalLocationDao
    {
        private const string QUERY_DIV_SEC_UNIT_BY_SITE_ID = "QueryFunctionalLocationsUnitLevelAndHigherBySiteId";

        private const string QUERY_BY_ACTIONITEMDEFINITION_ID_STORED_PROCEDURE =
            "QueryFunctionalLocationsByActionItemDefinitionId";

        private const string QUERY_BY_ACTION_ITEM_ID_STORED_PROCEDURE = "QueryFunctionalLocationsByActionItemId";
        private const string QUERY_BY_LOG_ID_STORED_PROCEDURE = "QueryFunctionalLocationsByLogId";
        private const string QUERY_BY_LOG_DEFINITION_ID_STORED_PROCEDURE = "QueryFunctionalLocationsByLogDefinitionId";

        private const string QUERY_BY_SHIFT_HANDOVER_QUESTIONNAIRE_ID_STORED_PROCEDURE =
            "QueryFunctionalLocationsByShiftHandoverQuestionnaireId";

        private const string QUERY_BY_SUMMARY_LOG_ID_STORED_PROCEDURE = "QueryFunctionalLocationsBySummaryLogId";

        private const string QUERY_BY_WORK_PERMIT_MONTREAL_ID_STORED_PROCEDURE =
            "QueryFunctionalLocationsByWorkPermitMontrealId";

        private const string QUERY_BY_PERMIT_REQUEST_MONTREAL_ID_STORED_PROCEDURE =
            "QueryFunctionalLocationsByPermitRequestMontrealId";

        private const string QUERY_BY_FORM_GN7_ID_STORED_PROCEDURE = "QueryFunctionalLocationsByFormGN7Id";
        private const string QUERY_BY_FORM_GN59_ID_STORED_PROCEDURE = "QueryFunctionalLocationsByFormGN59Id";
        private const string QUERY_BY_FORM_OP14_ID_STORED_PROCEDURE = "QueryFunctionalLocationsByFormOP14Id";

        private const string QUERY_BY_FORM_MONTREAL_CSD_ID_STORED_PROCEDURE =
            "QueryFunctionalLocationsByFormMontrealCsdId";

        private const string QUERY_BY_FORM_GN24_ID_STORED_PROCEDURE = "QueryFunctionalLocationsByFormGN24Id";
        private const string QUERY_BY_FORM_GN6_ID_STORED_PROCEDURE = "QueryFunctionalLocationsByFormGN6Id";

        private const string QUERY_BY_FORM_OILSANDS_PERMIT_ASSESSMENT_ID_STORED_PROCEDURE =
            "QueryFunctionalLocationsByFormPermitAssessmentId";

        private const string QUERY_BY_FORM_OILSANDS_TRAINING_ID_STORED_PROCEDURE =
            "QueryFunctionalLocationsByFormOilsandsTrainingId";

        private const string QUERY_BY_TRAINING_BLOCK_ID_STORED_PROCEDURE = "QueryFunctionalLocationsByTrainingBlockId";
        private const string QUERY_BY_DIRECTIVE_ID_STORED_PROCEDURE = "QueryFunctionalLocationsByDirectiveId";

        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryFunctionalLocationById";

        private const string QUERY_BY_FULLHIERARCHY_SITEID_STORED_PROCEDURE =
            "QueryFunctionalLocationByFullHierarchyAndSiteID";

        private const string QUERY_BY_FULLHIERARCHY_SITEID_INCLUDE_DELETED_STORED_PROCEDURE =
            "QueryFunctionalLocationByFullHierarchyAndSiteIDIncludeDeleted";

        private const string INSERT_STORED_PROCEDURE = "InsertFunctionalLocation";
        private const string REMOVE_STORED_PROCEDURE = "RemoveFunctionalLocationAndDescendants";

        private const string UPDATE_BYID_STORED_PROCEDURE = "UpdateFunctionalLocation";

        private const string QUERY_CHILD_SECTION_FLOC_BY_PARENT_DIVISION_FLOC =
            "QueryChildSectionFunctionLocationByParentDivisionFunctionalLocation";

        public const string QUERY_BY_WORK_ASSIGNMENT_ID = "QueryFunctionalLocationsByWorkAssignmentId";

        public const string QUERY_BY_WORK_ASSIGNMENT_ID_FOR_PERMIT_AUTO_ASSIGN =
            "QueryFunctionalLocationByWorkAssignmentIdForWorkPermitAutoAssignment";

        public const string QUERY_BY_WORK_ASSIGNMENT_ID_FOR_RESTRICTION_FLOCS =
            "QueryFunctionalLocationByWorkAssignmentIdForRestrictionFlocs";

        public const string QUERY_BY_WORK_ASSIGNMENT_ID_FOR_PERMITS =
            "QueryFunctionalLocationsByWorkAssignmentIdForWorkPermits";

        public const string UNDO_REMOVE_STORED_PROCEDURE = "UndoRemoveFunctionalLocation";

        public const string QUERY_BY_FULLHIERARCHY_SITEID_INCLUDE_DELETED_TO_TEST_EXISTENCE_STORED_PROCEDURE =
            "QueryFunctionalLocationByFullHierarchyIncludeDeletedToTestExistence";

        public const string QUERY_BY_FORM_DOCUMENT_SUGGESTION_ID_STORED_PROCEDURE = "QueryFunctionalLocationsByFormDocumentSuggestionId";

        public const string QUERY_BY_FORM_PROCEDURE_DEVIATION_ID_STORED_PROCEDURE = "QueryFunctionalLocationsByFormProcedureDeviationId";

        private const string QUERY_BY_FORM_GenericTemplate_ID_STORED_PROCEDURE = "QueryFunctionalLocationsByFormGenericTemplateId";

        //RITM0268131 - mangesh
        private const string QUERY_BY_FORM_MUDS_TemporaryInstallation_ID_STORED_PROCEDURE = "QueryFunctionalLocationsByFormMudsTemporaryInstallationId";

        //RITM0301321 mangesh
        private const string QUERY_BY_WORK_PERMIT_MUDS_ID_STORED_PROCEDURE = "QueryFunctionalLocationsByWorkPermitMudsId"; 

        private const string QUERY_BY_PERMIT_REQUEST_MUDS_ID_STORED_PROCEDURE = "QueryFunctionalLocationsByPermitRequestMudsId";

        private static ISiteDao siteDao;

        public FunctionalLocationDao()
        {
            siteDao = DaoRegistry.GetDao<ISiteDao>();
        }

        public FunctionalLocation QueryByFullHierarchy(string fullHierarchy, long siteId)
        {
            var command = ManagedCommand;
            command.AddParameter("@FullHierarchy", fullHierarchy);
            command.AddParameter("@SiteID", siteId);
            return command.QueryForSingleResult(PopulateInstance, QUERY_BY_FULLHIERARCHY_SITEID_STORED_PROCEDURE);
        }

        public FunctionalLocation QueryByFullHierarchyIncludeDeleted(string fullHierarchy, long siteId)
        {
            var command = ManagedCommand;
            command.AddParameter("@FullHierarchy", fullHierarchy);
            command.AddParameter("@SiteID", siteId);
            return command.QueryForSingleResult(PopulateInstance,
                QUERY_BY_FULLHIERARCHY_SITEID_INCLUDE_DELETED_STORED_PROCEDURE);
        }

        public List<FunctionalLocation> QueryDivSecUnitBySiteId(long siteId)
        {
            var command = ManagedCommand;
            command.AddParameter("@SiteID", siteId);
            return command.QueryForListResult(PopulateInstance, QUERY_DIV_SEC_UNIT_BY_SITE_ID);
        }

        public List<FunctionalLocation> QueryByActionItemDefinitionId(long actionItemDefinitionId)
        {
            var command = ManagedCommand;
            command.AddParameter("@ActionItemDefinitionId", actionItemDefinitionId);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_ACTIONITEMDEFINITION_ID_STORED_PROCEDURE);
        }

        public List<FunctionalLocation> QueryByActionItemId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@ActionItemId", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_ACTION_ITEM_ID_STORED_PROCEDURE);
        }

        public List<FunctionalLocation> QueryByLogId(long logId)
        {
            var command = ManagedCommand;
            command.AddParameter("@LogId", logId);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_LOG_ID_STORED_PROCEDURE);
        }

        public List<FunctionalLocation> QueryByLogDefinitionId(long logDefinitionId)
        {
            var command = ManagedCommand;
            command.AddParameter("@LogDefinitionId", logDefinitionId);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_LOG_DEFINITION_ID_STORED_PROCEDURE);
        }

        public List<FunctionalLocation> QueryByShiftHandoverQuestionnaireId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@ShiftHandoverQuestionnaireId", id);
            return command.QueryForListResult(PopulateInstance,
                QUERY_BY_SHIFT_HANDOVER_QUESTIONNAIRE_ID_STORED_PROCEDURE);
        }

        public List<FunctionalLocation> QueryBySummaryLogId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@SummaryLogId", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_SUMMARY_LOG_ID_STORED_PROCEDURE);
        }

        public List<FunctionalLocation> QueryByWorkPermitMontrealId(long workPermitId)
        {
            var command = ManagedCommand;
            command.AddParameter("@WorkPermitMontrealId", workPermitId);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_WORK_PERMIT_MONTREAL_ID_STORED_PROCEDURE);
        }

        //RITM0301321 mangesh
        public List<FunctionalLocation> QueryByWorkPermitMudsId(long workPermitId)
        {
            var command = ManagedCommand;
            command.AddParameter("@WorkPermitMudsId", workPermitId);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_WORK_PERMIT_MUDS_ID_STORED_PROCEDURE);
        }
        public List<FunctionalLocation> QueryByPermitRequestMudsId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@PermitRequestMudsId", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_PERMIT_REQUEST_MUDS_ID_STORED_PROCEDURE);
        }

        public List<FunctionalLocation> QueryByPermitRequestMontrealId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@PermitRequestMontrealId", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_PERMIT_REQUEST_MONTREAL_ID_STORED_PROCEDURE);
        }

        public List<FunctionalLocation> QueryByFormGN7Id(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGN7Id", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_GN7_ID_STORED_PROCEDURE);
        }

        public List<FunctionalLocation> QueryByFormGN59Id(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGN59Id", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_GN59_ID_STORED_PROCEDURE);
        }

        public List<FunctionalLocation> QueryByFormOP14Id(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormOP14Id", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_OP14_ID_STORED_PROCEDURE);
        }

        //generic template - mangesh
        public List<FunctionalLocation> QueryByFormGenericTemplateId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGenericTemplateId", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_GenericTemplate_ID_STORED_PROCEDURE);
        }

        public List<FunctionalLocation> QueryByFormOilsandsPermitAssessmentId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@PermitAssessmentId", id);
            return command.QueryForListResult(PopulateInstance,
                QUERY_BY_FORM_OILSANDS_PERMIT_ASSESSMENT_ID_STORED_PROCEDURE);
        }

        public List<FunctionalLocation> QueryByFormDocumentSuggestionId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@DocumentSuggestionId", id);
            return command.QueryForListResult(PopulateInstance,
                QUERY_BY_FORM_DOCUMENT_SUGGESTION_ID_STORED_PROCEDURE);
        }

        public List<FunctionalLocation> QueryByFormProcedureDeviationId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@ProcedureDeviationId", id);
            return command.QueryForListResult(PopulateInstance,
                QUERY_BY_FORM_PROCEDURE_DEVIATION_ID_STORED_PROCEDURE);
        }

        public List<FunctionalLocation> QueryByFormMontrealCsdId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormMontrealCsdId", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_MONTREAL_CSD_ID_STORED_PROCEDURE);
        }

        //RITM0268131 - mangesh
        public List<FunctionalLocation> QueryByFormTemporaryInstallationId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormMudsTemporaryInstallationId", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_MUDS_TemporaryInstallation_ID_STORED_PROCEDURE);
        }

        public List<FunctionalLocation> QueryByFormGN24Id(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGN24Id", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_GN24_ID_STORED_PROCEDURE);
        }

        public List<FunctionalLocation> QueryByFormGN6Id(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormGN6Id", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_GN6_ID_STORED_PROCEDURE);
        }

        public List<FunctionalLocation> QueryByFormOilsandsTrainingId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@FormOilsandsTrainingId", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_FORM_OILSANDS_TRAINING_ID_STORED_PROCEDURE);
        }

        public List<FunctionalLocation> QueryByTrainingBlockId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@TrainingBlockId", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_TRAINING_BLOCK_ID_STORED_PROCEDURE);
        }

        public List<FunctionalLocation> QueryByDirectiveId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@DirectiveId", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_DIRECTIVE_ID_STORED_PROCEDURE);
        }

        public List<FunctionalLocation> QueryByDocumentRootPathId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("DocumentRootPathId", id);
            return command.QueryForListResult(PopulateInstance, "QueryFunctionalLocationsByDocumentRootPathId");
        }

        public FunctionalLocation QueryById(long id)
        {
            return ManagedCommand.QueryById(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public void UndoRemove(FunctionalLocation functionalLocation)
        {
            var command = ManagedCommand;
            command.AddParameter("@FunctionalLocationId", functionalLocation.IdValue);
            command.ExecuteNonQuery(UNDO_REMOVE_STORED_PROCEDURE);
        }

        public void RemoveAndAllDescendants(FunctionalLocation functionalLocation)
        {
            ManagedCommand.ExecuteNonQuery(functionalLocation, REMOVE_STORED_PROCEDURE, AddRemoveParameters);
        }

        public void Update(FunctionalLocation functionalLocation)
        {
            ManagedCommand.Update(functionalLocation, AddUpdateParameters, UPDATE_BYID_STORED_PROCEDURE);
        }

        public FunctionalLocation Insert(FunctionalLocation functionalLocation)
        {
            var command = ManagedCommand;
            var id = command.InsertAndReturnId(functionalLocation, AddInsertParameters, INSERT_STORED_PROCEDURE);
            functionalLocation.Id = id;
            return functionalLocation;
        }

        public FunctionalLocation QueryParentSectionFunctionalLocationByChildLevelFunctionalLocation(
            FunctionalLocation childFunctionalLocation)
        {
            return
                QueryByFullHierarchy(
                    childFunctionalLocation.FunctionalLocationHierarchy.GetAncestorOrSelf(2).ToString(),
                    childFunctionalLocation.Site.IdValue);
        }

        public List<FunctionalLocation> QueryChildSectionFunctionalLocationByParentDivisionFunctionalLocations(
            FunctionalLocation divisionFunctionalLocation)
        {
            var command = ManagedCommand;
            command.AddParameter("@DivisionValue", divisionFunctionalLocation.Division);
            return command.QueryForListResult(PopulateInstance, QUERY_CHILD_SECTION_FLOC_BY_PARENT_DIVISION_FLOC);
        }

        public List<FunctionalLocation> QueryByWorkAssignmentId(
            long workAssignmentId)
        {
            var command = ManagedCommand;
            command.AddParameter("@WorkAssignmentId", workAssignmentId);

            var flocList = command.QueryForListResult(PopulateInstance, QUERY_BY_WORK_ASSIGNMENT_ID);

            return flocList;
        }

        public List<FunctionalLocation> QueryByWorkAssignmentIdForWorkPermitAutoAssignment(long workAssignmentId)
        {
            var command = ManagedCommand;
            command.AddParameter("@WorkAssignmentId", workAssignmentId);

            var flocList = command.QueryForListResult(PopulateInstance,
                QUERY_BY_WORK_ASSIGNMENT_ID_FOR_PERMIT_AUTO_ASSIGN);

            return flocList;
        }
        public List<FunctionalLocation> QueryByWorkAssignmentIdForRestrictionFlocs(long workAssignmentId)
        {
            var command = ManagedCommand;
            command.AddParameter("@WorkAssignmentId", workAssignmentId);

            var flocList = command.QueryForListResult(PopulateInstance, QUERY_BY_WORK_ASSIGNMENT_ID_FOR_RESTRICTION_FLOCS);

            return flocList;
        }

        public List<FunctionalLocation> QueryByWorkAssignmentIdRestrictionFlocs(long workAssignmentId)
        {
            var command = ManagedCommand;
            command.AddParameter("@WorkAssignmentId", workAssignmentId);

            var flocList = command.QueryForListResult(PopulateInstance, QUERY_BY_WORK_ASSIGNMENT_ID_FOR_RESTRICTION_FLOCS);

            return flocList;            
        }

        public List<FunctionalLocation> QueryByWorkAssignmentIdForWorkPermits(long workAssignmentId)
        {
            var command = ManagedCommand;
            command.AddParameter("@WorkAssignmentId", workAssignmentId);

            var flocList = command.QueryForListResult(PopulateInstance, QUERY_BY_WORK_ASSIGNMENT_ID_FOR_PERMITS);

            return flocList;
        }

        public FunctionalLocation QueryByFullHierarchyIncludeDeletedToTestExistence(string fullHierarchy)
        {
            var command = ManagedCommand;
            command.AddParameter("@FullHierarchy", fullHierarchy);
            return command.QueryForSingleResult(PopulateInstance,
                QUERY_BY_FULLHIERARCHY_SITEID_INCLUDE_DELETED_TO_TEST_EXISTENCE_STORED_PROCEDURE);
        }

        public static FunctionalLocation PopulateInstance(SqlDataReader reader)
        {
            var site = siteDao.QueryById(reader.Get<long>("SiteId"));
            var b = reader.Get<byte>("Source");

            var source = b.ToEnum<FunctionalLocationSource>();

            var result = new FunctionalLocation(
                reader.Get<long>("Id"),
                site,
                reader.Get<string>("FullHierarchy"),
                reader.Get<string>("Description"),
                reader.Get<bool>("Deleted"),
                reader.Get<bool>("OutOfService"),
                reader.Get<long>("PlantId"),
                reader.Get<string>("Culture"), source);


            return result;
        }


        private static void AddUpdateParameters(FunctionalLocation functionalLocation, SqlCommand command)
        {
            command.AddParameter("@Id", functionalLocation.Id);
            command.AddParameter("@Description", functionalLocation.Description);
            command.AddParameter("@Culture", functionalLocation.Culture);
        }

        private static void AddInsertParameters(FunctionalLocation functionalLocation, SqlCommand command)
        {
            command.AddParameter("@FullHierarchy", functionalLocation.FullHierarchy);
            command.AddParameter("@SiteID", functionalLocation.Site.Id);
            command.AddParameter("@Level", functionalLocation.Level);
            command.AddParameter("@Description", functionalLocation.Description);
            command.AddParameter("@PlantId", functionalLocation.PlantId);
            command.AddParameter("@Culture", functionalLocation.Culture);
            command.AddParameter("@Source", functionalLocation.Source);
        }

        private static void AddRemoveParameters(FunctionalLocation functionalLocation, SqlCommand command)
        {
            command.AddParameter("@Id", functionalLocation.Id);
        }
    }
}