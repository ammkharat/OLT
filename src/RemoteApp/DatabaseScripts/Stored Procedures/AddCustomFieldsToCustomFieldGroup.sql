IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'AddCustomFieldsToCustomFieldGroup')
	BEGIN
		DROP  Procedure  AddCustomFieldsToCustomFieldGroup
	END

GO


CREATE Procedure [dbo].[AddCustomFieldsToCustomFieldGroup]
(
    @CustomFieldGroupId bigint,
	@CustomFieldId bigint,
	@DisplayOrder int
)
AS

INSERT INTO [CustomFieldCustomFieldGroup] (CustomFieldId, CustomFieldGroupId, DisplayOrder)
values (@CustomFieldId, @CustomFieldGroupId, @DisplayOrder)

GRANT EXEC ON AddCustomFieldsToCustomFieldGroup TO PUBLIC
GO
 