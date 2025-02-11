
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByPermitRequestMudsId')
	BEGIN
		DROP Procedure [dbo].QueryDocumentLinkByPermitRequestMudsId
	END
GO

CREATE Procedure [dbo].[QueryDocumentLinkByPermitRequestMudsId]  
 (  
  @PermitRequestMudsId bigint  
 )  
  
AS  
SELECT    
 *  
FROM  
 [DocumentLink]   
WHERE  
 PermitRequestMudsId = @PermitRequestMudsId   
 and Deleted = 0  
 and PermitRequestMudsId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON QueryDocumentLinkByPermitRequestMudsId TO PUBLIC
GO

