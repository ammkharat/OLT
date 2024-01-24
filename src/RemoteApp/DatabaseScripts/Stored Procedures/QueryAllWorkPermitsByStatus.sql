IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllWorkPermitsByStatus')
    BEGIN
        DROP PROCEDURE [dbo].QueryAllWorkPermitsByStatus
    END
GO

CREATE Procedure dbo.QueryAllWorkPermitsByStatus
    (
        @WorkPermitStatusId int
    )
AS

SELECT  
	WorkPermit.*
FROM         
	WorkPermit
WHERE     
	WorkPermitStatusId = @WorkPermitStatusId
	AND WorkPermit.Deleted = 0
GO

GRANT EXEC ON QueryAllWorkPermitsByStatus TO PUBLIC
GO