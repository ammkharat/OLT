IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryUserLoginHistoryFunctionalLocation')
	BEGIN
		DROP PROCEDURE [dbo].QueryUserLoginHistoryFunctionalLocation
	END
GO

CREATE Procedure dbo.QueryUserLoginHistoryFunctionalLocation
	(
		@UserLoginHistoryId bigint
	)
AS

SELECT 
	h.*
FROM
	UserLoginHistoryFunctionalLocation h,
	FunctionalLocation f
WHERE
	h.FunctionalLocationId = f.Id and
	f.Deleted = 0 and
	h.UserLoginHistoryId = @UserLoginHistoryId
GO

GRANT EXEC ON QueryUserLoginHistoryFunctionalLocation TO PUBLIC
GO