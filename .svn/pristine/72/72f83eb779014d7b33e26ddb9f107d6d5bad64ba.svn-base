if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateDirective]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateDirective]
GO

CREATE Procedure [dbo].[UpdateDirective]
(
	@Id bigint,			
	@ActiveFromDateTime DateTime,
	@ActiveToDateTime DateTime,
	@Content varchar(max),
	@PlainTextContent varchar(max),
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime DateTime
)
AS

UPDATE Directive
SET 
	ActiveFromDateTime = @ActiveFromDateTime,	
	ActiveToDateTime = @ActiveToDateTime,			
	Content = @Content,
	PlainTextContent = @PlainTextContent,
	LastModifiedDateTime = @LastModifiedDateTime,
	LastModifiedByUserId = @LastModifiedByUserId
WHERE
	Id = @Id

GO

GRANT EXEC ON UpdateDirective TO PUBLIC
GO