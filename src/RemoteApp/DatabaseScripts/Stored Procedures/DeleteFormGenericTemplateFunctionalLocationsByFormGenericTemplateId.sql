 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteFormGenericTemplateFunctionalLocationsByFormGenericTemplateId')
	BEGIN
		DROP  Procedure  DeleteFormGenericTemplateFunctionalLocationsByFormGenericTemplateId
	END

GO

CREATE Procedure [dbo].[DeleteFormGenericTemplateFunctionalLocationsByFormGenericTemplateId]
	(	
	@FormGenericTemplateId bigint
	)
AS
DELETE FROM FormGenericTemplateFunctionalLocation WHERE FormGenericTemplateId = @FormGenericTemplateId

RETURN

GO

