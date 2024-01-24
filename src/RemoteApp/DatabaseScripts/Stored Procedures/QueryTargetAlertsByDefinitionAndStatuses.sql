IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTargetAlertsByDefinitionAndStatuses')
	BEGIN
		DROP PROCEDURE [dbo].QueryTargetAlertsByDefinitionAndStatuses
	END
GO

CREATE Procedure [dbo].QueryTargetAlertsByDefinitionAndStatuses
(
    @TargetDefinitionId int,
    @StatusIds varchar(MAX)
)
AS

SELECT
	*
FROM
    TargetAlert targetAlert
WHERE
	targetAlert.TargetDefinitionID = @TargetDefinitionId AND
	EXISTS (SELECT * FROM IDSplitter(@StatusIds) statusId WHERE statusId.Id = targetAlert.TargetAlertStatusID)
GO  

GRANT EXEC ON QueryTargetAlertsByDefinitionAndStatuses TO PUBLIC
GO