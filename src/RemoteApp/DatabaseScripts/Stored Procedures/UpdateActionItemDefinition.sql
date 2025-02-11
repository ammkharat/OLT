if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateActionItemDefinition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateActionItemDefinition]
Go  
CREATE Procedure [dbo].[UpdateActionItemDefinition]  
 (  
 @Id bigint,  
 @workpermitId bigint=NULL,  
 @Name varchar(80), --RITM0370841 : Modified by Vibhor changed size from 50 to 80  
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
 @AssignmentId bigint = NULL,  
 @CreateAnActionItemForEachFunctionalLocation bit,  
 @GN75BId BIGINT = NULL,    
 @GN75BId1 BIGINT = NULL ,    
 @GN75BId2 BIGINT = NULL ,  
@VisGroupsStartingWith varchar(100)   
 )  
AS  
  
UPDATE  
 [ActionItemDefinition]  
 SET   
 [WorkPermitId]=@workpermitId,   
 [Name] = @Name,  
 [BusinessCategoryId] = @BusinessCategoryId,  
 [ActionItemDefinitionStatusId] = @ActionItemDefinitionStatusId,  
 [PriorityId] = @PriorityId,  
 [ScheduleId] = @ScheduleId,  
 [RequiresApproval] = @RequiresApproval,  
 [Active] = @Active,  
 [CopyResponseToLog] = @CopyResponseToLog ,  
 [ResponseRequired] = @ResponseRequired,  
 [SapOperationId] = @SapOperationId,  
 [Description] = @Description,  
 [SourceId] = @SourceId,  
 [OperationalModeId] = @OperationalModeId,  
 [LastModifiedUserId] = @LastModifiedUserId,   
 [LastModifiedDateTime] = @LastModifiedDateTime,  
 [WorkAssignmentId] = @AssignmentId,  
 [CreateAnActionItemForEachFunctionalLocation] = @CreateAnActionItemForEachFunctionalLocation,  
 [GN75BId] = @GN75BId,  
 [GN75BId1] = @GN75BId1 ,    
 [GN75BId2] = @GN75BId2       
WHERE Id = @Id  

 GRANT EXEC ON UpdateActionItemDefinition TO PUBLIC 