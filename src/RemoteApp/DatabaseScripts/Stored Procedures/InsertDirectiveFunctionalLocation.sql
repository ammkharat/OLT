IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertDirectiveFunctionalLocation')
	BEGIN
		DROP  Procedure  InsertDirectiveFunctionalLocation
	END

GO

CREATE Procedure [dbo].[InsertDirectiveFunctionalLocation]
(
	@DirectiveId bigint,
	@FunctionalLocationId bigint
)
AS

INSERT INTO [DirectiveFunctionalLocation]
(
	[DirectiveId],
	[FunctionalLocationId]
)
VALUES
(
	@DirectiveId,
	@FunctionalLocationId
)
	

GRANT EXEC ON [InsertDirectiveFunctionalLocation] TO PUBLIC
GO