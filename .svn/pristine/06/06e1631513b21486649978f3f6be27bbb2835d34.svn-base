if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertWorkPermitEdmontonGroup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertWorkPermitEdmontonGroup]
GO

CREATE Procedure [dbo].[InsertWorkPermitEdmontonGroup]
	(
	@Id bigint Output,
	@Name varchar(100),
	@DisplayOrder int,
	@DefaultToDayShiftOnSapImport bit
	)
AS

INSERT INTO WorkPermitEdmontonGroup ([Name], DisplayOrder, Deleted, DefaultToDayShiftOnSapImport)
VALUES (@Name, @DisplayOrder, 0, @DefaultToDayShiftOnSapImport)

SET @Id= SCOPE_IDENTITY() 
GO 

GRANT EXEC ON InsertWorkPermitEdmontonGroup TO PUBLIC
GO
