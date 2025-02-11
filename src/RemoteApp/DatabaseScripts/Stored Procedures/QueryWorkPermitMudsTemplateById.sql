
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitMudsTemplateById')
	BEGIN
		DROP Procedure [dbo].QueryWorkPermitMudsTemplateById
	END
GO

CREATE Procedure [dbo].[QueryWorkPermitMudsTemplateById]
	(
		@id bigint
	)
AS

select * 
from WorkPermitMudsTemplate 
where
	 WorkPermitMudsTemplate.Id = @id
GO

GRANT EXEC ON QueryWorkPermitMudsTemplateById TO PUBLIC
GO
