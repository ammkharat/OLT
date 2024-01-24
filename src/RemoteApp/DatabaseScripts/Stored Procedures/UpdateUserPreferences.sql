if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateUserPreferences]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateUserPreferences]
GO

CREATE Procedure [dbo].[UpdateUserPreferences]
(
	@Id bigint,
	@UserId bigint,
	@ActionItemDefinitionLastUsedWorkAssignmentId bigint = null
)
AS

UPDATE    UserPreferences
SET              
	UserId = @UserId,
	ActionItemDefinitionLastUsedWorkAssignmentId = @ActionItemDefinitionLastUsedWorkAssignmentId
WHERE     (Id = @Id)
GO

GRANT EXEC ON [dbo].[UpdateUserPreferences] TO PUBLIC

GO 