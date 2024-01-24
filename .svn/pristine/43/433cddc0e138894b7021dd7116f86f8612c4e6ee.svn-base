IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryOpmToeDefinitionByTagAndVersion')
	BEGIN
		DROP PROCEDURE [dbo].QueryOpmToeDefinitionByTagAndVersion
	END
GO

CREATE Procedure [dbo].QueryOpmToeDefinitionByTagAndVersion
(
	@ToeVersion bigint,
    @HistorianTag varchar(255)
)
AS

SELECT 
	def.*

FROM OpmToeDefinition def
WHERE 
def.HistorianTag = @HistorianTag
AND
def.ToeVersion = @ToeVersion
GO

GRANT EXEC ON QueryOpmToeDefinitionByTagAndVersion TO PUBLIC
GO