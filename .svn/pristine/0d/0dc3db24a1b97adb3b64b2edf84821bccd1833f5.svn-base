if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormLubesCsdById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormLubesCsdById]
GO

CREATE Procedure [dbo].[QueryFormLubesCsdById]
(
	@Id bigint
)
AS
select form.*
from FormLubesCsd form
where form.Id = @Id