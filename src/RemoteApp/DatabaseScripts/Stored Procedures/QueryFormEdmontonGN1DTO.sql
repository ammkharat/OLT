IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormEdmontonGN1DTO')
    BEGIN
        DROP PROCEDURE [dbo].QueryFormEdmontonGN1DTO
    END
GO

CREATE Procedure [dbo].QueryFormEdmontonGN1DTO
    (
        @CsvFlocIds VARCHAR(MAX),
        @StartOfDateRange DateTime,
        @EndOfDateRange DateTime,
		@CsvFormStatusIds varchar(max),
		@IncludeAllDraft bit
    )
AS

WITH FormEdmontonGN1_Id_Cte (FormGN1Id)
AS
(
  SELECT DISTINCT f.Id
  FROM
    FormGN1 f
	INNER JOIN FunctionalLocation fl ON fl.Id = f.FunctionalLocationId	
  WHERE
    f.Deleted = 0 AND
	(
	    EXISTS (
			-- Floc of Form matches one of the passed in flocs
			select * From IDSplitter(@CsvFLOCIds) flocIds
			WHERE flocIds.Id = fl.Id
	    )
	    OR EXISTS (
			-- Floc of Form is parent of one of the passed in flocs (look up the floc tree from my selected flocs)
			select * from FunctionalLocationAncestor a
			INNER JOIN IDSplitter(@CsvFLOCIds) flocIds ON flocIds.Id = a.Id
			WHERE a.AncestorId = fl.Id
	    )
	    OR EXISTS (
			-- Floc of Form is child of one of the passed in flocs (look down the floc tree from my selected flocs)
			select * from FunctionalLocationAncestor a
			INNER JOIN IDSplitter(@CsvFLOCIds) flocIds ON flocIds.Id = a.ancestorid
			WHERE a.Id = fl.Id
	    )
    )
)

SELECT
    f.Id as Id,	
	6 as FormTypeId,
	
	f.CreatedDateTime,	
	f.CreatedByUserId,
	f.LastModifiedByUserId,
	f.LastModifiedDateTime,
	f.ApprovedDateTime,
	f.ClosedDateTime,
	f.TradeChecklistNames,
	f.FromDateTime,
	f.ToDateTime,
	f.FormStatusId,	
	f.CSELevel,
	
    createdByUser.LastName as CreatedByLastName,
    createdByUser.FirstName as CreatedByFirstName,
    createdByUser.UserName as CreatedByUserName,
	
    fl.FullHierarchy as FullHierarchy,
	
	pwa.Approver as PlanningWorksheetApprovalApprover,
	pwa.ApprovedByUserId as PlanningWorksheetApprovalApprovedByUserId,
	pwa.DisplayOrder as PlanningWorkSheetApprovalDisplayOrder,
	
	rpa.Approver as RescuePlanApprovalApprover,
	rpa.ApprovedByUserId as RescuePlanApprovalApprovedByUserId,
	rpa.DisplayOrder as RescuePlanApprovalDisplayOrder,
	
	tc.ConstFieldMaintCoordApproval as TradeChecklistConstFieldMaintCoordApproval,
	tc.OpsCoordApproval as TradeChecklistOpsCoordApproval,
	tc.AreaManagerApproval as TradeChecklistAreaManagerApproval
	
FROM
    FormGN1 f  
	INNER JOIN FormEdmontonGN1_Id_Cte ON FormGN1Id = f.Id	
    INNER JOIN [FunctionalLocation] fl on fl.Id = f.FunctionalLocationId
    INNER JOIN [User] createdByUser on f.CreatedByUserId = createdByUser.Id
	LEFT OUTER JOIN [FormGN1PlanningWorksheetApproval] pwa on pwa.FormGN1Id = f.Id and pwa.ApprovedByUserId is null
	LEFT OUTER JOIN [FormGN1RescuePlanApproval] rpa on rpa.FormGN1Id = f.Id and rpa.ApprovedByUserId is null
	LEFT OUTER JOIN [TradeChecklist] tc on tc.FormGN1Id = f.Id and tc.Deleted = 0
WHERE 
	-- if we want to include all Draft forms, then return the form if it's status is Draft
	(@IncludeAllDraft = 0 AND f.FormStatusId = 15)
	OR
	-- otherwise,  we need to check the status and date range to make sure they match the params passed in
	(f.FromDateTime <= @EndOfDateRange AND f.ToDateTime >= @StartOfDateRange AND EXISTS (SELECT * FROM IDSplitter(@CsvFormStatusIds) WHERE Id = f.FormStatusId))
ORDER BY f.Id
OPTION (OPTIMIZE FOR UNKNOWN)	
GO
GRANT EXEC on QueryFormEdmontonGN1DTO TO PUBLIC
GO