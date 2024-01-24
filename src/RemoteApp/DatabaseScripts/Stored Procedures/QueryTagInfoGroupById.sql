IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryTagInfoGroupById')
    BEGIN
        DROP PROCEDURE [dbo].QueryTagInfoGroupById
    END
GO

CREATE Procedure [dbo].QueryTagInfoGroupById
(
    @Id bigint
)
AS

SELECT
    *
FROM
    TagGroup
WHERE
    TagGroup.Id = @Id
GO

GRANT EXEC ON QueryTagInfoGroupById TO PUBLIC
GO