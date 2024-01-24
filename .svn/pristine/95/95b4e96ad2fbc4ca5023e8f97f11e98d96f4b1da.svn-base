if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemoveLogTemplateAsAutoInsertChoiceFromWorkAssignmentsThatAreNotConnectedToTheTemplate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RemoveLogTemplateAsAutoInsertChoiceFromWorkAssignmentsThatAreNotConnectedToTheTemplate]
GO

CREATE Procedure [dbo].[RemoveLogTemplateAsAutoInsertChoiceFromWorkAssignmentsThatAreNotConnectedToTheTemplate]
(
	@LogTemplateId bigint
)
AS

UPDATE WorkAssignment
SET AutoInsertLogTemplateId = null
WHERE AutoInsertLogTemplateId = @LogTemplateId AND
      Id not in (SELECT WorkAssignmentId from LogTemplateWorkAssignment where LogTemplateId = @LogTemplateId)
GO

GRANT EXEC ON RemoveLogTemplateAsAutoInsertChoiceFromWorkAssignmentsThatAreNotConnectedToTheTemplate TO PUBLIC
GO