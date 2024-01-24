if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormMontrealCsdById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormMontrealCsdById]
GO

CREATE Procedure [dbo].[QueryFormMontrealCsdById]
(
	@Id bigint
)
AS
select form.*
from FormMontrealCsd form
where form.Id = @Id