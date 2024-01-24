IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCustomFieldDropDownValuesByCustomFieldId')
	BEGIN
		DROP PROCEDURE [dbo].QueryCustomFieldDropDownValuesByCustomFieldId
	END
GO

CREATE Procedure dbo.QueryCustomFieldDropDownValuesByCustomFieldId
	(
		@CustomFieldId bigint
	)
AS

SELECT *
FROM CustomFieldDropDownValue
WHERE [CustomFieldId] = @CustomFieldId
GO

GRANT EXEC ON QueryCustomFieldDropDownValuesByCustomFieldId TO PUBLIC
GO