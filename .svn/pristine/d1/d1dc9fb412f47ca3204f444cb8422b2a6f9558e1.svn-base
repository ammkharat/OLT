if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertTagInfoGroup]') and OBJECTPROPERTY(id,N'IsProcedure') = 1)
drop procedure [dbo].[InsertTagInfoGroup]
GO

CREATE PROCEDURE [dbo].[InsertTagInfoGroup]
(
    @Id bigint Output,
    @Name VARCHAR(50),
    @SiteId bigint
)
AS

INSERT INTO [dbo].TagGroup
(
    [Name],
    [SiteId]
)
VALUES
(
    @Name,
    @SiteId
)

SET @Id = SCOPE_IDENTITY()
GO
GRANT EXEC ON [InsertTagInfoGroup] TO PUBLIC
GO