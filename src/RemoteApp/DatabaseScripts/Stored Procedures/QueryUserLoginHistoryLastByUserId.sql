IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryUserLoginHistoryLastByUserId')
	BEGIN
		DROP PROCEDURE [dbo].QueryUserLoginHistoryLastByUserId
	END
GO

CREATE Procedure dbo.QueryUserLoginHistoryLastByUserId
	(
		@userId bigint
	)
AS

SELECT 
	top 1 ulh.*
FROM
	UserLoginHistory ulh
WHERE
	ulh.UserId = @userId 
ORDER BY ulh.LoginDateTime DESC
GO

GRANT EXEC ON QueryUserLoginHistoryLastByUserId TO PUBLIC
GO