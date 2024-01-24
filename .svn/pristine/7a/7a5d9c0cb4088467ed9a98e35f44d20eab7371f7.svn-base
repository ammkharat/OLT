IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitEdmontonByFormGN24Id')
    BEGIN
        DROP PROCEDURE [dbo].QueryWorkPermitEdmontonByFormGN24Id
    END
GO

CREATE Procedure [dbo].QueryWorkPermitEdmontonByFormGN24Id
    (
		@FormGN24Id bigint
    )
AS

SELECT wp.*, wped.* , sw.Id as SpecialWorkId, sw.CompanyName as SpecialWorkName FROM WorkPermitEdmonton wp  
INNER JOIN WorkPermitEdmontonDetails wped on wped.WorkPermitEdmontonId = wp.Id
left outer join SpecialWork sw on wped.SpecialWorkType = sw.Id      
WHERE
wped.FormGN24Id = @FormGN24Id AND
wp.Deleted = 0

GRANT EXEC ON QueryWorkPermitEdmontonByFormGN24Id TO PUBLIC
GO