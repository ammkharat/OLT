IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateWorkAssignment')
	BEGIN
		DROP  Procedure  UpdateWorkAssignment
	END

GO

CREATE Procedure [dbo].UpdateWorkAssignment

	(
		@workAssignmentId bigint,
		@description varchar(75),
		@name varchar(40),
		@category varchar(75) = null,
		@roleId bigint,
		@useWorkAssignmentForActionItemHandoverDisplay bit,
		@ShowLubesCsdOnShiftHandoverReport bit,
		@ShowEventExcursionsOnShiftHandoverReport bit,
		@CopyTargetAlertResponseToLog bit,
		@AutoInsertLogTemplateId bigint = NULL
	)

AS
UPDATE 
	WorkAssignment 
SET 
	Description = @description, 
	[Name] = @name,
	RoleId = @roleId,
	Category = @category,
	UseWorkAssignmentForActionItemHandoverDisplay = @useWorkAssignmentForActionItemHandoverDisplay,
	ShowLubesCsdOnShiftHandoverReport = @ShowLubesCsdOnShiftHandoverReport,
	ShowEventExcursionsOnShiftHandoverReport = @ShowEventExcursionsOnShiftHandoverReport,
	CopyTargetAlertResponseToLog = @CopyTargetAlertResponseToLog,
	AutoInsertLogTemplateId = @AutoInsertLogTemplateId	
WHERE
	Id = @workAssignmentId
GO
 