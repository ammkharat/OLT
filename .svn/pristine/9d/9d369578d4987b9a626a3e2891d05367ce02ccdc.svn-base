 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryLogGuidelineByDivision')
	BEGIN
		DROP PROCEDURE [dbo].QueryLogGuidelineByDivision
	END
GO

CREATE Procedure [dbo].QueryLogGuidelineByDivision
	(
		@DivisionId bigint
	)
AS
SELECT lg.* 
FROM 
	LogGuideline lg
	inner join FunctionalLocation fl on lg.FunctionalLocationId = fl.Id
WHERE 
	fl.Id = @DivisionId
GO

GRANT EXEC ON QueryLogGuidelineByDivision TO PUBLIC
GO


 