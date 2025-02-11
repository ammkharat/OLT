
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryConfinedSpaceMudsById')
	BEGIN
		DROP Procedure [dbo].QueryConfinedSpaceMudsById
	END
GO

Create Procedure [dbo].[QueryConfinedSpaceMudsById]
(
	@Id bigint
)
AS
	SELECT 
		* 
	From 
		ConfinedSpaceMuds
	WHERE
		ConfinedSpaceMuds.Id = @Id
GO


GRANT EXEC ON QueryConfinedSpaceMudsById TO PUBLIC
GO
