  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteFormGN59FunctionalLocationsByFormGN59Id')
	BEGIN
		DROP  Procedure  DeleteFormGN59FunctionalLocationsByFormGN59Id
	END

GO

CREATE Procedure dbo.DeleteFormGN59FunctionalLocationsByFormGN59Id
	(	
	@FormGN59Id bigint
	)
AS
DELETE FROM FormGN59FunctionalLocation WHERE FormGN59Id = @FormGN59Id

RETURN

GO   