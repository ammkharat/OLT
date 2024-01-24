IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUserLoginHistoryFunctionalLocation')
	BEGIN
		DROP  Procedure  InsertUserLoginHistoryFunctionalLocation
	END

GO

CREATE Procedure dbo.InsertUserLoginHistoryFunctionalLocation
	(
		@UserLoginHistoryId bigint,
		@FunctionalLocationId bigint
	)

AS
	insert into UserLoginHistoryFunctionalLocation
	(UserLoginHistoryId, FunctionalLocationId)
	values
	(@UserLoginHistoryId, @FunctionalLocationId)

GO
