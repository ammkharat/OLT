IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryUserPreferencesByUserId')
	BEGIN
		DROP PROCEDURE [dbo].QueryUserPreferencesByUserId
	END
GO

CREATE Procedure [dbo].[QueryUserPreferencesByUserId]
	(
		@UserId bigint
	)
AS

SELECT
	Id, 
	UserId, 
	ActionItemDefinitionLastUsedWorkAssignmentId
FROM
	UserPreferences
WHERE
	UserId = @UserId
GO

GRANT EXEC ON QueryUserPreferencesByUserId TO PUBLIC
GO