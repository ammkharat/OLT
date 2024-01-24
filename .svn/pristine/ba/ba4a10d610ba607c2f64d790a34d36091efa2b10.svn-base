 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveTagInfoGroup')
    BEGIN
        DROP  Procedure  RemoveTagInfoGroup
    END

GO

CREATE Procedure [dbo].RemoveTagInfoGroup
(
    @Id bigint
)
AS

DELETE
FROM
    TagGroup
WHERE
    Id = @Id

GO

GRANT EXEC ON RemoveTagInfoGroup TO PUBLIC

GO