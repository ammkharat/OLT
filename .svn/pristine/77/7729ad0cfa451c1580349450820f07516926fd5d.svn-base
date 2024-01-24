IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveLog')
	BEGIN
		DROP  Procedure  RemoveLog
	END

GO

CREATE Procedure [dbo].RemoveLog
	(
		@id bigint,
		@LastModifiedUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE 	[Log] 
	SET [LastModifiedUserId] = @LastModifiedUserId, 
		[LastModifiedDateTime] = @LastModifiedDateTime,
		[Deleted] = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemoveLog TO PUBLIC

GO