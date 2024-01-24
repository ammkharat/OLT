  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteLogTemplateWorkAssignmentByLogTemplateId')
	BEGIN
		DROP  Procedure  DeleteLogTemplateWorkAssignmentByLogTemplateId
	END

GO

CREATE Procedure dbo.DeleteLogTemplateWorkAssignmentByLogTemplateId
	(	
	@LogTemplateId bigint
	)
AS
DELETE FROM LogTemplateWorkAssignment WHERE LogTemplateId = @LogTemplateId

RETURN

GO    