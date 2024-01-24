IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryEventNameWithUniqueness')
	BEGIN
		DROP PROCEDURE [dbo].QueryEventNameWithUniqueness
	END
GO

CREATE Procedure dbo.QueryEventNameWithUniqueness
AS
SELECT DISTINCT(Name)
FROM Event
GO

GRANT EXEC ON QueryEventNameWithUniqueness TO PUBLIC
GO