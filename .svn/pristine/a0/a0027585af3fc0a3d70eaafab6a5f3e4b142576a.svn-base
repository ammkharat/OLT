IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteCustomFieldDropDownValuesByCustomFieldId')
	BEGIN
		DROP  Procedure  DeleteCustomFieldDropDownValuesByCustomFieldId
	END

GO

CREATE Procedure [dbo].[DeleteCustomFieldDropDownValuesByCustomFieldId]
(
    @CustomFieldId bigint
)
AS

DELETE FROM [CustomFieldDropDownValue]
where [CustomFieldId] = @CustomFieldId

GO
 