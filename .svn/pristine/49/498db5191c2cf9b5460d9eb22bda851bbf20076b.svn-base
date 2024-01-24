 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateActionItem')
	BEGIN
		DROP  Procedure  UpdateActionItem
	END

GO

CREATE Procedure [dbo].[UpdateActionItem]
	(
	@Id bigint,
	@ActionItemStatusId bigint, 
	@ResponseRequired bit,
	@Description varchar(MAX),
	@StartDateTime datetime,
	@EndDateTime datetime,
	@LastModifiedUserId bigint, 
	@LastModifiedDateTime datetime,
	@SourceId int,
	@BusinessCategoryId bigint,
	@Name varchar(80), --RITM0370841 : Modified by Vibhor changed size from 50 to 80
	@PreviousActionItemStatusId bigint = NULL,
	@StatusModifiedUserId bigint = NULL,
	@StatusModifiedDateTime datetime = NULL,
	@CreatedByActionItemDefinitionId BIGINT,
	@AssignmentId bigint = NULL,
	@FormGN75BId bigint = NULL,  
	@FormGN75BId1 bigint = NULL,  
	@FormGN75BId2 bigint = NULL,
	@VisGroupsStartingWith varchar(100),
	@flocIDs varchar(max)

	)
AS

UPDATE
	[ActionItem]	
	SET 
	[ActionItemStatusId] = @ActionItemStatusId,
	[ResponseRequired] = @ResponseRequired,
	[Description] = @Description,
	[StartDateTime] =  @StartDateTime,
	[EndDateTime] = @EndDateTime,
	[LastModifiedUserId] = @LastModifiedUserId, 
	[LastModifiedDateTime] = @LastModifiedDateTime,
	[SourceId] = @SourceId,
	[BusinessCategoryId] = @BusinessCategoryId,
	[Deleted] = 0,
	[Name] = @Name,
	[PreviousActionItemStatusId] = @PreviousActionItemStatusId,
	[StatusModifiedUserId] = @StatusModifiedUserId,
	[StatusModifiedDateTime] = @StatusModifiedDateTime,
	[CreatedByActionItemDefinitionId] = @CreatedByActionItemDefinitionId,
	[WorkAssignmentId] = @AssignmentId,
	[FormGN75BId] = @FormGN75BId,  
	[FormGN75BId1] = @FormGN75BId1,  
	[FormGN75BId2] = @FormGN75BId2  
WHERE Id = @Id
GO


GRANT EXEC ON UpdateActionItem TO PUBLIC

GO


 