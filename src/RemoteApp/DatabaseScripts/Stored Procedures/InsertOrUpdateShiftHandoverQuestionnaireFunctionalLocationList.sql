  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertOrUpdateShiftHandoverQuestionnaireFunctionalLocationList')
	BEGIN
		DROP  Procedure  InsertOrUpdateShiftHandoverQuestionnaireFunctionalLocationList
	END

GO

CREATE Procedure dbo.InsertOrUpdateShiftHandoverQuestionnaireFunctionalLocationList
	(	
	@QuestionnaireId bigint
	)
AS

DELETE FROM ShiftHandoverQuestionnaireFunctionalLocationList WHERE ShiftHandoverQuestionnaireId = @QuestionnaireId

insert into dbo.ShiftHandoverQuestionnaireFunctionalLocationList (ShiftHandoverQuestionnaireId, FunctionalLocationList)
SELECT shq.Id
, STUFF 
( 
  (SELECT ', ' + f.FullHierarchy
    FROM dbo.ShiftHandoverQuestionnaireFunctionalLocation shqfl 
    INNER JOIN FunctionalLocation f on f.Id = shqfl.FunctionalLocationId 
    where shq.Id = shqfl.ShiftHandoverQuestionnaireId 
    order by f.FullHierarchy 
    FOR XML PATH('') 
  ) 
,1,2,'') as subqueryAsStringList 
FROM [ShiftHandoverQuestionnaire] shq
WHERE shq.Id = @QuestionnaireId

RETURN

GO    