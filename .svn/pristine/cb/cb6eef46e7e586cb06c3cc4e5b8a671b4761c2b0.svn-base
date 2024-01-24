if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateTagInfoGroup]') and OBJECTPROPERTY(id,N'IsProcedure') = 1)
drop procedure [dbo].[UpdateTagInfoGroup]
GO

CREATE PROCEDURE [dbo].[UpdateTagInfoGroup]
(
    @Id BIGINT,
    @Name VARCHAR(50),
    @SiteId bigint
)
AS

UPDATE
    TagGroup
SET
    TagGroup.Name = @Name,
    TagGroup.SiteId = @SiteId
WHERE
    TagGroup.Id = @Id
GO

GRANT EXEC ON [UpdateTagInfoGroup] TO PUBLIC
GO 