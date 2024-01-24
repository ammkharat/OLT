IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteWorkPermitMontrealTemplate')
	BEGIN
		DROP PROCEDURE [dbo].DeleteWorkPermitMontrealTemplate
	END
GO

CREATE Procedure [dbo].DeleteWorkPermitMontrealTemplate
	(
		@id bigint
	)
AS

UPDATE WorkPermitMontrealTemplate
SET Deleted = 1, Active=0
WHERE id = @id
GO

GRANT EXEC ON DeleteWorkPermitMontrealTemplate TO PUBLIC
GO 