IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryObjectLockByOid')
	BEGIN
		DROP PROCEDURE [dbo].QueryObjectLockByOid
	END
GO

CREATE Procedure [dbo].QueryObjectLockByOid
	(
		@ObjectIdentifier varchar(255)
	)

AS

SELECT 
	ObjectLock.*, 
	[User].UserName, 
	[User].FirstName, 
	[User].LastName 
FROM 
	ObjectLock,[User] 
WHERE 
	ObjectIdentifier=@ObjectIdentifier AND ObjectLock.LockedByUserId=[User].Id;
GO

GRANT EXEC ON QueryObjectLockByOid TO PUBLIC
GO