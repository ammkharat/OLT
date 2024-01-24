IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryShiftHandoverQuestionsByConfigurationId')
	BEGIN
		DROP PROCEDURE [dbo].QueryShiftHandoverQuestionsByConfigurationId
	END
GO

CREATE Procedure dbo.QueryShiftHandoverQuestionsByConfigurationId
	(
	@ConfigurationId bigint
	)
AS

SELECT * 
FROM 
	ShiftHandoverQuestion 
WHERE 
	[ShiftHandoverConfigurationId] = @ConfigurationId 
	and Deleted = 0
	and IsCurrentQuestionVersion = 1
GO

GRANT EXEC ON QueryShiftHandoverQuestionsByConfigurationId TO PUBLIC
GO