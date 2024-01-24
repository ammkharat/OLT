IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveObjectLockByOidAndUserId')
	BEGIN
		DROP  Procedure  [dbo].RemoveObjectLockByOidAndUserId
	END

GO

CREATE Procedure [dbo].RemoveObjectLockByOidAndUserId
	(
		@ObjectIdentifier varchar(255),
		@UserId bigint
	)

AS

DELETE FROM ObjectLock WHERE ObjectIdentifier=@ObjectIdentifier AND LockedByUserId=@UserId

GO


