if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertConfiguredDocumentLink]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertConfiguredDocumentLink]
GO

CREATE Procedure [dbo].[InsertConfiguredDocumentLink]
(
  @Id bigint Output,
  @Title varchar(100),
  @Link varchar(1000),
  @Location varchar(100),
  @DisplayOrder int
)
AS

INSERT INTO ConfiguredDocumentLink
(
	Title,
    Link,
	Location,
	Deleted,
	DisplayOrder
)
VALUES
(
	@Title,
	@Link,
	@Location,
	0,
	@DisplayOrder
);

SET @Id= SCOPE_IDENTITY()

GO

GRANT EXEC ON InsertConfiguredDocumentLink TO PUBLIC
GO
