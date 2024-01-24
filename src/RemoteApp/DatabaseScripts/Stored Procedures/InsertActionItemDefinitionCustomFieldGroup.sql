IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertActionItemDefinitionCustomFieldGroup')
	BEGIN
		DROP PROCEDURE [dbo].InsertActionItemDefinitionCustomFieldGroup
	END
GO

CREATE Procedure [dbo].[InsertActionItemDefinitionCustomFieldGroup]
    (
    @ActionItemDefinitionId bigint,
	@CustomFieldGroupId bigint,
	@AutoPopulate bit,
	@Reading bit
    )
AS

INSERT INTO ActionItemDefinitionCustomFieldGroup (ActionItemDefinitionId, CustomFieldGroupId,AutoPopulate,Reading)
values (@ActionItemDefinitionId, @CustomFieldGroupId,@AutoPopulate,@Reading)

