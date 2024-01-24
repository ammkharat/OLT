if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateConfiguredDocumentLink]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateConfiguredDocumentLink]
GO

CREATE Procedure [dbo].[UpdateConfiguredDocumentLink]
    (
	  @Id bigint Output,
	  @Title varchar(100),
	  @Link varchar(1000),
	  @Location varchar(100),
	  @DisplayOrder int
    )
AS

update ConfiguredDocumentLink
set
	Title = @Title,
	Link = @Link,
	Location = @Location,
	DisplayOrder = @DisplayOrder
where Id = @Id

GO 

GRANT EXEC ON UpdateConfiguredDocumentLink TO PUBLIC
GO  