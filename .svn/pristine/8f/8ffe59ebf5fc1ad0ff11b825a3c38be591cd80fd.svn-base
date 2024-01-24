IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySpecialWorkBySite')
	BEGIN
		DROP Procedure [dbo].QuerySpecialWorkBySite
	END
GO

CREATE Procedure [dbo].[QuerySpecialWorkBySite]      
 (      
  @SiteId BIGINT      
 )      
AS      
SELECT *      
FROM SpecialWork      
WHERE WorkPermitId Is Null And PermitRequestId Is Null  
And SiteId = @SiteId  

GO

GRANT EXEC ON QuerySpecialWorkBySite TO PUBLIC
GO

