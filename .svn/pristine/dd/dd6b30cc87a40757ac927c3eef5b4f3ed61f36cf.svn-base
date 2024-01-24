IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormTemplateByFormTypeId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormTemplateByFormTypeId
	END
GO

CREATE Procedure dbo.QueryFormTemplateByFormTypeId
	(
		@FormTypeId int, @siteid bigint
	)
AS

SELECT ft.*
FROM FormTemplate ft
WHERE
	ft.FormTypeId = @FormTypeId AND SiteId = @siteid AND
	ft.Deleted != 1
GO

GRANT EXEC ON QueryFormTemplateByFormTypeId TO PUBLIC
GO