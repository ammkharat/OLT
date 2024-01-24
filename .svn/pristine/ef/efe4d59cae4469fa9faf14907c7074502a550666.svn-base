IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteAllUserGridLayoutsByUserId')
	BEGIN
		DROP  Procedure  DeleteAllUserGridLayoutsByUserId
	END

GO

CREATE Procedure [dbo].[DeleteAllUserGridLayoutsByUserId]
(
    @UserId bigint   
)
AS

delete from UserGridLayout where UserId = @UserId;

GO
 