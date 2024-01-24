 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateRestrictionLocation')
	BEGIN
		DROP  Procedure  UpdateRestrictionLocation
	END

GO


CREATE Procedure [dbo].UpdateRestrictionLocation
(
    @Id bigint,
	@Name varchar (50),
    @LastModifiedByUserId bigint, 
    @LastModifiedDateTime datetime,
	@SiteID bigint
)
AS

UPDATE RestrictionLocation
SET	
	[Name] = @Name,
	[LastModifiedByUserId] = @LastModifiedByUserId,
	[LastModifiedDateTime] = @LastModifiedDateTime
WHERE Id = @Id
GO

GRANT EXEC ON UpdateRestrictionLocation TO PUBLIC
GO