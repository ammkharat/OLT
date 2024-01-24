IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestEdmontonByFormGN1Id')
    BEGIN
        DROP PROCEDURE [dbo].QueryPermitRequestEdmontonByFormGN1Id
    END
GO

CREATE Procedure [dbo].QueryPermitRequestEdmontonByFormGN1Id(@FormGN1Id bigint)
AS

SELECT pr.*, sw.Id as SpecialWorkId, sw.CompanyName as SpecialWorkName  FROM PermitRequestEdmonton pr 
left outer join SpecialWork sw on pr.SpecialWorkType = sw.Id      
WHERE pr.FormGN1Id = @FormGN1Id AND pr.Deleted = 0

GRANT EXEC ON QueryPermitRequestEdmontonByFormGN1Id TO PUBLIC
GO