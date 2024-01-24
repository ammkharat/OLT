IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveExpiredObjectLocks')
	BEGIN
		DROP  Procedure  [dbo].RemoveExpiredObjectLocks
	END

GO

CREATE Procedure [dbo].RemoveExpiredObjectLocks
	(
	    @Now datetime,
		@TimeoutInMinutes int
	)

AS

DELETE FROM ObjectLock WHERE DATEDIFF(minute, ObjectLock.LockedOnDateTime, @Now) > @TimeoutInMinutes; 

GO

