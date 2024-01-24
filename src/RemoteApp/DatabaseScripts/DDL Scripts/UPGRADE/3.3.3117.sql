ALTER TABLE dbo.ShiftHandoverQuestion
  ADD IsCurrentQuestionVersion BIT NULL
GO

UPDATE dbo.ShiftHandoverQuestion
  SET IsCurrentQuestionVersion = 1 
WHERE Deleted = 0

UPDATE dbo.ShiftHandoverQuestion
  SET IsCurrentQuestionVersion = 0 
WHERE Deleted = 1

ALTER TABLE dbo.ShiftHandoverQuestion
  ALTER COLUMN IsCurrentQuestionVersion BIT NOT NULL

ALTER TABLE dbo.ShiftHandoverAnswer
  DROP COLUMN QuestionText

  
ALTER TABLE  dbo.ShiftHandoverAnswerHistory
	ADD ShiftHandoverQuestionId bigint NULL
GO	

UPDATE dbo.ShiftHandoverAnswerHistory 
  SET ShiftHandoverQuestionId = 
	(SELECT q.Id 
		from ShiftHandoverQuestion q 
		Where q.[Text] = [QuestionText] and q.Deleted = 0 and q.IsCurrentQuestionVersion = 1)


ALTER TABLE dbo.ShiftHandoverAnswerHistory
	ALTER COLUMN ShiftHandoverQuestionId bigint NOT NULL
GO

ALTER TABLE [dbo].[ShiftHandoverAnswerHistory]
	ADD  CONSTRAINT [FK_ShiftHandoverAnswerHistory_ShiftHandoverQuestionId]
		FOREIGN KEY ([ShiftHandoverQuestionId])
	REFERENCES [dbo].[ShiftHandoverQuestion] ( [Id] )
GO

ALTER TABLE dbo.ShiftHandoverAnswerHistory
	DROP COLUMN [QuestionText]

	


  
GO
