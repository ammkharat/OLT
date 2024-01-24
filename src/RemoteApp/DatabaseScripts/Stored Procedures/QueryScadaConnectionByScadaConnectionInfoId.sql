IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryScadaConnectionByScadaConnectionInfoId')
	BEGIN
		DROP PROCEDURE [dbo].QueryScadaConnectionByScadaConnectionInfoId
	END
GO

CREATE Procedure [dbo].QueryScadaConnectionByScadaConnectionInfoId
	(
		@ScadaConnectionInfoId BIGINT
	)
AS


SELECT 
	*
FROM
	ScadaConnectionInfo
WHERE
	Id = @ScadaConnectionInfoId
GO

GRANT EXEC ON QueryScadaConnectionByScadaConnectionInfoId TO PUBLIC
GO