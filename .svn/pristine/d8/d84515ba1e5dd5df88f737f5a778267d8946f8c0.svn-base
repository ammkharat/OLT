 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertLogDefinitionHistory')
	BEGIN
		DROP  Procedure  InsertLogDefinitionHistory
	END
GO

CREATE Procedure [dbo].[InsertLogDefinitionHistory]
(
 	@LogDefinitionHistoryId bigint Output,
    @Id bigint,
    @LastModifiedUserId bigint,
    @LastModifiedDateTime datetime,
    @FunctionalLocations varchar(max),
    @DocumentLinks VARCHAR(1000),
    @InspectionFollowUp bit,
	@ProcessControlFollowUp bit,
	@OperationsFollowUp bit,
	@SupervisionFollowUp bit,
	@EnvironmentalHealthSafetyFollowUp bit,
	@OtherFollowUp bit,
	@Deleted bit,
	@Schedule VARCHAR(300),
	@PlainTextComments varchar(max),
	@Active bit
)
AS

INSERT INTO [LogDefinitionHistory]
(
    [Id],
	[LastModifiedUserId],
	[LastModifiedDateTime],
	[FunctionalLocations],
	[DocumentLinks],
	[InspectionFollowUp],
	[ProcessControlFollowUp],
	[OperationsFollowUp],
	[SupervisionFollowUp],
	[EnvironmentalHealthSafetyFollowUp],
	[OtherFollowUp],
	[Deleted],
	[Schedule],
	[PlainTextComments],
	[Active]
)
VALUES
(
    @Id,
    @LastModifiedUserId,
    @LastModifiedDateTime,
    @FunctionalLocations,
    @DocumentLinks,
    @InspectionFollowUp,
	@ProcessControlFollowUp,
	@OperationsFollowUp,
	@SupervisionFollowUp,
	@EnvironmentalHealthSafetyFollowUp,
	@OtherFollowUp,
	@Deleted,
	@Schedule,
	@PlainTextComments,
	@Active
)
SET @LogDefinitionHistoryId=SCOPE_IDENTITY() 
GO

GRANT EXEC ON [InsertLogDefinitionHistory] TO PUBLIC
GO
