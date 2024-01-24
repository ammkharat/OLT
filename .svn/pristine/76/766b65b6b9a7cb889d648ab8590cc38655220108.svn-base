IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertLogHistory')
	BEGIN
		DROP  Procedure  InsertLogHistory
	END
GO

CREATE Procedure [dbo].[InsertLogHistory]
(
 	@LogHistoryId bigint Output,
    @Id bigint Output,
    @LastModifiedUserId bigint, 
    @LastModifiedDateTime datetime, 
    @FunctionalLocations varchar(max),
    @InspectionFollowUp bit,
    @ProcessControlFollowUp bit, 
    @OperationsFollowUp bit, 
    @SupervisionFollowUp bit, 
    @OtherFollowUp bit,
    @EHSFollowUp bit,
	@IsOperatingEngineerLog bit,
    @DocumentLinks varchar(1000) = NULL,
    @RecommendForShiftSummary bit,
    @ActualLoggedDateTime datetime = NULL,
	@PlainTextComments varchar(max)
)
AS

INSERT INTO [LogHistory]
(
    [Id],
    [LastModifiedUserId], 
    [LastModifiedDateTime], 
    [FunctionalLocations],
    [EHSFollowup],
    [ProcessControlFollowUp],
    [OperationsFollowUp],
    [SupervisionFollowUp],
    [InspectionFollowUp],
    [OtherFollowUp],
    [IsOperatingEngineerLog],
    [DocumentLinks],
	[RecommendForShiftSummary],
	[ActualLoggedDateTime],
	[PlainTextComments]
)
VALUES
(
    @Id,
    @LastModifiedUserId,
    @LastModifiedDateTime,
    @FunctionalLocations,
    @EHSFollowUp,
    @ProcessControlFollowUp,
    @OperationsFollowUp,
    @SupervisionFollowUp,
    @InspectionFollowUp,
    @OtherFollowUp,
    @IsOperatingEngineerLog,
    @DocumentLinks,
	@RecommendForShiftSummary,
	@ActualLoggedDateTime,
	@PlainTextComments
)

SET @LogHistoryId=SCOPE_IDENTITY() 

GO
GRANT EXEC ON [InsertLogHistory] TO PUBLIC
GO
