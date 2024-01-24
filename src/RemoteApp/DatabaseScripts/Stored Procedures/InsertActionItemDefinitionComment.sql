if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertActionItemDefinitionComment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertActionItemDefinitionComment]
GO


CREATE Procedure [dbo].[InsertActionItemDefinitionComment]
    (
    @Id bigint Output,
    @ActionItemDefinitionId bigint,
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

INSERT INTO ActionItemDefinitionComment
(
    ActionItemDefinitionId,
    CommentId
)
VALUES
(
    @ActionItemDefinitionId,
    @Id
)
GO 

GRANT EXEC ON InsertActionItemDefinitionComment TO PUBLIC
GO 