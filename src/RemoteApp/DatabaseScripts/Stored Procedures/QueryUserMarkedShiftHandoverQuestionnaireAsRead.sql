IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryUserMarkedShiftHandoverQuestionnaireAsRead')
	BEGIN
		DROP PROCEDURE [dbo].QueryUserMarkedShiftHandoverQuestionnaireAsRead
	END
GO

CREATE Procedure [dbo].[QueryUserMarkedShiftHandoverQuestionnaireAsRead]
(
	@ShiftHandoverQuestionnaireId bigint,
	@UserId bigint
)
AS

SELECT * 
FROM 
	[ShiftHandoverQuestionnaireRead]
WHERE
	ShiftHandoverQuestionnaireId = @ShiftHandoverQuestionnaireId AND
	UserId = @UserId
GO

GRANT EXEC ON [QueryUserMarkedShiftHandoverQuestionnaireAsRead] TO PUBLIC
GO 