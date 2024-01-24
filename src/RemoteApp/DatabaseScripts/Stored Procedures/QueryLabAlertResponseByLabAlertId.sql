IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLabAlertResponseByLabAlertId')
	BEGIN
		DROP PROCEDURE [dbo].QueryLabAlertResponseByLabAlertId
	END
GO

CREATE Procedure [dbo].QueryLabAlertResponseByLabAlertId
(
	@LabAlertId int
)
AS

SELECT * 
FROM LabAlertResponse
WHERE LabAlertId=@LabAlertId
GO

GRANT EXEC ON QueryLabAlertResponseByLabAlertId TO PUBLIC
GO