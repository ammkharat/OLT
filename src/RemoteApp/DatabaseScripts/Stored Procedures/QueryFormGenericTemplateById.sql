if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGenericTemplateById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGenericTemplateById]
GO

CREATE Procedure [dbo].[QueryFormGenericTemplateById]
(
	@Id bigint
)
AS
select form.*
from FormGenericTemplate form
where form.Id = @Id


GO

GRANT EXEC ON QueryFormGenericTemplateById TO PUBLIC
GO
