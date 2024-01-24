IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTagInfoBySiteId')
    BEGIN
        DROP PROCEDURE [dbo].QueryTagInfoBySiteId
    END
GO

CREATE Procedure [dbo].QueryTagInfoBySiteId
(
    @SiteId bigint,
    @PrefixCharacter varchar(80)
)
AS

SELECT * 
FROM 
	Tag
WHERE
    Tag.SiteId = @SiteId AND
    LOWER(Tag.[Name]) LIKE LOWER(@PrefixCharacter + '%')
ORDER BY 
	[Name]
GO

GRANT EXEC ON QueryTagInfoBySiteId TO PUBLIC
GO