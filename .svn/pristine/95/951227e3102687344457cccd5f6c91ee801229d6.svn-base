IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveTagInfo')
    BEGIN
        DROP  Procedure  RemoveTagInfo
    END

GO

CREATE Procedure [dbo].RemoveTagInfo
(
    @Id bigint
)
AS

UPDATE 
	Tag
SET
	[Deleted] = 1
WHERE
	Id = @Id
GO