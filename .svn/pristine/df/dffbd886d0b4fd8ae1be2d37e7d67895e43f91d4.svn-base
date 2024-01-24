if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemoveTagGroupAndTagAssociation]') and OBJECTPROPERTY(id,N'IsProcedure') = 1)
drop procedure [dbo].[RemoveTagGroupAndTagAssociation]
GO

CREATE PROCEDURE [dbo].[RemoveTagGroupAndTagAssociation]
(
    @TagGroupId BIGINT,
    @TagId BIGINT
)
AS
    DELETE
    FROM
        [dbo].TagGroupAssociation
    WHERE
        TagGroupAssociation.TagGroupId = @TagGroupId AND
        TagGroupAssociation.TagId = @TagId
GO