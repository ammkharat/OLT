
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertWorkPermitMudsPermitAttributeAssociation')
	BEGIN
		DROP Procedure [dbo].InsertWorkPermitMudsPermitAttributeAssociation
	END
GO

CREATE Procedure [dbo].[InsertWorkPermitMudsPermitAttributeAssociation]  
 (  
 @WorkPermitMudsId bigint,  
 @PermitAttributeId bigint ,
 @WorkPermitTypeId bigint   
 )  
AS  
  
INSERT INTO WorkPermitMudsPermitAttributeAssociation  
(  
 WorkPermitMudsId,   
 PermitAttributeId  
)  
VALUES  
(  
 @WorkPermitMudsId,   
 @PermitAttributeId  
)  

Declare @Name varchar(100) = (Select Name From PermitAttribute Where Id = @PermitAttributeId And SiteId = 16)
exec UpdateWorkPermitMudsDetailsBasedOnPermitAttributeAssociation @WorkPermitMudsId, @PermitAttributeId, @Name, @WorkPermitTypeid
GO


GRANT EXEC ON InsertWorkPermitMudsPermitAttributeAssociation TO PUBLIC
GO


