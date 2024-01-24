IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CountLogChildren')
	BEGIN
		DROP PROCEDURE [dbo].CountLogChildren
	END
GO

CREATE Procedure [dbo].[CountLogChildren]
(
    @LogId bigint
)
AS

SELECT count(*)
FROM 
	[Log] l
WHERE
  ReplyToLogId = @LogId
  and
  Deleted = 0
GO

GRANT EXEC ON [dbo].[CountLogChildren] TO PUBLIC
GO