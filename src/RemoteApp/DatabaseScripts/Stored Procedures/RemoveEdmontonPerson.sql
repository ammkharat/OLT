IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveEdmontonPerson')
    BEGIN
        DROP  Procedure  RemoveEdmontonPerson
    END

GO

CREATE Procedure [dbo].RemoveEdmontonPerson
(
    @Id bigint
)
AS

UPDATE EdmontonPerson
    SET
        [Deleted] = 1
    WHERE
        Id = @Id
GO