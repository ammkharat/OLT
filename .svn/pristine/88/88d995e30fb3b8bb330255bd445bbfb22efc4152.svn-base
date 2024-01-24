if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateUserWorkPermitDefaultTimePreferences]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateUserWorkPermitDefaultTimePreferences]
GO

CREATE Procedure [dbo].[UpdateUserWorkPermitDefaultTimePreferences]
(
	@Id bigint,
	@PreShiftPadding datetime,
	@PostShiftPadding datetime
)
AS

UPDATE UserWorkPermitDefaultTimesPreference
SET 
    PreShiftPadding = @PreShiftPadding,
    PostShiftPadding = @PostShiftPadding
WHERE Id=@Id
GO 

GRANT EXEC ON [dbo].[UpdateUserWorkPermitDefaultTimePreferences] TO PUBLIC
GO