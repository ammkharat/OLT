if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateDropdownValue]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateDropdownValue]
GO

CREATE Procedure [dbo].[UpdateDropdownValue]
    (
	  @Id bigint Output,
      @Key varchar(100),
      @Value varchar(100),
      @DisplayOrder int
    )
AS

update DropdownValue
set
	[Key] = @Key,
	[Value] = @Value,
	DisplayOrder = @DisplayOrder
where Id = @Id

GO 

GRANT EXEC ON UpdateDropdownValue TO PUBLIC
GO  