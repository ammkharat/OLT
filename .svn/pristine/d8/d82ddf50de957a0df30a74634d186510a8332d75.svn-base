if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGN24ById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGN24ById]
GO

CREATE Procedure [dbo].[QueryFormGN24ById]
(
	@Id bigint
)
AS
select form.*
from FormGN24 form
where form.Id = @Id