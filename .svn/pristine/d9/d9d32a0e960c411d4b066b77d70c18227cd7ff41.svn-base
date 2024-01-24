IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestEdmontonByFormGN75AId')
    BEGIN
        DROP PROCEDURE [dbo].QueryPermitRequestEdmontonByFormGN75AId
    END
GO

CREATE Procedure [dbo].QueryPermitRequestEdmontonByFormGN75AId(@FormGN75AId bigint)
AS

SELECT pr.*, sw.Id as SpecialWorkId, sw.CompanyName as SpecialWorkName FROM PermitRequestEdmonton pr 
left outer join SpecialWork sw on pr.SpecialWorkType = sw.Id      
WHERE pr.FormGN75AId = @FormGN75AId AND pr.Deleted = 0

GRANT EXEC ON QueryPermitRequestEdmontonByFormGN75AId TO PUBLIC
GO