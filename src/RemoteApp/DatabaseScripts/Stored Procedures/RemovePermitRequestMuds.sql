
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemovePermitRequestMuds')
	BEGIN
		DROP Procedure [dbo].RemovePermitRequestMuds
	END
GO

CREATE Procedure [dbo].[RemovePermitRequestMuds]  
 (  
  @id bigint,  
  @LastModifiedByUserId bigint,   
  @LastModifiedDateTime datetime  
 )  
AS  
  
UPDATE  PermitRequestMuds  
 SET LastModifiedByUserId = @LastModifiedByUserId,   
  LastModifiedDateTime = @LastModifiedDateTime,  
  Deleted = 1  
 WHERE Id=@Id
GO

GRANT EXEC ON RemovePermitRequestMuds TO PUBLIC
GO

