IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertShiftHandoverQuestionnaireRead')
	BEGIN
		DROP  Procedure  InsertShiftHandoverQuestionnaireRead
	END

GO

CREATE Procedure [dbo].[InsertShiftHandoverQuestionnaireRead]
(
	@ShiftHandoverQuestionnaireId bigint,
	@UserId bigint,
	@DateTime datetime
)
AS

INSERT INTO [ShiftHandoverQuestionnaireRead]
(
    [ShiftHandoverQuestionnaireId],
    [UserId], 
    [DateTime]
)
VALUES
(
    @ShiftHandoverQuestionnaireId,
    @UserId,
    @DateTime
)

GO
GRANT EXEC ON [InsertShiftHandoverQuestionnaireRead] TO PUBLIC
GO
