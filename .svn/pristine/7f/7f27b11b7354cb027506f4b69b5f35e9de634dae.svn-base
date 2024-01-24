IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitByIdForUSPipeline')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkPermitByIdForUSPipeline
	END
GO

CREATE Procedure dbo.QueryWorkPermitByIdForUSPipeline
  (
	    @Id bigint
  )
AS
SELECT workPermit.*
FROM
    WorkPermitUSPipeline workPermit
WHERE
    workPermit.Id = @Id
GO

GRANT EXEC ON QueryWorkPermitByIdForUSPipeline TO PUBLIC
GO