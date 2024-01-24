IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VReportingShiftHandoverAnswers')
BEGIN
	DROP VIEW VReportingShiftHandoverAnswers
END
GO

CREATE VIEW dbo.VReportingShiftHandoverAnswers WITH SCHEMABINDING
AS
select 
	shqre.ShiftHandoverConfigurationName as ShiftHandoverConfigurationNameWhenAnswered,	
	shqre.CreatedDateTime as QuestionnaireCreatedDateTime,
	shqre.LastModifiedDateTime as QuestionnaireLastModifiedDateTime,
	sh.Name as ShiftName,
	cu.Username as QuestionnaireCreatedByUserId,
	cu.Firstname as QuestionnaireCreatedByFirstName,
	cu.LastName as QuestionnaireCreatedByLastName,
	shq.Text as ShiftHandoverQuestionText,
	sha.Comments as ShiftHandoverAnswerComments,
	sha.Answer as ShiftHandoverAnswer,
	wa.Name as WorkAssignmentName,
	(select top 1 fl.SiteId from dbo.ShiftHandoverQuestionnaireFunctionalLocation shqfl
		inner join dbo.FunctionalLocation fl on fl.Id = shqfl.FunctionalLocationId
		where shqfl.ShiftHandoverQuestionnaireId = shqre.Id) as SiteId,			
	(select top 1 s.Name from dbo.ShiftHandoverQuestionnaireFunctionalLocation shqfl
		inner join dbo.FunctionalLocation fl on fl.Id = shqfl.FunctionalLocationId
		inner join dbo.[Site] s on s.Id = fl.SiteId
		where shqfl.ShiftHandoverQuestionnaireId = shqre.Id) as Site
			
from dbo.ShiftHandoverAnswer sha
	inner join dbo.ShiftHandoverQuestion shq on shq.Id = sha.ShiftHandoverQuestionId
	inner join dbo.ShiftHandoverQuestionnaire shqre on shqre.Id = sha.ShiftHandoverQuestionnaireId
	inner join dbo.[User] cu on cu.Id = shqre.CreatedByUserId
	inner join dbo.Shift sh on sh.Id = shqre.ShiftId	
	left outer join dbo.WorkAssignment wa on wa.Id = shqre.WorkAssignmentId
where 	
	shq.Deleted = 0
GO