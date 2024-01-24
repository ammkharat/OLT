if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertLogDefinition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertLogDefinition]
GO

CREATE Procedure [dbo].[InsertLogDefinition]
	(
	@Id bigint Output,
	@ScheduleId bigint,
	@CreatedDateTime datetime,
	@CreatedBy bigint,
	@InspectionFollowUp bit,
	@ProcessControlFollowUp bit, 
	@OperationsFollowUp bit, 
	@SupervisionFollowUp bit, 
	@EHSFollowUp bit,
	@OtherFollowUp bit,
	@IsOperatingEngineerLog bit,
	@CreatedByRoleId [BIGINT],
	@LastModifiedUserId bigint, 
	@LastModifiedDateTime datetime,	
	@LogType tinyint,
	@WorkAssignmentId bigint = NULL,
	@CreateALogForEachFunctionalLocation bit,
	@RtfComments varchar(max),
	@PlainTextComments varchar(max),
	@Active bit
	)
AS

INSERT INTO [LogDefinition]
(
    [CreatedDateTime],
    [ScheduleId],
    [EHSFollowup],
    [ProcessControlFollowUp],
    [OperationsFollowUp],
    [SupervisionFollowUp],
    [InspectionFollowUp],
    [OtherFollowUp],
    [IsOperatingEngineerLog],
	[CreatedByRoleId],
    [CreatedBy],
    [Deleted],
    [LastModifiedUserId],
    [LastModifiedDateTime],    
    [LogType],
	[WorkAssignmentId],
	[CreateALogForEachFunctionalLocation],
	[RtfComments],
	[PlainTextComments],
	[Active]
)
VALUES
(
    @CreatedDateTime,
    @ScheduleId,
    @EHSFollowUp,
    @ProcessControlFollowUp,
    @OperationsFollowUp,
    @SupervisionFollowUp,
    @InspectionFollowUp,
    @OtherFollowUp,
    @IsOperatingEngineerLog,
	@CreatedByRoleId,
    @CreatedBy,
    0,
    @LastModifiedUserId,
    @LastModifiedDateTime,    
    @LogType,
	@WorkAssignmentId,
	@CreateALogForEachFunctionalLocation,
	@RtfComments,
	@PlainTextComments,
	@Active
)

SET @Id= SCOPE_IDENTITY() 
GO
GRANT EXEC ON [InsertLogDefinition] TO PUBLIC
GO