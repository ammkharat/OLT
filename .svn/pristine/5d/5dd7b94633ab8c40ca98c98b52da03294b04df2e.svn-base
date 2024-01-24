IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogTemplateById')
	BEGIN
		DROP PROCEDURE [dbo].QueryLogTemplateById
	END
GO

CREATE Procedure [dbo].QueryLogTemplateById
	(
		@id bigint
	)
AS

select * from LogTemplate where id = @id
GO

GRANT EXEC ON QueryLogTemplateById TO PUBLIC
GO 