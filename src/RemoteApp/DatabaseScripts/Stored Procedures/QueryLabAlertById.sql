IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLabAlertById')
	BEGIN
		DROP PROCEDURE [dbo].QueryLabAlertById
	END
GO

CREATE Procedure [dbo].QueryLabAlertById
(
	@id int
)
AS

SELECT * FROM LabAlert 
WHERE ID=@id
GO

GRANT EXEC ON QueryLabAlertById TO PUBLIC
GO