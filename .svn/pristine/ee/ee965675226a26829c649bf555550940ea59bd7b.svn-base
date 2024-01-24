if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteShiftHandoverQuestionnaireFunctionalLocation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteShiftHandoverQuestionnaireFunctionalLocation]
GO

CREATE Procedure [dbo].[DeleteShiftHandoverQuestionnaireFunctionalLocation]
    (
	@ShiftHandoverQuestionnaireId bigint
    )
AS

delete
from ShiftHandoverQuestionnaireFunctionalLocation
where ShiftHandoverQuestionnaireId = @ShiftHandoverQuestionnaireId

GO 
GRANT EXEC ON DeleteShiftHandoverQuestionnaireFunctionalLocation TO PUBLIC
GO  