IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormGN7FunctionalLocation')
	BEGIN
		DROP  Procedure  InsertFormGN7FunctionalLocation
	END

GO

CREATE Procedure [dbo].[InsertFormGN7FunctionalLocation]
	(
	@FormGN7Id bigint,
	@FunctionalLocationId bigint	
	)
AS

INSERT INTO 
	[FormGN7FunctionalLocation]
	(
	[FormGN7Id],
	[FunctionalLocationId]
	)
VALUES
	(	
	@FormGN7Id,
	@FunctionalLocationId	
	)
	

GRANT EXEC ON [InsertFormGN7FunctionalLocation] TO PUBLIC
GO