IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestEdmontonByFormGN24Id')
    BEGIN
        DROP PROCEDURE [dbo].QueryPermitRequestEdmontonByFormGN24Id
    END
GO

CREATE Procedure [dbo].QueryPermitRequestEdmontonByFormGN24Id(@FormGN24Id bigint)
AS

SELECT pr.*, sw.Id as SpecialWorkId, sw.CompanyName as SpecialWorkName  FROM PermitRequestEdmonton pr 
left outer join SpecialWork sw on pr.SpecialWorkType = sw.Id      
WHERE pr.FormGN24Id = @FormGN24Id AND pr.Deleted = 0

GRANT EXEC ON QueryPermitRequestEdmontonByFormGN24Id TO PUBLIC
GO