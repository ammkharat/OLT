if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertLabAlertDefinition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertLabAlertDefinition]
GO

CREATE Procedure [dbo].[InsertLabAlertDefinition]
    (
    @Id bigint Output,
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
	@ScheduleId bigint,
    @LabAlertDefinitionStatusID bigint,
    @IsActive bit,    
    @LastModifiedByUserId bigint, 
    @LastModifiedDateTime datetime,
    @CreatedByUserId bigint, 
    @CreatedDateTime datetime
    )
AS

INSERT INTO LabAlertDefinition
(
    [Name],
    FunctionalLocationID,
    [Description],
    TagID,
	MinimumNumberOfSamples,
	LabAlertTagQueryRangeType,
	LabAlertTagQueryRangeFromTime,
	LabAlertTagQueryRangeToTime,
	LabAlertTagQueryRangeFromDayOfWeek,
	LabAlertTagQueryRangeToDayOfWeek,
	LabAlertTagQueryRangeFromWeekOfMonth,
	LabAlertTagQueryRangeToWeekOfMonth,
	LabAlertTagQueryRangeFromDayOfMonth,
	LabAlertTagQueryRangeToDayOfMonth,
	ScheduleId,
    LabAlertDefinitionStatusID,
    IsActive,    
    LastModifiedByUserId,
    LastModifiedDateTime,
    CreatedByUserId,
    CreatedDateTime,
	Deleted
)
VALUES
(
    @Name,
    @FunctionalLocationID,
    @Description,
    @TagID,
	@MinimumNumberOfSamples,
	@LabAlertTagQueryRangeType,
	@LabAlertTagQueryRangeFromTime,
	@LabAlertTagQueryRangeToTime,
	@LabAlertTagQueryRangeFromDayOfWeek,
	@LabAlertTagQueryRangeToDayOfWeek,
	@LabAlertTagQueryRangeFromWeekOfMonth,
	@LabAlertTagQueryRangeToWeekOfMonth,
	@LabAlertTagQueryRangeFromDayOfMonth,
	@LabAlertTagQueryRangeToDayOfMonth,
	@ScheduleId,
    @LabAlertDefinitionStatusID,
    @IsActive,    
    @LastModifiedByUserId, 
    @LastModifiedDateTime,
	@CreatedByUserId,
    @CreatedDateTime,
	0
)
SET @Id= SCOPE_IDENTITY() 


GRANT EXEC ON [InsertLabAlertDefinition] TO PUBLIC
GO
