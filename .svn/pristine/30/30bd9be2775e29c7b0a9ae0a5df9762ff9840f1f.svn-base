if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUserPreferences]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUserPreferences]
GO

CREATE Procedure [dbo].[InsertUserPreferences]
(
	@Id bigint output,
	@UserId bigint,
	@ActionItemDefinitionLastUsedWorkAssignmentId bigint = null	
)
AS

INSERT INTO UserPreferences
	(
		UserId,
		ActionItemDefinitionLastUsedWorkAssignmentId
	)
VALUES	
	(
		@UserId,		
		@ActionItemDefinitionLastUsedWorkAssignmentId
	)

SET @Id= SCOPE_IDENTITY() 
GO 

GRANT EXEC ON [dbo].[InsertUserPreferences] TO PUBLIC
GO