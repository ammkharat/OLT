IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllHoneywellPhdConnections')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllHoneywellPhdConnections
	END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllScadaConnections')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllScadaConnections
	END
GO

CREATE Procedure [dbo].QueryAllScadaConnections
AS

SELECT 
	*
FROM
	ScadaConnectionInfo
ORDER BY SiteId
GO

GRANT EXEC ON QueryAllScadaConnections TO PUBLIC
GO