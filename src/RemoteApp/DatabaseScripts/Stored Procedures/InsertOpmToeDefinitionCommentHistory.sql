if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertOpmToeDefinitionCommentHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertOpmToeDefinitionCommentHistory]
GO

CREATE Procedure [dbo].[InsertOpmToeDefinitionCommentHistory]
(
	@Id bigint,		
	@ToeName nvarchar(255),	
	@Comment varchar(max),	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime
)
AS

INSERT INTO OpmToeDefinitionCommentHistory
(
	Id,
	ToeName,	
	Comment,	
	LastModifiedByUserId,
	LastModifiedDateTime
)
VALUES
(
	@Id,		
	@ToeName,	
	@Comment,
	@LastModifiedByUserId,
	@LastModifiedDateTime
);

GO

GRANT EXEC ON InsertOpmToeDefinitionCommentHistory TO PUBLIC
GO
