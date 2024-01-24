if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGN6ById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGN6ById]
GO

CREATE Procedure [dbo].[QueryFormGN6ById]
(
	@Id bigint
)
AS
select form.*
from FormGN6 form
where form.Id = @Id