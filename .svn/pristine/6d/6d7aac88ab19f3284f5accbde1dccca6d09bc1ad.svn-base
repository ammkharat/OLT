IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitEdmontonByFormGN75AId')
    BEGIN
        DROP PROCEDURE [dbo].QueryWorkPermitEdmontonByFormGN75AId
    END
GO

CREATE Procedure [dbo].QueryWorkPermitEdmontonByFormGN75AId(@FormGN75AId bigint)
AS

SELECT wp.*, wped.*, sw.Id as SpecialWorkId, sw.CompanyName as SpecialWorkName  FROM WorkPermitEdmonton wp
INNER JOIN WorkPermitEdmontonDetails wped on wped.WorkPermitEdmontonId = wp.Id
left outer join SpecialWork sw on wped.SpecialWorkType = sw.Id      
WHERE
wped.FormGN75AId = @FormGN75AId AND wp.Deleted = 0

GRANT EXEC ON QueryWorkPermitEdmontonByFormGN75AId TO PUBLIC
GO
    