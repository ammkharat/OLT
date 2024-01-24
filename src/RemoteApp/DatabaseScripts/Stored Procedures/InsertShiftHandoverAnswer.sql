if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertShiftHandoverAnswer]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertShiftHandoverAnswer]
GO

CREATE Procedure [dbo].[InsertShiftHandoverAnswer]
    (
    @Id bigint Output,    
	@ShiftHandoverQuestionnaireId bigint,
	@Answer bit,
	@Comments varchar(2048) = null,
	@QuestionDisplayOrder int,
	@ShiftHandoverQuestionId bigint
    )
AS

INSERT INTO ShiftHandoverAnswer
(
    ShiftHandoverQuestionnaireId,
	Answer,
	Comments,
	QuestionDisplayOrder,
	ShiftHandoverQuestionId
)
VALUES
(
    @ShiftHandoverQuestionnaireId,
	@Answer,
	@Comments,
	@QuestionDisplayOrder,
	@ShiftHandoverQuestionId
)
SET @Id= SCOPE_IDENTITY() 
GO 
GRANT EXEC ON InsertShiftHandoverAnswer TO PUBLIC
GO  