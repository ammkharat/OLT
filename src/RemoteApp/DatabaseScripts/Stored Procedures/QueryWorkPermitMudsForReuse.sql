
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitMudsForReuse')
	BEGIN
		DROP Procedure [dbo].QueryWorkPermitMudsForReuse
	END
GO

CREATE Procedure [dbo].[QueryWorkPermitMudsForReuse]
	(	
		@Id bigint
	)
AS

Select  Top 1 previous.*, details.*,requestDetails.*
from WorkPermitMuds previous
INNER JOIN WorkPermitMuds [current] ON [current].PermitRequestId = previous.PermitRequestId and [current].Id != previous.Id
INNER JOIN WorkPermitMudsDetails details ON details.Id = previous.Id
INNER JOIN WorkPermitMudsRequestDetails requestDetails ON requestDetails.Id = previous.Id

WHERE
  [current].PermitRequestId IS NOT NULL
  and previous.Deleted = 0
  and [current].Id = @Id
  and previous.IssuedDateTime IS NOT NULL
ORDER BY
  previous.PermitNumber DESC

GRANT EXEC ON QueryWorkPermitMudsForReuse TO PUBLIC
GO

