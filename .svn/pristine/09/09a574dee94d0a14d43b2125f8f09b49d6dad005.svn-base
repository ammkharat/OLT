 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateLabAlertDefinition')
	BEGIN
		DROP  Procedure  UpdateLabAlertDefinition
	END

GO


CREATE Procedure [dbo].UpdateLabAlertDefinition
(
    @id bigint,
	@Name varchar (50),
    @FunctionalLocationID bigint,
    @Description varchar(3000),
    @TagID bigint,
	@MinimumNumberOfSamples int,
	@LabAlertTagQueryRangeType int,
	@LabAlertTagQueryRangeFromTime datetime,
	@LabAlertTagQueryRangeToTime datetime,
	@LabAlertTagQueryRangeFromDayOfWeek int = NULL,
	@LabAlertTagQueryRangeToDayOfWeek int = NULL,
	@LabAlertTagQueryRangeFromWeekOfMonth int = NULL,
	@LabAlertTagQueryRangeToWeekOfMonth int = NULL,
	@LabAlertTagQueryRangeFromDayOfMonth int = NULL,
	@LabAlertTagQueryRangeToDayOfMonth int = NULL,
    @LabAlertDefinitionStatusID bigint,
    @IsActive bit,
    @LastModifiedByUserId bigint, 
    @LastModifiedDateTime datetime	
)
AS

UPDATE LabAlertDefinition
SET	
	[Name] = @Name,
	[FunctionalLocationID] = @FunctionalLocationID,
	[Description] = @Description,
	[TagId] = @TagID,
	[MinimumNumberOfSamples] = @MinimumNumberOfSamples,
	[LabAlertTagQueryRangeType] = @LabAlertTagQueryRangeType,
	[LabAlertTagQueryRangeFromTime] = @LabAlertTagQueryRangeFromTime,
	[LabAlertTagQueryRangeToTime] = @LabAlertTagQueryRangeToTime,
	[LabAlertTagQueryRangeFromDayOfWeek] = @LabAlertTagQueryRangeFromDayOfWeek,
	[LabAlertTagQueryRangeToDayOfWeek] = @LabAlertTagQueryRangeToDayOfWeek,
	[LabAlertTagQueryRangeFromWeekOfMonth] = @LabAlertTagQueryRangeFromWeekOfMonth,
	[LabAlertTagQueryRangeToWeekOfMonth] = @LabAlertTagQueryRangeToWeekOfMonth,
	[LabAlertTagQueryRangeFromDayOfMonth] = @LabAlertTagQueryRangeFromDayOfMonth,
	[LabAlertTagQueryRangeToDayOfMonth] = @LabAlertTagQueryRangeToDayOfMonth,
	[LabAlertDefinitionStatusID] = @LabAlertDefinitionStatusID,
	[IsActive] = @IsActive,
	[LastModifiedByUserId] = @LastModifiedByUserId,
	[LastModifiedDateTime] = @LastModifiedDateTime
WHERE ID = @id
GO

GRANT EXEC ON UpdateLabAlertDefinition TO PUBLIC
GO