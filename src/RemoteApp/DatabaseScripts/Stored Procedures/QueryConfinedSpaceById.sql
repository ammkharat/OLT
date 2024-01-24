if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryConfinedSpaceById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryConfinedSpaceById]
GO

CREATE Procedure [dbo].[QueryConfinedSpaceById]
(
	@Id bigint
)
AS
	SELECT 
		* 
	From 
		ConfinedSpace
	WHERE
		ConfinedSpace.Id = @Id