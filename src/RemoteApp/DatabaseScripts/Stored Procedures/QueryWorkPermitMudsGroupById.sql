
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitMudsGroupById')
	BEGIN
		DROP Procedure [dbo].QueryWorkPermitMudsGroupById
	END
GO

CREATE Procedure [dbo].[QueryWorkPermitMudsGroupById]
	(
		@Id int
	)
AS

SELECT g.*
FROM WorkPermitMudsGroup g
WHERE g.Id = @Id
GO

GRANT EXEC ON QueryWorkPermitMudsGroupById TO PUBLIC
GO
