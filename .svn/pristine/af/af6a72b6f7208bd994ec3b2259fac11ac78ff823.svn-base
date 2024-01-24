IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryEventSinks')
	BEGIN
		DROP PROCEDURE [dbo].QueryEventSinks
	END
GO

CREATE Procedure [dbo].QueryEventSinks
AS

SELECT * FROM EventSinks
GO

GRANT EXEC ON QueryEventSinks TO PUBLIC
GO