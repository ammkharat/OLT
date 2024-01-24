IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryOpmToeDefinitionCommentByOltToeDefinitionId')
	BEGIN
		DROP PROCEDURE [dbo].QueryOpmToeDefinitionCommentByOltToeDefinitionId
	END
GO

CREATE Procedure [dbo].QueryOpmToeDefinitionCommentByOltToeDefinitionId
(
	@OltToeDefinitionId bigint
)
AS

SELECT 
	com.*

FROM OpmToeDefinitionComment com
WHERE com.OltToeDefinitionId=@OltToeDefinitionId
GO

GRANT EXEC ON QueryOpmToeDefinitionCommentByOltToeDefinitionId TO PUBLIC
GO