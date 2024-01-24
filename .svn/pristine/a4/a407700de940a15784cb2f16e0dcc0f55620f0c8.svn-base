IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveAllObjectLocks')
	BEGIN
		DROP  Procedure  [dbo].RemoveAllObjectLocks
	END

GO

CREATE Procedure [dbo].RemoveAllObjectLocks

AS

DELETE FROM ObjectLock;

GO

