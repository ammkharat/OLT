IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormGN24FunctionalLocation')
	BEGIN
		DROP  Procedure  InsertFormGN24FunctionalLocation
	END

GO

CREATE Procedure [dbo].[InsertFormGN24FunctionalLocation]
	(
	@FormGN24Id bigint,
	@FunctionalLocationId bigint	
	)
AS

INSERT INTO 
	[FormGN24FunctionalLocation]
	(
	[FormGN24Id],
	[FunctionalLocationId]
	)
VALUES
	(	
	@FormGN24Id,
	@FunctionalLocationId	
	)
	

GRANT EXEC ON [InsertFormGN24FunctionalLocation] TO PUBLIC
GO