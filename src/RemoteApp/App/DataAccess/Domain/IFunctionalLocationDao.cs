using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IFunctionalLocationDao : IDao
    {
//        [CachedQueryList("DivSecUnitFlocFor")]
        List<FunctionalLocation> QueryDivSecUnitBySiteId(long siteId);

        List<FunctionalLocation> QueryByActionItemDefinitionId(long actionItemId);
        List<FunctionalLocation> QueryByActionItemId(long id);

        [CachedQueryById]
        FunctionalLocation QueryById(long id);

//        [CachedQuery("QueryByFullHierarchy")]
        FunctionalLocation QueryByFullHierarchy(string fullHierarchy, long siteId);

        FunctionalLocation QueryByFullHierarchyIncludeDeleted(string fullHierarchy, long siteId);

        FunctionalLocation QueryByFullHierarchyIncludeDeletedToTestExistence(string fullHierarchy);

        void RemoveAndAllDescendants(FunctionalLocation functionalLocation);

        [CachedInsertOrUpdate(false, false)]
        void Update(FunctionalLocation functionalLocation);

        [CachedInsertOrUpdate(false, false)]
        FunctionalLocation Insert(FunctionalLocation functionalLocation);

//        [CachedQuery("Level2AncestorFor")]
        FunctionalLocation QueryParentSectionFunctionalLocationByChildLevelFunctionalLocation(
            FunctionalLocation childFunctionalLocation);

//        [CachedQueryList("Level2ChildrenFor")]
        List<FunctionalLocation> QueryChildSectionFunctionalLocationByParentDivisionFunctionalLocations(
            FunctionalLocation divisionFunctionalLocation);

        // Called by Work Assignment. Caching at Work Assignment
        List<FunctionalLocation> QueryByWorkAssignmentId(long workAssignmentId);
        List<FunctionalLocation> QueryByWorkAssignmentIdForWorkPermitAutoAssignment(long workAssignmentId);

        [CachedInsertOrUpdate(false, false)]
        void UndoRemove(FunctionalLocation functionalLocation);

        List<FunctionalLocation> QueryByLogId(long logId);
        List<FunctionalLocation> QueryByLogDefinitionId(long logDefinitionId);
        List<FunctionalLocation> QueryByShiftHandoverQuestionnaireId(long id);
        List<FunctionalLocation> QueryBySummaryLogId(long id);
        List<FunctionalLocation> QueryByDocumentRootPathId(long id);
        List<FunctionalLocation> QueryByWorkPermitMontrealId(long workPermitId);
        List<FunctionalLocation> QueryByPermitRequestMontrealId(long id);
        List<FunctionalLocation> QueryByFormGN7Id(long id);
        List<FunctionalLocation> QueryByFormGN59Id(long id);
        List<FunctionalLocation> QueryByFormOP14Id(long id);
        List<FunctionalLocation> QueryByFormMontrealCsdId(long id);
        List<FunctionalLocation> QueryByFormGN24Id(long id);
        List<FunctionalLocation> QueryByFormGN6Id(long id);
        List<FunctionalLocation> QueryByFormOilsandsTrainingId(long id);
        List<FunctionalLocation> QueryByWorkAssignmentIdForWorkPermits(long workAssignmentId);
        List<FunctionalLocation> QueryByTrainingBlockId(long id);
        List<FunctionalLocation> QueryByDirectiveId(long directiveId);
        List<FunctionalLocation> QueryByFormOilsandsPermitAssessmentId(long id);
        List<FunctionalLocation> QueryByWorkAssignmentIdForRestrictionFlocs(long workAssignmentId);
        List<FunctionalLocation> QueryByWorkAssignmentIdRestrictionFlocs(long workAssignmentId);
        List<FunctionalLocation> QueryByFormDocumentSuggestionId(long id);
        List<FunctionalLocation> QueryByFormProcedureDeviationId(long id);

        //generic template - mangesh
        List<FunctionalLocation> QueryByFormGenericTemplateId(long id);

        List<FunctionalLocation> QueryByFormTemporaryInstallationId(long id);
        //RITM0301321 mangesh
        List<FunctionalLocation> QueryByWorkPermitMudsId(long workPermitId); 
        List<FunctionalLocation> QueryByPermitRequestMudsId(long id);
    }
}