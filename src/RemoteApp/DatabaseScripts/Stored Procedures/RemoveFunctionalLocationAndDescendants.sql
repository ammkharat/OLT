 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveFunctionalLocationAndDescendants')
	BEGIN
		DROP  Procedure  RemoveFunctionalLocationAndDescendants
	END

GO

CREATE Procedure [dbo].RemoveFunctionalLocationAndDescendants
	(
		@Id bigint
	)
AS

UPDATE f
  SET f.Deleted = 1
FROM FunctionalLocation f
  INNER JOIN FunctionalLocationAncestor a ON f.Id = a.Id
WHERE 
	a.AncestorId = @Id OR f.Id = @Id
GO

GRANT EXEC ON RemoveFunctionalLocationAndDescendants TO PUBLIC
GO