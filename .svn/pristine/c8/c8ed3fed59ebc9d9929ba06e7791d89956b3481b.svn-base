IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitEdmontonByFormGN6Id')
    BEGIN
        DROP PROCEDURE [dbo].QueryWorkPermitEdmontonByFormGN6Id
    END
GO

CREATE Procedure [dbo].QueryWorkPermitEdmontonByFormGN6Id
    (
		@FormGN6Id bigint
    )
AS

SELECT wp.*, wped.*, sw.Id as SpecialWorkId, sw.CompanyName as SpecialWorkName   
FROM WorkPermitEdmonton wp
INNER JOIN WorkPermitEdmontonDetails wped on wped.WorkPermitEdmontonId = wp.Id
left outer join SpecialWork sw on wped.SpecialWorkType = sw.Id      
WHERE
wped.FormGN6Id = @FormGN6Id AND
wp.Deleted = 0

GRANT EXEC ON QueryWorkPermitEdmontonByFormGN6Id TO PUBLIC
GO