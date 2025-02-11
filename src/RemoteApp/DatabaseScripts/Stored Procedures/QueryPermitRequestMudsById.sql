
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestMudsById')
	BEGIN
		DROP Procedure [dbo].QueryPermitRequestMudsById
	END
GO

CREATE Procedure [dbo].[QueryPermitRequestMudsById]  
(  
 @Id bigint  
)  
AS  
  
SELECT *  
FROM PermitRequestMuds  
WHERE Id=@Id
GO

GRANT EXEC ON QueryPermitRequestMudsById TO PUBLIC
GO

