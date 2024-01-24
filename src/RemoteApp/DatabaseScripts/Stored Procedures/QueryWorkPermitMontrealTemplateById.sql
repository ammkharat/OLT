IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitMontrealTemplateById')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkPermitMontrealTemplateById
	END
GO

CREATE Procedure [dbo].QueryWorkPermitMontrealTemplateById
	(
		@id bigint
	)
AS

select * 
from WorkPermitMontrealTemplate 
where
	 WorkPermitMontrealTemplate.Id = @id
GO

GRANT EXEC ON QueryWorkPermitMontrealTemplateById TO PUBLIC
GO 