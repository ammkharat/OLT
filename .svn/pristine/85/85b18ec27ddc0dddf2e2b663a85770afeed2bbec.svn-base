if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUserWorkPermitDefaultTimePreferences]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUserWorkPermitDefaultTimePreferences]
GO

CREATE Procedure [dbo].[InsertUserWorkPermitDefaultTimePreferences]
(
	@Id bigint Output,
	@UserId bigint,
	@PreShiftPadding datetime,
	@PostShiftPadding datetime
)
AS

INSERT INTO UserWorkPermitDefaultTimesPreference
	(
		UserId,
		PreShiftPadding,
		PostShiftPadding
	)
VALUES	
	(
		@UserId,
		@PreShiftPadding,
		@PostShiftPadding
	)

SET @Id = SCOPE_IDENTITY() 
GO 

GRANT EXEC ON [dbo].[InsertUserWorkPermitDefaultTimePreferences] TO PUBLIC
GO