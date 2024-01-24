IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAreaLabelById')
	BEGIN
		DROP PROCEDURE [dbo].QueryAreaLabelById
	END
GO

CREATE Procedure dbo.QueryAreaLabelById
	(
	@Id bigint
	)
AS
SELECT * 
FROM AreaLabel
WHERE Id = @Id
GO

GRANT EXEC ON QueryAreaLabelById TO PUBLIC
GO