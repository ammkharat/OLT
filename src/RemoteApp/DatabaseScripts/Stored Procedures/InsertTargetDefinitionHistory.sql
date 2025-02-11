IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertTargetDefinitionHistory')
	BEGIN
		DROP  Procedure  InsertTargetDefinitionHistory
	END

GO

CREATE Procedure dbo.InsertTargetDefinitionHistory
    (
    @Id bigint,
    @Name varchar (50),
    @UpdatedUserId bigint, 
    @UpdatedDate datetime, 
    @NeverToExceedMax decimal(10,3) = NULL, 
    @NeverToExceedMin decimal(10,3) = NULL, 
    @PreApprovedNeverToExceedMin decimal(10,3) = NULL,
    @PreApprovedNeverToExceedMax decimal(10,3) = NULL,
    @NeverToExceedMaxFrequency bigint = NULL, 
    @NeverToExceedMinFrequency bigint = NULL,
    @MaxValue decimal(10,3) = NULL, 
    @MinValue decimal(10,3) = NULL, 
    @PreApprovedMin decimal(9,2) = NULL,
    @PreApprovedMax decimal(9,2) = NULL,
    @MaxValueFrequency bigint= NULL, 
    @MinValueFrequency bigint= NULL, 
    @TargetDefinitionValue varchar(50) = NULL, 
    @GapUnitValue decimal(9,3) = NULL, 
    @TargetDefinitionStatusID bigint,
    @TargetCategoryID bigint,
    @TagID bigint,
    @FunctionalLocationId bigint,
    @Schedule varchar(300),
    @GenerateActionItem bit,
    @Description varchar(MAX),
    @AlertRequired bit,
    @RequiresApproval bit,
    @RequiresResponseWhenAlerted bit,
    @IsActive bit,
	@OperationalModeId int,
	@PriorityId bigint,
	@DocumentLinks varchar(300) = NULL,
	@AssociatedTargets VARCHAR(200) = NULL,
	@ReadWriteConfiguration VARCHAR(300),
	@WorkAssignmentName varchar(40) = NULL
    )
AS

INSERT INTO TargetDefinitionHistory
(
    Id,
    [Name],
    LastModifiedUserId,
    LastModifiedDateTime,
    NeverToExceedMax,
    NeverToExceedMin,
    PreApprovedNeverToExceedMin,
    PreApprovedNeverToExceedMax,
    NeverToExceedMaxFrequency,
    NeverToExceedMinFrequency,
    MaxValue,
    MinValue,
    PreApprovedMin,
    PreApprovedMax,
    MaxValueFrequency,
    MinValueFrequency,
    TargetDefinitionValue,
    GapUnitValue,
    TargetDefinitionStatusID,
    TagID,
    FunctionalLocationId,
    Schedule,
    Description,
    TargetCategoryID,
    GenerateActionItem,
    AlertRequired,
    RequiresApproval,
    RequiresResponseWhenAlerted,
    IsActive,
    OperationalModeId,
    PriorityId,
    DocumentLinks,
    AssociatedTargets,
	ReadWriteConfiguration,
	WorkAssignmentName
)
VALUES
(
    @Id,
    @Name,
    @UpdatedUserId,
    @UpdatedDate,
    @NeverToExceedMax,
    @NeverToExceedMin,
    @PreApprovedNeverToExceedMin,
    @PreApprovedNeverToExceedMax,
    @NeverToExceedMaxFrequency,
    @NeverToExceedMinFrequency,
    @MaxValue,
    @MinValue,
    @PreApprovedMin,
    @PreApprovedMax,
    @MaxValueFrequency,
    @MinValueFrequency,
    @TargetDefinitionValue,
    @GapUnitValue,
    @TargetDefinitionStatusID,
    @TagID,
    @FunctionalLocationId,
    @Schedule,
    @Description,
    @TargetCategoryID,
    @GenerateActionItem,
    @AlertRequired,
    @RequiresApproval,
    @RequiresResponseWhenAlerted,
    @IsActive,
    @OperationalModeId,
    @PriorityId,
    @DocumentLinks,
    @AssociatedTargets,
	@ReadWriteConfiguration,
	@WorkAssignmentName
)
GO

