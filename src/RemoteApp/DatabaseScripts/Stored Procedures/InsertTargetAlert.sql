if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertTargetAlert]') and OBJECTPROPERTY(id,N'IsProcedure') = 1)
drop procedure [dbo].[InsertTargetAlert]
GO

CREATE PROCEDURE [dbo].[InsertTargetAlert]
(
    @Id bigint Output,
    @TargetDefinitionID bigint,
    @TargetName VARCHAR(30),
    @NeverToExceedMax DECIMAL(10,3)= NULL,
    @NeverToExceedMin DECIMAL(10,3)= NULL,
    @NeverToExceedMaxFrequency bigint= NULL,
    @NeverToExceedMinFrequency bigint= NULL,
    @MaxValue DECIMAL(10,3)= NULL,
    @MinValue DECIMAL(10,3)= NULL,
    @MaxValueFrequency bigint= NULL,
    @MinValueFrequency bigint= NULL,
    @TargetValueTypeId BIGINT,
    @TargetAlertValue DECIMAL(10,3)= NULL,
    @GapUnitValue DECIMAL(10,3)= NULL,
    @TargetAlertStatusID bigint,
    @PriorityId BIGINT,
    @ExceedingBoundaries bit,
    @TagID bigint,
    @FunctionalLocationID bigint,
    @LastModifiedUserId bigint = NULL,
    @LastModifiedDateTime DATETIME,
    @CreatedDateTime DATETIME,
    @TargetCategoryId bigint,
    @CreatedByScheduleTypeId INT,
    @Description varchar(MAX),
    @ActualValue DECIMAL(10, 3)= NULL,
    @OriginalExceedingValue DECIMAL(10, 3) = NULL,
    @RequiresResponse bit,	
	@TypeOfViolationStatusId int,
	@LastViolatedDateTime datetime,
	@MaxAtEvaluation decimal(10,3) = null,
	@MinAtEvaluation decimal(10,3) = null,
	@NTEMaxAtEvaluation decimal(10,3) = null,
	@NTEMinAtEvaluation decimal(10,3) = null,
	@ActualValueAtEvaluation decimal(10,3) = null
)
AS

INSERT INTO [dbo].[TargetAlert]
(
    [TargetName],
    [TargetDefinitionId],
    [NeverToExceedMax],
    [NeverToExceedMin],
    [MaxValue],
    [MinValue],
    [NeverToExceedMaxFrequency],
    [NeverToExceedMinFrequency],
    [MaxValueFrequency],
    [MinValueFrequency],
    [TargetValueTypeId],
    [TargetAlertValue],
    [GapUnitValue],
    [TargetAlertStatusID],
    [PriorityId],
    [ExceedingBoundaries],
    [TagID],
    [FunctionalLocationID],
    [LastModifiedUserId],
    [LastModifiedDateTime],
    [CreatedDateTime],
    [TargetCategoryId],
    [CreatedByScheduleTypeId],
    [Description],
    [ActualValue],
    [OriginalExceedingValue],
    [RequiresResponse],
	[TypeOfViolationStatusId],
	[LastViolatedDateTime],
	[MaxAtEvaluation],
	[MinAtEvaluation],
	[NTEMaxAtEvaluation],
	[NTEMinAtEvaluation],
	[ActualValueAtEvaluation]
)
VALUES
(
    @TargetName,
    @TargetDefinitionId,
    @NeverToExceedMax,
    @NeverToExceedMin,
    @MaxValue,
    @MinValue,
    @NeverToExceedMaxFrequency,
    @NeverToExceedMinFrequency,
    @MaxValueFrequency,
    @MinValueFrequency,
    @TargetValueTypeId,
    @TargetAlertValue,
    @GapUnitValue,
    @TargetAlertStatusID,
    @PriorityId,
    @ExceedingBoundaries,
    @TagID,
    @FunctionalLocationID,
    @LastModifiedUserId,
    @LastModifiedDateTime,
    @CreatedDateTime,
    @TargetCategoryId,
    @CreatedByScheduleTypeId,
    @Description,
    @ActualValue,
    @OriginalExceedingValue,
    @RequiresResponse,
	@TypeOfViolationStatusId,
	@LastViolatedDateTime,
	@MaxAtEvaluation,
	@MinAtEvaluation,
	@NTEMaxAtEvaluation,
	@NTEMinAtEvaluation,
	@ActualValueAtEvaluation	
)

SET @Id= SCOPE_IDENTITY()
GO 

GRANT EXEC ON [InsertTargetAlert] TO PUBLIC
GO