IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertActionItemDefinitionHistory')
	BEGIN
		DROP  Procedure  InsertActionItemDefinitionHistory
	END

GO

CREATE Procedure [dbo].[InsertActionItemDefinitionHistory]
	(
	@Id bigint,
	@Name varchar (80), --RITM0370841 : Modified by Vibhor changed size from 50 to 80
	@BusinessCategoryId bigint = NULL, 
	@ActionItemDefinitionStatusId bigint, 
	@Schedule varchar(300), 
	@RequiresApproval bit,
	@Active bit,
	@ResponseRequired bit,
	@SapOperationId bigint = NULL,
	@Description VARCHAR(MAX),
	@CopyResponseToLog bit, -- Vibhor
	@SourceId int,
	@OperationalModeId int,
	@PriorityId bigint,
	@LastModifiedUserId bigint, 
	@LastModifiedDateTime datetime,
	@FunctionalLocations varchar(MAX), 
	@DocumentLinks varchar(2000), 
	@TargetDefinitions varchar(200),
	@WorkAssignmentName varchar(40) = null,
	@CreateAnActionItemForEachFunctionalLocation bit,
	@GN75BId bigint = NULL ,  
	@GN75BId1 bigint = NULL ,  
	@GN75BId2 bigint = NULL  
	)
AS

INSERT INTO 
	[ActionItemDefinitionHistory]
	(
	[Id],
	[Name],
	[BusinessCategoryId], 
	[ActionItemDefinitionStatusId], 
	[Schedule], 
	[RequiresApproval],
	[Active],
	[ResponseRequired],
	[SapOperationId],
	[Description],
	[CopyResponseToLog],
	[SourceId], 
	[OperationalModeId],
	[PriorityId],
	[LastModifiedUserId],
	[LastModifiedDateTime],
	[FunctionalLocations],
	[DocumentLinks],
	[TargetDefinitions],
	[WorkAssignmentName],
	[CreateAnActionItemForEachFunctionalLocation],
	[Gn75BId],  
	[Gn75BId1],  
	[Gn75BId2] 
	)
VALUES
	(
	@Id,
	@Name,
	@BusinessCategoryId,
	@ActionItemDefinitionStatusId,
	@Schedule,
	@RequiresApproval,
	@Active,
	@ResponseRequired,
	@SapOperationId,
	@Description,
	@CopyResponseToLog,
	@SourceId, 
	@OperationalModeId,
	@PriorityId,
	@LastModifiedUserId, 
	@LastModifiedDateTime,
	@FunctionalLocations,
	@DocumentLinks,
	@TargetDefinitions,
	@WorkAssignmentName,
	@CreateAnActionItemForEachFunctionalLocation,
	@GN75BId,  
	@GN75BId1,  
	@GN75BId2 
	)
	
GRANT EXEC ON InsertActionItemDefinitionHistory TO PUBLIC
GO