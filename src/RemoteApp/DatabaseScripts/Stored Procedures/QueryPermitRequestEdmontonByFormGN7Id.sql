IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestEdmontonByFormGN7Id')
    BEGIN
        DROP PROCEDURE [dbo].QueryPermitRequestEdmontonByFormGN7Id
    END
GO

CREATE Procedure [dbo].QueryPermitRequestEdmontonByFormGN7Id
    (
		@FormGN7Id bigint
    )
AS

SELECT pr.*, sw.Id as SpecialWorkId, sw.CompanyName as SpecialWorkName FROM PermitRequestEdmonton  pr  
left outer join SpecialWork sw on pr.SpecialWorkType = sw.Id      
WHERE
pr.FormGN7Id = @FormGN7Id AND
pr.Deleted = 0

GRANT EXEC ON QueryPermitRequestEdmontonByFormGN7Id TO PUBLIC
GO