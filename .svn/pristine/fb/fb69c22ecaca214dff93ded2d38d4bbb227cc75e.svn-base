if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryOvertimeFormById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryOvertimeFormById]
GO

CREATE Procedure [dbo].[QueryOvertimeFormById]
(
	@Id bigint
)
AS
select form.*
from OvertimeForm form
where form.Id = @Id

GRANT EXEC ON [QueryOvertimeFormById] TO PUBLIC
GO