IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkAssignmentByFunctionalLocationList')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkAssignmentByFunctionalLocationList
	END
GO

CREATE Procedure dbo.QueryWorkAssignmentByFunctionalLocationList
	(
	@CsvFLOCIds varchar(max)
	)
AS

SELECT 
	distinct asg.* 
FROM 
	WorkAssignment asg
	inner join WorkAssignmentFunctionalLocation asgfloc on asg.Id = asgFloc.WorkAssignmentId
WHERE 
	Deleted = 0 AND
	(
		EXISTS 
		(
			select IDSplitter.Id from IDSplitter(@CsvFLOCIds)
			where 
		  IDSplitter.Id = asgfloc.FunctionalLocationId 
		) OR EXISTS
		(
			select fla.AncestorId from FunctionalLocationAncestor fla
			INNER JOIN IDSplitter(@CsvFLOCIds) QueryIds on fla.Id = QueryIds.Id
			where asgfloc.FunctionalLocationId = fla.AncestorId
		) OR EXISTS
		(
			select fla.Id from FunctionalLocationAncestor fla
			INNER JOIN IDSplitter(@CsvFLOCIds) QueryIds on fla.AncestorId = QueryIds.Id
			where asgfloc.FunctionalLocationId = fla.Id
		)
	)
ORDER BY 
	[Name]
OPTION (OPTIMIZE FOR UNKNOWN)		
GO  

GRANT EXEC ON QueryWorkAssignmentByFunctionalLocationList TO PUBLIC
GO