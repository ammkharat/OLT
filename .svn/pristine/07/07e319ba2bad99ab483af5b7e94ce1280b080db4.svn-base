IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveBusinessCategory')
	BEGIN
		DROP  Procedure  RemoveBusinessCategory
	END

GO

CREATE Procedure [dbo].RemoveBusinessCategory
	(
		@id bigint,
		@LastModifiedUserId bigint, 
		@LastModifiedDateTime datetime
	)
AS

UPDATE 	[BusinessCategory] 
	SET [LastModifiedUserId] = @LastModifiedUserId, 
		[LastModifiedDateTime] = @LastModifiedDateTime,
		[Deleted] = 1
	WHERE Id=@Id
GO


GRANT EXEC ON RemoveBusinessCategory TO PUBLIC

GO 