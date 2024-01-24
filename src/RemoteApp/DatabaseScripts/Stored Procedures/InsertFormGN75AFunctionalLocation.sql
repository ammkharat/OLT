IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormGN75AFunctionalLocation')
	BEGIN
		DROP  Procedure  InsertFormGN75AFunctionalLocation
	END

GO

CREATE Procedure [dbo].InsertFormGN75AFunctionalLocation(@FormGN75AId bigint, @FunctionalLocationId bigint)
AS

INSERT INTO [FormGN75AFunctionalLocation](FormGN75AId, FunctionalLocationId) VALUES (@FormGN75AId, @FunctionalLocationId)
	

GRANT EXEC ON [InsertFormGN75AFunctionalLocation] TO PUBLIC
GO