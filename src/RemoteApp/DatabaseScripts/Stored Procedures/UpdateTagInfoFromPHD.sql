  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateTagInfoFromPHD')
    BEGIN
        DROP  Procedure  UpdateTagInfoFromPHD
    END

GO


CREATE Procedure [dbo].UpdateTagInfoFromPHD
(
    @Name VARCHAR(100),
    @Description VARCHAR(150),
    @Units varchar(32),
    @SiteId bigint
)

AS

UPDATE
    Tag
SET
    [Description] = @Description,
    [Units] = @Units,
    [Deleted] = 0
WHERE
    Name = @Name AND
    SiteId = @SiteId
GO