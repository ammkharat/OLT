IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertSummaryLog')
	BEGIN
		DROP  Procedure  InsertSummaryLog
	END

GO

CREATE Procedure [dbo].[InsertSummaryLog]
(
    @Id bigint Output,              
    @LastModifiedUserId bigint, 
    @LastModifiedDateTime datetime,     
    @LogDateTime datetime,    
	@CreatedDateTime datetime,
    @CreatedByUserId bigint,
	@CreatedByRoleId bigint,
    @InspectionFollowUp bit,
    @ProcessControlFollowUp bit, 
    @OperationsFollowUp bit, 
    @SupervisionFollowUp bit, 
    @OtherFollowUp bit,
    @EHSFollowUp bit,
    @CreationUserShiftPatternId bigint,             
	@WorkAssignmentId bigint = NULL,
	@RtfComments varchar(max),
	@PlainTextComments varchar(max),
	@DorComments varchar(max) = null,
	@RootLogId bigint = null,
	@ReplyToLogId bigint = null,
	@HasChildren bit = false,
	@DataSourceId int
)
AS

 INSERT INTO [SummaryLog]
(
    [LastModifiedUserId], 
    [LastModifiedDateTime],        
    [LogDateTime],        
    [CreatedDateTime],        
    [EHSFollowup],
    [ProcessControlFollowUp],
    [OperationsFollowUp],
    [SupervisionFollowUp],
    [InspectionFollowUp],
    [OtherFollowUp],
    [CreatedByUserId],
	[CreatedByRoleId],
    [Deleted],
    [CreationUserShiftPatternId],               	
	[WorkAssignmentId],
	[RtfComments],
	[PlainTextComments],
	[DorComments],
	[RootLogId],
	[ReplyToLogId],
	[HasChildren],
	[DataSourceId]
)
VALUES
(
    @LastModifiedUserId,
    @LastModifiedDateTime,    
    @LogDateTime,   
	@CreatedDateTime,
    @EHSFollowUp,
    @ProcessControlFollowUp,
    @OperationsFollowUp,
    @SupervisionFollowUp,
    @InspectionFollowUp,
    @OtherFollowUp,
    @CreatedByUserId,
	@CreatedByRoleId,
    0,
    @CreationUserShiftPatternId,    	
	@WorkAssignmentId,
	@RtfComments,
	@PlainTextComments,
	@DorComments,
	@RootLogId,
	@ReplyToLogId,
	@HasChildren,
	@DataSourceId
)

SET @Id = SCOPE_IDENTITY() 
GO