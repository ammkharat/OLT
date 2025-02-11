if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertOpmToeDefinitionComment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertOpmToeDefinitionComment]
GO

CREATE Procedure [dbo].[InsertOpmToeDefinitionComment]
    (
    @Id bigint Output,
    @ToeVersion bigint,    
    @HistorianTag nvarchar(255),
    @ToeName nvarchar(255),
    @LastModifiedByUserId bigint,
    @Comment nvarchar(255),
    @LastModifiedDateTime datetime,
	@OltToeDefinitionId bigint
    )
AS

INSERT INTO OpmToeDefinitionComment
(
	ToeVersion,
    HistorianTag,
    ToeName,
	LastModifiedByUserId,
	[Comment],
	LastModifiedDateTime,
	OltToeDefinitionId
)
VALUES
(	
    @ToeVersion,
    @HistorianTag,
    @ToeName,
    @LastModifiedByUserId,
    @Comment,
	@LastModifiedDateTime,
	@OltToeDefinitionId
)
SET @Id= SCOPE_IDENTITY() 

GRANT EXEC ON [InsertOpmToeDefinitionComment] TO PUBLIC
GO
