if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertTargetDefinitionComment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertTargetDefinitionComment]
GO


CREATE Procedure [dbo].[InsertTargetDefinitionComment]
    (
    @Id bigint Output,
    @TargetDefinitionId bigint,
    @CreatedUserId bigint,
    @CreatedDate datetime,
    @Text VARCHAR(MAX)
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

INSERT INTO TargetDefinitionComment
(
    TargetDefinitionId,
    CommentId
)
VALUES
(
    @TargetDefinitionId,
    @Id
)

GO 

GRANT EXEC ON InsertTargetDefinitionComment TO PUBLIC

GO