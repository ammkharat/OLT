IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CountLogsAssociatedToWorkPermitLubes')
	BEGIN
		DROP Procedure [dbo].CountLogsAssociatedToWorkPermitLubes
	END
GO

CREATE Procedure [dbo].CountLogsAssociatedToWorkPermitLubes
	(
		@WorkPermitLubesId [bigint]
	)
AS

SELECT
	Count(assoc.LogId) as COUNT
FROM
	[LogWorkPermitLubesAssociation] assoc
	inner join [Log] l on l.Id = assoc.LogId
WHERE
	assoc.WorkPermitLubesId = @WorkPermitLubesId and
	l.Deleted = 0
	
GO

GRANT EXEC ON CountLogsAssociatedToWorkPermitLubes TO PUBLIC
GO