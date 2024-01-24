if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGN75BIsolationItemsByGN75BTemplateId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGN75BIsolationItemsByGN75BTemplateId]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[QueryFormGN75BIsolationItemsByGN75BTemplateId]
(
	@FormGN75BId bigint
)
AS
select 
	item.*
from
	FormGN75BTemplateIsolationItem item
where 
	item.FormGN75BTemplateId = @FormGN75BId and
    item.Deleted = 0
Order By item.DisplayOrder

GRANT EXEC ON [QueryFormGN75BIsolationItemsByGN75BTemplateId] TO PUBLIC



