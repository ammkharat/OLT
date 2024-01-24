IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryScheduleById')
	BEGIN
		DROP PROCEDURE [dbo].QueryScheduleById
	END
GO

CREATE Procedure [dbo].QueryScheduleById
	(
		@id int
	)
AS

SELECT * FROM Schedule WHERE Id=@id
GO

GRANT EXEC ON [QueryScheduleById] TO PUBLIC
GO