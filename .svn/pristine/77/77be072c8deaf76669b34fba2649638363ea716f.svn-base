if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateShiftHandoverAnswer]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateShiftHandoverAnswer]
GO

CREATE Procedure [dbo].[UpdateShiftHandoverAnswer]
    (
    @Id bigint Output,    
	@Answer bit,
	@Comments varchar(2048) = null
    )
AS

update ShiftHandoverAnswer
set
	Answer = @Answer,
	Comments = @Comments
where Id = @Id

GO 

GRANT EXEC ON UpdateShiftHandoverAnswer TO PUBLIC
GO  