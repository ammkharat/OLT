 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateLog')
	BEGIN
		DROP  Procedure  UpdateLog
	END

GO

CREATE Procedure [dbo].[UpdateLog]
	(
	@Id bigint,
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
	@CreatedByRoleId [BIGINT],
    @LogType tinyint,
    @RecommendForShiftSummary bit,
	@WorkAssignmentId bigint = NULL,	
	@RtfComments varchar(max),
	@PlainTextComments varchar(max)
	)
AS

UPDATE
    [Log]
SET
    LastModifiedUserId = @LastModifiedUserId,
    LastModifiedDateTime = @LastModifiedDateTime,
	CreatedDateTime = @CreatedDateTime,
    LogDateTime = @LogDateTime,    
    EHSFollowup = @EHSFollowUp,
    ProcessControlFollowUp = @ProcessControlFollowUp,
    OperationsFollowUp = @OperationsFollowUp,
    SupervisionFollowUp = @SupervisionFollowUp,
    InspectionFollowUp = @InspectionFollowUp, 
    OtherFollowUp = @OtherFollowUp,
    UserId = @UserID,
    CreationUserShiftPatternId = @CreationUserShiftPatternId,
    ReplyToLogId = @ReplyToLogId, 
    RootLogId = @RootLogId,
	HasChildren = @HasChildren,
    LogDefinitionId = @LogDefinitionId,
    SourceId = @SourceId,
    IsOperatingEngineerLog = @IsOperatingEngineerLog,
	CreatedByRoleId = @CreatedByRoleId,
    LogType = @LogType,
    RecommendForShiftSummary = @RecommendForShiftSummary,
	WorkAssignmentId = @WorkAssignmentId,	
	RtfComments = @RtfComments,
	PlainTextComments = @PlainTextComments
WHERE
    Id = @Id
GO

GRANT EXEC ON UpdateLog TO PUBLIC
GO