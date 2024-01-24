if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGN7ById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGN7ById]
GO

CREATE Procedure [dbo].[QueryFormGN7ById]
(
	@Id bigint
)
AS
select form.*
from FormGN7 form
where form.Id = @Id