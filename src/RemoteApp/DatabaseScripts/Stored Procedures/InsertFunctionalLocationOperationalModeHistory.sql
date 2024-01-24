IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE Id = OBJECT_ID(N'[dbo].[InsertFunctionalLocationOperationalModeHistory]') AND OBJECTPROPERTY(Id, N'IsProcedure') = 1 )
DROP PROCEDURE [dbo].[InsertFunctionalLocationOperationalModeHistory]
GO

CREATE PROCEDURE [dbo].[InsertFunctionalLocationOperationalModeHistory]    
(    
    @Id BIGINT OUTPUT,    
    @UnitId BIGINT,    
    @OperationalModeId BIGINT,    
    @AvailabilityReasonId BIGINT,    
    @LastModifiedUserId BIGINT,    
    @LastModifiedDateTime DATETIME    
)    
AS    
 If Exists( SELECT 1 from FunctionalLocationOperationalMode where (UnitId in (select AncestorId from FunctionalLocationAncestor where Id = @UnitId)) And (OperationalModeId<>0))  
  Begin  
  Set @Id = 0;  
  return;  
  End  
INSERT INTO [FunctionalLocationOperationalModeHistory]    
(    
    UnitId,    
    OperationalModeId,    
    AvailabilityReasonId,    
    LastModifiedUserId,    
    LastModifiedDateTime    
)    
select  UnitId , @OperationalModeId,    
    @AvailabilityReasonId,@LastModifiedUserId,    
    @LastModifiedDateTime from FunctionalLocationOperationalMode    
 WHERE    
  (UnitId in (Select Id from FunctionalLocationAncestor where AncestorId = @UnitId)) OR  (UnitId = @UnitId)     
      
SET @Id = SCOPE_IDENTITY()    
  
 /*   
CREATE PROCEDURE [dbo].[InsertFunctionalLocationOperationalModeHistory]    
(    
    @Id BIGINT OUTPUT,    
    @UnitId BIGINT,    
    @OperationalModeId BIGINT,    
    @AvailabilityReasonId BIGINT,    
    @LastModifiedUserId BIGINT,    
    @LastModifiedDateTime DATETIME    
)    
AS    
INSERT INTO [FunctionalLocationOperationalModeHistory]    
(    
    UnitId,    
    OperationalModeId,    
    AvailabilityReasonId,    
    LastModifiedUserId,    
    LastModifiedDateTime    
)    
VALUES    
(    
    @UnitId,    
    @OperationalModeId,    
    @AvailabilityReasonId,    
    @LastModifiedUserId,    
    @LastModifiedDateTime    
)    
SET @Id = SCOPE_IDENTITY()    
*/
GO

GRANT EXEC ON [InsertFunctionalLocationOperationalModeHistory] TO PUBLIC
GO