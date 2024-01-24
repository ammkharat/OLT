IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestEdmontonByFormGN6Id')
    BEGIN
        DROP PROCEDURE [dbo].QueryPermitRequestEdmontonByFormGN6Id
    END
GO

CREATE Procedure [dbo].QueryPermitRequestEdmontonByFormGN6Id(@FormGN6Id bigint)
AS

SELECT pr.*, sw.Id as SpecialWorkId, sw.CompanyName as SpecialWorkName FROM PermitRequestEdmonton pr 
left outer join SpecialWork sw on pr.SpecialWorkType = sw.Id      
WHERE pr.FormGN6Id = @FormGN6Id AND pr.Deleted = 0

GRANT EXEC ON QueryPermitRequestEdmontonByFormGN6Id TO PUBLIC
GO