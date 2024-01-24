if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertComment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertComment]
GO

CREATE Procedure [dbo].[InsertComment]
    (
    @Id bigint Output,
    @CreatedUserId bigint,
    @CreatedDate datetime,
    @Text varchar(MAX)
    )
AS

INSERT INTO Comment
(
    [CreatedUserId],
    [CreatedDate],
    [Text]
)
VALUES
(
    @CreatedUserId,
    @CreatedDate,
    @Text
)
SET @Id= SCOPE_IDENTITY() 
GO 
GRANT EXEC ON InsertComment TO PUBLIC
GO  