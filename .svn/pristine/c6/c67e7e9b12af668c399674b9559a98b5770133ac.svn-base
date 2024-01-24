IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryOpmToeDefinitionCommentById')
	BEGIN
		DROP PROCEDURE [dbo].QueryOpmToeDefinitionCommentById
	END
GO

CREATE Procedure [dbo].QueryOpmToeDefinitionCommentById
(
	@id bigint
)
AS

SELECT 
	com.*

FROM OpmToeDefinitionComment com
WHERE com.ID=@id
GO

GRANT EXEC ON QueryOpmToeDefinitionCommentById TO PUBLIC
GO