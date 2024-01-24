 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveRestrictionLocation')
	BEGIN
		DROP  Procedure  RemoveRestrictionLocation
	END

GO


CREATE Procedure [dbo].RemoveRestrictionLocation
(
    @Id bigint,
    @LastModifiedByUserId bigint, 
    @LastModifiedDateTime datetime
	
)
AS

UPDATE RestrictionLocation
SET	
	[LastModifiedByUserId] = @LastModifiedByUserId,
	[LastModifiedDateTime] = @LastModifiedDateTime,
	DELETED = 1
WHERE 
	Id = @Id
GO