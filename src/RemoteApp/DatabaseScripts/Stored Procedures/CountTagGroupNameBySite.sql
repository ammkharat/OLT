IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CountTagGroupNameBySite')
    BEGIN
        DROP PROCEDURE [dbo].CountTagGroupNameBySite
    END
GO

CREATE Procedure [dbo].CountTagGroupNameBySite
    (
        @Name varchar (50),
        @SiteId BIGINT
    )
AS

SELECT
    Count(Id) as COUNT
FROM         
    TagGroup
WHERE 
    LOWER(TagGroup.[Name]) = LOWER(@Name) AND
    TagGroup.SiteId = @SiteId
GO

GRANT EXEC ON CountTagGroupNameBySite TO PUBLIC
GO