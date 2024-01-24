IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveActionItem')
	BEGIN
		DROP  Procedure  RemoveActionItem
	END

GO

CREATE Procedure [dbo].RemoveActionItem
	(
		@id bigint,
		@LastModifiedUserId bigint, 
		@LastModifiedDateTime datetime

	)
AS

UPDATE ActionItem
	SET [LastModifiedUserId] = @LastModifiedUserId, 
		[LastModifiedDateTime] = @LastModifiedDateTime,
		[Deleted] = 1
	WHERE Id=@Id

	--delete the action item custom fields group if any
	delete ActionItemCustomFieldGroup where ActionItemId = @id


GRANT EXEC ON RemoveActionItem TO PUBLIC

GO


