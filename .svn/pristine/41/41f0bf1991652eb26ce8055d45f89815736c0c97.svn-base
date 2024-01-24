IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitById')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkPermitById
	END
GO

CREATE Procedure dbo.QueryWorkPermitById
  (
	    @Id bigint
  )
AS
SELECT workPermit.*
FROM
    WorkPermit workPermit
WHERE
    workPermit.Id = @Id
GO

GRANT EXEC ON QueryWorkPermitById TO PUBLIC
GO