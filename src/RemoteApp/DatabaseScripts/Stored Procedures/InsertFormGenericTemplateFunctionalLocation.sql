IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormGenericTemplateFunctionalLocation')
	BEGIN
		DROP  Procedure  InsertFormGenericTemplateFunctionalLocation
	END

GO

CREATE Procedure [dbo].[InsertFormGenericTemplateFunctionalLocation]
	(
	@FormGenericTemplateId bigint,
	@FunctionalLocationId bigint	
	)
AS

INSERT INTO 
	[FormGenericTemplateFunctionalLocation]
	(
	[FormGenericTemplateId],
	[FunctionalLocationId]
	)
VALUES
	(	
	@FormGenericTemplateId,
	@FunctionalLocationId	
	)
	

GRANT EXEC ON [InsertFormGenericTemplateFunctionalLocation] TO PUBLIC
Go