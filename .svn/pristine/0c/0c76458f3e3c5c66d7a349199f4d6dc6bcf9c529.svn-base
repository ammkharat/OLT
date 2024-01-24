IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitEdmontonForReuse')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkPermitEdmontonForReuse
	END
GO

CREATE Procedure [dbo].QueryWorkPermitEdmontonForReuse
	(	
		@Id bigint
	)
AS

SELECT 
  Top 1 previous.*, details.*
from 
  WorkPermitEdmonton previous
INNER JOIN   
	WorkPermitEdmonton [current] ON [current].PermitRequestId = previous.PermitRequestId and [current].Id != previous.Id
INNER JOIN WorkPermitEdmontonDetails details ON details.WorkPermitEdmontonId = previous.Id
WHERE
  [current].PermitRequestId IS NOT NULL
  and previous.Deleted = 0
  and [current].Id = @Id
  and (previous.IssuedDateTime IS NOT NULL OR previous.IssuedByUserId IS NOT NULL) -- these should both be not null, but there were some bugs in the past where it may not be the case.
Order By
  previous.PermitNumber DESC

GRANT EXEC ON QueryWorkPermitEdmontonForReuse TO PUBLIC
GO