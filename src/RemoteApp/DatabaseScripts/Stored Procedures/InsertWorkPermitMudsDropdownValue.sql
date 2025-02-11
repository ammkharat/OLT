
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertWorkPermitMudsDropdownValue')
	BEGIN
		DROP Procedure [dbo].InsertWorkPermitMudsDropdownValue
	END
GO

CREATE Procedure [dbo].[InsertWorkPermitMudsDropdownValue]
(
  @Id bigint Output,
  @Key varchar(100),
  @Value varchar(100),
  @DisplayOrder int
)
AS

INSERT INTO WorkPermitMudsDropdownValue
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


GRANT EXEC ON InsertWorkPermitMudsDropdownValue TO PUBLIC
GO

