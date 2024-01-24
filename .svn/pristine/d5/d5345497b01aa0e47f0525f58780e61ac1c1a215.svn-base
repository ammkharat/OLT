  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteFormOP14FunctionalLocationsByFormOP14Id')
	BEGIN
		DROP  Procedure  DeleteFormOP14FunctionalLocationsByFormOP14Id
	END

GO

CREATE Procedure dbo.DeleteFormOP14FunctionalLocationsByFormOP14Id
	(	
	@FormOP14Id bigint
	)
AS
DELETE FROM FormOP14FunctionalLocation WHERE FormOP14Id = @FormOP14Id

RETURN

GO   