IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateFunctionalLocationOperationalMode')
	BEGIN
		DROP  Procedure  UpdateFunctionalLocationOperationalMode
	END

GO

      
CREATE Procedure [dbo].[UpdateFunctionalLocationOperationalMode]      
(      
 @UnitId bigint,       
 @OperationalModeId BIGINT,      
 @AvailabilityReasonId BIGINT,      
 @LastModifiedDateTime DATETIME      
)      
AS      
   
 If Not Exists( SELECT 1 from FunctionalLocationOperationalMode where (UnitId in (select AncestorId from FunctionalLocationAncestor where Id = @UnitId)) And (OperationalModeId<>0))  
  Begin  
   
    
      
  declare @Level tinyint      
SET @Level = (SELECT [Level] from FunctionalLocation where Id = @UnitId)    
    
    
    
IF (@Level = 3)      
  BEGIN        
  UPDATE          
  FunctionalLocationOperationalMode      
 SET       
  OperationalModeId = @OperationalModeId,      
  AvailabilityReasonId = @AvailabilityReasonId,      
  LastModifiedDateTime = @LastModifiedDateTime      
 WHERE      
  UnitId = @UnitId      
  End    
  Else     
  Begin      
  UPDATE          
  FunctionalLocationOperationalMode      
 SET       
  OperationalModeId = @OperationalModeId,      
  AvailabilityReasonId = @AvailabilityReasonId,      
  LastModifiedDateTime = @LastModifiedDateTime      
 WHERE      
  (UnitId in (Select Id from FunctionalLocationAncestor where AncestorId = @UnitId)) OR  (UnitId = @UnitId)       
  End   
    
  End    
      
  /* prev the procedure was like below */    
  /*    
 CREATE Procedure [dbo].[UpdateFunctionalLocationOperationalMode]      
 (      
  @UnitId bigint,       
  @OperationalModeId BIGINT,      
  @AvailabilityReasonId BIGINT,      
  @LastModifiedDateTime DATETIME      
 )      
 AS      
       
 UPDATE          
  FunctionalLocationOperationalMode      
 SET       
  OperationalModeId = @OperationalModeId,      
  AvailabilityReasonId = @AvailabilityReasonId,      
  LastModifiedDateTime = @LastModifiedDateTime      
 WHERE      
  UnitId = @UnitId     
 */    
  /**/

GO

GRANT EXEC ON UpdateFunctionalLocationOperationalMode TO PUBLIC

GO
