
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByWorkPermitMudsId')
	BEGIN
		DROP Procedure [dbo].QueryDocumentLinkByWorkPermitMudsId
	END
GO

CREATE Procedure [dbo].[QueryDocumentLinkByWorkPermitMudsId]      
 (      
  @WorkPermitMudsId bigint      
 )      
      
AS      
SELECT        
 *      
FROM      
 [DocumentLink]       
WHERE      
 FormWorkPermitMudsId = @WorkPermitMudsId      
 and Deleted = 0      
 and FormWorkPermitMudsId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON QueryDocumentLinkByWorkPermitMudsId TO PUBLIC
GO

