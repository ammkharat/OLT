IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormTemplateById')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormTemplateById
	END
GO

CREATE Procedure dbo.QueryFormTemplateById
	(
		@Id bigint
	)
AS

SELECT ft.*
FROM FormTemplate ft
WHERE
	Id = @Id
GO

GRANT EXEC ON QueryFormTemplateById TO PUBLIC
GO