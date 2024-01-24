IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormGN75BDevicePositionByGN75BId')
	BEGIN
		DROP  Procedure dbo.QueryFormGN75BDevicePositionByGN75BId
	END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[QueryFormGN75BDevicePositionByGN75BId]
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

GRANT EXEC ON [QueryFormGN75BDevicePositionByGN75BId] TO PUBLIC
