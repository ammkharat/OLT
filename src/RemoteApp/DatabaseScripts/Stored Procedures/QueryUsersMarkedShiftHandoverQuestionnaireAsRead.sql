IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryUsersMarkedShiftHandoverQuestionnaireAsRead')
	BEGIN
		DROP PROCEDURE [dbo].QueryUsersMarkedShiftHandoverQuestionnaireAsRead
	END
GO

CREATE Procedure [dbo].[QueryUsersMarkedShiftHandoverQuestionnaireAsRead]
(
	@ShiftHandoverQuestionnaireId bigint
)
AS

SELECT 
	Firstname, 
	Lastname, 
	Username, 
	[DateTime]
FROM 
	[ShiftHandoverQuestionnaireRead]
	INNER JOIN [User] ON ShiftHandoverQuestionnaireRead.UserId = [User].Id
WHERE
	ShiftHandoverQuestionnaireId = @ShiftHandoverQuestionnaireId
ORDER BY
	DateTime DESC
GO

GRANT EXEC ON [QueryUsersMarkedShiftHandoverQuestionnaireAsRead] TO PUBLIC
GO