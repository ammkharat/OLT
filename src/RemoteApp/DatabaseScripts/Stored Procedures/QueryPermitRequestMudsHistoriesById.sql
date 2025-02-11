
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestMudsHistoriesById')
	BEGIN
		DROP Procedure [dbo].QueryPermitRequestMudsHistoriesById
	END
GO

CREATE Procedure [dbo].[QueryPermitRequestMudsHistoriesById]  
 (  
 @Id bigint  
 )  
AS  
SELECT *   
FROM PermitRequestMudsHistory   
WHERE Id=@Id   
ORDER BY LastModifiedDateTime
GO

GRANT EXEC ON QueryPermitRequestMudsHistoriesById TO PUBLIC
GO
