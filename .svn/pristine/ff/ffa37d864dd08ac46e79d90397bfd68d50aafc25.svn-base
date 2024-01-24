IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateCustomFieldGroup')
	BEGIN
		DROP  Procedure  UpdateCustomFieldGroup
	END

GO

CREATE Procedure [dbo].UpdateCustomFieldGroup

@ActionItemDefinitionId bigint,
@CustomFieldGroupId bigint,
@AutoPopulate bit,
@Reading bit

as

update ActionItemDefinitionCustomFieldGroup set 
CustomFieldGroupId = @CustomFieldGroupId ,
AutoPopulate = @autoPopulate,
Reading = @Reading

where ActionItemDefinitionId = @ActionItemDefinitionId


