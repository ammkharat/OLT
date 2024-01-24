 if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertTargetDefinition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertTargetDefinition]
GO

CREATE Procedure [dbo].[InsertTargetDefinition]
    (
    @Id bigint Output,
    @Name varchar (50),
    @UpdatedUserId bigint, 
    @UpdatedDate datetime, 
    @NeverToExceedMax decimal(10,3)= NULL, 
    @NeverToExceedMin decimal(10,3)= NULL, 
    @NeverToExceedMaxFrequency bigint= NULL, 
    @NeverToExceedMinFrequency bigint= NULL,
    @MaxValue decimal(10,3)= NULL, 
    @MinValue decimal(10,3)= NULL, 
    @MaxValueFrequency bigint= NULL, 
    @MinValueFrequency bigint= NULL, 
    @TargetValueTypeId bigint,
    @TargetDefinitionValue decimal(10,3)= NULL, 
    @GapUnitValue decimal(10,3)= NULL, 
    @TargetDefinitionStatusID bigint,
	@PriorityId bigint,     
    @TargetCategoryID bigint,
    @TagID bigint,
    @FunctionalLocationID bigint,
    @ScheduleID bigint,
    @GenerateActionItem bit,
    @Description varchar(3000),
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

INSERT INTO TargetDefinition
(
    [Name],
    LastModifiedUserId,
    LastModifiedDateTime,
    NeverToExceedMax,
    NeverToExceedMin,
    NeverToExceedMaxFrequency,
    NeverToExceedMinFrequency,
    MaxValue,
    MinValue,
    MaxValueFrequency,
    MinValueFrequency,
    TargetValueTypeId,
    TargetDefinitionValue,
    GapUnitValue,
    TargetDefinitionStatusID,
    PriorityId,
    TagID,
    FunctionalLocationID,
    Deleted,
    ScheduleId,
    Description,
    TargetCategoryID,
    GenerateActionItem,
    AlertRequired,
    RequiresApproval,
    RequiresResponseWhenAlerted,
    IsActive,
    OperationalModeId,
    PreApprovedMin,
    PreApprovedMax,
    PreApprovedNeverToExceedMin,
    PreApprovedNeverToExceedMax,
	WorkAssignmentId
)
VALUES
(
    @Name,
    @UpdatedUserId,
    @UpdatedDate,
    @NeverToExceedMax,
    @NeverToExceedMin,
    @NeverToExceedMaxFrequency,
    @NeverToExceedMinFrequency,
    @MaxValue,
    @MinValue,
    @MaxValueFrequency,
    @MinValueFrequency,
    @TargetValueTypeId,
    @TargetDefinitionValue,
    @GapUnitValue,
    @TargetDefinitionStatusID,
    @PriorityId,
    @TagID,
    @FunctionalLocationID,
    0,
    @ScheduleID,
    @Description,
    @TargetCategoryID,
    @GenerateActionItem,
    @AlertRequired,
    @RequiresApproval,
    @RequiresResponseWhenAlerted,
    @IsActive,
    @OperationalModeId,
    @PreApprovedMin,
    @PreApprovedMax,
    @PreApprovedNeverToExceedMin,
    @PreApprovedNeverToExceedMax,
	@WorkAssignmentId
)
SET @Id= SCOPE_IDENTITY() 
GO

GRANT EXEC ON [InsertTargetDefinition] TO PUBLIC
GO