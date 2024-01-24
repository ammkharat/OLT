if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormOP14ById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormOP14ById]
GO

CREATE Procedure [dbo].[QueryFormOP14ById]
(
	@Id bigint
)
AS
select form.*
from FormOP14 form
where form.Id = @Id