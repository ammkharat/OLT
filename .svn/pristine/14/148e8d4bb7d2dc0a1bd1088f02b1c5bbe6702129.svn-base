IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPropertyByEventId')
	BEGIN
		DROP PROCEDURE [dbo].QueryPropertyByEventId
	END
GO

CREATE Procedure dbo.QueryPropertyByEventId
	(
	@EventId bigint
	)
AS
SELECT * 
FROM Property
WHERE EventId = @EventId
GO

GRANT EXEC ON QueryPropertyByEventId TO PUBLIC
GO