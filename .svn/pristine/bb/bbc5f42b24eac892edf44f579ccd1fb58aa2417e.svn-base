if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateShiftHandoverQuestionnaire]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateShiftHandoverQuestionnaire]
GO

CREATE Procedure [dbo].[UpdateShiftHandoverQuestionnaire]
    (
    @Id bigint Output,    
	@LastModifiedDateTime datetime,
	@HasYesAnswer bit,
	@LogId bigint = null,
	@SummaryLogId bigint = null
    )
AS

update ShiftHandoverQuestionnaire
set
	[LastModifiedDateTime] = @LastModifiedDateTime,
	[HasYesAnswer] = @HasYesAnswer,
	[LogId] = @LogId,
	[SummaryLogId] = @SummaryLogId
where [Id] = @Id


GO 

GRANT EXEC ON UpdateShiftHandoverQuestionnaire TO PUBLIC
GO  