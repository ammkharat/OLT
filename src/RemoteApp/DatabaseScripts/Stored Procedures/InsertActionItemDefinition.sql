  if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertActionItemDefinition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertActionItemDefinition]
Go
CREATE Procedure [dbo].[InsertActionItemDefinition]  
 (  
 @Id bigint Output,  
 @workpermitId bigint=NULL,
 @Name varchar (80), --RITM0370841 : Modified by Vibhor changed size from 50 to 80  
 @BusinessCategoryId bigint = NULL,   
 @ActionItemDefinitionStatusId bigint,   
 @PriorityId bigint,   
 @ScheduleId bigint,   
 @RequiresApproval bit,  
 @Active bit,  
 @CopyResponseToLog bit,  
 @ResponseRequired bit,  
 @SapOperationId bigint = NULL,  
 @Description VARCHAR(MAX),  
 @SourceId int,  
 @OperationalModeId int,   
 @LastModifiedUserId bigint,   
 @LastModifiedDateTime datetime,  
 @CreatedByUserId bigint,   
 @CreatedDateTime datetime,  
 @AssignmentId bigint = NULL,  
 @CreateAnActionItemForEachFunctionalLocation bit,  
 @GN75BId BIGINT = NULL,  
 @GN75BId1 BIGINT = NULL,    
 @GN75BId2 BIGINT = NULL,   
 @visGroupsStartingWith varchar(100)  
 )  
AS  
  
INSERT INTO   
 [ActionItemDefinition]  
 ( 
 [WorkPermitId], 
 [Name],  
 [BusinessCategoryId],   
 [ActionItemDefinitionStatusId],   
 [PriorityId],  
 [ScheduleId],   
 [RequiresApproval],  
 [Active],  
 [CopyResponseToLog],  
 [ResponseRequired],  
 [SapOperationId],  
 [Description],  
 [SourceId],   
 [OperationalModeId],  
 [LastModifiedUserId],    
 [LastModifiedDateTime],  
 [CreatedByUserId],    
 [CreatedDateTime],  
 [WorkAssignmentId],  
 [CreateAnActionItemForEachFunctionalLocation],  
 [GN75BId],    
 [GN75BId1],    
 [GN75BId2],  
 [VisibilityGroupIDs]  
 )  
VALUES  
 (  
 @workpermitId,
 @Name,   
 @BusinessCategoryId,   
 @ActionItemDefinitionStatusId,   
 @PriorityId,  
 @ScheduleId,    
 @RequiresApproval,  
 @Active,  
 @CopyResponseToLog ,  
 @ResponseRequired,  
 @SapOperationId,  
 @Description,  
 @SourceId,   
 @OperationalModeId,  
 @LastModifiedUserId,   
 @LastModifiedDateTime,  
 @CreatedByUserId,  
 @CreatedDateTime,  
 @AssignmentId,  
 @CreateAnActionItemForEachFunctionalLocation,  
 @GN75BId,   
 @GN75BId1,  
 @GN75BId2,  
 @visGroupsStartingWith  
 )  
   
SET @Id= SCOPE_IDENTITY()

Go
GRANT EXEC ON InsertActionItemDefinition TO PUBLIC
         