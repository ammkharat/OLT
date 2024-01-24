  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteFormGN7FunctionalLocationsByFormGN7Id')
	BEGIN
		DROP  Procedure  DeleteFormGN7FunctionalLocationsByFormGN7Id
	END

GO

CREATE Procedure dbo.DeleteFormGN7FunctionalLocationsByFormGN7Id
	(	
	@FormGN7Id bigint
	)
AS
DELETE FROM FormGN7FunctionalLocation WHERE FormGN7Id = @FormGN7Id

RETURN

GO   