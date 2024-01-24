 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveRestrictionReasonCode')
	BEGIN
		DROP  Procedure  RemoveRestrictionReasonCode
	END

GO

CREATE Procedure [dbo].RemoveRestrictionReasonCode
	(
		@id bigint,
		@LastModifiedUserId bigint, 
		@LastModifiedDateTime datetime,
		@SiteId bigint
	)
AS

UPDATE [RestrictionReasonCode] 
	SET [LastModifiedUserId] = @LastModifiedUserId, 
		[LastModifiedDateTime] = @LastModifiedDateTime,
		[Deleted] = 1
	WHERE Id=@Id and SiteId = @SiteId

GO

GRANT EXEC ON RemoveRestrictionReasonCode TO PUBLIC

GO