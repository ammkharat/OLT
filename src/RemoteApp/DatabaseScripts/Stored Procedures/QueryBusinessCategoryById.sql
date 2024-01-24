IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryBusinessCategoryById')
	BEGIN
		DROP PROCEDURE [dbo].QueryBusinessCategoryById
	END
GO

CREATE Procedure [dbo].QueryBusinessCategoryById
	(
		@Id int
	)
AS

SELECT *
FROM [BusinessCategory] WHERE ID = @Id 
GO

GRANT EXEC ON QueryBusinessCategoryById TO PUBLIC
GO 