if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertShiftHandoverQuestionnaireCokerCardConfiguration]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertShiftHandoverQuestionnaireCokerCardConfiguration]
GO

CREATE Procedure [dbo].[InsertShiftHandoverQuestionnaireCokerCardConfiguration]
    (
	@ShiftHandoverQuestionnaireId bigint,
	@CokerCardConfigurationId bigint
    )
AS

INSERT INTO ShiftHandoverQuestionnaireCokerCardConfiguration
(
    ShiftHandoverQuestionnaireId,
	CokerCardConfigurationId
)
VALUES
(
    @ShiftHandoverQuestionnaireId,
	@CokerCardConfigurationId
)

GO 
GRANT EXEC ON InsertShiftHandoverQuestionnaireCokerCardConfiguration TO PUBLIC
GO  