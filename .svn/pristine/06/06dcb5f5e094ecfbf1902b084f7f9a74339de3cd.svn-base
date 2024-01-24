 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateTargetDefinition')
	BEGIN
		DROP  Procedure  UpdateTargetDefinition
	END

GO


CREATE Procedure [dbo].UpdateTargetDefinition

	(
		@id bigint,
		@Name varchar (50), 
		@NeverToExceedMax decimal(10,3)= NULL,
		@NeverToExceedMin decimal(10,3)= NULL,
		@MaxValue decimal(10,3)= NULL,
		@MinValue decimal(10,3)= NULL,
		@NeverToExceedMaxFrequency int= NULL,
		@NeverToExceedMinFrequency int= NULL,
		@MaxValueFrequency int= NULL,
		@MinValueFrequency int= NULL,
		@TargetValueTypeId bigint,
		@TargetDefinitionValue decimal(10,3)= NULL,
		@GapUnitValue decimal(10,3)= NULL,
		@TargetDefinitionStatusID bigint,
		@PriorityId bigint,
		@TargetCategoryID bigint,
		@TagID bigint,
		@FunctionalLocationID bigint,
		@UpdatedUserId bigint,
		@UpdatedDate datetime,
		@GenerateActionItem bit,
		@ScheduleId bigint,
		@Description VARCHAR(MAX) = NULL,
		@AlertRequired bit,
		@RequiresApproval bit,
		@RequiresResponseWhenAlerted bit,
		@IsActive bit,
		@OperationalModeId int,
		@PreApprovedMin decimal(9,2) = NULL,
		@PreApprovedMax decimal(9,2) = NULL,
		@PreApprovedNeverToExceedMin decimal(9,2) = NULL,
		@PreApprovedNeverToExceedMax decimal(9,2) = NULL,
		@WorkAssignmentId bigint
	)
AS

UPDATE TargetDefinition
SET	
	[Name] = @Name,
	[NeverToExceedMax] = @NeverToExceedMax, 
	[NeverToExceedMin] =	@NeverToExceedMin,
	[MaxValue] =	@MaxValue,
	[MinValue] =	@MinValue,
	[NeverToExceedMaxFrequency] =	@NeverToExceedMaxFrequency,
	[NeverToExceedMinFrequency] =	@NeverToExceedMinFrequency,
	[MaxValueFrequency] =	@MaxValueFrequency,
	[MinValueFrequency] =	@MinValueFrequency,
	[TargetValueTypeId] = @TargetValueTypeId,
	[TargetDefinitionValue] =	@TargetDefinitionValue,
	[GapUnitValue] =	@GapUnitValue,
	[TargetDefinitionStatusID] =	@TargetDefinitionStatusID,
	[PriorityId] = @PriorityId,
	[TargetCategoryID] =	@TargetCategoryID,
	[TagID] =	@TagID,
	[FunctionalLocationID] =	@FunctionalLocationID,
	[LastModifiedUserId] =	@UpdatedUserId,
	[LastModifiedDateTime] =	@UpdatedDate,
	[ScheduleId] = @ScheduleId,
	[Description]=@Description,
	[GenerateActionItem]=@GenerateActionItem, 
	[AlertRequired]=@AlertRequired,
	[RequiresApproval] = @RequiresApproval,
	[RequiresResponseWhenAlerted] = @RequiresResponseWhenAlerted,
	[IsActive] = @IsActive,
	[OperationalModeId] = @OperationalModeId,
	[PreApprovedMin] = @PreApprovedMin,
	[PreApprovedMax] = @PreApprovedMax,
	[PreApprovedNeverToExceedMin] = @PreApprovedNeverToExceedMin,
	[PreApprovedNeverToExceedMax] = @PreApprovedNeverToExceedMax,
	[WorkAssignmentId] = @WorkAssignmentId
WHERE ID = @id
GO

GRANT EXEC ON UpdateTargetDefinition TO PUBLIC
GO