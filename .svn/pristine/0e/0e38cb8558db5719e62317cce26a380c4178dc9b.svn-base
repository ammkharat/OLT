 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateSummaryLog')
	BEGIN
		DROP  Procedure  UpdateSummaryLog
	END

GO

CREATE Procedure [dbo].[UpdateSummaryLog]
	(
	@Id bigint,	
	@LastModifiedUserId bigint, 
	@LastModifiedDateTime datetime, 	
	@LogDateTime datetime,	
	@CreatedDateTime datetime,	
	@CreatedByUserID bigint,
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
	@HasChildren bit,
	@DataSourceId int
	)
AS

UPDATE
    [SummaryLog]
SET
    LastModifiedUserId = @LastModifiedUserId,
    LastModifiedDateTime = @LastModifiedDateTime,
    LogDateTime = @LogDateTime,        
    CreatedDateTime = @CreatedDateTime,        
    EHSFollowup = @EHSFollowUp,
    ProcessControlFollowUp = @ProcessControlFollowUp,
    OperationsFollowUp = @OperationsFollowUp,
    SupervisionFollowUp = @SupervisionFollowUp,
    InspectionFollowUp = @InspectionFollowUp, 
    OtherFollowUp = @OtherFollowUp,
    CreatedByUserId = @CreatedByUserID,
    CreationUserShiftPatternId = @CreationUserShiftPatternId,              
	WorkAssignmentId = @WorkAssignmentId,
	RtfComments = @RtfComments,
	PlainTextComments = @PlainTextComments,
	DorComments = @DorComments,
	HasChildren = @HasChildren,
	DataSourceId = @DataSourceId
WHERE
    Id = @Id
GO

GRANT EXEC ON UpdateSummaryLog TO PUBLIC
GO