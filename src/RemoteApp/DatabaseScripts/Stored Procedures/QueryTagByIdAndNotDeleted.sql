IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTagByIdAndNotDeleted')
	BEGIN
		DROP PROCEDURE [dbo].QueryTagByIdAndNotDeleted
	END
GO

CREATE Procedure [dbo].QueryTagByIdAndNotDeleted
	(
		@id int
	)
AS

SELECT
    Id,
    Name,
    Description,
    Units,
    SiteId
FROM
    Tag
WHERE
    ID=@id
    AND DELETED = 0
GO

GRANT EXEC ON QueryTagByIdAndNotDeleted TO PUBLIC
GO