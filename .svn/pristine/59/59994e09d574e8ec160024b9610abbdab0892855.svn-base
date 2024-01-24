if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemoveShiftHandoverQuestionnaire]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RemoveShiftHandoverQuestionnaire]
GO

CREATE Procedure [dbo].[RemoveShiftHandoverQuestionnaire]
    (
    @Id bigint Output
    )
AS

delete from ShiftHandoverQuestionnaireFunctionalLocation
where ShiftHandoverQuestionnaireId = @Id

delete from ShiftHandoverQuestionnaireFunctionalLocationList
where ShiftHandoverQuestionnaireId = @Id

delete from ShiftHandoverAnswer
where ShiftHandoverQuestionnaireId = @Id

delete from ShiftHandoverQuestionnaireCokerCardConfiguration
where ShiftHandoverQuestionnaireId = @Id

DELETE FROM ShiftHandoverQuestionnaireRead
WHERE ShiftHandoverQuestionnaireId = @Id

DELETE FROM ShiftHandoverQuestionnaireLog
WHERE ShiftHandoverQuestionnaireId = @Id

DELETE FROM ShiftHandoverQuestionnaireSummaryLog
WHERE ShiftHandoverQuestionnaireId = @Id

delete
from ShiftHandoverQuestionnaire
where [Id] = @Id


GO 

GRANT EXEC ON [RemoveShiftHandoverQuestionnaire] TO PUBLIC
GO  