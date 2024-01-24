IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitEdmontonByFormGN1Id')
    BEGIN
        DROP PROCEDURE [dbo].QueryWorkPermitEdmontonByFormGN1Id
    END
GO

CREATE Procedure [dbo].QueryWorkPermitEdmontonByFormGN1Id(@FormGN1Id bigint)
AS

SELECT wp.*, wped.* , sw.Id as SpecialWorkId, sw.CompanyName as SpecialWorkName FROM WorkPermitEdmonton wp  
INNER JOIN WorkPermitEdmontonDetails wped on wped.WorkPermitEdmontonId = wp.Id
left outer join SpecialWork sw on wped.SpecialWorkType = sw.Id      
WHERE
wped.FormGN1Id = @FormGN1Id AND wp.Deleted = 0

GRANT EXEC ON QueryWorkPermitEdmontonByFormGN1Id TO PUBLIC
GO