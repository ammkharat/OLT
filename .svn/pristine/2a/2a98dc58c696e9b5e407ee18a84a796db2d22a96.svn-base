IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryUserWorkPermitDefaultTimePreferencesByUserId')
	BEGIN
		DROP PROCEDURE [dbo].QueryUserWorkPermitDefaultTimePreferencesByUserId
	END
GO

CREATE Procedure [dbo].[QueryUserWorkPermitDefaultTimePreferencesByUserId]
	(
		@UserId bigint
	)
AS

SELECT * FROM UserWorkPermitDefaultTimesPreference WHERE UserId = @UserId
GO

GRANT EXEC ON QueryUserWorkPermitDefaultTimePreferencesByUserId TO PUBLIC
GO