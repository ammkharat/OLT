IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestEdmontonById')
	BEGIN
		DROP PROCEDURE [dbo].QueryPermitRequestEdmontonById
	END
GO

CREATE Procedure [dbo].QueryPermitRequestEdmontonById
(
	@Id bigint
)
AS


SELECT pr.*, sw.Id as SpecialWorkId, sw.CompanyName as SpecialWorkName FROM PermitRequestEdmonton  pr  
left outer join SpecialWork sw on pr.SpecialWorkType = sw.Id      
WHERE pr.Id=@Id  
GO

GRANT EXEC ON QueryPermitRequestEdmontonById TO PUBLIC
GO