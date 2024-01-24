if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryWorkPermitLubesById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryWorkPermitLubesById]
GO

CREATE Procedure [dbo].[QueryWorkPermitLubesById]
(
	@Id bigint
)
AS
select wpl.*, prl.CreatedByUserId as PermitRequestCreatedByUserId, prl.DataSourceId as PermitRequestDataSourceId
from WorkPermitLubes wpl
left outer join PermitRequestLubes prl on prl.Id = wpl.PermitRequestId
where wpl.Id = @Id