IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CountLogsAssociatedToWorkPermitEdmonton')
	BEGIN
		DROP Procedure [dbo].CountLogsAssociatedToWorkPermitEdmonton
	END
GO

CREATE Procedure [dbo].CountLogsAssociatedToWorkPermitEdmonton
	(
		@WorkPermitEdmontonId [bigint]
	)
AS

SELECT
	Count(assoc.LogId) as COUNT
FROM
	[LogWorkPermitEdmontonAssociation] assoc
	inner join [Log] l on l.Id = assoc.LogId
WHERE
	assoc.WorkPermitEdmontonId = @WorkPermitEdmontonId and
	l.Deleted = 0
	
GO

GRANT EXEC ON CountLogsAssociatedToWorkPermitEdmonton TO PUBLIC
GO