IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormOP14FunctionalLocation')
	BEGIN
		DROP  Procedure  InsertFormOP14FunctionalLocation
	END

GO

CREATE Procedure [dbo].[InsertFormOP14FunctionalLocation]
	(
	@FormOP14Id bigint,
	@FunctionalLocationId bigint	
	)
AS

INSERT INTO 
	[FormOP14FunctionalLocation]
	(
	[FormOP14Id],
	[FunctionalLocationId]
	)
VALUES
	(	
	@FormOP14Id,
	@FunctionalLocationId	
	)
	

GRANT EXEC ON [InsertFormOP14FunctionalLocation] TO PUBLIC
GO