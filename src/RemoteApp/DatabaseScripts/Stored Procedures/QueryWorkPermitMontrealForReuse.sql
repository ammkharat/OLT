IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitMontrealForReuse')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkPermitMontrealForReuse
	END
GO

CREATE Procedure [dbo].QueryWorkPermitMontrealForReuse
	(	
		@Id bigint
	)
AS

Select  Top 1 previous.*, details.*,requestDetails.*
from WorkPermitMontreal previous
INNER JOIN WorkPermitMontreal [current] ON [current].PermitRequestId = previous.PermitRequestId and [current].Id != previous.Id
INNER JOIN WorkPermitMontrealDetails details ON details.Id = previous.Id
INNER JOIN WorkPermitMontrealRequestDetails requestDetails ON requestDetails.Id = previous.Id

WHERE
  [current].PermitRequestId IS NOT NULL
  and previous.Deleted = 0
  and [current].Id = @Id
  and previous.IssuedDateTime IS NOT NULL
ORDER BY
  previous.PermitNumber DESC

GRANT EXEC ON QueryWorkPermitMontrealForReuse TO PUBLIC
GO
