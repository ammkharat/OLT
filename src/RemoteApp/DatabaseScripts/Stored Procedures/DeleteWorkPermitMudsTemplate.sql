
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteWorkPermitMudsTemplate')
	BEGIN
		DROP Procedure [dbo].DeleteWorkPermitMudsTemplate
	END
GO


CREATE Procedure [dbo].[DeleteWorkPermitMudsTemplate]
	(
		@id bigint
	)
AS

UPDATE WorkPermitMudsTemplate
SET Deleted = 1, Active=0
WHERE id = @id
GO


GRANT EXEC ON DeleteWorkPermitMudsTemplate TO PUBLIC
GO

