 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertShiftHandoverQuestionnaireHistory')
	BEGIN
		DROP  Procedure  InsertShiftHandoverQuestionnaireHistory
	END
GO

CREATE Procedure [dbo].[InsertShiftHandoverQuestionnaireHistory]
(
	@ShiftHandoverQuestionnaireHistoryId bigint Output,
    @Id bigint,
	@FunctionalLocations varchar(max),
    @LastModifiedByUserId bigint,
    @LastModifiedDateTime datetime
)
AS

INSERT INTO [ShiftHandoverQuestionnaireHistory]
(
    [Id],
	[FunctionalLocations],
	[LastModifiedByUserId],
	[LastModifiedDateTime]
)
VALUES
(
    @Id,
	@FunctionalLocations,
    @LastModifiedByUserId,
    @LastModifiedDateTime
)
SET @ShiftHandoverQuestionnaireHistoryId= SCOPE_IDENTITY() 
GO

GRANT EXEC ON [InsertShiftHandoverQuestionnaireHistory] TO PUBLIC
GO