IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitLubesForReuse')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkPermitLubesForReuse
	END
GO

CREATE Procedure [dbo].QueryWorkPermitLubesForReuse
	(	
		@Id bigint
	)
AS

SELECT Top 1 previous.*, prl.CreatedByUserId as PermitRequestCreatedByUserId, prl.DataSourceId as PermitRequestDataSourceId
from WorkPermitLubes previous
INNER JOIN WorkPermitLubes [current] ON [current].PermitRequestId = previous.PermitRequestId and [current].Id != previous.Id
left outer join PermitRequestLubes prl on prl.Id = previous.PermitRequestId
WHERE
  [current].PermitRequestId IS NOT NULL
  and previous.Deleted = 0
  and [current].Id = @Id
  and previous.IssuedDateTime IS NOT NULL
ORDER BY
  previous.PermitNumber DESC

GRANT EXEC ON QueryWorkPermitLubesForReuse TO PUBLIC
GO