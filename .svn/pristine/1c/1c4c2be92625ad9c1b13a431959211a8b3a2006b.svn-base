if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemoveUserPreferences]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].RemoveUserPreferences
GO

CREATE Procedure [dbo].RemoveUserPreferences
	(
		@id bigint
	)
AS

DELETE FROM UserPreferences WHERE Id = @id
GO

GRANT EXEC ON RemoveUserPreferences TO PUBLIC
GO  