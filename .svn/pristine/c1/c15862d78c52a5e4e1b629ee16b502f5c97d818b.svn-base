if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertShiftHandoverQuestionnaireFunctionalLocation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertShiftHandoverQuestionnaireFunctionalLocation]
GO

CREATE Procedure [dbo].[InsertShiftHandoverQuestionnaireFunctionalLocation]
    (
	@ShiftHandoverQuestionnaireId bigint,
	@FunctionalLocationId bigint
    )
AS

INSERT INTO ShiftHandoverQuestionnaireFunctionalLocation
(
    ShiftHandoverQuestionnaireId,
	FunctionalLocationId
)
VALUES
(
    @ShiftHandoverQuestionnaireId,
	@FunctionalLocationId
)

GO 
GRANT EXEC ON InsertShiftHandoverQuestionnaireFunctionalLocation TO PUBLIC
GO  