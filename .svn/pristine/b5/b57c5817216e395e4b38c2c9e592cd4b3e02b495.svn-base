IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormTemplateByFormTypeIdAndKey')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormTemplateByFormTypeIdAndKey
	END
GO

CREATE Procedure dbo.QueryFormTemplateByFormTypeIdAndKey
	(
		@FormTypeId int,
		@TemplateKey varchar(100)
	)
AS

SELECT ft.*
FROM FormTemplate ft
WHERE
	ft.FormTypeId = @FormTypeId AND
	ft.TemplateKey = @TemplateKey AND
	ft.Deleted = 0
GO

GRANT EXEC ON QueryFormTemplateByFormTypeIdAndKey TO PUBLIC
GO