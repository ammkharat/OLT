  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveWorkPermit')
	BEGIN
		DROP  Procedure  RemoveWorkPermit
	END

GO

CREATE Procedure [dbo].RemoveWorkPermit
	(
		@id bigint,
		@LastModifiedUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE [WorkPermit] 
	SET [LastModifiedUserId] = @LastModifiedUserId, 
		[LastModifiedDate] = @LastModifiedDateTime,
		[Deleted] = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemoveWorkPermit TO PUBLIC

GO