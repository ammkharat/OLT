IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTagInfoByTagGroupId')
    BEGIN
        DROP PROCEDURE [dbo].QueryTagInfoByTagGroupId
    END
GO

CREATE Procedure [dbo].QueryTagInfoByTagGroupId
(
    @TagGroupId bigint
)
AS

SELECT
    Tag.*
FROM
    Tag,
    TagGroupAssociation
WHERE
    TagGroupAssociation.TagGroupId = @TagGroupId AND
    Tag.Id = TagGroupAssociation.TagId
GO

GRANT EXEC ON QueryTagInfoByTagGroupId TO PUBLIC
GO