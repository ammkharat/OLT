IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteUserLoginHistoryFunctionalLocations')
	BEGIN
		DROP  Procedure  DeleteUserLoginHistoryFunctionalLocations
	END

GO

CREATE Procedure [dbo].[DeleteUserLoginHistoryFunctionalLocations]
(
    @UserLoginHistoryId bigint
)
AS

DELETE FROM UserLoginHistoryFunctionalLocation
WHERE UserLoginHistoryId = @UserLoginHistoryId

GO
 