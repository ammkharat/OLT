IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveActionItemDefinition')
	BEGIN
		DROP  Procedure  RemoveActionItemDefinition
	END

GO

CREATE Procedure [dbo].RemoveActionItemDefinition
	(
		@id bigint,
		@LastModifiedUserId bigint, 
		@LastModifiedDateTime datetime

	)
AS

UPDATE ActionItemDefinition 
	SET [LastModifiedUserId] = @LastModifiedUserId, 
		[LastModifiedDateTime] = @LastModifiedDateTime,
		[Deleted] = 1
	WHERE Id=@Id

	--Delete related Send Email entry in actionitemdefinitionsendemail
	delete actionitemdefinitionsendemail where ActionItemDefinitionId = @id

	--Delete related custom fields group in ActionItemDefinitionCustomFieldGroup
	delete ActionItemDefinitionCustomFieldGroup where ActionItemDefinitionId = @id
	

GO


GRANT EXEC ON RemoveActionItemDefinition TO PUBLIC

GO


