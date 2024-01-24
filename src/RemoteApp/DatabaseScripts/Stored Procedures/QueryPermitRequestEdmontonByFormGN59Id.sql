IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestEdmontonByFormGN59Id')
    BEGIN
        DROP PROCEDURE [dbo].QueryPermitRequestEdmontonByFormGN59Id
    END
GO

CREATE Procedure [dbo].QueryPermitRequestEdmontonByFormGN59Id
    (
		@FormGN59Id bigint
    )
AS

SELECT pr.*, sw.Id as SpecialWorkId, sw.CompanyName as SpecialWorkName  FROM PermitRequestEdmonton pr
left outer join SpecialWork sw on pr.SpecialWorkType = sw.Id      
WHERE
pr.FormGN59Id = @FormGN59Id AND
pr.Deleted = 0

GRANT EXEC ON QueryPermitRequestEdmontonByFormGN59Id TO PUBLIC
GO