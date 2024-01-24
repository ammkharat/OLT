IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VShiftHandoverAnswers')
BEGIN
	DROP VIEW VShiftHandoverAnswers
END
GO

CREATE VIEW dbo.VShiftHandoverAnswers WITH SCHEMABINDING
AS
select 
	shqre.ShiftHandoverConfigurationName as ShiftHandoverConfigurationNameWhenAnswered,
	wa.Name as WorkAssignmentName,
	shqre.CreatedDateTime as QuestionnaireCreatedDateTime,
	shqre.LastModifiedDateTime as QuestionnaireLastModifiedDateTime,
	cu.Username as QuestionnaireCreatedByUserId,
	cu.Firstname as QuestionnaireCreatedByFirstName,
	cu.LastName as QuestionnaireCreatedByLastName,
	shq.Text as ShiftHandoverQuestionText,
	sha.Comments as ShiftHandoverAnswerComments,
	sha.Answer as ShiftHandoverAnswer
from dbo.ShiftHandoverAnswer sha
	inner join dbo.ShiftHandoverQuestion shq on shq.Id = sha.ShiftHandoverQuestionId
	inner join dbo.ShiftHandoverQuestionnaire shqre on shqre.Id = sha.ShiftHandoverQuestionnaireId
	inner join dbo.[User] cu on cu.Id = shqre.CreatedByUserId
	left outer join dbo.WorkAssignment wa on wa.Id = shqre.WorkAssignmentId
where 	
	shq.Deleted = 0
GO