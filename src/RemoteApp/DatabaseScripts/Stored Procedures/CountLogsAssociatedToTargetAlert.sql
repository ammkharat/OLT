IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CountLogsAssociatedToTargetAlert')
	BEGIN
		DROP Procedure [dbo].CountLogsAssociatedToTargetAlert
	END
GO

CREATE Procedure [dbo].CountLogsAssociatedToTargetAlert
	(
		@TargetAlertId [bigint]
	)
AS

SELECT
	Count(assoc.LogId) as COUNT
FROM
	[LogTargetAlertAssociation] assoc
	inner join [Log] l on l.Id = assoc.LogId
WHERE
	assoc.TargetAlertId = @TargetAlertId and
	l.Deleted = 0
	
GO

GRANT EXEC ON CountLogsAssociatedToTargetAlert TO PUBLIC
GO