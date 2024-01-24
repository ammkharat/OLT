IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitHistoriesById')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkPermitHistoriesById
	END
GO

CREATE Procedure [dbo].QueryWorkPermitHistoriesById
	(
	@Id bigint
	)
AS
SELECT wph.*, wphe.* 
FROM WorkPermitHistory wph
LEFT OUTER JOIN WorkPermitHistory_Extension wphe on wphe.Id = wph.Id and wphe.LastModifiedDate = wph.LastModifiedDate
WHERE wph.Id = @Id
ORDER BY wph.LastModifiedDate
GO

GRANT EXEC ON QueryWorkPermitHistoriesById TO PUBLIC
GO