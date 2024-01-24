IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertSummaryLogHistory')
	BEGIN
		DROP  Procedure  InsertSummaryLogHistory
	END
GO

CREATE Procedure [dbo].[InsertSummaryLogHistory]
(
	@SummaryLogHistoryId bigint Output,
    @Id bigint,
	@LogDateTime datetime,
    @LastModifiedUserId bigint, 
    @LastModifiedDateTime datetime, 
    @FunctionalLocations varchar(max),
    @InspectionFollowUp bit,
    @ProcessControlFollowUp bit, 
    @OperationsFollowUp bit, 
    @SupervisionFollowUp bit, 
    @OtherFollowUp bit,
    @EHSFollowUp bit,
    @DocumentLinks varchar(1000) = NULL,
	@PlainTextComments varchar(max) = NULL,
	@DorComments varchar(max) = NULL
)
AS

INSERT INTO [SummaryLogHistory]
(
    [Id],
	[LogDateTime],
    [LastModifiedUserId], 
    [LastModifiedDateTime], 
    [FunctionalLocations],
    [EHSFollowup],
    [ProcessControlFollowUp],
    [OperationsFollowUp],
    [SupervisionFollowUp],
    [InspectionFollowUp],
    [OtherFollowUp],
    [DocumentLinks],
	[PlainTextComments],
	[DorComments]
)
VALUES
(
    @Id,
	@LogDateTime,
    @LastModifiedUserId,
    @LastModifiedDateTime,
    @FunctionalLocations,
    @EHSFollowUp,
    @ProcessControlFollowUp,
    @OperationsFollowUp,
    @SupervisionFollowUp,
    @InspectionFollowUp,
    @OtherFollowUp,
    @DocumentLinks,
	@PlainTextComments,
	@DorComments
)

SET @SummaryLogHistoryId=SCOPE_IDENTITY() 

GO
GRANT EXEC ON [InsertSummaryLogHistory] TO PUBLIC
GO