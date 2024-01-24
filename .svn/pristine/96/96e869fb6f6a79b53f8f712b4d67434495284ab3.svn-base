IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCokerCardById')
	BEGIN
		DROP PROCEDURE [dbo].QueryCokerCardById
	END
GO

CREATE Procedure [dbo].QueryCokerCardById
(
	@id bigint
)
AS

SELECT 
	cc.*,
	ccf.Name as CokerCardConfigurationName
FROM CokerCard cc,
CokerCardConfiguration ccf
WHERE cc.ID=@id
and cc.CokerCardConfigurationId = ccf.Id
GO

GRANT EXEC ON QueryCokerCardById TO PUBLIC
GO