if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertLogGuideline]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertLogGuideline]
GO

CREATE Procedure [dbo].[InsertLogGuideline]
    (
    @Id bigint Output,
    @FunctionalLocationId bigint,    
    @Text varchar(MAX) = NULL
    )
AS

INSERT INTO LogGuideline
(
    [FunctionalLocationId],    
    [Text]
)
VALUES
(    
    @FunctionalLocationId,
    @Text
)
SET @Id= SCOPE_IDENTITY() 
GO 
GRANT EXEC ON InsertLogGuideline TO PUBLIC
GO  