IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormGN59FunctionalLocation')
	BEGIN
		DROP  Procedure  InsertFormGN59FunctionalLocation
	END

GO

CREATE Procedure [dbo].[InsertFormGN59FunctionalLocation]
	(
	@FormGN59Id bigint,
	@FunctionalLocationId bigint	
	)
AS

INSERT INTO 
	[FormGN59FunctionalLocation]
	(
	[FormGN59Id],
	[FunctionalLocationId]
	)
VALUES
	(	
	@FormGN59Id,
	@FunctionalLocationId	
	)
	

GRANT EXEC ON [InsertFormGN59FunctionalLocation] TO PUBLIC
GO