IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormGN6FunctionalLocation')
	BEGIN
		DROP  Procedure  InsertFormGN6FunctionalLocation
	END

GO

CREATE Procedure [dbo].[InsertFormGN6FunctionalLocation]
	(
	@FormGN6Id bigint,
	@FunctionalLocationId bigint	
	)
AS

INSERT INTO 
	[FormGN6FunctionalLocation]
	(
	[FormGN6Id],
	[FunctionalLocationId]
	)
VALUES
	(	
	@FormGN6Id,
	@FunctionalLocationId	
	)
	

GRANT EXEC ON [InsertFormGN6FunctionalLocation] TO PUBLIC
GO