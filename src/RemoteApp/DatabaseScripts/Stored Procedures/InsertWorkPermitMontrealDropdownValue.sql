if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertWorkPermitMontrealDropdownValue]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertWorkPermitMontrealDropdownValue]
GO

CREATE Procedure [dbo].[InsertWorkPermitMontrealDropdownValue]
(
  @Id bigint Output,
  @Key varchar(100),
  @Value varchar(100),
  @DisplayOrder int
)
AS

INSERT INTO WorkPermitMontrealDropdownValue
(
	[Key],
    Value,
	Deleted,
	DisplayOrder
)
VALUES
(
	@Key,
	@Value,
	0,
	@DisplayOrder
);

SET @Id= SCOPE_IDENTITY()

GO

GRANT EXEC ON InsertWorkPermitMontrealDropdownValue TO PUBLIC
GO
