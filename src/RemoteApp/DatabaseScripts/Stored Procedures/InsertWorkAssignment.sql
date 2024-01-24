IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertWorkAssignment')
	BEGIN
		DROP  Procedure  InsertWorkAssignment
	END

GO

CREATE Procedure [dbo].InsertWorkAssignment
(
	@Id bigint Output,
	@Name varchar(100),
	@Description varchar(75),
	@Category varchar(75) = null,
	@SiteId bigint,
	@RoleId bigint,
	@UseWorkAssignmentForActionItemHandoverDisplay bit,
	@ShowLubesCsdOnShiftHandoverReport bit,
	@ShowEventExcursionsOnShiftHandoverReport bit,
	@CopyTargetAlertResponseToLog bit,
	@AutoInsertLogTemplateId bigint = NULL
)
AS
INSERT INTO WorkAssignment
	(
		[Name],
		Description,
		Category,
		SiteId,
		RoleId,
		UseWorkAssignmentForActionItemHandoverDisplay,
		ShowLubesCsdOnShiftHandoverReport,
		ShowEventExcursionsOnShiftHandoverReport,
		CopyTargetAlertResponseToLog,
		AutoInsertLogTemplateId
	)
	VALUES
	(
		@Name,
		@Description,
		@Category,
		@SiteId,
		@RoleId,
		@UseWorkAssignmentForActionItemHandoverDisplay,
		@ShowLubesCsdOnShiftHandoverReport,
		@ShowEventExcursionsOnShiftHandoverReport,
		@CopyTargetAlertResponseToLog,
		@AutoInsertLogTemplateId
	)

SET @Id= SCOPE_IDENTITY()	
GO
GRANT EXEC ON InsertWorkAssignment TO PUBLIC
GO
 