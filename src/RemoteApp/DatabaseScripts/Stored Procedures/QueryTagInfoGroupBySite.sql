IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTagInfoGroupBySite')
    BEGIN
        DROP PROCEDURE [dbo].QueryTagInfoGroupBySite
    END
GO

CREATE Procedure [dbo].QueryTagInfoGroupBySite
(
    @SiteId bigint
)
AS

SELECT
    *
FROM
    TagGroup
WHERE
    TagGroup.SiteId = @SiteId
GO

GRANT EXEC ON QueryTagInfoGroupBySite TO PUBLIC
GO