IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CountLogsAssociatedToWorkPermitMontreal')
	BEGIN
		DROP Procedure [dbo].CountLogsAssociatedToWorkPermitMontreal
	END
GO

CREATE Procedure [dbo].CountLogsAssociatedToWorkPermitMontreal
	(
		@WorkPermitMontrealId [bigint]
	)
AS

SELECT
	Count(assoc.LogId) as COUNT
FROM
	[LogWorkPermitMontrealAssociation] assoc
	inner join [Log] l on l.Id = assoc.LogId
WHERE
	assoc.WorkPermitMontrealId = @WorkPermitMontrealId and
	l.Deleted = 0
	
GO

GRANT EXEC ON CountLogsAssociatedToWorkPermitMontreal TO PUBLIC
GO