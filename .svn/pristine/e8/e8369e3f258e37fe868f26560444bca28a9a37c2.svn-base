IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestMontrealById')
	BEGIN
		DROP PROCEDURE [dbo].QueryPermitRequestMontrealById
	END
GO

CREATE Procedure [dbo].QueryPermitRequestMontrealById
(
	@Id bigint
)
AS

SELECT *
FROM PermitRequestMontreal
WHERE Id=@Id
GO

GRANT EXEC ON QueryPermitRequestMontrealById TO PUBLIC
GO