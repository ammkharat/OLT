if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateShiftHandoverQuestionAsOld]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateShiftHandoverQuestionAsOld]
GO

CREATE Procedure [dbo].[UpdateShiftHandoverQuestionAsOld]
    (
    @Id bigint    
    )
AS

update ShiftHandoverQuestion
set 
	[IsCurrentQuestionVersion] = 0
where [Id] = @Id

GO 
GRANT EXEC ON UpdateShiftHandoverQuestionAsOld TO PUBLIC
GO  