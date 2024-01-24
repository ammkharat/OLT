IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertLog')
	BEGIN
		DROP  Procedure  InsertLog
	END

GO

CREATE Procedure [dbo].[InsertLog]
(
    @Id bigint Output,
    @RootLogId bigint,
    @ReplyToLogId bigint,
	@HasChildren bit,
    @SourceId bigint,
    @LogDefinitionId bigint,
    @LastModifiedUserId bigint, 
    @LastModifiedDateTime datetime, 
	@CreatedDateTime datetime,
    @LogDateTime datetime,    
    @UserID bigint,
    @InspectionFollowUp bit,
    @ProcessControlFollowUp bit, 
    @OperationsFollowUp bit, 
    @SupervisionFollowUp bit, 
    @OtherFollowUp bit,
    @EHSFollowUp bit,
    @CreationUserShiftPatternId bigint,
    @IsOperatingEngineerLog bit,
	@CreatedByRoleId [bigint],
    @LogType tinyint,
    @RecommendForShiftSummary bit,
	@WorkAssignmentId bigint = NULL,	
	@RtfComments varchar(max),
	@PlainTextComments varchar(max)
)
AS

 INSERT INTO [Log]
(
    [LastModifiedUserId], 
    [LastModifiedDateTime],
	[CreatedDateTime],
    [RootLogId],
    [ReplyToLogId],
	[HasChildren],
    [SourceId],
    [LogDefinitionId],
    [LogDateTime],    
    [EHSFollowup],
    [ProcessControlFollowUp],
    [OperationsFollowUp],
    [SupervisionFollowUp],
    [InspectionFollowUp],
    [OtherFollowUp],
    [UserId],
    [Deleted],
    [CreationUserShiftPatternId],
    [IsOperatingEngineerLog],
	[CreatedByRoleId],
    [LogType],
    [RecommendForShiftSummary],
	[WorkAssignmentId],	
	[RtfComments],
	[PlainTextComments]
)
VALUES
(
    @LastModifiedUserId,
    @LastModifiedDateTime,
	@CreatedDateTime,
    @RootLogId,
    @ReplyToLogId,
	@HasChildren,
    @SourceId,
    @LogDefinitionId,
    @LogDateTime,    
    @EHSFollowUp,
    @ProcessControlFollowUp,
    @OperationsFollowUp,
    @SupervisionFollowUp,
    @InspectionFollowUp,
    @OtherFollowUp,
    @UserID,
    0,
    @CreationUserShiftPatternId,
    @IsOperatingEngineerLog,
	@CreatedByRoleId,
    @LogType,
    @RecommendForShiftSummary,
	@WorkAssignmentId,	
	@RtfComments,
	@PlainTextComments
)

SET @Id = SCOPE_IDENTITY()

GO
