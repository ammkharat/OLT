if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertDropdownValue]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertDropdownValue]
GO

CREATE Procedure [dbo].[InsertDropdownValue]
(
  @Id bigint Output,
  @Key varchar(100),
  @Value varchar(100),
  @DisplayOrder int,
  @SiteId bigint
)
AS

INSERT INTO DropdownValue
(
	[Key],
    Value,
	Deleted,
	DisplayOrder,
	SiteId
)
VALUES
(
	@Key,
	@Value,
	0,
	@DisplayOrder,
	@SiteId
);

SET @Id= SCOPE_IDENTITY()

GO

GRANT EXEC ON InsertDropdownValue TO PUBLIC
GO
