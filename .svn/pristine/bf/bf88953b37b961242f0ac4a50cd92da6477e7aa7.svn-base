IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryHoneywellPhdConnectionBySite')
	BEGIN
		DROP PROCEDURE [dbo].QueryHoneywellPhdConnectionBySite
	END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryScadaConnectionBySite')
	BEGIN
		DROP PROCEDURE [dbo].QueryScadaConnectionBySite
	END
GO

CREATE Procedure [dbo].QueryScadaConnectionBySite
	(
		@SiteId BIGINT
	)
AS


SELECT 
	*
FROM
	ScadaConnectionInfo
WHERE
	SiteId = @SiteId
GO

GRANT EXEC ON QueryScadaConnectionBySite TO PUBLIC
GO