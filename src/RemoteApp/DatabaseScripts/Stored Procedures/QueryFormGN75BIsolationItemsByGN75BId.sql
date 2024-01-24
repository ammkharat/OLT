if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGN75BIsolationItemsByGN75BId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGN75BIsolationItemsByGN75BId]
GO

CREATE Procedure [dbo].[QueryFormGN75BIsolationItemsByGN75BId]
(
	@FormGN75BId bigint
)
AS
select 
	item.*
from
	FormGN75BIsolationItem item
where 
	item.FormGN75BId = @FormGN75BId and
    item.Deleted = 0
Order By item.DisplayOrder

GRANT EXEC ON [QueryFormGN75BIsolationItemsByGN75BId] TO PUBLIC
GO