 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertShiftHandoverAnswerHistory')
	BEGIN
		DROP  Procedure  InsertShiftHandoverAnswerHistory
	END
GO

CREATE Procedure [dbo].[InsertShiftHandoverAnswerHistory]
(
	@ShiftHandoverQuestionnaireHistoryId bigint,
	@ShiftHandoverQuestionId bigint,
	@Id bigint,
    @Answer bit,
    @Comments varchar(1024) = null
)
AS

INSERT INTO [ShiftHandoverAnswerHistory]
(
	[ShiftHandoverQuestionnaireHistoryId],
	[ShiftHandoverQuestionId],
	[Id],
	[Answer],
	[Comments]
)
VALUES
(
    @ShiftHandoverQuestionnaireHistoryId,
    @ShiftHandoverQuestionId,
	@Id,
    @Answer,
    @Comments
)

GO

GRANT EXEC ON [InsertShiftHandoverAnswerHistory] TO PUBLIC
GO