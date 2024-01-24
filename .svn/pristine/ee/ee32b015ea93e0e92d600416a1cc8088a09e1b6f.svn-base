 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveObjectLockByGuId')
	BEGIN
		DROP  Procedure  [dbo].RemoveObjectLockByGuId
	END

GO

CREATE Procedure [dbo].RemoveObjectLockByGuId
	(
		@LockedByGuid varchar(255)
	)
AS

DELETE FROM ObjectLock WHERE LockedByGuid=@LockedByGuid

GO


