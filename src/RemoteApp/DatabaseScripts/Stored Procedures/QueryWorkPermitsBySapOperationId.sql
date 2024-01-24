IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitsBySapOperationId')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkPermitsBySapOperationId
	END
GO

CREATE Procedure dbo.QueryWorkPermitsBySapOperationId
  (
	    @SapOperationId bigint
  )
AS

SELECT workPermit.*
FROM
    WorkPermit workPermit
WHERE
    workPermit.SapOperationId = @SapOperationId
GO

GRANT EXEC ON QueryWorkPermitsBySapOperationId TO PUBLIC
GO