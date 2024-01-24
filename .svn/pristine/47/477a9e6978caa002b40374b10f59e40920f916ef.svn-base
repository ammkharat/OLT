IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteUserGridLayout')
	BEGIN
		DROP  Procedure  DeleteUserGridLayout
	END

GO

CREATE Procedure [dbo].[DeleteUserGridLayout]
(
    @UserId bigint,
    @GridId int
)
AS

delete from UserGridLayout where UserId = @UserId and GridId = @GridId

GO
 