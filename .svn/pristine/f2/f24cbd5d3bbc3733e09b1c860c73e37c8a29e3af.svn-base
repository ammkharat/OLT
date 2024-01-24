IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertObjectLock')
	BEGIN
		DROP  Procedure  [dbo].InsertObjectLock
	END

GO

CREATE Procedure [dbo].InsertObjectLock
	(
		@ObjectIdentifier varchar(255),
		@LockedByUserId bigint,
		@LockedByGuid varchar(255),
		@LockedOnDateTime datetime
	)

AS

INSERT INTO ObjectLock (ObjectIdentifier, LockedByUserId, LockedOnDateTime, LockedByGuid) 
VALUES (@ObjectIdentifier, @LockedByUserId, @LockedOnDateTime, @LockedByGuid);

GO
GRANT EXEC ON InsertObjectLock TO PUBLIC
GO

