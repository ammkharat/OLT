IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryUserGridLayout')
	BEGIN
		DROP PROCEDURE [dbo].QueryUserGridLayout
	END
GO

CREATE Procedure [dbo].QueryUserGridLayout(@UserId bigint, @GridId int)
AS

select * from UserGridLayout where UserId = @UserId and GridId = @GridId
GO

GRANT EXEC ON QueryUserGridLayout TO PUBLIC
GO