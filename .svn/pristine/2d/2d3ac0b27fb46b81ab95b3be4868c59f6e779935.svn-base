if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertTagGroupAndTagAssociation]') and OBJECTPROPERTY(id,N'IsProcedure') = 1)
drop procedure [dbo].[InsertTagGroupAndTagAssociation]
GO

CREATE PROCEDURE [dbo].[InsertTagGroupAndTagAssociation]
(
    @TagGroupId BIGINT,
    @TagId BIGINT
)
AS
INSERT INTO [dbo].TagGroupAssociation
(
    TagGroupId,
    TagId
)
VALUES
(
    @TagGroupId,
    @TagId
)
GO
GRANT EXEC ON [InsertTagGroupAndTagAssociation] TO PUBLIC
GO