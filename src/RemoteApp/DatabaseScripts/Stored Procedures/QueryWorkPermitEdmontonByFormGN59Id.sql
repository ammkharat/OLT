IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitEdmontonByFormGN59Id')
    BEGIN
        DROP PROCEDURE [dbo].QueryWorkPermitEdmontonByFormGN59Id
    END
GO

CREATE Procedure [dbo].QueryWorkPermitEdmontonByFormGN59Id
    (
		@FormGN59Id bigint
    )
AS

SELECT wp.*, wped.*, sw.Id as SpecialWorkId, sw.CompanyName as SpecialWorkName   
FROM WorkPermitEdmonton wp
INNER JOIN WorkPermitEdmontonDetails wped on wped.WorkPermitEdmontonId = wp.Id
left outer join SpecialWork sw on wped.SpecialWorkType = sw.Id      
WHERE
wped.FormGN59Id = @FormGN59Id AND
wp.Deleted = 0

GRANT EXEC ON QueryWorkPermitEdmontonByFormGN59Id TO PUBLIC
GO