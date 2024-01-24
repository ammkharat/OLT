  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveDropdownValue')
	BEGIN
		DROP Procedure RemoveDropdownValue
	END

GO

CREATE Procedure dbo.RemoveDropdownValue(@Id bigint)
AS

update DropdownValue set Deleted = 1 WHERE Id = @Id

GO

GRANT EXEC ON RemoveDropdownValue TO PUBLIC

GO
