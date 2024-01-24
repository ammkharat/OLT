IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitEdmontonByFormGN7Id')
    BEGIN
        DROP PROCEDURE [dbo].QueryWorkPermitEdmontonByFormGN7Id
    END
GO

CREATE Procedure [dbo].QueryWorkPermitEdmontonByFormGN7Id
    (
		@FormGN7Id bigint
    )
AS

SELECT wp.*, wped.*, sw.Id as SpecialWorkId, sw.CompanyName as SpecialWorkName   
FROM WorkPermitEdmonton wp  
INNER JOIN WorkPermitEdmontonDetails wped on wped.WorkPermitEdmontonId = wp.Id  
left outer join SpecialWork sw on wped.SpecialWorkType = sw.Id 
WHERE
wped.FormGN7Id = @FormGN7Id AND
wp.Deleted = 0

GRANT EXEC ON QueryWorkPermitEdmontonByFormGN7Id TO PUBLIC
GO
