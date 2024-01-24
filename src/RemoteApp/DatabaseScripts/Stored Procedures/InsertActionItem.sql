 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertActionItem')
	BEGIN
		DROP  Procedure  InsertActionItem
	END

GO

CREATE Procedure [dbo].[InsertActionItem]
	(
	@Id bigint Output,
	@ActionItemStatusId bigint, 
	@PriorityId bigint,
	@ResponseRequired bit,
	@Description VARCHAR(MAX),
	@CreatedByScheduleTypeId int,
	@StartDateTime datetime,
	@EndDateTime datetime,
	@ShiftAdjustedEndDateTime datetime,
	@SourceId int,
	@BusinessCategoryId bigint,
	@LastModifiedUserId bigint, 
	@LastModifiedDateTime datetime,
	@Name varchar(80), --RITM0370841 : Modified by Vibhor changed size from 50 to 80
	@CreatedByActionItemDefinitionId BIGINT,
	@VisGroupsStartingWith varchar(100),         
	@AssignmentId bigint = null,
	@FormGN75BId bigint = null,  
	@FormGN75BId1 bigint = null,  
	@FormGN75BId2 bigint = null,
	@FlocIDs varchar(max)
	)
AS

-- Ayman added to prevent action item duplicate
if not exists(
	select 1 from [ActionItem] AI 
	inner join ActionItemFunctionalLocation AIFL on AI.Id = AIFL.ActionItemId
	inner join IDSplitter(@FlocIDs) flocids on AIFL.FunctionalLocationId = flocids.ID
	where 
	AI.StartDateTime = @StartDateTime 
	and AI.EndDateTime = @EndDateTime 
	and AI.ActionItemStatusId = @ActionItemStatusId  
	and AI.Deleted=0 
	and AI.BusinessCategoryId = @BusinessCategoryId
	and AI.CreatedByActionItemDefinitionId = @CreatedByActionItemDefinitionId
)	


BEGIN
INSERT INTO 
	[ActionItem]
	(
	[ResponseRequired],
	[ActionItemStatusId], 
	[PriorityId],
	[Description],
	[CreatedByScheduleTypeId],
	[StartDateTime],
	[EndDateTime],
	[ShiftAdjustedEndDateTime],
	[LastModifiedUserId], 	
	[LastModifiedDateTime],
	[SourceId],
	[BusinessCategoryId],
	[Name],
	[CreatedByActionItemDefinitionId],
	[WorkAssignmentId],
	[FormGN75BId],  
	[FormGN75BId1],  
	[FormGN75BId2],
	[visibilityGroupIDs]
	)
VALUES
	(
	@ResponseRequired,
	@ActionItemStatusId,
	@PriorityId,
	@Description,
	@CreatedByScheduleTypeId,
	@StartDateTime,
	@EndDateTime,
	@ShiftAdjustedEndDateTime,
	@LastModifiedUserId, 
	@LastModifiedDateTime,
	@SourceId,
	@BusinessCategoryId,
	@Name,
	@CreatedByActionItemDefinitionId,
	@AssignmentId,
	@FormGN75BId,  
	@FormGN75BId1,  
	@FormGN75BId2,
	@VisGroupsStartingWith
	)
SET @Id= IDENT_CURRENT('actionitem')
END	
else
begin
	set @Id = 0
end


go
GRANT EXEC ON [InsertActionItem] TO PUBLIC
go


