  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteFormGN6FunctionalLocationsByFormGN6Id')
	BEGIN
		DROP  Procedure  DeleteFormGN6FunctionalLocationsByFormGN6Id
	END

GO

CREATE Procedure dbo.DeleteFormGN6FunctionalLocationsByFormGN6Id
	(	
	@FormGN6Id bigint
	)
AS
DELETE FROM FormGN6FunctionalLocation WHERE FormGN6Id = @FormGN6Id

RETURN

GO   