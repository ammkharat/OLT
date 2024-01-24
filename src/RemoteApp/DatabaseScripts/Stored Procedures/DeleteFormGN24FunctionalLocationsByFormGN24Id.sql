  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteFormGN24FunctionalLocationsByFormGN24Id')
	BEGIN
		DROP  Procedure  DeleteFormGN24FunctionalLocationsByFormGN24Id
	END

GO

CREATE Procedure dbo.DeleteFormGN24FunctionalLocationsByFormGN24Id
	(	
	@FormGN24Id bigint
	)
AS
DELETE FROM FormGN24FunctionalLocation WHERE FormGN24Id = @FormGN24Id

RETURN

GO   