IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CountLogsAssociatedToActionItem')
	BEGIN
		DROP PROCEDURE [dbo].CountLogsAssociatedToActionItem
	END
GO

CREATE Procedure [dbo].CountLogsAssociatedToActionItem
	(
		@ActionItemId [bigint]
	)
AS

SELECT
	Count(laia.LogId) as COUNT
FROM
	[LogActionItemAssociation] laia
	join [Log] l on l.Id = laia.LogId
WHERE
	laia.ActionItemId = @ActionItemId and
	l.Deleted = 0
GO

GRANT EXEC ON CountLogsAssociatedToActionItem TO PUBLIC
GO