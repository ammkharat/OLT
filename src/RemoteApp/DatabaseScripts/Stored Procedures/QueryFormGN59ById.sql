if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGN59ById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGN59ById]
GO

CREATE Procedure [dbo].[QueryFormGN59ById]
(
	@Id bigint
)
AS
select form.*
from FormGN59 form
where form.Id = @Id