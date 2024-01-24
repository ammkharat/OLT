IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitMontrealGroupById')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkPermitMontrealGroupById
	END
GO

CREATE Procedure [dbo].QueryWorkPermitMontrealGroupById
	(
		@Id int
	)
AS

SELECT g.*
FROM WorkPermitMontrealGroup g
WHERE g.Id = @Id
GO

GRANT EXEC ON QueryWorkPermitMontrealGroupById TO PUBLIC
GO