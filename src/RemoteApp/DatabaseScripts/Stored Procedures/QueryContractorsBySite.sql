IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryContractorsBySite')
	BEGIN
		DROP PROCEDURE [dbo].QueryContractorsBySite
	END
GO

CREATE Procedure dbo.QueryContractorsBySite
	(
		@SiteId BIGINT
	)
AS
SELECT *
FROM Contractor
WHERE SiteId = @SiteId
ORDER BY CompanyName -- RITM0353906 - Added by Vibhor
GO

GRANT EXEC ON QueryContractorsBySite TO PUBLIC
GO
