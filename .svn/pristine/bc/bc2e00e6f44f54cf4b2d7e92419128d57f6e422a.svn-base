IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryRestrictionLocationItemById')
	BEGIN
		DROP PROCEDURE [dbo].QueryRestrictionLocationItemById
	END
GO

CREATE Procedure [dbo].QueryRestrictionLocationItemById
(
	@Id int
)
AS

SELECT * FROM RestrictionLocationItem 
WHERE ID=@Id
GO

GRANT EXEC ON QueryRestrictionLocationItemById TO PUBLIC
GO