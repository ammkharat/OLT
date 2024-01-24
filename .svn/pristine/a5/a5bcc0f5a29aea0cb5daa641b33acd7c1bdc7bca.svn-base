if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertTagInfo]') and OBJECTPROPERTY(id,N'IsProcedure') = 1)
drop procedure [dbo].[InsertTagInfo]
GO

CREATE PROCEDURE [dbo].[InsertTagInfo]
(
    @Id bigint Output,
    @Name VARCHAR(100),
    @Description VARCHAR(150),
    @SiteId bigint,
    @ScadaConnectionInfoId bigint,
    @Units VARCHAR(32)
)
AS

INSERT INTO [dbo].Tag
(
    [Name],
    [Description],
    [Units],
    [SiteId],
    [ScadaConnectionInfoId]
)
VALUES
(
    @Name,
    @Description,
    @Units,
    @SiteId,
    @ScadaConnectionInfoId
)

SET @Id= SCOPE_IDENTITY()
GO